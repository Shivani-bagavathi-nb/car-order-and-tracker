
using CarOrder.Aggregate.Model.Models;
using CarOrder.Aggregate.Repos.Repository.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarOrder.Aggregate.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        [Route("getuser")]
        [EnableCors("AllowOrigin")]
        public async Task<bool> GetUser(string emailId, string password)
        {
            User user = null;
            try
            {
                user = await _userRepository.GetUser(emailId,password);
                if (user != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("adduser")]
        [EnableCors("AllowOrigin")]
        public async Task AddUser([FromBody] User user)
        {
            try
            {
                await _userRepository.AddUser(user);
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
