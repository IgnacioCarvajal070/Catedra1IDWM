using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra.src.Models;

namespace catedra.src.Interfaces
{
    public interface IUserRepository
    {
        Task <List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
}