using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Json;

namespace Jayhunelectro
{
    public partial class frmCashDesk : Form
    {
        public frmCashDesk()
        {
            InitializeComponent();
        }
        DBAccess objDBAccess = new DBAccess();
        public static DataTable tbCashShop, tbCashCart;
        public static CurrencyManager managerCashShop, managerCashCart;
        public static MySqlCommand cmd, cmdCashShop, cmdCashCart;
        public static string header = "";
        public static string footer = "";
       
        private void dbgridCashShop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbCashShop.Rows[managerCashShop.Position]["id"] + "'";
                tbCashCart.Clear();
                objDBAccess.readDatathroughAdapter(queryCashCart, tbCashCart);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                string queryCashShop = "select shop.id, shop.jamisumma as Жами_сумма, shop.date as Сана, userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where shop.status_tulov=0 and shop.debt=0 and shop.jamisumma>0";
                tbCashShop.Clear();
                objDBAccess.readDatathroughAdapter(queryCashShop, tbCashShop);
                string queryCashCart;
                tbCashCart.Clear();
                if (tbCashShop.Rows.Count > 0)
                {
                    queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbCashShop.Rows[managerCashShop.Position]["id"] + "'";
                }
                else
                {
                    queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id=0";
                }
                objDBAccess.readDatathroughAdapter(queryCashCart, tbCashCart);
            }
            else
            {
                string queryCashShop = "select shop.id, shop.jamisumma as Жами_сумма, shop.date as Сана, userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where shop.status_tulov=0 and shop.debt=0 and shop.jamisumma>0 and shop.id like '" + txtSearch.Text+"%'";
                tbCashShop.Clear();
                objDBAccess.readDatathroughAdapter(queryCashShop, tbCashShop);
                string queryCashCart;
                tbCashCart.Clear();
                if (tbCashShop.Rows.Count > 0)
                {
                    queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbCashShop.Rows[managerCashShop.Position]["id"] + "'";
                }
                else
                {
                    queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id=0";
                }
                objDBAccess.readDatathroughAdapter(queryCashCart, tbCashCart);
            }
        }

        public void btnNasiya_Click(object sender, EventArgs e)
        {
            if (tbCashShop.Rows.Count == 0) return;
            double summa = 0;
            foreach (DataRow dtColimn in tbCashCart.Rows)
            {
                string each_summa = "";
                if (dtColimn["умумий_сумма"].ToString().IndexOf(',') > -1)
                {
                    int index = dtColimn["умумий_сумма"].ToString().IndexOf(',');
                    string first_ = dtColimn["умумий_сумма"].ToString().Substring(0, index);
                    string last_ = dtColimn["умумий_сумма"].ToString().Substring(index + 1);
                    each_summa = first_ + "." + last_;
                }
                else
                {
                    each_summa = dtColimn["умумий_сумма"].ToString();
                }
                summa += double.Parse(each_summa, CultureInfo.InvariantCulture);
            }
            bool isopen = false;
            foreach (Form f1 in Application.OpenForms)
            {
                if (f1.Text == "Насия Ойнаси")
                {
                    isopen = true;
                    f1.BringToFront();
                    break;
                }
            }

            string print = header;
            print += "\nЧeк : " + tbCashShop.Rows[managerCashShop.Position]["id"].ToString() + "\n";
            print += "Сотувчи : " + tbCashShop.Rows[managerCashShop.Position]["Сотувчи"].ToString() + "\n";
            print += "Кассир : " + frmLogin.sellar + "\n";
            int i = 1;
            int CountBasket = managerCashCart.Count;
            managerCashCart.Position = 0;
            for (int j = 0; j < CountBasket; j++)
            {
                string name = tbCashCart.Rows[managerCashCart.Position]["Номи"].ToString();
                string price = tbCashCart.Rows[managerCashCart.Position]["Нархи"].ToString();
                string quantity = tbCashCart.Rows[managerCashCart.Position]["Микдори"].ToString();
                quantity = DoubleToStr(quantity);
                print += i.ToString() + "." + name + "\n";
                double Dquantity = double.Parse(quantity, CultureInfo.InvariantCulture);
                double Dprice = double.Parse(price, CultureInfo.InvariantCulture);
                double total_each = Dquantity * Dprice;
                string str_total_each = DoubleToStr(total_each.ToString());
                print += " " + quantity + " x " + price + " = " + str_total_each + "\n";
                i++;
                managerCashCart.Position++;
            }
            print += "\n" + "Жами сумма : " + DoubleToStr(summa.ToString()) + "\n";
            managerCashCart.Position = 0;
            //

            if (isopen == false)
            {
                DateTime dt = DateTime.Now;
                frmDebt f2 = new frmDebt();
                frmDebt.JamiSumma = summa.ToString();
                frmDebt.OlganSana = dt.Date.ToString("yyyy-MM-dd");
                f2.shopID = int.Parse(tbCashShop.Rows[managerCashShop.Position]["id"].ToString());
                f2.print = print;
                f2.footer = footer;
                if (f2.ShowDialog() == DialogResult.OK)
                {
                    Refresh();
                }
            }
        }

        public string DoubleToStr(string s)
        {
            if(s.IndexOf(',') > -1)
            {
                int index = s.IndexOf(',');
                string first = s.Substring(0, index);
                string last = s.Substring(index + 1);
                s = first + "." + last;
            }
            return s;
        }

        public void btnTulov_Click(object sender, EventArgs e)
        {
            if (tbCashShop.Rows.Count == 0) return;
            double summa = 0;
            foreach (DataRow dtColimn in tbCashCart.Rows)
            {
                string each_summa = "";
                if (dtColimn["умумий_сумма"].ToString().IndexOf(',') > -1)
                {
                    int index = dtColimn["умумий_сумма"].ToString().IndexOf(',');
                    string first_ = dtColimn["умумий_сумма"].ToString().Substring(0, index);
                    string last_ = dtColimn["умумий_сумма"].ToString().Substring(index + 1);
                    each_summa = first_ + "." + last_;
                }
                else
                {
                    each_summa = dtColimn["умумий_сумма"].ToString();
                }
                summa += double.Parse(each_summa, CultureInfo.InvariantCulture);

            }

            string print = header;
            print += "\nЧeк : " + tbCashShop.Rows[managerCashShop.Position]["id"].ToString() + "\n";
            print += "Сотувчи : " + tbCashShop.Rows[managerCashShop.Position]["Сотувчи"].ToString() + "\n";
            print += "Кассир : " + frmLogin.sellar + "\n";
            int i = 1;
            int CountBasket = managerCashCart.Count;
            managerCashCart.Position = 0;
            for (int j = 0; j < CountBasket; j++)
            {
                string name = tbCashCart.Rows[managerCashCart.Position]["Номи"].ToString();
                string price = tbCashCart.Rows[managerCashCart.Position]["Нархи"].ToString();
                string quantity = tbCashCart.Rows[managerCashCart.Position]["Микдори"].ToString();
                quantity = DoubleToStr(quantity);
                print += i.ToString() + "." + name + "\n";
                double Dquantity = double.Parse(quantity, CultureInfo.InvariantCulture);
                double Dprice = double.Parse(price, CultureInfo.InvariantCulture);
                double total_each = Dquantity * Dprice;
                string str_total_each = DoubleToStr(total_each.ToString());
                print += " " + quantity + " x " + price + " = " + str_total_each + "\n";
                i++;
                managerCashCart.Position++;
            }
            print += "\n" + "Жами сумма : " + DoubleToStr(summa.ToString()) + "\n";
            managerCashCart.Position = 0;

            frmTulov tulov = new frmTulov();
            tulov.Width = 825;
            tulov.Height = 290;
            tulov.txtTulov.Text = summa.ToString();
            string sellar = frmLogin.sellar;
            tulov.txtSellar.Text = sellar;
            tulov.panelNayisa.Visible = false;
            tulov.panelSotish.Visible = true;
            tulov.shopId = tbCashShop.Rows[managerCashShop.Position]["id"].ToString();
            tulov.print = print;
            tulov.footer = footer;
            tulov.ShowDialog();
        }

        private void dbgridCashShop_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridCashShop.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridCashCart_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridCashCart.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        static async Task<string> PostURI(Uri u, HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "token 57e75875257cb9c356aa91a9d5ef53facc48d846");
                try
                {
                    HttpResponseMessage result = await client.PostAsync(u, c);
                    if (result.IsSuccessStatusCode)
                    {
                        response = result.StatusCode.ToString();
                    }
                    else
                    {
                        response = "Error!";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return response;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmCashCheck cashCheck = new frmCashCheck();
            cashCheck.txtHeader.Text = header;
            cashCheck.txtFooter.Text = footer;
            cashCheck.ShowDialog();
        }

        public void btnCancel_Click(object sender, EventArgs e)
        {
            if (tbCashShop.Rows.Count == 0) return;
            managerCashCart.Position = 0;
            int count = managerCashCart.Count;
            string quantityBasket, product_id, quantityProduct, queryProduct;
            DataTable tbProductFill = new DataTable();
            for (int i = 0; i < count; i++)
            {
                quantityBasket = tbCashCart.Rows[managerCashCart.Position]["микдори"].ToString();  // cart jadvalidagilarni miqdorini double ga tekshiramiz
                string str_quantityBasket = "";
                if (quantityBasket.IndexOf(',') > -1)
                {
                    int index = quantityBasket.IndexOf(',');
                    string firstBasket_quantity = quantityBasket.Substring(0, index);
                    string lastBasket_quantity = quantityBasket.Substring(index + 1);
                    str_quantityBasket = firstBasket_quantity + "." + lastBasket_quantity;
                    quantityBasket = str_quantityBasket;
                    str_quantityBasket = "";
                }
                product_id = tbCashCart.Rows[managerCashCart.Position]["product_id"].ToString();
                queryProduct = "select * from product where product_id='" + product_id + "'";
                objDBAccess.readDatathroughAdapter(queryProduct, tbProductFill);
                quantityProduct = tbProductFill.Rows[0]["quantity"].ToString();  // product jadvalidagilarni miqdorini double ga tekshiramiz
                string str_quantityProduct = "";
                if (quantityProduct.IndexOf(',') > -1)
                {
                    int index = quantityProduct.IndexOf(',');
                    string firstProduct_quantity = quantityProduct.Substring(0, index);
                    string lastProduct_quantity = quantityProduct.Substring(index + 1);
                    str_quantityProduct = firstProduct_quantity + "." + lastProduct_quantity;
                    quantityProduct = str_quantityProduct;
                    str_quantityProduct = "";
                }
                double dquantityBasket = double.Parse(quantityBasket, CultureInfo.InvariantCulture);
                double dquantityProduct = double.Parse(quantityProduct, CultureInfo.InvariantCulture);
                double totalQuantity = dquantityBasket + dquantityProduct;//umumiy miqdorni hisoblaymiz.
                
                //miqdorni double ekanligini tekshiramiz
                string str_totalQuantity = totalQuantity.ToString();
                string first_last_quantity = "";
                if (str_totalQuantity.IndexOf(',') > -1)
                {
                    int index_quantity = str_totalQuantity.IndexOf(',');
                    string first_quantity = str_totalQuantity.Substring(0, index_quantity);
                    string last_quantity = str_totalQuantity.Substring(index_quantity + 1);
                    first_last_quantity = first_quantity + "." + last_quantity;
                }

                //Umumiy miqdorni product table ga yozamiz.
                if (first_last_quantity != "")
                {
                    cmd = new MySqlCommand("update product set quantity='" + first_last_quantity + "' where product_id='" + product_id + "'");
                }
                else
                {
                    cmd = new MySqlCommand("update product set quantity='" + totalQuantity + "' where product_id='" + product_id + "'");
                }
                
                objDBAccess.executeQuery(cmd);
                tbProductFill.Clear();
                managerCashCart.Position++;
            }

            cmdCashCart = new MySqlCommand("delete from cart where shop_id='" + tbCashShop.Rows[managerCashShop.Position]["id"] + "'"); //Cart dan bekor qilinganlarni o'chiramiz/
            cmdCashShop = new MySqlCommand("delete from shop where id='" + tbCashShop.Rows[managerCashShop.Position]["id"] + "'"); //Shop dan bekor qilinganlarni o'chiramiz.
            objDBAccess.executeQuery(cmdCashCart);
            objDBAccess.executeQuery(cmdCashShop);
            MessageBox.Show("Товарлар бэкор килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbProductFill.Dispose();
            cmd.Dispose();
            cmdCashCart.Dispose();
            cmdCashShop.Dispose();
            Refresh();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void frmCashDesk_Load(object sender, EventArgs e)
        {
            objDBAccess.createConn();
            string queryCashShop = "select shop.id, shop.jamisumma as Жами_сумма, shop.date as Сана, userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where shop.status_tulov=0 and shop.debt=0 and shop.jamisumma>0";
            tbCashShop = new DataTable();
            objDBAccess.readDatathroughAdapter(queryCashShop, tbCashShop);
            managerCashShop = (CurrencyManager)BindingContext[tbCashShop];
            dbgridCashShop.DataSource = tbCashShop;
            dbgridCashShop.Columns[0].Visible = false;
            dbgridCashShop.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            string queryCashCart = "";
            if (tbCashShop.Rows.Count > 0)
            {
                queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbCashShop.Rows[managerCashShop.Position]["id"] + "'";
            }
            else
            {
                queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id=0";
            }
            tbCashCart = new DataTable();
            objDBAccess.readDatathroughAdapter(queryCashCart, tbCashCart);
            managerCashCart = (CurrencyManager)BindingContext[tbCashCart];
            dbgridCashCart.DataSource = tbCashCart;
            dbgridCashCart.Columns[0].Visible = false;
            dbgridCashCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            tbCashShop.Dispose();
            tbCashCart.Dispose();
            objDBAccess.closeConn();

            header = frmMainMenu.headerCash;
            footer = frmMainMenu.footerCash;
        }

        public void Refresh()
        {
            string queryCashShop = "select shop.id, shop.jamisumma as Жами_сумма, shop.date as Сана, userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where shop.status_tulov=0 and shop.debt=0 and shop.jamisumma>0";
            tbCashShop.Clear();
            objDBAccess.readDatathroughAdapter(queryCashShop, tbCashShop);
            string queryCashCart = "";
            if (tbCashShop.Rows.Count > 0)
            {
                queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbCashShop.Rows[managerCashShop.Position]["id"] + "'";
            }
            else
            {
                queryCashCart = "select product_id,name as Номи,price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id=0";
            }
            tbCashCart.Clear();
            objDBAccess.readDatathroughAdapter(queryCashCart, tbCashCart);
        }

    }
}
