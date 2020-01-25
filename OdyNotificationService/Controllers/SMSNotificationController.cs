using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdyNotificationService.Models;
using OdyNotificationService.Services;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OdyNotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSNotificationController : ControllerBase
    {

        private readonly ILogger<SMSNotificationController> _logger;

        public SMSNotificationController(ILogger<SMSNotificationController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into SMSNotificationController");
        }

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
                _logger.LogInformation("OTP Request: " + JsonConvert.SerializeObject(NotificationReq));
                string serviceAPI = Enum.GetName(typeof(NotificationAPI), NotificationReq.NotificationAPI);
                Type instanceType = Type.GetType("OdyNotificationService.Services." + serviceAPI + "." + serviceAPI);
                INotificationService service = (INotificationService)Activator.CreateInstance(instanceType, NotificationReq.ApiProperties);
                NotificationResp = service.RequestOTP(NotificationReq);
                _logger.LogInformation("OTP Response: " + JsonConvert.SerializeObject(NotificationResp));
            }
            return NotificationResp;
        }

        /// <summary>
        /// Request OTP
        /// </summary>
        /// <param name="NotificationReq"></param>
        [HttpPost("VerifyOTP")]
        public NotificationResponse VerifyOTP(NotificationRequest NotificationReq)
        {
            NotificationResponse NotificationResp = new NotificationResponse();
            if (NotificationReq != null)
            {
                _logger.LogInformation("OTP Request: ", JsonConvert.SerializeObject(NotificationReq));
                string serviceAPI = Enum.GetName(typeof(NotificationAPI), NotificationReq.NotificationAPI);
                Type instanceType = Type.GetType("OdyNotificationService.Services." + serviceAPI + "." + serviceAPI);
                INotificationService service = (INotificationService)Activator.CreateInstance(instanceType, NotificationReq.ApiProperties);
                NotificationResp = service.VerifyOTP(NotificationReq);
                _logger.LogInformation("OTP Response: ", JsonConvert.SerializeObject(NotificationResp));
            }
            return NotificationResp;
        }
        /// <summary>
        /// Request OTP
        /// </summary>
        /// <param name="NotificationReq"></param>
        [HttpPost("SendSMS")]
        public NotificationResponse SendSMS(NotificationRequest NotificationReq)
        {
            NotificationResponse NotificationResp = new NotificationResponse();
            if (NotificationReq != null)
            {
                string serviceAPI = Enum.GetName(typeof(NotificationAPI), NotificationReq.NotificationAPI);
                Type instanceType = Type.GetType("OdyNotificationService.Services." + serviceAPI + "." + serviceAPI);
                INotificationService service = (INotificationService)Activator.CreateInstance(instanceType, NotificationReq.ApiProperties);
                service.SendSMS(NotificationReq, NotificationResp);
            }
            return NotificationResp;
        }
        
    }
}