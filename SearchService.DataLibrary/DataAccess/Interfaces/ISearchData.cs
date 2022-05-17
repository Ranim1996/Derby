using SearchService.DataLibrary.Models;
using System.Collections.Generic;

namespace SearchService.DataLibrary.DataAccess.Interfaces
{
    public interface ISearchData
    {
        List<EventModel> GetEventsByLocation(string location);
    }
}
