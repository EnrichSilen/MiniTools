using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;


namespace ipwatcher
{
    public partial class Watcher : Form
    {
        private NotifyIcon trayIcon;

        string lastIpRecord;

        public Watcher()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon;
            InitTrayIcon();

        }

        #region Methods

        private void InitTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.BalloonTipText = "I noticed that you double-clicked me! What can I do for you?";
            trayIcon.BalloonTipTitle = "You called Master?";
            trayIcon.Text = "My fabulous tray icon demo application";
            if (GetOsName() == "Microsoft Windows 10 Home")
                trayIcon.Icon = Properties.Resources.icon_invert;
            else
                trayIcon.Icon = Properties.Resources.icon;
        }

        private string GetOsName()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }

        private void AddIpToRecord()
        {
            if (lb_ip.Text != lastIpRecord)
            {
                var ipItem = new ListViewItem(lb_ip.Text);
                lv_ipAdresses.Items.Add(ipItem);
                lastIpRecord = lb_ip.Text;
            }
        }

        private static string GetLocalIPAddress()
        {

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "0.0.0.0";

        }



        #endregion

        #region Events

        private void Tmr_ipWatcher_Tick(object sender, EventArgs e)
        {
            lb_ip.Text = GetLocalIPAddress();
            AddIpToRecord();
            lv_ipAdresses.TopItem = lv_ipAdresses.Items.Cast<ListViewItem>().LastOrDefault();
        }

        private void chb_OnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_onTop.Checked)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        private void Watcher_Resize(object sender, EventArgs e)
        {
            trayIcon.Visible = true;
        }

        #endregion

        private void bt_ping_Click(object sender, EventArgs e)
        {
            trayIcon.ShowBalloonTip(5000);
            
        }
    } 
}
