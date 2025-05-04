using Magazyn.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class ListaUzytkownikow : Form
    {
        public ListaUzytkownikow()
        {
            InitializeComponent();
            ConfigureDataGridView();
            WireUpEventHandlers();
            LoadUprawnienia();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewUzytkownicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUzytkownicy.MultiSelect = false;
            dataGridViewUzytkownicy.CellFormatting += dataGridViewUzytkownicy_CellFormatting;
        }

        private void WireUpEventHandlers()
        {
            txtFiltrImie.TextChanged += FiltrujUzytkownikow;
            txtFiltrNazwisko.TextChanged += FiltrujUzytkownikow;
            txtFiltrPesel.TextChanged += FiltrujUzytkownikow;
            comboUprawnienia.SelectedIndexChanged += FiltrujUzytkownikow;
            btnWyczyśćFiltry.Click += btnWyczyśćFiltry_Click;
        }

        private void LoadUprawnienia()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    string query = "SELECT ID_Uprawnienia, nazwa FROM Uprawnienia";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow row = dt.NewRow();
                    row["nazwa"] = "Wszystkie";
                    row["ID_Uprawnienia"] = -1;
                    dt.Rows.InsertAt(row, 0);

                    comboUprawnienia.DataSource = dt;
                    comboUprawnienia.DisplayMember = "nazwa";
                    comboUprawnienia.ValueMember = "ID_Uprawnienia";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd ładowania uprawnień: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListaUzytkownikow_Load(object sender, EventArgs e)
        {
            WczytajUzytkownikow();
        }

        private void WczytajUzytkownikow(bool forceReload = false)
        {
            try
            {
                var dt = new DataTable();
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT 
                    u.ID_Uzytkownik AS ID,
                    u.Imię,
                    u.Nazwisko,
                    u.Email,
                    u.PESEL,
                    CASE WHEN u.ID_Status = 1 THEN 'Aktywny' ELSE 'Nieaktywny' END AS Status,
                    CASE u.ID_Uprawnienia
                        WHEN 1 THEN 'Administrator'
                        WHEN 2 THEN 'Magazynier'
                        WHEN 3 THEN 'Brygadzista'
                        WHEN 4 THEN 'Kierownik'
                        WHEN 5 THEN 'Kontroler jakości'
                        ELSE 'Brak uprawnienia'
                    END AS Uprawnienie,
                    u.Data_zapomnienia
                FROM Uzytkownik u
                WHERE 
                    u.ID_Status = 1
                    AND (u.Imię     LIKE @FiltrImie     + '%' OR @FiltrImie     = '')
                    AND (u.Nazwisko LIKE @FiltrNazwisko + '%' OR @FiltrNazwisko = '')
                    AND (u.PESEL    LIKE @FiltrPesel    + '%' OR @FiltrPesel    = '')
                    AND (@Uprawnienia = -1 OR u.ID_Uprawnienia = @Uprawnienia)
                    AND NEWID() IS NOT NULL;";

                    using (var adapter = new SqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@FiltrImie", txtFiltrImie.Text.Trim());
                        adapter.SelectCommand.Parameters.AddWithValue("@FiltrNazwisko", txtFiltrNazwisko.Text.Trim());
                        adapter.SelectCommand.Parameters.AddWithValue("@FiltrPesel", txtFiltrPesel.Text.Trim());

                        var drv = comboUprawnienia.SelectedItem as DataRowView;
                        int filtrUprawnienia = -1;
                        if (drv != null)
                            filtrUprawnienia = Convert.ToInt32(drv["ID_Uprawnienia"]);

                        adapter.SelectCommand.Parameters.AddWithValue("@Uprawnienia", filtrUprawnienia);

                        adapter.Fill(dt);
                    }
                }

                dataGridViewUzytkownicy.DataSource = dt;
                if (dataGridViewUzytkownicy.Columns.Contains("Data_zapomnienia"))
                    dataGridViewUzytkownicy.Columns["Data_zapomnienia"].Visible = false;
                dataGridViewUzytkownicy.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania danych: {ex.Message}", "Błąd",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FiltrujUzytkownikow(object sender, EventArgs e)
        {
            WczytajUzytkownikow();
        }

        private void btnWyczyśćFiltry_Click(object sender, EventArgs e)
        {
            txtFiltrImie.Clear();
            txtFiltrNazwisko.Clear();
            txtFiltrPesel.Clear();
            comboUprawnienia.SelectedIndex = 0;
        }

        private void dataGridViewUzytkownicy_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUzytkownicy.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value?.ToString() == "Aktywny")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnWroc_Click(object sender, EventArgs e)
        {
            OpenForm(new PanelAdmina());
        }

        private void btnOdswiez_Click(object sender, EventArgs e)
        {
            WczytajUzytkownikow(true);
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (!ValidateSelection()) return;
            int selectedUserId = GetSelectedUserId();
            OpenForm(new EdytujUzytkownika(selectedUserId));
        }

        private void btnZapomniani_Click(object sender, EventArgs e)
        {
            OpenForm(new ZapomnianiUzytkownicy());
        }

        private bool ValidateSelection()
        {
            if (dataGridViewUzytkownicy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika z listy!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private int GetSelectedUserId()
        {
            return Convert.ToInt32(dataGridViewUzytkownicy.SelectedRows[0].Cells["ID"].Value);
        }

        private void OpenForm(Form form)
        {
            form.Show();
            this.Hide();
        }

        private string GeneratePESELForForgottenUser()
        {
            Random rand = new Random();
            string basePESEL = "002101"; 
            string randomPart = rand.Next(0, 1000).ToString("D3");
            int genderDigit;

            do
            {
                genderDigit = rand.Next(0, 10);
            } while (genderDigit % 2 == 0);

            string peselWithoutChecksum = basePESEL + randomPart + genderDigit;

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(peselWithoutChecksum[i].ToString()) * weights[i];

            int checksum = (10 - (sum % 10)) % 10;

            return peselWithoutChecksum + checksum.ToString();
        }

        private void ZapomnijUzytkownika(int userId)
        {
            try
            {
                string newPesel = GeneratePESELForForgottenUser();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = transaction;
                                cmd.CommandText = @"
                                    UPDATE Uzytkownik 
                                    SET 
                                        Imię = 'xxxxx',
                                        Nazwisko = 'xxxxx',
                                        PESEL = @NewPESEL,
                                        Data_urodzenia = '2000-01-01',
                                        Plec = 'M',
                                        ID_Status = 2,
                                        Data_zapomnienia = GETDATE(),
                                        ID_Uprawnienia = NULL
                                    WHERE ID_Uzytkownik = @UserId";

                                cmd.Parameters.AddWithValue("@NewPESEL", newPesel);
                                cmd.Parameters.AddWithValue("@UserId", userId);

                                int affectedRows = cmd.ExecuteNonQuery();

                                if (affectedRows == 0)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Nie znaleziono użytkownika!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                transaction.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Błąd transakcji: {ex.Message}");
                        }
                    }
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 2627)
            {
                MessageBox.Show("Wygenerowany PESEL już istnieje. Spróbuj ponownie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZapomnij_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSelection()) return;

                var selectedRow = dataGridViewUzytkownicy.SelectedRows[0];
                int userId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string userName = $"{selectedRow.Cells["Imię"].Value} {selectedRow.Cells["Nazwisko"].Value}";

                var result = MessageBox.Show(
                    $"Czy na pewno chcesz oznaczyć użytkownika {userName} jako zapomnianego?",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    ZapomnijUzytkownika(userId);
                    MessageBox.Show("Użytkownik został zapomniany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Krytyczny błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}