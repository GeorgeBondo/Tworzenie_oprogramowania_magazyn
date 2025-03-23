using Magazyn.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class ListaUzytkownikow : Form
    {
        public ListaUzytkownikow()
        {
            InitializeComponent();
            dataGridViewUzytkownicy.CellFormatting += dataGridViewUzytkownicy_CellFormatting;
        }



        private void ListaUzytkownikow_Load(object sender, EventArgs e)
        {
            WczytajUzytkownikow();
        }

        private void WczytajUzytkownikow()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    // Zapytanie z dynamicznym statusem
                    string query = @"
                        SELECT 
                            ID_Uzytkownik AS 'ID',
                            Imię,
                            Nazwisko,
                            Email,
                            Numer_Telefonu AS 'Telefon',
                            Data_urodzenia AS 'Data urodzenia',
                            CASE 
                                WHEN ID_Status = 1 THEN 'Aktywny'
                                ELSE 'Nieaktywny'
                            END AS 'Status'
                        FROM Uzytkownik";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewUzytkownicy.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Formatowanie koloru dla kolumny "Status"
        private void dataGridViewUzytkownicy_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUzytkownicy.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value?.ToString() == "Aktywny")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            PanelAdmina adminPanel = new PanelAdmina();
            adminPanel.Show();
            this.Hide();
        }

        public void OdswiezDane()
        {
            WczytajUzytkownikow();
        }

        private void btnOdswiez_Click(object sender, EventArgs e)
        {
            OdswiezDane();
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            EdytujUzytkownika edytujForm = new EdytujUzytkownika();
            edytujForm.Show();
            this.Hide();
        }
    }
}
