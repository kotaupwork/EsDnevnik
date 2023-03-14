namespace EsDnevnik
{
    partial class Upisnica
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
            this.dgv_upisnica = new System.Windows.Forms.DataGridView();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Menjaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Dodaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime_i_prezime = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Odeljenje = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Smer = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_upisnica)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_upisnica
            // 
            this.dgv_upisnica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_upisnica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Obrisi,
            this.Menjaj,
            this.Dodaj,
            this.Id,
            this.Ime_i_prezime,
            this.Odeljenje,
            this.Smer});
            this.dgv_upisnica.Location = new System.Drawing.Point(26, 64);
            this.dgv_upisnica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_upisnica.Name = "dgv_upisnica";
            this.dgv_upisnica.RowHeadersWidth = 51;
            this.dgv_upisnica.RowTemplate.Height = 24;
            this.dgv_upisnica.Size = new System.Drawing.Size(928, 379);
            this.dgv_upisnica.TabIndex = 0;
            this.dgv_upisnica.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 125;
            // 
            // Ime_i_prezime
            // 
            this.Ime_i_prezime.HeaderText = "Ime i prezime";
            this.Ime_i_prezime.MinimumWidth = 6;
            this.Ime_i_prezime.Name = "Ime_i_prezime";
            this.Ime_i_prezime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ime_i_prezime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ime_i_prezime.Width = 125;
            // 
            // Odeljenje
            // 
            this.Odeljenje.HeaderText = "Odeljenje";
            this.Odeljenje.MinimumWidth = 6;
            this.Odeljenje.Name = "Odeljenje";
            this.Odeljenje.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Odeljenje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Odeljenje.Width = 125;
            // 
            // Smer
            // 
            this.Smer.HeaderText = "Smer";
            this.Smer.MinimumWidth = 6;
            this.Smer.Name = "Smer";
            this.Smer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Smer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Smer.Width = 125;
            // 
            // Upisnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(974, 461);
            this.Controls.Add(this.dgv_upisnica);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(990, 500);
            this.MinimumSize = new System.Drawing.Size(990, 500);
            this.Name = "Upisnica";
            this.ShowIcon = false;
            this.Text = "Upisnica";
            this.Load += new System.EventHandler(this.Upisnica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_upisnica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_upisnica;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
        private System.Windows.Forms.DataGridViewButtonColumn Menjaj;
        private System.Windows.Forms.DataGridViewButtonColumn Dodaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ime_i_prezime;
        private System.Windows.Forms.DataGridViewComboBoxColumn Odeljenje;
        private System.Windows.Forms.DataGridViewComboBoxColumn Smer;
    }
}