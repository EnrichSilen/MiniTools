namespace ipwatcher
{
    partial class Watcher
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
            this.lv_ipAdresses = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_ip = new System.Windows.Forms.Label();
            this.Tmr_ipWatcher = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lv_ipAdresses
            // 
            this.lv_ipAdresses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv_ipAdresses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_ipAdresses.Location = new System.Drawing.Point(12, 79);
            this.lv_ipAdresses.Name = "lv_ipAdresses";
            this.lv_ipAdresses.Size = new System.Drawing.Size(260, 132);
            this.lv_ipAdresses.TabIndex = 0;
            this.lv_ipAdresses.UseCompatibleStateImageBehavior = false;
            this.lv_ipAdresses.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Adress";
            this.columnHeader1.Width = 214;
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_ip.Location = new System.Drawing.Point(46, 25);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(120, 32);
            this.lb_ip.TabIndex = 1;
            this.lb_ip.Text = "0.0.0.0";
            // 
            // Tmr_ipWatcher
            // 
            this.Tmr_ipWatcher.Enabled = true;
            this.Tmr_ipWatcher.Interval = 500;
            this.Tmr_ipWatcher.Tick += new System.EventHandler(this.Tmr_ipWatcher_Tick);
            // 
            // Watcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 223);
            this.Controls.Add(this.lb_ip);
            this.Controls.Add(this.lv_ipAdresses);
            this.Name = "Watcher";
            this.Text = "Watcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_ipAdresses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.Timer Tmr_ipWatcher;
    }
}