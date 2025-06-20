using NUnit.Framework;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using System;
using System.Collections.Generic;
using System.IO;

namespace OrderProcessingSystemTests.Rules
{
    [TestFixture]
    internal class BookRuleTests
    {
        [Test]
        public void Apply_WithBook_WritesPackingSlips()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Book, ProductName = "Book", Price = 20 }
                }
            };
            var rule = new BookRule();

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
            Assert.That(output, Does.Contain("Generated packing slip for shipping."));
            Assert.That(output, Does.Contain("Created duplicate packing slip for royalty department."));
        }

        [Test]
        public void Apply_WithNoBook_WritesNothing()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.PhysicalProduct, ProductName = "Item", Price = 10 }
                }
            };
            var rule = new BookRule();

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