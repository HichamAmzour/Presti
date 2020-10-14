namespace PresrtiProject_API.Notifications
{
    public interface INotificationProvider
    {
        string Message { get; set; }
        string Id { get; set; }
        void SetNotificationMessage(bool success, string itemName, string id);


    }
}