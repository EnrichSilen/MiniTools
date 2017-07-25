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
        bool tray = false;

        public Watcher()
        {
            InitializeComponent();
            
            InitTrayIcon();

        }

        #region Methods

        private void InitTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.BalloonTipText = "";
            trayIcon.BalloonTipTitle = "IP Changed";
            trayIcon.Text = "IP Watcher";
            if (GetOsName() == "Microsoft Windows 10 Home")
            {
                Icon = Properties.Resources.icon_invert;
                trayIcon.Icon = Properties.Resources.icon_invert;
            }
            else
            {
                Icon = Properties.Resources.icon;
                trayIcon.Icon = Properties.Resources.icon;
            }
            trayIcon.DoubleClick += new EventHandler(TrayIcon_DoubleClick);
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

                if(tray)
                {
                    trayIcon.BalloonTipText = lb_ip.Text;
                    trayIcon.ShowBalloonTip(1500);
                }
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
            if(WindowState == FormWindowState.Minimized)
            {
                trayIcon.Visible = true;
                this.Hide();
                tray = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                trayIcon.Visible = false;
                tray = false;
            }
        }

        #endregion

        private void bt_ping_Click(object sender, EventArgs e)
        {
            
        }

        private void TrayIcon_DoubleClick(object Sender, EventArgs e)
        {
            this.Show();

            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            Activate();
        }
    } 
}
