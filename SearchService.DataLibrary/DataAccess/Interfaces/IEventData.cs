using SearchService.DataLibrary.Models;

namespace SearchService.DataLibrary.DataAccess.Interfaces
{
    public interface IEventData
    {
        void AddEvent(EventModel eventModel);
    }
}
