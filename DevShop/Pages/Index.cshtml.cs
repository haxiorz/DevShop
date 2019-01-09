using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevShop.Data;
using DevShop.Data.Models;
using DevShop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DevShop.Data.ApplicationDbContext _context;

        public IndexPageViewModel ViewModel { get; set; }

        public IndexModel(DevShop.Data.ApplicationDbContext context)
        {
            _context = context;
            ViewModel = new IndexPageViewModel();
        }

        public IActionResult OnGetAsync()
        {
            ViewModel.RecommendedBooks = _context.Book.Where(c => c.IsRecommended).ToList();
            ViewModel.LimitedSaleBooks = _context.Book.Where(c => c.IsOnLimitedSale).ToList();

            return Page();
        }
    }
}
