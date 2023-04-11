using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Itec245_Final.Data;
using Itec245_Final.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Itec245_Final.Pages.MyShoes
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Itec245_Final.Data.ApplicationDbContext _context;

        public EditModel(Itec245_Final.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shoes Shoes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.shoes == null)
            {
                return NotFound();
            }

            var shoes =  await _context.shoes.FirstOrDefaultAsync(m => m.Id == id);
            if (shoes == null)
            {
                return NotFound();
            }
            Shoes = shoes;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoesExists(Shoes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShoesExists(int id)
        {
          return (_context.shoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
