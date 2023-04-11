using Itec245_Final.Data;
using Itec245_Final.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Itec245_Final.Models
{
    public class HelperModel
    {
        public HelperModel()
        {
            
        }
        public static List<Shoes> GetCart(string email, ApplicationDbContext context)
        {
            List<Shoes> shoes = new List<Shoes>();

            var cartJson = "";
            try
            {
                cartJson = context.CartData.Where(x => x.Email == email).First().Json;
            }
            catch
            {
                return new List<Shoes>();
            }
            shoes = JsonConvert.DeserializeObject<List<Shoes>>(cartJson);
            return shoes;

        }


        public List<Shoes> GetShoes(string email, ApplicationDbContext context)
        {
            var shoes = new List<Shoes>();
            var x  = context.CartData.Where(x => x.Email == email).FirstOrDefault();
            if (x == null)
            {
                return new List<Shoes>();
            }
            shoes = JsonConvert.DeserializeObject<List<Shoes>>(x.Json);
            return shoes??new List<Shoes>();


        }

        public void AddShoes(string email, ApplicationDbContext context, int ShoeId)
        {

            if(email == null || context == null)
            {
                return;
            }
            
            List<Shoes> shoes = GetShoes(email, context);
            var shoetoAdd = context.shoes.First(x => x.Id == ShoeId);
            shoes.Add(shoetoAdd);

            
            var cartdatabyEmail = context.CartData.Where(x => x.Email == email).FirstOrDefault();
           
            var Json = JsonConvert.SerializeObject(shoes);
            if(cartdatabyEmail != null)
            {
                cartdatabyEmail.Email = email;
                cartdatabyEmail.Json = Json;
            }
            else
            {
                context.CartData.Add(new CartData()
                {
                    Email = email,
                    Json = Json
                });
            }
           
            context.SaveChanges();
        }
        public int countcart(string email, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(email))
            {
                return 0;
            }
            try
            {
                int count = 0;
                var cartdatabyEmail = context.CartData.Where(x => x.Email == email).FirstOrDefault();
                string Cart = context.CartData.Where(x => x.Email == email).First().Json;
                var shoesjson = JsonConvert.DeserializeObject<List<Shoes>>(Cart);
                count = shoesjson.Count();
                return count;
            }
            catch
            {
                return 0;
            }
            

        }
        public  List<Shoes> GroupItems(string email, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(email))
            {
                return new List<Shoes>();
            }
            try
            {
                string Cart = context.CartData.Where(x => x.Email == email).First().Json;
                var shoes = JsonConvert.DeserializeObject<List<Shoes>>(Cart);

                var group = shoes.GroupBy(x => x.Id).Select(z => z.ToList()).ToList();
                List<Shoes> groupshoes = new List<Shoes>();
                foreach (var tmp in group)
                {
                    var shoe = tmp[0];
                    shoe.Quantity = tmp.Count();
                    groupshoes.Add(shoe);
                }

                return groupshoes ?? new List<Shoes>();
            }
            catch
            {
                return new List<Shoes>();
            }
            
            

            
        } 

        public decimal GetTotal(string email, ApplicationDbContext context)
        {
            if (string.IsNullOrEmpty(email))
            {
                return 0;
            }
            try
            {
                decimal total = 0;
                var cartdatabyEmail = context.CartData.Where(x => x.Email == email).FirstOrDefault();
                string Cart = context.CartData.Where(x => x.Email == email).First().Json;
                var shoesjson = JsonConvert.DeserializeObject<List<Shoes>>(Cart);
                foreach (Shoes tmp in shoesjson)
                {
                    total += tmp.Price;
                }
                return total;
            }
            catch
            {
                return 0;
            }
            
        }

        public void remove(string email, ApplicationDbContext context, int ShoeId)
        {
            if (email == null || context == null)
            {
                return;
            }

            CartData Cart = context.CartData.Where(x => x.Email == email).First();

            if (Cart == null)
            {
                return;
            }
            var shieslist = JsonConvert.DeserializeObject<List<Shoes>>(Cart.Json);

            if (shieslist != null)
            {
                foreach (Shoes sho in shieslist)
                {
                    if(sho.Id == ShoeId)
                    {
                        shieslist.Remove(sho);
                        break;
                    }
                }
            }

            var Json = JsonConvert.SerializeObject(shieslist);

            Cart.Json = Json;
            context.SaveChanges();
        }

        public void CheckOut(string email, ApplicationDbContext context)
        {

            if (email == null || context == null)
            {
                return;
            }

            CartData Cart = context.CartData.Where(x => x.Email == email).First();

            if (Cart == null)
            {
                return;
            }
            var shieslist = JsonConvert.DeserializeObject<List<Shoes>>(Cart.Json);

            if (shieslist != null)
            {
                foreach (Shoes sho in shieslist)
                {
                    
                        shieslist.RemoveRange(0,shieslist.Count);
                        break;
                    
                }
            }

            var Json = JsonConvert.SerializeObject(shieslist);

            Cart.Json = Json;
            context.SaveChanges();
        }
        
    }
}
