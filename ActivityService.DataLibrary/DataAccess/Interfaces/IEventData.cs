using ActivityService.DataLibrary.Models;
using ActivityService.DataLibrary.Models.DTO;
using System.Collections.Generic;

namespace ActivityService.DataLibrary.DataAccess.Interfaces
{
    public interface IEventData
    {
        List<EventModel> GetEvents();
        void AddEvent(EventModel eventModel);
        void UpdateEvent(EventModel eventModel);
        List<EventModel> GetEventsByUserId(string userId);
        List<EventModel> GetEventById(int eventId);
        void DeleteEvent(int eventId, string userId);
        void JoinEvent(UserEventModel userEventModel);
        List<UserEventDTO> GetJoinedUsers(int eventId);
    }
}
