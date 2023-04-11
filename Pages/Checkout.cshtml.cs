using Itec245_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Itec245_Final.Pages
{
    [Authorize(Roles ="User, Admin")]
    public class CheckoutModel : PageModel
    {
        private readonly Itec245_Final.Data.ApplicationDbContext _context;

        public OrderHistory o = new OrderHistory();
        public CheckoutModel(Itec245_Final.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Shoes> Shoes { get; set; } = default!;
        public void OnGet()
        {

        }

        public void OnPostRemoveCustom(int myvalue)
        {
            HelperModel h = new HelperModel();


            h.remove(User.Identity.Name, _context, myvalue);
            Shoes = _context.shoes.ToList();
        }

        public void OnPostAddCustom(int myvalue)
        {
            HelperModel h = new HelperModel();


            h.AddShoes(User.Identity.Name, _context, myvalue);
            Shoes = _context.shoes.ToList();
        }

        public void OnpostFinal()
        {
           
            Page();
            HelperModel h = new HelperModel();
            h.CheckOut(User.Identity.Name, _context);
            Response.Redirect("Thank");

        }
    }
}
