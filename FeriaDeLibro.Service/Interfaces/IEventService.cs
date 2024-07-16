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
        Task<Result<bool>> AddEvent(Event evento);
        Task RemoveEvent(Event evento);
        Task<Event> GetEventById(int id);
        Task<ICollection<Event>> GetAllEvents();
        Task<ICollection<Event>> GetAllFutureEvents();
        Task UpdateEvent(Event evento);
    }
}
