using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdyNotificationService.Models
{
    /// <summary>
    /// Notification Response container for data communication between services
    /// </summary>
    public class NotificationResponse
    {
        /// <summary>
        /// Notification Response Status
        /// </summary>
        public NotificationRequestStatus NotificationRespStatus { get; set; }

        /// <summary>
        /// Gets or sets the Notification Status
        /// </summary>
        public NotificationStatus NotificationStatus { get; set; }

        /// <summary>
        /// Gets or sets the OTP Status
        /// </summary>
        public OTPStatus OTPStatus { get; set; }

        /// <summary>
        /// Gets or sets the Notification Service Errors list.
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the Notification Service Exception.
        /// </summary>
        public string Exceptions { get; set; }

        /// <summary>
        /// Gets or sets the Notification Service Message list.
        /// </summary>
        public List<string> Message { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the Notification Request was Successful
        /// </summary>
        public bool IsSuccessful { get; set; }
    }
}
