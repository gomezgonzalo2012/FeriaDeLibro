using FeriaDeLibro.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Data.Interfaces
{
    public interface IUserRepository
    {
        
        Task<bool> AddUser (User user);
        Task<User> GetUserByName (string name);
        Task<User> GetUserById (int id);

    }
}
