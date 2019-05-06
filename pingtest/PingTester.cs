using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace pingtest
{
    public partial class PingTester : Form
    {
        int timeout = 1000;

        public PingTester()
        {
            InitializeComponent();
            
            //custom Inits
            tscbDomains.SelectedIndex = 0;
        }

        #region Private Methods

        private bool PingTest()
        {
            try
            {
                var buffer = new byte[32];
                var reply = new Ping().Send(lbHostName.Text, timeout, buffer, new PingOptions());
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
                lbPingResult.ForeColor = Color.Black;
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
            lbHostName.Text = comboBox.SelectedItem.ToString();
        }
        
        
        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TopMost)
            {
                TopMost = true;
                this.Text = "Ping Test (On Top)";
            }
            else
            {
                TopMost = false;
                this.Text = "Ping Test";
            }
        }
        #endregion
    }
}
