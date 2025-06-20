using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Rules
{
    public interface IOrderRule
    {
        void Apply(Order order);
    }
}