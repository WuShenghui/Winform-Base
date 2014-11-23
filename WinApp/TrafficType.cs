using System;
using System.Windows.Forms;

namespace WinApp
{
    public partial class TrafficType : Form
    {
        private bool isSubFormExitApp;

        public TrafficType()
        {
            this.InitializeComponent();
        }

        private void ToTargetFrom(TrafficTypes trafficType)
        {
            this.Hide();

            switch (trafficType)
            {
                case TrafficTypes.Bicycle:
                    using (var form = new Bicycle(TrafficTypes.Bicycle))
                    {
                        this.ShowTargetForm(form);
                    }

                    break;
                case TrafficTypes.Train:
                    using (var form = new Train(TrafficTypes.Train))
                    {
                        this.ShowTargetForm(form);
                    }

                    break;
                case TrafficTypes.Airplane:
                    using (var form = new Airplane(TrafficTypes.Airplane))
                    {
                        this.ShowTargetForm(form);
                    }

                    break;
                default:
                    break;
            }
        }

        private void ShowTargetForm(BaseTraffic form)
        {
            var result = form.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                if (form.IsBack)
                {
                    this.Show();
                }
                else
                {
                    // To close application when close form 
                    // Prevate show twice close Comfirm message,need a global var to stop it.
                    this.isSubFormExitApp = true;
                    Application.Exit();
                }
            }
        }

        private void BtnBicycle_Click(object sender, EventArgs e)
        {
            this.ToTargetFrom(TrafficTypes.Bicycle);
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            this.ToTargetFrom(TrafficTypes.Train);
        }

        private void BtnAirplane_Click(object sender, EventArgs e)
        {
            this.ToTargetFrom(TrafficTypes.Airplane);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!this.isSubFormExitApp)
            {
                var result = MessageBox.Show(
                            "Are you sure you want to exit?",
                            "Opration",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

                e.Cancel = result == DialogResult.No;
            }
        }    
    }
}
