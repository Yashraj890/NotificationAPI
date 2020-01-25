using OdyNotificationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdyNotificationService.Services
{
    public interface INotificationService
    {
        void RequestOTP(NotificationRequest NotificationRequest, NotificationResponse NotificationResponse);
        void VerifyOTP(NotificationRequest NotificationRequest, NotificationResponse NotificationResponse);
        void SendSMS(NotificationRequest NotificationRequest, NotificationResponse NotificationResponse); 
    }
}
