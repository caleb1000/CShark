using CShark;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

class Sniffer
{
    public const int Ipv4TotalLength = 2;
    public const int Ipv4TotalOffset = 2;
    public const int Ipv4ProtocolOffset = 9;
    public const int Ipv4ChecksumOffset = 10;
    public const int Ipv4ChecksumLength = 2;
    public const int Ipv4SrcAddOffset = 12;
    public const int Ipv4SrcAddLength = 4;
    public const int Ipv4DstAddOffset = 16;
    public const int Ipv4DstAddLength = 4;



    private Socket? rawSocket;
    public Filter filter = new();
    public Recorder recorder = new();
    public List<string> ipAddresses = new();
    public string SelectedInterface = string.Empty;
    UInt64 Index = 0;
    public ConcurrentBag<Packet> Packets = new();
    public CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    public void SetFilter(Filter filter)
    {
        this.filter = filter;
    }

    public void Run()
    {
        rawSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

        if (SelectedInterface == string.Empty)
        {
            Debug.WriteLine("Network Interface not selected, Run failed");
            return;
        }
        else
        {
            IPAddress selectedIp = IPAddress.Parse(SelectedInterface);
            try
            {
                rawSocket.Bind(new IPEndPoint(selectedIp, 0));
            }
            catch
            {
                Debug.WriteLine("Network Interface " + SelectedInterface + " failed to bind");
                return;
            }
        }

        /*
         * Enable the socket to receive all incoming packets
         */
        rawSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

        /* 
         * Specify the packet header includes the IP header
         */
        byte[] inValue = new byte[] { 1, 0, 0, 0 };
        byte[] outValue = new byte[] { 0, 0, 0, 0 };
        rawSocket.IOControl(IOControlCode.ReceiveAll, inValue, outValue);

        /*
         * Start receiving packets asynchronously
         */
        byte[] buffer = new byte[4096];

        rawSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnReceive, buffer);



        //rawSocket.Close();

    }
    public void CloseSocket()
    {
        cancellationTokenSource.Cancel();
        if (rawSocket != null)
        {
            rawSocket.Close();
            rawSocket = null;
        }
    }
    public void NetworkInterfaces()
    {
        int index = 0;
        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface adapter in adapters)
        {
            if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {

                foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ipAddresses.Add(ip.Address.ToString());
                        index++;
                    }
                }
            }
        }

    }

    private int ParseIp(int bytesRead, byte[] buffer)
    {
        if (bytesRead > 0 && buffer != null)
        {
            int IHL = (int)(buffer[0] & 0x0F);

            var fullPacket = buffer[0..bytesRead];
            string fullPacketHex = BitConverter.ToString(fullPacket);

            byte protocol = buffer[Ipv4ProtocolOffset];
            string protocolString;
            if (protocol == 6)
            {
                protocolString = "TCP";
            }
            else if (protocol == 17)
            {
                protocolString = "UDP";
            }
            else
            {
                protocolString = protocol.ToString();
            }

            UInt16 totalLengthInt = (UInt16)(buffer[Ipv4TotalOffset] << 8);
            totalLengthInt += (UInt16)(buffer[Ipv4TotalOffset + Ipv4TotalLength - 1]);

            var checksum = buffer[Ipv4ChecksumOffset..(Ipv4ChecksumOffset + Ipv4ChecksumLength)];
            string checksumHex = BitConverter.ToString(checksum);

            var ipHeader = buffer[0..(IHL * 4)];
            string ipHeaderHex = BitConverter.ToString(ipHeader);

            var src = buffer[Ipv4SrcAddOffset..(Ipv4SrcAddOffset + Ipv4SrcAddLength)];
            string srcString = string.Join(".", src.Select(b => b.ToString()));

            var dst = buffer[Ipv4DstAddOffset..(Ipv4DstAddOffset + Ipv4DstAddLength)];
            string dstString = string.Join(".", dst.Select(b => b.ToString()));

            var transportPacket = buffer[(IHL * 4)..bytesRead];
            string transportPacketHex = BitConverter.ToString(transportPacket);

            Packet packet = new Packet();
            packet.IpHeader = ipHeaderHex;
            packet.TransportHeader = transportPacketHex;
            packet.Protocol = protocolString;
            packet.SrcIpAddress = srcString;
            packet.DstIpAddress = dstString;
            packet.Time = DateTime.Now;
            packet.index = Index;

            if (filter != null && filter.ContainedInFilter(srcString, dstString, (int)protocol))
            {
                Index++;
                recorder.Record(srcString, dstString, (int)protocol);
                Packets.Add(packet);
            }

            return (int)protocol;
        }
        return -1;
    }

    private void OnReceive(IAsyncResult ar)
    {
        if (this.cancellationTokenSource.IsCancellationRequested)
        {
            return;
        }

        if (ar.AsyncState == null)
        {
            Console.WriteLine("Error, AysncState is null");
            return;
        }

        byte[] buffer = (byte[])ar.AsyncState;

        try
        {
            if (rawSocket != null)
            {
                int bytesRead = rawSocket.EndReceive(ar);

                int protocol = ParseIp(bytesRead, buffer);
                // Continue receiving packets asynchronously
                rawSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnReceive, buffer);
            }
            else
            {
                return;
            }
        }
        catch
        {
            Console.WriteLine($"Error or Socket closed");
        }
    }
}