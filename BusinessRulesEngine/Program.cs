using System.Net.Mail;
using OrderProcessingSystem.Data;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Rules;
using OrderProcessingSystem.Services;

class Program
{
    static void Main()
    {
        var notifier = new NotificationService();
        var engine = new RuleEngine();
        engine.AddRule(new PhysicalProductRule());
        engine.AddRule(new BookRule());
        engine.AddRule(new MembershipActivationRule(notifier));
        engine.AddRule(new MembershipUpgradeRule(notifier));
        engine.AddRule(new EmailNotificationRule(notifier));
        engine.AddRule(new VideoRule());
        engine.AddRule(new CommissionRule());

        bool continueProcessing = true;

        while (continueProcessing)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("       Order Processing System");
            Console.WriteLine("=======================================\n");

            var selectedProducts = new List<Product>();

            Console.WriteLine("Available Product Types:");

            foreach (var type in Enum.GetValues(typeof(ProductType)))
                Console.WriteLine($"  {(int)type}. {type}");

            Console.WriteLine("\nSelect product types to add (comma-separated numbers):");

            string[] selectedTypeInputs = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

            foreach (string typeInput in selectedTypeInputs.Select(x => x.Trim()))
            {
                if (int.TryParse(typeInput, out int typeInt) && Enum.IsDefined(typeof(ProductType), typeInt))
                {
                    var type = (ProductType)typeInt;

                    if (ProductRepository.ProductsByType.TryGetValue(type, out var products))
                    {
                        // Auto-add membership types
                        if (type == ProductType.Membership || type == ProductType.MembershipUpgrade)
                        {
                            var (name, price) = products.First();
                            Console.WriteLine($"\n {name} - ${price}");
                            selectedProducts.Add(new Product
                            {
                                ProductType = type,
                                ProductName = name,
                                Price = price
                            });
                        }
                        else
                        {
                            Console.WriteLine($"\n{type} Products:");
                            for (int j = 0; j < products.Count; j++) 
                            {
                                var (name, price) = products[j];
                                Console.WriteLine($"  {j + 1}. {name} - ${price}");
                            }

                            Console.Write("Select product numbers (comma-separated): ");
                            var productSelections = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();
                            foreach (var sel in productSelections.Select(s => s.Trim()))
                            {
                                if (int.TryParse(sel, out int idx) && idx >= 1 && idx <= products.Count)
                                {
                                    var (name, price) = products[idx - 1];
                                    selectedProducts.Add(new Product
                                    {
                                        ProductType = type,
                                        ProductName = name,
                                        Price = price
                                    });
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"[Warning] Invalid product number: {sel}");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[Error] Product type '{type}' not found in repository.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[Warning] Invalid product type: {typeInput}");
                    Console.ResetColor();
                }
            }

            if (selectedProducts.Count == 0)
            {
                Console.WriteLine("\nNo valid products selected. Returning to main menu.");
                Console.Write("\nPress Enter to continue...");
                Console.ReadLine();
                continue;
            }

            // Email validation
            string email;
            do
            {
                Console.Write("\nEnter customer email: ");
                email = Console.ReadLine()?.Trim();

                if (!IsValidEmail(email))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[Error] Invalid email format.");
                    Console.ResetColor();
                }
                else break;
            } while (true);

            var order = new Order
            {
                CustomerEmail = email,
                Products = selectedProducts
            };

            Console.WriteLine("\nProcessing your order...\n");

            engine.Process(order); // Apply all rules to the full order

            Console.WriteLine("\n--- Products in your order ---");
            int i = 1;
            foreach (var product in order.Products)
            {
                Console.WriteLine($"{i++}. {product.ProductName,-20} - ${product.Price:F2}");
            }

            var total = order.Products.Sum(p => p.Price);
            Console.WriteLine("----------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total Bill: ${total:F2}");
            Console.ResetColor();

            Console.Write("\nWould you like to process another order? (y/n): ");
            string answer = Console.ReadLine()?.Trim().ToLower();
            continueProcessing = answer == "y";
        }

        Console.WriteLine("\nThank you for using the Order Processing System. Goodbye!");
    }

    static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
