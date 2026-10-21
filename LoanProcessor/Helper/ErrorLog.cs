using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessor.Helper
{
       public class Errorlog
    {
        public static string logpath = @"C:\SwizzProcessor LOGS\";
        private static readonly object _logFileLock = new object();
        private Errorlog()
        {
        }

        public static string LogFileName
        {
            get { return "D:\\SwizzKASH logs\\Errorlogs\\" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".txt"; }
        }

        public static void LogEntryOnFile(string processItem, string processData)
        {
            try
            {
                string logFileName = $"S1ProcessorLogs-{DateTime.Now:yyyy-MM-dd}-{processItem}.txt";
                string logFilePath = Path.Combine(logpath, logFileName);

                //if (!Directory.Exists(logpath))
                //{
                //    Directory.CreateDirectory(logpath);
                //}

                //lock (_logFileLock)
                //{
                //    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                //    {
                //        writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - [{Thread.CurrentThread.ManagedThreadId}]-[{processItem}] {processData}");
                //    }
                //}
            }
            catch (Exception ex)
            {
                // Optional: fallback log mechanism
                Console.WriteLine($"[LogError] Could not write to file: {ex.Message}");
            }
        }
    }
    }
