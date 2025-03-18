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

        private void btnKopiuj_Click(object sender, EventArgs e)
        {
            try
            {
                // Kopiuj do schowka
                Clipboard.SetText(noweHaslo);

                // Aktualizuj hasło w bazie
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Uzytkownik SET Haslo = @Haslo WHERE ID_Uzytkownik = @ID_Uzytkownik";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Haslo", noweHaslo);
                    cmd.Parameters.AddWithValue("@ID_Uzytkownik", login);
                    cmd.ExecuteNonQuery();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NoweHasloForm_Load(object sender, EventArgs e)
        {

        }
    }
}
