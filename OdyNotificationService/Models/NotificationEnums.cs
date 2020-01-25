using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdyNotificationService.Models
{
    /// <summary>
    /// Service Type Enumerators for Notification.
    /// </summary>
    public enum ServiceType
    {
        /// <summary>
        /// Default.
        /// </summary>
        None = 0,

        /// <summary>
        /// Short message Service.
        /// </summary>
        SMS = 1,

        /// <summary>
        /// Call Service.
        /// </summary>
        Call = 2,

        /// <summary>
        /// WhatsApp Service.
        /// </summary>
        WhatsApp = 3,

        /// <summary>
        /// Push Notification Service.
        /// </summary>
        Push = 4,

        /// <summary>
        /// Email Service.
        /// </summary>
        Email = 5,
    }

    /// <summary>
    /// Notification API Enumerators for Notification.
    /// </summary>
    public enum NotificationAPI
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Twilio Notification API
        /// </summary>
        Twilio = 1,
    }


    public enum NotificationRequestStatus
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Success
        /// </summary>
        Success = 1,

        /// <summary>
        /// Failure
        /// </summary>
        Failure = 2,

        /// <summary>
        /// Error
        /// </summary>
        Error = 3
    }

    public enum NotificationStatus
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Success
        /// </summary>
        Success = 1,

        /// <summary>
        /// Failure
        /// </summary>
        Failure = 2,

        /// <summary>
        /// Error
        /// </summary>
        Error = 3
    }

    public enum OTPStatus
    {
        None = 0,

        WrongOTP = 1,

        MatchingOTP = 2,

        ExpiredOTP = 3,
    }
}
