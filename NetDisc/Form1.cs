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
        private int pingTimeout = 4000;
        private int timeToLive = 30;
        private bool dontFragment = true;
        private int firstHost = 0;
        private int lastHost = 255;
        private int bufferSize = 32;
        private bool _isPinging = false;

        private int pendingPings = 0;

        private IPAddress IPv4;
        private IPAddress IPv6;
        private string MAC;
        private IPAddress Gateway;
        private IPAddress SubnetMask;
        private bool showUnsuccessfullPings;

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
            this.FormClosed += (object o, FormClosedEventArgs e) =>
            {
                Environment.Exit(0);
            };
        }

        private delegate void _AddtoListBox(PingReply reply);
        private delegate PingReply _PingInThread(string ip);
        //private delegate void _

        private void ReadHostInterface()
        {
            try
            {
                networkInterface = netTools.GetInterface();
                if (networkInterface == null)
                {
                    throw new NullReferenceException();
                }
                this.IPv4 = netTools.getIPv4Address(networkInterface);
                this.IPv6 = netTools.getIPv6Address(networkInterface);
                this.MAC = netTools.getMAC(networkInterface);
                this.Gateway = networkInterface.GetIPProperties().GatewayAddresses.Select(g => g?.Address).Where(a => a != null).FirstOrDefault();
                this.SubnetMask = networkInterface.GetIPProperties().UnicastAddresses.Select(g => g?.IPv4Mask).Where(a => a != null && !a.ToString().Equals("0.0.0.0")).FirstOrDefault();
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
            handlePingResults(PingTask(textBoxTarget.Text), textBoxTarget.Text);
            Unlockbuttons();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            this.buttonSearch.Text = "Sending pings...";
            Lockbuttons();
            //_PingInThread threadDelegate = PingTask;
            string subnetInput = this.textBoxTargetSubnet.Text;
            string[] subnetBaseArr = subnetInput.Trim().Split('.');
            string subnetbase = subnetBaseArr[0] + "." + subnetBaseArr[1] + "." + subnetBaseArr[2];
            this.firstHost = (int)Convert.ToInt32(this.textBoxRangeMin.Text);
            this.lastHost = (int)Convert.ToInt32(this.textBoxRangeMax.Text);
            List<PingReply> replyList = new List<PingReply>();
            this.pendingPings = 0;
            for (int ip = this.firstHost; ip < this.lastHost; ip++)
            {
                new Thread((targetip) =>
                {
                    Thread.CurrentThread.IsBackground = false; // so the threads won't keep running when the form closes
                    this.pendingPings++;
                    PingReply rep = PingTask(targetip.ToString());
                    replyList.Add(rep);
                    handlePingResults(rep, targetip.ToString());
                    this.pendingPings--;
                }).Start(subnetbase + "." + ip);
                //replyList.Add(PingTask(subnetbase+"."+ip));

            }
            this.buttonSearch.Text = "Scan Subnet";
            this.ListBoxResults.Items.Add("Pings sent");
            Thread.Sleep(100);
            //Unlockbuttons();
            new Thread(() =>
            {
                while (this.pendingPings > 0)
                {
                    Thread.Sleep(10);
                }
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                        {
                            this.ListBoxResults.Items.Add("Scanning complete");
                            DoAutoscroll();
                            Unlockbuttons();
                        }));
                }
            }).Start();
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
                try
                {
                    //Console.WriteLine("at Task result callback");
                    //if (ping == null) return null;
                    if (ping.Result.Status == IPStatus.Success)
                    {
                        //this.ListBoxResults.Items.Add(ping.Result.Address);
                        return ping.Result;
                    }
                    //Console.WriteLine(ping.Result.Status);
                    return ping.Result;
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                    return ping.Result;
                }
            }
            );
            return ping.Result;
        }

        #region backgroundTask
        private void backgroundPinger_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker;
            while (_isPinging)
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

        private void handlePingResults(PingReply reply, string ip)
        {
            if (reply == null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.ListBoxResults.Items.Add("Ping operation failed");
                        DoAutoscroll();


                    }));
                }
                else
                {
                    this.ListBoxResults.Items.Add("Ping operation failed");
                }
            }
            else
            {
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Ping to " + reply.Address + " was a success");
                    Console.WriteLine("Address " + reply.Address);
                    Console.WriteLine("Roundtrip time " + reply.RoundtripTime);
                    if (this.InvokeRequired)
                    {
                        try
                        {

                            this.Invoke(new Action(() =>
                            {
                                this.ListBoxResults.Items.Add("Reply from:  " + reply.Address + "    bytes=" + reply.Buffer.Length + "    RTT=" + reply.RoundtripTime);
                                DoAutoscroll();
                            }));
                        }
                        catch (ObjectDisposedException e)
                        {
                            Console.WriteLine(e.Message);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        this.ListBoxResults.Items.Add("Reply from:  " + reply.Address + "    bytes=" + reply.Buffer.Length + "    RTT=" + reply.RoundtripTime);
                        DoAutoscroll();
                    }

                }
                else
                {
                    if (showUnsuccessfullPings)
                    {
                        if (this.InvokeRequired)
                        {
                            try
                            {

                                this.Invoke(new Action(() =>
                                {
                                    this.ListBoxResults.Items.Add("Ping to        " + ip + "    failed,    reason: " + reply.Status);
                                    DoAutoscroll();
                                }));
                            }
                            catch (ObjectDisposedException e)
                            {
                                Console.WriteLine(e.Message);
                                Environment.Exit(0);
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Ping to " + ip + " failed, reason: " + reply.Status);

                    }
                }
            }
        }

        private void DoAutoscroll()
        {

            if (this.ListBoxResults.Items.Count >= 24)
            {
                this.ListBoxResults.TopIndex = this.ListBoxResults.Items.Count - 23;
            }


        }

        private void ScourSubnet()
        {
            string subraw = textBoxTargetSubnet.Text;
            string[] parts = subraw.Split('.');
            this.firstHost = (int)Convert.ToInt32(this.textBoxRangeMin.Text);
            this.lastHost = (int)Convert.ToInt32(this.textBoxRangeMax.Text);
            if (parts.Length != 4)
            {
                Console.WriteLine("Invalid subnet.");
            }
            else
            {
                string address = parts[0] + "." + parts[1] + "." + parts[2] + ".";
                List<string> addressList = new List<string>();
                for (int i = firstHost; i < lastHost; i++)
                {
                    addressList.Add(address + i);

                }
                backgroundPinger.RunWorkerAsync(addressList);
            }
            //string subnetFields = subraw.Substring(subraw.IndexOf("."));
        }

        private string IPStringFilter(string ip)
        {
            string filteredIp = String.Empty;
            if (ip.ToLower().Equals("localhost") || ip.ToLower().Contains("localhost")) return "localhost";
            char[] legalChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F', '.', ':' };
            foreach (char c in ip)
            {
                if (legalChars.Contains(c)) filteredIp += c;
            }

            return filteredIp;
        }

        private string ValidateIP(string ip)
        {
            if (!this.checkBoxIPonly.Checked) return ip;
            if (ip.Equals("") || ip == null) return "localhost";
            string filteredIP = IPStringFilter(ip);
            if (filteredIP.Equals("localhost")) return filteredIP;
            else if (filteredIP.Contains(".")) filteredIP = ValidateIP4(filteredIP);
            else if (filteredIP.Contains(":")) filteredIP = ValidateIP6(filteredIP);
            else return filteredIP;

            return filteredIP;
        }

        private string ValidateIP4(string ip)
        {
            string[] ipArray = ip.Split('.');
            List<int> filteredArray = new List<int>(4);
            foreach (string element in ipArray)
            {
                try
                {
                    int value = Convert.ToInt32(element);
                    if (value < 0 || value > 255) continue;
                    else filteredArray.Add(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (filteredArray.Count == 0) return "0.0.0.0";
            else if (filteredArray.Count == 4) return IPArrayToString(filteredArray, false);
            else if (filteredArray.Count < 4)
            {
                while (filteredArray.Count < 4) filteredArray.Add(0);
                return IPArrayToString(filteredArray, false);
            }
            else
            {
                filteredArray.RemoveRange(4, filteredArray.Count - 1);
                return IPArrayToString(filteredArray, false);
            }

        }
        private string ValidateIP6(string ip)
        {
            //if (ip.Equals("::1")) return "localhost";
            //            List<string> filteredArray = new List<string>(8);
            //bool isCompressed = false;

            //isCompressed = ip.Contains("::") ? true : false;

            //if(isCompressed)
            //{
            //    string[] ipPartials = ip.Split();

            //}


            //foreach (string element in ipArray)
            //{
            //    if (element.Count<char>() == 0)
            //    {
            //        if (!isCompressed)
            //        {
            //            isCompressed = true;
            //            filteredArray.Add(":");
            //        }
            //        else
            //        {
            //            return "";
            //        }

            //    }
            //    else if(element.Count<char>() == 1)

            //    filteredArray.Add(":");
            //}

            return ip;
        }

        private string IPArrayToString(List<int> ipArray, bool isIP6)
        {
            string ip = "";
            if (isIP6)
            {
                foreach (int element in ipArray)
                {
                    ip += element + ":";
                }
                return ip.TrimEnd(':');
            }
            else
            {
                foreach (int element in ipArray)
                {
                    ip += element + ".";
                }
                return ip.TrimEnd('.');

            }

        }

        private int ValidateInteger(string value)
        {
            try
            {
                int number = Convert.ToInt32(value);
                return number;

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }


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

        private void textBoxTarget_Validating(object sender, CancelEventArgs e)
        {
            this.textBoxTarget.Text = ValidateIP(this.textBoxTarget.Text);
        }

        private void textBoxRangeMin_Validating(object sender, CancelEventArgs e)
        {
            if (this.textBoxRangeMin.Text == "") this.textBoxRangeMin.Text = this.firstHost.ToString();
            else
            {
                int value = ValidateInteger(this.textBoxRangeMin.Text);

                if (value <= 0)
                {
                    this.textBoxRangeMin.Text = "0";
                    this.firstHost = 0;
                }
                else if (value > this.lastHost)
                {
                    this.firstHost = this.lastHost;
                    this.textBoxRangeMin.Text = this.lastHost.ToString();
                }
                else
                {
                    this.textBoxRangeMin.Text = value.ToString();
                    this.firstHost = value;
                }
            }

        }

        private void textBoxRangeMax_Validating(object sender, CancelEventArgs e)
        {
            if (this.textBoxRangeMax.Text == "") this.textBoxRangeMax.Text = this.lastHost.ToString();
            else
            {
                int value = ValidateInteger(this.textBoxRangeMax.Text);
                if (value <= 0)
                {
                    this.textBoxRangeMax.Text = "0";
                    this.lastHost = 0;
                }
                else if (value >= 255)
                {
                    this.textBoxRangeMax.Text = "255";
                    this.lastHost = 255;
                }
                else if (value <= this.firstHost)
                {
                    this.lastHost = this.firstHost;
                    this.textBoxRangeMax.Text = this.firstHost.ToString();
                }
                else
                {
                    this.textBoxRangeMax.Text = value.ToString();
                    this.lastHost = value;
                }
            }
        }

        private void checkBoxIPonly_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxIPonly.Checked) textBoxTarget_Validating(sender, new CancelEventArgs());
        }

        private void labelIP4_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxShowFailedPings_CheckStateChanged(object sender, EventArgs e)
        {
            this.showUnsuccessfullPings = this.checkBoxShowFailedPings.Checked;
        }

        private void textBoxBufferSize_Validating(object sender, CancelEventArgs e)
        {
            ValidateBufferSize();
        }

        private void ValidateBufferSize()
        {
            int value = 32;
            try
            {
                value = Convert.ToInt32(this.textBoxBufferSize.Text);
                if (value > 65500) value = 65500;
                else if (value < 1) value = 1;


            }
            catch (FormatException fe)
            {
                this.bufferSize = 32;
            }
            catch (OverflowException oe)
            {

                this.bufferSize = 32;
            }
            finally
            {
                this.textBoxBufferSize.Text = value.ToString();
                this.bufferSize = value;
            }
        }

        private void textBoxTTL_Validating(object sender, CancelEventArgs e)
        {
            if (this.textBoxTTL.Text == "") this.textBoxTTL.Text = this.timeToLive.ToString();
            else
            {
                int value = ValidateInteger(this.textBoxTTL.Text);

                if (value <= 0)
                {
                    this.textBoxTTL.Text = "1";
                    this.timeToLive = 1;
                }
                else if (value > 255)
                {
                    this.textBoxTTL.Text = "255";
                    this.timeToLive = 255;

                }
                else
                {
                    this.timeToLive = value;

                }
            }
        }

        private void textBoxTimeout_Validating(object sender, CancelEventArgs e)
        {
            if (this.textBoxTimeout.Text == "") this.textBoxTimeout.Text = this.pingTimeout.ToString();
            else
            {
                int value = ValidateInteger(this.textBoxTimeout.Text);

                if (value <= 0)
                {
                    this.textBoxTimeout.Text = "1";
                    this.pingTimeout = 1;
                }
                else if (value > 10000)
                {
                    this.textBoxTimeout.Text = "10000";
                    this.pingTimeout = 10000;

                }
                else
                {
                    this.pingTimeout = value;

                }
            }
        }
    }
}
