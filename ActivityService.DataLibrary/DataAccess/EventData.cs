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
                eventId = eventModel.Id,
                eventTitle = eventModel.Title,
                eventDescription = eventModel.Description,
                eventWhen= eventModel.When,
                eventWhere = eventModel.Where
            };

            _sql.SaveData("dbo.AddEvent", p, "ActivityDB");
        }

        public void DeleteEvent(string id)
        {
            _sql.SaveData("dbo.DeleteEvent", new { eventId = id }, "ActivityDB");
        }

        public List<EventModel> GetEventById(string id)
        {
            var output = _sql.LoadData<EventModel, dynamic>("dbo.GetEventById", new { eventId = id }, "ActivityDB");

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
                eventTitle = eventModel.Title,
                eventDescription = eventModel.Description,
                eventWhen = eventModel.When,
                eventWhere = eventModel.Where
            };

            _sql.SaveData("dbo.UpdateEvent", p, "ActivityDB");
        }
    }
}
