using System.ComponentModel.DataAnnotations.Schema;

namespace Itec245_Final.Models
{
    public class Shoes
    {
        public int Id { get; set; }
        public string Images { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        public string Type { get; set; }

        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

    }

    
}
