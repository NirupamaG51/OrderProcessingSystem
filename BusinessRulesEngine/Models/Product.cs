public enum ProductType { PhysicalProduct, Book, Membership, MembershipUpgrade, Video }
public class Product
{
    public ProductType ProductType { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}