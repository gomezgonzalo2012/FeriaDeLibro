using FeriaDeLibro.Entities.Errors;
using FeriaDeLibro.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Interfaces
{
    public interface IEventService
    {
        Result<bool> AddEvent(Event evento);
        void RemoveEvent(Event evento);
        Event GetEventById(int id);
        ICollection<Event> GetAllEvents();
        ICollection<Event> GetAllFutureEvents();
        void UpdateEvent(Event evento);
    }
}
