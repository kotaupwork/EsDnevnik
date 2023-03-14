using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsDnevnik
{
    public partial class Ocene : Form
    {
        DataTable ptabela1, ptabela2;
        SqlCommand promena;
        string[] pomocna;

        public Ocene()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ocene.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ove podatake?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int indeks = Convert.ToInt32(dgv_ocene.Rows[e.RowIndex].Cells["id"].Value);

                        promena = new SqlCommand();
                        promena.CommandText = ("DELETE FROM Ocena WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promena.Connection = con;
                        promena.ExecuteNonQuery();
                        con.Close();
                        dgv_ocene.Rows.RemoveAt(e.RowIndex);

                        Osvezi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da obrisete ove podatake, druge tabele zahtevaju ove podatake! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (dgv_ocene.Columns[e.ColumnIndex].Name == "Menjaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da izmenite ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        promena = new SqlCommand();

                        int indeks = Convert.ToInt32(dgv_ocene.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Ime_i_prezime"].Value).Split(' ');
                        string datum = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Datum"].Value);
                        string raspodela = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Predmet"].Value);
                        string ocena = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Ocena"].Value);
                        string predmet = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Predmet"].Value);

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Predmet WHERE naziv = " + "'" + predmet + "'");
                        int predmet_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Raspodela WHERE predmet_id = " + predmet_id);
                        int raspodela_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT * FROM Ocena WHERE datum = '" + datum + "' AND raspodela_id = " + raspodela_id + " AND ocena = '" + ocena + "' AND ucenik_id = " + osoba_id);
                        if (ptabela1.Rows.Count >= 1) throw new Exception();

                        promena.CommandText = ("UPDATE Ocena SET datum = '" + datum + "' WHERE id = " + indeks +
                            " UPDATE Ocena SET raspodela_id = " + raspodela_id + " WHERE id = " + indeks +
                            " UPDATE Ocena SET ocena = '" + ocena + "' WHERE id = " + indeks +
                            " UPDATE Ocena SET ucenik_id = " + osoba_id + " WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promena.Connection = con;
                        promena.ExecuteNonQuery();
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

            else if (dgv_ocene.Columns[e.ColumnIndex].Name == "Dodaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da dodate ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        promena = new SqlCommand();

                        int indeks = Convert.ToInt32(dgv_ocene.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Ime_i_prezime"].Value).Split(' ');
                        string datum = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Datum"].Value);
                        string ocena = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Ocena"].Value);
                        string predmet = Convert.ToString(dgv_ocene.Rows[e.RowIndex].Cells["Predmet"].Value);

                        if (ime_prezime[0] == "" || ime_prezime[1] == "" || predmet == "" || datum == "" || ocena == "") throw new Exception();

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Predmet WHERE naziv = " + "'" + predmet + "'");
                        int predmet_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Raspodela WHERE predmet_id = " + predmet_id);
                        int raspodela_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT * FROM Ocena WHERE datum = '" + datum + "' AND raspodela_id = " + raspodela_id + " AND ocena = '" + ocena + "' AND ucenik_id = " + osoba_id);
                        if (ptabela1.Rows.Count >= 1) throw new Exception();

                        promena.CommandText = ("INSERT INTO Ocena VALUES ('" + datum + "', " + raspodela_id + ", " + ocena + ", " + osoba_id + ")");

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promena.Connection = con;
                        promena.ExecuteNonQuery();
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

        private void Osvezi()
        {
            ptabela1 = new DataTable();
            ptabela1 = Konekcija.Unos("SELECT Ocena.id AS Id, datum AS Datum, Osoba.ime + ' ' + Osoba.prezime AS Ucenik, ocena AS Ocena, Predmet.naziv AS Predmet FROM Ocena\r\n JOIN Osoba ON Ocena.ucenik_id = Osoba.id\r\n JOIN Raspodela ON Raspodela.id = Ocena.raspodela_id\r\n JOIN Predmet ON Predmet.id = Raspodela.predmet_id");

            if (dgv_ocene.Rows.Count != 1)
            {
                while (dgv_ocene.Rows.Count != 1)
                {
                    dgv_ocene.Rows.RemoveAt(0);
                }
            }

            for (int i = 0; i < ptabela1.Rows.Count; i++)
            {
                dgv_ocene.Rows.Add();
                dgv_ocene.Rows[i].Cells["Id"].Value = Convert.ToString(ptabela1.Rows[i]["Id"]);
                dgv_ocene.Rows[i].Cells["Datum"].Value = Convert.ToString(ptabela1.Rows[i]["Datum"]);
                dgv_ocene.Rows[i].Cells["Ime_i_prezime"].Value = Convert.ToString(ptabela1.Rows[i]["Ucenik"]);
                dgv_ocene.Rows[i].Cells["Ocena"].Value = Convert.ToString(ptabela1.Rows[i]["Ocena"]);
                dgv_ocene.Rows[i].Cells["Predmet"].Value = Convert.ToString(ptabela1.Rows[i]["Predmet"]);
            }
        }

        private void Ocene_Load(object sender, EventArgs e)
        {
            ptabela2 = new DataTable();//Dodavanje ucenika
            ptabela2 = Konekcija.Unos("SELECT ime + ' ' + prezime AS Ucenik FROM Osoba WHERE ULOGA = 1");
            pomocna = new string[ptabela2.Rows.Count];

            for (int i = 0; i < ptabela2.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(ptabela2.Rows[i]["Ucenik"]);
                Ime_i_prezime.Items.Add(pomocna[i]);
            }

            ptabela2 = new DataTable();//Dodavanje predmeta
            ptabela2 = Konekcija.Unos("SELECT DISTINCT naziv FROM Predmet");
            pomocna = new string[ptabela2.Rows.Count];

            for (int i = 0; i < ptabela2.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(ptabela2.Rows[i]["naziv"]);
                Predmet.Items.Add(pomocna[i]);
            }

            Osvezi();
        }
    }
}
