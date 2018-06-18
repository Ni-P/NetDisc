using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetDisc
{
    class NetworkTools
    {
        public NetworkTools()
        {

        }

        public PingReply SendPing(object target, int timeout, PingOptions options)
        {
            Ping ping = new Ping();

            string data = "one ping Vasilyi!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            PingReply reply = ping.Send(target.ToString(), timeout, buffer, options);
            return reply;
        }

        
  

        public NetworkInterface GetInterface()
        {
            IPInterfaceProperties properties;
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                if (adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    if (adapter.OperationalStatus == OperationalStatus.Up)
                    {
                        properties = adapter.GetIPProperties();
                        Console.WriteLine("selected " + adapter.Name);
                        Console.WriteLine("Desciprtion: " + adapter.Description);
                        Console.WriteLine("IP4 " + ShowIPAddresses(adapter.NetworkInterfaceType));
                        return adapter;
                    }
                }

            }
            return null;
        }

        public string getIPv4Address(NetworkInterface networkInterface)
        {
            return ShowIPAddresses(networkInterface.NetworkInterfaceType);
        }

        public string getIPv6Address(NetworkInterface networkInterface)
        {
            return getIpv6Address(networkInterface.NetworkInterfaceType);
        }

        private string getIpv6Address(NetworkInterfaceType networkIftype)
        {

            string[] ip6arr = GetAllLocalIPv6(networkIftype);

            return ip6arr.FirstOrDefault<string>();
        }

        public string getMAC(NetworkInterface networkInterface)
        {
            return networkInterface.GetPhysicalAddress().ToString();
        }

        private string ShowIPAddresses(NetworkInterfaceType networkIftype)
        {

            string[] ip4arr = GetAllLocalIPv4(networkIftype);

            return ip4arr.FirstOrDefault<string>();
        }

        private string[] GetAllLocalIPv4(NetworkInterfaceType _type)
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


        private string[] GetAllLocalIPv6(NetworkInterfaceType _type)
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
    }
}