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
    public class UserRepository : IUserRepository
    {
        readonly FeriaDeLibroContext _feriaDeLibroContext;
        readonly ILogger<UserRepository> _logger;

        public UserRepository(FeriaDeLibroContext feriaDeLibroContext, ILogger<UserRepository> logger)
        {
            _feriaDeLibroContext = feriaDeLibroContext;
            _logger = logger;
        }

        public bool AddUser(User user)
        {
            try
            {
                _feriaDeLibroContext.Users.Add(user);
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

        public User GetUserById(int id)
        {
            try
            {
                return _feriaDeLibroContext.Users.FirstOrDefault(user => user.UserId.Equals(id));

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

        public User GetUserByName(string name)
        {
            try
            {
                return _feriaDeLibroContext.Users.FirstOrDefault(user => user.Name.Equals(name));

            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                throw; // caturar en el controlador
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw; // caturar en el controlador
            }
        }
    }
}
