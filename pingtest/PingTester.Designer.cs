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
            this.lbHostName = new System.Windows.Forms.Label();
            this.timerGC = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiHosts = new System.Windows.Forms.ToolStripMenuItem();
            this.iPsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbIPs = new System.Windows.Forms.ToolStripComboBox();
            this.domainsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbDomains = new System.Windows.Forms.ToolStripComboBox();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.lbPingResult.Location = new System.Drawing.Point(12, 36);
            this.lbPingResult.Name = "lbPingResult";
            this.lbPingResult.Size = new System.Drawing.Size(208, 41);
            this.lbPingResult.TabIndex = 0;
            this.lbPingResult.Text = "Ping: 0 ms";
            // 
            // lbHostName
            // 
            this.lbHostName.AutoSize = true;
            this.lbHostName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbHostName.Location = new System.Drawing.Point(15, 101);
            this.lbHostName.Name = "lbHostName";
            this.lbHostName.Size = new System.Drawing.Size(126, 19);
            this.lbHostName.TabIndex = 2;
            this.lbHostName.Text = "Host: 0.0.0.0";
            // 
            // timerGC
            // 
            this.timerGC.Interval = 10000;
            this.timerGC.Tick += new System.EventHandler(this.timerGC_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHosts,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(287, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiHosts
            // 
            this.tsmiHosts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPsToolStripMenuItem,
            this.domainsToolStripMenuItem});
            this.tsmiHosts.Name = "tsmiHosts";
            this.tsmiHosts.Size = new System.Drawing.Size(49, 20);
            this.tsmiHosts.Text = "Hosts";
            // 
            // iPsToolStripMenuItem
            // 
            this.iPsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbIPs});
            this.iPsToolStripMenuItem.Name = "iPsToolStripMenuItem";
            this.iPsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iPsToolStripMenuItem.Text = "IPs";
            // 
            // tscbIPs
            // 
            this.tscbIPs.Items.AddRange(new object[] {
            "1.0.0.1",
            "1.1.1.1",
            "8.8.4.4",
            "8.8.8.8"});
            this.tscbIPs.Name = "tscbIPs";
            this.tscbIPs.Size = new System.Drawing.Size(121, 23);
            this.tscbIPs.Sorted = true;
            this.tscbIPs.SelectedIndexChanged += new System.EventHandler(this.tscbHostname_SelectedIndexChanged);
            // 
            // domainsToolStripMenuItem
            // 
            this.domainsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbDomains});
            this.domainsToolStripMenuItem.Name = "domainsToolStripMenuItem";
            this.domainsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.domainsToolStripMenuItem.Text = "Domains";
            // 
            // tscbDomains
            // 
            this.tscbDomains.Items.AddRange(new object[] {
            "google.com",
            "bing.com",
            "example.com"});
            this.tscbDomains.Name = "tscbDomains";
            this.tscbDomains.Size = new System.Drawing.Size(121, 23);
            this.tscbDomains.SelectedIndexChanged += new System.EventHandler(this.tscbHostname_SelectedIndexChanged);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onTopToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // onTopToolStripMenuItem
            // 
            this.onTopToolStripMenuItem.Name = "onTopToolStripMenuItem";
            this.onTopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.onTopToolStripMenuItem.Text = "On Top off";
            this.onTopToolStripMenuItem.Click += new System.EventHandler(this.onTopToolStripMenuItem_Click);
            // 
            // PingTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 134);
            this.Controls.Add(this.lbHostName);
            this.Controls.Add(this.lbPingResult);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PingTester";
            this.Text = "Ping Test";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.Label lbPingResult;
        private System.Windows.Forms.Label lbHostName;
        private System.Windows.Forms.Timer timerGC;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiHosts;
        private System.Windows.Forms.ToolStripMenuItem iPsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscbIPs;
        private System.Windows.Forms.ToolStripMenuItem domainsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscbDomains;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onTopToolStripMenuItem;
    }
}

