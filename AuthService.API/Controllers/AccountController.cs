using AuthService.API.Configuration;
using AuthService.API.Data;
using AuthService.DataLibrary.DataAccess;
using AuthService.DataLibrary.Models;
using AuthService.DataLibrary.Models.DTOs;
using AuthService.DataLibrary.Models.DTOs.Requests;
using AuthService.DataLibrary.Models.DTOs.Responses;
using Derby.MessageBus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountData _accountData;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParams;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMessageBus _messageBus;

        public AccountController(IAccountData accountData, UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor,
            TokenValidationParameters tokenValidationParams, ApplicationDbContext Context, RoleManager<IdentityRole> roleManager, IMessageBus messageBus)
        {
            _accountData = accountData;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _tokenValidationParams = tokenValidationParams;
            _context = Context;
            _roleManager = roleManager;
            _messageBus = messageBus;
        }

        [HttpGet]
        [Route("getacconts")]
        public List<AccountModel> GetAccounts()
        {
            return _accountData.GetAccounts();
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterNewAccount(AccountModelDto accountDto)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(accountDto.EmailAddress);

                if (existingUser != null)
                {
                    return BadRequest(new AuthResponse(){
                        Errors = new List<string>() {
                                "Email already in use"
                        },
                        Success = false
                    });
                }

                var newUser = new IdentityUser()
                {
                    Email = accountDto.EmailAddress,
                    EmailConfirmed = true,
                    UserName = accountDto.FirstName + accountDto.LastName
                };

                var isCreated = await _userManager.CreateAsync(newUser, accountDto.Password);

                if (isCreated.Succeeded)
                {
                    try
                    {
                        var t = new IdentityRole
                        {
                            Name = "ADMIN"
                        };
                        var existingRole = await _roleManager.FindByNameAsync(new IdentityRole { Name = "ADMIN"}.Name);

                        if (existingRole == null)
                        {
                            await _roleManager.CreateAsync(t);
                        }
                        await _userManager.AddToRoleAsync(newUser, "ADMIN");
                        
                    }
                    catch (Exception ex)
                    {

                        return Ok(ex.Message);
                    }

                    existingUser = await _userManager.FindByEmailAsync(accountDto.EmailAddress);

                    if (existingUser is null)
                    {
                        return BadRequest(new AuthResponse()
                        {
                            Errors = new List<string>() {
                                "User model is null"
                            },
                            Success = false
                        });
                    }

                    var jwtToken = await GenerateJwtToken(newUser);
                    
                    AccountModel accountModel = new()
                    {
                        Id = existingUser.Id,
                        FirstName = accountDto.FirstName,
                        LastName = accountDto.LastName,
                        EmailAddress = accountDto.EmailAddress
                    };

                    await _accountData.CreateAccount(accountModel);

                    //TODO: the topic name must be added in the appsettingsjson
                    await _messageBus.PublishMessage(accountModel, "createusertopic");

                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest(new AuthResponse()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }

            }

            return BadRequest(new AuthResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AccountLoginRequest account)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(account.Email);

                if (existingUser == null)
                {
                    return BadRequest(new AuthResponse()
                    {
                        Errors = new List<string>() {
                                "No user with the given request"
                            },
                        Success = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, account.Password);

                if (!isCorrect)
                {
                    return BadRequest(new AuthResponse()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    });
                }

                var jwtToken = await GenerateJwtToken(existingUser);

                return Ok(jwtToken);
            }

            return BadRequest(new AuthResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        private async Task<AuthResult> GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var claims = await GetAllValidClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            await _context.SaveChangesAsync();

            return new AuthResult()
            {
                Token = jwtToken,
                Success = true,
            };
        }

        private async Task<List<Claim>> GetAllValidClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole);

                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));

                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }
    }
}
