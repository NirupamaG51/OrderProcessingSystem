using NUnit.Framework;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using OrderProcessingSystem.Services;
using System.Collections.Generic;

namespace OrderProcessingSystemTests.Rules
{
    [TestFixture]
    public class MembershipActivationRuleTests
    {
        [Test]
        public void Apply_WithMembershipProduct_DoesNotThrow()
        {
            // Arrange
            var notifier = new NotificationService();
            var rule = new MembershipActivationRule(notifier);
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Membership, ProductName = "Gold Membership", Price = 99.99m }
                },
                CustomerEmail = "test@example.com"
            };

            // Act & Assert
            Assert.DoesNotThrow(() => rule.Apply(order));
        }

        [Test]
        public void Apply_WithoutMembershipProduct_DoesNotThrow()
        {
            // Arrange
            var notifier = new NotificationService();
            var rule = new MembershipActivationRule(notifier);
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.PhysicalProduct, ProductName = "Book", Price = 19.99m }
                },
                CustomerEmail = "test@example.com"
            };

            // Act & Assert
            Assert.DoesNotThrow(() => rule.Apply(order));
        }
    }
}