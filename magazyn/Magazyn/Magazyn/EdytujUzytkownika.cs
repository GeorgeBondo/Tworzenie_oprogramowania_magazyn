using Magazyn.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class EdytujUzytkownika : Form
    {
        public int userId;
        public Dictionary<string, string> originalData = new Dictionary<string, string>();

        public EdytujUzytkownika(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            comboPlec.Items.Add("Kobieta");
            comboPlec.Items.Add("Mężczyzna");
            LoadUprawnienia();
            WczytajDaneUzytkownika();
        }

        public void WczytajDaneUzytkownika()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT U.*, A.* 
                    FROM Uzytkownik U 
                    INNER JOIN Adres A ON U.ID_Adres = A.ID_Adres 
                    LEFT JOIN Uprawnienia Up ON U.ID_Uprawnienia = Up.ID_Uprawnienia
                    WHERE ID_Uzytkownik = @UserId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtImie.Text = reader["Imię"].ToString();
                        txtNazwisko.Text = reader["Nazwisko"].ToString();
                        txtPesel.Text = reader["PESEL"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtTelefon.Text = reader["Numer_Telefonu"].ToString();
                        txtMiejscowosc.Text = reader["Miejscowość"].ToString();
                        txtKodPocztowy.Text = reader["Kod_pocztowy"].ToString();
                        txtNumerPosesji.Text = reader["Numer_posesji"].ToString();
                        txtUlica.Text = reader["Ulica"].ToString();
                        txtNumerLokalu.Text = reader["Numer_lokalu"].ToString();
                        comboPlec.SelectedItem = reader["Plec"].ToString() == "K" ? "Kobieta" : "Mężczyzna";
                        txtDataUrodzenia.Value = Convert.ToDateTime(reader["Data_urodzenia"]);
                        comboUprawnienia.SelectedValue = reader["ID_Uprawnienia"];


                        originalData["Imie"] = txtImie.Text;
                        originalData["Nazwisko"] = txtNazwisko.Text;
                        originalData["Pesel"] = txtPesel.Text;
                        originalData["Email"] = txtEmail.Text;
                        originalData["Telefon"] = txtTelefon.Text;
                        originalData["Miejscowosc"] = txtMiejscowosc.Text;
                        originalData["KodPocztowy"] = txtKodPocztowy.Text;
                        originalData["NumerPosesji"] = txtNumerPosesji.Text;
                        originalData["Ulica"] = txtUlica.Text;
                        originalData["NumerLokalu"] = txtNumerLokalu.Text;
                        originalData["Plec"] = comboPlec.SelectedItem.ToString();
                        originalData["DataUrodzenia"] = txtDataUrodzenia.Value.ToString("yyyy-MM-dd");
                        originalData["Uprawnienia"] = comboUprawnienia.SelectedValue?.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd ładowania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AktualizujAdres(SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"
                UPDATE Adres 
                SET 
                    Miejscowość = @Miejscowosc,
                    Kod_pocztowy = @KodPocztowy,
                    Ulica = @Ulica,
                    Numer_posesji = @NumerPosesji,
                    Numer_lokalu = @NumerLokalu
                WHERE ID_Adres = (SELECT ID_Adres FROM Uzytkownik WHERE ID_Uzytkownik = @UserId)";

            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@Miejscowosc", txtMiejscowosc.Text);
            cmd.Parameters.AddWithValue("@KodPocztowy", txtKodPocztowy.Text);
            cmd.Parameters.AddWithValue("@Ulica", string.IsNullOrEmpty(txtUlica.Text) ? DBNull.Value : (object)txtUlica.Text);
            cmd.Parameters.AddWithValue("@NumerPosesji", txtNumerPosesji.Text);
            cmd.Parameters.AddWithValue("@NumerLokalu", string.IsNullOrEmpty(txtNumerLokalu.Text) ? DBNull.Value : (object)txtNumerLokalu.Text);
            cmd.Parameters.AddWithValue("@UserId", userId);

            cmd.ExecuteNonQuery();
        }

        private bool WalidujDane()
        {

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


            if (!WalidujPESEL(txtPesel.Text, txtDataUrodzenia.Value, comboPlec.SelectedItem.ToString()))
            {
                MessageBox.Show("Nieprawidłowy numer PESEL w stosunku do daty urodzenia lub płci!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            bool zmianaPesel = txtPesel.Text != originalData["Pesel"];
            bool zmianaData = txtDataUrodzenia.Value.ToString("yyyy-MM-dd") != originalData["DataUrodzenia"];
            bool zmianaPlec = comboPlec.SelectedItem.ToString() != originalData["Plec"];

            if (zmianaPesel && !zmianaData && !zmianaPlec)
            {
                MessageBox.Show("Zmiana PESEL wymaga aktualizacji daty urodzenia lub płci!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((zmianaData || zmianaPlec) && !zmianaPesel)
            {
                MessageBox.Show("Zmiana daty urodzenia lub płci wymaga aktualizacji PESEL!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || txtEmail.Text.Length > 255)
            {
                MessageBox.Show("Nieprawidłowy adres email!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (!Regex.IsMatch(txtTelefon.Text, @"^\d{9}$"))
            {
                MessageBox.Show("Nieprawidłowy numer telefonu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

 
            if (!Regex.IsMatch(txtKodPocztowy.Text, @"^\d{2}-\d{3}$"))
            {
                MessageBox.Show("Nieprawidłowy format kodu pocztowego!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


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

   
            int year = dataUrodzenia.Year;
            int month = dataUrodzenia.Month;
            int day = dataUrodzenia.Day;

            int peselMonth;
            if (year >= 2000 && year <= 2099)
                peselMonth = month + 20;
            else if (year >= 2100 && year <= 2199)
                peselMonth = month + 40;
            else if (year >= 2200 && year <= 2299)
                peselMonth = month + 60;
            else if (year >= 1800 && year <= 1899)
                peselMonth = month + 80;
            else 
                peselMonth = month;

            string expected = dataUrodzenia.ToString("yy") + peselMonth.ToString("00") + day.ToString("00");
            if (pesel.Substring(0, 6) != expected)
                return false;

            int genderDigit = int.Parse(pesel[9].ToString());
            bool isMale = genderDigit % 2 == 1;
            if ((plec == "Kobieta" && isMale) || (plec == "Mężczyzna" && !isMale))
                return false;

 
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(pesel[i].ToString()) * weights[i];
            int checksum = (10 - (sum % 10)) % 10;

            return checksum == int.Parse(pesel[10].ToString());
        }


        private bool CzyDokonanoZmian()
        {
            return txtImie.Text != originalData["Imie"] ||
                   txtNazwisko.Text != originalData["Nazwisko"] ||
                   txtPesel.Text != originalData["Pesel"] ||
                   txtEmail.Text != originalData["Email"] ||
                   txtTelefon.Text != originalData["Telefon"] ||
                   txtMiejscowosc.Text != originalData["Miejscowosc"] ||
                   txtKodPocztowy.Text != originalData["KodPocztowy"] ||
                   txtNumerPosesji.Text != originalData["NumerPosesji"] ||
                   txtUlica.Text != originalData["Ulica"] ||
                   txtNumerLokalu.Text != originalData["NumerLokalu"] ||
                   comboPlec.SelectedItem.ToString() != originalData["Plec"] ||
                   txtDataUrodzenia.Value.ToString("yyyy-MM-dd") != originalData["DataUrodzenia"] ||
                   comboUprawnienia.SelectedValue?.ToString() != originalData["Uprawnienia"];


        }

        private bool SprawdzUnikalnosc(SqlConnection conn, SqlTransaction transaction, string pole, string wartosc)
        {
            string query = $"SELECT COUNT(*) FROM Uzytkownik WHERE {pole} = @Wartosc AND ID_Uzytkownik != @UserId";
            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Wartosc", wartosc);
                cmd.Parameters.AddWithValue("@UserId", userId);
                return (int)cmd.ExecuteScalar() == 0;
            }
        }
        private void LoadUprawnienia()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT ID_Uprawnienia, nazwa FROM Uprawnienia";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboUprawnienia.DataSource = dt;
                comboUprawnienia.DisplayMember = "nazwa";
                comboUprawnienia.ValueMember = "ID_Uprawnienia";
            }
        }



        private void EdytujUzytkownika_Load(object sender, EventArgs e) { }
        private void txtImie_TextChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void btnZapisz_Click_1(object sender, EventArgs e)
        {
            if (!WalidujDane()) return;

            if (!CzyDokonanoZmian())
            {
                MessageBox.Show("Nie dokonano żadnych zmian!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {

                        string[] pola = { "PESEL", "Email", "Numer_Telefonu" };
                        string[] wartosci = { txtPesel.Text, txtEmail.Text, txtTelefon.Text };

                        for (int i = 0; i < pola.Length; i++)
                        {
                            if (!SprawdzUnikalnosc(conn, transaction, pola[i], wartosci[i]))
                            {
                                MessageBox.Show($"{pola[i]} musi być unikalny!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }
                        }

                        AktualizujAdres(conn, transaction);

                        string query = @"
                            UPDATE Uzytkownik 
                            SET 
                                Imię = @Imie,
                                Nazwisko = @Nazwisko,
                                PESEL = @PESEL,
                                Data_urodzenia = @DataUrodzenia,
                                Plec = @Plec,
                                Email = @Email,
                                ID_Uprawnienia = @Uprawnienia,
                                Numer_Telefonu = @Telefon
                            WHERE ID_Uzytkownik = @UserId";

                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@Imie", txtImie.Text);
                        cmd.Parameters.AddWithValue("@Nazwisko", txtNazwisko.Text);
                        cmd.Parameters.AddWithValue("@PESEL", txtPesel.Text);
                        cmd.Parameters.AddWithValue("@DataUrodzenia", txtDataUrodzenia.Value);
                        cmd.Parameters.AddWithValue("@Plec", comboPlec.SelectedItem.ToString() == "Kobieta" ? "K" : "M");
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Uprawnienia", comboUprawnienia.SelectedValue);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        MessageBox.Show("Dane zostały zaktualizowane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListaUzytkownikow lista = new ListaUzytkownikow();
                        lista.Show();
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

        private void btnAnuluj_Click_1(object sender, EventArgs e)
        {
            ListaUzytkownikow lista = new ListaUzytkownikow();
            lista.Show();
            this.Close();
        }
    }
}