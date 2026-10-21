using LoanProcessor.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessor.Clients
{
    public class SERVICE
    {
        public string clientCode;
        public string SaccoName;
        public string CompanyName;
        public string processItem;

        public void LogError(string processItem, Exception ex)
        {
            try
            {
                Errorlog.LogEntryOnFile(processItem, string.Format("{0}:{1}", clientCode, ex.Message));
                if (ex.InnerException != null)
                {
                    Errorlog.LogEntryOnFile(processItem, string.Format("{0}:{1}", clientCode, ex.InnerException.Message));
                }
                Errorlog.LogEntryOnFile(processItem, string.Format("{0}:{1}", clientCode, ex.StackTrace));
                Errorlog.LogEntryOnFile(processItem, string.Format("{0}:{1}", clientCode, ex.Source));
            }
            catch (Exception e)
            {
            }
        }
        public static string FormatPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty");

            // Remove spaces, dashes, etc.
            phoneNumber = phoneNumber.Trim().Replace(" ", "").Replace("-", "");

            // If already starts with 254, return as is
            if (phoneNumber.StartsWith("254"))
                return phoneNumber;

            // If starts with 0, replace with 254
            if (phoneNumber.StartsWith("0"))
                return "254" + phoneNumber.Substring(1);

            // If starts with +254, remove +
            if (phoneNumber.StartsWith("+254"))
                return phoneNumber.Substring(1);

            throw new ArgumentException("Invalid phone number format");
        }
    }
}
    