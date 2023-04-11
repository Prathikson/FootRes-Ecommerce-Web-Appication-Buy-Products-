using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Itec245_Final.Data;
using Itec245_Final.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Itec245_Final.Pages.MyShoes
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Itec245_Final.Data.ApplicationDbContext _context;

        public CreateModel(Itec245_Final.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shoes Shoes { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.shoes == null || Shoes == null)
            {
                return Page();
            }

            _context.shoes.Add(Shoes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
