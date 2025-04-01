using Magazyn.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            btnWyczyśćFiltry.Click += btnWyczyśćFiltry_Click;
        }

        private void ListaUzytkownikow_Load(object sender, EventArgs e)
        {
            WczytajUzytkownikow();
        }

        private void WczytajUzytkownikow(string filtrImie = "", string filtrNazwisko = "", string filtrPesel = "")
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT 
                            ID_Uzytkownik AS 'ID',
                            Imię,
                            Nazwisko,
                            Email,
                            PESEL,
                            CASE 
                                WHEN ID_Status = 1 THEN 'Aktywny'
                                ELSE 'Nieaktywny'
                            END AS 'Status',
                            Data_zapomnienia
                        FROM Uzytkownik
                        WHERE 
                            ID_Status = 1 AND
                            (Imię LIKE @FiltrImie + '%' OR @FiltrImie = '') AND
                            (Nazwisko LIKE @FiltrNazwisko + '%' OR @FiltrNazwisko = '') AND
                            (PESEL LIKE @FiltrPesel + '%' OR @FiltrPesel = '')";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrImie", filtrImie);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrNazwisko", filtrNazwisko);
                    adapter.SelectCommand.Parameters.AddWithValue("@FiltrPesel", filtrPesel);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewUzytkownicy.DataSource = dt;
                    dataGridViewUzytkownicy.Columns["Data_zapomnienia"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrujUzytkownikow(object sender, EventArgs e)
        {
            WczytajUzytkownikow(
                txtFiltrImie.Text.Trim(),
                txtFiltrNazwisko.Text.Trim(),
                txtFiltrPesel.Text.Trim()
            );
        }

        private void btnWyczyśćFiltry_Click(object sender, EventArgs e)
        {
            txtFiltrImie.Clear();
            txtFiltrNazwisko.Clear();
            txtFiltrPesel.Clear();
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
            WczytajUzytkownikow();
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
                MessageBox.Show("Wybierz użytkownika z listy!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ZapomnijUzytkownika(int userId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"
                    UPDATE Uzytkownik 
                    SET 
                        ID_Status = 2,
                        Data_zapomnienia = GETDATE()
                    WHERE ID_Uzytkownik = @UserId";

                        cmd.Parameters.AddWithValue("@UserId", userId);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            // Ręczne odświeżenie danych
                            var bindingSource = new BindingSource();
                            bindingSource.DataSource = dataGridViewUzytkownicy.DataSource;
                            bindingSource.ResetBindings(false);

                            WczytajUzytkownikow();
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono użytkownika o podanym ID!",
                                          "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Błąd bazy danych: {sqlEx.Message}\nKod błędu: {sqlEx.Number}",
                              "Błąd SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ogólny: {ex.Message}",
                              "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    "Potwierdzenie operacji",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    ZapomnijUzytkownika(userId);
                    MessageBox.Show("Operacja zakończona pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}\nSzczegóły: {ex.StackTrace}",
                              "Krytyczny błąd aplikacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
