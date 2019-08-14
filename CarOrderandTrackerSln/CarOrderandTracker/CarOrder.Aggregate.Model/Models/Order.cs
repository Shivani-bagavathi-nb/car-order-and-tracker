using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarOrder.Aggregate.Model.Models
{
    public class Order
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Orderid { get; private set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Orderitem { get; set; }
        public string Orderitemmodel { get; set; }
        public string Engine { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }

        
    }
}