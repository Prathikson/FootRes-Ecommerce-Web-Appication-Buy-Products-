using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Itec245_Final.Pages
{
    [Authorize(Roles = "User, Admin")]
    public class ThankModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPostCust()
        {
            Response.Redirect("Index");
        }
    }
}
