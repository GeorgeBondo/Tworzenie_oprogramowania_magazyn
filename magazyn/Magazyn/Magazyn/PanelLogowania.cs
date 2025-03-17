using Magazyn.Helpers;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class PanelLogowania : Form
    {
        public PanelLogowania()
        {
            InitializeComponent();
        }

        // Przycisk "Wyczyść"
        private void button_wyczysc_Click(object sender, EventArgs e)
        {
            textbox_login.Clear();
            textbox_haslo.Clear();
            textbox_login.Focus();
        }

        // Przycisk "Zaloguj"
        private void button_zaloguj_Click(object sender, EventArgs e)
        {
            string login = textbox_login.Text.Trim();
            string haslo = textbox_haslo.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Wprowadź login i hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Sprawdź czy użytkownik istnieje i nie jest zapomniany
                    string query = @"
                        SELECT U.*, S.Status 
                        FROM Uzytkownik U
                        LEFT JOIN Status S ON U.ID_Status = S.ID_Status
                        WHERE U.ID_Uzytkownik = @Login"; // Używamy ID_Uzytkownik jako loginu
                    

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Login", login);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Sprawdź hasło (załóżmy że hasło jest zahashowane BCryptem)
                            string storedHash = reader["Haslo"].ToString();

                            if (BCrypt.Net.BCrypt.Verify(haslo, storedHash))
                            {
                                // Logowanie udane - otwórz panel administratora
                                PanelAdmina adminPanel = new PanelAdmina();
                                adminPanel.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Nieprawidłowe hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Użytkownik nie istnieje lub został zapomniany!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd logowania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Przycisk "Resetuj hasło"
        private void button_haslo_Click(object sender, EventArgs e)
        {
            ResetHasla resetForm = new ResetHasla(this);
            resetForm.Show();
            this.Hide();
        }

        private void PanelLogowania_Load(object sender, EventArgs e)
        {

        }
    }
}
