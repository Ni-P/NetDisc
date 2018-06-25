using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public PingReply SendPing(object target, int timeout, PingOptions options, int bufferSize=32)
        {
            Ping ping = new Ping();

            string data = "one ping only!";
            //byte[] buffer = Encoding.ASCII.GetBytes(data);
            byte[] buffer = new byte[bufferSize];
            //for(int i=0; i < bufferSize; i++)
            //{
            //    char c = new Random().Next(256);
            //}
            new Random().NextBytes(buffer);

            try
            {
                PingReply reply = ping.Send(target.ToString(), timeout, buffer, options);
                return reply;

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
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
                        Console.WriteLine("Selected " + adapter.Name);
                        Console.WriteLine("Description: " + adapter.Description);
                        Console.WriteLine("IP4 " + ShowIPAddresses(adapter.NetworkInterfaceType));
                        return adapter;
                    }
                }

            }
            return null;
        }

        public IPAddress getIPv4Address(NetworkInterface networkInterface)
        {
            return ShowIPAddresses(networkInterface.NetworkInterfaceType);
        }

        public IPAddress getIPv6Address(NetworkInterface networkInterface)
        {
            return getIpv6Address(networkInterface.NetworkInterfaceType);
        }

        private IPAddress getIpv6Address(NetworkInterfaceType networkIftype)
        {

            IPAddress[] ip6arr = GetAllLocalIPv6(networkIftype);

            return ip6arr.FirstOrDefault<IPAddress>();
        }

        public string getMAC(NetworkInterface networkInterface)
        {

            return networkInterface.GetPhysicalAddress().ToString();
        }

        private IPAddress ShowIPAddresses(NetworkInterfaceType networkIftype)
        {

            IPAddress[] ip4arr = GetLocalIpStringArr(networkIftype);

            return ip4arr.FirstOrDefault<IPAddress>();
        }

        private IPAddress[] GetLocalIpStringArr(NetworkInterfaceType _type)
        {
            List<IPAddress> ipAddrList = new List<IPAddress>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddrList.Add(ip.Address);
                        }
                    }
                }
            }
            return ipAddrList.ToArray();
        }
        private IPAddress[] GetLocalIpArray(NetworkInterfaceType _type)
        {
            List<IPAddress> ipAddrList = new List<IPAddress>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddrList.Add(ip.Address);
                        }
                    }
                }
            }
            return ipAddrList.ToArray();
        }

        private IPAddress[] GetAllLocalIPv6(NetworkInterfaceType _type)
        {
            List<IPAddress> ipAddrList = new List<IPAddress>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            ipAddrList.Add(ip.Address);
                        }
                    }
                }
            }
            return ipAddrList.ToArray();
        }
    }
}