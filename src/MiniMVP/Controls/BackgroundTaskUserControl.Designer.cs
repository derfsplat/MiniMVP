namespace MiniMVP.Controls
{
    partial class BackgroundTaskUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWaitDescription = new System.Windows.Forms.Label();
            this.spinningProgress1 = new MiniMVP.Controls.SpinningProgress();
            this.SuspendLayout();
            // 
            // lblWaitDescription
            // 
            this.lblWaitDescription.AutoSize = true;
            this.lblWaitDescription.BackColor = System.Drawing.Color.White;
            this.lblWaitDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitDescription.Location = new System.Drawing.Point(38, 7);
            this.lblWaitDescription.Name = "lblWaitDescription";
            this.lblWaitDescription.Size = new System.Drawing.Size(104, 16);
            this.lblWaitDescription.TabIndex = 31;
            this.lblWaitDescription.Text = "Please Wait...";
            this.lblWaitDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spinningProgress1
            // 
            this.spinningProgress1.ActiveSegmentColour = System.Drawing.Color.Green;
            this.spinningProgress1.AutoIncrementFrequency = 100D;
            this.spinningProgress1.BehindTransistionSegmentIsActive = false;
            this.spinningProgress1.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinningProgress1.InactiveSegmentColour = System.Drawing.SystemColors.Control;
            this.spinningProgress1.Location = new System.Drawing.Point(0, 0);
            this.spinningProgress1.Name = "spinningProgress1";
            this.spinningProgress1.Size = new System.Drawing.Size(30, 30);
            this.spinningProgress1.TabIndex = 32;
            this.spinningProgress1.TransistionSegment = 1;
            this.spinningProgress1.TransistionSegmentColour = System.Drawing.Color.LimeGreen;
            // 
            // BackgroundTaskUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblWaitDescription);
            this.Controls.Add(this.spinningProgress1);
            this.Name = "BackgroundTaskUserControl";
            this.Size = new System.Drawing.Size(196, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWaitDescription;
        private MiniMVP.Controls.SpinningProgress spinningProgress1;


    }
}
