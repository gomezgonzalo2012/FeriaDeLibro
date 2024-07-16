using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Data.Implements
{
    public class EventRepository : IEventRepository
    {
        private readonly FeriaDeLibroContext _feriaDeLibroContext;
        private readonly ILogger<EventRepository> _logger;

        public EventRepository(FeriaDeLibroContext feriaDeLibroContext, ILogger<EventRepository> logger)
        {
            _feriaDeLibroContext = feriaDeLibroContext;
            _logger = logger;
        }

        public async Task<bool> AddEvent(Event evento)
        {
            try
            {
                await _feriaDeLibroContext.Events.AddAsync(evento);
                await _feriaDeLibroContext.SaveChangesAsync();
                return true;
            }catch(DbUpdateException ex) { 
                _logger.LogError(ex.Message);
                return false;
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        
        public async Task<ICollection<Event>> GetAllEvents()
        {
            return await _feriaDeLibroContext.Events.Include("Course")?.OrderByDescending(x => x.EventDate).ToListAsync();
        }

        public async Task<ICollection<Event>> GetAllFutureEvents()
        {
            try 
            {
                var currentDate= DateOnly.FromDateTime(DateTime.Now);
                // retorna eventos futuros y ordenados por hora de eve
                // nto
                return await _feriaDeLibroContext.Events.Where(ev => ev.EventDate >= currentDate.AddDays(-1)).OrderByDescending(x=> x.EventDate).ThenBy(x=> x.EventTime).ToListAsync();
            }catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message); 
                throw; // caturar en el controlador
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message); 
                throw; //// caturar en el controlador
            }

        }

        public async Task<Event> GetEventById(int id)
        {
            try
            {
                return await _feriaDeLibroContext.Events.Include("Course")?.FirstOrDefaultAsync(ev => ev.EventId.Equals(id));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                throw; // caturar en el controlador
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw; //// caturar en el controlador
            }
        }

        public async Task<bool> RemoveEvent(Event evento)
        {
            try
            {
                if (evento == null)
                {
                    throw new ArgumentNullException(nameof(evento));
                }
                 _feriaDeLibroContext.Events.Remove(evento);
                await _feriaDeLibroContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task UpdateEvent(Event evento)
        {
            try
            {
                _feriaDeLibroContext.Attach(evento);
                //_feriaDeLibroContext.Events.Update(evento);
                _feriaDeLibroContext.Entry(evento).State = EntityState.Modified;
                await _feriaDeLibroContext.SaveChangesAsync();
                
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
               
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);
                
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
            }
        }
    }
}
