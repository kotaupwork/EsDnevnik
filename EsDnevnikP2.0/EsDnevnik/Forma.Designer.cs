﻿
namespace EsDnevnik
{
    partial class Forma
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
            this.dgv_templejt = new System.Windows.Forms.DataGridView();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Menjaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Dodaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Predmet = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Razred = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Smer = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_templejt)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_templejt
            // 
            this.dgv_templejt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_templejt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Obrisi,
            this.Menjaj,
            this.Dodaj,
            this.IDD,
            this.Predmet,
            this.Razred,
            this.Smer});
            this.dgv_templejt.Location = new System.Drawing.Point(26, 64);
            this.dgv_templejt.Name = "dgv_templejt";
            this.dgv_templejt.RowHeadersWidth = 51;
            this.dgv_templejt.Size = new System.Drawing.Size(929, 373);
            this.dgv_templejt.TabIndex = 0;
            this.dgv_templejt.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgv_templejt.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // Obrisi
            // 
            this.Obrisi.HeaderText = "Obrisi";
            this.Obrisi.MinimumWidth = 6;
            this.Obrisi.Name = "Obrisi";
            this.Obrisi.Text = "Obrisi";
            this.Obrisi.UseColumnTextForButtonValue = true;
            this.Obrisi.Width = 125;
            // 
            // Menjaj
            // 
            this.Menjaj.HeaderText = "Menjaj";
            this.Menjaj.MinimumWidth = 6;
            this.Menjaj.Name = "Menjaj";
            this.Menjaj.Text = "Menjaj";
            this.Menjaj.UseColumnTextForButtonValue = true;
            this.Menjaj.Width = 125;
            // 
            // Dodaj
            // 
            this.Dodaj.HeaderText = "Dodaj";
            this.Dodaj.MinimumWidth = 6;
            this.Dodaj.Name = "Dodaj";
            this.Dodaj.Text = "Dodaj";
            this.Dodaj.UseColumnTextForButtonValue = true;
            this.Dodaj.Width = 125;
            // 
            // IDD
            // 
            this.IDD.HeaderText = "ID";
            this.IDD.MinimumWidth = 6;
            this.IDD.Name = "IDD";
            this.IDD.ReadOnly = true;
            this.IDD.Width = 125;
            // 
            // Predmet
            // 
            this.Predmet.HeaderText = "Predmet";
            this.Predmet.Items.AddRange(new object[] {
            "Baze podataka 2",
            "Programiranje",
            "Srpski jezik",
            "Matematika",
            "Paradigme",
            "Engleski jezik",
            "Fizika",
            "Web programiranje",
            "Fizicko vaspitanje"});
            this.Predmet.MinimumWidth = 6;
            this.Predmet.Name = "Predmet";
            this.Predmet.Width = 125;
            // 
            // Razred
            // 
            this.Razred.HeaderText = "Razred";
            this.Razred.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.Razred.MinimumWidth = 6;
            this.Razred.Name = "Razred";
            this.Razred.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Razred.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Razred.Width = 125;
            // 
            // Smer
            // 
            this.Smer.HeaderText = "Smer";
            this.Smer.Items.AddRange(new object[] {
            "Prirodni",
            "Drustveni",
            "Informaticki",
            "Jezicki",
            "Matematicki"});
            this.Smer.MinimumWidth = 6;
            this.Smer.Name = "Smer";
            this.Smer.Width = 125;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Elephant", 9F);
            this.textBox1.Location = new System.Drawing.Point(35, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 23);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Elephant", 9F);
            this.textBox2.Location = new System.Drawing.Point(190, 32);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 23);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Elephant", 9F);
            this.textBox3.Location = new System.Drawing.Point(347, 32);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(142, 23);
            this.textBox3.TabIndex = 3;
            this.textBox3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Elephant", 12F);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Elephant", 12F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(186, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tekst";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Elephant", 12F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(343, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Razred";
            this.label3.Visible = false;
            // 
            // Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(974, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgv_templejt);
            this.MaximumSize = new System.Drawing.Size(990, 500);
            this.MinimumSize = new System.Drawing.Size(990, 500);
            this.Name = "Forma";
            this.ShowIcon = false;
            this.Text = "Forma";
            this.Load += new System.EventHandler(this.Skolska_Godina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_templejt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_templejt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
        private System.Windows.Forms.DataGridViewButtonColumn Menjaj;
        private System.Windows.Forms.DataGridViewButtonColumn Dodaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDD;
        private System.Windows.Forms.DataGridViewComboBoxColumn Predmet;
        private System.Windows.Forms.DataGridViewComboBoxColumn Razred;
        private System.Windows.Forms.DataGridViewComboBoxColumn Smer;
    }
}