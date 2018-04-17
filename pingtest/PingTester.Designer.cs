namespace pingtest
{
    partial class PingTester
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
            this.components = new System.ComponentModel.Container();
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.lbPingResult = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbHostName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerPing
            // 
            this.timerPing.Interval = 1000;
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick);
            // 
            // lbPingResult
            // 
            this.lbPingResult.AutoSize = true;
            this.lbPingResult.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbPingResult.Location = new System.Drawing.Point(12, 9);
            this.lbPingResult.Name = "lbPingResult";
            this.lbPingResult.Size = new System.Drawing.Size(208, 41);
            this.lbPingResult.TabIndex = 0;
            this.lbPingResult.Text = "Ping: 0 ms";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbHostName
            // 
            this.lbHostName.AutoSize = true;
            this.lbHostName.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbHostName.Location = new System.Drawing.Point(12, 65);
            this.lbHostName.Name = "lbHostName";
            this.lbHostName.Size = new System.Drawing.Size(98, 15);
            this.lbHostName.TabIndex = 2;
            this.lbHostName.Text = "Host: 0.0.0.0";
            // 
            // PingTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 92);
            this.Controls.Add(this.lbHostName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbPingResult);
            this.Name = "PingTester";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.Label lbPingResult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbHostName;
    }
}

