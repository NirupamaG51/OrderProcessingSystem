namespace OrderProcessingSystem.Services
{
    public class NotificationService : INotificationService
    {
        public void SendEmail(string to, string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[Email] Sent to {to}: {message}");
            Console.ResetColor();
        }
    }
}