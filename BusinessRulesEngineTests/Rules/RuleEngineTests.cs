using NUnit.Framework;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using System.Collections.Generic;

namespace OrderProcessingSystemTests.Rules
{
    [TestFixture]
    internal class RuleEngineTests
    {
        private class TestRule : IOrderRule
        {
            public bool WasApplied { get; private set; }
            public void Apply(Order order) => WasApplied = true;
        }

        [Test]
        public void AddRule_AndProcess_CallsApplyOnAllRules()
        {
            var engine = new RuleEngine();
            var rule1 = new TestRule();
            var rule2 = new TestRule();
            var order = new Order { Products = new List<Product>() };

            engine.AddRule(rule1);
            engine.AddRule(rule2);

            engine.Process(order);

            Assert.That(rule1.WasApplied, Is.True);
            Assert.That(rule2.WasApplied, Is.True);
        }
    }
}