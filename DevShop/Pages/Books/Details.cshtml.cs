using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevShop.Data;
using DevShop.Data.Models;
using DevShop.Data.ViewModels;

namespace DevShop.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly DevShop.Data.DevShopDbContext _context;

        public DetailsModel(DevShop.Data.DevShopDbContext context)
        {
            _context = context;
            ViewModel = new DetailsPageViewModel();
        }

        public DetailsPageViewModel ViewModel { get; set; }

        public string AuthorString { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            ViewModel.Book = await _context
                .Books
                .Include(c => c.BookAuthors)
                .ThenInclude(c => c.Author)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewModel.Similar = await _context
                .Books
                //.Where(c => c.Id != id)
                .Take(4).ToListAsync();

            if (ViewModel.Book == null)
                return NotFound();

            AuthorString = string.Join(", ", ViewModel.Book.BookAuthors.Select(c => c.Author.FullName));
            return Page();
        }
    }
}
