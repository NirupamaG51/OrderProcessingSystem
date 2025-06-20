using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Rules
{
    public class PhysicalProductRule : IOrderRule
    {
        public void Apply(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.ProductType == ProductType.PhysicalProduct)
                {
                    Console.WriteLine("Generated packing slip for shipping.");
                }
            }
        }
    }
}