namespace OrderProcessingSystem.Data
{
    public static class ProductRepository
    {
        public static Dictionary<ProductType, List<(string Name, decimal Price)>> ProductsByType = new()
        {
            [ProductType.PhysicalProduct] = new() { ("Keyboard", 30.00m), ("Mouse", 20.00m) },
            [ProductType.Book] = new() { ("C# in Depth", 40.00m), ("Clean Code", 35.00m) },
            [ProductType.Membership] = new() { ("Gym Membership", 100.00m) },
            [ProductType.MembershipUpgrade] = new() { ("Premium Upgrade", 50.00m) },
            [ProductType.Video] = new() { ("Learning to Ski", 15.00m), ("Cooking Basics", 10.00m) }
        };
    }
}
