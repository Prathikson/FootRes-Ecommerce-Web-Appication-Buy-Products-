
using System.ComponentModel.DataAnnotations;

namespace Itec245_Final.Models
{
    public class CartData
    {
        [Key]
        public string Email { get; set; }
        public string Json { get; set; }

    }
}
