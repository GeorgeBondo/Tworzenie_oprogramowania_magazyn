using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazyn
{
    public partial class PanelLogowania : Form
    {
        public PanelLogowania()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_wyczysc_Click(object sender, EventArgs e)
        {
            textbox_login.Clear();
            textbox_haslo.Clear();
        }

        private void button_zaloguj_Click(object sender, EventArgs e)
        {

        }

        private void button_haslo_Click(object sender, EventArgs e)
        {
            ResetHasla resetForm = new ResetHasla(this);
            resetForm.Show();
            this.Hide();
        }
    }
}
