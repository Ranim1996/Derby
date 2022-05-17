using System;

namespace SearchService.DataLibrary.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime When { get; set; }
        public string Where { get; set; }
    }
}
