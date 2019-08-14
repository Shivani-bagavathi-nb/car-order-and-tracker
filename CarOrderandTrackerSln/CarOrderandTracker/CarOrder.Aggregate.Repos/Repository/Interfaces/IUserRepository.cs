using CarOrder.Aggregate.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarOrder.Aggregate.Repos.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUser(string userEmailId, string password);
    }
}