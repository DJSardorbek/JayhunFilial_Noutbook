using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Jayhunelectro
{
    public partial class frmSaleQuantity : MetroFramework.Forms.MetroForm
    {
        public string barcode = "";
        public string price = "";
        public string oldquantity = "";
        public string product_id = "";
        public string name = "";
        MySqlCommand cmdProduct;
        DBAccess objDBAccess = new DBAccess();
        public frmSaleQuantity()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        MySqlDataAdapter adapterSaleQuantity;
        MySqlCommand cmdShop, cmdCart;
        DataTable tbSaleQuantity, tbID;
        CurrencyManager managerSaleQuantity;


        private void frmSaleQuantity_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            txtProduct.Text = name;
            txtPrice.Text = frmSales.price;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            /*if (txtQuantity.Text!="")
            {
                double parsedValue;
                if (!double.TryParse(txtQuantity.Text, out parsedValue))
                {
                    txtQuantity.Clear();
                    return;
                }
                double quantity = double.Parse(txtQuantity.Text, CultureInfo.InvariantCulture);
                double total = quantity * double.Parse(txtPrice.Text, CultureInfo.InvariantCulture);
                txtTotal.Text = total.ToString();
            }
            
            else
            {
                txtTotal.Text = "";
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tovar bekor qilindi!");
            this.Close();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSaleQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iconButton1_Click(sender, e);
            }
            if(e.KeyCode == Keys.Escape)
            {
                iconButton2_Click(sender, e);
            }
        }

        public void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "") return;
            if(txtQuantity.Text.IndexOf(',') >-1)
            {
                MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Clear();
                return;
            }
            
            if (txtQuantity.Text != "")
            {
                double quantity = double.Parse(txtQuantity.Text, CultureInfo.InvariantCulture);
                double total = quantity * double.Parse(txtPrice.Text, CultureInfo.InvariantCulture);
                txtTotal.Text = total.ToString();
            }
            objDBAccess.createConn();
            int ID = frmSales.shopID;
            string rq = txtQuantity.Text;
            if(oldquantity.IndexOf(',') > -1)
            {
                int index_oldquantity = oldquantity.IndexOf(',');
                string first_oldquantity = oldquantity.Substring(0, index_oldquantity);
                string last_oldquantity = oldquantity.Substring(index_oldquantity + 1);
                string first_lastQuantity = first_oldquantity + "." + last_oldquantity;
                oldquantity = string.Empty;
                oldquantity = first_lastQuantity;
            }
            double rq1 = double.Parse(oldquantity, CultureInfo.InvariantCulture);
            double rq2 = double.Parse(rq, CultureInfo.InvariantCulture);
            double resultQuantity = rq1 - rq2; //double.Parse(oldquantity, CultureInfo.CurrentCulture) - double.Parse(rq, CultureInfo.CurrentCulture);
            if(resultQuantity<0)
            {
                MessageBox.Show("Махсулот йэтарли эмас\n Бизда махсулот колдиги '" + oldquantity+ "'", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            // Agar ushbu maxsulotdan avval korzinkaga olingan bo'lsa , avvalgini miqdori va umumiy_summasini update qilamiz
            string queryCart = "select * from cart where shop_id='" + ID + "' and product_id='" + product_id + "'";
            DataTable tbCartFill = new DataTable();
            objDBAccess.readDatathroughAdapter(queryCart, tbCartFill);
            if (tbCartFill.Rows.Count > 0)
            {
                string old_quantity = tbCartFill.Rows[0]["quantity"].ToString();
                string old_total = tbCartFill.Rows[0]["total"].ToString();
                double result_quantity = double.Parse(old_quantity,CultureInfo.CurrentCulture) + double.Parse(txtQuantity.Text, CultureInfo.CurrentCulture); // umumiy miqdor
                double result_total = double.Parse(old_total, CultureInfo.CurrentCulture) + double.Parse(txtTotal.Text, CultureInfo.CurrentCulture); // umumiy summa

                //quantity va totalni double yoki int ekanligini tekshiramiz
                int index_total = -1, index_quantity = -1;
                string str_result_quantity = result_quantity.ToString();
                string str_result_total = result_total.ToString();
                string first_last_quantity = "", first_last_total = "";
                if (str_result_quantity.IndexOf(',') > -1)
                {
                    index_quantity = str_result_quantity.IndexOf(',');
                    string first_quantity = str_result_quantity.Substring(0, index_quantity);
                    string last_quantity = str_result_quantity.Substring(index_quantity + 1);
                    first_last_quantity = first_quantity + "." + last_quantity;
                }
                if(str_result_total.IndexOf(',') > -1)
                {
                    index_total = str_result_total.IndexOf(',');
                    string first_total = str_result_total.Substring(0, index_total);
                    string last_total = str_result_total.Substring(index_total + 1);
                    first_last_total = first_total + "." + last_total;
                }

                if(first_last_quantity !="" && first_last_total !="")
                {
                    cmdCart = new MySqlCommand("update cart set quantity='" + first_last_quantity + "', total='" + first_last_total + "' where shop_id='" + ID + "' and product_id='" + product_id + "'");
                }
                if(first_last_quantity == "" && first_last_total != "")
                {
                    cmdCart = new MySqlCommand("update cart set quantity='" + result_quantity + "', total='" + first_last_total + "' where shop_id='" + ID + "' and product_id='" + product_id + "'");
                }
                if(first_last_quantity != "" && first_last_total == "")
                {
                    cmdCart = new MySqlCommand("update cart set quantity='" + first_last_quantity + "', total='" + result_total + "' where shop_id='" + ID + "' and product_id='" + product_id + "'");
                }
                if (first_last_quantity == "" && first_last_total == "")
                {
                    cmdCart = new MySqlCommand("update cart set quantity='" + result_quantity + "', total='" + result_total + "' where shop_id='" + ID + "' and product_id='" + product_id + "'");
                }
                objDBAccess.executeQuery(cmdCart);
                cmdCart.Dispose();
            }
            else
            {
                if (ID == 1)
                {
                    //quantity va totalni double yoki int ekanligini tekshiramiz
                    int index_total = -1, index_quantity = -1;
                    string str_result_quantity = txtQuantity.Text;
                    string str_result_total = txtTotal.Text;
                    string first_last_quantity = "", first_last_total = "";
                    if (str_result_quantity.IndexOf(',') > -1)
                    {
                        index_quantity = str_result_quantity.IndexOf(',');
                        string first_quantity = str_result_quantity.Substring(0, index_quantity);
                        string last_quantity = str_result_quantity.Substring(index_quantity + 1);
                        first_last_quantity = first_quantity + "." + last_quantity;
                    }
                    if (str_result_total.IndexOf(',') > -1)
                    {
                        index_total = str_result_total.IndexOf(',');
                        string first_total = str_result_total.Substring(0, index_total);
                        string last_total = str_result_total.Substring(index_total + 1);
                        first_last_total = first_total + "." + last_total;
                    }

                    if (first_last_quantity != "" && first_last_total != "")
                    {
                        cmdCart = new MySqlCommand("insert into cart values('" + ID + "', '" + ID + "', '" + product_id + "', '" + name + "', '" + price + "', '" + first_last_quantity + "', '" + first_last_total + "')");
                    }
                    if (first_last_quantity == "" && first_last_total != "")
                    {
                        cmdCart = new MySqlCommand("insert into cart values('" + ID + "', '" + ID + "', '" + product_id + "', '" + name + "', '" + price + "', '" + txtQuantity.Text + "', '" + first_last_total + "')");
                    }
                    if (first_last_quantity != "" && first_last_total == "")
                    {
                        cmdCart = new MySqlCommand("insert into cart values('" + ID + "', '" + ID + "', '" + product_id + "', '" + name + "', '" + price + "', '" + first_last_quantity + "', '" + txtTotal.Text + "')");
                    }
                    if (first_last_quantity == "" && first_last_total == "")
                    {
                        cmdCart = new MySqlCommand("insert into cart values('" + ID + "', '" + ID + "', '" + product_id + "', '" + name + "', '" + price + "', '" + txtQuantity.Text + "', '" + txtTotal.Text + "')");
                    }
                    objDBAccess.executeQuery(cmdCart);
                    cmdCart.Dispose();
                }
                else
                {

                    //quantity va totalni double yoki int ekanligini tekshiramiz
                    int index_total = -1, index_quantity = -1;
                    string str_result_quantity = txtQuantity.Text;
                    string str_result_total = txtTotal.Text;
                    string first_last_quantity = "", first_last_total = "";
                    if (str_result_quantity.IndexOf(',') > -1)
                    {
                        index_quantity = str_result_quantity.IndexOf(',');
                        string first_quantity = str_result_quantity.Substring(0, index_quantity);
                        string last_quantity = str_result_quantity.Substring(index_quantity + 1);
                        first_last_quantity = first_quantity + "." + last_quantity;
                    }
                    if (str_result_total.IndexOf(',') > -1)
                    {
                        index_total = str_result_total.IndexOf(',');
                        string first_total = str_result_total.Substring(0, index_total);
                        string last_total = str_result_total.Substring(index_total + 1);
                        first_last_total = first_total + "." + last_total;
                    }

                    if (first_last_quantity != "" && first_last_total != "")
                    {
                        cmdCart = new MySqlCommand("insert into cart (shop_id,product_id,name,price,quantity,total) values('" + ID + "', '" + product_id + "', '" + name + "', '" + price + "', '" + first_last_quantity + "', '" + first_last_total + "')");
                    }
                    if (first_last_quantity == "" && first_last_total != "")
                    {
                        cmdCart = new MySqlCommand("insert into cart (shop_id,product_id,name,price,quantity,total) values('" + ID + "', '" + product_id + "', '" + name + "', '" + price + "', '" + txtQuantity.Text + "', '" + first_last_total + "')");
                    }
                    if (first_last_quantity != "" && first_last_total == "")
                    {
                        cmdCart = new MySqlCommand("insert into cart (shop_id,product_id,name,price,quantity,total) values('" + ID + "', '" + product_id + "', '" + name + "', '" + price + "', '" + first_last_quantity + "', '" + txtTotal.Text + "')");
                    }
                    if (first_last_quantity == "" && first_last_total == "")
                    {
                        cmdCart = new MySqlCommand("insert into cart (shop_id,product_id,name,price,quantity,total) values('" + ID + "', '" + product_id + "', '" + name + "', '" + price + "', '" + txtQuantity.Text + "', '" + txtTotal.Text + "')");
                    }
                    objDBAccess.executeQuery(cmdCart);
                    cmdCart.Dispose();
                }
            }

            string str_resultQuantity = resultQuantity.ToString();
            string first_last_Quantity = "";
            int index = -1;
            if(str_resultQuantity.IndexOf(',') > -1)
            {
                index = str_resultQuantity.IndexOf(',');
                string first_Quantity = str_resultQuantity.Substring(0, index);
                string last_Quantity = str_resultQuantity.Substring(index + 1);
                first_last_Quantity = first_Quantity + "." + last_Quantity;
                cmdProduct = new MySqlCommand("update product set quantity='" + first_last_Quantity + "' where product_id='" + product_id + "' and barcode='" + barcode + "'");
            }
            else
            {
                cmdProduct = new MySqlCommand("update product set quantity='" + resultQuantity + "' where product_id='" + product_id + "' and barcode='" + barcode + "'");

            }
            objDBAccess.executeQuery(cmdProduct);
            tbCartFill.Clear();
            tbCartFill.Dispose();
            cmdProduct.Dispose();
            cmdCart.Dispose();
            frmSales sales = new frmSales();
            sales.Refresh();
            Close();
        }
    }
}
