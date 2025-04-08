using Magazyn.Helpers;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class DodajUzytkownika : Form
    {
        public DodajUzytkownika()
        {
            InitializeComponent();
            comboPlec.Items.Add("Kobieta");
            comboPlec.Items.Add("Mężczyzna");
            comboPlec.SelectedIndex = 0;
        }

        private bool WalidujDane()
        {
            // Sprawdzanie wyamagnych pól
            if (string.IsNullOrWhiteSpace(txtImie.Text) ||
                string.IsNullOrWhiteSpace(txtNazwisko.Text) ||
                string.IsNullOrWhiteSpace(txtPesel.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                string.IsNullOrWhiteSpace(txtMiejscowosc.Text) ||
                string.IsNullOrWhiteSpace(txtKodPocztowy.Text) ||
                string.IsNullOrWhiteSpace(txtNumerPosesji.Text))
            {
                MessageBox.Show("Wypełnij wszystkie wymagane pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Walidacja pesel
            if (!Regex.IsMatch(txtPesel.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Nieprawidłowy numer PESEL!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Walidacja email
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Nieprawidłowy adres email!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Walidacja telefonu 
            if (!Regex.IsMatch(txtTelefon.Text, @"^\d{9}$"))
            {
                MessageBox.Show("Nieprawidłowy numer telefonu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //  Walidacja kod pocztowy
            if (!Regex.IsMatch(txtKodPocztowy.Text, @"^\d{2}-\d{3}$"))
            {
                MessageBox.Show("Nieprawidłowy format kodu pocztowego!\nPoprawny format: 00-000", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Walidacja liter w imieniu, nazwisku i miejscowości
            if (!Regex.IsMatch(txtImie.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$") ||
                !Regex.IsMatch(txtNazwisko.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$") ||
                !Regex.IsMatch(txtMiejscowosc.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$"))
            {
                MessageBox.Show("Imię, nazwisko i miejscowość mogą zawierać tylko litery, spacje, myślniki i apostrofy!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Walidacja hasła 
            if (!string.IsNullOrEmpty(txtHaslo.Text)) 
            {
                string haslo = txtHaslo.Text;
                bool isPasswordValid = Regex.IsMatch(haslo, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[-_!*#$&]).{8,15}$");

                if (!isPasswordValid)
                {
                    MessageBox.Show(
                        "Hasło musi spełniać wymagania:\n" +
                        "- 8-15 znaków\n" +
                        "- co najmniej 1 wielka litera\n" +
                        "- co najmniej 1 mała litera\n" +
                        "- co najmniej 1 cyfra\n" +
                        "- co najmniej 1 znak specjalny (-, _, !, *, #, $, &)",
                        "Błąd hasła",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
            }

            return true;
        }



        private int DodajAdres(SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO Adres 
                (Miejscowość, Kod_pocztowy, Ulica, Numer_posesji, Numer_lokalu)
                OUTPUT INSERTED.ID_Adres
                VALUES (@Miejscowosc, @KodPocztowy, @Ulica, @NumerPosesji, @NumerLokalu)";

            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@Miejscowosc", txtMiejscowosc.Text);
            cmd.Parameters.AddWithValue("@KodPocztowy", txtKodPocztowy.Text);
            cmd.Parameters.AddWithValue("@Ulica", string.IsNullOrEmpty(txtUlica.Text) ? DBNull.Value : (object)txtUlica.Text);
            cmd.Parameters.AddWithValue("@NumerPosesji", txtNumerPosesji.Text);
            cmd.Parameters.AddWithValue("@NumerLokalu", string.IsNullOrEmpty(txtNumerLokalu.Text) ? DBNull.Value : (object)txtNumerLokalu.Text);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int DodajUprawnienia(SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO Uprawnienia 
                (nazwa)
                OUTPUT INSERTED.ID_Uprawnienia
                VALUES (@Nazwa)";

            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@Nazwa", txtUprawnienia.Text);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private bool SprawdzUnikalnoscPesel(string pesel, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "SELECT COUNT(*) FROM Uzytkownik WHERE PESEL = @PESEL";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@PESEL", pesel);
            return (int)cmd.ExecuteScalar() == 0;
        }

        private void DodajUzytkownikaDoBazy(SqlConnection conn, SqlTransaction transaction, int adresId, int uprawnieniaId)
        {
            string query = @"
                INSERT INTO Uzytkownik 
                (Haslo, Imię, Nazwisko, PESEL, Data_urodzenia, Plec, Email, Numer_Telefonu, ID_Adres, ID_Status, ID_Uprawnienia, Login, Data_zapomnienia, ID_Użytkownik_zapomniany, Liczba_blednych_logowan, Data_blokady)
                VALUES 
                (@Haslo, @Imie, @Nazwisko, @PESEL, @DataUrodzenia, @Plec, @Email, @Telefon, @AdresId, 1, @UprawnieniaId, @Login, @Data_zapomnienia, @ID_Uzytkownik_zapomniany,@Liczba_blednych_logowan, @Data_blokady)";

            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@Haslo", txtHaslo.Text);
            cmd.Parameters.AddWithValue("@Imie", txtImie.Text);
            cmd.Parameters.AddWithValue("@Nazwisko", txtNazwisko.Text);
            cmd.Parameters.AddWithValue("@PESEL", txtPesel.Text);
            cmd.Parameters.AddWithValue("@DataUrodzenia", txtDataUrodzenia.Value);
            cmd.Parameters.AddWithValue("@Plec", comboPlec.SelectedItem.ToString() == "Kobieta" ? "K" : "M");
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            cmd.Parameters.AddWithValue("@AdresId", adresId);
            cmd.Parameters.AddWithValue("@UprawnieniaId", uprawnieniaId);
            cmd.Parameters.AddWithValue("@Login", loginTextBox.Text);

            cmd.ExecuteNonQuery();
        }

        

        private void btnWroc_Click(object sender, EventArgs e)
        {
            PanelAdmina adminPanel = new PanelAdmina();
            adminPanel.Show();
            this.Hide();
        }

        private void DodajUzytkownika_Load(object sender, EventArgs e)
        {

        }

        

        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
            comboPlec.SelectedIndex = 0;
            txtDataUrodzenia.Value = DateTime.Now;
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (!WalidujDane()) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction()) 
                    {
                        try
                        {
                            
                            int adresId = DodajAdres(conn, transaction);

                            
                            int uprawnieniaId = DodajUprawnienia(conn, transaction);

                            
                            if (!SprawdzUnikalnoscPesel(txtPesel.Text, conn, transaction))
                            {
                                MessageBox.Show("Użytkownik o podanym numerze PESEL już istnieje!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }

                            
                            DodajUzytkownikaDoBazy(conn, transaction, adresId, uprawnieniaId);

                            transaction.Commit();
                            MessageBox.Show("Użytkownik dodany pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                           
                            ListaUzytkownikow listaForm = new ListaUzytkownikow();
                            listaForm.Show();
                            this.Close(); 
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                finally
                {
                    conn.Close(); 
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHaslo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
