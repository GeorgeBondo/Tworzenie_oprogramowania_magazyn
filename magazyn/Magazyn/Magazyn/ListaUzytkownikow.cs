using Magazyn.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class ListaUzytkownikow : Form
    {
        public ListaUzytkownikow()
        {
            InitializeComponent();
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
                    string query = @"
                        SELECT 
                            ID_Uzytkownik AS 'ID',
                            Imię,
                            Nazwisko,
                            Email,
                            Numer_Telefonu AS 'Telefon',
                            Data_urodzenia AS 'Data urodzenia',
                            PESEL,
                            Pieć,
                            ID_Status AS 'Status'
                        FROM Uzytkownik
                        WHERE ID_Status = 1"; 

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
