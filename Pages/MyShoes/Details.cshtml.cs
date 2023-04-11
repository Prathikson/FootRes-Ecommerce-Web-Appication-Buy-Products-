using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Itec245_Final.Data;
using Itec245_Final.Models;

namespace Itec245_Final.Pages.MyShoes
{
    public class DetailsModel : PageModel
    {
        private readonly Itec245_Final.Data.ApplicationDbContext _context;

        public DetailsModel(Itec245_Final.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Shoes Shoes { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.shoes == null)
            {
                return NotFound();
            }

            var shoes = await _context.shoes.FirstOrDefaultAsync(m => m.Id == id);
            if (shoes == null)
            {
                return NotFound();
            }
            else 
            {
                Shoes = shoes;
            }
            return Page();
        }
    }
}
