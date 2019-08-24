using CarOrder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarOrder.Business.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUser(string userEmailId, string password);
    }
}