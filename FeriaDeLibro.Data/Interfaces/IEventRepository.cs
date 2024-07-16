using FeriaDeLibro.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Data.Interfaces
{
    public interface IEventRepository
    {
        Task<bool> AddEvent(Event evento);
        Task<bool> RemoveEvent(Event evento);
        Task UpdateEvent(Event evento);
        Task<Event> GetEventById(int id);
        Task<ICollection<Event>> GetAllEvents();
        Task<ICollection<Event>> GetAllFutureEvents();
    }
}
