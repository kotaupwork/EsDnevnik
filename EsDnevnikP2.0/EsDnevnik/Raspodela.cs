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
using System.Reflection.Emit;

namespace EsDnevnik
{
    public partial class Raspodela : Form
    {
        DataTable ptabela1, ptabela2;
        SqlCommand promene;
        string[] pomocna;
        public Raspodela()
        {
            InitializeComponent();
        }

        private void Osvezi()
        {
            ptabela1 = new DataTable();
            ptabela1 = Konekcija.Unos("SELECT raspodela.id, Osoba.ime + ' ' + Osoba.prezime AS Nastavnik, Skolska_godina.naziv AS Godina, Predmet.naziv AS Predmet, STR(Odeljenje.razred,1,0) + '/' + Odeljenje.indeks AS Odeljenje FROM Raspodela left join Osoba ON Raspodela.nastavnik_id = Osoba.id left join Skolska_godina ON Raspodela.godina_id = Skolska_godina.id left join Predmet ON Raspodela.predmet_id = Predmet.id left join Odeljenje ON Raspodela.odeljenje_id = Odeljenje.id");

            if (dgv_raspodela.Rows.Count != 1)
            {
                while (dgv_raspodela.Rows.Count != 1)
                {
                    dgv_raspodela.Rows.RemoveAt(0);
                }
            }

            for (int i = 0; i < ptabela1.Rows.Count; i++)
            {
                dgv_raspodela.Rows.Add();
                dgv_raspodela.Rows[i].Cells["id"].Value = Convert.ToString(ptabela1.Rows[i]["id"]);
                dgv_raspodela.Rows[i].Cells["Nastavnik"].Value = Convert.ToString(ptabela1.Rows[i]["Nastavnik"]);
                dgv_raspodela.Rows[i].Cells["Godina"].Value = Convert.ToString(ptabela1.Rows[i]["Godina"]);
                dgv_raspodela.Rows[i].Cells["Predmet"].Value = Convert.ToString(ptabela1.Rows[i]["Predmet"]);
                dgv_raspodela.Rows[i].Cells["Odeljenje"].Value = Convert.ToString(ptabela1.Rows[i]["Odeljenje"]);
            }
        }

        private void Raspodela_Load(object sender, EventArgs e)
        {
            ptabela2 = new DataTable();//Dodavanje skolskih godina
            ptabela2 = Konekcija.Unos("SELECT naziv FROM Skolska_godina");
            pomocna = new string[ptabela2.Rows.Count];

            for (int i = 0; i < ptabela2.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(ptabela2.Rows[i]["naziv"]);
                Godina.Items.Add(pomocna[i]);
            }

            ptabela2 = new DataTable();//Dodavanje nastavnika
            ptabela2 = Konekcija.Unos("SELECT ime + ' ' + prezime AS Nastavnik FROM Osoba WHERE uloga = 2");
            pomocna = new string[ptabela2.Rows.Count];

            for (int i = 0; i < ptabela2.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(ptabela2.Rows[i]["Nastavnik"]);
                Nastavnik.Items.Add(pomocna[i]);
            }

            ptabela2 = new DataTable();//Dodavanje predmeta
            ptabela2 = Konekcija.Unos("SELECT DISTINCT naziv FROM Predmet");
            pomocna = new string[ptabela2.Rows.Count];

            for (int i = 0; i < ptabela2.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(ptabela2.Rows[i]["naziv"]);
                Predmet.Items.Add(pomocna[i]);
            }

            ptabela2 = new DataTable();//Dodavanje odeljenja
            ptabela2 = Konekcija.Unos("SELECT STR(razred,1,0) + '/' + indeks AS Odlj FROM Odeljenje");
            pomocna = new string[ptabela2.Rows.Count];

            for (int i = 0; i < ptabela2.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(ptabela2.Rows[i]["Odlj"]);
                Odeljenje.Items.Add(pomocna[i]);
            }
            Osvezi();
        }

       /* private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            int indeks;
            indeks = dataGridView1.CurrentRow.Index;
            textBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["id"].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Nastavnik"].Value);
            textBox3.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Godina"].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Predmet"].Value);
            textBox5.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Odeljenje"].Value);
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_raspodela.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ove podatake?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int indeks = Convert.ToInt32(dgv_raspodela.Rows[e.RowIndex].Cells["id"].Value);

                        promene = new SqlCommand();
                        promene.CommandText = ("DELETE FROM Raspodela WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
                        con.Close();
                        dgv_raspodela.Rows.RemoveAt(e.RowIndex);

                        Osvezi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da obrisete ove podatake, druge tabele zahtevaju ove podatake! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (dgv_raspodela.Columns[e.ColumnIndex].Name == "Menjaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da izmenite ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        promene = new SqlCommand();

                        int indeks = Convert.ToInt32(dgv_raspodela.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dgv_raspodela.Rows[e.RowIndex].Cells["Nastavnik"].Value).Split(' ');
                        string godina = Convert.ToString(dgv_raspodela.Rows[e.RowIndex].Cells["Godina"].Value);
                        string predmet = Convert.ToString(dgv_raspodela.Rows[e.RowIndex].Cells["Predmet"].Value);
                        string[] odeljenje = Convert.ToString(dgv_raspodela.Rows[e.RowIndex].Cells["Odeljenje"].Value).Split('/');

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Skolska_godina WHERE naziv = " + "'" + godina + "'");
                        int godina_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Predmet WHERE naziv = " + "'" + predmet + "'");
                        int predmet_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Odeljenje WHERE razred = " + "'" + odeljenje[0] + "' AND indeks = " + "'" + odeljenje[1] + "'");
                        int odeljenje_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT * FROM Raspodela WHERE nastavnik_id = " + osoba_id + " AND godina_id = " + godina_id + " AND predmet_id = " + predmet_id + " AND odeljenje_id = " + odeljenje_id);
                        if (ptabela1.Rows.Count >= 1) throw new Exception();

                        promene.CommandText = ("UPDATE Raspodela SET nastavnik_id = " + osoba_id + " WHERE id = " + indeks +
                            " UPDATE Raspodela SET godina_id = " + godina_id + " WHERE id = " + indeks +
                            " UPDATE Raspodela SET predmet_id = " + predmet_id + " WHERE id = " + indeks +
                            " UPDATE Raspodela SET odeljenje_id = " + odeljenje_id + " WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
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
            
            else if (dgv_raspodela.Columns[e.ColumnIndex].Name == "Dodaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da dodate ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        promene = new SqlCommand();

                        int indeks = Convert.ToInt32(dgv_raspodela.Rows[e.RowIndex].Cells["id"].Value);
                        string[] ime_prezime = Convert.ToString(dgv_raspodela.Rows[e.RowIndex].Cells["Nastavnik"].Value).Split(' ');
                        string godina = Convert.ToString(dgv_raspodela.Rows[e.RowIndex].Cells["Godina"].Value);
                        string predmet = Convert.ToString(dgv_raspodela.Rows[e.RowIndex].Cells["Predmet"].Value);
                        string[] odeljenje = Convert.ToString(dgv_raspodela.Rows[e.RowIndex].Cells["Odeljenje"].Value).Split('/');

                        if (ime_prezime[0] == "" || ime_prezime[1] == "" || godina == "" || predmet == "" || odeljenje[0] == "" || odeljenje[1] == "")
                            throw new Exception();

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Osoba WHERE ime = " + "'" + ime_prezime[0] + "' AND prezime = " + "'" + ime_prezime[1] + "'");
                        int osoba_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Skolska_godina WHERE naziv = " + "'" + godina + "'");
                        int godina_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Predmet WHERE naziv = " + "'" + predmet + "'");
                        int predmet_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT id FROM Odeljenje WHERE razred = " + "'" + odeljenje[0] + "' AND indeks = " + "'" + odeljenje[1] + "'");
                        int odeljenje_id = (int)ptabela1.Rows[0][0];

                        ptabela1 = new DataTable();
                        ptabela1 = Konekcija.Unos("SELECT * FROM Raspodela WHERE nastavnik_id = " + osoba_id + " AND godina_id = " + godina_id + " AND predmet_id = " + predmet_id + " AND odeljenje_id = " + odeljenje_id);
                        if (ptabela1.Rows.Count >= 1) throw new Exception();

                        promene.CommandText = ("INSERT INTO Raspodela VALUES (" + osoba_id + ", " + godina_id + ", " + predmet_id + ", " + odeljenje_id + ")");

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
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
    }
}
