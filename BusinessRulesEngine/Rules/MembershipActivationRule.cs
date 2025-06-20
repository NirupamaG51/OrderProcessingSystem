using OrderProcessingSystem.Models;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem.Rules
{
    public class MembershipActivationRule : IOrderRule
    {
        private readonly NotificationService _notifier;
        public MembershipActivationRule(NotificationService notifier)
        {
            _notifier = notifier;
        }

        public void Apply(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.ProductType == ProductType.Membership)
                {
                    Console.WriteLine("Membership activated.");
                    
                }
            }
        }
    }
}