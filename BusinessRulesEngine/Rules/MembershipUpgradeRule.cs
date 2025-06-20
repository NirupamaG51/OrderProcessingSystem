using OrderProcessingSystem.Models;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem.Rules
{
    public class MembershipUpgradeRule : IOrderRule
    {
        private readonly NotificationService _notifier;
        public MembershipUpgradeRule(NotificationService notifier)
        {
            _notifier = notifier;
        }

        public void Apply(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.ProductType == ProductType.MembershipUpgrade)
                {
                    Console.WriteLine("Membership upgraded.");
                    
                }
            }
        }

    }
}