using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace EsDnevnik
{
    public partial class Odeljenje : Form
    {
        DataTable odeljenja, odeljenja2, odeljenja3, odeljenja4, promene;
        SqlCommand promena, resetovanje_id;
        int vrsta;

        public Odeljenje()
        {
            InitializeComponent();
        }

        private void TextLoad()
        {
            if (odeljenja.Rows.Count == 1)
            {
                b_first.Enabled = false;
                c_back.Enabled = false;
                b_next.Enabled = false;
                b_last.Enabled = false;
            }
            else 
            {
                tb_id.Text = odeljenja.Rows[vrsta][0].ToString();
                tb_razred.Text = odeljenja.Rows[vrsta][1].ToString();
                tb_indeks.Text = odeljenja.Rows[vrsta][2].ToString();
                cb_smer.Text = odeljenja2.Rows[vrsta][0].ToString();
                cb_staresina.Text = odeljenja3.Rows[vrsta][0].ToString();
                cb_godina.Text = odeljenja4.Rows[vrsta][0].ToString();
                if (vrsta == 0)
                {
                    c_back.Enabled = false;
                    b_first.Enabled = false;
                }
                else
                {
                    c_back.Enabled = true;
                    b_first.Enabled = true;
                }
                if (vrsta == odeljenja.Rows.Count - 1)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Odeljenje_Load(object sender, EventArgs e)
        {
            odeljenja = new DataTable();
            odeljenja2 = new DataTable();
            odeljenja3 = new DataTable();
            odeljenja4 = new DataTable();
            odeljenja = Konekcija.Unos("SELECT * FROM Odeljenje");
            odeljenja2 = Konekcija.Unos("SELECT naziv AS smer_id FROM Smer JOIN Odeljenje ON Smer.id = Odeljenje.smer_id");
            odeljenja3 = Konekcija.Unos("SELECT ime + ' ' + prezime AS id_razredni FROM Osoba JOIN Odeljenje ON Osoba.id = Odeljenje.razredni_id");
            odeljenja4 = Konekcija.Unos("SELECT naziv AS godina_id FROM Skolska_godina JOIN Odeljenje ON Odeljenje.godina_id = Skolska_godina.id");
            TextLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vrsta > 0)
            {
                label7.Visible = false;
                vrsta--;
                TextLoad();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (vrsta < odeljenja.Rows.Count - 1)
            {
                label7.Visible = false;
                vrsta++;
                TextLoad();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            vrsta = 0;
            TextLoad();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            vrsta = odeljenja.Rows.Count - 1;
            TextLoad();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(tb_id.Text);
                int smer_id, razredni_id, godina_id;
                string[] ime_prezime = cb_staresina.Text.Split(' ');
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT id FROM Smer WHERE naziv = '" + cb_smer.Text + "'");
                smer_id = (int)promene.Rows[0][0];
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = '" + ime_prezime[0] + "'" + " AND prezime = '" + ime_prezime[1] + "'");
                razredni_id = (int)promene.Rows[0][0];
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT id FROM Skolska_godina WHERE naziv = '" + cb_godina.Text + "'");
                godina_id = (int)promene.Rows[0][0];
                promena = new SqlCommand();
                promena.CommandText = ("UPDATE Odeljenje SET razred = " + Convert.ToInt32(tb_razred.Text) + " WHERE id = " + ID +
                    " UPDATE Odeljenje SET indeks = " + Convert.ToInt32(tb_indeks.Text) + " WHERE id = " + ID +
                    " UPDATE Odeljenje SET smer_id = " + smer_id + " WHERE id = " + ID +
                    " UPDATE Odeljenje SET razredni_id = " + razredni_id + " WHERE id = " + ID +
                    " UPDATE Odeljenje SET godina_id = " + godina_id + " WHERE id = " + ID);
                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Open();
                promena.Connection = con;
                promena.ExecuteNonQuery();
                con.Close();
                odeljenja = new DataTable();
                odeljenja2 = new DataTable();
                odeljenja3 = new DataTable();
                odeljenja = Konekcija.Unos("SELECT * FROM Odeljenje");
                odeljenja2 = Konekcija.Unos("SELECT naziv AS smer_id FROM Smer JOIN Odeljenje ON Smer.id = Odeljenje.smer_id");
                odeljenja3 = Konekcija.Unos("SELECT ime + ' ' + prezime AS id_razredni FROM Osoba JOIN Odeljenje ON Osoba.id = Odeljenje.razredni_id");
                odeljenja4 = Konekcija.Unos("SELECT naziv AS godina_id FROM Skolska_godina JOIN Odeljenje ON Odeljenje.godina_id = Skolska_godina.id");
                TextLoad();
                label7.Text = "Uspesno ste izmenili podatak!";
                label7.Visible = true;
            }
            catch
            {
                label7.Text = "Niste dobro uneli podatke!";
                label7.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int max_id;
                promena = new SqlCommand();
                promena.CommandText = ("DELETE FROM Odeljenje WHERE id = " + Convert.ToInt32(tb_id.Text));
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT * FROM Odeljenje");
                max_id = promene.Rows.Count - 1;
                resetovanje_id = new SqlCommand();
                resetovanje_id.CommandText = ("DBCC CHECKIDENT ('Odeljenje', RESEED, " + max_id + ")");
                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Open();
                promena.Connection = con;
                resetovanje_id.Connection = con;
                promena.ExecuteNonQuery();
                resetovanje_id.ExecuteNonQuery();
                con.Close();
                label7.Text = "Uspesno ste obrisali podatak!";
                label7.Visible = true;
                odeljenja = new DataTable();
                odeljenja2 = new DataTable();
                odeljenja3 = new DataTable();
                odeljenja = Konekcija.Unos("SELECT * FROM Odeljenje");
                odeljenja2 = Konekcija.Unos("SELECT naziv AS smer_id FROM Smer JOIN Odeljenje ON Smer.id = Odeljenje.smer_id");
                odeljenja3 = Konekcija.Unos("SELECT ime + ' ' + prezime AS id_razredni FROM Osoba JOIN Odeljenje ON Osoba.id = Odeljenje.razredni_id");
                odeljenja4 = Konekcija.Unos("SELECT naziv AS godina_id FROM Skolska_godina JOIN Odeljenje ON Odeljenje.godina_id = Skolska_godina.id");
                vrsta = 0;
                TextLoad();
            }
            catch
            {
                label7.Text = "Ne mozete da obrisete dati podatak!";
                label7.Visible = true;
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int smer_id, razredni_id, godina_id;
                string[] ime_prezime = cb_staresina.Text.Split(' ');
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT id FROM Smer WHERE naziv = '" + cb_smer.Text + "'");
                smer_id = (int)promene.Rows[0][0];
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = '" + ime_prezime[0] + "'" + " AND prezime = '" + ime_prezime[1] + "'");
                razredni_id = (int)promene.Rows[0][0];
                promene = new DataTable();
                promene = Konekcija.Unos("SELECT id FROM Skolska_godina WHERE naziv = '" + cb_godina.Text + "'");
                godina_id = (int)promene.Rows[0][0];
                promena = new SqlCommand();
                promena.CommandText = ("INSERT INTO Odeljenje VALUES (" + Convert.ToInt32(tb_razred.Text) + ", " + tb_indeks.Text + ", " + smer_id + ", " + razredni_id + ", " + godina_id + ")");
                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Open();
                promena.Connection = con;
                promena.ExecuteNonQuery();
                con.Close();
                label7.Text = "Uspesno ste dodali podatak!";
                label7.Visible = true;
                odeljenja = new DataTable();
                odeljenja2 = new DataTable();
                odeljenja3 = new DataTable();
                odeljenja = Konekcija.Unos("SELECT * FROM Odeljenje");
                odeljenja2 = Konekcija.Unos("SELECT naziv AS smer_id FROM Smer JOIN Odeljenje ON Smer.id = Odeljenje.smer_id");
                odeljenja3 = Konekcija.Unos("SELECT ime + ' ' + prezime AS id_razredni FROM Osoba JOIN Odeljenje ON Osoba.id = Odeljenje.razredni_id");
                odeljenja4 = Konekcija.Unos("SELECT naziv AS godina_id FROM Skolska_godina JOIN Odeljenje ON Odeljenje.godina_id = Skolska_godina.id");
                TextLoad();
            }
            catch
            {
                label7.Text = "Niste uneli odgovarajuce podatke podatke!";
                label7.Visible = true;
            }
        }
    }
}
