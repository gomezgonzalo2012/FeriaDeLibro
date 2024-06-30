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
        bool AddUser (User user);
        User GetUserByName (string name);
        User GetUserById (int id);

    }
}
