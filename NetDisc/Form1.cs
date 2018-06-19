using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDisc
{
    public partial class MainForm : Form
    {
        private NetworkInterface networkInterface;
        private NetworkTools netTools;
        private int pingTimeout;
        private int timeToLive;
        private bool dontFragment;
        private int firstHost;
        private int lastHost;
        private Queue<PingReply> pingResults;

        private IPAddress IPv4;
        private IPAddress IPv6;
        private string MAC;
        private IPAddress Gateway;
        private IPAddress SubnetMask;

        public MainForm()
        {
            InitializeComponent();
            netTools = new NetworkTools();
            ReadHostInterface();
            UpdateHostAddresses();
            pingTimeout = 100;
            timeToLive = 30;
            dontFragment = true;
            this.textBoxTarget.Text = this.IPv4.ToString();
            //ListBoxTest();
        }

        private void ListBoxTest()
        {
            ListBoxResults.Items.Add(IPv4);
            ListBoxResults.Items.Add(IPv6);
            ListBoxResults.Items.Add(SubnetMask);
            try
            {
                pingResults.Dequeue();

            } catch (ThreadInterruptedException e)
            {

            }
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
                this.IPv4 = netTools.getIPv4Address(networkInterface);
                this.IPv6 = netTools.getIPv6Address(networkInterface);
                this.MAC = netTools.getMAC(networkInterface);
                this.Gateway = networkInterface.GetIPProperties().GatewayAddresses.Select(g => g?.Address).Where(a=>a!=null).FirstOrDefault();
                this.SubnetMask = networkInterface.GetIPProperties().UnicastAddresses.Select(g => g?.IPv4Mask).Where(a => a != null&&!a.ToString().Equals("0.0.0.0")).FirstOrDefault();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("ERROR: No network interface found.");
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void UpdateHostAddresses()
        {
            richTextBoxIP4.Text = this.IPv4.ToString();
            richTextBoxIP6.Text = this.IPv6.ToString();
            richTextBoxMAC.Text = this.MAC;
            richTextBoxSubnet.Text = this.SubnetMask.ToString();
            richTextBoxGateway.Text = this.Gateway.ToString();
        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            Console.WriteLine("buttonPing clicked.");
            Lockbuttons();
            backgroundPinger.RunWorkerAsync(textBoxTarget.Text);
            Unlockbuttons();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Lockbuttons();
            string subnetInput = this.textBoxTargetSubnet.Text;
            string[] subnetBaseArr = subnetInput.Trim().Split('.');
            string subnetbase = subnetBaseArr[0]+ "." + subnetBaseArr[1] + "." + subnetBaseArr[2];
            List<PingReply> replyList = new List<PingReply>();
            for (int i=50;i<110;i++)
            {
                replyList.Add(PingTask(subnetbase+"."+i));

            }
            Unlockbuttons();
            foreach(PingReply rep in replyList)
            {
                if (rep.Status == IPStatus.Success) this.ListBoxResults.Items.Add("Found host at: " + rep.Address);
                //else this.ListBoxResults.Items.Add("Host at: " + rep.Address+" Failed to respond.");

            }
            //this.ListBoxResults.Items.AddRange(replyList.ToArray());
        }

        public PingReply PingTask(string address)
        {
            Task<PingReply> ping = Task.Run(() =>
            {
                return (netTools.SendPing(address, this.pingTimeout, new PingOptions(this.timeToLive, this.dontFragment)));
            });

            ping.ContinueWith(res =>
            {
                //Console.WriteLine("at Task result callback");
                if (ping.Result.Status == IPStatus.Success)
                {
                    //this.ListBoxResults.Items.Add(ping.Result.Address);
                    return ping.Result;
                }
                Console.WriteLine(ping.Result.Status);
                return ping.Result;
            });
            return ping.Result;
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
                this.ListBoxResults.Items.Add("Ping to host: " + reply.Address + " was successfull.");
                
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
            this.firstHost =(int) Convert.ToInt32(this.textBoxRangeMin.Text);
            this.lastHost =(int) Convert.ToInt32(this.textBoxRangeMax.Text);
            if(parts.Length != 4)
            {
                Console.WriteLine("Invalid subnet.");
            } else
            {
                string address = parts[0] + "." + parts[1] + "." + parts[2] + ".";
                List<string> addressList = new List<string>();
                for (int i= firstHost; i < lastHost; i++)
                {
                    addressList.Add(address + i);
                    
                }
                backgroundPinger.RunWorkerAsync(addressList);
            }
            //string subnetFields = subraw.Substring(subraw.IndexOf("."));
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

        private void richTextBoxGateway_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTarget_Enter(object sender, EventArgs e)
        {
            this.textBoxTarget.Text = "";
        }

        private void textBoxTarget_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTargetSubnet_Enter(object sender, EventArgs e)
        {
            this.textBoxTargetSubnet.Text = "";
        }
    }
}
