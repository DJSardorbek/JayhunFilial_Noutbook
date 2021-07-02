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
    public partial class frmCashCheck : MetroFramework.Forms.MetroForm
    {
        public frmCashCheck()
        {
            InitializeComponent();
        }

        
        private void frmCashCheck_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            frmCashDesk.header = txtHeader.Text;
            frmCashDesk.footer = txtFooter.Text;
            frmMainMenu.headerCash = txtHeader.Text;
            frmMainMenu.footerCash = txtFooter.Text;
            Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
