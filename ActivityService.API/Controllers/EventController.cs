using ActivityService.DataLibrary.DataAccess.Interfaces;
using ActivityService.DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ActivityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventData _eventData;
        public EventController(IEventData eventData)
        {
            _eventData = eventData;
        }

        [HttpGet]
        [Route("getevents")]
        public List<EventModel> GetEvents()
        {
            return _eventData.GetEvents();
        }

        [HttpGet]
        [Route("geteventbyUserId")]
        public List<EventModel> GetEventsByUserId(int id)
        {
            List<EventModel> events = _eventData.GetEventsByUserId(id);
            return events;
        }

        [HttpPut]
        [Route("updateevent")]
        public void UpdateEvent(EventModel eventModel)
        {
            _eventData.UpdateEvent(eventModel);
        }

        [HttpPost]
        [Route("addevent")]
        public void AddEvent(EventModel eventModel)
        {
            _eventData.AddEvent(eventModel);
        }

        [HttpDelete]
        [Route("deleteEvent")]
        public void DeleteEvent(string id)
        {
            _eventData.DeleteEvent(id);
        }
    }
}
