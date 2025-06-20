namespace OrderProcessingSystem.Models
{
    public class Order
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public string CustomerEmail { get; set; }
    }
}
