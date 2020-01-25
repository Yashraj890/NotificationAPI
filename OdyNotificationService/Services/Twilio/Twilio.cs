using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdyNotificationService.Models;

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
                    var obj = new { item };
                }
                ApiProperties.ToArray().Where(prop => prop.ToString().Contains("accountsid", StringComparison.InvariantCultureIgnoreCase)).Select(p => p);

            }
        }

        private string accountSid { get; set; }

        private string authToken { get; set; }

        private string verificationSid { get; set; }
    }
}
