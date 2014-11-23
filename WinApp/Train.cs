using System.ComponentModel;

namespace WinApp
{

    public partial class Train : BaseTraffic
    {
        public Train(TrafficTypes trafficType)
        {
            base.trafficType = trafficType;
            this.InitializeComponent();
            this.Load += this.Train_Load;
        }

        private void Train_Load(object sender, System.EventArgs e)
        {
            this.txtFrom.Validating += this.TxtFrom_Validating;
            this.txtTo.Validating += this.TxtTo_Validating;
        }

        private void TxtTo_Validating(object sender, CancelEventArgs e)
        {
            base.errorTracker.ValidationControl(this.txtTo);
        }

        private void TxtFrom_Validating(object sender, CancelEventArgs e)
        {
            base.errorTracker.ValidationControl(this.txtFrom);
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
                    System.Threading.Thread.Sleep(10);
                }
            }

            return -1;
        }
    }
}
