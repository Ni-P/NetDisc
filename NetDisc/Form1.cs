using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDisc
{
    public partial class Form1 : Form
    {
        private NetworkInterface networkInterface;
        private NetworkTools netTools;
        private int pingTimeout;
        private int timeToLive;
        private bool dontFragment;

        public Form1()
        {
            InitializeComponent();
            netTools = new NetworkTools();
            ReadHostInterface();
            pingTimeout = 10000;
            timeToLive = 30;
            dontFragment = true;

        }

        private void ReadHostInterface()
        {
            try
            {
                networkInterface = netTools.GetInterface();
                if(networkInterface == null)
                {
                    throw new NullReferenceException();
                }
                richTextBoxIP4.Text = netTools.getIPv4Address(networkInterface);
                richTextBoxIP6.Text = netTools.getIPv6Address(networkInterface);
                richTextBoxMAC.Text = netTools.getMAC(networkInterface);

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("ERROR: No network interface found.");
                Console.WriteLine(e.ToString());
            }
        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            Console.WriteLine("buttonPing clicked.");
            Lockbuttons();
            backgroundPinger.RunWorkerAsync(textBoxTarget.Text);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Lockbuttons();
            ScourSubnet();
            
        }

        private void backgroundPinger_DoWork(object sender, DoWorkEventArgs e)
        {
            
            BackgroundWorker worker = sender as BackgroundWorker;

            if (e.Argument.GetType() == typeof(List<string>))
            {
                List<PingReply> replies = new List<PingReply>();
                PingReply reply;
                foreach (string addr in (List<string>)e.Argument)
                {
                    reply = netTools.SendPing(addr, this.pingTimeout, new PingOptions(this.timeToLive, this.dontFragment));
                    replies.Add(reply);
                }
                e.Result = replies;
            } else
            {
                PingReply reply = netTools.SendPing(e.Argument, this.pingTimeout, new PingOptions(this.timeToLive, this.dontFragment));
                e.Result = reply;

            }

        }

        private void backgroundPinger_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (e.Error != null)
            {
                Console.WriteLine("Error at backgroundPinger");
            }
            else {
                if(e.Result.GetType()==typeof(List<PingReply>))
                {
                    foreach(PingReply reply in (List<PingReply>)e.Result)
                    {
                        handlePingResults(reply);
                    }
                } else
                {
                    handlePingResults((PingReply)e.Result);

                }
            }
        }

        private void handlePingResults(PingReply reply)
        {
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Ping to "+reply.Address+" was a success");
                Console.WriteLine("Address " + reply.Address);
                Console.WriteLine("Roundtrip time " + reply.RoundtripTime);
                
            }
            else
            {
                Console.WriteLine("Ping to "+reply.Address+ " failed, reason: " + reply.Status);
            }
        }

        private void ScourSubnet()
        {
            string subraw = textBoxTargetSubnet.Text;
            string[] parts = subraw.Split('.');
            if(parts.Length != 4)
            {
                Console.WriteLine("Invalid subnet.");
            } else
            {
                string address = parts[0] + "." + parts[1] + "." + parts[2] + ".";
                List<string> addressList = new List<string>();
                for (int i=0;i <256; i++)
                {
                    addressList.Add(address + i);
                    
                }
                backgroundPinger.RunWorkerAsync(addressList);
            }
            //string subnetFields = subraw.Substring(subraw.IndexOf("."));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Lockbuttons()
        {
            this.buttonSearch.Enabled = false;
            this.buttonPing.Enabled = false;
        }
        private void Unlockbuttons()
        {
            this.buttonSearch.Enabled = true;
            this.buttonPing.Enabled = true;
        }
    }
}
