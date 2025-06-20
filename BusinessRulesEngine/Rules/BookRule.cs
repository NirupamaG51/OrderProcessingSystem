using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Rules
{
    public class BookRule : IOrderRule
    {
        public void Apply(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.ProductType == ProductType.Book)
                {
                    Console.WriteLine("Generated packing slip for shipping.");
                    Console.WriteLine("Created duplicate packing slip for royalty department.");
                }
            }
        }
    }
}