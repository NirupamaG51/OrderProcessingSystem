using NUnit.Framework;
using Moq;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem.Tests.Rules
{
    [TestFixture]
    public class EmailNotificationRuleTests
    {
        private INotificationService _mockNotifier;
        private EmailNotificationRule _rule;

        [SetUp]
        public void Setup()
        {
            _mockNotifier = new Mock<INotificationService>().Object;
            _rule = new EmailNotificationRule(_mockNotifier);

        }

        [Test]
        public void Apply_WhenOrderHasMembershipProduct_SendsActivationEmail()
        {
            // Arrange
            var order = new Order
            {
                CustomerEmail = "test@example.com",
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Membership }
                }
            };

            // Act
            _rule.Apply(order);

            // Assert
           
        }

        [Test]
        public void Apply_WhenOrderHasMembershipUpgradeProduct_SendsUpgradeEmail()
        {
            // Arrange
            var order = new Order
            {
                CustomerEmail = "test@example.com",
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.MembershipUpgrade }
                }
            };

            // Act
            _rule.Apply(order);

           
        }

        [Test]
        public void Apply_WhenOrderHasBothMembershipTypes_SendsBothEmails()
        {
            // Arrange
            var order = new Order
            {
                CustomerEmail = "test@example.com",
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Membership },
                    new Product { ProductType = ProductType.MembershipUpgrade }
                }
            };

            // Act
            _rule.Apply(order);

          
        }

        [Test]
        public void Apply_WhenOrderHasNoMembershipProducts_DoesNotSendEmail()
        {
            // Arrange
            var order = new Order
            {
                CustomerEmail = "test@example.com",
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Book },
                    new Product { ProductType = ProductType.PhysicalProduct }
                }
            };

            // Act
            _rule.Apply(order);

           
        }

        [Test]
        public void Apply_WhenOrderHasEmptyProductsList_DoesNotSendEmail()
        {
            // Arrange
            var order = new Order
            {
                CustomerEmail = "test@example.com",
                Products = new List<Product>()
            };

            // Act
            _rule.Apply(order);

            // Assert
           
        }

        [Test]
        public void Apply_WhenCustomerEmailIsEmpty_StillSendsEmail()
        {
            // Arrange
            var order = new Order
            {
                CustomerEmail = "",
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Membership }
                }
            };

            // Act
            _rule.Apply(order);

            // Assert
           
        }

        [Test]
        public void Apply_WhenCustomerEmailIsNull_StillSendsEmail()
        {
            // Arrange
            var order = new Order
            {
                CustomerEmail = null,
                Products = new List<Product>
                {
                    new Product { ProductType = ProductType.Membership }
                }
            };

            // Act
            _rule.Apply(order);

            // Assert
           
        }
    }
}