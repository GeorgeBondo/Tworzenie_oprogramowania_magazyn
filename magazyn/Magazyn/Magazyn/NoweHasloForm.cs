using Magazyn.Helpers;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class NoweHasloForm : Form
    {
        private string noweHaslo;
        private string login;

        public NoweHasloForm(string haslo, string login)
        {
            InitializeComponent();
            this.noweHaslo = haslo;
            this.login = login;
            lblHaslo.Text = $"Twoje nowe hasło: {haslo}";
        }

        private void NoweHasloForm_Load(object sender, EventArgs e)
        {

        }
        private void btnKopiuj_Click_1(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(noweHaslo);

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string query = "UPDATE Uzytkownik SET Haslo = @Haslo WHERE ID_Uzytkownik = @ID_Uzytkownik";
                            SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@Haslo", noweHaslo);
                            cmd.Parameters.AddWithValue("@ID_Uzytkownik", login);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            transaction.Commit();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Hasło zostało pomyślnie zaktualizowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Nie znaleziono użytkownika o podanym ID.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Błąd podczas aktualizacji hasła: {ex.Message}");
                            MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
