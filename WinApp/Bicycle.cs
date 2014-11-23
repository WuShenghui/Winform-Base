using System.ComponentModel;

namespace WinApp
{
    public partial class Bicycle : BaseTraffic
    {
        public Bicycle(TrafficTypes trafficType)
        {
            base.trafficType = trafficType;
            this.InitializeComponent();
        }

        protected override int ProcessProgress(object sender, DoWorkEventArgs e)
        {
            base.SetProcessBarMaximum(100);

            for (int i = 0; i < 100; i++)
            {
                if (BkWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }
                else
                {
                    BkWorker.ReportProgress(i);
                    System.Threading.Thread.Sleep(100);
                }
            }

            return -1;
        }
    }
}
