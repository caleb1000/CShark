
using System.ComponentModel;
namespace CShark
{
    class Packet
    {
        public UInt64 index { get; set; }
        public DateTime Time { get; set; }
        public string SrcIpAddress { get; set; }
        public string DstIpAddress { get; set; }
        public string Protocol { get; set; }
        public string IpHeader { get; set; }
        public string TransportHeader { get; set; }
    }
}
