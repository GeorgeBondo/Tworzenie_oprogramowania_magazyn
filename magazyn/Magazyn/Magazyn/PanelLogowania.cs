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

        
        private void button_wyczysc_Click(object sender, EventArgs e)
        {
            textbox_login.Clear();
            textbox_haslo.Clear();
            textbox_login.Focus();
        }


        public void button_zaloguj_Click(object sender, EventArgs e)
        {
            string login = textbox_login.Text.Trim();
            string haslo = textbox_haslo.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Wprowadź login i hasło", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    
                    string query = @"
                SELECT U.*, S.Status 
                FROM Uzytkownik U
                LEFT JOIN Status S ON U.ID_Status = S.ID_Status
                WHERE U.Login = @Login";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Login", login);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           
                            string storedPassword = reader["Haslo"].ToString();

                            
                            if (haslo == storedPassword)
                            {
                                PanelAdmina adminPanel = new PanelAdmina();
                                adminPanel.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Błędne dane logowania", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


       
        private void button_haslo_Click(object sender, EventArgs e)
        {
            ResetHasla resetForm = new ResetHasla(this);
            resetForm.Show();
            this.Hide();
        }

        private void PanelLogowania_Load(object sender, EventArgs e)
        {

        }

        private void textbox_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_haslo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
