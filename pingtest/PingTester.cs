using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace pingtest
{
    public partial class PingTester : Form
    {
        string hostName = "8.8.8.8";
        int timeout = 1000;


        public PingTester()
        {
            InitializeComponent();

#if DEBUG
            init(true);
#else
            init(false);
#endif
        }

        private void init(bool debug)
        {
            if(debug)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }

            timerPing.Interval = 1000;
            timerPing.Start();
            lbHostName.Text = hostName;


        }

        private bool PingTest()
        {
            try
            {
                byte[] buffer = new byte[32];

                Ping ping = new Ping();
                PingOptions pingOptions = new PingOptions();
                PingReply reply = ping.Send(hostName, timeout, buffer, pingOptions);
                lbPingResult.Text = "Ping: " + reply.RoundtripTime.ToString() + " ms";

                return reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        private void timerPing_Tick(object sender, EventArgs e)
        {
            if (!PingTest())
            {
                lbPingResult.Text = "No internet connection";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
