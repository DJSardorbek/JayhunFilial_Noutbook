using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Jayhunelectro
{
    public partial class frmDebtList : Form
    {
        public frmDebtList()
        {
            InitializeComponent();
        }
        DBAccess objDBAccess = new DBAccess();
        MySqlCommand cmdDebtor, cmdDebtCart, cmdDebtHistory;
        public static DataTable tbUmumiy, tbDebtCart, tbDebtor, tbJamiNasiya, tbJamiNasiyaQaytishi, tbSumJamiNasiya, tbJamiQaytSumma; // Nayiya ro'yhati uchun
        public static DataTable tbReturn_dataDelete, tbNasiyaDelete, tbpayDelete; // Nasiya ro'yhati uchun
        public static CurrencyManager managerDebtSumma, managerCartDebt, managerDebtor, managerSoldhistoryShop, managerSoldhistoryCart;
        public static DataTable tbPayhistory, tbSoldhistoryShop, tbSoldhistoryCart;  // to'lov tarixi va qaytarish uchun
        public static DataTable tbReturnProduct, tbTotalReturnProduct, tbBirReturnProduct;
        public string shop_id="", debt_quantity = "", debt_price = "", given_quantity = "", total = "", cartdebt_id="", difference=""; // qaytib olish uchun

        private void dbgridReturnProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridReturnProduct.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridReturnProductTotal_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridReturnProductTotal.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridPayhistory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridPayhistory.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void comboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtYear.Text=="")
            {
                DateTime dt_now = DateTime.Now;
                string month = dt_now.ToString("yyyy-MM");
                string queryJamiNasiya = "select sum(nasiya), sum(difference) from shop where date like '" + month + "%'";
                tbSumJamiNasiya.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiNasiya, tbSumJamiNasiya);

                string queryJamiNasiyaQaytishi = "select sum(given_summa) from payhistory where date like '" + month + "%'";
                tbJamiNasiyaQaytishi.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiNasiyaQaytishi, tbJamiNasiyaQaytishi);

                string queryJamiQaytSumma = "select sum(summa) as Кайт_сумма from returnproduct where debt=1 and date like '" + month + "%'";
                tbJamiQaytSumma.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiQaytSumma, tbJamiQaytSumma);

                tbJamiNasiya.Clear();

                DataRow rows = tbJamiNasiya.NewRow();
                if (tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString() == "") { rows["Жами_насия"] = "0"; }
                else { rows["Жами_насия"] = tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString(); }
                if (tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString() == "") { rows["Насия_кайтиши"] = "0"; }
                else { rows["Насия_кайтиши"] = tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString(); }
                if (tbJamiQaytSumma.Rows[0]["Кайт_сумма"].ToString() == "") { rows["Кайт_сумма"] = "0"; }
                else { rows["Кайт_сумма"] = tbJamiQaytSumma.Rows[0]["Кайт_сумма"].ToString(); }
                if (tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString() == "") { rows["Фарк"] = "0"; }
                else { rows["Фарк"] = tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString(); }
                tbJamiNasiya.Rows.Add(rows);

                txtYear.Text = dt_now.ToString("yyyy");
                for (int i = 0; i < 11; i++)
                {
                    if (comboMonth.Items[i].ToString() == dt_now.ToString("MMMM"))
                    {
                        comboMonth.SelectedIndex = i;
                        return;
                    }
                }
            }
            else
            {
                int month = comboMonth.SelectedIndex + 1;
                string month_year = "";
                if (month < 10) { month_year = txtYear.Text+"-0"+Convert.ToString(month); }
                else { month_year = txtYear.Text + "-" + Convert.ToString(month); }
                string queryJamiNasiya = "select sum(nasiya), sum(difference) from shop where date like '" + month_year + "%'";
                tbSumJamiNasiya.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiNasiya, tbSumJamiNasiya);

                string queryJamiNasiyaQaytishi = "select sum(given_summa) from payhistory where date like '" + month_year + "%'";
                tbJamiNasiyaQaytishi.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiNasiyaQaytishi, tbJamiNasiyaQaytishi);

                string queryJamiQaytSumma = "select sum(summa) as Кайт_сумма from returnproduct where debt=1 and date like '" + month_year + "%'";
                tbJamiQaytSumma.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiQaytSumma, tbJamiQaytSumma);

                tbJamiNasiya.Clear();
                DataRow rows = tbJamiNasiya.NewRow();
                if (tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString() == "") { rows["Жами_насия"] = "0"; }
                else { rows["Жами_насия"] = tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString(); }
                if (tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString() == "") { rows["Насия_кайтиши"] = "0"; }
                else { rows["Насия_кайтиши"] = tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString(); }
                if (tbJamiQaytSumma.Rows[0]["Кайт_сумма"].ToString() == "") { rows["Кайт_сумма"] = "0"; }
                else { rows["Кайт_сумма"] = tbJamiQaytSumma.Rows[0]["Кайт_сумма"].ToString(); }
                if (tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString() == "") { rows["Фарк"] = "0"; }
                else { rows["Фарк"] = tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString(); }
                tbJamiNasiya.Rows.Add(rows);
                
            }
        }

        private void comboQaytMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtQaytYear.Text == "")
            {
                DateTime dt_now = DateTime.Now;
                string month_year = dt_now.ToString("yyyy-MM");
                string queryReturnProduct = "select cart.name as Номи, cart.quantity as Сотилган_микдор, cart.price as Сотилган_нарх, shop.date as Сотилган_сана, returnproduct.return_quantity as Кайтган_микдор, returnproduct.summa as Кайтган_сумма, returnproduct.date as Кайтган_сана, product.price as Сотув_нархи, returnproduct.difference as Фарк " +
                    "from returnproduct  inner join cart using(shop_id, product_id) inner join product using(product_id) inner join shop on returnproduct.shop_id=shop.id where returnproduct.debt=1 and returnproduct.date like '" + month_year + "%' order by returnproduct.date";
                tbReturnProduct.Clear();
                objDBAccess.readDatathroughAdapter(queryReturnProduct, tbReturnProduct);

                tbBirReturnProduct.Clear();

                if (tbReturnProduct.Rows.Count > 0)
                {
                    string queryJamiReturnProduct = "select sum(summa) as Жами_кайтган_сумма, sum(difference) as Фарк from returnproduct where debt=1 and date like '" + month_year + "%'";
                    tbTotalReturnProduct.Clear();
                    objDBAccess.readDatathroughAdapter(queryJamiReturnProduct, tbTotalReturnProduct);

                    DataRow rowBirQaytgan = tbBirReturnProduct.NewRow();
                    rowBirQaytgan["Ой"] = dt_now.ToString("MMMM");
                    rowBirQaytgan["Жами_кайтган_сумма"] = tbTotalReturnProduct.Rows[0]["Жами_кайтган_сумма"].ToString();
                    rowBirQaytgan["Фарк"] = tbTotalReturnProduct.Rows[0]["Фарк"].ToString();

                    tbBirReturnProduct.Rows.Add(rowBirQaytgan);
                    tbTotalReturnProduct.Clear();
                }
            }
            else
            {
                int month = comboQaytMonth.SelectedIndex + 1;
                string month_year;
                if (month < 10) { month_year = txtQaytYear.Text + "-0" + Convert.ToString(month); }
                else { month_year = txtQaytYear.Text + "-" + Convert.ToString(month); }

                string queryReturnProduct = "select cart.name as Номи, cart.quantity as Сотилган_микдор, cart.price as Сотилган_нарх, shop.date as Сотилган_сана, returnproduct.return_quantity as Кайтган_микдор, returnproduct.summa as Кайтган_сумма, returnproduct.date as Кайтган_сана, product.price as Сотув_нархи, returnproduct.difference as Фарк " +
                    "from returnproduct  inner join cart using(shop_id, product_id) inner join product using(product_id) inner join shop on returnproduct.shop_id=shop.id where returnproduct.debt=1 and returnproduct.date like '" + month_year + "%' order by returnproduct.date";
                tbReturnProduct.Clear();
                objDBAccess.readDatathroughAdapter(queryReturnProduct, tbReturnProduct);

                tbBirReturnProduct.Clear();
                if (tbReturnProduct.Rows.Count > 0)
                {
                    string queryJamiReturnProduct = "select sum(summa) as Жами_кайтган_сумма, sum(difference) as Фарк from returnproduct where debt=1 and date like '" + month_year + "%'";
                    try
                    {
                        tbTotalReturnProduct.Clear();
                    }
                    catch (Exception) { tbTotalReturnProduct = new DataTable(); }
                    objDBAccess.readDatathroughAdapter(queryJamiReturnProduct, tbTotalReturnProduct);

                    DataRow rowBirQaytgan = tbBirReturnProduct.NewRow();
                    rowBirQaytgan["Ой"] = comboQaytMonth.Text;
                    rowBirQaytgan["Жами_кайтган_сумма"] = tbTotalReturnProduct.Rows[0]["Жами_кайтган_сумма"].ToString();
                    rowBirQaytgan["Фарк"] = tbTotalReturnProduct.Rows[0]["Фарк"].ToString();

                    tbBirReturnProduct.Rows.Add(rowBirQaytgan);
                    tbTotalReturnProduct.Clear();
                }
            }
        }

        private void dbgridSoldHistoryCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtSearchQaytOlish.Text != "")
            {
                try
                {
                    string querySoldhistoryShop = "select shop.id, shop.date as Сана, shop.nasiya as Насия, shop.naqd as Накд, shop.plastik as Пластик, shop.jamisumma as Жами_сумма, userprofile.first_name as Сотувчи from shop " +
                         "inner join userprofile on shop.sellar_id = userprofile.id where shop.id='" + tbSoldhistoryCart.Rows[managerSoldhistoryCart.Position]["shop_id"] + "'";
                    tbSoldhistoryShop.Clear();
                    objDBAccess.readDatathroughAdapter(querySoldhistoryShop, tbSoldhistoryShop);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void btnQaytOlish_Click(object sender, EventArgs e)
        {
            if (dbgridSoldHistoryCart.Rows.Count == 0) return;

            string debtorId = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();
            string productId = tbSoldhistoryCart.Rows[managerSoldhistoryCart.Position]["product_id"].ToString();
            string umumiy_qarz = tbUmumiy.Rows[managerDebtSumma.Position]["Умумий_карз"].ToString();
            //Qaytarilayotgan maxsulotni qolgan_miqdor, qolgan_summa, berilgan_miqdor, jamisumma larini cartdebt jadvalidan olamiz
            string queryCartDebtReturn = "select id, debt_quantity, debt_price, given_quantity, total, difference from cartdebt where debtor_id='" + debtorId + "' and product_id='" + productId + "' order by id desc";

            DataTable tbCartDebtReturn = new DataTable();
            objDBAccess.readDatathroughAdapter(queryCartDebtReturn, tbCartDebtReturn);
            shop_id = tbSoldhistoryShop.Rows[managerSoldhistoryShop.Position]["id"].ToString(); // shop_id
            cartdebt_id = tbCartDebtReturn.Rows[0]["id"].ToString();  // cartdebt_id
            debt_quantity = tbCartDebtReturn.Rows[0]["debt_quantity"].ToString(); // qolgan_miqdor
            debt_price =  tbCartDebtReturn.Rows[0]["debt_price"].ToString();  // qolgan_summa
            given_quantity = tbCartDebtReturn.Rows[0]["given_quantity"].ToString(); // berilgan_miqdor
            total = tbCartDebtReturn.Rows[0]["total"].ToString(); // jami_summa
            difference = tbCartDebtReturn.Rows[0]["difference"].ToString(); // farq
            tbCartDebtReturn.Clear();
            tbCartDebtReturn.Dispose();

            string cart_name = tbSoldhistoryCart.Rows[managerSoldhistoryCart.Position]["Номи"].ToString();
            string cart_price = tbSoldhistoryCart.Rows[managerSoldhistoryCart.Position]["Нархи"].ToString();

            frmReturnQuantity returnQuantity = new frmReturnQuantity();
            returnQuantity.name = cart_name; // nomi
            returnQuantity.old_price = cart_price; // oldingi_narxi
            returnQuantity.shop_id = shop_id;  // shop_id
            returnQuantity.product_id = productId; // product_id

            returnQuantity.debt_quantity = debt_quantity; // qolgan_miqdorni uzatamiz
            returnQuantity.debt_price = debt_price; // qolgan_summani uzatamiz 
            returnQuantity.given_quantity = given_quantity; // berilgan miqdorni uzatamiz
            returnQuantity.cartdebt_total =  total; // jami_summa ni uzatamiz
            returnQuantity.cartdebt_id = cartdebt_id; // cartdebt_id ni uzatamiz
            returnQuantity.debtor_id = debtorId; // debtor_id ni uzatamiz
            returnQuantity.umumiy_qarz = umumiy_qarz; // umumiy_qarzni uzatamiz
            returnQuantity.diff = difference; // farqni uzatamiz

            returnQuantity.debt = true; returnQuantity.sold = false;
            returnQuantity.ShowDialog();

        }

        private void txtSearchQaytOlish_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchQaytOlish.Text == "")
            {
                string debtorId = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();
                string productId = tbDebtCart.Rows[managerCartDebt.Position]["product_id"].ToString();
                string debtor = tbUmumiy.Rows[managerDebtSumma.Position]["Мижоз_фиш"].ToString();
                lblDebtor.Text = debtor;
                string querySoldhistoryShop = "select shop.id, shop.date as Сана, shop.nasiya as Насия, shop.naqd as Накд, shop.plastik as Пластик, shop.jamisumma as Жами_сумма, userprofile.first_name as Сотувчи from shop " +
                    "inner join userprofile on shop.sellar_id = userprofile.id where shop.id in (select shop_id from debt where debtor_id ='" + debtorId + "') order by shop.date desc";
                tbSoldhistoryShop.Clear();
                objDBAccess.readDatathroughAdapter(querySoldhistoryShop, tbSoldhistoryShop);
                tbSoldhistoryCart.Clear();
                string shopId = "";
                if (tbSoldhistoryShop.Rows.Count > 0)
                {
                    shopId = tbSoldhistoryShop.Rows[managerSoldhistoryShop.Position]["id"].ToString();
                    string querySoldhistoryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shopId + "'";
                    objDBAccess.readDatathroughAdapter(querySoldhistoryCart, tbSoldhistoryCart);
                }
                else
                {
                    shopId = "0";
                    string querySoldhistoryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shopId + "'";
                    objDBAccess.readDatathroughAdapter(querySoldhistoryCart, tbSoldhistoryCart);
                }
            }
            else
            {
                string debtorId = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();
                string searchSoldCart = txtSearchQaytOlish.Text;
                tbSoldhistoryCart.Clear();
                string querySearchSoldCart = "select shop_id, product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart " +
                "inner join shop on cart.shop_id=shop.id where shop_id in (select shop_id from debt where debtor_id ='" + debtorId + "') and name like '"+searchSoldCart+"%' order by shop.date desc";
                objDBAccess.readDatathroughAdapter(querySearchSoldCart, tbSoldhistoryCart);

                if(tbSoldhistoryCart.Rows.Count > 0)
                {
                    string querySoldhistoryShop = "select shop.id, shop.date as Сана, shop.nasiya as Насия, shop.naqd as Накд, shop.plastik as Пластик, shop.jamisumma as Жами_сумма, userprofile.first_name as Сотувчи from shop " +
                        "inner join userprofile on shop.sellar_id = userprofile.id where shop.id='"+tbSoldhistoryCart.Rows[managerSoldhistoryCart.Position]["shop_id"]+"'";
                    tbSoldhistoryShop.Clear();
                    objDBAccess.readDatathroughAdapter(querySoldhistoryShop, tbSoldhistoryShop);
                }
            }
        }

        private void lblDebtor_Click(object sender, EventArgs e)
        {

        }

        private void dbgridSoldhistoryShop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbSoldhistoryCart.Clear();
            string shopId = "";
            if (tbSoldhistoryShop.Rows.Count > 0)
            {
                shopId = tbSoldhistoryShop.Rows[managerSoldhistoryShop.Position]["id"].ToString();
                string querySoldhistoryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shopId + "'";
                objDBAccess.readDatathroughAdapter(querySoldhistoryCart, tbSoldhistoryCart);
            }
            else
            {
                shopId = "0";
                string querySoldhistoryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shopId + "'";
                objDBAccess.readDatathroughAdapter(querySoldhistoryCart, tbSoldhistoryCart);
            }
        }

        private void dbgridSoldhistoryShop_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridSoldhistoryShop.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridSoldHistoryCart_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridSoldHistoryCart.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        public void btnQaytaribOlish_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            tabControl1_Click(sender, e);
        }

        public void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (tbUmumiy.Rows.Count > 0)
                {
                    string debtorId = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();
                    string queryPayhistory = "select debtor.mijoz_fish as Мижоз_фиш, payhistory.given_summa as Тўланган_сумма, payhistory.date as Сана from payhistory " +
                        "inner join debtor on payhistory.debtor_id = debtor.id where payhistory.debtor_id='" + debtorId + "' order by payhistory.date desc";
                    tbPayhistory = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryPayhistory, tbPayhistory);
                    dbgridPayhistory.DataSource = tbPayhistory;
                    dbgridPayhistory.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
            }

            if(tabControl1.SelectedIndex == 2)
            {
                if (tbUmumiy.Rows.Count > 0)
                {
                    string debtorId = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();
                    string productId = tbDebtCart.Rows[managerCartDebt.Position]["product_id"].ToString();
                    string debtor = tbUmumiy.Rows[managerDebtSumma.Position]["Мижоз_фиш"].ToString();
                    lblDebtor.Text = debtor;
                    string querySoldhistoryShop = "select shop.id, shop.date as Сана, shop.nasiya as Насия, shop.naqd as Накд, shop.plastik as Пластик, shop.jamisumma as Жами_сумма, userprofile.first_name as Сотувчи from shop " +
                        "inner join userprofile on shop.sellar_id = userprofile.id where shop.id in (select shop_id from debt where debtor_id ='"+debtorId+"') order by shop.date desc";
                    tbSoldhistoryShop = new DataTable();
                    objDBAccess.readDatathroughAdapter(querySoldhistoryShop, tbSoldhistoryShop);
                    managerSoldhistoryShop = (CurrencyManager)BindingContext[tbSoldhistoryShop];
                    dbgridSoldhistoryShop.DataSource = tbSoldhistoryShop;
                    dbgridSoldhistoryShop.Columns[0].Visible = false;
                    dbgridSoldhistoryShop.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                    tbSoldhistoryCart = new DataTable();
                    string shopId = "";
                    if (tbSoldhistoryShop.Rows.Count > 0)
                    {
                        shopId = tbSoldhistoryShop.Rows[managerSoldhistoryShop.Position]["id"].ToString();
                        string querySoldhistoryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shopId+"'";
                        objDBAccess.readDatathroughAdapter(querySoldhistoryCart, tbSoldhistoryCart);
                    }
                    else
                    {
                        shopId = "0";
                        string querySoldhistoryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + shopId + "'";
                        objDBAccess.readDatathroughAdapter(querySoldhistoryCart, tbSoldhistoryCart);
                    }
                    managerSoldhistoryCart = (CurrencyManager)BindingContext[tbSoldhistoryCart];
                    dbgridSoldHistoryCart.DataSource = tbSoldhistoryCart;
                    dbgridSoldHistoryCart.Columns[0].Visible = false;
                    dbgridSoldHistoryCart.Columns[1].Visible = false;
                    dbgridSoldHistoryCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
            }
            if(tabControl1.SelectedIndex == 3) // Qaytgan tovarlar uchun
            {
                DateTime dt_now = DateTime.Now;
                string month_year = dt_now.ToString("yyyy-MM");
                string queryReturnProduct = "select cart.name as Номи, cart.quantity as Сотилган_микдор, cart.price as Сотилган_нарх, shop.date as Сотилган_сана, returnproduct.return_quantity as Кайтган_микдор, returnproduct.summa as Кайтган_сумма, returnproduct.date as Кайтган_сана, product.price as Сотув_нархи, returnproduct.difference as Фарк " +
                    "from returnproduct inner join cart using(shop_id, product_id) inner join product using(product_id) inner join shop on returnproduct.shop_id=shop.id where returnproduct.debt=1 and returnproduct.date like '" + month_year + "%' order by returnproduct.date";
                tbReturnProduct = new DataTable();
                objDBAccess.readDatathroughAdapter(queryReturnProduct, tbReturnProduct);
                dbgridReturnProduct.DataSource = tbReturnProduct;
                dbgridReturnProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbReturnProduct.Dispose();

                tbBirReturnProduct = new DataTable();
                tbBirReturnProduct.Columns.Add("Ой");
                tbBirReturnProduct.Columns.Add("Жами_кайтган_сумма");
                tbBirReturnProduct.Columns.Add("Фарк");

                if (tbReturnProduct.Rows.Count > 0)
                {
                    string queryJamiReturnProduct = "select sum(summa) as Жами_кайтган_сумма, sum(difference) as Фарк from returnproduct where debt=1 and date like '" + month_year + "%'";
                    tbTotalReturnProduct = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryJamiReturnProduct, tbTotalReturnProduct);

                    DataRow rowBirQaytgan = tbBirReturnProduct.NewRow();
                    rowBirQaytgan["Ой"] = dt_now.ToString("MMMM");
                    rowBirQaytgan["Жами_кайтган_сумма"] = tbTotalReturnProduct.Rows[0]["Жами_кайтган_сумма"].ToString();
                    rowBirQaytgan["Фарк"] = tbTotalReturnProduct.Rows[0]["Фарк"].ToString();

                    tbBirReturnProduct.Rows.Add(rowBirQaytgan);
                    tbTotalReturnProduct.Clear();
                    tbTotalReturnProduct.Dispose();
                }
                dbgridReturnProductTotal.DataSource = tbBirReturnProduct;
                dbgridReturnProductTotal.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbBirReturnProduct.Dispose();
                txtQaytYear.Text = dt_now.ToString("yyyy");
                for (int i = 0; i < 11; i++)
                {
                    if (comboQaytMonth.Items[i].ToString() == dt_now.ToString("MMMM"))
                    {
                        comboQaytMonth.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        string name ="", qolgan_miqdor="", price="", debtor_id="", product_id="", umumiy_qarz=""; // to'lash uchun
        
        private void dbgridDebtSumma_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridDebtSumma.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }

        }

        private void dbgridJamiNasiya_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridJamiNasiya.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        public void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                тўлашToolStripMenuItem_Click(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text=="")
            {
                Refresh();
            }
            else
            {
                string querySearch = "";
                if (comboSearchTypes.SelectedIndex == 0)
                {
                    querySearch = "select * from debtor where mijoz_fish like '%" + txtSearch.Text + "%'";
                }
                if(comboSearchTypes.SelectedIndex == 1)
                {
                    querySearch = "select * from debtor where tel_1 like '%" + txtSearch.Text + "%'";
                }
                if (comboSearchTypes.SelectedIndex == 2)
                {
                    querySearch = "select * from debtor where tel_2 like '%" + txtSearch.Text + "%'";
                }

                tbDebtor.Clear();
                objDBAccess.readDatathroughAdapter(querySearch, tbDebtor);
                if (tbDebtor.Rows.Count > 0)
                {
                    tbUmumiy.Clear();
                    DataRow row;
                    managerDebtor.Position = 0;
                    int Count = managerDebtor.Count;
                    string debtor_id = "";
                    tbReturn_dataDelete.Clear();
                    tbNasiyaDelete.Clear();
                    tbpayDelete.Clear();
                    for (int i = 0; i < Count; i++)
                    {
                        debtor_id = tbDebtor.Rows[managerDebtor.Position]["id"].ToString();

                        string queryReturn_date = "select return_date from debt where debtor_id='" + debtor_id + "' order by id desc limit 1";

                        objDBAccess.readDatathroughAdapter(queryReturn_date, tbReturn_dataDelete);

                        string queryNasiya = "select sum(nasiya), sum(difference) from shop where id in(select shop_id from debt where debtor_id = '" + debtor_id + "')";

                        objDBAccess.readDatathroughAdapter(queryNasiya, tbNasiyaDelete);

                        string queryPay = "select sum(given_summa) from payhistory where debtor_id='" + debtor_id + "'";

                        objDBAccess.readDatathroughAdapter(queryPay, tbpayDelete);

                        row = tbUmumiy.NewRow();
                        row["id"] = tbDebtor.Rows[managerDebtor.Position]["id"].ToString();
                        row["Мижоз_фиш"] = tbDebtor.Rows[managerDebtor.Position]["mijoz_fish"].ToString();
                        row["Тэл_1"] = tbDebtor.Rows[managerDebtor.Position]["tel_1"].ToString();
                        row["Тэл_2"] = tbDebtor.Rows[managerDebtor.Position]["tel_2"].ToString();
                        row["Умумий_карз"] = tbDebtor.Rows[managerDebtor.Position]["umumiy_qarz"].ToString();
                        row["Охирги_сана"] = tbReturn_dataDelete.Rows[0]["return_date"].ToString();
                        row["Умумий_насия"] = tbNasiyaDelete.Rows[0]["sum(nasiya)"].ToString();
                        row["Фарк"] = tbNasiyaDelete.Rows[0]["sum(difference)"].ToString();
                        if (tbpayDelete.Rows[0]["sum(given_summa)"].ToString() == "") { row["Насия_кайтиши"] = "0"; }
                        else { row["Насия_кайтиши"] = tbpayDelete.Rows[0]["sum(given_summa)"].ToString(); }
                        tbUmumiy.Rows.Add(row);
                        tbReturn_dataDelete.Clear();
                        tbReturn_dataDelete.Dispose();
                        tbNasiyaDelete.Clear();
                        tbNasiyaDelete.Dispose();
                        tbpayDelete.Clear();
                        tbpayDelete.Dispose();
                        managerDebtor.Position++;
                    }
                    string id = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();

                    string queryCartdebt = "select product_id, name as Номи,price as Нархи, given_quantity as Бэрилган_микдор, total as Умумий_сумма, return_quantity as Тўланган_микдор, return_price as Тўланган_сумма, debt_quantity as Колган_микдор, debt_price as Колган_сумма, difference as Фарк " +
                        "from cartdebt where debtor_id='" + id + "'";
                    tbDebtCart.Clear();
                    objDBAccess.readDatathroughAdapter(queryCartdebt, tbDebtCart);
                    dbgridDebtCart.DataSource = tbDebtCart;
                }
                else
                {
                    tbUmumiy.Clear();
                    tbDebtCart.Clear();
                }
                string queryJamiNasiya = "select sum(nasiya), sum(difference) from shop";
                tbSumJamiNasiya.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiNasiya, tbSumJamiNasiya);
                string queryJamiNasiyaQaytishi = "select sum(given_summa) from payhistory";
                tbJamiNasiyaQaytishi.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiNasiyaQaytishi, tbJamiNasiyaQaytishi);
               /* tbJamiNasiya.Clear();
                DataRow rows = tbJamiNasiya.NewRow();
                rows["Жами_насия"] = tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString();
                rows["Насия_кайтиши"] = tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString();
                rows["Фарк"] = tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString();
                tbJamiNasiya.Rows.Add(rows);*/
            }
        }

        private void frmDebtList_SizeChanged(object sender, EventArgs e)
        {
            if(Width <=1123 && Height <=700)
            {
                dbgridDebtSumma.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            if(Width >1123 && Height >=700)
            {
                dbgridDebtSumma.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            if(Width > 1378 && Height > 780)
            {
                dbgridDebtCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            if(Width <= 1378 && Height <= 780)
            {
                dbgridDebtCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void dbgridDebtCart_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridDebtCart.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridDebtSumma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            debtor_id = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();
            string queryCartdebt = "select product_id, name as Номи,price as Нархи, given_quantity as Бэрилган_микдор, total as Умумий_сумма, return_quantity as Тўланган_микдор, return_price as Тўланган_сумма, debt_quantity as Колган_микдор, debt_price as Колган_сумма, difference as Фарк " +
                    "from cartdebt where debtor_id='" + debtor_id + "'";
            tbDebtCart.Clear();
            objDBAccess.readDatathroughAdapter(queryCartdebt, tbDebtCart);
            dbgridDebtCart.DataSource = tbDebtCart;
        }

        public void тўлашToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cartdebt jadvalidagi ma'lumotlarni panelga uzatamiz
            debtor_id = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();  // debtor id ni tbumumiy jadvalidan olamiz
            umumiy_qarz = tbUmumiy.Rows[managerDebtSumma.Position]["Умумий_карз"].ToString(); // umumiy_qarzni tbumumiy jadvalidan olamiz
            product_id = tbDebtCart.Rows[managerCartDebt.Position]["product_id"].ToString();
            name = tbDebtCart.Rows[managerCartDebt.Position]["Номи"].ToString();
            qolgan_miqdor = tbDebtCart.Rows[managerCartDebt.Position]["Колган_микдор"].ToString();
            price = tbDebtCart.Rows[managerCartDebt.Position]["Нархи"].ToString();

            frmDebtTulov debtTulov = new frmDebtTulov();
            debtTulov.debtor_id = debtor_id;
            debtTulov.umumiy_qarz = umumiy_qarz;
            debtTulov.product_id = product_id;
            debtTulov.name = name;
            debtTulov.qolgan_miqdor = qolgan_miqdor;
            debtTulov.price = price;
            debtTulov.ShowDialog();
        }

        private void frmDebtList_Load(object sender, EventArgs e)
        {
            comboSearchTypes.SelectedIndex = 0;
            objDBAccess.createConn();
            string queryDebtor = "select * from debtor";
            tbDebtor = new DataTable();
            objDBAccess.readDatathroughAdapter(queryDebtor, tbDebtor);
            managerDebtor = (CurrencyManager)BindingContext[tbDebtor]; // Debtor jadvali uchun manager

            tbUmumiy = new DataTable();
            tbUmumiy.Columns.Add("id", typeof(int));
            tbUmumiy.Columns.Add("Мижоз_фиш");
            tbUmumiy.Columns.Add("Тэл_1");
            tbUmumiy.Columns.Add("Тэл_2");
            tbUmumiy.Columns.Add("Умумий_насия");
            tbUmumiy.Columns.Add("Умумий_карз");
            tbUmumiy.Columns.Add("Насия_кайтиши");
            tbUmumiy.Columns.Add("Охирги_сана", typeof(DateTime));
            tbUmumiy.Columns.Add("Фарк");
            if (tbDebtor.Rows.Count > 0)
            {
                DataRow row;
                managerDebtor.Position = 0;
                int Count = managerDebtor.Count;
                string debtor_id = "";
                tbReturn_dataDelete = new DataTable();
                tbNasiyaDelete = new DataTable();
                tbpayDelete = new DataTable();
                for (int i = 0; i<Count; i++)
                {
                    debtor_id = tbDebtor.Rows[managerDebtor.Position]["id"].ToString();

                    string queryReturn_date = "select return_date from debt where debtor_id='" + debtor_id + "' order by id desc limit 1";
                    
                    objDBAccess.readDatathroughAdapter(queryReturn_date, tbReturn_dataDelete);

                    string queryNasiya = "select sum(nasiya), sum(difference) from shop where id in(select shop_id from debt where debtor_id = '" + debtor_id + "')";
                    
                    objDBAccess.readDatathroughAdapter(queryNasiya, tbNasiyaDelete);

                    string queryPay = "select sum(given_summa) from payhistory where debtor_id='" + debtor_id + "'";
                    
                    objDBAccess.readDatathroughAdapter(queryPay, tbpayDelete);

                    row = tbUmumiy.NewRow();
                    row["id"] = tbDebtor.Rows[managerDebtor.Position]["id"].ToString();
                    row["Мижоз_фиш"] = tbDebtor.Rows[managerDebtor.Position]["mijoz_fish"].ToString();
                    row["Тэл_1"] = tbDebtor.Rows[managerDebtor.Position]["tel_1"].ToString();
                    row["Тэл_2"] = tbDebtor.Rows[managerDebtor.Position]["tel_2"].ToString();
                    row["Умумий_карз"] = tbDebtor.Rows[managerDebtor.Position]["umumiy_qarz"].ToString();
                    row["Охирги_сана"] = tbReturn_dataDelete.Rows[0]["return_date"].ToString();
                    row["Умумий_насия"] = tbNasiyaDelete.Rows[0]["sum(nasiya)"].ToString();
                    row["Фарк"] = tbNasiyaDelete.Rows[0]["sum(difference)"].ToString();
                    if (tbpayDelete.Rows[0]["sum(given_summa)"].ToString() == "") { row["Насия_кайтиши"] = "0"; }
                    else { row["Насия_кайтиши"] = tbpayDelete.Rows[0]["sum(given_summa)"].ToString(); }
                    tbUmumiy.Rows.Add(row);
                    tbReturn_dataDelete.Clear();
                    tbReturn_dataDelete.Dispose();
                    tbNasiyaDelete.Clear();
                    tbNasiyaDelete.Dispose();
                    tbpayDelete.Clear();
                    tbpayDelete.Dispose();
                    managerDebtor.Position++;
                }

                managerDebtSumma = (CurrencyManager)BindingContext[tbUmumiy];  // tbUmumiy jadvali uchun manager
                dbgridDebtSumma.DataSource = tbUmumiy;
                dbgridDebtSumma.Columns[0].Visible = false;
                dbgridDebtSumma.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbDebtor.Dispose();
                string id = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();
                string queryCartdebt = "select product_id, name as Номи,price as Нархи, given_quantity as Бэрилган_микдор, total as Умумий_сумма, return_quantity as Тўланган_микдор, return_price as Тўланган_сумма, debt_quantity as Колган_микдор, debt_price as Колган_сумма, difference as Фарк " +
                    "from cartdebt where debtor_id='" + id + "'";
                tbDebtCart = new DataTable();
                objDBAccess.readDatathroughAdapter(queryCartdebt, tbDebtCart);
                managerCartDebt = (CurrencyManager)BindingContext[tbDebtCart];
                dbgridDebtCart.DataSource = tbDebtCart;
                dbgridDebtCart.Columns[0].Visible = false;
                dbgridDebtCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbDebtCart.Dispose();
            }
            DateTime dt_now = DateTime.Now;
            string month = dt_now.ToString("yyyy-MM");
            string queryJamiNasiya = "select sum(nasiya), sum(difference) from shop where date like '"+month+"%'";
            tbSumJamiNasiya = new DataTable();
            objDBAccess.readDatathroughAdapter(queryJamiNasiya, tbSumJamiNasiya);

            string queryJamiNasiyaQaytishi = "select sum(given_summa) from payhistory where date like '"+month+"%'";
            tbJamiNasiyaQaytishi = new DataTable();
            objDBAccess.readDatathroughAdapter(queryJamiNasiyaQaytishi, tbJamiNasiyaQaytishi);

            string queryJamiQaytSumma = "select sum(summa) as Кайт_сумма from returnproduct where debt=1 and date like '" + month + "%'";
            tbJamiQaytSumma = new DataTable();
            objDBAccess.readDatathroughAdapter(queryJamiQaytSumma, tbJamiQaytSumma);

            tbJamiNasiya = new DataTable();
            tbJamiNasiya.Columns.Add("Жами_насия");
            tbJamiNasiya.Columns.Add("Насия_кайтиши");
            tbJamiNasiya.Columns.Add("Кайт_сумма");
            tbJamiNasiya.Columns.Add("Фарк");

            DataRow rows = tbJamiNasiya.NewRow();
            if (tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString() == "") { rows["Жами_насия"] = "0"; }
            else { rows["Жами_насия"] = tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString(); }
            if (tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString() == "") { rows["Насия_кайтиши"] = "0"; }
            else { rows["Насия_кайтиши"] = tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString(); }
            if (tbJamiQaytSumma.Rows[0]["Кайт_сумма"].ToString() == "") { rows["Кайт_сумма"] = "0"; }
            else { rows["Кайт_сумма"] = tbJamiQaytSumma.Rows[0]["Кайт_сумма"].ToString(); }
            if (tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString() == "") { rows["Фарк"] = "0"; }
            else { rows["Фарк"] = tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString(); }
            tbJamiNasiya.Rows.Add(rows);

            dbgridJamiNasiya.DataSource = tbJamiNasiya;
            dbgridJamiNasiya.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            tbSumJamiNasiya.Dispose();
            tbJamiNasiyaQaytishi.Dispose();
            tbJamiNasiya.Dispose();
            tbJamiQaytSumma.Dispose();
            tbUmumiy.Dispose();
            txtYear.Text = dt_now.ToString("yyyy");
            for(int i = 0; i<11; i++)
            {
                if(comboMonth.Items[i].ToString() == dt_now.ToString("MMMM"))
                {
                    comboMonth.SelectedIndex = i;
                    return;
                }
            }
        }
        public void Refresh()
        {
            try
            {
                int DebtSummaPosition = managerDebtSumma.Position;
                int DebtCartPostion = managerCartDebt.Position;

                string queryDebtor = "select * from debtor";
                tbDebtor.Clear();
                objDBAccess.readDatathroughAdapter(queryDebtor, tbDebtor);
                if (tbDebtor.Rows.Count > 0)
                {
                    tbUmumiy.Clear();
                    DataRow row;
                    managerDebtor.Position = 0;
                    int Count = managerDebtor.Count;
                    string debtor_id = "";
                    tbReturn_dataDelete.Clear();
                    tbNasiyaDelete.Clear();
                    tbpayDelete.Clear();
                    for (int i = 0; i < Count; i++)
                    {
                        debtor_id = tbDebtor.Rows[managerDebtor.Position]["id"].ToString();

                        string queryReturn_date = "select return_date from debt where debtor_id='" + debtor_id + "' order by id desc limit 1";
                        
                        objDBAccess.readDatathroughAdapter(queryReturn_date, tbReturn_dataDelete);

                        string queryNasiya = "select sum(nasiya), sum(difference) from shop where id in(select shop_id from debt where debtor_id = '" + debtor_id + "')";
                        
                        objDBAccess.readDatathroughAdapter(queryNasiya, tbNasiyaDelete);

                        string queryPay = "select sum(given_summa) from payhistory where debtor_id='" + debtor_id + "'";
                        
                        objDBAccess.readDatathroughAdapter(queryPay, tbpayDelete);

                        row = tbUmumiy.NewRow();
                        row["id"] = tbDebtor.Rows[managerDebtor.Position]["id"].ToString();
                        row["Мижоз_фиш"] = tbDebtor.Rows[managerDebtor.Position]["mijoz_fish"].ToString();
                        row["Тэл_1"] = tbDebtor.Rows[managerDebtor.Position]["tel_1"].ToString();
                        row["Тэл_2"] = tbDebtor.Rows[managerDebtor.Position]["tel_2"].ToString();
                        row["Умумий_карз"] = tbDebtor.Rows[managerDebtor.Position]["umumiy_qarz"].ToString();
                        row["Охирги_сана"] = tbReturn_dataDelete.Rows[0]["return_date"].ToString();
                        row["Умумий_насия"] = tbNasiyaDelete.Rows[0]["sum(nasiya)"].ToString();
                        row["Фарк"] = tbNasiyaDelete.Rows[0]["sum(difference)"].ToString();
                        if (tbpayDelete.Rows[0]["sum(given_summa)"].ToString() == "") { row["Насия_кайтиши"] = "0"; }
                        else { row["Насия_кайтиши"] = tbpayDelete.Rows[0]["sum(given_summa)"].ToString(); }
                        tbUmumiy.Rows.Add(row);
                        tbReturn_dataDelete.Clear();
                        tbReturn_dataDelete.Dispose();
                        tbNasiyaDelete.Clear();
                        tbNasiyaDelete.Dispose();
                        tbpayDelete.Clear();
                        tbpayDelete.Dispose();
                        managerDebtor.Position++;
                    }
                    managerDebtSumma.Position = DebtSummaPosition;
                    string id = tbUmumiy.Rows[managerDebtSumma.Position]["id"].ToString();

                    string queryCartdebt = "select product_id, name as Номи,price as Нархи, given_quantity as Бэрилган_микдор, total as Умумий_сумма, return_quantity as Тўланган_микдор, return_price as Тўланган_сумма, debt_quantity as Колган_микдор, debt_price as Колган_сумма, difference as Фарк " +
                        "from cartdebt where debtor_id='" + id + "'";
                    tbDebtCart.Clear();
                    objDBAccess.readDatathroughAdapter(queryCartdebt, tbDebtCart);
                    dbgridDebtCart.DataSource = tbDebtCart;
                    managerCartDebt.Position = DebtCartPostion;
                }
                DateTime dt_now = DateTime.Now;
                string month = dt_now.ToString("yyyy-MM");
                string queryJamiNasiya = "select sum(nasiya), sum(difference) from shop where date like '"+month+"%'";
                tbSumJamiNasiya.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiNasiya, tbSumJamiNasiya);
                string queryJamiNasiyaQaytishi = "select sum(given_summa) from payhistory where date like '"+month+"%'";
                tbJamiNasiyaQaytishi.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiNasiyaQaytishi, tbJamiNasiyaQaytishi);
                string queryJamiQaytSumma = "select sum(summa) as Кайт_сумма from returnproduct where debt=1 and date like '" + month + "%'";
                tbJamiQaytSumma.Clear();
                objDBAccess.readDatathroughAdapter(queryJamiQaytSumma, tbJamiQaytSumma);
                tbJamiNasiya.Clear();
                DataRow rows = tbJamiNasiya.NewRow();
                //
                if (tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString() == "") { rows["Жами_насия"] = "0"; }
                else { rows["Жами_насия"] = tbSumJamiNasiya.Rows[0]["sum(nasiya)"].ToString(); }
                if (tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString() == "") { rows["Насия_кайтиши"] = "0"; }
                else { rows["Насия_кайтиши"] = tbJamiNasiyaQaytishi.Rows[0]["sum(given_summa)"].ToString(); }
                if (tbJamiQaytSumma.Rows[0]["Кайт_сумма"].ToString() == "") { rows["Кайт_сумма"] = "0"; }
                else { rows["Кайт_сумма"] = tbJamiQaytSumma.Rows[0]["Кайт_сумма"].ToString(); }
                if (tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString() == "") { rows["Фарк"] = "0"; }
                else { rows["Фарк"] = tbSumJamiNasiya.Rows[0]["sum(difference)"].ToString(); }
                tbJamiNasiya.Rows.Add(rows);

                txtYear.Text = dt_now.ToString("yyyy");
                for (int i = 0; i < 11; i++)
                {
                    if (comboMonth.Items[i].ToString() == dt_now.ToString("MMMM"))
                    {
                        comboMonth.SelectedIndex = i;
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
    }
}
