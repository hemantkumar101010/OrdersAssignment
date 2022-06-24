using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersData.Entities
{
    public class Customer
    {
        public string? CustomerFName { get; set; }
        public string? CustomerLName { get; set; }

        public int? CustomerPhone { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public string? CustomerEmail { get; set; }
        public string? CustomerPassword { get; set; }
    }
}
