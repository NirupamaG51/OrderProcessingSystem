using NUnit.Framework;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using System.Collections.Generic;
using System.Linq;

namespace OrderProcessingSystemTests.Rules
{
    [TestFixture]
    public class VideoRuleTests
    {
       
        [Test]
        public void Apply_ShouldNotAddFirstAidVideo_WhenLearningToSkiIsNotPresent()
        {
            // Arrange
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Video, ProductName = "Snowboarding Basics", Price = 12.00m }
                }
            };

            var rule = new VideoRule();

            // Act
            rule.Apply(order);

            // Assert
            Assert.That(order.Products.Count, Is.EqualTo(1));
            Assert.That(order.Products.Any(p => p.ProductName == "First Aid"), Is.False);
        }

     
    }
}
