
namespace CShark
{
    class Recorder
    {
        //TO:DO - Switch to dictionary so we can count the occurances of each

        /// <summary>
        /// Maintain list of observed source IP addresses
        /// </summary>
        public HashSet<string> SourceIPAddresses = new();

        /// <summary>
        /// Maintain list of observed destination source IP addresses
        /// </summary>
        public HashSet<string> DestinationIPAddresses = new();

        /// <summary>
        /// Maintain list of observed protocols
        /// </summary>
        public HashSet<int> Protocols = new();

        public void Record(string srcIp, string dstIp, int protocol)
        {
            this.SourceIPAddresses.Add(srcIp);
            this.DestinationIPAddresses.Add(dstIp);
            this.Protocols.Add(protocol);
            return;
        }
    }
}
