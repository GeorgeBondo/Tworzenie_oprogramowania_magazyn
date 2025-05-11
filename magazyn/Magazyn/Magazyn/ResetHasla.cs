using Magazyn.Helpers;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class ResetHasla : Form
    {
        private PanelLogowania panelLogowania;

        public ResetHasla(PanelLogowania panelLogowania)
        {
            InitializeComponent();
            this.panelLogowania = panelLogowania;
        }

        private string GenerateNewPassword()
        {
            Random rand = new Random();
            char[] upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] lower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] digits = "0123456789".ToCharArray();
            char[] specials = "-_!*#$&".ToCharArray();

            char[] password = new char[10];

            // 3 wielkie litery
            for (int i = 0; i < 3; i++)
                password[i] = upper[rand.Next(upper.Length)];

            // 3 małe litery
            for (int i = 3; i < 6; i++)
                password[i] = lower[rand.Next(lower.Length)];

            // 2 cyfry
            for (int i = 6; i < 8; i++)
                password[i] = digits[rand.Next(digits.Length)];

            // 2 znaki specjalne
            for (int i = 8; i < 10; i++)
                password[i] = specials[rand.Next(specials.Length)];

            // Mieszanie znaków
            for (int i = 0; i < password.Length; i++)
            {
                int j = rand.Next(i, password.Length);
                (password[j], password[i]) = (password[i], password[j]);
            }

            return new string(password);
        }

        private void btnWygeneruj_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Wprowadź login i email!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Sprawdź czy użytkownik istnieje
                    string checkQuery = "SELECT COUNT(*) FROM Uzytkownik WHERE Login = @Login AND Email = @Email";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Login", login);
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Nieprawidłowy login lub email!", "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Generuj nowe hasło
                    string newPassword = GenerateNewPassword();

                    // Aktualizuj hasło w bazie
                    string updateQuery = "UPDATE Uzytkownik SET Haslo = @Haslo WHERE Login = @Login AND Email = @Email";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Haslo", newPassword);
                    updateCmd.Parameters.AddWithValue("@Login", login);
                    updateCmd.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Nowe hasło: {newPassword}\nHasło zostało zaktualizowane!", "Sukces",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Aktualizacja hasła nie powiodła się!", "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            panelLogowania.Show();
            this.Hide();
        }

        private void btnOdzyskaj_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Wprowadź login i email!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Pobierz hasło z bazy
                    string query = "SELECT Haslo FROM Uzytkownik WHERE Login = @Login AND Email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Email", email);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string haslo = result.ToString();
                        MessageBox.Show($"Twoje hasło: {haslo}", "Odzyskiwanie hasła",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nieprawidłowy login lub email!", "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}