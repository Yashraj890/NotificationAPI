using OdyNotificationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdyNotificationService.Services
{
    public interface INotificationService
    {
        NotificationResponse RequestOTP(NotificationRequest NotificationRequest);
        NotificationResponse VerifyOTP(NotificationRequest NotificationRequest);
        NotificationResponse SendSMS(NotificationRequest NotificationRequest); 
    }
}
