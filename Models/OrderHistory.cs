namespace Itec245_Final.Models
{
    public class OrderHistory
    {
        public int Id { get; set; } 
        public string User { get; set; }
        public List<Shoes> Products { get; set; }
        public decimal Totoal { get; set; }
        public string DeliveryAddress { get; set; }



    }
}
