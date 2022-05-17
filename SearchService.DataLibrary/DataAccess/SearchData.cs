using SearchService.DataLibrary.DataAccess.Interfaces;
using SearchService.DataLibrary.Internal.DataAccess;
using SearchService.DataLibrary.Models;
using System.Collections.Generic;

namespace SearchService.DataLibrary.DataAccess
{
    public class SearchData : ISearchData
    {
        private readonly ISqlDataAccess _sql;

        public SearchData(ISqlDataAccess sql) 
        {
            _sql = sql;
        }

        public List<EventModel> GetEventsByLocation(string location)
        {
            var output = _sql.LoadData<EventModel, dynamic>("dbo.GetEventsByLocation", new { location = location }, "SearchDB");

            return output;
        }
    }
}
