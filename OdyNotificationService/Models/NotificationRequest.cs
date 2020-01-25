using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdyNotificationService.Models
{
    /// <summary>
    /// Notification Request container for data communication between services
    /// </summary>
    public class NotificationRequest
    {
        /// <summary>
        /// Gets or sets the Service Type
        /// </summary>
        public ServiceType ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the SiteItemID
        /// </summary>
        public string SiteItemID { get; set; }

        /// <summary>
        /// Gets or sets the SiteName
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets the Notification API
        /// </summary>
        public NotificationAPI NotificationAPI { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumbers list.
        /// </summary>
        public List<string> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the Emails list.
        /// </summary>
        public List<string> Emails { get; set; }

        /// <summary>
        /// Gets or sets the Tokens list.
        /// </summary>
        public List<string> Tokens { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the Api Properties.
        /// </summary>
        public ArrayList ApiProperties { get; set; }
    }
}
