using Magazyn.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class ZapomnianiUzytkownicy : Form
    {
        public ZapomnianiUzytkownicy()
        {
            InitializeComponent();
            ConfigureDataGridView();
            WireUpEventHandlers();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewZapomniani.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewZapomniani.MultiSelect = false;
            dataGridViewZapomniani.AutoGenerateColumns = false;

            // Konfiguracja kolumn
            dataGridViewZapomniani.Columns.Add("ID", "ID");
            dataGridViewZapomniani.Columns.Add("ImieNazwisko", "Imię i nazwisko");
            dataGridViewZapomniani.Columns.Add("DataZapomnienia", "Data zapomnienia");

            dataGridViewZapomniani.Columns["ID"].DataPropertyName = "ID";
            dataGridViewZapomniani.Columns["ImieNazwisko"].DataPropertyName = "ImieNazwisko";
            dataGridViewZapomniani.Columns["DataZapomnienia"].DataPropertyName = "DataZapomnienia";
        }

        private void WireUpEventHandlers()
        {
            txtFiltrImie.TextChanged += FiltrujUzytkownikow;
            txtFiltrNazwisko.TextChanged += FiltrujUzytkownikow;
            txtFiltrPesel.TextChanged += FiltrujUzytkownikow;
            btnWyczyscFiltry.Click += btnWyczyscFiltry_Click;
        }

        private void ZapomnianiUzytkownicy_Load(object sender, EventArgs e)
        {
            WczytajZapomnianych();
        }

        private void WczytajZapomnianych(string filtrImie = "", string filtrNazwisko = "", string filtrPesel = "")
        {
            try
            {
                dataGridViewZapomniani.DataSource = null;

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT 
                            ID_Uzytkownik AS 'ID',
                            'xxxxx xxxxx' AS 'ImieNazwisko',
                            Data_zapomnienia AS 'DataZapomnienia'
                        FROM Uzytkownik
                        WHERE 
                            ID_Status = 2
                            AND (Imię LIKE @FiltrImie + '%' OR @FiltrImie = '')
                            AND (Nazwisko LIKE @FiltrNazwisko + '%' OR @FiltrNazwisko = '')
                            AND (PESEL LIKE @FiltrPesel + '%' OR @FiltrPesel = '')";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrImie", filtrImie);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrNazwisko", filtrNazwisko);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrPesel", filtrPesel);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewZapomniani.DataSource = dt;
                }

                dataGridViewZapomniani.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWyczyscFiltry_Click(object sender, EventArgs e)
        {
            txtFiltrImie.Clear();
            txtFiltrNazwisko.Clear();
            txtFiltrPesel.Clear();
            WczytajZapomnianych();
        }

        private void btnPowrot_Click_1(object sender, EventArgs e)
        {
            new ListaUzytkownikow().Show();
            this.Close();
        }

        private void FiltrujUzytkownikow(object sender, EventArgs e)
        {
            WczytajZapomnianych(
                txtFiltrImie.Text.Trim(),
                txtFiltrNazwisko.Text.Trim(),
                txtFiltrPesel.Text.Trim()
            );
        }
    }
}