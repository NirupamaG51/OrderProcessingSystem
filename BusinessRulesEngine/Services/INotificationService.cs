namespace OrderProcessingSystem.Services
{
    public interface INotificationService
    {
        void SendEmail(string to, string message);
    }
}
