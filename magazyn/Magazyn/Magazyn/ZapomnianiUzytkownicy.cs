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
            dataGridViewZapomniani.CellFormatting += dataGridViewZapomniani_CellFormatting;
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
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT 
                    ID_Uzytkownik AS 'ID',
                    Imię,
                    Nazwisko,
                    PESEL,
                    Email,
                    Data_zapomnienia AS 'DataZapomnienia',
                    'Nieaktywny' AS 'Status'
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

                    // Debug: sprawdź liczbę rekordów
                    Console.WriteLine($"Liczba rekordów: {dt.Rows.Count}");

                    dataGridViewZapomniani.AutoGenerateColumns = true; // Dodaj tę linię!
                    dataGridViewZapomniani.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewZapomniani_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewZapomniani.Columns[e.ColumnIndex].Name == "Status")
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void FiltrujUzytkownikow(object sender, EventArgs e)
        {
            WczytajZapomnianych(
                txtFiltrImie.Text.Trim(),
                txtFiltrNazwisko.Text.Trim(),
                txtFiltrPesel.Text.Trim()
            );
        }

        private void btnWyczyscFiltry_Click(object sender, EventArgs e)
        {
            txtFiltrImie.Clear();
            txtFiltrNazwisko.Clear();
            txtFiltrPesel.Clear();
        }

        

        private void btnPowrot_Click_1(object sender, EventArgs e)
        {
            ListaUzytkownikow lista = new ListaUzytkownikow();
            lista.Show();
            this.Close();
        }
    }
}