using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EsDnevnik
{
    public partial class Forma : Form
    {
        DataTable ptabela;
        SqlCommand promene;
        string tabela;

        public Forma(string ime)
        {
            tabela = ime;
            
            InitializeComponent();
        }

        private void Osvezi(string tabela)
        {
            try
            {
                ptabela = new DataTable();
                ptabela = Konekcija.Unos("SELECT * FROM " + tabela);
                if (dgv_templejt.Rows.Count != 1)
                {
                    while (dgv_templejt.Rows.Count != 1)
                    {
                        dgv_templejt.Rows.RemoveAt(0);
                    }
                }

                if (tabela == "Predmet")
                {
                    textBox3.Visible = true;
                    label3.Visible = true;
                    label2.Text = tabela;
                    dgv_templejt.Columns["Smer"].Visible = false;
                    for (int i = 0; i < ptabela.Rows.Count; i++)
                    {
                        dgv_templejt.Rows.Add();
                        dgv_templejt.Rows[i].Cells["IDD"].Value = Convert.ToString(ptabela.Rows[i]["id"]);
                        dgv_templejt.Rows[i].Cells["Predmet"].Value = Convert.ToString(ptabela.Rows[i]["naziv"]);
                        dgv_templejt.Rows[i].Cells["Razred"].Value = Convert.ToString(ptabela.Rows[i]["razred"]);
                    }

                }
                else if (tabela == "Smer")
                {
                    label2.Text = tabela;
                    dgv_templejt.Columns["Predmet"].Visible = false;
                    dgv_templejt.Columns["Razred"].Visible = false;

                    for (int i = 0; i < ptabela.Rows.Count; i++)
                    {
                        dgv_templejt.Rows.Add();
                        dgv_templejt.Rows[i].Cells["IDD"].Value = Convert.ToString(ptabela.Rows[i]["id"]);
                        dgv_templejt.Rows[i].Cells["Smer"].Value = Convert.ToString(ptabela.Rows[i]["naziv"]);
                    }
                }
                else
                {
                    label2.Text = "Skolska godina";
                    dgv_templejt.Columns["Predmet"].Visible = false;
                    dgv_templejt.Columns["Razred"].Visible = false;
                    dgv_templejt.Columns["Smer"].Visible = false;
                    dgv_templejt.Columns["IDD"].Visible = false;
                    dgv_templejt.DataSource = ptabela;
                    dgv_templejt.Columns["id"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Source);
            }
        }

        private void Skolska_Godina_Load(object sender, EventArgs e)
        {
            Osvezi(tabela);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_templejt.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ove podatake?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int indeks;
                        if (tabela == "Skolska_godina")
                        {
                            indeks = Convert.ToInt32(dgv_templejt.Rows[e.RowIndex].Cells["id"].Value);
                        }
                        else
                        {
                            indeks = Convert.ToInt32(dgv_templejt.Rows[e.RowIndex].Cells["IDD"].Value);
                        }

                        promene = new SqlCommand();
                        promene.CommandText = ("DELETE FROM " + tabela + " WHERE id = " + indeks);

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
                        con.Close();
                        dgv_templejt.Rows.RemoveAt(e.RowIndex);
                        Osvezi(tabela);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da obrisete ove podatake, druge tabele zahtevaju ove podatake! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Osvezi(tabela);
                }
            }

            else if (dgv_templejt.Columns[e.ColumnIndex].Name == "Menjaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da izmenite ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        promene = new SqlCommand();

                        if (tabela == "Predmet")
                        {
                            int indeks;
                            indeks = Convert.ToInt32(dgv_templejt.Rows[e.RowIndex].Cells["IDD"].Value);
                            string razred;
                            razred = Convert.ToString(dgv_templejt.Rows[e.RowIndex].Cells["Razred"].Value);
                            string naziv;
                            naziv = Convert.ToString(dgv_templejt.Rows[e.RowIndex].Cells["Predmet"].Value);

                            ptabela = new DataTable();
                            ptabela = Konekcija.Unos("SELECT naziv, razred FROM " + tabela + " WHERE naziv = " + "'" + naziv + "' AND razred = " + "'" + razred + "'");
                            if (ptabela.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("UPDATE " + tabela + " SET naziv = " + "'" + naziv + "'" + " WHERE id = " + indeks +
                                " UPDATE " + tabela + " SET razred = " + "'" + razred + "'" + " WHERE id = " + indeks);
                        }
                        else if (tabela == "Smer")
                        {
                            int indeks;
                            indeks = Convert.ToInt32(dgv_templejt.Rows[e.RowIndex].Cells["IDD"].Value);
                            string naziv;
                            naziv = Convert.ToString(dgv_templejt.Rows[e.RowIndex].Cells["Smer"].Value);

                            ptabela = new DataTable();
                            ptabela = Konekcija.Unos("SELECT naziv FROM " + tabela + " WHERE naziv = " + "'" + naziv + "'");
                            if (ptabela.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("UPDATE " + tabela + " SET naziv = " + "'" + naziv + "'" + " WHERE id = " + indeks);
                        }
                        else
                        {
                            int indeks;
                            indeks = Convert.ToInt32(dgv_templejt.Rows[e.RowIndex].Cells["id"].Value);
                            string naziv;
                            naziv = Convert.ToString(dgv_templejt.Rows[e.RowIndex].Cells["naziv"].Value);

                            ptabela = new DataTable();
                            ptabela = Konekcija.Unos("SELECT naziv FROM " + tabela + " WHERE naziv = " + "'" + naziv + "'");
                            if (ptabela.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("UPDATE " + tabela + " SET naziv = " + "'" + naziv + "'" + " WHERE id = " + indeks);
                        }

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
                        con.Close();

                        Osvezi(tabela);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Podatak vec postoji u tabeli - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Osvezi(tabela);
                }
            }

            else if (dgv_templejt.Columns[e.ColumnIndex].Name == "Dodaj")
            {
                try
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite da dodate ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        promene = new SqlCommand();

                        if (tabela == "Predmet")
                        {
                            string naziv;
                            naziv = Convert.ToString(dgv_templejt.Rows[e.RowIndex].Cells["Predmet"].Value);
                            string razred;
                            razred = Convert.ToString(dgv_templejt.Rows[e.RowIndex].Cells["Razred"].Value);

                            if (naziv == "" || razred == "")
                            {
                                throw new Exception();
                            }

                            ptabela = new DataTable();
                            ptabela = Konekcija.Unos("SELECT naziv, razred FROM " + tabela + " WHERE naziv = " + "'" + naziv + "' AND razred = " + "'" + razred + "'");
                            if (ptabela.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("INSERT INTO " + tabela + " VALUES (" + "'" + naziv + "', " + "'" + razred + "')");
                        }
                        else if (tabela == "Smer")
                        {
                            string naziv;
                            naziv = Convert.ToString(dgv_templejt.Rows[e.RowIndex].Cells["Smer"].Value);
                            ptabela = new DataTable();
                            ptabela = Konekcija.Unos("SELECT naziv FROM " + tabela + " WHERE naziv = " + "'" + naziv + "'");
                            if (ptabela.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("INSERT INTO " + tabela + " VALUES (" + "'" + naziv + "')");
                        }
                        else
                        {
                            string naziv;
                            naziv = Convert.ToString(dgv_templejt.Rows[e.RowIndex].Cells["naziv"].Value);
                            ptabela = new DataTable();
                            ptabela = Konekcija.Unos("SELECT naziv FROM " + tabela + " WHERE naziv = " + "'" + naziv + "'");
                            if (ptabela.Rows.Count >= 1) throw new Exception();

                            promene.CommandText = ("INSERT INTO " + tabela + " VALUES (" + "'" + naziv + "')");
                        }

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        promene.Connection = con;
                        promene.ExecuteNonQuery();
                        con.Close();

                        Osvezi(tabela);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mozete da dodate vec postojece podatke! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Osvezi(tabela);
                }
            }


        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgv_templejt.CurrentRow != null)
            {
                int indeks = dgv_templejt.CurrentRow.Index;

                if (tabela == "Skolska_godina")
                {
                    textBox1.Text = Convert.ToString(dgv_templejt.Rows[indeks].Cells["id"].Value);
                    textBox2.Text = Convert.ToString(dgv_templejt.Rows[indeks].Cells["naziv"].Value);
                }
                else if (tabela == "Smer")
                {
                    textBox1.Text = Convert.ToString(dgv_templejt.Rows[indeks].Cells["IDD"].Value);
                    textBox2.Text = Convert.ToString(dgv_templejt.Rows[indeks].Cells["Smer"].Value);
                }
                else
                {
                    textBox1.Text = Convert.ToString(dgv_templejt.Rows[indeks].Cells["IDD"].Value);
                    textBox2.Text = Convert.ToString(dgv_templejt.Rows[indeks].Cells["Predmet"].Value);
                    textBox3.Text = Convert.ToString(dgv_templejt.Rows[indeks].Cells["Razred"].Value);
                }
            }
        }
    }
}
