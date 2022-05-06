using ActivityService.DataLibrary.Models;
using System.Collections.Generic;

namespace ActivityService.DataLibrary.DataAccess.Interfaces
{
    public interface IEventData
    {
        List<EventModel> GetEvents();
        void AddEvent(EventModel eventModel);
        void UpdateEvent(EventModel eventModel);
        List<EventModel> GetEventsByUserId(int id);
        void DeleteEvent(string id);
    }
}
