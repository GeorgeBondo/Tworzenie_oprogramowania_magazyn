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
    public partial class PanelUżytkownika : Form
    {
        public PanelUżytkownika()
        {
            InitializeComponent();
        }

        private void btnZmien_Click(object sender, EventArgs e)
        {
            ZmianaHasłaPrzezUżytkownika form = new ZmianaHasłaPrzezUżytkownika();
            form.Show();
            this.Close();
        }

        private void btnWyloguj_Click(object sender, EventArgs e)
        {
            PanelLogowania loginForm = new PanelLogowania();
            loginForm.Show();
            this.Close();
        }
    }
}
