using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Itec245_Final.Data;
using Itec245_Final.Models;
using Microsoft.AspNetCore.Authorization;

namespace Itec245_Final.Pages.MyShoes
{
    [Authorize(Roles ="User,Admin")]
    public class IndexModel : PageModel
    {
        public List<Shoes> Shoppingcart { get; set; }

        

        private readonly Itec245_Final.Data.ApplicationDbContext _context;

        public IndexModel(Itec245_Final.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Shoes> Shoes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.shoes != null)
            {
                Shoes = await _context.shoes.ToListAsync();
                Shoppingcart = await _context.shoes.ToListAsync();
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
