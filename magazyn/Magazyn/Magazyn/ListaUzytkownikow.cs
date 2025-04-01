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
            dataGridViewUzytkownicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUzytkownicy.MultiSelect = false;
            dataGridViewUzytkownicy.CellFormatting += dataGridViewUzytkownicy_CellFormatting;

            txtFiltrImie.TextChanged += FiltrujUzytkownikow;
            txtFiltrNazwisko.TextChanged += FiltrujUzytkownikow;
            txtFiltrPesel.TextChanged += FiltrujUzytkownikow;
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
                            END AS 'Status'
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

        
        private void btnWyczyscFiltry_Click(object sender, EventArgs e)
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
            PanelAdmina adminPanel = new PanelAdmina();
            adminPanel.Show();
            this.Hide();
        }

        public void OdswiezDane()
        {
            WczytajUzytkownikow();
        }

        private void btnOdswiez_Click(object sender, EventArgs e)
        {
            OdswiezDane();
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridViewUzytkownicy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika do edycji!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedUserId = Convert.ToInt32(dataGridViewUzytkownicy.SelectedRows[0].Cells["ID"].Value);
            EdytujUzytkownika edytujForm = new EdytujUzytkownika(selectedUserId);
            edytujForm.Show();
            this.Hide();
        }

        private void btnWyczyśćFiltry_Click(object sender, EventArgs e)
        {
                txtFiltrImie.Clear();
                txtFiltrNazwisko.Clear();
                txtFiltrPesel.Clear();
        }

        private void btnZapomniani_Click(object sender, EventArgs e)
        {
            ZapomnianiUzytkownicy zapomnianiForm = new ZapomnianiUzytkownicy();
            zapomnianiForm.Show();
            this.Hide();
        }

        private void btnZapomnij_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewUzytkownicy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedUserId = Convert.ToInt32(dataGridViewUzytkownicy.SelectedRows[0].Cells["ID"].Value);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            UPDATE Uzytkownik 
                            SET ID_Status = 2 
                            WHERE ID_Uzytkownik = @UserId;

                            UPDATE Status 
                            SET data_zapomnienia = GETDATE() 
                            WHERE ID_Status = 2;";

                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@UserId", selectedUserId);
                        cmd.ExecuteNonQuery();
                        transaction.Commit();

                        MessageBox.Show("Użytkownik został oznaczony jako zapomniany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        WczytajUzytkownikow();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
