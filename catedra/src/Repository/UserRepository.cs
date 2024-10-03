using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra.src.Data;
using catedra.src.Interfaces;
using catedra.src.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id)!;
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}