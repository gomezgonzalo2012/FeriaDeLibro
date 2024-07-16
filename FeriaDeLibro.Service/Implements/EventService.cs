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

        public async Task<Result<bool>> AddEvent(Event evento)
        {
            if (evento == null)
            {
                return Result<bool>.Failed("Los datos del evento son incorrectos");
            }
            return Result<bool>.Success(await _eventRepository.AddEvent(evento));
        }

        public async Task<ICollection<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAllEvents();
        }

        public async Task<ICollection<Event>> GetAllFutureEvents()
        {
            return await _eventRepository.GetAllFutureEvents();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _eventRepository.GetEventById(id);
        }

        public async Task RemoveEvent(Event evento)
        {
            await _eventRepository.RemoveEvent(evento);
        }

        public async Task UpdateEvent(Event evento)
        {
            await _eventRepository.UpdateEvent(evento);
        }
    }
}
