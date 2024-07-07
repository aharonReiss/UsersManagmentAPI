using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<bool> ValidateUserAndPassword(User user);
    }
}
