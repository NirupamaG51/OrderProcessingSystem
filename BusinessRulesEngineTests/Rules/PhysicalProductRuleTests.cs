using NUnit.Framework;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrderProcessingSystemTests.Rules
{
    [TestFixture]
    internal class PhysicalProductRuleTests
    {
        [Test]
        public void Apply_WithPhysicalProduct_WritesPackingSlip()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.PhysicalProduct, ProductName = "Item", Price = 10 }
                }
            };
            var rule = new PhysicalProductRule();

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

            Assert.That(sw.ToString(), Does.Contain("Generated packing slip for shipping."));
        }

        [Test]
        public void Apply_WithNoPhysicalProduct_WritesNothing()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Book, ProductName = "Book", Price = 10 }
                }
            };
            var rule = new PhysicalProductRule();

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