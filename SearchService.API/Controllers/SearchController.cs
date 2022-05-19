using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SearchService.DataLibrary.DataAccess.Interfaces;
using SearchService.DataLibrary.Models;
using System.Collections.Generic;

namespace SearchService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchData _searchData;
        public SearchController(ISearchData searchData)
        {
            _searchData = searchData;
        }

        [HttpGet]
        [Route("geteventsbylocation")]
        public List<EventModel> GetEventsByLocation(string location)
        {
            return _searchData.GetEventsByLocation(location);
        }
    }
}
