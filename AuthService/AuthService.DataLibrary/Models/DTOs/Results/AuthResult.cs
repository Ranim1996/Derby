using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.DataLibrary.Models.DTOs.Results
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
