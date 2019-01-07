using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevShop.Data;
using DevShop.Data.Models;

namespace DevShop.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly DevShop.Data.ApplicationDbContext _context;

        public DetailsModel(DevShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public string AuthorString { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Book = await _context
                .Book
                .Include(c => c.BookAuthors)
                .ThenInclude(c => c.Author)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
                return NotFound();

            AuthorString = string.Join(", ", Book.BookAuthors.Select(c => c.Author.FullName));
            return Page();
        }
    }
}
