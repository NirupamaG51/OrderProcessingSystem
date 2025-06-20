using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Rules
{
    public class CommissionRule : IOrderRule
    {
        public void Apply(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.ProductType == ProductType.PhysicalProduct || product.ProductType == ProductType.Book)
                {
                    Console.WriteLine("Commission payment to agent generated.");
                }
            }
        }
    }
}