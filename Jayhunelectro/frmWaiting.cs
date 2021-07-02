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
using System.Globalization;

namespace Jayhunelectro
{
    public partial class frmWaiting : Form
    {
        public frmWaiting()
        {
            InitializeComponent();
        }
        DBAccess objDBAcces = new DBAccess();
        public static MySqlCommand cmdWaiting, cmdCart,cmdShop, cmd;
        public static CurrencyManager managerWaiting, managerBasket;
        public static DataTable tbWaiting, tbWaitingCart, tbBasket;
        public static DataTable tbShopId;
        public static MySqlCommand cmdShopId;

        private void dbgridWaiting_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridWaiting.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridWaitingCart_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridWaitingCart.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridWaiting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                shop_id = tbWaiting.Rows[managerWaiting.Position]["id"].ToString();
                string queryCart = "select name as номи, price as нархи, quantity as микдори, total as умумий_сумма from cart where shop_id='" + shop_id + "'";
                tbWaitingCart.Clear();
                objDBAccess.readDatathroughAdapter(queryCart, tbWaitingCart);
                dbgridWaitingCart.DataSource = tbWaitingCart;
                objDBAccess.closeConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           if(txtSearch.Text=="")
           {
                string queryWaiting = "select shop.id,shop.jamisumma as Жамисумма, shop.date as Сана, shop.queue as Кутиш, userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id = userprofile.id where shop.queue=1";
                tbWaiting = new DataTable();
                objDBAcces.readDatathroughAdapter(queryWaiting, tbWaiting);
                managerWaiting = (CurrencyManager)BindingContext[tbWaiting];
                dbgridWaiting.DataSource = tbWaiting;
                dbgridWaiting.Columns[0].Visible = false;
                if (managerWaiting.Count > 0)
                {
                    managerWaiting.Position = 0;
                    shop_id = tbWaiting.Rows[managerWaiting.Position]["id"].ToString();
                    string queryWaitingCart = "select name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shop_id + "'";
                    tbWaitingCart = new DataTable();
                    objDBAcces.readDatathroughAdapter(queryWaitingCart, tbWaitingCart);
                    dbgridWaitingCart.DataSource = tbWaitingCart;
                }
                tbWaiting.Dispose();
                objDBAcces.closeConn();
           }
           else
            {
                string querySearch = "select shop.id,shop.jamisumma as Жамисумма, shop.date as Сана, shop.queue as Кутиш, userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id = userprofile.id where shop.queue=1 and shop.id like "+"'%"+txtSearch.Text+"%'";
                tbWaiting = new DataTable();
                objDBAcces.readDatathroughAdapter(querySearch, tbWaiting);
                managerWaiting = (CurrencyManager)BindingContext[tbWaiting];
                dbgridWaiting.DataSource = tbWaiting;
                dbgridWaiting.Columns[0].Visible = false;
                try { tbWaitingCart.Clear();
                    tbWaitingCart.Dispose();
                }
                catch (Exception) { }
                if (managerWaiting.Count > 0)
                {
                    managerWaiting.Position = 0;
                    shop_id = tbWaiting.Rows[managerWaiting.Position]["id"].ToString();
                    string queryWaitingCart = "select name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shop_id + "'";
                    tbWaitingCart = new DataTable();
                    objDBAcces.readDatathroughAdapter(queryWaitingCart, tbWaitingCart);
                    dbgridWaitingCart.DataSource = tbWaitingCart;
                }
                tbWaiting.Dispose();
                objDBAcces.closeConn();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string shop_id = "";
        DBAccess objDBAccess = new DBAccess();
        private void frmWaiting_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            objDBAcces.createConn();
            string queryWaiting = "select shop.id,shop.jamisumma as Жамисумма, shop.date as Сана, shop.queue as Кутиш, userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id = userprofile.id where shop.queue=1";
            tbWaiting = new DataTable();
            objDBAcces.readDatathroughAdapter(queryWaiting, tbWaiting);
            managerWaiting = (CurrencyManager)BindingContext[tbWaiting];
            dbgridWaiting.DataSource = tbWaiting;
            dbgridWaiting.Columns[0].Visible = false;
            dbgridWaiting.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            if (managerWaiting.Count > 0)
            {
                managerWaiting.Position = 0;
                shop_id = tbWaiting.Rows[managerWaiting.Position]["id"].ToString();
                string queryWaitingCart = "select name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shop_id + "'";
                tbWaitingCart = new DataTable();
                objDBAcces.readDatathroughAdapter(queryWaitingCart, tbWaitingCart);
                dbgridWaitingCart.DataSource = tbWaitingCart;
            }
            dbgridWaitingCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            tbWaiting.Dispose();
            objDBAcces.closeConn();

        }
        public void Refresh()
        {
            string queryWaiting = "select shop.id,shop.jamisumma as Жамисумма, shop.date as Сана, shop.queue as Кутиш, userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id = userprofile.id where shop.queue=1";
            tbWaiting.Clear();
            objDBAcces.readDatathroughAdapter(queryWaiting, tbWaiting);
            tbWaitingCart.Clear();
            if (managerWaiting.Count > 0)
            {
                managerWaiting.Position = 0;
                shop_id = tbWaiting.Rows[managerWaiting.Position]["id"].ToString();
                string queryWaitingCart = "select name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shop_id + "'";
                objDBAcces.readDatathroughAdapter(queryWaitingCart, tbWaitingCart);
            }
                objDBAcces.closeConn();
        }

        /// <summary>
        /// Korzinkaga olish
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void button1_Click(object sender, EventArgs e)
        {
            if (frmSales.shopID != 0)
            {
                MessageBox.Show("Корзинка бўш эмас, илтимос аввал корзинкани тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string id = tbWaiting.Rows[managerWaiting.Position]["id"].ToString();
                DateTime dt = DateTime.Now;
                cmdWaiting = new MySqlCommand("update shop set queue=0,date='"+ dt.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + id + "'");
                objDBAcces.executeQuery(cmdWaiting);
                frmSales.shopID = int.Parse(id);
                frmSales.shop = true;

                string queryShopId = "select * from shopId where password='"+frmLogin.password1+"'";
                tbShopId = new DataTable();
                objDBAccess.readDatathroughAdapter(queryShopId, tbShopId);
                if (tbShopId.Rows.Count > 0)
                {
                    cmdShopId = new MySqlCommand("update shopId set shop_id='"+id+"' where password='"+frmLogin.password1+"'");
                    objDBAccess.executeQuery(cmdShopId);
                }
                else
                {
                    string queryId = "select * from shopId order by id desc limit 1";
                    DataTable tbSId = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryId, tbSId);
                    if (tbSId.Rows.Count == 0)
                    {
                        cmdShopId = new MySqlCommand("insert into shopId values(1,'" + id + "','" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
                        objDBAccess.executeQuery(cmdShopId);
                    }
                    else
                    {
                        cmdShopId = new MySqlCommand("insert into shopId (shop_id,mac_address,password) values('" + id + "','" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
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
                MessageBox.Show("Товарлар корзинкага ўтказилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tovarlarni bazaga qaytarish
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void button2_Click(object sender, EventArgs e)
        {
            try
            {
                objDBAcces.createConn();
                string shopID = tbWaiting.Rows[managerWaiting.Position]["id"].ToString();
                string queryBasket = "select * from cart where shop_id='" + shopID + "'";
                tbBasket = new DataTable();
                objDBAcces.readDatathroughAdapter(queryBasket, tbBasket);
                managerBasket = (CurrencyManager)BindingContext[tbBasket];
                managerBasket.Position = 0;
                int count = managerBasket.Count;
                string quantityBasket, product_id, quantityProduct, queryProduct;
                DataTable tbProductFill = new DataTable();
                for (int i = 0; i < count; i++)
                {
                    quantityBasket = tbBasket.Rows[managerBasket.Position]["quantity"].ToString(); // cart jadvalidagilarni miqdorini double ga tekshiramiz
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
                    product_id = tbBasket.Rows[managerBasket.Position]["product_id"].ToString();
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
                    managerBasket.Position++;
                }
                cmdCart = new MySqlCommand("delete from cart where shop_id='" + shopID + "'"); //Cart dan bekor qilinganlarni o'chiramiz/
                cmdShop = new MySqlCommand("delete from shop where id='" + shopID + "'"); //Shop dan bekor qilinganlarni o'chiramiz.
                objDBAccess.executeQuery(cmdCart);
                objDBAccess.executeQuery(cmdShop);
                MessageBox.Show("Товарлар базага кайтарилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
