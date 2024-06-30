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
        public bool AddEvent(Event evento)
        {
            try
            {
                _feriaDeLibroContext.Events.Add(evento);
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

        public ICollection<Event> GetAllEvents()
        {
            return _feriaDeLibroContext.Events.ToList();
        }

        public ICollection<Event> GetAllFutureEvents()
        {
            try
            {
                var currentDate= DateOnly.FromDateTime(DateTime.Now);
                return _feriaDeLibroContext.Events.Where(ev => ev.EventDate > currentDate).ToList();
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

        public Event GetEventById(int id)
        {
            try
            {
                return _feriaDeLibroContext.Events.FirstOrDefault(ev => ev.EventId.Equals(id));
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

        public bool RemoveEvent(Event evento)
        {
            try
            {
                _feriaDeLibroContext.Events.Remove(evento);
                _feriaDeLibroContext.SaveChanges();
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

        public void UpdateEvent(Event evento)
        {
            try
            {
                _feriaDeLibroContext.Events.Update(evento);
                _feriaDeLibroContext.SaveChanges();
                
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
