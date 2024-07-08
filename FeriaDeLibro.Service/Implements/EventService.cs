using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Entities.Errors;
using FeriaDeLibro.Entities.Models;
using FeriaDeLibro.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Implements
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Result<bool> AddEvent(Event evento)
        {
            if (evento == null)
            {
                return Result<bool>.Failed("Los datos del evento son incorrectos");
            }
            return Result<bool>.Success(_eventRepository.AddEvent(evento));
        }

        public ICollection<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public ICollection<Event> GetAllFutureEvents()
        {
            return _eventRepository.GetAllFutureEvents();
        }

        public Event GetEventById(int id)
        {
            return _eventRepository.GetEventById(id);
        }

        public void RemoveEvent(Event evento)
        {
            _eventRepository.RemoveEvent(evento);
        }

        public void UpdateEvent(Event evento)
        {
            _eventRepository.UpdateEvent(evento);
        }
    }
}
