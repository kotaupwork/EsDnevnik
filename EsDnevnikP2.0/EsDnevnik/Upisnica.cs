﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EsDnevnik
{
    public partial class Upisnica : Form
    {
        DataTable podaci, podaci1;
        SqlCommand menjanja;
        string[] pomocna;
        public Upisnica()
        {
            InitializeComponent();
        }

        private void Osvezi()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Upisnica.id AS id, Osoba.ime + ' ' + Osoba.prezime AS 'ime i prezime', STR(Odeljenje.razred,1,0) + '/' + Odeljenje.indeks AS Odeljenje, Smer.naziv AS Smer FROM Upisnica\r\nJOIN Osoba ON Upisnica.osoba_id = Osoba.id\r\nJOIN Odeljenje ON Upisnica.odeljenje_id = Odeljenje.id\r\nJOIN Smer ON Odeljenje.smer_id = Smer.id");

            if (dgv_upisnica.Rows.Count != 1)
            {
                while (dgv_upisnica.Rows.Count != 1)
                {
                    dgv_upisnica.Rows.RemoveAt(0);
                }
            }

            for (int i = 0; i < podaci.Rows.Count; i++)
            {
                dgv_upisnica.Rows.Add();
                dgv_upisnica.Rows[i].Cells["Id"].Value = Convert.ToString(podaci.Rows[i]["id"]);
                dgv_upisnica.Rows[i].Cells["Ime_i_prezime"].Value = Convert.ToString(podaci.Rows[i]["ime i prezime"]);
                dgv_upisnica.Rows[i].Cells["Odeljenje"].Value = Convert.ToString(podaci.Rows[i]["Odeljenje"]);
                dgv_upisnica.Rows[i].Cells["Smer"].Value = Convert.ToString(podaci.Rows[i]["Smer"]);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//Dugmad
        {
            if (dgv_upisnica.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ove podatake?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int indeks = Convert.ToInt32(dgv_upisnica.Rows[e.RowIndex].Cells["Id"].Value);

                        menjanja = new SqlCommand();
                        menjanja.CommandText = ("DELETE FROM Upisnica WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();
                        dgv_upisnica.Rows.RemoveAt(e.RowIndex);

                        Osvezi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da obrisete ove podatake, druge tabele zahtevaju ove podatake! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (dgv_upisnica.Columns[e.ColumnIndex].Name == "Menjaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da izmenite ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        menjanja = new SqlCommand();

                        int indeks = Convert.ToInt32(dgv_upisnica.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dgv_upisnica.Rows[e.RowIndex].Cells["Ime_i_prezime"].Value).Split(' ');
                        string[] odeljenje = Convert.ToString(dgv_upisnica.Rows[e.RowIndex].Cells["Odeljenje"].Value).Split('/');

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Odeljenje WHERE razred = " + "'" + odeljenje[0] + "' AND indeks = " + "'" + odeljenje[1] + "'");
                        int odeljenje_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Upisnica WHERE osoba_id = " + osoba_id + " AND odeljenje_id = " + odeljenje_id);
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja.CommandText = ("UPDATE Upisnica SET osoba_id = " + osoba_id + " WHERE id = " + indeks +
                            " UPDATE Upisnica SET odeljenje_id = " + odeljenje_id + " WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();

                        Osvezi();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Podatak vec postoji u tabeli - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Osvezi();
                }
            }

            else if (dgv_upisnica.Columns[e.ColumnIndex].Name == "Dodaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da dodate ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        menjanja = new SqlCommand();

                        int indeks = Convert.ToInt32(dgv_upisnica.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dgv_upisnica.Rows[e.RowIndex].Cells["Nastavnik"].Value).Split(' ');
                        string[] odeljenje = Convert.ToString(dgv_upisnica.Rows[e.RowIndex].Cells["Odeljenje"].Value).Split('/');

                        if (ime_prezime[0] == "" || ime_prezime[1] == "" || odeljenje[0] == "" || odeljenje[1] == "")
                            throw new Exception();

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Odeljenje WHERE razred = " + "'" + odeljenje[0] + "' AND indeks = " + "'" + odeljenje[1] + "'");
                        int odeljenje_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Raspodela WHERE nastavnik_id = " + osoba_id + " AND odeljenje_id = " + odeljenje_id);
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja.CommandText = ("INSERT INTO Raspodela VALUES (" + osoba_id + ", " + odeljenje_id + ")");

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();

                        Osvezi();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da dodate vec postojece podatke! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Osvezi();
                }
            }
        }
       

        private void Upisnica_Load(object sender, EventArgs e)
        {
            podaci1 = new DataTable();//Dodavanje ucenika
            podaci1 = Konekcija.Unos("SELECT ime + ' ' + prezime AS 'ime i prezime' FROM Osoba WHERE uloga = 1");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["ime i prezime"]);
                Ime_i_prezime.Items.Add(pomocna[i]);
            }

            podaci1 = new DataTable();//Dodavanje odeljenja
            podaci1 = Konekcija.Unos("SELECT STR(Odeljenje.razred,1,0) + '/' + Odeljenje.indeks AS Odeljenje FROM Odeljenje");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["Odeljenje"]);
                Odeljenje.Items.Add(pomocna[i]);
            }

            podaci1 = new DataTable();//Dodavanje smerova
            podaci1 = Konekcija.Unos("SELECT naziv FROM Smer");
            pomocna = new string[podaci1.Rows.Count];

            for (int i = 0; i < podaci1.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(podaci1.Rows[i]["naziv"]);
                Smer.Items.Add(pomocna[i]);
            }
            Osvezi();
        }
    }
}