using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace DevShop.Data.Models.JoinTables
{
    public class BookAuthor
    {
       public int BookId { get; set; }
       public Book Book { get; set; }
       public int AuthorId { get; set; }
       public Author Author { get; set; }


    }
}
