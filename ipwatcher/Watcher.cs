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

namespace ipwatcher
{
    public partial class Watcher : Form
    {
        public Watcher()
        {
            InitializeComponent();
        }

        private void Tmr_ipWatcher_Tick(object sender, EventArgs e)
        {
            lb_ip.Text = GetLocalIPAddress();
            AddIpToRecord();
            lv_ipAdresses.TopItem = lv_ipAdresses.Items.Cast<ListViewItem>().LastOrDefault();
        }



        string lastIpRecord;
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
    }
}
