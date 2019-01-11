using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Data.Models;

namespace DevShop.Data.ViewModels
{
    public class DetailsPageViewModel
    {
        public Book Book { get; set; }
        public ICollection<Book> Similar { get; set; }
    }
}
