using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarOrder.Business.Interfaces;
using CarOrder.Domain.Context;
using CarOrder.Domain.Models;

namespace CarOrder.Business.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly CarOrderAndTrackerDbContext _context;

        public UserRepository(CarOrderAndTrackerDbContext context)
        {
            _context = context;
        }

      

        public async Task<User> GetUser(string emailId, string password)
        {
            try
            {
                return _context.Users.Find(emailId, password);
               
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
                await _context.Users.AddAsync(user);
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}

