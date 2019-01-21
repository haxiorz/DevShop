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
using Microsoft.AspNetCore.Identity;

namespace DevShop.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly DevShop.Data.DevShopDbContext _context;
        private readonly UserManager<ExtendedIdentityUser> _userManager;

        public DetailsModel(DevShop.Data.DevShopDbContext context, UserManager<ExtendedIdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            ViewModel = new DetailsPageViewModel();
            ReturnUrl = "/Account/Cart";
        }

        public DetailsPageViewModel ViewModel { get; set; }

        public string ReturnUrl { get; set; }

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
                .Take(4).ToListAsync();

            if (ViewModel.Book == null)
                return NotFound();

            AuthorString = string.Join(", ", ViewModel.Book.BookAuthors.Select(c => c.Author.FullName));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if(user == null)
                    return LocalRedirect("/Identity/Account/Register");

                await _context.Cart.AddAsync(new Cart() {User = user,
                    CartBooks = new List<CartBook>(){ new CartBook(){Book = ViewModel.Book, Quantity = ViewModel.OrderQuantity}}});
                await _context.SaveChangesAsync();

                //Show cart
                return LocalRedirect(ReturnUrl);
            }

            //Something went wrong
            return Page();
        }
    }
}
