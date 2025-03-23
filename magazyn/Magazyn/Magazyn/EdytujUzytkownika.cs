using Magazyn.Helpers;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class EdytujUzytkownika : Form
    {
        private int userId;

        
        public EdytujUzytkownika(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            comboPlec.Items.Add("Kobieta");
            comboPlec.Items.Add("Mężczyzna");
            WczytajDaneUzytkownika(); 
        }

        private void WczytajDaneUzytkownika()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT U.*, A.* 
                    FROM Uzytkownik U 
                    INNER JOIN Adres A ON U.ID_Adres = A.ID_Adres 
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
                        comboPlec.SelectedItem = reader["Pieć"].ToString() == "K" ? "Kobieta" : "Mężczyzna";
                        txtDataUrodzenia.Value = Convert.ToDateTime(reader["Data_urodzenia"]);
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

            
            if (!Regex.IsMatch(txtPesel.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Nieprawidłowy numer PESEL!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
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
                MessageBox.Show("Nieprawidłowy format kodu pocztowego!\nPoprawny format: 00-000", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            if (!Regex.IsMatch(txtImie.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$") ||
                !Regex.IsMatch(txtNazwisko.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$") ||
                !Regex.IsMatch(txtMiejscowosc.Text, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$"))
            {
                MessageBox.Show("Imię, nazwisko i miejscowość mogą zawierać tylko litery, spacje, myślniki i apostrofy!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

     

        private void btnAnuluj_Click_1(object sender, EventArgs e)
        {
            ListaUzytkownikow lista = new ListaUzytkownikow();
            lista.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!WalidujDane()) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        
                        AktualizujAdres(conn, transaction);

                        
                        string query = @"
                            UPDATE Uzytkownik 
                            SET 
                                Imię = @Imie,
                                Nazwisko = @Nazwisko,
                                PESEL = @PESEL,
                                Data_urodzenia = @DataUrodzenia,
                                Pieć = @Plec,
                                Email = @Email,
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

        private void EdytujUzytkownika_Load(object sender, EventArgs e)
        {

        }
    }
}
