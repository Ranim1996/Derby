using ActivityService.DataLibrary.DataAccess.Interfaces;
using ActivityService.DataLibrary.Internal.DataAccess;
using ActivityService.DataLibrary.Models;
using System;
using System.Collections.Generic;

namespace ActivityService.DataLibrary.DataAccess
{
    public class EventData : IEventData
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
                userId = eventModel.UserId,
                eventTitle = eventModel.Title,
                eventDescription = eventModel.Description,
                eventDate = eventModel.When,
                eventLocation = eventModel.Where
            };

            _sql.SaveData("dbo.AddEvent", p, "ActivityDB");
        }

        public void DeleteEvent(int eventId, string userId)
        {
            _sql.SaveData("dbo.DeleteEvent", new { eventId = eventId, userId = userId }, "ActivityDB");
        }

        public List<EventModel> GetEventsByUserId(string userId)
        {
            var output = _sql.LoadData<EventModel, dynamic>("dbo.GetEventsByUserId", new { userId = userId }, "ActivityDB");

            return output;
        }

        public List<EventModel> GetEvents()
        {
            var output = _sql.LoadData<EventModel, dynamic>("dbo.GetEvents", new { }, "ActivityDB");

            return output;
        }

        public void UpdateEvent(EventModel eventModel)
        {
            var p = new
            {
                eventId = eventModel.Id,
                userId = eventModel.UserId,
                eventTitle = eventModel.Title,
                eventDescription = eventModel.Description,
                eventDate = eventModel.When,
                eventLocation = eventModel.Where
            };

            _sql.SaveData("dbo.UpdateEvent", p, "ActivityDB");
        }

        public List<EventModel> GetEventById(int eventId)
        {
            var output = _sql.LoadData<EventModel, dynamic>("dbo.GetEventById", new { eventId = eventId }, "ActivityDB");

            return output;
        }
    }
}
