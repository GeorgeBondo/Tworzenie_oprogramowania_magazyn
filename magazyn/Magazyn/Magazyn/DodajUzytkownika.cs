using Magazyn.Helpers;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class DodajUzytkownika : Form
    {
        public DodajUzytkownika()
        {
            InitializeComponent();
            InicjalizujComboPlec();
        }

        // Inicjalizacja ComboBox dla płci
        private void InicjalizujComboPlec()
        {
            comboPlec.Items.Add("Kobieta");
            comboPlec.Items.Add("Mężczyzna");
            comboPlec.SelectedIndex = 0;
        }

        // Przycisk "Zapisz"
        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (!WalidujDane()) return;
            if (!SprawdzUnikalnoscLoginu(txtLogin.Text)) return;
            if (!WalidujPESEL(txtPesel.Text))
            {
                MessageBox.Show("Niepoprawny numer PESEL!");
                return;
            }

            try
            {
                ZapiszUzytkownikaDoBazy();
                MessageBox.Show("Użytkownik dodany pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Przycisk "Anuluj"
        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Walidacja wymaganych pól
        private bool WalidujDane()
        {
            if (string.IsNullOrEmpty(txtLogin.Text) ||
                string.IsNullOrEmpty(txtImie.Text) ||
                string.IsNullOrEmpty(txtNazwisko.Text) ||
                string.IsNullOrEmpty(txtPesel.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtTelefon.Text) ||
                string.IsNullOrEmpty(txtMiejscowosc.Text) ||
                string.IsNullOrEmpty(txtKodPocztowy.Text) ||
                string.IsNullOrEmpty(txtNumerPosesji.Text))
            {
                MessageBox.Show("Wypełnij wszystkie wymagane pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Sprawdź unikalność loginu
        private bool SprawdzUnikalnoscLoginu(string login)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Uzytkownik WHERE Login = @Login";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login", login);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Login już istnieje w systemie!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
        }

        // Walidacja numeru PESEL
        private bool WalidujPESEL(string pesel)
        {
            if (pesel.Length != 11 || !pesel.All(char.IsDigit)) return false;

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += (pesel[i] - '0') * weights[i];
            }
            int controlDigit = (10 - (sum % 10)) % 10;
            return controlDigit == (pesel[10] - '0');
        }

        // Zapis do bazy z transakcją
        private void ZapiszUzytkownikaDoBazy()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Dodaj adres
                    int adresId = DodajAdres(conn, transaction);

                    // 2. Dodaj użytkownika
                    string query = @"
                        INSERT INTO Uzytkownik 
                        (Login, Haslo, Imię, Nazwisko, PESEL, Data_urodzenia, Płeć, Email, Numer_Telefonu, ID_Adres)
                        VALUES 
                        (@Login, @Haslo, @Imie, @Nazwisko, @PESEL, @DataUrodzenia, @Plec, @Email, @Telefon, @AdresId)";

                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@Login", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@Haslo", HaszujHaslo("tymczasowe_haslo")); // TODO: Zastąp rzeczywistym hasłem
                    cmd.Parameters.AddWithValue("@Imie", txtImie.Text);
                    cmd.Parameters.AddWithValue("@Nazwisko", txtNazwisko.Text);
                    cmd.Parameters.AddWithValue("@PESEL", txtPesel.Text);
                    cmd.Parameters.AddWithValue("@DataUrodzenia", txtDataUrodzenia.Value);
                    cmd.Parameters.AddWithValue("@Plec", comboPlec.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                    cmd.Parameters.AddWithValue("@AdresId", adresId);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Dodawanie adresu (metoda pomocnicza)
        private int DodajAdres(SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"
                INSERT INTO Adres 
                (Miejscowość, Kod_pocztowy, Ulica, Numer_posesji, Numer_lokalu)
                OUTPUT INSERTED.ID_Adres
                VALUES 
                (@Miejscowosc, @KodPocztowy, @Ulica, @NumerPosesji, @NumerLokalu)";

            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@Miejscowosc", txtMiejscowosc.Text);
            cmd.Parameters.AddWithValue("@KodPocztowy", txtKodPocztowy.Text);
            cmd.Parameters.AddWithValue("@Ulica", string.IsNullOrEmpty(txtUlica.Text) ? (object)DBNull.Value : txtUlica.Text);
            cmd.Parameters.AddWithValue("@NumerPosesji", txtNumerPosesji.Text);
            cmd.Parameters.AddWithValue("@NumerLokalu", string.IsNullOrEmpty(txtNumerLokalu.Text) ? (object)DBNull.Value : txtNumerLokalu.Text);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Metoda do haszowania hasła (do implementacji)
        private string HaszujHaslo(string haslo)
        {
            // Przykład użycia BCrypt.Net (wymaga instalacji paczki NuGet)
            // return BCrypt.Net.BCrypt.HashPassword(haslo);
            return "temp_haslo"; // Tymczasowe rozwiązanie
        }

        private void DodajUzytkownika_Load(object sender, EventArgs e)
        {

        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            PanelAdmina adminPanel = new PanelAdmina();
            adminPanel.Show();
            this.Hide();
        }
    }
}
