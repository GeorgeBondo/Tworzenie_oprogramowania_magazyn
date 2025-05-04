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
using Magazyn.Helpers;

namespace Magazyn
{
    public partial class InformacjeUprawnienia : Form
    {
        private readonly int _uprawnienieId;
        private readonly ListaUprawnien _listaUprawnien;

        public InformacjeUprawnienia(int uprawnienieId, ListaUprawnien listaUprawnien)
        {
            InitializeComponent();
            _uprawnienieId = uprawnienieId;
            _listaUprawnien = listaUprawnien;

           
            

            WczytajSzczegoly();
        }

        private void BtnZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    UPDATE Uprawnienia 
                    SET opis = @Opis 
                    WHERE ID_Uprawnienia = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Opis", txtOpis.Text);
                        cmd.Parameters.AddWithValue("@Id", _uprawnienieId);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Zmiany zostały zapisane!", "Sukces",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się zapisać zmian!", "Błąd",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WczytajSzczegoly()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT nazwa, opis FROM Uprawnienia WHERE ID_Uprawnienia = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", _uprawnienieId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblNazwa.Text = reader["nazwa"].ToString();
                                txtOpis.Text = reader["opis"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nie znaleziono uprawnienia!", "Błąd",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnPowrot_Click(object sender, EventArgs e)
        {
            new ListaUprawnien().Show();
            this.Close();
        }

        private void lblNazwa_Click(object sender, EventArgs e)
        {

        }
    }
}
