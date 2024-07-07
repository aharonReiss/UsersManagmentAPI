using Application.Interfaces;
using Application.Utils;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddUserAsync(User user)
        {
            //encrypt the password
            try
            {
                var userFromDb = await _userRepository.GetByUserNameAsync(user.UserName);
                if (userFromDb != null)
                    throw new Exception("userName in use");
                user.Password = Cryptor.MD5Encrypt(user.Password);
                return await _userRepository.AddAsync(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var userFromDb = await _userRepository.GetByIdAsync(id);
            if (userFromDb == null)
                throw new Exception("user not found");
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id); 
        }
        public async Task<bool> ValidateUserAndPassword(User user)
        {
            var userFromDb = await _userRepository.GetByUserNameAsync(user.UserName);
            if(userFromDb == null)
                return false;
            return Cryptor.MD5Encrypt(user.Password) == userFromDb.Password;
        }
    }
}
