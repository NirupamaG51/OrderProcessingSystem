using NUnit.Framework;
using System;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystemTests.Services
{
    [TestFixture]
    internal class NotificationServiceTests
    {
        [Test]
        public void SendEmail_ShouldWriteExpectedOutput()
        {
            var service = new NotificationService();
            var to = "test@example.com";
            var message = "Hello, this is a test email!";
            var expectedOutput = $"[Email] Sent to {to}: {message}{Environment.NewLine}";

            using var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                service.SendEmail(to, message);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void SendEmail_WithEmptyRecipient_ShouldWriteOutput()
        {
            var service = new NotificationService();
            var to = "";
            var message = "No recipient";
            var expectedOutput = $"[Email] Sent to {to}: {message}{Environment.NewLine}";

            using var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                service.SendEmail(to, message);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void SendEmail_WithNullMessage_ShouldWriteOutputWithNull()
        {
            var service = new NotificationService();
            var to = "someone@example.com";
            string message = null;
            var expectedOutput = $"[Email] Sent to {to}: {message}{Environment.NewLine}";

            using var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                service.SendEmail(to, message);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void SendEmail_CanBeCalledViaInterface()
        {
            INotificationService service = new NotificationService();
            var to = "interface@example.com";
            var message = "Interface test";
            var expectedOutput = $"[Email] Sent to {to}: {message}{Environment.NewLine}";

            using var sw = new System.IO.StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                service.SendEmail(to, message);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
        }
    }
}