using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Configuration;

namespace EsDnevnik
{
    public partial class Osoba : Form
    {
        DataTable osoba, promene;
        SqlCommand menjanja, resetovanje_id;
        int BrVrste;

        public Osoba()
        {
            InitializeComponent();
        }

        private void TextLoad()
        {

            if (osoba.Rows.Count == 1)
            {
                b_first.Enabled = false;
                b_back.Enabled = false;
                b_next.Enabled = false;
                b_last.Enabled = false;
            }
            else
            {
                tb_id.Text = osoba.Rows[BrVrste][0].ToString();
                tb_ime.Text = osoba.Rows[BrVrste][1].ToString();
                tb_prezime.Text = osoba.Rows[BrVrste][2].ToString();
                tb_adresa.Text = osoba.Rows[BrVrste][3].ToString();
                tb_jmbg.Text = osoba.Rows[BrVrste][4].ToString();
                tb_mail.Text = osoba.Rows[BrVrste][5].ToString();
                tb_lozinka.Text = osoba.Rows[BrVrste][6].ToString();
                tb_uloga.Text = osoba.Rows[BrVrste][7].ToString();
                if (BrVrste == 0)
                {
                    b_back.Enabled = false;
                    b_first.Enabled = false;
                }
                else
                {
                    b_back.Enabled = true;
                    b_first.Enabled = true;
                }
                if (BrVrste == osoba.Rows.Count - 1)
                {
                    b_next.Enabled = false;
                    b_last.Enabled = false;
                }
                else
                {
                    b_next.Enabled = true;
                    b_last.Enabled = true;
                }
            }
        }

        private void Osoba_Load(object sender, EventArgs e)
        {
            osoba = new DataTable();
            osoba = Konekcija.Unos("SELECT * FROM Osoba");
            TextLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            BrVrste = 0;
            TextLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            if (BrVrste > 0)
            {
                BrVrste--;
                TextLoad();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            if (BrVrste < osoba.Rows.Count - 1)
            {
                BrVrste++;
                TextLoad();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_jmbg.Text.Length == 13)
                {
                    if (tb_uloga.Text == "1" || tb_uloga.Text == "2")
                    {
                        menjanja = new SqlCommand();
                        menjanja.CommandText = ("INSERT INTO Osoba VALUES (" + "'" + tb_ime.Text + "'" + ", " + "'" + tb_prezime.Text + "'" + ", " + "'" + tb_adresa.Text + "'" + ", " + "'" + tb_jmbg.Text + "'" + ", " + "'" + tb_mail.Text + "'" + ", " + "'" + tb_lozinka.Text + "'" + ", " + Convert.ToInt32(tb_uloga.Text) + ")");
                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();
                        label9.Text = "Uspesno ste dodali podatak!";
                        label9.Visible = true;
                        osoba = new DataTable();
                        osoba = Konekcija.Unos("SELECT * FROM Osoba");
                        TextLoad();
                    }
                    else label9.Text = "Uloga mora biti ili 1 ili 2!"; label9.Visible = true;
                }
                else label9.Text = "JMBG mora imati 13 cifara!"; label9.Visible = true;
                
            }
            catch
            {
                label9.Text = "Niste uneli odgovarajuce podatke podatke!";
                label9.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_jmbg.Text.Length == 13)
                {
                    if (tb_uloga.Text == "1" || tb_uloga.Text == "2")
                    {
                        int ID = Convert.ToInt32(tb_id.Text);
                        menjanja = new SqlCommand();
                        menjanja.CommandText = ("UPDATE Osoba SET ime = " + "'" + tb_ime.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET prezime = " + "'" + tb_prezime.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET adresa = " + "'" + tb_adresa.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET jmbg = " + "'" + tb_jmbg.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET email = " + "'" + tb_mail.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET pass = " + "'" + tb_lozinka.Text + "'" + " WHERE id = " + ID +
                            " UPDATE Osoba SET uloga = " + Convert.ToInt32(tb_uloga.Text) + " WHERE id = " + ID);
                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();
                        osoba = new DataTable();
                        osoba = Konekcija.Unos("SELECT * FROM Osoba");
                        TextLoad();
                        label9.Text = "Uspesno ste izmenili podatak!";
                        label9.Visible = true;
                    }
                    else label9.Text = "Uloga mora biti ili 1 ili 2!"; label9.Visible = true;
                }
                else label9.Text = "JMBG mora imati 13 cifara!"; label9.Visible = true;
            }
            catch
            {
                label7.Text = "Niste dobro uneli podatke!";
                label7.Visible = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            BrVrste = osoba.Rows.Count - 1;
            TextLoad();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int max_id;
                menjanja = new SqlCommand();
                menjanja.CommandText = ("DELETE FROM Osoba WHERE id = " + Convert.ToInt32(tb_id.Text));
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT * FROM Osoba");
                max_id = promene.Rows.Count - 1;
                resetovanje_id = new SqlCommand();
                resetovanje_id.CommandText = ("DBCC CHECKIDENT ('Osoba', RESEED, " + max_id + ")");

                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Open();
                menjanja.Connection = con;
                resetovanje_id.Connection = con;
                menjanja.ExecuteNonQuery();
                resetovanje_id.ExecuteNonQuery();
                con.Close();

                label9.Text = "Uspesno ste obrisali podatak!";
                label9.Visible = true;
                osoba = new DataTable();
                osoba = Konekcija.Unos("SELECT * FROM Osoba");
                BrVrste = 0;
                TextLoad();
            }
            catch
            {
                label9.Text = "Ne mozete da obrisete dati podatak!";
                label9.Visible = true;
            }
        }
    }
}
