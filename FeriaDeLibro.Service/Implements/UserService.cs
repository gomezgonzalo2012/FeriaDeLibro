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
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id); 
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _userRepository.GetUserByName(name);
        }
    }
}
