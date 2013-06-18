namespace MiniMVP.Controls
{
    partial class BackgroundTaskView
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
            this.backgroundTaskUserControl = new MiniMVP.Controls.BackgroundTaskUserControl();
            this.SuspendLayout();
            // 
            // backgroundTaskUserControl
            // 
            this.backgroundTaskUserControl.BackColor = System.Drawing.Color.White;
            this.backgroundTaskUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundTaskUserControl.Location = new System.Drawing.Point(1, 1);
            this.backgroundTaskUserControl.Name = "backgroundTaskUserControl";
            this.backgroundTaskUserControl.Size = new System.Drawing.Size(196, 30);
            this.backgroundTaskUserControl.TabIndex = 0;
            this.backgroundTaskUserControl.WaitDescription = "Please Wait...";
            // 
            // BackgroundTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(198, 32);
            this.ControlBox = false;
            this.Controls.Add(this.backgroundTaskUserControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BackgroundTaskView";
            this.ResumeLayout(false);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private BackgroundTaskUserControl backgroundTaskUserControl;
    }
}