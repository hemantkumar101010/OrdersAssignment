using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersData.Entities
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]

        public string? ItemName { get; set; }

        public int? ItemsRate { get; set; }

        public int? ItemQty { get; set; }
    }
}
