using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Rules
{
    public class RuleEngine
    {
        private readonly List<IOrderRule> _rules = new();

        public void AddRule(IOrderRule rule) => _rules.Add(rule);

        public void Process(Order order)
        {
            foreach (var rule in _rules)
            {
                rule.Apply(order);
            }
        }
    }
}