namespace WinService.TestRunner
{
    partial class WinServiceController
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonShutdown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(189, 12);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.ButtonPauseClick);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(270, 12);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 2;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.ButtonContinueClick);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(93, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
            // 
            // buttonShutdown
            // 
            this.buttonShutdown.Location = new System.Drawing.Point(367, 12);
            this.buttonShutdown.Name = "buttonShutdown";
            this.buttonShutdown.Size = new System.Drawing.Size(75, 23);
            this.buttonShutdown.TabIndex = 4;
            this.buttonShutdown.Text = "Shutdown";
            this.buttonShutdown.UseVisualStyleBackColor = true;
            this.buttonShutdown.Click += new System.EventHandler(this.ButtonShutdownClick);
            // 
            // WinServiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 49);
            this.Controls.Add(this.buttonShutdown);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStart);
            this.MinimumSize = new System.Drawing.Size(470, 84);
            this.Name = "WinServiceControl";
            this.Text = "WinService TestRunner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonShutdown;
    }
}

