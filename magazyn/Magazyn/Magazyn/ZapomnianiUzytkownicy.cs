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
            dataGridViewZapomniani.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewZapomniani.MultiSelect = false;
            dataGridViewZapomniani.CellFormatting += dataGridViewZapomniani_CellFormatting;

            txtFiltrImie.TextChanged += FiltrujUzytkownikow;
            txtFiltrNazwisko.TextChanged += FiltrujUzytkownikow;
            txtFiltrPesel.TextChanged += FiltrujUzytkownikow;
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
                    U.ID_Uzytkownik AS 'ID',
                    U.Imię,
                    U.Nazwisko,
                    U.PESEL,
                    U.Email,
                    S.data_zapomnienia AS 'Data zapomnienia',
                    'Nieaktywny' AS 'Status'
                FROM Uzytkownik U
                INNER JOIN Status S ON U.ID_Status = S.ID_Status
                WHERE 
                    U.ID_Status = 2 AND
                    (U.Imię LIKE @FiltrImie + '%' OR @FiltrImie = '') AND
                    (U.Nazwisko LIKE @FiltrNazwisko + '%' OR @FiltrNazwisko = '') AND
                    (U.PESEL LIKE @FiltrPesel + '%' OR @FiltrPesel = '')";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrImie", filtrImie);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrNazwisko", filtrNazwisko);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrPesel", filtrPesel);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewZapomniani.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewZapomniani_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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


        private void dataGridViewZapomniani_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewZapomniani.Columns[e.ColumnIndex].Name == "Status")
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void btnPowrot_Click_1(object sender, EventArgs e)
        {
            ListaUzytkownikow lista = new ListaUzytkownikow();
            lista.Show();
            this.Close();
        }

        private void btnWyczyscFiltry_Click_1(object sender, EventArgs e)
        {
            txtFiltrImie.Clear();
            txtFiltrNazwisko.Clear();
            txtFiltrPesel.Clear();
        }
    }
}
