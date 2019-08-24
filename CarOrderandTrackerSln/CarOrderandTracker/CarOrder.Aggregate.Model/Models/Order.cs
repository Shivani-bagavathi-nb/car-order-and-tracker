using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarOrder.Domain.Models
{
    public class Order
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; private set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string OrderItemModel { get; set; }
        public string Engine { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }

        
    }
}