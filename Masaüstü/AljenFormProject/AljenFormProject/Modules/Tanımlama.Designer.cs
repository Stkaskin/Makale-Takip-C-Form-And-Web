
namespace AljenFormProject.Modules
{
    partial class Tanımlama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Tad = new System.Windows.Forms.TextBox();
            this.Cyetki = new System.Windows.Forms.ComboBox();
            this.Tmail = new System.Windows.Forms.TextBox();
            this.Ttel = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Soyadtxt = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lid = new System.Windows.Forms.Label();
            this.Tid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 15.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.SeaShell;
            this.button1.Location = new System.Drawing.Point(12, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ekle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tad
            // 
            this.Tad.Location = new System.Drawing.Point(62, 37);
            this.Tad.Name = "Tad";
            this.Tad.Size = new System.Drawing.Size(131, 22);
            this.Tad.TabIndex = 1;
            this.Tad.Text = "ad";
            // 
            // Cyetki
            // 
            this.Cyetki.FormattingEnabled = true;
            this.Cyetki.Items.AddRange(new object[] {
            "Yazar",
            "Alan Editörü",
            "Hakem"});
            this.Cyetki.Location = new System.Drawing.Point(64, 177);
            this.Cyetki.Name = "Cyetki";
            this.Cyetki.Size = new System.Drawing.Size(131, 24);
            this.Cyetki.TabIndex = 2;
            this.Cyetki.Text = "yetki";
            // 
            // Tmail
            // 
            this.Tmail.Location = new System.Drawing.Point(64, 100);
            this.Tmail.Name = "Tmail";
            this.Tmail.Size = new System.Drawing.Size(131, 22);
            this.Tmail.TabIndex = 1;
            this.Tmail.Text = "mail";
            // 
            // Ttel
            // 
            this.Ttel.Location = new System.Drawing.Point(64, 137);
            this.Ttel.Name = "Ttel";
            this.Ttel.Size = new System.Drawing.Size(131, 22);
            this.Ttel.TabIndex = 1;
            this.Ttel.Text = "tel";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Peru;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 15.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.AliceBlue;
            this.button2.Location = new System.Drawing.Point(136, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 35);
            this.button2.TabIndex = 0;
            this.button2.Text = "Düzenle";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Firebrick;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(71, 315);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 35);
            this.button3.TabIndex = 0;
            this.button3.Text = "Sil";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(272, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(616, 434);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.Soyadtxt);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Lid);
            this.panel1.Controls.Add(this.Tid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Tad);
            this.panel1.Controls.Add(this.Tmail);
            this.panel1.Controls.Add(this.Ttel);
            this.panel1.Controls.Add(this.Cyetki);
            this.panel1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.ForeColor = System.Drawing.Color.DarkBlue;
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 253);
            this.panel1.TabIndex = 4;
            // 
            // Soyadtxt
            // 
            this.Soyadtxt.AutoSize = true;
            this.Soyadtxt.Location = new System.Drawing.Point(12, 71);
            this.Soyadtxt.Name = "Soyadtxt";
            this.Soyadtxt.Size = new System.Drawing.Size(40, 16);
            this.Soyadtxt.TabIndex = 5;
            this.Soyadtxt.Text = "Soyad";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "soyad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Yetki";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mail";
            // 
            // Lid
            // 
            this.Lid.AutoSize = true;
            this.Lid.Location = new System.Drawing.Point(12, 9);
            this.Lid.Name = "Lid";
            this.Lid.Size = new System.Drawing.Size(19, 16);
            this.Lid.TabIndex = 3;
            this.Lid.Text = "ID";
            // 
            // Tid
            // 
            this.Tid.Location = new System.Drawing.Point(62, 6);
            this.Tid.Name = "Tid";
            this.Tid.ReadOnly = true;
            this.Tid.Size = new System.Drawing.Size(131, 22);
            this.Tid.TabIndex = 1;
            this.Tid.Text = "-1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ad";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.ForestGreen;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(222, 440);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "HEPSİ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Fuchsia;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(330, 440);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 35);
            this.button5.TabIndex = 6;
            this.button5.Text = "ALAN EDİTÖRLERİ";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Gray;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(484, 440);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(123, 35);
            this.button6.TabIndex = 7;
            this.button6.Text = "YAZARLAR";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Green;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(613, 440);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(123, 35);
            this.button7.TabIndex = 8;
            this.button7.Text = "HAKEMLER";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(742, 440);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // Tanımlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(900, 484);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Tanımlama";
            this.Text = "Tanımlama";
            this.Load += new System.EventHandler(this.Tanımlama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Tad;
        private System.Windows.Forms.ComboBox Cyetki;
        private System.Windows.Forms.TextBox Tmail;
        private System.Windows.Forms.TextBox Ttel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Soyadtxt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Lid;
        private System.Windows.Forms.TextBox Tid;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}