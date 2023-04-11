using Itec245_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Itec245_Final.Pages.BrandsSort
{
    [Authorize(Roles = "User,Admin")]
    public class AdidasModel : PageModel
    {
       

        private readonly Itec245_Final.Data.ApplicationDbContext _context;
        public AdidasModel(Itec245_Final.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Shoes> Shoes { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.shoes != null)
            {
                Shoes = await _context.shoes.ToListAsync();
            }



        }

        public IActionResult OnPostAddCustom(int myvalue)
        {
            if (User.Identity.IsAuthenticated)
            {
                HelperModel h = new HelperModel();


                h.AddShoes(User.Identity.Name, _context, myvalue);
                Shoes = _context.shoes.ToList();
                return Page();
            }
            else
            {
                return Redirect("Login");
            }



        }
    }
}
