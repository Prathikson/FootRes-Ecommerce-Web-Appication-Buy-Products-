using Itec245_Final.Models;
using Itec245_Final.Pages.BrandsSort;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Itec245_Final.Pages
{
    [Authorize(Roles = "User,Admin")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //var cart = CartHolder.GetobjectFromJson<List<Products>>(HttpContext.Session, "cart");
        }

        public void OnPostCustom2()
        {
            if (_logger.Equals(null))
            {
                RedirectToPage("../Areas/Identity/Pages/Accounts/Register");
            }
            else
            {
                
            }
        }

        public IActionResult OnPostCust1(string myvalue)
        {
            if (User.Identity.IsAuthenticated)
            {
                if(myvalue == "Nike")
                {
                    return Redirect("../BrandsSort/Nike");
                }
                else if(myvalue == "Adidas")
                {
                    return Redirect("../BrandsSort/Adidas");
                }
                else if (myvalue == "Puma")
                {
                    return Redirect("../BrandsSort/Puma");
                }
                else if (myvalue == "UA")
                {
                    return Redirect("../BrandsSort/UnderArmour");
                }
                else if (myvalue == "NB")
                {
                    return Redirect("../BrandsSort/NewBalance");
                }
                else if (myvalue == "North")
                {
                    return Redirect("../BrandsSort/NorthFace");
                }
                else if (myvalue == "Reebok")
                {
                    return Redirect("../BrandsSort/Reebok");
                }
                else if (myvalue == "Vans")
                {
                    return Redirect("../BrandsSort/Reebok");
                }
                else if (myvalue == "Skechers")
                {
                    return Redirect("../BrandsSort/Skechers");
                }
                else
                {
                    return Page();
                }

            }
            else
            {
                return Redirect("Login");
            }
        }
    }
}