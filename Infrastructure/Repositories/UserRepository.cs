using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private int userId = 0;
        public async Task<int> AddAsync(User user)
        {
            using (var context = new AppDbContext())
            {
                user.UserId = userId++;
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return user.UserId;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                var user = await context.Users.FindAsync(id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                var user = await context.Users.FindAsync(id);
                return user;
            }
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            using (var context = new AppDbContext())
            {
                var user = await context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
                return user;
            }
        }
    }
}
