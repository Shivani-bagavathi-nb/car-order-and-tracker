

using CarOrder.Domain.Context;
using CarOrder.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarOrder.Services
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CarOrderAndTrackerDbContext _context;

        public UserController(CarOrderAndTrackerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getuser/{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetUser([FromRoute] string emailId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailId == emailId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Password);
        }

        [HttpPost]
        [Route("adduser")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!UserExists(user.EmailId))
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { emailId = user.EmailId }, user);
            }
            else return (BadRequest("User Exists"));
        }
        private bool UserExists(string emailId)
        {
            return _context.Users.Any(e => e.EmailId == emailId);
        }

    }
}
