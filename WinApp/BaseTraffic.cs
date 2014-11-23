using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinApp
{
    /// <summary>
    /// Traffic master form
    /// </summary>
    public partial class BaseTraffic : Form
    {
        protected TrafficTypes trafficType;
        protected ErrorTracker errorTracker = new ErrorTracker(new ErrorProvider());
        private bool isBack;
        private BackgroundWorker bkWorker = new BackgroundWorker();

        public BaseTraffic()
        {
            this.InitializeComponent();

            this.Load += this.BaseTraffic_Load;
        }

        /// <summary>
        /// Gets a value indicating whether file isBack.
        /// </summary>
        public bool IsBack
        {
            get
            {
                return this.isBack;
            }
        }

        /// <summary>
        /// Gets BackgroundWorker object.
        /// </summary>
        public BackgroundWorker BkWorker
        {
            get
            {
                return this.bkWorker;
            }
        }

        public void SetProcessBarMaximum(int maximum)
        {
            this.tsProgressBar.Maximum = maximum;
        }

        protected virtual int ProcessProgress(object sender, DoWorkEventArgs e)
        {
            return -1;
        }

        protected virtual void BtnBegin_Click(object sender, EventArgs e)
        {
            if (this.errorTracker.ValidationControls(this))
            {
                this.SetControlEnable(false);
                this.bkWorker.RunWorkerAsync();
            }
        }

        protected virtual void BtnStop_Click(object sender, EventArgs e)
        {
            this.bkWorker.CancelAsync();
        }

        protected virtual void BtnBack_Click(object sender, EventArgs e)
        {
            this.isBack = true;
            this.StopBackgroundWorker();
            this.Dispose();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!this.isBack)
            {
                this.StopBackgroundWorker();

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to exit?",
                    "Opration",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                e.Cancel = result == DialogResult.No;
            }
        }

        private void BaseTraffic_Load(object sender, EventArgs e)
        {
            this.lblTafficType.Text = this.trafficType.ToString();

            this.SetControlEnable(true);

            this.bkWorker.WorkerReportsProgress = true;
            this.bkWorker.WorkerSupportsCancellation = true;
            this.bkWorker.DoWork += this.BkWorker_DoWork;
            this.bkWorker.ProgressChanged += this.ProgessChanged;
            this.bkWorker.RunWorkerCompleted += this.CompleteWork;

            this.KeyDown += this.BaseTraffic_KeyDown;
        }

        private void BaseTraffic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ("btnBegin".Equals(ActiveControl.Name))
                {
                    return;
                }

                Control ctrl = GetNextControl(ActiveControl, true);

                while (ctrl is Label)
                {
                    ctrl = this.GetNextControl(ctrl, true);
                }

                if (ctrl != null)
                {
                    ctrl.Focus();
                }
            }
        }

        private void BkWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = this.ProcessProgress(this.bkWorker, e);
        }

        private void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tsProgressBar.Value = e.ProgressPercentage;
            int percent = e.ProgressPercentage % this.tsProgressBar.Maximum;
            this.tsslStatus.Text = string.Format("There {0}% destination", percent);
        }

        private void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            this.tsslStatus.Text = this.tsProgressBar.Value + 1 == this.tsProgressBar.Maximum
                ? "Safe arrival!"
                : "Stop !";

            this.SetControlEnable(true);
        }

        private void SetControlEnable(bool isEnable)
        {
            this.btnBack.Enabled = isEnable;
            this.btnBegin.Enabled = isEnable;

            this.btnStop.Enabled = !isEnable;
        }

        private void StopBackgroundWorker()
        {
            if (this.bkWorker.IsBusy)
            {
                this.bkWorker.CancelAsync();
            }
        }
    }
}