using LoanProcessor.BWSWebRef;
using LoanProcessor.Properties;
using LoanProcessor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessor.Helper
{
    class Config
    {
        public static ServerSetting ss = new ServerSetting();
        public static string url = string.Empty;
        public static string username = string.Empty;
        public static string password = string.Empty;
        public static string domain = string.Empty;
        public Config()
        {
            //url = Settings.Default.mobileService.ToString();
            //username = Settings.Default.username.ToString();
            //password = Settings.Default.password.ToString();
            //domain = Settings.Default.domain.ToString();
        }
        public static MobileService service
        {
            get
            {
                //string url, username, password, domain;
                url = Settings.Default.LoanService.ToString();
                username = Settings.Default.username.ToString();
                password = Settings.Default.password.ToString();
                domain = Settings.Default.domain.ToString();

                MobileService service_ = new MobileService();
                service_.Url = url;
                service_.PreAuthenticate = true;
                service_.Credentials = new NetworkCredential(username, password, domain);

                return service_;
            }

        }
    }
}
    

