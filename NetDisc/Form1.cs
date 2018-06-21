using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
        private bool _isPinging = false;

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
            pingTimeout = Convert.ToInt32(this.textBoxTimeout.Text);
            timeToLive = Convert.ToInt32(this.textBoxTTL.Text);
            dontFragment = true;
            this.textBoxTarget.Text = this.IPv4.ToString();

        }

        private delegate void _AddtoListBox(PingReply reply);
        private delegate PingReply _PingInThread(string ip);
        //private delegate void _

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
            //Console.WriteLine("buttonPing clicked.");
            Lockbuttons();
            handlePingResults(PingTask(textBoxTarget.Text));
            Unlockbuttons();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Lockbuttons();
            //_PingInThread threadDelegate = PingTask;
            string subnetInput = this.textBoxTargetSubnet.Text;
            string[] subnetBaseArr = subnetInput.Trim().Split('.');
            string subnetbase = subnetBaseArr[0]+ "." + subnetBaseArr[1] + "." + subnetBaseArr[2];
            this.firstHost = (int)Convert.ToInt32(this.textBoxRangeMin.Text);
            this.lastHost = (int)Convert.ToInt32(this.textBoxRangeMax.Text);
            List<PingReply> replyList = new List<PingReply>();
            for (int ip=this.firstHost;ip< this.lastHost; ip++)
            {
                new Thread((targetip)=> {
                    PingReply rep = PingTask(targetip.ToString());
                    replyList.Add(rep);
                    handlePingResults(rep);
                }).Start(subnetbase + "." + ip);
                //replyList.Add(PingTask(subnetbase+"."+ip));

            }
            Unlockbuttons();
            //foreach(PingReply rep in replyList)
            //{
            //    if (rep.Status == IPStatus.Success) this.ListBoxResults.Items.Add("Found host at: " + rep.Address);
            //    //else this.ListBoxResults.Items.Add("Host at: " + rep.Address+" Failed to respond.");

            //}
            //this.ListBoxResults.Items.AddRange(replyList.ToArray());
        }

        private PingReply PingTask(string address)
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

        #region backgroundTask
        private void backgroundPinger_DoWork(object sender, DoWorkEventArgs e)
        {
            
            BackgroundWorker worker = sender as BackgroundWorker;
            while(_isPinging)
            {

            }


        }

        private void backgroundPinger_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                Console.WriteLine("Error at backgroundPinger");
            }
            else
            {

            }
        }
        #endregion

        private void handlePingResults(PingReply reply)
        {
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Ping to "+reply.Address+" was a success");
                Console.WriteLine("Address " + reply.Address);
                Console.WriteLine("Roundtrip time " + reply.RoundtripTime);
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(()=>
                    {
                        this.ListBoxResults.Items.Add("Ping to host: " + reply.Address + " was successfull.");
                    }));
                } else
                {
                    this.ListBoxResults.Items.Add("Ping to host: " + reply.Address + " was successfull.");
                }
                
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
