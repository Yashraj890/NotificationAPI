using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdyNotificationService.Models;
using OdyNotificationService.Services;

namespace OdyNotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        /// <summary>
        /// Request OTP
        /// </summary>
        /// <param name="NotificationReq"></param>
        [HttpPost("RequestOTP")]
        public NotificationResponse RequestOTP(NotificationRequest NotificationReq)
        {
            NotificationResponse NotificationResp = new NotificationResponse();
            if (NotificationReq != null)
            {
                string serviceAPI = Enum.GetName(typeof(NotificationAPI), NotificationReq.NotificationAPI);
                Type instanceType = Type.GetType("OdyNotificationService.Services." + serviceAPI + "." + serviceAPI);
                INotificationService service = (INotificationService) Activator.CreateInstance(instanceType, NotificationReq.ApiProperties);
                service.RequestOTP(NotificationReq, NotificationResp);
            }
            return NotificationResp;
        }
    }
}