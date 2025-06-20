using NUnit.Framework;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrderProcessingSystemTests.Rules
{
    [TestFixture]
    internal class CommissionRuleTests
    {
        [Test]
        public void Apply_WithPhysicalProductOrBook_WritesCommission()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.PhysicalProduct, ProductName = "Item", Price = 10 },
                    new Product { ProductType = ProductType.Book, ProductName = "Book", Price = 20 }
                }
            };
            var rule = new CommissionRule();

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

            var output = sw.ToString();
            Assert.That(output, Does.Contain("Commission payment to agent generated."));
        }

        [Test]
        public void Apply_WithNoPhysicalProductOrBook_WritesNothing()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Video, ProductName = "Video", Price = 15 }
                }
            };
            var rule = new CommissionRule();

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