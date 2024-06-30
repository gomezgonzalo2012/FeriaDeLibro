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
        bool AddEvent(Event evento);
        bool RemoveEvent(Event evento);
        void UpdateEvent(Event evento);
        Event GetEventById(int id);
        ICollection<Event> GetAllEvents();
        ICollection<Event> GetAllFutureEvents();
    }
}
