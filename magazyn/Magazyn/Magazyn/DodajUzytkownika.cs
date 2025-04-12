using Magazyn.Helpers;
using System;
using System.Data.SqlClient;
using System.Linq;
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
            // Sprawdzenie wymaganych pól
            if (string.IsNullOrWhiteSpace(loginTextBox.Text) ||
                string.IsNullOrWhiteSpace(txtImie.Text) ||
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

            // Walidacja loginu
            if (!Regex.IsMatch(loginTextBox.Text, @"^[a-zA-Z0-9_]{3,20}$"))
            {
                MessageBox.Show("Login może zawierać tylko litery, cyfry i podkreślenia (3-20 znaków)!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Walidacja PESEL
            if (!WalidujPESEL(txtPesel.Text, txtDataUrodzenia.Value, comboPlec.SelectedItem.ToString()))
            {
                MessageBox.Show("Nieprawidłowy numer PESEL!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Walidacja email
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || txtEmail.Text.Length > 255)
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

            // Walidacja kodu pocztowego
            if (!Regex.IsMatch(txtKodPocztowy.Text, @"^\d{2}-\d{3}$"))
            {
                MessageBox.Show("Nieprawidłowy format kodu pocztowego!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Walidacja danych osobowych
            if (!Regex.IsMatch(txtImie.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$") ||
                !Regex.IsMatch(txtNazwisko.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$") ||
                !Regex.IsMatch(txtMiejscowosc.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$"))
            {
                MessageBox.Show("Nieprawidłowe znaki w polach tekstowych!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool WalidujPESEL(string pesel, DateTime dataUrodzenia, string plec)
        {
            if (pesel.Length != 11 || !pesel.All(char.IsDigit))
                return false;

            // Sprawdzenie daty urodzenia
            string rr = dataUrodzenia.ToString("yy");
            string mm = dataUrodzenia.Month.ToString("00");
            string dd = dataUrodzenia.Day.ToString("00");
            if (pesel.Substring(0, 6) != rr + mm + dd)
                return false;

            // Sprawdzenie płci
            int genderDigit = int.Parse(pesel[9].ToString());
            bool isMale = genderDigit % 2 == 1;
            if ((plec == "Kobieta" && isMale) || (plec == "Mężczyzna" && !isMale))
                return false;

            // Sprawdzenie sumy kontrolnej
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(pesel[i].ToString()) * weights[i];

            int checksum = (10 - (sum % 10)) % 10;
            return checksum == int.Parse(pesel[10].ToString());
        }

        private int DodajAdres(SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"INSERT INTO Adres 
                           (Miejscowość, Kod_pocztowy, Ulica, Numer_posesji, Numer_lokalu)
                           OUTPUT INSERTED.ID_Adres
                           VALUES (@Miejscowosc, @KodPocztowy, @Ulica, @NumerPosesji, @NumerLokalu)";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Miejscowosc", txtMiejscowosc.Text);
                cmd.Parameters.AddWithValue("@KodPocztowy", txtKodPocztowy.Text);
                cmd.Parameters.AddWithValue("@Ulica", string.IsNullOrEmpty(txtUlica.Text) ? DBNull.Value : (object)txtUlica.Text);
                cmd.Parameters.AddWithValue("@NumerPosesji", txtNumerPosesji.Text);
                cmd.Parameters.AddWithValue("@NumerLokalu", string.IsNullOrEmpty(txtNumerLokalu.Text) ? DBNull.Value : (object)txtNumerLokalu.Text);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void DodajUzytkownikaDoBazy(SqlConnection conn, SqlTransaction transaction, int adresId)
        {
            string query = @"INSERT INTO Uzytkownik 
                           (Login, Haslo, Imię, Nazwisko, PESEL, Data_urodzenia, Plec, Email, Numer_Telefonu, ID_Adres, ID_Status)
                           VALUES 
                           (@Login, @Haslo, @Imie, @Nazwisko, @PESEL, @DataUrodzenia, @Plec, @Email, @Telefon, @AdresId, 1)";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Login", loginTextBox.Text);
                cmd.Parameters.AddWithValue("@Haslo", txtHaslo.Text);
                cmd.Parameters.AddWithValue("@Imie", txtImie.Text);
                cmd.Parameters.AddWithValue("@Nazwisko", txtNazwisko.Text);
                cmd.Parameters.AddWithValue("@PESEL", txtPesel.Text);
                cmd.Parameters.AddWithValue("@DataUrodzenia", txtDataUrodzenia.Value);
                cmd.Parameters.AddWithValue("@Plec", comboPlec.SelectedItem.ToString() == "Kobieta" ? "K" : "M");
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                cmd.Parameters.AddWithValue("@AdresId", adresId);

                cmd.ExecuteNonQuery();
            }
        }

        private bool SprawdzUnikalnosc(SqlConnection conn, SqlTransaction transaction, string pole, string wartosc)
        {
            string query = $"SELECT COUNT(*) FROM Uzytkownik WHERE {pole} = @Wartosc";
            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Wartosc", wartosc);
                return (int)cmd.ExecuteScalar() == 0;
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (!WalidujDane()) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Sprawdzenie unikalności
                        string[] pola = { "Login", "PESEL", "Email" };
                        string[] wartosci = { loginTextBox.Text, txtPesel.Text, txtEmail.Text };

                        for (int i = 0; i < pola.Length; i++)
                        {
                            if (!SprawdzUnikalnosc(conn, transaction, pola[i], wartosci[i]))
                            {
                                MessageBox.Show($"{pola[i]} musi być unikalny!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }
                        }

                        int adresId = DodajAdres(conn, transaction);
                        DodajUzytkownikaDoBazy(conn, transaction, adresId);

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
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            PanelAdmina adminPanel = new PanelAdmina();
            adminPanel.Show();
            this.Hide();
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

        // Pozostałe metody
        private void DodajUzytkownika_Load(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void loginTextBox_TextChanged(object sender, EventArgs e) { }
        private void txtHaslo_TextChanged(object sender, EventArgs e) { }

    }
}