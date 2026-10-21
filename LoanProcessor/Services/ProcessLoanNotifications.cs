
using LoanProcessor.Clients;
using LoanProcessor.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessor.Services
{
     class ProcessLoanNotifications : SERVICE
    {
        #region Declarations

        private static readonly ILog _log = LogManager.GetLogger(typeof(ProcessLoanNotifications));
        private readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        #endregion

        #region Constructor

        public ProcessLoanNotifications()
        {
            clientCode = "86";
            SaccoName = "BWS Sacco";
            processItem = "BamburiLoanNotifications";
        }

        #endregion
        #region Public Methods

        public void RunService()
        {
            LogInfo("Started ProcessBamburiLoanNotifications");

            while (!Shared.StopService)
            {
                try
                {
                    LogInfo("Top of loop...");
                    Task.Run(() => ProcessBamburiLoanNotifications());
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error occurred in RunService loop.");
                }

                try
                {
                    _autoResetEvent.WaitOne(1800);
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error while waiting in AutoResetEvent.");
                    _autoResetEvent.WaitOne(5000);
                }
            }
        }

        #endregion

        #region Private Methods

        private void ProcessBamburiLoanNotifications()
        {
            LogInfo("Processing BamburiLoan Notifications - START...");
            Console.WriteLine($"{DateTime.Now:yy-MM-dd HH:mm:ss.fff}\tProcessing ProcessBamburiLoan Notifications - START...");

            try
            {
                Config.service.fnProcessMBAMBURINotifications();// MPolytechNotifications();

                Console.WriteLine($"ProcessBamburiLoanNotifications processed");
                LogInfo($"ProcessBamburiLoanNotifications processed ");
            }
            catch (Exception ex)
            {
                Errorlog.LogEntryOnFile(processItem, $"{clientCode}: {ex.Message}");
                LogError(ex, "Exception during ProcessBamburiLoanNotifications");

                if (ex.InnerException?.Message != null)
                {
                    Errorlog.LogEntryOnFile(processItem, $"InnerException: {ex.InnerException.Message}");
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

            LogInfo("Processing ProcessBamburiLoanNotifications - DONE...");
            Console.WriteLine($"{DateTime.Now:yy-MM-dd HH:mm:ss.fff}\tProcessing ProcessBamburiLoanNotifications - DONE...");
        }

        private void LogInfo(string message)
        {
            _log.Info($"{DateTime.Now:yy-MM-dd HH:mm:ss.fff}\t{message}");
            Console.WriteLine($"{DateTime.Now:yy-MM-dd HH:mm:ss.fff}\t{message}");
            Errorlog.LogEntryOnFile(processItem, message);
        }

        private void LogError(Exception ex, string contextMessage = "")
        {
            _log.Error($"{contextMessage}\n{ex}");
            Errorlog.LogEntryOnFile(processItem, $"{clientCode}: {contextMessage} - {ex.Message}");

            if (ex.InnerException?.Message != null)
            {
                Errorlog.LogEntryOnFile(processItem, $"InnerException: {ex.InnerException.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
        }

        #endregion
    }
}
