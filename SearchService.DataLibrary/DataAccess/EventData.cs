using SearchService.DataLibrary.DataAccess.Interfaces;
using SearchService.DataLibrary.Internal.DataAccess;
using SearchService.DataLibrary.Models;

namespace SearchService.DataLibrary.DataAccess
{
    public class EventData: IEventData
    {
        private readonly ISqlDataAccess _sql;

        public EventData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public void AddEvent(EventModel eventModel)
        {
            var p = new
            {
                eventTitle = eventModel.Title,
                eventDescription = eventModel.Description,
                eventDate = eventModel.When,
                eventLocation = eventModel.Where
            };

            _sql.SaveData("dbo.AddEvent", p, "SearchDB");
        }
    }
}
