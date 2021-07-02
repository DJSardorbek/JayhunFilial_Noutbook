using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
namespace Jayhunelectro
{
    public partial class frmFakturaItem : MetroFramework.Forms.MetroForm
    {
        public frmFakturaItem()
        {
            InitializeComponent();
        }

        DBAccess objDBAccess = new DBAccess();
        public static string faktura_id = "";
        DataTable tbFakturaItem;
        DataTable tbFillProduct;
        CurrencyManager managerFakturaItem;
        MySqlCommand cmdUpdate;
        MySqlCommand cmdInsert;
        MySqlCommand cmdSelect;
        //public static float Summa = 0;
        //public static float sum = 0;
       
        private void FakturaItem_Load(object sender, EventArgs e)
        {
            /*objDBAccess.createConn();
            faktura_id = frmTovarQabuli.faktura_id;
            string query = "select fakturaItem.product_id,fakturaItem.faktura_id, product.name, fakturaItem.price, fakturaItem.quantity from fakturaItem " +
                "inner join product on fakturaItem.product_id= product.id where fakturaItem.faktura_id='"+faktura_id+"' order by fakturaItem.product_id";
            tbFakturaItem = new DataTable();
            objDBAccess.readDatathroughAdapter(query, tbFakturaItem);
            managerFakturaItem = (CurrencyManager)BindingContext[tbFakturaItem];
            dbgridFakturaItem.DataSource = tbFakturaItem;
            
            objDBAccess.closeConn();
            */

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            
            
            /*bool isopen = false;
            foreach (Form f1 in Application.OpenForms)
            {
                if (f1.Text == "Товар Кабули")
                {
                    isopen = true;
                    f1.BringToFront();
                    break;
                }
            }
            if (isopen == false)
            {
                frmTovarQabuli Qabul = new frmTovarQabuli();
                Qabul.Show();
            }
            this.Close();*/

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

           /* string status = frmTovarQabuli.status;
            if(int.Parse(status) == 1)
            {
                MessageBox.Show("Tovar qabul qilib bo'lingan", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                objDBAccess.createConn();
                string query = "select * from ProductFilial limit 1";
                tbFillProduct = new DataTable();
                objDBAccess.readDatathroughAdapter(query, tbFillProduct);
                int sum = 0, Summa = 0;
                if (tbFillProduct.Rows.Count==0)
                {
                    int count = managerFakturaItem.Count;
                    managerFakturaItem.Position = 0;
                    for(int i = 0; i<count; i++)
                    {

                        string product_id = tbFakturaItem.Rows[managerFakturaItem.Position]["product_id"].ToString();
                        string newprice = tbFakturaItem.Rows[managerFakturaItem.Position]["price"].ToString();
                        string newquantity = tbFakturaItem.Rows[managerFakturaItem.Position]["quantity"].ToString();

                        cmdInsert = new MySqlCommand("insert into ProductFilial values('"+(i+1)+"','" + product_id + "','" + newprice + "', '" + newquantity + "', '" + frmLogin.filial_id + "')");
                        objDBAccess.executeQuery(cmdInsert);
                        managerFakturaItem.Position++;
                    }
                    cmdUpdate = new MySqlCommand("Update Faktura set status=1 where filial_id='" + frmLogin.filial_id + "' and id='" + faktura_id + "'");
                    objDBAccess.executeQuery(cmdUpdate);
                    MessageBox.Show("Tovar muvaffaqiyatli qabul qilindi!");
                    objDBAccess.closeConn();
                    return;

                }
                else
                {
                    tbFillProduct.Clear();
                    
                    int count = managerFakturaItem.Count;
                    managerFakturaItem.Position = 0;
                    for (int i = 0; i < count; i++)
                    {
                        sum = 0;
                        string product_id = tbFakturaItem.Rows[managerFakturaItem.Position]["product_id"].ToString();
                        string newprice = tbFakturaItem.Rows[managerFakturaItem.Position]["price"].ToString();
                        string newquantity = tbFakturaItem.Rows[managerFakturaItem.Position]["quantity"].ToString();

                        string queryProductFilial = "select * from ProductFilial where filial_id='" + frmLogin.filial_id + "' and product_id='" + product_id + "'";
                        objDBAccess.readDatathroughAdapter(queryProductFilial, tbFillProduct);
                        if (tbFillProduct.Rows.Count == 1)
                        {
                            string oldquantity = tbFillProduct.Rows[0]["quantity"].ToString();
                            string oldprice = tbFillProduct.Rows[0]["price"].ToString();
                            int totalQuantity = int.Parse(oldquantity) + int.Parse(newquantity);
                            sum = (int.Parse(newprice) - int.Parse(oldprice)) * int.Parse(oldquantity);
                            Summa += sum;
                            cmdUpdate = new MySqlCommand("Update ProductFilial set price='" + newprice + "',quantity='" + totalQuantity + "' where filial_id='" + frmLogin.filial_id + "' and product_id='" + product_id + "'");
                            objDBAccess.executeQuery(cmdUpdate);
                            tbFillProduct.Clear();
                        }

                        else
                        {
                        cmdInsert = new MySqlCommand("insert into ProductFilial (product_id,price,quantity, filial_id) values('" + product_id + "','" + newprice + "', '" + newquantity + "', '" + frmLogin.filial_id + "')");
                        objDBAccess.executeQuery(cmdInsert);

                        }
                        managerFakturaItem.Position++;

                    }


                }
                cmdUpdate = new MySqlCommand("Update Faktura set status=1,difference='"+Summa+"' where filial_id='" + frmLogin.filial_id + "' and id='" + faktura_id + "'");
                objDBAccess.executeQuery(cmdUpdate);
                MessageBox.Show("Tovar muvaffaqiyatli qabul qilindi!");
                objDBAccess.closeConn();


    */
        }

        
    }
}
