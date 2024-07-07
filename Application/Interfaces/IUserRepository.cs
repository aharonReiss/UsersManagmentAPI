using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<int> AddAsync(User user);
        Task DeleteAsync(int id);
        Task<User> GetByUserNameAsync(string userName);
    }
}
