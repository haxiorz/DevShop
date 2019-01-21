using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShop.Data.Models
{
    public class CartBook
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
