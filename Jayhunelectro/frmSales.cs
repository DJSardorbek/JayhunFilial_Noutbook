using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Json;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Drawing.Printing;

namespace Jayhunelectro
{
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }

        // public static string filial_id = "";
        public static string header = "";
        public static string footer = "";
        public static string barcode = "";
        public static string price = "";
        public static string oldquantity = "";
        public static string product_id = "";
        public static string name = "";
        public static bool shop = false;
        public static int shopID = 0;
        public static MySqlConnection con;
        public static MySqlDataAdapter adapterProduct, adapterBasket;
        public static MySqlCommand cmd, cmdCart,cmdShop, command;
        public static DataTable tbProducts,tbBasket, tbID, tbTulovSumma, tbGuruh;
        public static DataTable tbShopId;
        public static MySqlCommand cmdShopId;
        public static CurrencyManager managerProduct, managerbasket, managerGuruh;
        public static string product_idEdit="", priceEdit="", quantityEdit="", totalEdit="";
        public static bool nasiya = false;

        DBAccess objDBAccess = new DBAccess();

       
        private void frmSales_Load(object sender, EventArgs e)
        {
            objDBAccess.createConn();
            string queryProduct = "select product_id, name as Номи,price as Нархи,quantity as Микдори, barcode as Штрих_код from product limit 1";
            string queryCart = "select product_id, name as Номи, price as Нархи,quantity as Микдори, total as Умумий_сумма from cart " +
                "inner join shop on cart.shop_id=shop.id inner join shopId on shopId.shop_id=cart.shop_id where shop.id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
            string queryTulovSumma = "select sum(total) from cart inner join shopId on cart.shop_id=shopId.shop_id where cart.shop_id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
            tbTulovSumma = new DataTable();
            tbProducts = new DataTable();
            objDBAccess.readDatathroughAdapter(queryProduct, tbProducts);
            tbBasket = new DataTable();

            string queryGuruh = "select * from guruh";
            tbGuruh = new DataTable();
            objDBAccess.readDatathroughAdapter(queryGuruh, tbGuruh);
            managerGuruh = (CurrencyManager)BindingContext[tbGuruh];
            ComboGuruh.DataSource = tbGuruh;
            ComboGuruh.DisplayMember = "name";
            dbgridProducts.Visible = false;
            objDBAccess.readDatathroughAdapter(queryCart, tbBasket);
            tbBasket.Columns.Add("pl").SetOrdinal(3);
            tbBasket.Columns[3].DefaultValue = "+";
            tbBasket.Columns.Add("mn").SetOrdinal(5);
            tbBasket.Columns[5].DefaultValue = "-";
            if (tbBasket.Rows.Count > 0)
            {
                foreach (DataRow item in tbBasket.Rows)
                {
                    item["pl"] = "+";
                    item["mn"] = "-";
                    item.EndEdit();
                    tbBasket.AcceptChanges();
                }
            }
            objDBAccess.readDatathroughAdapter(queryTulovSumma, tbTulovSumma);
            txtTulovSumma.DataSource = tbTulovSumma;
            txtTulovSumma.DisplayMember = "sum(total)";
            managerProduct = (CurrencyManager)BindingContext[tbProducts];
            managerbasket = (CurrencyManager)BindingContext[tbBasket];
            dbgridProducts.DataSource = tbProducts;
            dbgridProducts.MaximumSize = new Size(this.dbgridProducts.Width, 400);
            dbgridProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dbgridProducts.Columns[0].Visible = false;
            dbgridProducts.RowHeadersVisible = false;
            dbgridProducts.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dbgridBasket.DataSource = tbBasket;
            dbgridBasket.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dbgridBasket.Columns[0].Visible = false;
            dbgridBasket.Columns[3].HeaderText = "+";
            dbgridBasket.Columns[3].Width = 21;
            dbgridBasket.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbgridBasket.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dbgridBasket.Columns[5].HeaderText = "-";
            dbgridBasket.Columns[5].Width = 21;
            dbgridBasket.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbgridBasket.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            objDBAccess.closeConn();
            tbProducts.Dispose();
            tbBasket.Dispose();
            header = frmMainMenu.header;
            footer = frmMainMenu.footer;
        }
       
        public void iconButton5_Click(object sender, EventArgs e)
        {
            if (shopID == 0 || tbBasket.Rows.Count==0) return;
            managerbasket.Position = 0;
            int count = managerbasket.Count;
            string quantityBasket,product_id, quantityProduct, queryProduct;
            DataTable tbProductFill = new DataTable();
            for(int i = 0; i<count; i++)
            {
                quantityBasket = tbBasket.Rows[managerbasket.Position]["микдори"].ToString(); // cart jadvalidagilarni miqdorini double ga tekshiramiz
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
                product_id = tbBasket.Rows[managerbasket.Position]["product_id"].ToString();
                queryProduct = "select * from product where product_id='" + product_id + "'";
                objDBAccess.readDatathroughAdapter(queryProduct, tbProductFill);
                quantityProduct = tbProductFill.Rows[0]["quantity"].ToString(); // product jadvalidagilarni miqdorini double ga tekshiramiz
                string str_quantityProduct = "";
                if(quantityProduct.IndexOf(',') > -1)
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
                if(str_totalQuantity.IndexOf(',') > -1)
                {
                    int index_quantity = str_totalQuantity.IndexOf(',');
                    string first_quantity = str_totalQuantity.Substring(0, index_quantity);
                    string last_quantity = str_totalQuantity.Substring(index_quantity + 1);
                    first_last_quantity = first_quantity + "." + last_quantity;
                }

                //Umumiy miqdorni product table ga yozamiz.

                if(first_last_quantity!="")
                {
                    cmd = new MySqlCommand("update product set quantity='" + first_last_quantity + "' where product_id='" + product_id + "'");
                }
                else
                {
                    cmd = new MySqlCommand("update product set quantity='" + totalQuantity + "' where product_id='" + product_id + "'");
                }
                objDBAccess.executeQuery(cmd);
                tbProductFill.Clear();
                managerbasket.Position++;
            }
            
            cmdCart = new MySqlCommand("delete from cart where shop_id='" + shopID + "'"); //Cart dan bekor qilinganlarni o'chiramiz/
            cmdShop = new MySqlCommand("delete from shop where id='" + shopID + "'"); //Shop dan bekor qilinganlarni o'chiramiz.
            objDBAccess.executeQuery(cmdCart);
            objDBAccess.executeQuery(cmdShop);

            string queryShopId = "select * from shopId where password='"+frmLogin.password1+"'";
            tbShopId = new DataTable();
            objDBAccess.readDatathroughAdapter(queryShopId, tbShopId);
            if (tbShopId.Rows.Count > 0)
            {
                cmdShopId = new MySqlCommand("update shopId set shop_id=0 where password='"+frmLogin.password1+"'");
                objDBAccess.executeQuery(cmdShopId);
            }
            else
            {
                string queryId = "select * from shopId order by id desc limit 1";
                DataTable tbSId = new DataTable();
                objDBAccess.readDatathroughAdapter(queryId, tbSId);
                if (tbSId.Rows.Count == 0)
                {
                    cmdShopId = new MySqlCommand("insert into shopId values(1,0,'" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
                    objDBAccess.executeQuery(cmdShopId);
                }
                else
                {
                    cmdShopId = new MySqlCommand("insert into shopId (shop_id,mac_address,password) values(0,'" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
                    objDBAccess.executeQuery(cmdShopId);
                }
                try
                {
                    tbSId.Clear();
                    tbSId.Dispose();
                }
                catch (Exception) { }
            }
            tbShopId.Clear();
            tbShopId.Dispose();

            MessageBox.Show("Товарлар бэкор килинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbProductFill.Dispose();
            cmd.Dispose();
            cmdCart.Dispose();
            cmdShop.Dispose();
            shopID = 0;
            shop = false;
            Refresh();
        }

        public void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbBasket.Rows.Count > 0)
            {
                string BasketDeleteQuantity = tbBasket.Rows[managerbasket.Position]["микдори"].ToString();
                BasketDeleteQuantity = DoubleToStr(BasketDeleteQuantity);
                string Product_idDelete = tbBasket.Rows[managerbasket.Position]["product_id"].ToString();
                string queryProductQuantity = "select * from product where product_id='" + Product_idDelete + "'";
                DataTable tbProductQuantity = new DataTable();
                objDBAccess.readDatathroughAdapter(queryProductQuantity, tbProductQuantity);
                string QuantityProduct = tbProductQuantity.Rows[0]["quantity"].ToString();   // Product jadvalidan maxsulot miqdorini olamiz
                QuantityProduct = DoubleToStr(QuantityProduct);
                tbProductQuantity.Clear();
                tbProductQuantity.Dispose();
                double DBasketDeleteQuantity = double.Parse(BasketDeleteQuantity);
                double DQuantityProduct = double.Parse(QuantityProduct);
                double ResultQuantity = DBasketDeleteQuantity + DQuantityProduct;  // Umumiy miqdorni hisoblaymiz

                //Umumiy miqdorni Product jadvaliga yozamiz
                cmd = new MySqlCommand("update product set quantity='" + DoubleToStr(ResultQuantity.ToString()) + "' where product_id='" + Product_idDelete + "'");
                objDBAccess.executeQuery(cmd);
                cmd.Dispose();

                //Cart jadvalidan productni o'chiramiz
                cmdCart = new MySqlCommand("delete from cart where product_id='" + Product_idDelete + "' and shop_id='" + shopID + "'");
                objDBAccess.executeQuery(cmdCart);
                cmdCart.Dispose();
                Refresh();
                
            }
            return;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            try
            {
                Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dbgridProducts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           
            //using (SolidBrush b = new SolidBrush(dbgridProducts.RowHeadersDefaultCellStyle.ForeColor))
            //{
            //    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            //}
        }

        public void iconButton2_Click(object sender, EventArgs e)
        {
            moveBasketToolStripMenuItem_Click(sender, e);
        }

        private void frmSales_SizeChanged(object sender, EventArgs e)
        {
            if(Width <= 1123 && Height <= 700)
            {
                dbgridProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            if (Width > 1123 && Height >= 700)
            {
                dbgridProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && dbgridProducts.Visible)
            {
                dbgridProducts.Focus();
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Down && dbgridProducts.Visible == false)
            {
                dbgridBasket.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                moveBasketToolStripMenuItem_Click(sender, e);
                txtSearch.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void dbgridProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                moveBasketToolStripMenuItem_Click(sender, e);
                txtSearch.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void ComboGuruh_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                dbgridProducts.Focus();
            }
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                ComboGuruh.SelectedIndex = 0;
                tbProducts.Clear();
                dbgridProducts.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ComboGuruh_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void ComboGuruh_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void ComboGuruh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbProducts.Clear();
                string querySearch = "select product_id,name as номи, price as нархи,quantity as микдори, barcode as штрих_код from product where gurux='" + tbGuruh.Rows[ComboGuruh.SelectedIndex ]["id"] + "'";
                
                objDBAccess.readDatathroughAdapter(querySearch, tbProducts);
                dbgridProducts.DataSource = tbProducts;
                dbgridProducts.Visible = true;
                dbgridProducts.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dbgridBasket_KeyDown(object sender, KeyEventArgs e)
        {
            if (managerbasket.Count == 0) return;
            if (e.KeyCode == Keys.Add) //Plus
            {
                DataTable tbQuantityProduct = new DataTable();
                string queryQuantityProduct = "select * from product where product_id='" + tbBasket.Rows[managerbasket.Position]["product_id"] + "'";
                objDBAccess.readDatathroughAdapter(queryQuantityProduct, tbQuantityProduct);
                string quantityProduct = tbQuantityProduct.Rows[0]["quantity"].ToString(); // Product jadvalidan maxsulot sonini olamiz
                quantityProduct = DoubleToStr(quantityProduct);
                double DquantityProduct = double.Parse(quantityProduct, CultureInfo.InvariantCulture);
                tbQuantityProduct.Clear();
                tbQuantityProduct.Dispose();
                if (DquantityProduct >= 1)
                {
                    string quantityBasket = tbBasket.Rows[managerbasket.Position]["Микдори"].ToString();
                    string price = tbBasket.Rows[managerbasket.Position]["Нархи"].ToString();
                    price = DoubleToStr(price);
                    double Dprice = double.Parse(price, CultureInfo.InvariantCulture);
                    quantityBasket = DoubleToStr(quantityBasket);
                    double DquantityBasket = double.Parse(quantityBasket, CultureInfo.InvariantCulture);
                    DquantityBasket += 1;

                    string total = tbBasket.Rows[managerbasket.Position]["Умумий_сумма"].ToString();
                    total = DoubleToStr(total);
                    double Dtotal = double.Parse(total);
                    Dtotal += Dprice;

                    DquantityProduct -= 1;
                    //Product jadvaliga o'zgargan miqdorni yozamiz
                    cmd = new MySqlCommand("update product set quantity='" + DoubleToStr(DquantityProduct.ToString()) + "' where product_id='" + tbBasket.Rows[managerbasket.Position]["product_id"] + "'");
                    objDBAccess.executeQuery(cmd);
                    cmd.Dispose();

                    //Cart jadvaliga o'zgargan miqdorni va narxni yozamiz
                    cmdCart = new MySqlCommand("update cart set quantity='" + DoubleToStr(DquantityBasket.ToString()) + "', total='" + DoubleToStr(Dtotal.ToString()) + "' where product_id='" + tbBasket.Rows[managerbasket.Position]["product_id"] + "' and shop_id='" + shopID + "'");
                    objDBAccess.executeQuery(cmdCart);
                    cmdCart.Dispose();
                    Refresh();

                }
                else
                {
                    MessageBox.Show("Товар йэтарли эмас!", "сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (e.KeyCode == Keys.Subtract) // Minus
            {
                string quantityBasket = tbBasket.Rows[managerbasket.Position]["Микдори"].ToString();
                quantityBasket = DoubleToStr(quantityBasket);
                double DquantityBasket = double.Parse(quantityBasket, CultureInfo.InvariantCulture);

                if (DquantityBasket >= 2)
                {
                    DataTable tbQuantityProduct = new DataTable();
                    string queryQuantityProduct = "select * from product where product_id='" + tbBasket.Rows[managerbasket.Position]["product_id"] + "'";
                    objDBAccess.readDatathroughAdapter(queryQuantityProduct, tbQuantityProduct);
                    string quantityProduct = tbQuantityProduct.Rows[0]["quantity"].ToString(); // Product jadvalidan maxsulot sonini olamiz
                    quantityProduct = DoubleToStr(quantityProduct);
                    double DquantityProduct = double.Parse(quantityProduct, CultureInfo.InvariantCulture);
                    tbQuantityProduct.Clear();
                    tbQuantityProduct.Dispose();
                    string price = tbBasket.Rows[managerbasket.Position]["Нархи"].ToString();
                    price = DoubleToStr(price);
                    double Dprice = double.Parse(price, CultureInfo.InvariantCulture);

                    DquantityBasket -= 1;

                    string total = tbBasket.Rows[managerbasket.Position]["Умумий_сумма"].ToString();
                    total = DoubleToStr(total);
                    double Dtotal = double.Parse(total);
                    Dtotal -= Dprice;

                    DquantityProduct += 1;
                    //Product jadvaliga o'zgargan miqdorni yozamiz
                    cmd = new MySqlCommand("update product set quantity='" + DoubleToStr(DquantityProduct.ToString()) + "' where product_id='" + tbBasket.Rows[managerbasket.Position]["product_id"] + "'");
                    objDBAccess.executeQuery(cmd);
                    cmd.Dispose();

                    //Cart jadvaliga o'zgargan miqdorni va narxni yozamiz
                    cmdCart = new MySqlCommand("update cart set quantity='" + DoubleToStr(DquantityBasket.ToString()) + "', total='" + DoubleToStr(Dtotal.ToString()) + "' where product_id='" + tbBasket.Rows[managerbasket.Position]["product_id"] + "' and shop_id='" + shopID + "'");
                    objDBAccess.executeQuery(cmdCart);
                    cmdCart.Dispose();
                    Refresh();
                }

                else
                {
                    return;
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                deleteToolStripMenuItem_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string print = header;
            print += "\nЧeк : " + shopID.ToString() + "\n";
            print += "Сотувчи : " + frmLogin.sellar + "\n";
            int i = 1;
            int CountBasket = managerbasket.Count;
            managerbasket.Position = 0;
            for(int j = 0; j<CountBasket; j++ )
            {
                string name = tbBasket.Rows[managerbasket.Position]["Номи"].ToString();
                string price = tbBasket.Rows[managerbasket.Position]["Нархи"].ToString();
                string quantity = tbBasket.Rows[managerbasket.Position]["Микдори"].ToString();
                quantity = DoubleToStr(quantity);
                print += i.ToString() + "." + name + "\n";
                double Dquantity = double.Parse(quantity, CultureInfo.InvariantCulture);
                double Dprice = double.Parse(price, CultureInfo.InvariantCulture);
                double total_each = Dquantity * Dprice;
                string str_total_each = DoubleToStr(total_each.ToString());
                print += " " + quantity + " x " + price + " = " + str_total_each + "\n";
                i++;
                managerbasket.Position++;
            }
            managerbasket.Position = 0;
            double summa = 0;
            foreach (DataRow dtColimn in tbBasket.Rows)
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
            print +="\n" + "Жами сумма : " + DoubleToStr(summa.ToString()) + "\n";
            print += footer;
            e.Graphics.DrawString(print, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }


        
        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmCheck frmCheck = new frmCheck();
            frmCheck.txtHeader.Text = header;
            frmCheck.txtFooter.Text = footer;
            frmCheck.ShowDialog();
        }

        private void printWaiting_PrintPage(object sender, PrintPageEventArgs e)
        {
            string print = header;
            print += "\nКутишга ўтказилди\n";
            print += "\nЧeк : " + shopID.ToString() + "\n";
            print += "Сотувчи : " + frmLogin.sellar + "\n";
            int i = 1;
            int CountBasket = managerbasket.Count;
            managerbasket.Position = 0;
            for (int j = 0; j < CountBasket; j++)
            {
                string name = tbBasket.Rows[managerbasket.Position]["Номи"].ToString();
                string price = tbBasket.Rows[managerbasket.Position]["Нархи"].ToString();
                string quantity = tbBasket.Rows[managerbasket.Position]["Микдори"].ToString();
                quantity = DoubleToStr(quantity);
                print += i.ToString() + "." + name + "\n";
                double Dquantity = double.Parse(quantity, CultureInfo.InvariantCulture);
                double Dprice = double.Parse(price, CultureInfo.InvariantCulture);
                double total_each = Dquantity * Dprice;
                string str_total_each = DoubleToStr(total_each.ToString());
                print += " " + quantity + " x " + price + " = " + str_total_each + "\n";
                i++;
                managerbasket.Position++;
            }
            managerbasket.Position = 0;
            double summa = 0;
            foreach (DataRow dtColimn in tbBasket.Rows)
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
            print += "\n" + "Жами сумма : " + DoubleToStr(summa.ToString()) + "\n";
            print += footer;
            e.Graphics.DrawString(print, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        public void btnCash_Click(object sender, EventArgs e)
        {
            if (shopID == 0 || tbBasket.Rows.Count == 0)
            {
                return;
            }
            double summa = 0;
            foreach (DataRow dtColimn in tbBasket.Rows)
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

            string str_summa = summa.ToString();
            if (str_summa.IndexOf(',') > -1)
            {
                int index_summa = str_summa.IndexOf(',');
                string first_summa = str_summa.Substring(0, index_summa);
                string last_summa = str_summa.Substring(index_summa + 1);
                str_summa = first_summa + "." + last_summa;
            }
            cmd = new MySqlCommand("update shop set jamisumma='" + str_summa + "' where id='" + shopID + "'");
            objDBAccess.executeQuery(cmd);
            cmd.Dispose();

            string queryShopId = "select * from shopId where password='"+frmLogin.password1+"'";
            tbShopId = new DataTable();
            objDBAccess.readDatathroughAdapter(queryShopId, tbShopId);
            if (tbShopId.Rows.Count > 0)
            {
                cmdShopId = new MySqlCommand("update shopId set shop_id=0 where password='"+frmLogin.password1+"'");
                objDBAccess.executeQuery(cmdShopId);
            }
            else
            {
                string queryId = "select * from shopId order by id desc limit 1";
                DataTable tbSId = new DataTable();
                objDBAccess.readDatathroughAdapter(queryId, tbSId);
                if (tbSId.Rows.Count == 0)
                {
                    cmdShopId = new MySqlCommand("insert into shopId values(1,0,'" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
                    objDBAccess.executeQuery(cmdShopId);
                }
                else
                {
                    cmdShopId = new MySqlCommand("insert into shopId (shop_id,mac_address,password) values(0,'" + frmLogin.mac_address + "','"+frmLogin.password1+"')");
                    objDBAccess.executeQuery(cmdShopId);
                }
                try
                {
                    tbSId.Clear();
                    tbSId.Dispose();
                }
                catch (Exception) { }
            }
            tbShopId.Clear();
            tbShopId.Dispose();
            MessageBox.Show("Товарлар кассага ўтказилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printDocument1.Print();
            shopID = 0;
            shop = false;
            Refresh();
        }

        public void iconButton3_Click_2(object sender, EventArgs e)
        {
            frmMainMenu menu = new frmMainMenu();
            //menu.btnWaiting_Click(sender, e);
            menu.openChildForm(new frmWaiting());
            menu.lblDisplay.Text = menu.btnWaiting.Text;
            menu.btnSales.BackColor = Color.FromArgb(30, 31, 68);
            menu.btnMenu.BackColor = Color.FromArgb(30, 31, 68);
            menu.btnWaiting.BackColor = Color.FromArgb(75, 158, 253);
            menu.btnDebt.BackColor = Color.FromArgb(30, 31, 68);
            menu.btnSoldList.BackColor = Color.FromArgb(30, 31, 68);
            menu.btnRecieveFilial.BackColor = Color.FromArgb(30, 31, 68);
            menu.btnChiqish.BackColor = Color.FromArgb(30, 31, 68);
        }

        private void dbgridBasket_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridProducts.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        public void Refresh()
        {
            txtSearch.Clear();
            int PositionBasket = managerbasket.Position;
            int PositionProduct = managerProduct.Position;
            string queryProduct = "select product_id, name as номи, price as нархи,quantity as микдори, barcode as штрих_код from product limit 1";
            string queryCart = "select product_id, name as Номи, price as Нархи,quantity as Микдори, total as Умумий_сумма from cart " +
                "inner join shop on cart.shop_id=shop.id inner join shopId on shopId.shop_id=cart.shop_id where shop.id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
            string queryTulovSumma = "select sum(total) from cart inner join shopId on cart.shop_id=shopId.shop_id where cart.shop_id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
            tbProducts.Clear();
            tbBasket.Clear();
            tbTulovSumma.Clear();
            objDBAccess.readDatathroughAdapter(queryProduct, tbProducts);
            objDBAccess.readDatathroughAdapter(queryCart, tbBasket);
            objDBAccess.readDatathroughAdapter(queryTulovSumma, tbTulovSumma);

            /*if (tbBasket.Rows.Count>0)
            {
                decimal summa = 0;
                foreach (DataRow dtColimn in tbBasket.Rows)
                {
                    summa += (decimal)dtColimn["умумий_сумма"];
                }
                txtTulovSumma.Text = summa.ToString();
            }
            if(tbBasket.Rows.Count == 0)
            {
                txtTulovSumma.Text="";
            }*/
            managerProduct.Position = PositionProduct;
            managerbasket.Position = PositionBasket;
            objDBAccess.closeConn();

        }
        public void moveBasketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbProducts.Rows.Count == 0) return;
            //insertion new record to shop which has not been there before
            if (shop==false)
            {
                string queryShopID = "select id from shop order by id desc limit 1";
                tbID = new DataTable();
                objDBAccess.readDatathroughAdapter(queryShopID, tbID);
                shopID = 0;
                if (tbID.Rows.Count == 1)
                {
                    shopID = int.Parse(tbID.Rows[0]["id"].ToString());
                    shopID = shopID + 1;
                }
                else { shopID = 1; }
                shop = true;
                DateTime dt = DateTime.Now;
                cmdShop = new MySqlCommand("insert into shop values('" + shopID + "',0,0,0,0, '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "',0,0,0,0,0, '" + frmLogin.sellar_id + "')");
                objDBAccess.executeQuery(cmdShop);
                //Yaratilgan yangi shopId ni shopId jadvaliga yozamiz
                string queryShopId = "select * from shopId where password='"+frmLogin.password1+"'";
                tbShopId = new DataTable();
                objDBAccess.readDatathroughAdapter(queryShopId, tbShopId);
                if (tbShopId.Rows.Count > 0)
                {
                    cmdShopId = new MySqlCommand("update shopId set shop_id='" + shopID + "' where password='"+frmLogin.password1+"'");
                    objDBAccess.executeQuery(cmdShopId);
                }
                else
                {
                    string queryId = "select * from shopId order by id desc limit 1";
                    DataTable tbSId = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryId, tbSId);
                    if (tbSId.Rows.Count == 0)
                    {
                        cmdShopId = new MySqlCommand("insert into shopId values(1,'" + shopID + "','" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
                        objDBAccess.executeQuery(cmdShopId);
                    }
                    else
                    {
                        cmdShopId = new MySqlCommand("insert into shopId (shop_id,mac_address,password) values('" + shopID + "','" + frmLogin.mac_address + "','"+frmLogin.password1+"')");
                        objDBAccess.executeQuery(cmdShopId);
                    }
                    try
                    {
                        tbSId.Clear();
                        tbSId.Dispose();
                    }
                    catch (Exception) { }
                }
                tbShopId.Clear();
                tbShopId.Dispose();
                tbID.Clear();
                cmdShop.Dispose();
                tbID.Dispose();
            }

            //Getting properties from selected product
            price = tbProducts.Rows[managerProduct.Position]["нархи"].ToString();
            barcode = tbProducts.Rows[managerProduct.Position]["штрих_код"].ToString();
            oldquantity = tbProducts.Rows[managerProduct.Position]["микдори"].ToString();
            if(oldquantity=="0")
            {
                MessageBox.Show("Ушбу махсулот тугаган", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbProducts.Clear();
                dbgridProducts.Visible = false;
                Refresh();
                return;
            }
            product_id = tbProducts.Rows[managerProduct.Position]["product_id"].ToString();
            name = tbProducts.Rows[managerProduct.Position]["номи"].ToString();
            bool isopen = false;
            foreach (Form f1 in Application.OpenForms)
            {
                if (f1.Text == "Корзинка")
                {
                    isopen = true;
                    f1.BringToFront();
                    break;
                }
            }
            if (isopen == false)
            {
                frmSaleQuantity f2 = new frmSaleQuantity();
                f2.barcode = barcode;
                f2.price = price;
                f2.oldquantity = oldquantity;
                f2.product_id = product_id;
                f2.name = name;
                f2.ShowDialog();
                tbProducts.Clear();
                dbgridProducts.Visible = false;
            }
            
        }

        public void iconButton3_Click(object sender, EventArgs e)
        {
            if (shopID == 0 || tbBasket.Rows.Count==0)
            {
                return;
            }

            double summa = 0;
            foreach (DataRow dtColimn in tbBasket.Rows)
            {
                string each_summa = "";
                if(dtColimn["умумий_сумма"].ToString().IndexOf(',') > -1)
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

            string str_summa = summa.ToString();
            if(str_summa.IndexOf(',') > -1)
            {
                int index_summa = str_summa.IndexOf(',');
                string first_summa = str_summa.Substring(0, index_summa);
                string last_summa = str_summa.Substring(index_summa + 1);
                str_summa = first_summa + "." + last_summa;
            }
            cmd = new MySqlCommand("update shop set jamisumma='" + str_summa + "', queue=1 where id='" + shopID + "'");
            objDBAccess.executeQuery(cmd);
            cmd.Dispose();

            string queryShopId = "select * from shopId where password='"+frmLogin.password1+"'";
            tbShopId = new DataTable();
            objDBAccess.readDatathroughAdapter(queryShopId, tbShopId);
            if (tbShopId.Rows.Count > 0)
            {
                cmdShopId = new MySqlCommand("update shopId set shop_id=0 where password='"+frmLogin.password1+"'");
                objDBAccess.executeQuery(cmdShopId);
            }
            else
            {
                string queryId = "select * from shopId order by id desc limit 1";
                DataTable tbSId = new DataTable();
                objDBAccess.readDatathroughAdapter(queryId, tbSId);
                if (tbSId.Rows.Count == 0)
                {
                    cmdShopId = new MySqlCommand("insert into shopId values(1,0,'" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
                    objDBAccess.executeQuery(cmdShopId);
                }
                else
                {
                    cmdShopId = new MySqlCommand("insert into shopId (shop_id,mac_address,password) values(0,'" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
                    objDBAccess.executeQuery(cmdShopId);
                }
                try
                {
                    tbSId.Clear();
                    tbSId.Dispose();
                }
                catch (Exception) { }
            }
            tbShopId.Clear();
            tbShopId.Dispose();

            MessageBox.Show("Товарлар кутишга ўтказилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            printWaiting.Print();
            shopID = 0;
            shop = false;
            Refresh();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 2)
            {
                string querySearch = "";
                try
                {
                    double number = double.Parse(txtSearch.Text, CultureInfo.InvariantCulture);
                    if (txtSearch.Text.Length > 5)
                    {
                        querySearch = "select product_id,name as номи, price as нархи,quantity as микдори, barcode as штрих_код from product where barcode LIKE'%" + txtSearch.Text + "%'";
                        string queryCart = "select product_id, name as Номи, price as Нархи,quantity as Микдори, total as Умумий_сумма from cart " +
                        "inner join shop on cart.shop_id=shop.id inner join shopId on shopId.shop_id=cart.shop_id where shop.id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
                        string queryTulovSumma = "select sum(total) from cart inner join shopId on cart.shop_id=shopId.shop_id where cart.shop_id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
                        tbProducts.Clear();
                        tbBasket.Clear();
                        tbTulovSumma.Clear();
                        objDBAccess.readDatathroughAdapter(querySearch, tbProducts);
                        dbgridProducts.DataSource = tbProducts;
                        dbgridProducts.Visible = true;
                        objDBAccess.readDatathroughAdapter(queryCart, tbBasket);
                        objDBAccess.readDatathroughAdapter(queryTulovSumma, tbTulovSumma);
                    }
                }
                catch (Exception)
                {
                    querySearch = "select product_id,name as номи, price as нархи,quantity as микдори, barcode as штрих_код from product where name LIKE'%" + txtSearch.Text + "%'";
                    string queryCart = "select product_id, name as Номи, price as Нархи,quantity as Микдори, total as Умумий_сумма from cart " +
                    "inner join shop on cart.shop_id=shop.id inner join shopId on shopId.shop_id=cart.shop_id where shop.id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
                    string queryTulovSumma = "select sum(total) from cart inner join shopId on cart.shop_id=shopId.shop_id where cart.shop_id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
                    tbProducts.Clear();
                    tbBasket.Clear();
                    tbTulovSumma.Clear();
                    objDBAccess.readDatathroughAdapter(querySearch, tbProducts);
                    dbgridProducts.DataSource = tbProducts;
                    dbgridProducts.Visible = true;
                    objDBAccess.readDatathroughAdapter(queryCart, tbBasket);
                    objDBAccess.readDatathroughAdapter(queryTulovSumma, tbTulovSumma);
                }
            }
            else
            {
                dbgridProducts.Visible = false;
                objDBAccess.createConn();
                string queryProduct = "select product_id,name as номи, price as нархи,quantity as микдори, barcode as штрих_код from product limit 1";
                string queryCart = "select product_id, name as Номи, price as Нархи,quantity as Микдори, total as Умумий_сумма from cart " +
                "inner join shop on cart.shop_id=shop.id inner join shopId on shopId.shop_id=cart.shop_id where shop.id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
                string queryTulovSumma = "select sum(total) from cart inner join shopId on cart.shop_id=shopId.shop_id where cart.shop_id='" + shopID + "' and shopId.mac_address='" + frmLogin.mac_address + "'";
                try { tbProducts.Clear(); } catch (Exception) { }
                tbBasket.Clear();
                tbTulovSumma.Clear();
                objDBAccess.readDatathroughAdapter(queryProduct, tbProducts);
                objDBAccess.readDatathroughAdapter(queryCart, tbBasket);
                objDBAccess.readDatathroughAdapter(queryTulovSumma, tbTulovSumma);
            }

        }

    }
}
