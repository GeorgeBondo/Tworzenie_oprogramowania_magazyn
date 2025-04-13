using Magazyn.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class ZapomnianiUzytkownicy : Form
    {
        public ZapomnianiUzytkownicy()
        {
            InitializeComponent();
            ConfigureDataGridView();
            WireUpEventHandlers();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewZapomniani.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewZapomniani.MultiSelect = false;
            dataGridViewZapomniani.AutoGenerateColumns = false;
            
            dataGridViewZapomniani.Columns.Add("ID", "ID");
            dataGridViewZapomniani.Columns.Add("ImieNazwisko", "Imię i nazwisko");
            dataGridViewZapomniani.Columns.Add("DataZapomnienia", "Data zapomnienia");

            dataGridViewZapomniani.Columns["ID"].DataPropertyName = "ID";
            dataGridViewZapomniani.Columns["ImieNazwisko"].DataPropertyName = "ImieNazwisko";
            dataGridViewZapomniani.Columns["DataZapomnienia"].DataPropertyName = "DataZapomnienia";
        }


        private void WireUpEventHandlers()
        {
            txtFiltrId.TextChanged += FiltrujUzytkownikow;
            dateTimePickerFiltr.ValueChanged += FiltrujUzytkownikow;
            btnWyczyscFiltry.Click += btnWyczyscFiltry_Click;
        }

        private void ZapomnianiUzytkownicy_Load(object sender, EventArgs e)
        {
            WczytajZapomnianych();
        }

        private void WczytajZapomnianych(string idFiltr = "", DateTime? dataFiltr = null)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT 
                    ID_Uzytkownik AS [ID],
                    'xxxxx xxxxx' AS [ImieNazwisko],
                    Data_zapomnienia AS [DataZapomnienia]
                FROM Uzytkownik
                WHERE 
                    ID_Status = 2
                    AND (ID_Uzytkownik = @IdFiltr OR @IdFiltr IS NULL)
                    AND (
                        (@DataFiltr IS NULL) 
                        OR 
                        CONVERT(DATE, Data_zapomnienia) = CONVERT(DATE, @DataFiltr)
                    )";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    if (int.TryParse(idFiltr, out int parsedId))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@IdFiltr", parsedId);
                    }
                    else
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@IdFiltr", DBNull.Value);
                    }

                    if (dateTimePickerFiltr.Checked && dataFiltr.HasValue)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@DataFiltr", dataFiltr.Value.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@DataFiltr", DBNull.Value);
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewZapomniani.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWyczyscFiltry_Click(object sender, EventArgs e)
        {
            txtFiltrId.Clear();
            dateTimePickerFiltr.Checked = false;
            WczytajZapomnianych();
        }

        private void btnPowrot_Click_1(object sender, EventArgs e)
        {
            new ListaUzytkownikow().Show();
            this.Close();
        }

        private void FiltrujUzytkownikow(object sender, EventArgs e)
        {
            DateTime? selectedDate = dateTimePickerFiltr.Checked
                ? dateTimePickerFiltr.Value.Date
                : (DateTime?)null;

            WczytajZapomnianych(
                txtFiltrId.Text.Trim(),
                selectedDate
            );
        }


    }
}