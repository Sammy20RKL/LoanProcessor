using LoanProcessor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LoanProcessor.Services;
using System.Threading.Tasks;

namespace LoanProcessor
{
    public class ProcessorService
    {
        public void StartServices()
        {

            //Thread LoanProcessorthread = null;
            //Thread PaybillSwitchThread = null;
            //Thread PinResetRequestsThread = null;
            //Thread ProcessLoanRepaymentsThread = null;
            //Thread ProcessWithdrawalsThread = null;
            //Thread C2BRequestsThread = null;
            //Thread B2CServiceThread = null;
            Thread ProcessLoanNotificationsThread = null;
            //Thread ProcessRegistrationsThread = null;
            //Thread c2BCommitThread = null;
            //Thread processPaybillThread = null;

            try
            {
                //LoanProcessor startLoan = new LoanProcessor();
                //LoanProcessorthread = new Thread(startLoan.RunService);
                //LoanProcessorthread.Priority = ThreadPriority.Normal;
                //LoanProcessorthread.Start();

                //PaybillSwitch startPaybill = new PaybillSwitch();
                //PaybillSwitchThread = new Thread(startPaybill.RunService);
                //PaybillSwitchThread.Priority = ThreadPriority.Normal;
                //PaybillSwitchThread.Start();

                //PinResetRequests startPinReset = new PinResetRequests();
                //PinResetRequestsThread = new Thread(startPinReset.RunService);
                //PinResetRequestsThread.Priority = ThreadPriority.Normal;
                //PinResetRequestsThread.Start();

                //ProcessLoanRepayments startProcessLoanRepayments = new ProcessLoanRepayments();
                //ProcessLoanRepaymentsThread = new Thread(startProcessLoanRepayments.RunService);
                //ProcessLoanRepaymentsThread.Priority = ThreadPriority.Normal;
                //ProcessLoanRepaymentsThread.Start();

                //ProcessWithdrawals startProcessWithdrawals = new ProcessWithdrawals();
                //ProcessWithdrawalsThread = new Thread(startProcessWithdrawals.RunService);
                //ProcessWithdrawalsThread.Priority = ThreadPriority.Normal;
                //ProcessWithdrawalsThread.Start();

                //C2BRequests c2BRequests = new C2BRequests();
                //C2BRequestsThread = new Thread(c2BRequests.RunService);
                //C2BRequestsThread.Priority = ThreadPriority.Normal;
                //C2BRequestsThread.Start();

                //B2CService service = new B2CService();
                //B2CServiceThread = new Thread(service.RunService);
                //B2CServiceThread.Priority = ThreadPriority.Normal;
                //B2CServiceThread.Start();

                ProcessLoanNotifications startProcessLoanNotifications = new ProcessLoanNotifications();
                ProcessLoanNotificationsThread = new Thread(startProcessLoanNotifications.RunService);
                ProcessLoanNotificationsThread.Priority = ThreadPriority.Normal;
                ProcessLoanNotificationsThread.Start();

                //ProcessRegistration processRegistration = new ProcessRegistration();
                //ProcessRegistrationsThread = new Thread(processRegistration.RunService);
                //ProcessRegistrationsThread.Priority = ThreadPriority.Normal;
                //ProcessRegistrationsThread.Start();

                //C2BCommit c2BCommit = new C2BCommit();
                //c2BCommitThread = new Thread(c2BCommit.RunService);
                //c2BCommitThread.Priority = ThreadPriority.Normal;
                //c2BCommitThread.Start();

                //PaybillProcessor paybillProcessor = new PaybillProcessor();
                //processPaybillThread=new Thread(paybillProcessor.RunService);
                //processPaybillThread.Priority = ThreadPriority.Normal;
                //processPaybillThread.Start();

            }
            catch (Exception ex)
            {
                UTILS.WriteLog(string.Format("Start Service:{0}\\n{1}\\", ex.Message, ex.StackTrace));
            }
        }
    }
}

