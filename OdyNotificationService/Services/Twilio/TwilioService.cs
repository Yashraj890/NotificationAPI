﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdyNotificationService.Models;
using Twilio.Exceptions;
using Twilio.Rest.Verify.V2.Service;

namespace OdyNotificationService.Services.Twilio
{
    public partial class Twilio : INotificationService
    {
        public NotificationResponse RequestOTP(NotificationRequest NotificationRequest)
        {
            NotificationResponse NotificationResponse = new NotificationResponse();
            try
            {
                foreach (string phoneNumber in NotificationRequest.PhoneNumbers)
                {
                    var verificationResource = VerificationResource.Create(
                        to: phoneNumber,
                        channel: Enum.GetName(typeof(ServiceType), NotificationRequest.ServiceType),
                        pathServiceSid: this.verificationSid
                    );

                    if (verificationResource != null)
                    {
                        NotificationResponse.IsSuccessful = true;
                        NotificationResponse.NotificationStatus = NotificationStatus.Success;
                        NotificationResponse.Message.Add(verificationResource.Sid);
                    }
                }
                return NotificationResponse;

            }
            catch (TwilioException te)
            {
                NotificationResponse.Exceptions.Add(te.Message);
                NotificationResponse.IsSuccessful = false;
                return NotificationResponse;
            }
        }
    }
}
