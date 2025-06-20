using NUnit.Framework;
using OrderProcessingSystem.Data;
using OrderProcessingSystem.Models;
using System.Linq;

namespace OrderProcessingSystemTests.Data
{
    [TestFixture]
    public class ProductRespositoryTests
    {
        [Test]
        public void ProductsByType_ShouldContainAllProductTypes()
        {
            // Assert
            Assert.IsTrue(ProductRepository.ProductsByType.ContainsKey(ProductType.PhysicalProduct));
            Assert.IsTrue(ProductRepository.ProductsByType.ContainsKey(ProductType.Book));
            Assert.IsTrue(ProductRepository.ProductsByType.ContainsKey(ProductType.Membership));
            Assert.IsTrue(ProductRepository.ProductsByType.ContainsKey(ProductType.MembershipUpgrade));
            Assert.IsTrue(ProductRepository.ProductsByType.ContainsKey(ProductType.Video));
        }

        [Test]
        public void ProductsByType_PhysicalProduct_ShouldContainExpectedProducts()
        {
            var products = ProductRepository.ProductsByType[ProductType.PhysicalProduct];
            CollectionAssert.AreEquivalent(
                new[] { ("Keyboard", 30.00m), ("Mouse", 20.00m) },
                products
            );
        }

        [Test]
        public void ProductsByType_Book_ShouldContainExpectedProducts()
        {
            var products = ProductRepository.ProductsByType[ProductType.Book];
            CollectionAssert.AreEquivalent(
                new[] { ("C# in Depth", 40.00m), ("Clean Code", 35.00m) },
                products
            );
        }

        [Test]
        public void ProductsByType_Membership_ShouldContainExpectedProducts()
        {
            var products = ProductRepository.ProductsByType[ProductType.Membership];
            CollectionAssert.AreEquivalent(
                new[] { ("Gym Membership", 100.00m) },
                products
            );
        }

        [Test]
        public void ProductsByType_MembershipUpgrade_ShouldContainExpectedProducts()
        {
            var products = ProductRepository.ProductsByType[ProductType.MembershipUpgrade];
            CollectionAssert.AreEquivalent(
                new[] { ("Premium Upgrade", 50.00m) },
                products
            );
        }

        [Test]
        public void ProductsByType_Video_ShouldContainExpectedProducts()
        {
            var products = ProductRepository.ProductsByType[ProductType.Video];
            CollectionAssert.AreEquivalent(
                new[] { ("Learning to Ski", 15.00m), ("Cooking Basics", 10.00m) },
                products
            );
        }
    }
}