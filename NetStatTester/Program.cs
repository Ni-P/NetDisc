using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetStatTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test();
            //GetInterface();
            //PingTest();
            //PingTestAsync();
            ThreadTest();
        }

        public static void ThreadTest()
        {

            Console.WriteLine("Main thread: Start a second thread.");
            Thread t = new Thread(new ThreadStart(PingTest));
            t.Start();
            Thread.Sleep(0);
            Console.WriteLine("Main Thread doing stuff...");
            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            Console.ReadLine();

        }

        public static void PingTestAsync()
        {
            Ping ping = new Ping();
            PingOptions options = new PingOptions();
            options.Ttl = 30;
            options.DontFragment = true;
            int timeout = 10000;
            string address = "www.google.com";

            string data = "one ping Vasilyi!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            AutoResetEvent waiter = new AutoResetEvent(false);

            ping.PingCompleted += new PingCompletedEventHandler(PingCallback);

            ping.SendAsync(address, timeout, buffer, options, waiter);

            waiter.WaitOne();
            Console.WriteLine("PingAsync completed.");
        }

        private static void PingCallback(object sender, PingCompletedEventArgs e)
        {
            if(e.Reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Ping was successfull.");
                Console.WriteLine("Address "+e.Reply.Address);
                Console.WriteLine("Roundtrip time "+e.Reply.RoundtripTime);
            }
            else
            {
                Console.WriteLine("Ping failed, reason: " + e.Reply.Status);
            }

            ((AutoResetEvent)e.UserState).Set();

        }

        public static void PingTest()
        {
            Ping ping = new Ping();
            PingOptions options = new PingOptions();
            options.Ttl = 30;
            options.DontFragment = true;
            int timeout = 10000;
            string address = "www.google.com";

            string data = "one ping Vasilyi!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            PingReply reply = ping.Send(address, timeout, buffer, options);
            try
            {

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            } else
                {
                    Console.WriteLine("Ping failed " + reply.Status);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        


        public static void GetInterface()
        {
            IPInterfaceProperties properties;
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                if(adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    if(adapter.OperationalStatus == OperationalStatus.Up)
                    {
                        properties = adapter.GetIPProperties();
                        Console.WriteLine("selected " + adapter.Name);
                        Console.WriteLine("Desciprtion: " + adapter.Description);
                        Console.WriteLine("IPv4 " + ShowIPv4Addresses(adapter.NetworkInterfaceType));
                        Console.WriteLine("MAC " + adapter.GetPhysicalAddress().ToString());
                        Console.WriteLine("IPv6 " + ShowIPv6Addresses(adapter.NetworkInterfaceType));
                    }
                }

            }
        }

        private static string ShowIPv4Addresses(NetworkInterfaceType networkIftype)
        {

            string[] ip4arr = GetAllLocalIPv4(networkIftype);

            return ip4arr.FirstOrDefault<string>();
        }

        private static string ShowIPv6Addresses(NetworkInterfaceType networkIftype)
        {

            string[] ip6arr = GetAllLocalIPv6(networkIftype);

            return ip6arr.FirstOrDefault<string>();
        }

        public static string[] GetAllLocalIPv4(NetworkInterfaceType _type)
        {
            List<string> ipAddrList = new List<string>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddrList.Add(ip.Address.ToString());
                        }
                    }
                }
            }
            return ipAddrList.ToArray();
        }

        public static string[] GetAllLocalIPv6(NetworkInterfaceType _type)
        {
            List<string> ipAddrList = new List<string>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            ipAddrList.Add(ip.Address.ToString());
                        }
                    }
                }
            }
            return ipAddrList.ToArray();
        }

        public static void Test()
        {
            ShowInterfaceSummary();
        }
        public static void ShowInterfaceSummary()
        {

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                Console.WriteLine("Name: {0}", adapter.Name);
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Operational status ...................... : {0}",
                    adapter.OperationalStatus);
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                Console.WriteLine("  IP version .............................. : {0}", versions);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
