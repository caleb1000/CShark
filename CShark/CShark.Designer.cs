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
            richTextBox7 = new RichTextBox();
            label6 = new Label();
            label7 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            richTextBox5 = new RichTextBox();
            label8 = new Label();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox10 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 198);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1856, 791);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(773, 23);
            button1.Name = "button1";
            button1.Size = new Size(391, 44);
            button1.TabIndex = 1;
            button1.Text = "Scan IP ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(773, 90);
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
            richTextBox1.Location = new Point(982, 90);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(182, 49);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(1209, 22);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(217, 44);
            richTextBox2.TabIndex = 5;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(1209, 90);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(217, 49);
            richTextBox3.TabIndex = 6;
            richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(1473, 23);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(217, 44);
            richTextBox4.TabIndex = 7;
            richTextBox4.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1473, 6);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 8;
            label1.Text = "Protocol Filter";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1209, 4);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 9;
            label2.Text = "Source IP Filter";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1209, 73);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 10;
            label3.Text = "Destination IP Filter";
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(1473, 81);
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
            pictureBox1.Location = new Point(1795, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 84);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.AliceBlue;
            label5.Font = new Font("Stencil", 26.25F, FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.SteelBlue;
            label5.Location = new Point(1725, 6);
            label5.Name = "label5";
            label5.Size = new Size(176, 42);
            label5.TabIndex = 14;
            label5.Text = "C#Shark";
            // 
            // richTextBox7
            // 
            richTextBox7.BackColor = Color.AliceBlue;
            richTextBox7.Location = new Point(513, 22);
            richTextBox7.Name = "richTextBox7";
            richTextBox7.ReadOnly = true;
            richTextBox7.Size = new Size(234, 154);
            richTextBox7.TabIndex = 19;
            richTextBox7.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(513, 6);
            label6.Name = "label6";
            label6.Size = new Size(212, 15);
            label6.TabIndex = 20;
            label6.Text = "Observed IP Addresses and Protocols";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(982, 73);
            label7.Name = "label7";
            label7.Size = new Size(87, 15);
            label7.TabIndex = 21;
            label7.Text = "Capture Count";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.AliceBlue;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.Location = new Point(12, 78);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(109, 19);
            checkBox1.TabIndex = 22;
            checkBox1.Text = "Auto Size Rows";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.AliceBlue;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.FlatStyle = FlatStyle.Flat;
            checkBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox2.Location = new Point(143, 78);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(85, 19);
            checkBox2.TabIndex = 23;
            checkBox2.Text = "Color Rows";
            checkBox2.UseVisualStyleBackColor = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.AliceBlue;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(252, 29);
            comboBox1.TabIndex = 24;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 4);
            label4.Name = "label4";
            label4.Size = new Size(198, 21);
            label4.TabIndex = 25;
            label4.Text = "Select Network Interface";
            // 
            // richTextBox5
            // 
            richTextBox5.BackColor = Color.AliceBlue;
            richTextBox5.Location = new Point(300, 22);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(207, 154);
            richTextBox5.TabIndex = 26;
            richTextBox5.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(300, 4);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 27;
            label8.Text = "Debug Console";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = Color.AliceBlue;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.FlatStyle = FlatStyle.Flat;
            checkBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox3.Location = new Point(12, 157);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(109, 19);
            checkBox3.TabIndex = 28;
            checkBox3.Text = "Transport Layer";
            checkBox3.UseVisualStyleBackColor = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.BackColor = Color.AliceBlue;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.FlatStyle = FlatStyle.Flat;
            checkBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox4.Location = new Point(143, 157);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(67, 19);
            checkBox4.TabIndex = 29;
            checkBox4.Text = "IP Layer";
            checkBox4.UseVisualStyleBackColor = false;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.BackColor = Color.AliceBlue;
            checkBox6.Checked = true;
            checkBox6.CheckState = CheckState.Checked;
            checkBox6.FlatStyle = FlatStyle.Flat;
            checkBox6.Location = new Point(229, 157);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(48, 19);
            checkBox6.TabIndex = 31;
            checkBox6.Text = "Ascii";
            checkBox6.UseVisualStyleBackColor = false;
            checkBox6.CheckedChanged += checkBox6_CheckedChanged;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.BackColor = Color.AliceBlue;
            checkBox7.Checked = true;
            checkBox7.CheckState = CheckState.Checked;
            checkBox7.FlatStyle = FlatStyle.Flat;
            checkBox7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox7.Location = new Point(12, 103);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(76, 19);
            checkBox7.TabIndex = 32;
            checkBox7.Text = "Source IP";
            checkBox7.UseVisualStyleBackColor = false;
            checkBox7.CheckedChanged += checkBox7_CheckedChanged;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.BackColor = Color.AliceBlue;
            checkBox8.Checked = true;
            checkBox8.CheckState = CheckState.Checked;
            checkBox8.FlatStyle = FlatStyle.Flat;
            checkBox8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox8.Location = new Point(12, 128);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(101, 19);
            checkBox8.TabIndex = 33;
            checkBox8.Text = "Destination IP";
            checkBox8.UseVisualStyleBackColor = false;
            checkBox8.CheckedChanged += checkBox8_CheckedChanged;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.BackColor = Color.AliceBlue;
            checkBox9.Checked = true;
            checkBox9.CheckState = CheckState.Checked;
            checkBox9.FlatStyle = FlatStyle.Flat;
            checkBox9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox9.Location = new Point(143, 128);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(70, 19);
            checkBox9.TabIndex = 34;
            checkBox9.Text = "Protocol";
            checkBox9.UseVisualStyleBackColor = false;
            checkBox9.CheckedChanged += checkBox9_CheckedChanged;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.BackColor = Color.AliceBlue;
            checkBox10.Checked = true;
            checkBox10.CheckState = CheckState.Checked;
            checkBox10.FlatStyle = FlatStyle.Flat;
            checkBox10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox10.Location = new Point(143, 103);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(51, 19);
            checkBox10.TabIndex = 35;
            checkBox10.Text = "Time";
            checkBox10.UseVisualStyleBackColor = false;
            checkBox10.CheckedChanged += checkBox10_CheckedChanged;
            // 
            // CShark
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1904, 1041);
            Controls.Add(checkBox10);
            Controls.Add(checkBox9);
            Controls.Add(checkBox8);
            Controls.Add(checkBox7);
            Controls.Add(checkBox6);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(label8);
            Controls.Add(richTextBox5);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(richTextBox7);
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
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
        private RichTextBox richTextBox7;
        private Label label6;
        private Label label7;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ComboBox comboBox1;
        private Label label4;
        private RichTextBox richTextBox5;
        private Label label8;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckBox checkBox10;
    }
}