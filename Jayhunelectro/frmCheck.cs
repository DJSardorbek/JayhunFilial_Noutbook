using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jayhunelectro
{
    public partial class frmCheck : MetroFramework.Forms.MetroForm
    {
        public frmCheck()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCheck_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            frmSales.header = txtHeader.Text;
            frmSales.footer = txtFooter.Text;
            frmMainMenu.header = txtHeader.Text;
            frmMainMenu.footer = txtFooter.Text;
            Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
