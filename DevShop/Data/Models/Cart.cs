using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace DevShop.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public ICollection<CartBook> CartBooks { get; set; }

        public ExtendedIdentityUser User { get; set; }

        public string UserRef { get; set; }

        public decimal PriceTotal
        {
            get { return CartBooks.Select(c => c.Book.Price * c.Quantity).Sum(); }
        }


        public int QuantityTotal
        {
            get { return CartBooks.Select(c => c.Quantity).Sum(); }
        }
    }
}
