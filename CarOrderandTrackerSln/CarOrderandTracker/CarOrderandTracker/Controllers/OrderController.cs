using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarOrder.Domain.Context;
using CarOrder.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarOrder.Services.Controllers
{
    [Produces("application/json")]
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
      
            private readonly CarOrderAndTrackerDbContext _context;

            public OrderController(CarOrderAndTrackerDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            [Route("getorders")]
            [EnableCors("AllowOrigin")]
            public IEnumerable<Order> GetOrders()
            {
                return _context.Orders;
            }

        [HttpGet("{id}")]
        [Route("getorder/{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetOrder( int id)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
            [HttpDelete("{emailid}/{orderId}")]
            [Route("deleteorder")]
            [EnableCors("AllowOrigin")]
            public async Task<IActionResult> DeleteOrder([FromRoute]string userId, int orderId)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = await _context.Orders.FirstOrDefaultAsync(u => u.UserId == userId && u.OrderId == orderId);
                if (item == null)
                {
                    return NotFound();
                }

                _context.Orders.Remove(item);
                await _context.SaveChangesAsync();

                return Ok(item);
            }

            [HttpGet("{emailid}/{orderid}")]
            [Route("checkorder")]
            [EnableCors("AllowOrigin")]
            public Boolean CheckOrder([FromRoute] string userId, int orderId)
            {
            return _context.Orders.Any(e => e.UserId == userId && e.OrderId == orderId);

            }



        [HttpPost]
            [Route("addorder")]
            [EnableCors("AllowOrigin")]
            public async Task<IActionResult> AddOrder([FromBody] Order order)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return Ok(order);
            }

         
        
    }
}