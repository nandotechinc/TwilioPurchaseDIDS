using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace TwilioOrderPhoneNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var twilioSid = "";
            var authToken = "";
            var twilio = new TwilioRestClient(twilioSid, authToken);
            var options = new AvailablePhoneNumberListRequest();
            //Create Area Code List 
            List<string> didList = new List<string>();
            didList.Add("907");
            didList.Add("205");
            didList.Add("501");
            didList.Add("520");
            didList.Add("661");
            didList.Add("720");
            didList.Add("860");
            didList.Add("302");
            didList.Add("305");
            didList.Add("470");
            didList.Add("808");
            didList.Add("712");
            didList.Add("208");
            didList.Add("312");
            didList.Add("317");
            didList.Add("785");
            didList.Add("270");
            didList.Add("504");
            didList.Add("857");
            didList.Add("443");
            didList.Add("207");
            didList.Add("313");
            didList.Add("651");
            didList.Add("314");
            didList.Add("662");
            didList.Add("406");
            didList.Add("984");
            didList.Add("701");
            didList.Add("531");
            didList.Add("603");
            didList.Add("609");
            didList.Add("505");
            didList.Add("702");
            didList.Add("646");
            didList.Add("614");
            didList.Add("918");
            didList.Add("503");
            didList.Add("267");
            didList.Add("401");
            didList.Add("864");
            didList.Add("605");
            didList.Add("615");
            didList.Add("737");
            didList.Add("801");
            didList.Add("804");
            didList.Add("802");
            didList.Add("206");
            didList.Add("262");
            didList.Add("681");
            didList.Add("307");
            foreach (var numb in didList)
            {
                options.AreaCode = numb;
                var twilioResult = twilio.ListAvailableLocalPhoneNumbers("US", options);
                var availableNumber = twilioResult.AvailablePhoneNumbers[0];
                var didOptions = new PhoneNumberOptions();
                didOptions.PhoneNumber = availableNumber.PhoneNumber;
                didOptions.TrunkSid = "";
                //Purchase Phone NUmber / Set TrunkSid 
                var number = twilio.AddIncomingPhoneNumber(didOptions);
                Console.WriteLine(number.Sid);
                var file = File.AppendText("c:\\Twilio\\NumberLog.txt");
                file.WriteLine($"{didOptions.PhoneNumber} added to {didOptions.TrunkSid}");
                file.Close();
            }
        }
    }
}
