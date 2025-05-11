using Magazyn.Helpers;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class ZmianaHasłaPrzezUżytkownika : Form
    {
        public ZmianaHasłaPrzezUżytkownika()
        {
            InitializeComponent();
        }

        private bool SprawdzStareHaslo(string login, string stareHaslo)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT Haslo FROM Uzytkownik 
                                   WHERE Login = @Login";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Login", login);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string poprawneHaslo = reader["Haslo"].ToString();
                            return stareHaslo == poprawneHaslo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd weryfikacji: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool WalidujNoweHaslo(string haslo)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-]).{8,15}$");
            return regex.IsMatch(haslo);
        }

        private void ZaktualizujHaslo(string login, string noweHaslo)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE Uzytkownik 
                                   SET Haslo = @NoweHaslo 
                                   WHERE Login = @Login";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NoweHaslo", noweHaslo);
                    cmd.Parameters.AddWithValue("@Login", login);

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Hasło zostało zmienione!", "Sukces",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono użytkownika!", "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd aktualizacji: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNoweHaslo_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string stareHaslo = txtStareHaslo.Text;
            string noweHaslo = txtNoweHaslo.Text;

            // Walidacja pustych pól
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Wprowadź login!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(stareHaslo))
            {
                MessageBox.Show("Wprowadź stare hasło!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(noweHaslo))
            {
                MessageBox.Show("Wprowadź nowe hasło!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Weryfikacja starego hasła
            if (!SprawdzStareHaslo(login, stareHaslo))
            {
                MessageBox.Show("Nieprawidłowe stare hasło lub login!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Walidacja nowego hasła
            if (!WalidujNoweHaslo(noweHaslo))
            {
                MessageBox.Show("Nowe hasło musi zawierać:\n- 8-15 znaków\n- 1 wielką literę\n- 1 małą literę\n- 1 znak specjalny",
                    "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aktualizacja hasła
            ZaktualizujHaslo(login, noweHaslo);
        }
    }
}