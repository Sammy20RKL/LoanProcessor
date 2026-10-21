using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;

namespace LoanProcessor
{
    class ServiceInstallerUtility
    {
        private static readonly string exePath =
          Assembly.GetExecutingAssembly().Location;
        public static bool InstallMe()
        {
            try { ManagedInstallerClass.InstallHelper(new[] { "/LogFile=", exePath }); }
            catch { return false; }
            return true;
        }
        public static bool UninstallMe()
        {
            try { ManagedInstallerClass.InstallHelper(new[] { "/LogFile=", "/u", exePath }); }
            catch { return false; }
            return true;
        }
    }

}
