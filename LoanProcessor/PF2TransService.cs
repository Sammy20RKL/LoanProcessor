using LoanProcessor.Helper;
using System.ServiceProcess;
using LoanProcessor.Services; 
using System.Threading;

namespace LoanProcessor
{
    public partial class PF2TransService : ServiceBase
    {
        private ManualResetEvent _stop = new ManualResetEvent(false);

        public PF2TransService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var sync = new ProcessorService();
            sync.StartServices();
        }

        protected override void OnStop()
        {
            Shared.StopService = true;
            _stop.Set();
        }

        public void Start() { OnStart(null); }
        public void Stop() { OnStop(); }
    }
}