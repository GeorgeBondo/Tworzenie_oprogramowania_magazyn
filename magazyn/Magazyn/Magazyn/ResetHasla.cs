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


     

        private string GenerujLosoweHaslo()
        {
            Random rand = new Random();
            string haslo = "";
            for (int i = 0; i < 10; i++)
            {
                haslo += rand.Next(0, 10).ToString();
            }
            return haslo;
        }

        private void ResetHasla_Load(object sender, EventArgs e)
        {

        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            panelLogowania.Show();
            this.Hide();
        }

        private void btnGeneruj_Click_1(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Wprowadź login i email!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                   
                    string query = "SELECT COUNT(*) FROM Uzytkownik WHERE ID_Uzytkownik = @ID_Uzytkownik AND Email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_Uzytkownik", login);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Nieprawidłowy login lub email!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                   
                    string noweHaslo = GenerujLosoweHaslo();

                   
                    NoweHasloForm noweHasloForm = new NoweHasloForm(noweHaslo, login);
                    noweHasloForm.ShowDialog();

                    this.Close();
                    panelLogowania.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
