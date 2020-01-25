using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdyNotificationService.Models;
using Newtonsoft.Json.Linq;
using Twilio;

namespace OdyNotificationService.Services.Twilio
{
    public partial class Twilio
    {
        public Twilio()
        {

        }

        public Twilio(ArrayList ApiProperties)
        {
            if (ApiProperties != null && ApiProperties.Count > 0)
            {
                foreach (var item in ApiProperties)
                {
                    var json = JObject.Parse(item.ToString());

                    if (json != null)
                    {
                        if (((string)json["Name"]).Equals("accountsid", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (!string.IsNullOrWhiteSpace((string)json["Value"]))
                            {
                                this.accountSid = (string)json["Value"];
                            }
                            else
                            {
                                this.accountSid = (string)json["DefaultValue"];
                            }
                        }
                        if (((string)json["Name"]).Equals("authToken", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (!string.IsNullOrWhiteSpace((string)json["Value"]))
                            {
                                this.authToken = (string)json["Value"];
                            }
                            else
                            {
                                this.authToken = (string)json["DefaultValue"];
                            }
                        }
                        if (((string)json["Name"]).Equals("verificationSid", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (!string.IsNullOrWhiteSpace((string)json["Value"]))
                            {
                                this.verificationSid = (string)json["Value"];
                            }
                            else
                            {
                                this.verificationSid = (string)json["DefaultValue"];
                            }
                        }
                    }
                }
            }
            TwilioClient.Init(this.accountSid, this.authToken);
        }

        private string accountSid { get; set; }

        private string authToken { get; set; }

        private string verificationSid { get; set; }
    }
}
