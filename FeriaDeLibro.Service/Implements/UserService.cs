using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Entities.Models;
using FeriaDeLibro.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id); 
        }

        public User GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }
    }
}
