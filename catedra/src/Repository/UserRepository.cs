using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra.src.Data;
using catedra.src.Interfaces;
using catedra.src.Models;

namespace catedra.src.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDBContext _context;

        public UserRepository (ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}