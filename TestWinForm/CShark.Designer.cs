namespace CShark
{
    partial class CShark
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CShark));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            richTextBox5 = new RichTextBox();
            richTextBox6 = new RichTextBox();
            button4 = new Button();
            label4 = new Label();
            richTextBox7 = new RichTextBox();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 182);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1828, 825);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(725, 24);
            button1.Name = "button1";
            button1.Size = new Size(391, 44);
            button1.TabIndex = 1;
            button1.Text = "Scan IP 192.168.1.6";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(725, 91);
            button2.Name = "button2";
            button2.Size = new Size(178, 49);
            button2.TabIndex = 2;
            button2.Text = "Stop Scan";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.AliceBlue;
            richTextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(934, 91);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(182, 49);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(1161, 23);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(217, 44);
            richTextBox2.TabIndex = 5;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(1161, 91);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(217, 49);
            richTextBox3.TabIndex = 6;
            richTextBox3.Text = "";
            richTextBox3.TextChanged += richTextBox3_TextChanged;
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(1425, 24);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(217, 44);
            richTextBox4.TabIndex = 7;
            richTextBox4.Text = "";
            richTextBox4.TextChanged += richTextBox4_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1425, 7);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 8;
            label1.Text = "Protocol Filter";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1161, 5);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 9;
            label2.Text = "Source IP Filter";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1161, 74);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 10;
            label3.Text = "Destination IP Filter";
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(1425, 82);
            button3.Name = "button3";
            button3.Size = new Size(217, 58);
            button3.TabIndex = 11;
            button3.Text = "Apply Filter";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(1778, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 84);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Stencil", 26.25F, FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.SteelBlue;
            label5.Location = new Point(1725, 6);
            label5.Name = "label5";
            label5.Size = new Size(176, 42);
            label5.TabIndex = 14;
            label5.Text = "C#Shark";
            label5.Click += label5_Click;
            // 
            // richTextBox5
            // 
            richTextBox5.BackColor = Color.AliceBlue;
            richTextBox5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox5.Location = new Point(37, 78);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.ReadOnly = true;
            richTextBox5.Size = new Size(391, 81);
            richTextBox5.TabIndex = 15;
            richTextBox5.Text = "";
            richTextBox5.TextChanged += richTextBox5_TextChanged;
            // 
            // richTextBox6
            // 
            richTextBox6.Location = new Point(37, 28);
            richTextBox6.Name = "richTextBox6";
            richTextBox6.Size = new Size(183, 44);
            richTextBox6.TabIndex = 16;
            richTextBox6.Text = "";
            richTextBox6.TextChanged += richTextBox6_TextChanged;
            // 
            // button4
            // 
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(237, 28);
            button4.Name = "button4";
            button4.Size = new Size(191, 44);
            button4.TabIndex = 17;
            button4.Text = "Set Network Interface";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 7);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 18;
            label4.Text = "Enter Network Interface";
            label4.Click += label4_Click;
            // 
            // richTextBox7
            // 
            richTextBox7.BackColor = Color.AliceBlue;
            richTextBox7.Location = new Point(450, 23);
            richTextBox7.Name = "richTextBox7";
            richTextBox7.ReadOnly = true;
            richTextBox7.Size = new Size(249, 131);
            richTextBox7.TabIndex = 19;
            richTextBox7.Text = "";
            richTextBox7.TextChanged += richTextBox7_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(450, 5);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 20;
            label6.Text = "Observed";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(934, 74);
            label7.Name = "label7";
            label7.Size = new Size(85, 15);
            label7.TabIndex = 21;
            label7.Text = "Capture Count";
            // 
            // CShark
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(richTextBox7);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(richTextBox6);
            Controls.Add(richTextBox5);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlText;
            Name = "CShark";
            Text = "CShark";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button3;
        private PictureBox pictureBox1;
        private Label label5;
        private RichTextBox richTextBox5;
        private RichTextBox richTextBox6;
        private Button button4;
        private Label label4;
        private RichTextBox richTextBox7;
        private Label label6;
        private Label label7;
    }
}