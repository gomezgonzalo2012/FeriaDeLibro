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

        public async Task<bool> AddUser(User user)
        {
            try
            {
                await _feriaDeLibroContext.Users.AddAsync(user);
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

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _feriaDeLibroContext.Users.FirstOrDefaultAsync(user => user.UserId.Equals(id));

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

        public async Task<User> GetUserByName(string name)
        {
            try
            {
                return await _feriaDeLibroContext.Users.FirstOrDefaultAsync(user => user.Name.Equals(name));

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
