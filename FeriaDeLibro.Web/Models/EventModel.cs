using FeriaDeLibro.Entities.Models;

namespace FeriaDeLibro.Web.Models
{
    public class EventModel
    {
        public ICollection<Event> Events { get; set; }
    }
}
