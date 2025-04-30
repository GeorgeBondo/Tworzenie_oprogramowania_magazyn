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

        private void btnWrocUpr_Click(object sender, EventArgs e)
        {
            new PanelAdmina().Show();
            this.Close();
        }
    }
}
