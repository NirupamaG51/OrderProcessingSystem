using NUnit.Framework;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using OrderProcessingSystem.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrderProcessingSystemTests.Rules
{
    [TestFixture]
    internal class MembershipUpgradeRuleTests
    {
        [Test]
        public void Apply_WithMembershipUpgrade_WritesUpgradeMessage()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.MembershipUpgrade, ProductName = "Upgrade", Price = 50 }
                }
            };
            var rule = new MembershipUpgradeRule(new NotificationService());

            using var sw = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                rule.Apply(order);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            Assert.That(sw.ToString(), Does.Contain("Membership upgraded."));
        }

        [Test]
        public void Apply_WithNoMembershipUpgrade_WritesNothing()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.PhysicalProduct, ProductName = "Item", Price = 10 }
                }
            };
            var rule = new MembershipUpgradeRule(new NotificationService());

            using var sw = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                rule.Apply(order);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            Assert.That(sw.ToString(), Is.Empty);
        }
    }
}