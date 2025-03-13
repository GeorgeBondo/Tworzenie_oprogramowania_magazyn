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
    public partial class ResetHasla : Form
    {
        private PanelLogowania panelLogowania;

        public ResetHasla(PanelLogowania logowanie)
        {
            InitializeComponent(); 
            panelLogowania = logowanie;
        }

        
        private void button_powrot_Click(object sender, EventArgs e)
        {
            panelLogowania.Show();
            this.Close();
        }
    }
}
