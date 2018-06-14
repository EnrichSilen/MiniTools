using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace pingtest
{
    public partial class PingTester : Form
    {
        string hostName = "8.8.8.8";
        int timeout = 1000;

        Color onColor = Color.Green;
        Color offColor = Color.Red;

        public PingTester()
        {
            InitializeComponent();

#if DEBUG
            init(true);
#else
            init(false);
#endif
        }

        #region Private Methods

        private void init(bool debug)
        { 
            timerPing.Start();
            lbHostName.Text = hostName;
            tscbIPs.SelectedIndex = 0;
            //onTopToolStripMenuItem.ForeColor = offColor;
        }

        private bool PingTest()
        {
            try
            {
                byte[] buffer = new byte[32];

                Ping ping = new Ping();
                PingOptions pingOptions = new PingOptions();
                PingReply reply = ping.Send(hostName, timeout, buffer, pingOptions);
                ColorTextOutput(reply.RoundtripTime);

                return reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ColorTextOutput(double input)
        {
            if (input > 200)
                lbPingResult.ForeColor = Color.Red;
            else if (input > 50)
                lbPingResult.ForeColor = Color.Orange;
            else
                lbPingResult.ForeColor = Color.DarkGreen;


            lbPingResult.Text = "Ping: " + input.ToString() + " ms";
        }

        #endregion

        #region Events

        private void timerPing_Tick(object sender, EventArgs e)
        {
            if (!PingTest())
            {
                lbPingResult.Text = "No internet connection";
            }
        }

        private void timerGC_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

       

        private void tscbHostname_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (sender as ToolStripComboBox);

            hostName = comboBox.SelectedItem.ToString();
            lbHostName.Text = hostName;
            //if (comboBox.Name == "tscbIPs")
            //{
            //    tscbDomains.SelectedIndex = -1;
            //}
            //else
            //{
            //    comboBox.SelectedIndex = -1;
            //}
        }
        
        
        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripItem;
            //MessageBox.Show(menuItem.Name);

            /*
             * I'm not sure if color is way to go or text
             * Maybe both or something else?
             */
            if(menuItem.ForeColor == offColor || menuItem.Text == "On Top off")
            {
                TopMost = true;
                //menuItem.ForeColor = onColor;
                menuItem.Text = "On Top on";
            }
            else
            {
                TopMost = false;
                //menuItem.ForeColor = offColor;
                menuItem.Text = "On Top off";
            }
        }

        #endregion
    }
}
