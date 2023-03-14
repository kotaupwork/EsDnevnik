namespace EsDnevnik
{
    partial class Odeljenje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Odeljenje));
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_razred = new System.Windows.Forms.TextBox();
            this.tb_indeks = new System.Windows.Forms.TextBox();
            this.cb_smer = new System.Windows.Forms.ComboBox();
            this.cb_staresina = new System.Windows.Forms.ComboBox();
            this.cb_godina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.b_first = new System.Windows.Forms.Button();
            this.c_back = new System.Windows.Forms.Button();
            this.b_dodaj = new System.Windows.Forms.Button();
            this.b_imeni = new System.Windows.Forms.Button();
            this.b_brisi = new System.Windows.Forms.Button();
            this.b_next = new System.Windows.Forms.Button();
            this.b_last = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_id
            // 
            this.tb_id.Enabled = false;
            this.tb_id.Font = new System.Drawing.Font("Elephant", 9F);
            this.tb_id.Location = new System.Drawing.Point(170, 31);
            this.tb_id.Margin = new System.Windows.Forms.Padding(2);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(143, 23);
            this.tb_id.TabIndex = 0;
            // 
            // tb_razred
            // 
            this.tb_razred.Font = new System.Drawing.Font("Elephant", 9F);
            this.tb_razred.Location = new System.Drawing.Point(170, 58);
            this.tb_razred.Margin = new System.Windows.Forms.Padding(2);
            this.tb_razred.Name = "tb_razred";
            this.tb_razred.Size = new System.Drawing.Size(143, 23);
            this.tb_razred.TabIndex = 1;
            // 
            // tb_indeks
            // 
            this.tb_indeks.Font = new System.Drawing.Font("Elephant", 9F);
            this.tb_indeks.Location = new System.Drawing.Point(170, 85);
            this.tb_indeks.Margin = new System.Windows.Forms.Padding(2);
            this.tb_indeks.Name = "tb_indeks";
            this.tb_indeks.Size = new System.Drawing.Size(143, 23);
            this.tb_indeks.TabIndex = 2;
            // 
            // cb_smer
            // 
            this.cb_smer.Font = new System.Drawing.Font("Elephant", 9F);
            this.cb_smer.FormattingEnabled = true;
            this.cb_smer.Items.AddRange(new object[] {
            "Prirodni",
            "Drustveni",
            "Informaticki"});
            this.cb_smer.Location = new System.Drawing.Point(170, 112);
            this.cb_smer.Margin = new System.Windows.Forms.Padding(2);
            this.cb_smer.Name = "cb_smer";
            this.cb_smer.Size = new System.Drawing.Size(143, 24);
            this.cb_smer.TabIndex = 3;
            // 
            // cb_staresina
            // 
            this.cb_staresina.Font = new System.Drawing.Font("Elephant", 9F);
            this.cb_staresina.FormattingEnabled = true;
            this.cb_staresina.Items.AddRange(new object[] {
            "Dragana Stojanovic",
            "Cedo Skoric",
            "Branko Vrhovac",
            "Natasa Majstrovic",
            "Nevena Vasilic-Lukic",
            "Marina Jovicic-Samardzija"});
            this.cb_staresina.Location = new System.Drawing.Point(170, 139);
            this.cb_staresina.Margin = new System.Windows.Forms.Padding(2);
            this.cb_staresina.Name = "cb_staresina";
            this.cb_staresina.Size = new System.Drawing.Size(143, 24);
            this.cb_staresina.TabIndex = 4;
            // 
            // cb_godina
            // 
            this.cb_godina.Font = new System.Drawing.Font("Elephant", 9F);
            this.cb_godina.FormattingEnabled = true;
            this.cb_godina.Items.AddRange(new object[] {
            "2019/20",
            "2020/21",
            "2021/22",
            "2022/23"});
            this.cb_godina.Location = new System.Drawing.Point(170, 167);
            this.cb_godina.Margin = new System.Windows.Forms.Padding(2);
            this.cb_godina.Name = "cb_godina";
            this.cb_godina.Size = new System.Drawing.Size(143, 24);
            this.cb_godina.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 12F);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(133, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Elephant", 12F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(97, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Razred";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Elephant", 12F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(101, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Indeks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Elephant", 12F);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(115, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Smer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Elephant", 12F);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(82, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Staresina";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Elephant", 12F);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(98, 166);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Godina";
            // 
            // b_first
            // 
            this.b_first.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_first.Font = new System.Drawing.Font("Elephant", 9F);
            this.b_first.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.b_first.Location = new System.Drawing.Point(11, 223);
            this.b_first.Margin = new System.Windows.Forms.Padding(2);
            this.b_first.Name = "b_first";
            this.b_first.Size = new System.Drawing.Size(56, 29);
            this.b_first.TabIndex = 12;
            this.b_first.Text = "<<";
            this.b_first.UseVisualStyleBackColor = true;
            this.b_first.Click += new System.EventHandler(this.button1_Click);
            // 
            // c_back
            // 
            this.c_back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.c_back.Font = new System.Drawing.Font("Elephant", 9F);
            this.c_back.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.c_back.Location = new System.Drawing.Point(71, 223);
            this.c_back.Margin = new System.Windows.Forms.Padding(2);
            this.c_back.Name = "c_back";
            this.c_back.Size = new System.Drawing.Size(56, 29);
            this.c_back.TabIndex = 13;
            this.c_back.Text = "<";
            this.c_back.UseVisualStyleBackColor = true;
            this.c_back.Click += new System.EventHandler(this.button2_Click);
            // 
            // b_dodaj
            // 
            this.b_dodaj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_dodaj.Font = new System.Drawing.Font("Elephant", 9F);
            this.b_dodaj.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.b_dodaj.Location = new System.Drawing.Point(131, 223);
            this.b_dodaj.Margin = new System.Windows.Forms.Padding(2);
            this.b_dodaj.Name = "b_dodaj";
            this.b_dodaj.Size = new System.Drawing.Size(62, 29);
            this.b_dodaj.TabIndex = 14;
            this.b_dodaj.Text = "Dodaj";
            this.b_dodaj.UseVisualStyleBackColor = true;
            this.b_dodaj.Click += new System.EventHandler(this.button3_Click);
            // 
            // b_imeni
            // 
            this.b_imeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_imeni.Font = new System.Drawing.Font("Elephant", 9F);
            this.b_imeni.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.b_imeni.Location = new System.Drawing.Point(197, 223);
            this.b_imeni.Margin = new System.Windows.Forms.Padding(2);
            this.b_imeni.Name = "b_imeni";
            this.b_imeni.Size = new System.Drawing.Size(81, 29);
            this.b_imeni.TabIndex = 15;
            this.b_imeni.Text = "Izmeni";
            this.b_imeni.UseVisualStyleBackColor = true;
            this.b_imeni.Click += new System.EventHandler(this.button4_Click);
            // 
            // b_brisi
            // 
            this.b_brisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_brisi.Font = new System.Drawing.Font("Elephant", 9F);
            this.b_brisi.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.b_brisi.Location = new System.Drawing.Point(282, 223);
            this.b_brisi.Margin = new System.Windows.Forms.Padding(2);
            this.b_brisi.Name = "b_brisi";
            this.b_brisi.Size = new System.Drawing.Size(58, 29);
            this.b_brisi.TabIndex = 16;
            this.b_brisi.Text = "Brisi";
            this.b_brisi.UseVisualStyleBackColor = true;
            this.b_brisi.Click += new System.EventHandler(this.button5_Click);
            // 
            // b_next
            // 
            this.b_next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_next.Font = new System.Drawing.Font("Elephant", 9F);
            this.b_next.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.b_next.Location = new System.Drawing.Point(344, 223);
            this.b_next.Margin = new System.Windows.Forms.Padding(2);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(56, 29);
            this.b_next.TabIndex = 17;
            this.b_next.Text = ">";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.button6_Click);
            // 
            // b_last
            // 
            this.b_last.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_last.Font = new System.Drawing.Font("Elephant", 9F);
            this.b_last.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.b_last.Location = new System.Drawing.Point(404, 223);
            this.b_last.Margin = new System.Windows.Forms.Padding(2);
            this.b_last.Name = "b_last";
            this.b_last.Size = new System.Drawing.Size(56, 29);
            this.b_last.TabIndex = 18;
            this.b_last.Text = ">>";
            this.b_last.UseVisualStyleBackColor = true;
            this.b_last.Click += new System.EventHandler(this.button7_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 19;
            this.label7.Visible = false;
            // 
            // Odeljenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(471, 270);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.b_last);
            this.Controls.Add(this.b_next);
            this.Controls.Add(this.b_brisi);
            this.Controls.Add(this.b_imeni);
            this.Controls.Add(this.b_dodaj);
            this.Controls.Add(this.c_back);
            this.Controls.Add(this.b_first);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_godina);
            this.Controls.Add(this.cb_staresina);
            this.Controls.Add(this.cb_smer);
            this.Controls.Add(this.tb_indeks);
            this.Controls.Add(this.tb_razred);
            this.Controls.Add(this.tb_id);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(487, 309);
            this.MinimumSize = new System.Drawing.Size(487, 309);
            this.Name = "Odeljenje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Odeljenje";
            this.Load += new System.EventHandler(this.Odeljenje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_razred;
        private System.Windows.Forms.TextBox tb_indeks;
        private System.Windows.Forms.ComboBox cb_smer;
        private System.Windows.Forms.ComboBox cb_staresina;
        private System.Windows.Forms.ComboBox cb_godina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button b_first;
        private System.Windows.Forms.Button c_back;
        private System.Windows.Forms.Button b_dodaj;
        private System.Windows.Forms.Button b_imeni;
        private System.Windows.Forms.Button b_brisi;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.Button b_last;
        private System.Windows.Forms.Label label7;
    }
}