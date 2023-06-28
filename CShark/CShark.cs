using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace CShark
{
    public partial class CShark : Form
    {
        System.Windows.Forms.Timer MyTimer = new();
        Sniffer? sniffer = new();
        Filter filter = new();
        BindingList<Packet> packets = new();
        string CurNetworkInterface;
        int index = 0;
        bool running = false;
        bool autoSize = true;
        bool colorRows = true;
        public CShark()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);

            InitializeComponent();
            sniffer.NetworkInterfaces();
            richTextBox5.Text += "Network Interfaces:\n";
            richTextBox5.Text += "------------------------\n";
            foreach (string s in sniffer.ipAddresses)
            {
                richTextBox5.Text += s + "\n";
            }
            CurNetworkInterface = this.sniffer.ipAddresses.ElementAt(1);
            button1.Text = "Scan IP: " + CurNetworkInterface;
        }

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

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            int horizontalPosition = dataGridView1.FirstDisplayedScrollingColumnIndex;
            if (sniffer.Packets.Count > 0)
            {
                //dataGridView1.RowHeadersVisible = false;
                int scrollPosition = dataGridView1.FirstDisplayedScrollingRowIndex;
                int preSize = packets.Count;
                var orderedPackets = sniffer.Packets.OrderBy(p => p.index);
                int postSize = orderedPackets.Count();
                //TO:DO - make a better way of adding packets to bindinglist, maybe have a buffer of sorts
                for (int i = preSize; i < postSize; i++)
                {
                    index++;
                    packets.Add(orderedPackets.ElementAt(i));
                }
                richTextBox1.Text = "Packets Captured: " + index.ToString();
                //keep view at previous index unless you are looking at the top
                Debug.WriteLine("Scroll: " + scrollPosition);

                if (scrollPosition + dataGridView1.DisplayedRowCount(false) - 1 == preSize)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1; ;
                }
                else
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = scrollPosition;
                }
            }
            else
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
            //dataGridView1.RowHeadersVisible = true;
            dataGridView1.FirstDisplayedScrollingColumnIndex = horizontalPosition;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = this.packets;
            dataGridView1.Columns[0].HeaderText = "Index";
            dataGridView1.Columns[1].HeaderText = "Time";
            dataGridView1.Columns[2].HeaderText = "Source IP Address";
            dataGridView1.Columns[3].HeaderText = "Destination IP Address";
            dataGridView1.Columns[4].HeaderText = "Protocol";
            dataGridView1.Columns[5].HeaderText = "IP Header";
            dataGridView1.Columns[6].HeaderText = "Transport Header";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button3.Visible = false;
            this.packets.Clear();
            dataGridView1.Refresh();
            richTextBox1.Text = "Packets Captured: 0";
            richTextBox7.Text = string.Empty;
            if (!this.running)
            {
                this.running = true;
                this.sniffer.SetFilter(this.filter);
                this.sniffer.SelectedInterface = CurNetworkInterface;
                sniffer.Run();
                MyTimer.Interval = (100); // .1 seconds, could be changed and is somewhat randomly picked
                MyTimer.Tick += new EventHandler(MyTimer_Tick);
                MyTimer.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            button3.Visible = true;
            if (this.running)
            {
                index = 0;
                sniffer.CloseSocket();
                richTextBox7.Text += "Source IP Addresses Observed:\n";
                richTextBox7.Text += "------------------------------------------\n";
                foreach (var src in sniffer.recorder.SourceIPAddresses)
                {
                    richTextBox7.Text += src + "\n";
                }
                richTextBox7.Text += "\nDestination IP Addresses Observed:\n";
                richTextBox7.Text += "------------------------------------------\n";
                foreach (var dst in sniffer.recorder.DestinationIPAddresses)
                {
                    richTextBox7.Text += dst + "\n";
                }
                richTextBox7.Text += "\nProtocols Observed:\n";
                richTextBox7.Text += "-------------------------\n";
                foreach (var pro in sniffer.recorder.Protocols)
                {
                    richTextBox7.Text += pro.ToString() + "\n";
                }
                sniffer = new();
                filter = new();
                this.running = false;
                MyTimer.Stop();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem != null)
            {
                Packet packet = dataGridView1.Rows[e.RowIndex].DataBoundItem as Packet;

                if (packet != null && packet.Protocol == "TCP")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (packet != null && packet.Protocol == "UDP")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                filter = new();
                string cleanSrc = richTextBox2.Text.Replace("\n", "").Replace(" ", "");
                string[] srcs = cleanSrc.Split(',');

                foreach (var src in srcs)
                {

                    if (src != string.Empty)
                    {
                        Debug.WriteLine("Source IP: " + src);
                        filter.SourceIPAddresses.Add(src);
                    }

                }

                string cleanDst = richTextBox3.Text.Replace("\n", "").Replace(" ", "");
                string[] dsts = cleanDst.Split(',');

                foreach (var dst in dsts)
                {

                    if (dst != string.Empty)
                    {
                        Debug.WriteLine("Destination IP: " + dst);
                        filter.DestinationIPAddresses.Add(dst);
                    }
                }

                string cleanPro = richTextBox4.Text.Replace("\n", "").Replace(" ", "");
                string[] pros = cleanPro.Split(',');

                foreach (var pro in pros)
                {
                    if (pro != string.Empty)
                    {
                        int x = 0;
                        if (Int32.TryParse(pro, out x))
                        {
                            Debug.WriteLine("Protocol: " + pro);
                            filter.Protocols.Add(x);
                        }
                    }

                }
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                IPAddress? ipAddress;
                string cleanText = richTextBox6.Text.Replace("\n", "").Replace(" ", "");
                if (IPAddress.TryParse(cleanText, out ipAddress))
                {
                    button1.Text = "Scan IP: " + cleanText;
                    this.sniffer.SelectedInterface = cleanText;
                    CurNetworkInterface = cleanText;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            autoSize = !autoSize;
            if (autoSize)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            colorRows = !colorRows;
            if (colorRows)
            {
                dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            }
            else
            {
                dataGridView1.CellFormatting -= dataGridView1_CellFormatting;
            }
        }
    }
}