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
    public partial class PanelAdmina : Form
    {
        public PanelAdmina()
        {
            InitializeComponent();
        }

        private void button_testujPolaczenie_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Połączenie z bazą danych udane! 🎉", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd połączenia: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnWyloguj_Click(object sender, EventArgs e)
        {
            PanelLogowania loginForm = new PanelLogowania();
            loginForm.Show();
            this.Close(); 
        }


        private void btnDodaj_Click(object sender, EventArgs e)
        {
            DodajUzytkownika dodajForm = new DodajUzytkownika();
            dodajForm.Show();
            this.Hide(); 
        }


        private void btnLista_Click_1(object sender, EventArgs e)
        {
            ListaUzytkownikow listaForm = new ListaUzytkownikow();
            listaForm.Show();
            this.Hide();
        }

        private void PanelAdmina_Load(object sender, EventArgs e)
        {

        }
    }
    
}
