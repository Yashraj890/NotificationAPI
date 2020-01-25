using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdyNotificationService.Models
{
    public class NotificationResponse
    {
        public NotificationRequestStatus NotificationRespStatus { get; set; }

        public NotificationStatus NotificationStatus { get; set; }

        public OTPStatus OTPStatus { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public List<string> Exceptions { get; set; } = new List<string>();

        public List<string> Message { get; set; } = new List<string>();

        public bool IsSuccessful { get; set; }
    }
}
