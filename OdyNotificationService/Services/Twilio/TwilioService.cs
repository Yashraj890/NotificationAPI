using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdyNotificationService.Models;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Rest.Verify.V2.Service;

namespace OdyNotificationService.Services.Twilio
{
    public partial class Twilio : INotificationService
    {
        public void RequestOTP(NotificationRequest NotificationRequest, NotificationResponse NotificationResponse)
        {
            try
            {
                foreach (string phoneNumber in NotificationRequest.PhoneNumbers)
                {
                    var verificationResource = VerificationResource.Create(
                        to: phoneNumber,
                        channel: Enum.GetName(typeof(ServiceType), NotificationRequest.ServiceType).ToLower(),
                        pathServiceSid: this.verificationSid
                    );

                    if (verificationResource != null)
                    {
                        NotificationResponse.IsSuccessful = true;
                        NotificationResponse.NotificationStatus = NotificationStatus.Success;
                        NotificationResponse.Message.Add(verificationResource.Sid);
                    }
                }

            }
            catch (TwilioException te)
            {
                NotificationResponse.Exceptions.Add(te.Message);
                NotificationResponse.IsSuccessful = false;
            }
        }
        public void VerifyOTP(NotificationRequest NotificationRequest, NotificationResponse NotificationResponse)
        {
            try
            {
                foreach (string phoneNumber in NotificationRequest.PhoneNumbers)
                {
                    string OTP = NotificationRequest.OTP;
                    var verificationResource = VerificationCheckResource.Create(
                    to: phoneNumber,
                    code: OTP,
                    pathServiceSid: this.verificationSid
                    );

                    if (verificationResource != null)
                    {
                        NotificationResponse.IsSuccessful = true;
                        NotificationResponse.NotificationStatus = NotificationStatus.Success;
                        NotificationResponse.Message.Add(verificationResource.Status);
                    }
                }

            }
            catch (TwilioException te)
            {
                NotificationResponse.Exceptions.Add(te.Message);
                NotificationResponse.IsSuccessful = false;
            }
        }
        public void SendSMS(NotificationRequest NotificationRequest, NotificationResponse NotificationResponse)
        {
            try
            {
                foreach (string phoneNumber in NotificationRequest.PhoneNumbers)
                {
                    string OTP = NotificationRequest.OTP;
                    var verificationResource = MessageResource.Create(
                    to: new PhoneNumber("+918460326960"),
                    from: new PhoneNumber("+18124960290"),
                   body: "Hi there!"
                      );
                    if (verificationResource != null)
                    {
                        NotificationResponse.IsSuccessful = true;
                        NotificationResponse.NotificationStatus = NotificationStatus.Success;
                    //    NotificationResponse.Message.Add(verificationResource.Status);
                    }
                }

            }
            catch (TwilioException te)
            {
                NotificationResponse.Exceptions.Add(te.Message);
                NotificationResponse.IsSuccessful = false;
            }
        }
    }
}
