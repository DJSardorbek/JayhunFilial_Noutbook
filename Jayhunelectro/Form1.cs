using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jayhunelectro
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public static string sellar_id, staff_id;// filial_id;
        public static string sellar = "";
        public static string mac_address = "";
        public static string password1 = "";
        DBAccess objDBAccess = new DBAccess();
        DataTable tbPassword;
        
        private void mchboxkurish_CheckedChanged(object sender, EventArgs e)
        {
            if(mtxtPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        public void GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty) // only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            mac_address = sMacAddress;
        }
        
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Паролни киритинг!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //string ip_address = "";
            //try
            //{
            //    //Pass the file path and file name to the StreamReader constructor
            //    StreamReader sr = new StreamReader("ip_address.txt");
            //    //Read the first line of text
            //    ip_address = sr.ReadLine();
            //    //close the file
            //    sr.Close();
            //    DBAccess.ip_address = ip_address;
            //}
            //catch (Exception e1)
            //{
            //    Console.WriteLine("Exception: " + e1.Message);
            //}
            
            string password = txtPassword.Text;
            string query = "select * from userprofile where password='" + password + "'";
            objDBAccess.createConn();
            tbPassword = new DataTable();
            objDBAccess.readDatathroughAdapter(query, tbPassword);
            objDBAccess.closeConn();
            if (tbPassword.Rows.Count == 1)
            {
                sellar_id = tbPassword.Rows[0]["id"].ToString();
                staff_id = tbPassword.Rows[0]["staff_id"].ToString();
                sellar = tbPassword.Rows[0]["first_name"].ToString();
                password1 = tbPassword.Rows[0]["password"].ToString();
                GetMACAddress();
                //filial_id = tbPassword.Rows[0]["filial_id"].ToString();
                bool isopen = false;
                foreach (Form f1 in Application.OpenForms)
                {
                    if (f1.Text == ".")
                    {
                        isopen = true;
                        f1.BringToFront();
                        break;
                    }
                }
                if (isopen == false)
                {
                    frmMainMenu f2 = new frmMainMenu();
                    f2.Show();
                }
                tbPassword.Clear();
                tbPassword.Dispose();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("парол нотўгри киритилди, кайтадан уриниб кўринг!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                iconButton1_Click(sender, e);
                e.Handled = true;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }
        int esc = 0;
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}

