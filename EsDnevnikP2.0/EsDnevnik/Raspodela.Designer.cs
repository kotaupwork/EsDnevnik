namespace EsDnevnik
{
    partial class Raspodela
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
            this.dgv_raspodela = new System.Windows.Forms.DataGridView();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Menjaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Dodaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nastavnik = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Godina = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Predmet = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Odeljenje = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_raspodela)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_raspodela
            // 
            this.dgv_raspodela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_raspodela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Obrisi,
            this.Menjaj,
            this.Dodaj,
            this.id,
            this.Nastavnik,
            this.Godina,
            this.Predmet,
            this.Odeljenje});
            this.dgv_raspodela.Location = new System.Drawing.Point(26, 64);
            this.dgv_raspodela.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_raspodela.Name = "dgv_raspodela";
            this.dgv_raspodela.RowHeadersWidth = 51;
            this.dgv_raspodela.RowTemplate.Height = 24;
            this.dgv_raspodela.Size = new System.Drawing.Size(929, 373);
            this.dgv_raspodela.TabIndex = 0;
            this.dgv_raspodela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
            // 
            // Nastavnik
            // 
            this.Nastavnik.HeaderText = "Nastavnik";
            this.Nastavnik.MinimumWidth = 6;
            this.Nastavnik.Name = "Nastavnik";
            this.Nastavnik.Width = 125;
            // 
            // Godina
            // 
            this.Godina.HeaderText = "Godina";
            this.Godina.MinimumWidth = 6;
            this.Godina.Name = "Godina";
            this.Godina.Width = 125;
            // 
            // Predmet
            // 
            this.Predmet.HeaderText = "Predmet";
            this.Predmet.MinimumWidth = 6;
            this.Predmet.Name = "Predmet";
            this.Predmet.Width = 125;
            // 
            // Odeljenje
            // 
            this.Odeljenje.HeaderText = "Odeljenje";
            this.Odeljenje.MinimumWidth = 6;
            this.Odeljenje.Name = "Odeljenje";
            this.Odeljenje.Width = 125;
            // 
            // Raspodela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(974, 461);
            this.Controls.Add(this.dgv_raspodela);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(990, 500);
            this.MinimumSize = new System.Drawing.Size(990, 500);
            this.Name = "Raspodela";
            this.ShowIcon = false;
            this.Text = "Raspodela";
            this.Load += new System.EventHandler(this.Raspodela_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_raspodela)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_raspodela;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
        private System.Windows.Forms.DataGridViewButtonColumn Menjaj;
        private System.Windows.Forms.DataGridViewButtonColumn Dodaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewComboBoxColumn Nastavnik;
        private System.Windows.Forms.DataGridViewComboBoxColumn Godina;
        private System.Windows.Forms.DataGridViewComboBoxColumn Predmet;
        private System.Windows.Forms.DataGridViewComboBoxColumn Odeljenje;
    }
}