using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem.Rules
{
    public class EmailNotificationRule : IOrderRule
    {
        private readonly INotificationService _notifier;

        public EmailNotificationRule(INotificationService notifier)
        {
            _notifier = notifier;
        }

        public void Apply(Order order)
        {
            foreach (var product in order.Products)
            {
                if (product.ProductType == ProductType.Membership || product.ProductType == ProductType.MembershipUpgrade)
                {
                    string action = product.ProductType == ProductType.Membership ? "activated" : "upgraded";
                    _notifier.SendEmail(order.CustomerEmail, $"Your membership has been {action}.");
                }
            }
        }
    }
}