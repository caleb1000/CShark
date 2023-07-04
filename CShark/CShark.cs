using System.ComponentModel;
using PagedList;
using System.Net;
using System.Reflection;

namespace CShark
{
    public partial class CShark : Form
    {
        /// <summary>
        /// Class used to open raw socket and store packets
        /// </summary>
        Sniffer sniffer = new();

        /// <summary>
        /// Class used to set options for filtering packets on
        /// </summary>
        Filter filter = new();

        /// <summary>
        /// Timer used to determine how often the packet buffer is updated
        /// </summary>
        System.Windows.Forms.Timer Timer = new();

        /// <summary>
        /// After a run this list is used to hold the filtered packets
        /// </summary>
        BindingList<Packet> packetsFiltered = new();

        /// <summary>
        /// Current Network Interface selected
        /// </summary>
        string CurNetworkInterface;

        /// <summary>
        /// List of Network Intefaces the user can select from
        /// </summary>
        List<string> NetworkInterfaces = new List<string>();

        /*
         * Checkbox Bools
         */
        bool autoScroll = true;
        bool colorRows = true;
        bool transportVisible = true;
        bool ipVisible = true;
        bool protocolVisible = true;
        bool asciiVisible = true;
        bool timeVisible = true;
        bool srcVisible = true;
        bool dstVisible = true;

        /// <summary>
        /// Current page number in packet list
        /// </summary>
        int pageNumber = 1;

        /// <summary>
        /// Page Size
        /// </summary>
        int pageSize = 100;


        bool dataSourceFilter = false;

        bool scrollSubscribed = false;

        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            // Check if the user is scrolling vertically and nearing the end/start
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {

                // Check if the last displayed row is near the start
                if (pageNumber > 1 && e.NewValue < 1 && e.NewValue < e.OldValue)
                {
                    pageNumber--;
                    dataGridView1.DataSource = null;
                    IPagedList<Packet> pagedList;
                    if (dataSourceFilter)
                    {
                        pagedList = this.packetsFiltered.OrderBy(b => b.index).ToPagedList(pageNumber, pageSize);
                    }
                    else
                    {
                        pagedList = this.sniffer.Packets.OrderBy(b => b.index).ToPagedList(pageNumber, pageSize);
                    }

                    var listBinding = new BindingList<Packet>(pagedList.ToList());
                    Packet p = new();
                    p.SrcIpAddress = "* * * * * * * * * * * * * * * *";
                    p.DstIpAddress = "* * * * * * * * * * * * * * * *";
                    p.TransportHeader = "* * * * * * * * * * * * * * * *";
                    p.Ascii = "* * * * * * * * * * * * * * * *";
                    p.IpHeader = "* * * * KEEP SCROLLING TO LOADING MORE PACKETS * * * * * * * * * * * *";
                    p.Protocol = "* * * * * * * * * * * * * * * *";
                    listBinding.Add(p);
                    listBinding.Add(p);
                    listBinding.Add(p);
                    foreach (Packet packet in pagedList.ToList())
                    {
                        listBinding.Add(packet);
                    }
                    listBinding.Add(p);
                    listBinding.Add(p);
                    listBinding.Add(p);


                    dataGridView1.DataSource = listBinding;
                    dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                    dataGridView1.FirstDisplayedScrollingRowIndex = 70;

                }
                // Check if the last displayed row is near the end
                else if (e.NewValue > 70 && pageNumber * pageSize < this.sniffer.Packets.Count)
                {
                    if (dataSourceFilter && pageNumber * pageSize > this.packetsFiltered.Count)
                    {
                        //if we are in filter mode we need to make the check for that buffer instead
                        return;
                    }
                    pageNumber++;
                    dataGridView1.DataSource = null;
                    IPagedList<Packet> pagedList;
                    if (dataSourceFilter)
                    {
                        pagedList = this.packetsFiltered.OrderBy(b => b.index).ToPagedList(pageNumber, pageSize);
                    }
                    else
                    {
                        pagedList = this.sniffer.Packets.OrderBy(b => b.index).ToPagedList(pageNumber, pageSize);
                    }

                    BindingList<Packet> listBinding = new();
                    //TO:DO - this is a weird solution to allow scrolling, find a better way
                    Packet p = new();
                    p.SrcIpAddress = "* * * * * * * * * * * * * * * *";
                    p.DstIpAddress = "* * * * * * * * * * * * * * * *";
                    p.TransportHeader = "* * * * * * * * * * * * * * * *";
                    p.Ascii = "* * * * * * * * * * * * * * * *";
                    p.IpHeader = "* * * * KEEP SCROLLING TO LOADING MORE PACKETS * * * * * * * * * * * *";
                    p.Protocol = "* * * * * * * * * * * * * * * *";
                    listBinding.Add(p);
                    listBinding.Add(p);
                    listBinding.Add(p);
                    int packetCount = 0;
                    foreach (Packet packet in pagedList.ToList())
                    {
                        packetCount++;
                        listBinding.Add(packet);
                    }
                    for (int x = 0; x < this.pageSize - packetCount; x++)
                    {
                        //if we attempt to scroll to fast we need to fill page with empty values so we don't lose the scroll bar
                        Packet empty = new();
                        listBinding.Add(empty);
                    }
                    if (packetCount == this.pageSize)
                    {
                        listBinding.Add(p);
                        listBinding.Add(p);
                        listBinding.Add(p);
                    }
                    dataGridView1.DataSource = listBinding;
                    dataGridView1.FirstDisplayedScrollingRowIndex = 1;

                }
                this.dataGridView1.Columns["Time"].Visible = timeVisible;
                this.dataGridView1.Columns["SrcIpAddress"].Visible = srcVisible;
                this.dataGridView1.Columns["DstIpAddress"].Visible = dstVisible;
                this.dataGridView1.Columns["Protocol"].Visible = protocolVisible;
                this.dataGridView1.Columns["IpHeader"].Visible = ipVisible;
                this.dataGridView1.Columns["TransportHeader"].Visible = transportVisible;
                this.dataGridView1.Columns["Ascii"].Visible = asciiVisible;
            }
        }


        public CShark()
        {
            /*
             * Set up Icon and maximize window
             */
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);

            InitializeComponent();

            /*
             * Add network interfaces to drop-down menu and their associated IP Addresses to a list
             */
            this.sniffer.NetworkInterfaces();
            foreach (string name in this.sniffer.interfaceNames)
            {
                //Add Name to drop-down menu
                this.comboBox1.Items.Add(name);
            }
            foreach (string ip in this.sniffer.ipAddresses)
            {
                //Add IP to list
                this.NetworkInterfaces.Add(ip);
            }
            if (!this.NetworkInterfaces.Contains("127.0.0.1"))
            {
                this.comboBox1.Items.Add("Localhost Loopback");
                this.NetworkInterfaces.Add("127.0.0.1");
            }
            this.comboBox1.SelectedIndex = 1;
            this.CurNetworkInterface = this.NetworkInterfaces.ElementAt(this.comboBox1.SelectedIndex);
            this.button1.Text = "Scan IP: " + this.CurNetworkInterface;
            this.button2.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * DataGridView settings
             */
            this.dataGridView1.ShowCellToolTips = false;
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            this.dataGridView1, new object[] { true });
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            this.dataGridView1.ScrollBars = ScrollBars.Both;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.Scroll += DataGridView_Scroll;
        }


        /// <summary>
        /// Paint background as linear gradient
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Create a linear gradient brush
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                ClientRectangle, Color.AliceBlue, Color.DeepSkyBlue,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                // Fill the background with the gradient brush
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }


        /// <summary>
        /// Updates packet buffer with new entries ever .1 seconds
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            //If autoScroll is enabled re-render the page to the current last page
            if (autoScroll)
            {
                int horzScroll = dataGridView1.HorizontalScrollingOffset;
                int lastPage = (int)Math.Ceiling((decimal)this.sniffer.Packets.Count() / (decimal)pageSize);
                if (lastPage == 0)
                {
                    lastPage = 1;
                }
                pageNumber = lastPage;
                var pagedList = this.sniffer.Packets.OrderBy(b => b.index).ToPagedList(lastPage, pageSize);
                var listBinding = new BindingList<Packet>(pagedList.ToList());
                int preBufferCount = listBinding.Count;
                for (int x = preBufferCount; x < 30; x++)
                {
                    //if we attempt to scroll to fast we need to fill page with empty values so we don't lose the scroll bar
                    Packet empty = new();
                    listBinding.Add(empty);
                }
                this.dataGridView1.DataSource = listBinding;

                /*
                 * Make sure to restore settings after re-rendering page
                 */
                this.dataGridView1.HorizontalScrollingOffset = horzScroll;
                this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.RowCount - 1;
                this.dataGridView1.Columns["Time"].Visible = timeVisible;
                this.dataGridView1.Columns["SrcIpAddress"].Visible = srcVisible;
                this.dataGridView1.Columns["DstIpAddress"].Visible = dstVisible;
                this.dataGridView1.Columns["Protocol"].Visible = protocolVisible;
                this.dataGridView1.Columns["IpHeader"].Visible = ipVisible;
                this.dataGridView1.Columns["TransportHeader"].Visible = transportVisible;
                this.dataGridView1.Columns["Ascii"].Visible = asciiVisible;
            }
            //re-render dataGridView if we are not displaying enough entries to display a page of packets
            else if (this.dataGridView1.RowCount - 1 < pageSize)
            {
                int vertScroll = dataGridView1.FirstDisplayedScrollingRowIndex;
                int horzScroll = dataGridView1.HorizontalScrollingOffset;
                this.dataGridView1.DataSource = null;
                var pagedList = this.sniffer.Packets.OrderBy(b => b.index).ToPagedList(pageNumber, pageSize);
                var listBinding = new BindingList<Packet>(pagedList.ToList());
                this.dataGridView1.DataSource = listBinding;

                /*
                 * Make sure to restore settings after re-rendering page
                 */
                this.dataGridView1.FirstDisplayedScrollingRowIndex = vertScroll;
                this.dataGridView1.HorizontalScrollingOffset = horzScroll;
                this.dataGridView1.Columns["Time"].Visible = timeVisible;
                this.dataGridView1.Columns["SrcIpAddress"].Visible = srcVisible;
                this.dataGridView1.Columns["DstIpAddress"].Visible = dstVisible;
                this.dataGridView1.Columns["Protocol"].Visible = protocolVisible;
                this.dataGridView1.Columns["IpHeader"].Visible = ipVisible;
                this.dataGridView1.Columns["TransportHeader"].Visible = transportVisible;
                this.dataGridView1.Columns["Ascii"].Visible = asciiVisible;
            }
            this.richTextBox1.Text = "Packets Captured: " + this.sniffer.Packets.Count.ToString();

        }


        /// <summary>
        /// Start network scan
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            SetFilter();
            this.dataSourceFilter = false;
            this.pageNumber = 1;
            this.button2.Enabled = true;
            this.comboBox1.Enabled = false;
            this.button3.Enabled = false;
            this.button1.Enabled = false;
            if (scrollSubscribed == false)
            {
                //     this.dataGridView1.Scroll += DataGridView_Scroll;
                scrollSubscribed = true;
            }

            this.dataGridView1.Refresh();
            this.richTextBox1.Text = "Packets Captured: 0";
            this.richTextBox7.Text = string.Empty;
            this.sniffer = new Sniffer();
            this.sniffer.SetFilter(this.filter);
            this.sniffer.SelectedInterface = this.CurNetworkInterface;
            int result = sniffer.Run();
            if (result != 0)
            {
                this.richTextBox5.Text += "Error: Failed to bind to Network Interface " + this.CurNetworkInterface + " \n";
                return;
            }
            else
            {
                this.richTextBox5.Text += "Info: Successfully binded to Network Interface " + this.CurNetworkInterface + " \n";
            }

            //While listBinding will not have any entries, this refreshes the dataGridView1 in the case autoScroll is turned off
            var pagedList = this.sniffer.Packets.OrderBy(b => b.index).ToPagedList(pageNumber, pageSize);
            var listBinding = new BindingList<Packet>(pagedList.ToList());
            this.dataGridView1.DataSource = listBinding;

            // .1 seconds, could be changed and is somewhat randomly picked
            this.Timer.Interval = (100);
            this.Timer.Tick += new EventHandler(Timer_Tick);
            this.Timer.Start();
        }


        /// <summary>
        /// End network scan and report observed ip addresses and protocols
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.comboBox1.Enabled = true;
            this.button3.Enabled = true;
            this.button1.Enabled = true;
            this.sniffer.CloseSocket();


            this.richTextBox7.Text += "Source IP Addresses Observed:\n";
            this.richTextBox7.Text += "------------------------------------------\n";
            foreach (var src in this.sniffer.recorder.SourceIPAddresses)
            {
                this.richTextBox7.Text += src + "\n";
            }
            this.richTextBox7.Text += "\nDestination IP Addresses Observed:\n";
            this.richTextBox7.Text += "------------------------------------------\n";
            foreach (var dst in this.sniffer.recorder.DestinationIPAddresses)
            {
                this.richTextBox7.Text += dst + "\n";
            }
            this.richTextBox7.Text += "\nProtocols Observed:\n";
            this.richTextBox7.Text += "-------------------------\n";
            foreach (var pro in this.sniffer.recorder.Protocols)
            {
                this.richTextBox7.Text += pro.ToString() + "\n";
            }

            //Render the packet one more time to ensure we do not lose the scroll bar
            var pagedList = this.sniffer.Packets.OrderBy(b => b.index).ToPagedList(pageNumber, pageSize);
            var listBinding = new BindingList<Packet>(pagedList.ToList());
            for (int x = pagedList.Count; x < 35; x++)
            {
                //if we attempt to scroll to fast we need to fill page with empty values so we don't lose the scroll bar
                Packet empty = new();
                listBinding.Add(empty);
            }
            this.dataGridView1.DataSource = listBinding;
            this.richTextBox1.Text = "Packets Captured: " + this.sniffer.Packets.Count.ToString();
            this.dataGridView1.FirstDisplayedScrollingRowIndex = 1;
            this.Timer.Stop();

        }


        /// <summary>
        /// Color Cells in dataGridView1 based on protocol
        /// </summary>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && this.dataGridView1.Rows[e.RowIndex].DataBoundItem != null)
            {
                Packet packet = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Packet;

                if (packet != null && packet.Protocol == "TCP")
                {
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (packet != null && packet.Protocol == "UDP")
                {
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
                }
                else if (packet != null && packet.Protocol == "IGMP")
                {
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (packet != null && packet.Protocol == "* * * * * * * * * * * * * * * *")
                {
                    //This is for rendering buffer packets
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
                else
                {
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }

        }

        /// <summary>
        /// Set current filter based on filters set in textboxes
        /// </summary>
        private void SetFilter()
        {
            this.filter = new();
            this.richTextBox6.Text = "";
            /*
             * Parse Source IP Address Filters
             */
            string cleanSrc = this.richTextBox2.Text.Replace("\n", "").Replace(" ", "");
            string[] srcs = cleanSrc.Split(',');
            this.richTextBox6.Text += "Filter Settings: \n";
            foreach (var src in srcs)
            {
                int periodCount = src.Count(x => x == '.');
                IPAddress? temp;
                if (IPAddress.TryParse(src, out temp) && periodCount == 3)
                {
                    this.richTextBox6.Text += "    Source IP: " + src + "\n";
                    this.filter.SourceIPAddresses.Add(src);
                }
            }

            /*
             * Parse Destination IP Address Filters
             */
            string cleanDst = this.richTextBox3.Text.Replace("\n", "").Replace(" ", "");
            string[] dsts = cleanDst.Split(',');
            foreach (var dst in dsts)
            {
                int periodCount = dst.Count(x => x == '.');
                IPAddress? temp;
                if (IPAddress.TryParse(dst, out temp) && periodCount == 3)
                {
                    this.richTextBox6.Text += "    Destination IP: " + dst + "\n";
                    this.filter.DestinationIPAddresses.Add(dst);
                }
            }

            /*
             * Parse Protocol Filters
             */
            string cleanPro = this.richTextBox4.Text.Replace("\n", "").Replace(" ", "");
            string[] pros = cleanPro.Split(',');
            foreach (var pro in pros)
            {
                if (pro != string.Empty)
                {
                    //TO:DO - Add more protocols
                    switch (pro)
                    {
                        case "TCP":
                            this.filter.Protocols.Add(6);
                            this.richTextBox6.Text += "    Protocol: TCP\n";
                            break;
                        case "tcp":
                            this.filter.Protocols.Add(6);
                            this.richTextBox6.Text += "    Protocol: TCP\n";
                            break;
                        case "UDP":
                            this.filter.Protocols.Add(17);
                            this.richTextBox6.Text += "    Protocol: UDP\n";
                            break;
                        case "udp":
                            this.filter.Protocols.Add(17);
                            this.richTextBox6.Text += "    Protocol: UDP\n";
                            break;
                        case "IGMP":
                            this.filter.Protocols.Add(2);
                            this.richTextBox6.Text += "    Protocol: IGMP\n";
                            break;
                        case "igmp":
                            this.filter.Protocols.Add(2);
                            this.richTextBox6.Text += "    Protocol: IGMP\n";
                            break;
                        default:
                            /*
                             * Attempt to parse string as int
                             */
                            int proInt = 0;
                            bool isInt = Int32.TryParse(pro, out proInt);
                            if (isInt && proInt >= 0 && proInt <= 255)
                            {
                                this.richTextBox6.Text += "    Protocol: " + pro + "\n";
                                this.filter.Protocols.Add(proInt);
                            }
                            else
                            {
                                this.richTextBox6.Text += "    Invalid Protocol: " + pro + "\n";
                            }
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// Parse filter settings and apply new filter
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            dataSourceFilter = true;
            pageNumber = 1;

            if (scrollSubscribed == true)
            {
                //   this.dataGridView1.Scroll -= DataGridView_Scroll;
                scrollSubscribed = false;
            }

            SetFilter();
            this.dataGridView1.DataSource = null;
            if (this.button1.Enabled == true)
            {
                packetsFiltered.Clear();
                var ordredList = this.sniffer.Packets.OrderBy(p => p.index).ToList();

                //to:do fix this so we stop assigning things we don't need
                var listBinding = new BindingList<Packet>(ordredList);
                foreach (Packet packet in listBinding)
                {
                    int proInt = 0;
                    switch (packet.Protocol)
                    {
                        case "TCP":
                            proInt = 6;
                            break;
                        case "tcp":
                            proInt = 6;
                            break;
                        case "UDP":
                            proInt = 17;
                            break;
                        case "udp":
                            proInt = 17;
                            break;
                        case "IGMP":
                            proInt = 2;
                            break;
                        case "igmp":
                            proInt = 2;
                            break;
                        default:
                            Int32.TryParse(packet.Protocol, out proInt);
                            break;
                    }

                    if (this.filter.ContainedInFilter(packet.SrcIpAddress, packet.DstIpAddress, proInt))
                    {
                        this.packetsFiltered.Add(packet);
                    }
                }
                var pagedList = this.packetsFiltered.OrderBy(b => b.index).ToPagedList(pageNumber, pageSize);
                listBinding = new();
                Packet p = new();
                p.SrcIpAddress = "* * * * * * * * * * * * * * * *";
                p.DstIpAddress = "* * * * * * * * * * * * * * * *";
                p.TransportHeader = "* * * * * * * * * * * * * * * *";
                p.Ascii = "* * * * * * * * * * * * * * * *";
                p.IpHeader = "* * * * KEEP SCROLLING TO LOADING MORE PACKETS * * * * * * * * * * * *";
                p.Protocol = "* * * * * * * * * * * * * * * *";
                listBinding.Add(p);
                listBinding.Add(p);
                listBinding.Add(p);
                int packetCount = 0;
                foreach (Packet packet in pagedList.ToList())
                {
                    packetCount++;
                    listBinding.Add(packet);
                }
                for (int x = 0; x < this.pageSize - packetCount; x++)
                {
                    //if we attempt to scroll to fast we need to fill page with empty values so we don't lose the scroll bar
                    Packet empty = new();
                    listBinding.Add(empty);
                }
                listBinding.Add(p);
                listBinding.Add(p);
                listBinding.Add(p);


                this.dataGridView1.DataSource = listBinding;
                //TO:DO - Clean this up and make it a function to call
                this.dataGridView1.Columns["Time"].Visible = timeVisible;
                this.dataGridView1.Columns["SrcIpAddress"].Visible = srcVisible;
                this.dataGridView1.Columns["DstIpAddress"].Visible = dstVisible;
                this.dataGridView1.Columns["Protocol"].Visible = protocolVisible;
                this.dataGridView1.Columns["IpHeader"].Visible = ipVisible;
                this.dataGridView1.Columns["TransportHeader"].Visible = transportVisible;
                this.dataGridView1.Columns["Ascii"].Visible = asciiVisible;


            }

        }


        /// <summary>
        /// Debug Console
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                this.CurNetworkInterface = this.NetworkInterfaces.ElementAt(selectedIndex);
                this.button1.Text = "Scan IP: " + this.CurNetworkInterface;
            }
        }


        /// <summary>
        /// AutoSize Checkbox
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.autoScroll = !this.autoScroll;
        }


        /// <summary>
        /// ColorRows Checkbox
        /// </summary>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.colorRows = !this.colorRows;
            if (this.colorRows)
            {
                this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            }
            else
            {
                this.dataGridView1.CellFormatting -= dataGridView1_CellFormatting;
            }
        }


        /// <summary>
        /// Transport Layer Checkbox
        /// </summary>
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (this.transportVisible)
            {
                this.dataGridView1.Columns["TransportHeader"].Visible = false;
            }
            else
            {
                this.dataGridView1.Columns["TransportHeader"].Visible = true;
            }

            this.transportVisible = !this.transportVisible;
        }


        /// <summary>
        /// IP Layer Checkbox
        /// </summary>
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ipVisible)
            {
                this.dataGridView1.Columns["IpHeader"].Visible = false;
            }
            else
            {
                this.dataGridView1.Columns["IpHeader"].Visible = true;
            }

            this.ipVisible = !this.ipVisible;
        }


        /// <summary>
        /// Ascii Checkbox
        /// </summary>
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (asciiVisible)
            {
                this.dataGridView1.Columns["Ascii"].Visible = false;
            }
            else
            {
                this.dataGridView1.Columns["Ascii"].Visible = true;
            }

            this.asciiVisible = !this.asciiVisible;
        }


        /// <summary>
        /// Src IP Checkbox
        /// </summary>
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (this.srcVisible)
            {
                this.dataGridView1.Columns["SrcIpAddress"].Visible = false;
            }
            else
            {
                this.dataGridView1.Columns["SrcIpAddress"].Visible = true;
            }

            this.srcVisible = !this.srcVisible;
        }


        /// <summary>
        /// Dst IP Checkbox
        /// </summary>
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dstVisible)
            {
                this.dataGridView1.Columns["DstIpAddress"].Visible = false;
            }
            else
            {
                this.dataGridView1.Columns["DstIpAddress"].Visible = true;
            }

            this.dstVisible = !this.dstVisible;
        }


        /// <summary>
        /// Protocol Checkbox
        /// </summary>
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (this.protocolVisible)
            {
                this.dataGridView1.Columns["Protocol"].Visible = false;
            }
            else
            {
                this.dataGridView1.Columns["Protocol"].Visible = true;
            }

            this.protocolVisible = !this.protocolVisible;
        }


        /// <summary>
        /// Time Checkbox
        /// </summary>
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (this.timeVisible)
            {
                this.dataGridView1.Columns["Time"].Visible = false;
            }
            else
            {
                this.dataGridView1.Columns["Time"].Visible = true;
            }

            this.timeVisible = !this.timeVisible;
        }
    }
}