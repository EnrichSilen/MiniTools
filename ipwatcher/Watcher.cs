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
using System.Net.NetworkInformation;

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
            trayIcon = new NotifyIcon
            {
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipText = "",
                BalloonTipTitle = "IP Changed",
                Text = "IP Watcher"
            };
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
            return name?.ToString() ?? "Unknown";
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

        private static bool PingTest()
        {
            try
            {
                Ping myPing = new Ping();
                string host = "8.8.8.8";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);

                return reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
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
                Hide();
                tray = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                trayIcon.Visible = false;
                tray = false;
            }
        }

        #endregion

       
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();

            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            Activate();
        }

        private void Tmr_ConnectionCheck_Tick(object sender, EventArgs e)
        {
            if (PingTest())
                pb_pingResult.BackColor = Color.Green;
            else
                pb_pingResult.BackColor = Color.Red;
            Tmr_ConnectionCheck.Interval = 2500;
        }

        private void chb_connectionCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(chb_connectionCheck.Checked)
            {
                Tmr_ConnectionCheck.Start();

            }
            else
            {
                Tmr_ConnectionCheck.Stop();
                Tmr_ConnectionCheck.Interval = 1;
            }
        }
    } 
}
