
namespace CShark
{
    class Filter
    {
        /// <summary>
        /// List of source ip addresses to filter on
        /// </summary>
        public List<string> SourceIPAddresses = new();

        /// <summary>
        /// List of destination ip addresses to filter on
        /// </summary>
        public List<string> DestinationIPAddresses = new();

        /// <summary>
        /// List of protocols to filter on
        /// </summary>
        public List<int> Protocols = new();

        public bool ContainedInFilter(string srcIp, string dstIp, int protocol)
        {
            bool matchSrc = false;
            bool matchDst = false;
            bool matchPro = false;

            if (this.SourceIPAddresses.Count == 0)
            {
                matchSrc = true;
            }
            else
            {
                foreach (var ip in this.SourceIPAddresses)
                {
                    matchSrc |= (ip == srcIp);
                }
            }

            if (this.DestinationIPAddresses.Count == 0)
            {
                matchDst = true;
            }
            else
            {
                foreach (var ip in this.DestinationIPAddresses)
                {
                    matchDst |= (ip == dstIp);
                }
            }

            if (this.Protocols.Count == 0)
            {
                matchPro = true;
            }
            else
            {
                foreach (var pro in this.Protocols)
                {
                    matchPro |= (pro == protocol);
                }
            }

            bool result = matchSrc && matchDst && matchPro;

            return result;
        }

    }
}
