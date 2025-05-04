using Magazyn.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class ListaUprawnien : Form
    {
        public ListaUprawnien()
        {
            InitializeComponent();
            
            WczytajUprawnienia();
        }

        

        private void WczytajUprawnienia()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT ID_Uprawnienia, nazwa FROM Uprawnienia";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewUprawnienia.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUprawnienia.SelectedRows.Count == 0) return;

                int selectedId = Convert.ToInt32(dataGridViewUprawnienia.SelectedRows[0].Cells["ID_Uprawnienia"].Value);

                
                InformacjeUprawnienia form = new InformacjeUprawnienia(selectedId, this); 
                this.Hide();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWrocUpr_Click(object sender, EventArgs e)
        {
            new PanelAdmina().Show();
            this.Close();
        }
    }
}
