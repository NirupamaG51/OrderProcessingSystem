using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Rules
{
    public class VideoRule : IOrderRule
    {
        public void Apply(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.ProductType == ProductType.Video && product.ProductName == "Learning to Ski")
                {
                    Console.WriteLine("Added 'First Aid' video to packing slip.");

                    order.Products.Add(new Product
                    {
                        ProductType = ProductType.Video,
                        ProductName = "First Aid",
                        Price = 0.00m // Free item
                    });
                }
            }
        }

    }
}