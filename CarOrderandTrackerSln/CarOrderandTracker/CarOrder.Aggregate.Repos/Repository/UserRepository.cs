using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarOrder.Aggregate.Model.Context;
using CarOrder.Aggregate.Model.Models;
using CarOrder.Aggregate.Repos.Repository.Interfaces;

namespace CarOrder.Aggregate.Repos.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserContext _userContext;

        public UserRepository(UserContext context)
        {
            _userContext = context;
        }

      

        public async Task<User> GetUser(string userEmailId, string password)
        {
            try
            {
                return  _userContext.Users.Find(userEmailId,password);
               
            }

            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddUser(User user)
        {
            try
            {
                await _userContext.Users.AddAsync(user);
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}

