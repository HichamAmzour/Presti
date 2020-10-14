using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresrtiProject_API.Notifications
{
    public class NotificationProvider: INotificationProvider
    {
        public string Id { get; set; } 
        public string Message { get; set; }

        public void SetNotificationMessage(bool success, string itemName, string id)
        {
            this.Id = id;

            if (success)
                Message= $"{itemName} was added successfully !";
            else
                Message = $"Error occured : {itemName} was NOT added !!";
        }
    }
}
