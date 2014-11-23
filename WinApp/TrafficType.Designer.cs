namespace WinApp
{
    partial class TrafficType
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBicycle = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnAirplane = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBicycle
            // 
            this.btnBicycle.Location = new System.Drawing.Point(76, 39);
            this.btnBicycle.Name = "btnBicycle";
            this.btnBicycle.Size = new System.Drawing.Size(136, 23);
            this.btnBicycle.TabIndex = 0;
            this.btnBicycle.Text = "Bicycle";
            this.btnBicycle.UseVisualStyleBackColor = true;
            this.btnBicycle.Click += new System.EventHandler(this.BtnBicycle_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(76, 79);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(136, 23);
            this.btnTrain.TabIndex = 2;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnAirplane
            // 
            this.btnAirplane.Location = new System.Drawing.Point(76, 119);
            this.btnAirplane.Name = "btnAirplane";
            this.btnAirplane.Size = new System.Drawing.Size(136, 23);
            this.btnAirplane.TabIndex = 4;
            this.btnAirplane.Text = "Airplane";
            this.btnAirplane.UseVisualStyleBackColor = true;
            this.btnAirplane.Click += new System.EventHandler(this.BtnAirplane_Click);
            // 
            // TrafficType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 186);
            this.Controls.Add(this.btnAirplane);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnBicycle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TrafficType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrafficType";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBicycle;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnAirplane;
    }
}

