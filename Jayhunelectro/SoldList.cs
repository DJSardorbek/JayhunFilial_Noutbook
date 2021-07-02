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
    public partial class SoldList : Form
    {
        public SoldList()
        {
            InitializeComponent();
        }

        DBAccess objDBAccess = new DBAccess();
        public static MySqlDataAdapter adapterShop, adapterCart;
        public static MySqlCommand cmdShop, cmdCart;
        public static CurrencyManager managerShop, managerCart;
        public static MySqlCommand cmdReturnProduct;
        public static DataTable tbReturnProduct, tbTotalReturnProduct;
        public static DataTable tbShopOylik, tbBirOylik, tbBirReturnProduct;
        public static DataTable tbUchShopOylik, tbNasiyaQaytishi, tbQayt_summa, tbShopBirOylik, tbNasiyaBirQaytishi, tbBirQayt_summa;
        public static DataTable tbBirKunlik, tbKunlikShop, tbKunlikReturnProduct, tbKunlikNasiyaQaytishi; // bir kunlik uchun
        public bool delete = false;
        public string jamisumma = "", naqd = "", plastik = "", shop_id = "", product_id = "", old_price = "", sold_quantity = "";

        private void dbgridShopOylik_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridShopOylik.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridJamiQaytgan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridJamiQaytgan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void SoldList_SizeChanged(object sender, EventArgs e)
        {
            if (Width >= 1378 && Height >= 780)
            {
                dbgridReturnProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            if (Width <= 1378 && Height <= 780)
            {
                dbgridReturnProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DateTime dt_now = DateTime.Now;
            string print = "Филиаль : " + frmMainMenu.filial + "\n" + "Сана : " + dt_now.ToString("dd-MMM-yyyy") + "\n";
            print += "\nНакд : " + tbBirKunlik.Rows[0]["Накд"].ToString() + "\n";
            print += "Пластик : " + tbBirKunlik.Rows[0]["Пластик"].ToString() + "\n";
            print += "Насия : " + tbBirKunlik.Rows[0]["Насия"].ToString() + "\n";
            print += "Насия_кайтиши : " + tbBirKunlik.Rows[0]["Насия_кайтиши"].ToString() + "\n";
            print += "Кайт_сумма : " + tbBirKunlik.Rows[0]["Кайт_сумма"].ToString() + "\n";
            print += "Жами_сумма : " + tbBirKunlik.Rows[0]["Жами_сумма"].ToString() + "\n";
            print += "\nСмен ёпилди : " + dt_now.ToString("hh:mm:ss");

            e.Graphics.DrawString(print, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void dbgridBirOylik_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridBirOylik.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridJami_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridJami.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboQaytMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtQaytYear.Text == "")
            {
                DateTime dt_now = DateTime.Now;
                string month_year = dt_now.ToString("yyyy-MM");
                string queryReturnProduct = "select cart.name as Номи, cart.quantity as Сотилган_микдор, cart.price as Сотилган_нарх, shop.date as Сотилган_сана, returnproduct.return_quantity as Кайтган_микдор, returnproduct.summa as Кайтган_сумма, returnproduct.date as Кайтган_сана, product.price as Сотув_нархи, returnproduct.difference as Фарк " +
                    "from returnproduct  inner join cart using(shop_id, product_id) inner join product using(product_id) inner join shop on returnproduct.shop_id=shop.id where returnproduct.sold=1 and returnproduct.date like '" + month_year + "%' order by returnproduct.date";
                try
                {
                    tbReturnProduct.Clear();
                }
                catch (Exception) { }
                objDBAccess.readDatathroughAdapter(queryReturnProduct, tbReturnProduct);
                try
                {
                    tbBirReturnProduct.Clear();
                }
                catch (Exception) { }

                if (tbReturnProduct.Rows.Count > 0)
                {
                    string queryJamiReturnProduct = "select sum(summa) as Жами_кайтган_сумма, sum(difference) as Фарк from returnproduct where sold=1 and date like '" + month_year + "%'";
                    try
                    {
                        tbTotalReturnProduct.Clear();
                    }
                    catch (Exception) { }
                    objDBAccess.readDatathroughAdapter(queryJamiReturnProduct, tbTotalReturnProduct);

                    DataRow rowBirQaytgan = tbBirReturnProduct.NewRow();
                    rowBirQaytgan["Ой"] = dt_now.ToString("MMMM");
                    rowBirQaytgan["Жами_кайтган_сумма"] = tbTotalReturnProduct.Rows[0]["Жами_кайтган_сумма"].ToString();
                    rowBirQaytgan["Фарк"] = tbTotalReturnProduct.Rows[0]["Фарк"].ToString();

                    tbBirReturnProduct.Rows.Add(rowBirQaytgan);
                    try
                    {
                        tbTotalReturnProduct.Clear();
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                int month = comboQaytMonth.SelectedIndex + 1;
                string month_year;
                if (month < 10) { month_year = txtQaytYear.Text + "-0" + Convert.ToString(month); }
                else { month_year = txtQaytYear.Text + "-" + Convert.ToString(month); }

                string queryReturnProduct = "select cart.name as Номи, cart.quantity as Сотилган_микдор, cart.price as Сотилган_нарх, shop.date as Сотилган_сана, returnproduct.return_quantity as Кайтган_микдор, returnproduct.summa as Кайтган_сумма, returnproduct.date as Кайтган_сана, product.price as Сотув_нархи, returnproduct.difference as Фарк " +
                    "from returnproduct  inner join cart using(shop_id, product_id) inner join product using(product_id) inner join shop on returnproduct.shop_id=shop.id where returnproduct.sold=1 and returnproduct.date like '" + month_year + "%' order by returnproduct.date";
                try
                {
                    tbReturnProduct.Clear();

                }
                catch (Exception) { }
                objDBAccess.readDatathroughAdapter(queryReturnProduct, tbReturnProduct);

                try { tbBirReturnProduct.Clear(); }
                catch (Exception) { }
                if (tbReturnProduct.Rows.Count > 0)
                {
                    string queryJamiReturnProduct = "select sum(summa) as Жами_кайтган_сумма, sum(difference) as Фарк from returnproduct where sold=1 and date like '" + month_year + "%'";
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
                    try
                    {
                        tbTotalReturnProduct.Clear();
                    }
                    catch (Exception) { }
                }
            }
        }

        private void maskVaqt_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" && !maskVaqt.MaskFull)
            {

                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string queryShop = "select shop.id, shop.naqd as Накд, shop.plastik as Пластик, shop.nasiya as Насия, shop.difference as Скидка, shop.jamisumma as Жамисумма, shop.date as сана,userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where (shop.status_tulov=1 or shop.debt=1) and shop.date like '%" + date + "%'";
                tbShop.Clear();
                objDBAccess.readDatathroughAdapter(queryShop, tbShop);
                tbCart.Clear();
                if (tbShop.Rows.Count > 0)
                {
                    string queryCart = "select shop_id, product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbShop.Rows[managerShop.Position]["id"] + "'";
                    objDBAccess.readDatathroughAdapter(queryCart, tbCart);
                }
            }
            else if (maskVaqt.MaskFull)
            {
                txtSearch.Text = "";
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string time = maskVaqt.Text;
                string datetime = date + " " + time;
                try
                {
                    DateTime dt = Convert.ToDateTime(datetime);
                    string queryShop = "select shop.id, shop.naqd as Накд, shop.plastik as Пластик, shop.nasiya as Насия, shop.difference as Скидка, shop.jamisumma as Жамисумма, shop.date as сана,userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where (shop.status_tulov=1 or shop.debt=1) and shop.date like '" + dt.ToString("yyyy-MM-dd HH") + "%'";
                    tbShop.Clear();
                    objDBAccess.readDatathroughAdapter(queryShop, tbShop);
                    tbCart.Clear();
                    if (tbShop.Rows.Count > 0)
                    {
                        string querySearch = "select shop_id, product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbShop.Rows[managerShop.Position]["id"] + "'";
                        objDBAccess.readDatathroughAdapter(querySearch, tbCart);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskVaqt.Clear();
                }
            }
        }

        private void dbgridCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtSearch.Text != "")
            {
                maskVaqt.Clear();
                try
                {
                    string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    DateTime dt = Convert.ToDateTime(date);
                    string queryShop = "select shop.id, shop.naqd as Накд, shop.plastik as Пластик, shop.nasiya as Насия, shop.jamisumma as Жамисумма, shop.date as сана, shop.status_server as статус_сэрвэр,userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where (shop.status_tulov=1 or shop.debt=1) and shop.date like '" + dt.ToString("yyyy-MM-dd") + "%' and shop.id='" + tbCart.Rows[managerCart.Position]["shop_id"] + "'";
                    tbShop.Clear();
                    objDBAccess.readDatathroughAdapter(queryShop, tbShop);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtYear.Text == "")
            {
                tbBirOylik.Clear();
                tbUchShopOylik.Clear();
                DateTime dt_now = DateTime.Now;
                string time = dateTimePicker1.Value.ToString("yyyy-MM");
                string day = dateTimePicker1.Value.ToString("dd");
                int last = int.Parse(day, CultureInfo.InvariantCulture);
                string queryShopOylik = "", queryNasiyaQaytishi = "", queryQayt_summa = "";
                tbShopOylik.Clear();
                tbNasiyaQaytishi.Clear();
                tbQayt_summa.Clear();

                tbShopBirOylik.Clear();
                tbNasiyaBirQaytishi.Clear();
                tbBirQayt_summa.Clear();

                string each_day = "";
                string each_time = "";
                double jami_summa = 0; string nasiya_qaytishi = "", oy_skidka = "", qayt_summa = "", naqd = "", plastik = "";
                for (int i = 1; i <= last; i++)
                {
                    if (i < 10)
                        each_day = "0" + Convert.ToString(i);
                    else
                        each_day = Convert.ToString(i);
                    each_time = time + "-" + each_day;

                    queryShopOylik = "select DATE(date) as Сана, sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия, sum(difference) as Скидка from shop where date like '" + each_time + "%' and jamisumma>0";
                    objDBAccess.readDatathroughAdapter(queryShopOylik, tbShopOylik);

                    queryNasiyaQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + each_time + "%'";
                    objDBAccess.readDatathroughAdapter(queryNasiyaQaytishi, tbNasiyaQaytishi);

                    queryQayt_summa = "select sum(summa) as Кайт_сумма from returnproduct where date like '" + each_time + "%' and sold=1";
                    objDBAccess.readDatathroughAdapter(queryQayt_summa, tbQayt_summa);
                    string date = tbShopOylik.Rows[0]["Сана"].ToString();
                    if (tbShopOylik.Rows.Count > 0 && string.IsNullOrEmpty(date) == false)
                    {
                        DataRow row = tbUchShopOylik.NewRow();
                        row["Сана"] = tbShopOylik.Rows[0]["Сана"].ToString();
                        row["Накд"] = tbShopOylik.Rows[0]["Накд"].ToString();
                        row["Пластик"] = tbShopOylik.Rows[0]["Пластик"].ToString();
                        row["Насия"] = tbShopOylik.Rows[0]["Насия"].ToString();
                        if (tbShopOylik.Rows[0]["Скидка"].ToString() == "") { oy_skidka = "0"; }
                        else { oy_skidka = tbShopOylik.Rows[0]["Скидка"].ToString(); }
                        row["Скидка"] = tbShopOylik.Rows[0]["Скидка"].ToString();
                        oy_skidka = DoubleToStr(oy_skidka);
                        if (tbNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { nasiya_qaytishi = "0"; }
                        else { nasiya_qaytishi = tbNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString(); }//
                        row["Насия_кайтиши"] = nasiya_qaytishi;
                        if (nasiya_qaytishi.IndexOf(',') > -1)
                        {
                            int index = nasiya_qaytishi.IndexOf(',');
                            string first_nasiyaQaytishi = nasiya_qaytishi.Substring(0, index);
                            string last_nasiyaQaytishi = nasiya_qaytishi.Substring(index + 1);
                            nasiya_qaytishi = first_nasiyaQaytishi + "." + last_nasiyaQaytishi;
                        }

                        if (tbQayt_summa.Rows[0]["Кайт_сумма"].ToString() == "") { qayt_summa = "0"; }
                        else { qayt_summa = tbQayt_summa.Rows[0]["Кайт_сумма"].ToString(); }//
                        row["Кайт_сумма"] = qayt_summa;
                        if (qayt_summa.IndexOf(',') > -1)
                        {
                            int index = qayt_summa.IndexOf(',');
                            string first_qayt_summa = qayt_summa.Substring(0, index);
                            string last_qayt_summa = qayt_summa.Substring(index + 1);
                            qayt_summa = first_qayt_summa + "." + last_qayt_summa;
                        }

                        naqd = tbShopOylik.Rows[0]["Накд"].ToString();//
                        if (naqd.IndexOf(',') > -1)
                        {
                            int index = naqd.IndexOf(',');
                            string first_naqd = naqd.Substring(0, index);
                            string last_naqd = naqd.Substring(index + 1);
                            naqd = first_naqd + "." + last_naqd;
                        }

                        plastik = tbShopOylik.Rows[0]["Пластик"].ToString();//
                        if (plastik.IndexOf(',') > -1)
                        {
                            int index = plastik.IndexOf(',');
                            string first_plastik = plastik.Substring(0, index);
                            string last_plastik = plastik.Substring(index + 1);
                            naqd = first_plastik + "." + last_plastik;
                        }
                        double Dnaqd = double.Parse(naqd, CultureInfo.InvariantCulture);
                        double Dplastik = double.Parse(plastik, CultureInfo.InvariantCulture);
                        double Dnasiya_qaytishi = double.Parse(nasiya_qaytishi, CultureInfo.InvariantCulture);
                        double Dqayt_summa = double.Parse(qayt_summa, CultureInfo.InvariantCulture);
                        double Doy_skidka = Double.Parse(oy_skidka, CultureInfo.InvariantCulture);
                        jami_summa = Dnaqd + Dplastik + Dnasiya_qaytishi - Dqayt_summa - Doy_skidka;
                        row["Жами_сумма"] = jami_summa.ToString();
                        tbUchShopOylik.Rows.Add(row);

                        jami_summa = 0;
                        nasiya_qaytishi = "";
                        qayt_summa = "";
                        each_day = "";
                        each_time = "";
                        tbShopOylik.Clear();
                        tbShopOylik.Dispose();
                        tbNasiyaQaytishi.Clear();
                        tbNasiyaQaytishi.Dispose();
                        tbQayt_summa.Clear();
                        tbQayt_summa.Dispose();
                    }
                    else
                    {
                        tbShopOylik.Clear();
                        tbShopOylik.Dispose();
                        tbNasiyaQaytishi.Clear();
                        tbNasiyaQaytishi.Dispose();
                        tbQayt_summa.Clear();
                        tbQayt_summa.Dispose();
                    }
                }

                if (tbUchShopOylik.Rows.Count > 0)
                {
                    string birNaqd = "", birPlastik = "", bir_skidka = "", birNasiya_qaytishi = "", birQayt_summa = "";
                    string queryShopBirOylik = "select DATE(date) as Сана, sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия, sum(difference) as Скидка from shop where date like '" + time + "%' and jamisumma>0";
                    objDBAccess.readDatathroughAdapter(queryShopBirOylik, tbShopBirOylik);

                    string queryNasiyaBirQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + time + "%'";
                    objDBAccess.readDatathroughAdapter(queryNasiyaBirQaytishi, tbNasiyaBirQaytishi);

                    string queryBirQayt_summa = "select sum(summa) as Кайт_сумма from returnproduct where date like '" + time + "%' and sold=1";
                    objDBAccess.readDatathroughAdapter(queryBirQayt_summa, tbBirQayt_summa);

                    DataRow rowBirOylik = tbBirOylik.NewRow();
                    rowBirOylik["Ой"] = dt_now.ToString("MMMM");
                    rowBirOylik["Накд"] = tbShopBirOylik.Rows[0]["Накд"].ToString();
                    rowBirOylik["Пластик"] = tbShopBirOylik.Rows[0]["Пластик"].ToString();
                    rowBirOylik["Насия"] = tbShopBirOylik.Rows[0]["Насия"].ToString();
                    if (tbShopBirOylik.Rows[0]["Скидка"].ToString() == "") { bir_skidka = "0"; }
                    else { bir_skidka = tbShopBirOylik.Rows[0]["Скидка"].ToString(); }
                    rowBirOylik["Насия"] = tbShopBirOylik.Rows[0]["Скидка"].ToString();
                    bir_skidka = DoubleToStr(bir_skidka);
                    if (tbNasiyaBirQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { birNasiya_qaytishi = "0"; }
                    else { birNasiya_qaytishi = tbNasiyaBirQaytishi.Rows[0]["Насия_кайтиши"].ToString(); }//
                    rowBirOylik["Насия_кайтиши"] = birNasiya_qaytishi;
                    if (birNasiya_qaytishi.IndexOf(',') > -1)
                    {
                        int index = birNasiya_qaytishi.IndexOf(',');
                        string first_birNasiya_qaytishi = birNasiya_qaytishi.Substring(0, index);
                        string last_birNasiya_qaytishi = birNasiya_qaytishi.Substring(index + 1);
                        birNasiya_qaytishi = first_birNasiya_qaytishi + "." + last_birNasiya_qaytishi;
                    }

                    if (tbBirQayt_summa.Rows[0]["Кайт_сумма"].ToString() == "") { birQayt_summa = "0"; }
                    else { birQayt_summa = tbBirQayt_summa.Rows[0]["Кайт_сумма"].ToString(); }//
                    rowBirOylik["Кайт_сумма"] = birQayt_summa;
                    if (birQayt_summa.IndexOf(',') > -1)
                    {
                        int index = birQayt_summa.IndexOf(',');
                        string first_birQayt_summa = birQayt_summa.Substring(0, index);
                        string last_birQayt_summa = birQayt_summa.Substring(index + 1);
                        birQayt_summa = first_birQayt_summa + "." + last_birQayt_summa;
                    }

                    birNaqd = tbShopBirOylik.Rows[0]["Накд"].ToString();//
                    if (birNaqd.IndexOf(',') > -1)
                    {
                        int index = birNaqd.IndexOf(',');
                        string first_birNaqd = birNaqd.Substring(0, index);
                        string last_birNaqd = birNaqd.Substring(index + 1);
                        birNaqd = first_birNaqd + "." + last_birNaqd;
                    }

                    birPlastik = tbShopBirOylik.Rows[0]["Пластик"].ToString();//
                    if (birPlastik.IndexOf(',') > -1)
                    {
                        int index = birPlastik.IndexOf(',');
                        string first_birPlastik = birPlastik.Substring(0, index);
                        string last_birPlastik = birPlastik.Substring(index + 1);
                        birPlastik = first_birPlastik + "." + last_birPlastik;
                    }
                    double DbirNaqd = double.Parse(birNaqd, CultureInfo.InvariantCulture);
                    double DbirPlastik = double.Parse(birPlastik, CultureInfo.InvariantCulture);
                    double DbirNasiya_qaytishi = double.Parse(birNasiya_qaytishi, CultureInfo.InvariantCulture);
                    double DbirQayt_summa = double.Parse(birQayt_summa, CultureInfo.InvariantCulture);
                    double Dbir_skidka = double.Parse(bir_skidka, CultureInfo.InvariantCulture);
                    double result_JamiBirSumma = DbirNaqd + DbirPlastik + DbirNasiya_qaytishi - DbirQayt_summa - Dbir_skidka;
                    rowBirOylik["Жами_сумма"] = result_JamiBirSumma.ToString();
                    tbBirOylik.Rows.Add(rowBirOylik);

                    tbShopBirOylik.Clear();
                    tbShopBirOylik.Dispose();
                    tbNasiyaBirQaytishi.Clear();
                    tbNasiyaBirQaytishi.Dispose();
                    tbBirQayt_summa.Clear();
                    tbBirQayt_summa.Dispose();
                }
                txtYear.Text = dt_now.ToString("yyyy");
                for (int i = 0; i < 11; i++)
                {
                    if (comboMonth.Items[i].ToString() == dt_now.ToString("MMMM"))
                    {
                        comboMonth.SelectedIndex = i;
                        break;
                    }
                }
                return;
            }
            else
            {

                int index = comboMonth.SelectedIndex;
                index += 1;
                string month = "";
                if (index < 10)
                {
                    month = "0" + Convert.ToString(index);
                }
                else
                {
                    month = Convert.ToString(index);
                }
                string year = txtYear.Text;
                string month_yaer = year + "-" + month;
                string day = dateTimePicker1.Value.ToString("dd");
                DateTime dt_now = DateTime.Now;
                int last = 0;
                if (month == dt_now.ToString("MM"))
                {
                    last = int.Parse(day, CultureInfo.InvariantCulture);
                }
                else { last = 31; }
                string queryShopOylik = "", queryNasiyaQaytishi = "", queryQayt_summa = "";
                tbUchShopOylik.Clear(); tbBirOylik.Clear();
                tbShopOylik.Clear(); tbShopBirOylik.Clear();
                tbNasiyaQaytishi.Clear(); tbNasiyaBirQaytishi.Clear();
                tbQayt_summa.Clear(); tbBirQayt_summa.Clear();
                string each_day = "";
                string each_time = "";
                double jami_summa = 0; string nasiya_qaytishi = "", oy_skidka = "", qayt_summa = "", naqd = "", plastik = "";
                for (int i = 1; i <= last; i++)
                {
                    if (i < 10)
                        each_day = "0" + Convert.ToString(i);
                    else
                        each_day = Convert.ToString(i);
                    each_time = month_yaer + "-" + each_day;

                    queryShopOylik = "select DATE(date) as Сана, sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия, sum(difference) as Скидка from shop where date like '" + each_time + "%' and jamisumma>0";
                    objDBAccess.readDatathroughAdapter(queryShopOylik, tbShopOylik);

                    queryNasiyaQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + each_time + "%'";
                    objDBAccess.readDatathroughAdapter(queryNasiyaQaytishi, tbNasiyaQaytishi);

                    queryQayt_summa = "select sum(summa) as Кайт_сумма from returnproduct where date like '" + each_time + "%' and sold=1";
                    objDBAccess.readDatathroughAdapter(queryQayt_summa, tbQayt_summa);
                    string date = tbShopOylik.Rows[0]["Сана"].ToString();
                    if (tbShopOylik.Rows.Count > 0 && string.IsNullOrEmpty(date) == false)
                    {
                        DataRow row = tbUchShopOylik.NewRow();
                        row["Сана"] = tbShopOylik.Rows[0]["Сана"].ToString();
                        row["Накд"] = tbShopOylik.Rows[0]["Накд"].ToString();
                        row["Пластик"] = tbShopOylik.Rows[0]["Пластик"].ToString();
                        row["Насия"] = tbShopOylik.Rows[0]["Насия"].ToString();
                        if (tbShopOylik.Rows[0]["Скидка"].ToString() == "") { oy_skidka = "0"; }
                        else { oy_skidka = tbShopOylik.Rows[0]["Скидка"].ToString(); }
                        row["Скидка"] = oy_skidka;
                        oy_skidka = DoubleToStr(oy_skidka);
                        if (tbNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { nasiya_qaytishi = "0"; }
                        else { nasiya_qaytishi = tbNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString(); }//
                        row["Насия_кайтиши"] = nasiya_qaytishi;
                        if (nasiya_qaytishi.IndexOf(',') > -1)
                        {
                            int index_nasiya_qaytishi = nasiya_qaytishi.IndexOf(',');
                            string first_nasiya_qaytishi = nasiya_qaytishi.Substring(0, index_nasiya_qaytishi);
                            string last_nasiya_qaytishi = nasiya_qaytishi.Substring(index_nasiya_qaytishi + 1);
                            nasiya_qaytishi = first_nasiya_qaytishi + "." + last_nasiya_qaytishi;
                        }

                        if (tbQayt_summa.Rows[0]["Кайт_сумма"].ToString() == "") { qayt_summa = "0"; }
                        else { qayt_summa = tbQayt_summa.Rows[0]["Кайт_сумма"].ToString(); }//
                        row["Кайт_сумма"] = qayt_summa;
                        if (qayt_summa.IndexOf(',') > -1)
                        {
                            int index_qayt_summa = qayt_summa.IndexOf(',');
                            string first_qayt_summa = qayt_summa.Substring(0, index_qayt_summa);
                            string last_qayt_summa = qayt_summa.Substring(index_qayt_summa + 1);
                            qayt_summa = first_qayt_summa + "." + last_qayt_summa;
                        }

                        naqd = tbShopOylik.Rows[0]["Накд"].ToString();//
                        if (naqd.IndexOf(',') > -1)
                        {
                            int index_naqd = naqd.IndexOf(',');
                            string first_naqd = naqd.Substring(0, index_naqd);
                            string last_naqd = naqd.Substring(index_naqd + 1);
                            naqd = first_naqd + "." + last_naqd;
                        }

                        plastik = tbShopOylik.Rows[0]["Пластик"].ToString();//
                        if (plastik.IndexOf(',') > -1)
                        {
                            int index_plastik = plastik.IndexOf(',');
                            string first_plastik = plastik.Substring(0, index_plastik);
                            string last_plastik = plastik.Substring(index_plastik + 1);
                            plastik = first_plastik + "." + last_plastik;
                        }
                        double Dnaqd = double.Parse(naqd, CultureInfo.InvariantCulture);
                        double Dplastik = double.Parse(plastik, CultureInfo.InvariantCulture);
                        double Dnasiya_qaytishi = double.Parse(nasiya_qaytishi, CultureInfo.InvariantCulture);
                        double Dqayt_summa = double.Parse(qayt_summa, CultureInfo.InvariantCulture);
                        double Doy_skidka = double.Parse(oy_skidka, CultureInfo.InvariantCulture);
                        jami_summa = Dnaqd + Dplastik + Dnasiya_qaytishi - Dqayt_summa - Doy_skidka;
                        row["Жами_сумма"] = jami_summa.ToString();
                        tbUchShopOylik.Rows.Add(row);

                        jami_summa = 0;
                        nasiya_qaytishi = "";
                        qayt_summa = "";
                        each_day = "";
                        each_time = "";
                        tbShopOylik.Clear();
                        tbShopOylik.Dispose();
                        tbNasiyaQaytishi.Clear();
                        tbNasiyaQaytishi.Dispose();
                        tbQayt_summa.Clear();
                        tbQayt_summa.Dispose();
                    }
                    else
                    {
                        tbShopOylik.Clear();
                        tbShopOylik.Dispose();
                        tbNasiyaQaytishi.Clear();
                        tbNasiyaQaytishi.Dispose();
                        tbQayt_summa.Clear();
                        tbQayt_summa.Dispose();
                    }
                }

                if (tbUchShopOylik.Rows.Count > 0)
                {
                    string birNaqd = "", birPlastik = "", bir_skidka = "", birNasiya_qaytishi = "", birQayt_summa = "";
                    string queryShopBirOylik = "select DATE(date) as Сана, sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия, sum(difference) as Скидка from shop where date like '" + month_yaer + "%' and jamisumma>0";
                    objDBAccess.readDatathroughAdapter(queryShopBirOylik, tbShopBirOylik);

                    string queryNasiyaBirQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + month_yaer + "%'";
                    objDBAccess.readDatathroughAdapter(queryNasiyaBirQaytishi, tbNasiyaBirQaytishi);

                    string queryBirQayt_summa = "select sum(summa) as Кайт_сумма from returnproduct where date like '" + month_yaer + "%' and sold=1";
                    objDBAccess.readDatathroughAdapter(queryBirQayt_summa, tbBirQayt_summa);

                    DataRow rowBirOylik = tbBirOylik.NewRow();
                    rowBirOylik["Ой"] = comboMonth.Text;
                    rowBirOylik["Накд"] = tbShopBirOylik.Rows[0]["Накд"].ToString();
                    rowBirOylik["Пластик"] = tbShopBirOylik.Rows[0]["Пластик"].ToString();
                    rowBirOylik["Насия"] = tbShopBirOylik.Rows[0]["Насия"].ToString();
                    if (tbShopBirOylik.Rows[0]["Скидка"].ToString() == "") { bir_skidka = "0"; }
                    else { bir_skidka = tbShopBirOylik.Rows[0]["Скидка"].ToString(); }
                    rowBirOylik["Скидка"] = bir_skidka;
                    bir_skidka = DoubleToStr(bir_skidka);
                    if (tbNasiyaBirQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { birNasiya_qaytishi = "0"; }
                    else { birNasiya_qaytishi = tbNasiyaBirQaytishi.Rows[0]["Насия_кайтиши"].ToString(); } //
                    rowBirOylik["Насия_кайтиши"] = birNasiya_qaytishi;
                    if (birNasiya_qaytishi.IndexOf(',') > -1)
                    {
                        int index_birNasiya_qaytishi = birNasiya_qaytishi.IndexOf(',');
                        string first_birNasiya_qaytishi = birNasiya_qaytishi.Substring(0, index_birNasiya_qaytishi);
                        string last_birNasiya_qaytishi = birNasiya_qaytishi.Substring(index_birNasiya_qaytishi + 1);
                        birNasiya_qaytishi = first_birNasiya_qaytishi + "." + last_birNasiya_qaytishi;
                    }

                    if (tbBirQayt_summa.Rows[0]["Кайт_сумма"].ToString() == "") { birQayt_summa = "0"; }
                    else { birQayt_summa = tbBirQayt_summa.Rows[0]["Кайт_сумма"].ToString(); } //
                    rowBirOylik["Кайт_сумма"] = birQayt_summa;
                    if (birQayt_summa.IndexOf(',') > -1)
                    {
                        int index_birQayt_summa = birQayt_summa.IndexOf(',');
                        string first_birQayt_summa = birQayt_summa.Substring(0, index_birQayt_summa);
                        string last_birQayt_summa = birQayt_summa.Substring(index_birQayt_summa + 1);
                        birQayt_summa = first_birQayt_summa + "." + last_birQayt_summa;
                    }

                    birNaqd = tbShopBirOylik.Rows[0]["Накд"].ToString();//
                    if (birNaqd.IndexOf(',') > -1)
                    {
                        int index_birNaqd = birNaqd.IndexOf(',');
                        string first_birNaqd = birNaqd.Substring(0, index_birNaqd);
                        string last_birNaqd = birNaqd.Substring(index_birNaqd + 1);
                        birNaqd = first_birNaqd + "." + last_birNaqd;
                    }

                    birPlastik = tbShopBirOylik.Rows[0]["Пластик"].ToString();//
                    if (birPlastik.IndexOf(',') > -1)
                    {
                        int index_birPlastik = birPlastik.IndexOf(',');
                        string first_birPlastik = birPlastik.Substring(0, index_birPlastik);
                        string last_birPlastik = birPlastik.Substring(index_birPlastik + 1);
                        birPlastik = first_birPlastik + "." + last_birPlastik;
                    }
                    double DbirNaqd = double.Parse(birNaqd, CultureInfo.InvariantCulture);
                    double DbirPlastik = double.Parse(birPlastik, CultureInfo.InvariantCulture);
                    double DbirNasiya_qaytishi = double.Parse(birNasiya_qaytishi, CultureInfo.InvariantCulture);
                    double DbirQayt_summa = double.Parse(birQayt_summa, CultureInfo.InvariantCulture);
                    double Dbir_skidka = double.Parse(bir_skidka, CultureInfo.InvariantCulture);
                    double result_JamiBirSumma = DbirNaqd + DbirPlastik + DbirNasiya_qaytishi - DbirQayt_summa - Dbir_skidka;
                    rowBirOylik["Жами_сумма"] = result_JamiBirSumma.ToString();
                    tbBirOylik.Rows.Add(rowBirOylik);

                    tbShopBirOylik.Clear();
                    tbShopBirOylik.Dispose();
                    tbNasiyaBirQaytishi.Clear();
                    tbNasiyaBirQaytishi.Dispose();
                    tbBirQayt_summa.Clear();
                    tbBirQayt_summa.Dispose();
                }
            }
        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            if (Width <= 1123 && Height <= 700)
            {
                dbgridReturnProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            if (Width > 1123 && Height >= 700)
            {
                dbgridReturnProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dbgridReturnProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridReturnProduct.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        public string DoubleToStr(string str)
        {
            if (str.IndexOf(',') > -1)
            {
                int index = str.IndexOf(',');
                string first = str.Substring(0, index);
                string last = str.Substring(index + 1);
                str = first + "." + last;



            }
            return str;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)  // qaytgan tovarlar uchun
            {
                DateTime dt_now = DateTime.Now;
                string month_year = dt_now.ToString("yyyy-MM");
                string queryReturnProduct = "select cart.name as Номи, cart.quantity as Сотилган_микдор, cart.price as Сотилган_нарх, shop.date as Сотилган_сана, returnproduct.return_quantity as Кайтган_микдор, returnproduct.summa as Кайтган_сумма, returnproduct.date as Кайтган_сана, product.price as Сотув_нархи, returnproduct.difference as Фарк " +
                    "from returnproduct inner join cart using(shop_id, product_id) inner join product using(product_id) inner join shop on returnproduct.shop_id=shop.id where returnproduct.sold=1 and returnproduct.date like '" + month_year + "%' order by returnproduct.date";
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
                    string queryJamiReturnProduct = "select sum(summa) as Жами_кайтган_сумма, sum(difference) as Фарк from returnproduct where sold=1 and date like '" + month_year + "%'";
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
                dbgridJamiQaytgan.DataSource = tbBirReturnProduct;
                dbgridJamiQaytgan.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
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
            if (tabControl1.SelectedIndex == 1) // oylik savdo uchun
            {
                tbUchShopOylik = new DataTable(); // oy kunlari uchun
                tbUchShopOylik.Columns.Add("Сана", typeof(DateTime));
                tbUchShopOylik.Columns.Add("Накд");
                tbUchShopOylik.Columns.Add("Пластик");
                tbUchShopOylik.Columns.Add("Насия");
                tbUchShopOylik.Columns.Add("Скидка");
                tbUchShopOylik.Columns.Add("Насия_кайтиши");  // payhistory
                tbUchShopOylik.Columns.Add("Кайт_сумма"); // returnproduct
                tbUchShopOylik.Columns.Add("Жами_сумма");

                tbBirOylik = new DataTable(); // bir oylik uchun
                tbBirOylik.Columns.Add("Ой");
                tbBirOylik.Columns.Add("Накд");
                tbBirOylik.Columns.Add("Пластик");
                tbBirOylik.Columns.Add("Насия");
                tbBirOylik.Columns.Add("Скидка");
                tbBirOylik.Columns.Add("Насия_кайтиши");  // payhistory
                tbBirOylik.Columns.Add("Кайт_сумма");  // returnproduct
                tbBirOylik.Columns.Add("Жами_сумма");

                DateTime dt_now = DateTime.Now;
                string time = dateTimePicker1.Value.ToString("yyyy-MM");
                string day = dateTimePicker1.Value.ToString("dd");
                int last = int.Parse(day, CultureInfo.InvariantCulture);
                string queryShopOylik = "", queryNasiyaQaytishi = "", queryQayt_summa = "";
                tbShopOylik = new DataTable();  // oy kunlari uchun
                tbNasiyaQaytishi = new DataTable();  // oy kunlari uchun
                tbQayt_summa = new DataTable();   // oy kunlari uchun   

                tbShopBirOylik = new DataTable();  // bir oylik uchun
                tbNasiyaBirQaytishi = new DataTable(); // bir oylik uchun
                tbBirQayt_summa = new DataTable();  // bir oylik uchun

                string each_day = "";
                string each_time = "";
                double jami_summa = 0; string nasiya_qaytishi = "", oy_skidka = "", qayt_summa = "", naqd = "", plastik = "";
                for (int i = 1; i <= last; i++)
                {
                    if (i < 10)
                        each_day = "0" + Convert.ToString(i);
                    else
                        each_day = Convert.ToString(i);
                    each_time = time + "-" + each_day;

                    queryShopOylik = "select DATE(date) as Сана, sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия, sum(difference) as Скидка from shop where date like '" + each_time + "%' and jamisumma>0";
                    objDBAccess.readDatathroughAdapter(queryShopOylik, tbShopOylik);

                    queryNasiyaQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + each_time + "%'";
                    objDBAccess.readDatathroughAdapter(queryNasiyaQaytishi, tbNasiyaQaytishi);

                    queryQayt_summa = "select sum(summa) as Кайт_сумма from returnproduct where date like '" + each_time + "%' and sold=1";
                    objDBAccess.readDatathroughAdapter(queryQayt_summa, tbQayt_summa);
                    string date = tbShopOylik.Rows[0]["Сана"].ToString();
                    if (tbShopOylik.Rows.Count > 0 && string.IsNullOrEmpty(date) == false)
                    {
                        DataRow row = tbUchShopOylik.NewRow();
                        row["Сана"] = tbShopOylik.Rows[0]["Сана"].ToString();
                        row["Накд"] = tbShopOylik.Rows[0]["Накд"].ToString();
                        row["Пластик"] = tbShopOylik.Rows[0]["Пластик"].ToString();
                        row["Насия"] = tbShopOylik.Rows[0]["Насия"].ToString();
                        if (tbShopOylik.Rows[0]["Скидка"].ToString() == "") { oy_skidka = "0"; }
                        else { oy_skidka = tbShopOylik.Rows[0]["Скидка"].ToString(); }
                        row["Скидка"] = oy_skidka;
                        oy_skidka = DoubleToStr(oy_skidka);

                        if (tbNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { nasiya_qaytishi = "0"; }
                        else { nasiya_qaytishi = tbNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString(); } //
                        row["Насия_кайтиши"] = nasiya_qaytishi;
                        if (nasiya_qaytishi.IndexOf(',') > -1)
                        {
                            int index = nasiya_qaytishi.IndexOf(',');
                            string first_nasiyaQaytishi = nasiya_qaytishi.Substring(0, index);
                            string last_nasiyaQaytishi = nasiya_qaytishi.Substring(index + 1);
                            nasiya_qaytishi = first_nasiyaQaytishi + "." + last_nasiyaQaytishi;
                        }

                        if (tbQayt_summa.Rows[0]["Кайт_сумма"].ToString() == "") { qayt_summa = "0"; }
                        else { qayt_summa = tbQayt_summa.Rows[0]["Кайт_сумма"].ToString(); }//
                        row["Кайт_сумма"] = qayt_summa;
                        if (qayt_summa.IndexOf(',') > -1)
                        {
                            int index = qayt_summa.IndexOf(',');
                            string first_qaytSumma = qayt_summa.Substring(0, index);
                            string last_qaytSumma = qayt_summa.Substring(index + 1);
                            qayt_summa = first_qaytSumma + "." + last_qaytSumma;
                        }

                        naqd = tbShopOylik.Rows[0]["Накд"].ToString();//
                        if (naqd.IndexOf(',') > -1)
                        {
                            int index = naqd.IndexOf(',');
                            string first_naqd = naqd.Substring(0, index);
                            string last_naqd = naqd.Substring(index + 1);
                            naqd = first_naqd + "." + last_naqd;
                        }
                        plastik = tbShopOylik.Rows[0]["Пластик"].ToString();//
                        if (plastik.IndexOf(',') > -1)
                        {
                            int index = plastik.IndexOf(',');
                            string first_plastik = plastik.Substring(0, index);
                            string last_plastik = plastik.Substring(index + 1);
                            plastik = first_plastik + "." + last_plastik;
                        }
                        double Dnaqd = double.Parse(naqd, CultureInfo.InvariantCulture);
                        double Dplastik = double.Parse(plastik, CultureInfo.InvariantCulture);
                        double Dnasiya_qaytishi = double.Parse(nasiya_qaytishi, CultureInfo.InvariantCulture);
                        double Dqayt_summa = double.Parse(qayt_summa, CultureInfo.InvariantCulture);
                        double Doy_skidka = double.Parse(oy_skidka, CultureInfo.InvariantCulture);
                        jami_summa = Dnaqd + Dplastik + Dnasiya_qaytishi - Dqayt_summa - Doy_skidka;
                        row["Жами_сумма"] = jami_summa.ToString();
                        tbUchShopOylik.Rows.Add(row);

                        jami_summa = 0;
                        nasiya_qaytishi = "";
                        qayt_summa = "";
                        each_day = "";
                        each_time = "";
                        tbShopOylik.Clear();
                        tbShopOylik.Dispose();
                        tbNasiyaQaytishi.Clear();
                        tbNasiyaQaytishi.Dispose();
                        tbQayt_summa.Clear();
                        tbQayt_summa.Dispose();
                    }
                    else
                    {
                        tbShopOylik.Clear();
                        tbShopOylik.Dispose();
                        tbNasiyaQaytishi.Clear();
                        tbNasiyaQaytishi.Dispose();
                        tbQayt_summa.Clear();
                        tbQayt_summa.Dispose();
                    }
                }

                if (tbUchShopOylik.Rows.Count > 0)
                {
                    string birNaqd = "", bir_skidka = "", birPlastik = "", birNasiya_qaytishi = "", birQayt_summa = "";
                    string queryShopBirOylik = "select DATE(date) as Сана, sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия, sum(difference) as Скидка from shop where date like '" + time + "%' and jamisumma>0";
                    objDBAccess.readDatathroughAdapter(queryShopBirOylik, tbShopBirOylik);

                    string queryNasiyaBirQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + time + "%'";
                    objDBAccess.readDatathroughAdapter(queryNasiyaBirQaytishi, tbNasiyaBirQaytishi);

                    string queryBirQayt_summa = "select sum(summa) as Кайт_сумма from returnproduct where date like '" + time + "%' and sold=1";
                    objDBAccess.readDatathroughAdapter(queryBirQayt_summa, tbBirQayt_summa);

                    DataRow rowBirOylik = tbBirOylik.NewRow();
                    rowBirOylik["Ой"] = dt_now.ToString("MMMM");
                    rowBirOylik["Накд"] = tbShopBirOylik.Rows[0]["Накд"].ToString();
                    rowBirOylik["Пластик"] = tbShopBirOylik.Rows[0]["Пластик"].ToString();
                    rowBirOylik["Насия"] = tbShopBirOylik.Rows[0]["Насия"].ToString();
                    if (tbShopBirOylik.Rows[0]["Скидка"].ToString() == "")
                    {
                        bir_skidka = "0";
                    }
                    else { bir_skidka = tbShopBirOylik.Rows[0]["Скидка"].ToString(); }
                    rowBirOylik["Скидка"] = bir_skidka;
                    bir_skidka = DoubleToStr(bir_skidka);

                    if (tbNasiyaBirQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { birNasiya_qaytishi = "0"; }
                    else { birNasiya_qaytishi = tbNasiyaBirQaytishi.Rows[0]["Насия_кайтиши"].ToString(); }//
                    rowBirOylik["Насия_кайтиши"] = birNasiya_qaytishi;
                    if (birNasiya_qaytishi.IndexOf(',') > -1)
                    {
                        int index = birNasiya_qaytishi.IndexOf(',');
                        string first_birNasiya_qaytishi = birNasiya_qaytishi.Substring(0, index);
                        string last_birNasiya_qaytishi = birNasiya_qaytishi.Substring(index + 1);
                        birNasiya_qaytishi = first_birNasiya_qaytishi + "." + last_birNasiya_qaytishi;
                    }

                    if (tbBirQayt_summa.Rows[0]["Кайт_сумма"].ToString() == "") { birQayt_summa = "0"; }
                    else { birQayt_summa = tbBirQayt_summa.Rows[0]["Кайт_сумма"].ToString(); }//
                    rowBirOylik["Кайт_сумма"] = birQayt_summa;
                    if (birQayt_summa.IndexOf(',') > -1)
                    {
                        int index = birQayt_summa.IndexOf(',');
                        string first_birQayt_summa = birQayt_summa.Substring(0, index);
                        string last_birQayt_summa = birQayt_summa.Substring(index + 1);
                        birQayt_summa = first_birQayt_summa + "." + last_birQayt_summa;
                    }

                    birNaqd = tbShopBirOylik.Rows[0]["Накд"].ToString();//
                    if (birNaqd.IndexOf(',') > -1)
                    {
                        int index = birNaqd.IndexOf(',');
                        string first_birNaqd = birNaqd.Substring(0, index);
                        string last_birNaqd = birNaqd.Substring(index + 1);
                        birNaqd = first_birNaqd + "." + last_birNaqd;
                    }
                    birPlastik = tbShopBirOylik.Rows[0]["Пластик"].ToString(); //
                    if (birPlastik.IndexOf(',') > -1)
                    {
                        int index = birPlastik.IndexOf(',');
                        string first_birPlastik = birPlastik.Substring(0, index);
                        string last_birPlastik = birPlastik.Substring(index + 1);
                        birPlastik = first_birPlastik + "." + last_birPlastik;
                    }
                    double DbirNaqd = double.Parse(birNaqd, CultureInfo.InvariantCulture);
                    double DbirPlastik = double.Parse(birPlastik, CultureInfo.InvariantCulture);
                    double DbirNasiya_qaytishi = double.Parse(birNasiya_qaytishi, CultureInfo.InvariantCulture);
                    double DbirQayt_summa = double.Parse(birQayt_summa, CultureInfo.InvariantCulture);
                    double Dbir_skidka = double.Parse(bir_skidka, CultureInfo.InvariantCulture);
                    double result_JamiBirSumma = DbirNaqd + DbirPlastik + DbirNasiya_qaytishi - DbirQayt_summa - Dbir_skidka;
                    rowBirOylik["Жами_сумма"] = result_JamiBirSumma.ToString();
                    tbBirOylik.Rows.Add(rowBirOylik);

                    tbShopBirOylik.Clear();
                    tbShopBirOylik.Dispose();
                    tbNasiyaBirQaytishi.Clear();
                    tbNasiyaBirQaytishi.Dispose();
                    tbBirQayt_summa.Clear();
                    tbBirQayt_summa.Dispose();
                }
                dbgridBirOylik.DataSource = tbBirOylik;
                dbgridBirOylik.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                dbgridShopOylik.DataSource = tbUchShopOylik;
                dbgridShopOylik.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                txtYear.Text = dt_now.ToString("yyyy");
                for (int i = 0; i < 11; i++)
                {
                    if (comboMonth.Items[i].ToString() == dt_now.ToString("MMMM"))
                    {
                        comboMonth.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void dbgridShop_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridShop.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridCart_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridCart.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string querySearch = "select shop.id, shop.naqd as Накд, shop.plastik as Пластик, shop.nasiya as Насия, shop.difference as Скидка, shop.jamisumma as Жамисумма, shop.date as сана,userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where (shop.status_tulov=1 or shop.debt=1) and shop.date like '%" + date + "%'";
            tbShop.Clear();
            objDBAccess.readDatathroughAdapter(querySearch, tbShop);
            tbCart.Clear();
            tbBirKunlik.Clear();

            string queryShopKunlik = "select sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия, sum(difference) as Скидка from shop where date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryShopKunlik, tbKunlikShop);

            string queryKunlikReturnProduct = "select sum(summa) as Кайт_сумма from returnproduct where sold=1 and date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryKunlikReturnProduct, tbKunlikReturnProduct);

            string queryKunlikNasiyaQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryKunlikNasiyaQaytishi, tbKunlikNasiyaQaytishi);

            string kunlikNasiyaQaytishi = "", kunlikQaytSumma = "", kunlikNaqd = "", kunlikPlastik = "", kunlikNasiya = "", kunlikSkidka = "";
            DataRow rowBirKunlik = tbBirKunlik.NewRow();
            if (tbKunlikShop.Rows[0]["Накд"].ToString() == "") { kunlikNaqd = "0"; }
            else { kunlikNaqd = tbKunlikShop.Rows[0]["Накд"].ToString(); }
            rowBirKunlik["Накд"] = kunlikNaqd;
            if (kunlikNaqd.IndexOf(',') > -1)
            {
                int index = kunlikNaqd.IndexOf(',');
                string first_kunlikNaqd = kunlikNaqd.Substring(0, index);
                string last_kulikNaqd = kunlikNaqd.Substring(index + 1);
                kunlikNaqd = first_kunlikNaqd + "." + last_kulikNaqd;
            }

            if (tbKunlikShop.Rows[0]["Пластик"].ToString() == "") { kunlikPlastik = "0"; }
            else { kunlikPlastik = tbKunlikShop.Rows[0]["Пластик"].ToString(); }
            rowBirKunlik["Пластик"] = kunlikPlastik;
            if (kunlikPlastik.IndexOf(',') > -1)
            {
                int index = kunlikPlastik.IndexOf(',');
                string first_kunlikPlastik = kunlikPlastik.Substring(0, index);
                string last_kunlikPlastik = kunlikPlastik.Substring(index + 1);
                kunlikPlastik = first_kunlikPlastik + "." + last_kunlikPlastik;
            }

            if (tbKunlikShop.Rows[0]["Насия"].ToString() == "") { kunlikNasiya = "0"; }
            else { kunlikNasiya = tbKunlikShop.Rows[0]["Насия"].ToString(); }
            rowBirKunlik["Насия"] = kunlikNasiya;
            if (kunlikNasiya.IndexOf(',') > -1)
            {
                int index = kunlikNasiya.IndexOf(',');
                string first_kunlikNasiya = kunlikNasiya.Substring(0, index);
                string last_kunlikNasiya = kunlikNasiya.Substring(index + 1);
                kunlikNasiya = first_kunlikNasiya + "." + last_kunlikNasiya;
            }

            if (tbKunlikShop.Rows[0]["Скидка"].ToString() == "") { kunlikSkidka = "0"; }
            else { kunlikSkidka = tbKunlikShop.Rows[0]["Скидка"].ToString(); }
            rowBirKunlik["Скидка"] = kunlikSkidka;
            if (kunlikSkidka.IndexOf(',') > -1)
            {
                int index = kunlikSkidka.IndexOf(',');
                string first_kunlikSkidka = kunlikSkidka.Substring(0, index);
                string last_kunlikSkidka = kunlikSkidka.Substring(index + 1);
                kunlikSkidka = first_kunlikSkidka + "." + last_kunlikSkidka;
            }

            if (tbKunlikReturnProduct.Rows[0]["Кайт_сумма"].ToString() == "") { kunlikQaytSumma = "0"; }
            else { kunlikQaytSumma = tbKunlikReturnProduct.Rows[0]["Кайт_сумма"].ToString(); }
            rowBirKunlik["Кайт_сумма"] = kunlikQaytSumma;
            if (kunlikQaytSumma.IndexOf(',') > -1)
            {
                int index = kunlikQaytSumma.IndexOf(',');
                string first_kunlikQaytSumma = kunlikQaytSumma.Substring(0, index);
                string last_kunlikQaytSumma = kunlikQaytSumma.Substring(index + 1);
                kunlikQaytSumma = first_kunlikQaytSumma + "." + last_kunlikQaytSumma;
            }

            if (tbKunlikNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { kunlikNasiyaQaytishi = "0"; }
            else { kunlikNasiyaQaytishi = tbKunlikNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString(); }
            rowBirKunlik["Насия_кайтиши"] = kunlikNasiyaQaytishi;
            if (kunlikNasiyaQaytishi.IndexOf(',') > -1)
            {
                int index = kunlikNasiyaQaytishi.IndexOf(',');
                string first_kunlikNasiyaQaytishi = kunlikNasiyaQaytishi.Substring(0, index);
                string last_kunlikNasiyaQaytishi = kunlikNasiyaQaytishi.Substring(index + 1);
                kunlikNasiyaQaytishi = first_kunlikNasiyaQaytishi + "." + last_kunlikNasiyaQaytishi;
            }

            double DkunlikNaqd = double.Parse(kunlikNaqd, CultureInfo.InvariantCulture);
            double DkunlikPlastik = double.Parse(kunlikPlastik, CultureInfo.InvariantCulture);
            double DkunlikNasiyaQaytishi = double.Parse(kunlikNasiyaQaytishi, CultureInfo.InvariantCulture);
            double DkunlikQaytSumma = double.Parse(kunlikQaytSumma, CultureInfo.InvariantCulture);
            double DkunlikSkidka = double.Parse(kunlikSkidka, CultureInfo.InvariantCulture);
            double jamiKunlikSumma = DkunlikNaqd + DkunlikPlastik + DkunlikNasiyaQaytishi - DkunlikQaytSumma - DkunlikSkidka;
            rowBirKunlik["Жами_сумма"] = jamiKunlikSumma.ToString();

            tbBirKunlik.Rows.Add(rowBirKunlik);

            tbKunlikShop.Clear();
            tbKunlikShop.Dispose();
            tbKunlikReturnProduct.Clear();
            tbKunlikReturnProduct.Dispose();
            tbKunlikNasiyaQaytishi.Clear();
            tbKunlikNasiyaQaytishi.Dispose();

            if (tbShop.Rows.Count > 0)
            {
                string queryCart = "select shop_id, product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbShop.Rows[managerShop.Position]["id"] + "'";
                objDBAccess.readDatathroughAdapter(queryCart, tbCart);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" && !maskVaqt.MaskFull)
            {

                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string queryShop = "select shop.id, shop.naqd as Накд, shop.plastik as Пластик, shop.nasiya as Насия, shop.difference as Скидка, shop.jamisumma as Жамисумма, shop.date as сана,userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where (shop.status_tulov=1 or shop.debt=1) and shop.date like '%" + date + "%'";
                tbShop.Clear();
                objDBAccess.readDatathroughAdapter(queryShop, tbShop);
                tbCart.Clear();
                if (tbShop.Rows.Count > 0)
                {
                    string queryCart = "select shop_id, product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbShop.Rows[managerShop.Position]["id"] + "'";
                    objDBAccess.readDatathroughAdapter(queryCart, tbCart);
                }
            }
            else if (txtSearch.Text != "")
            {
                maskVaqt.Clear();
                try
                {
                    string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    DateTime dt = Convert.ToDateTime(date);
                    string querySearch = "select cart.shop_id, cart.product_id, cart.name as Номи, cart.price as Нархи, cart.quantity as Микдори, cart.total as Умумий_сумма from cart inner join shop on cart.shop_id=shop.id where cart.name like '%" + txtSearch.Text + "%' and (shop.status_tulov=1 or shop.debt=1) and shop.date like '" + dt.ToString("yyyy-MM-dd") + "%'";
                    tbCart.Clear();
                    objDBAccess.readDatathroughAdapter(querySearch, tbCart);
                    tbShop.Clear();

                    if (tbCart.Rows.Count > 0)
                    {
                        string queryShop = "select shop.id, shop.naqd as Накд, shop.plastik as Пластик, shop.nasiya as Насия,shop.difference as Скидка, shop.jamisumma as Жамисумма, shop.date as сана,userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where (shop.status_tulov=1 or shop.debt=1) and shop.date like '" + dt.ToString("yyyy-MM-dd") + "%' and shop.id='" + tbCart.Rows[managerCart.Position]["shop_id"] + "'";
                        objDBAccess.readDatathroughAdapter(queryShop, tbShop);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearch.Text = "";
                }
            }
        }

        public void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbShop.Rows.Count == 0) return;
                frmReturnQuantity returnQuantity = new frmReturnQuantity();
                returnQuantity.shop_id = tbShop.Rows[managerShop.Position]["id"].ToString(); // shop_id
                returnQuantity.product_id = tbCart.Rows[managerCart.Position]["product_id"].ToString(); // product_id
                returnQuantity.old_price = tbCart.Rows[managerCart.Position]["Нархи"].ToString(); // narxi
                returnQuantity.sold_quantity = tbCart.Rows[managerCart.Position]["Микдори"].ToString(); // miqdori
                returnQuantity.name = tbCart.Rows[managerCart.Position]["Номи"].ToString();  // nomi
                returnQuantity.total = tbCart.Rows[managerCart.Position]["Умумий_сумма"].ToString(); //umumiy_summa
                returnQuantity.sold = true; returnQuantity.debt = false;
                returnQuantity.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dbgridShop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string queryCart = "select shop_id, product_id, name as номи, price as нархи, quantity as микдори, total as умумий_сумма from cart where shop_id='" + tbShop.Rows[managerShop.Position]["id"] + "'";
                tbCart.Clear();
                objDBAccess.readDatathroughAdapter(queryCart, tbCart);
                managerCart = (CurrencyManager)BindingContext[tbCart];
                dbgridCart.DataSource = tbCart;
                objDBAccess.closeConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable tbShop, tbCart;

        private void SoldList_Load(object sender, EventArgs e)
        {
            objDBAccess.createConn();
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string queryShop = "select shop.id, shop.naqd as Накд, shop.plastik as Пластик, shop.nasiya as Насия,shop.difference as Скидка, shop.jamisumma as Жамисумма, shop.date as сана,userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where (shop.status_tulov=1 or shop.debt=1) and shop.date like '%" + date + "%'";
            tbShop = new DataTable();
            objDBAccess.readDatathroughAdapter(queryShop, tbShop);
            managerShop = (CurrencyManager)BindingContext[tbShop];
            dbgridShop.DataSource = tbShop;
            dbgridShop.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dbgridShop.Columns[0].Visible = false;

            tbBirKunlik = new DataTable(); // Birkunlik savdo boshlanishi
            tbBirKunlik.Columns.Add("Накд");
            tbBirKunlik.Columns.Add("Пластик");
            tbBirKunlik.Columns.Add("Насия");
            tbBirKunlik.Columns.Add("Насия_кайтиши");  // payhistory
            tbBirKunlik.Columns.Add("Кайт_сумма"); // returnproduct
            tbBirKunlik.Columns.Add("Скидка");
            tbBirKunlik.Columns.Add("Жами_сумма");

            tbKunlikShop = new DataTable();
            tbKunlikReturnProduct = new DataTable();
            tbKunlikNasiyaQaytishi = new DataTable();

            string queryShopKunlik = "select sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия, sum(difference) as Скидка from shop where date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryShopKunlik, tbKunlikShop);

            string queryKunlikReturnProduct = "select sum(summa) as Кайт_сумма from returnproduct where sold=1 and date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryKunlikReturnProduct, tbKunlikReturnProduct);

            string queryKunlikNasiyaQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryKunlikNasiyaQaytishi, tbKunlikNasiyaQaytishi);

            string kunlikNasiyaQaytishi = "", kunlikSkidka, kunlikQaytSumma = "", kunlikNaqd = "", kunlikPlastik = "", kunlikNasiya = "";

            DataRow rowBirKunlik = tbBirKunlik.NewRow();
            if (tbKunlikShop.Rows[0]["Накд"].ToString() == "") { kunlikNaqd = "0"; }
            else { kunlikNaqd = tbKunlikShop.Rows[0]["Накд"].ToString(); }
            rowBirKunlik["Накд"] = kunlikNaqd;
            if (kunlikNaqd.IndexOf(',') > -1)
            {
                int index = kunlikNaqd.IndexOf(',');
                string first_kunlikNaqd = kunlikNaqd.Substring(0, index);
                string last_kulikNaqd = kunlikNaqd.Substring(index + 1);
                kunlikNaqd = first_kunlikNaqd + "." + last_kulikNaqd;
            }

            if (tbKunlikShop.Rows[0]["Скидка"].ToString() == "") { kunlikSkidka = "0"; }
            else { kunlikSkidka = tbKunlikShop.Rows[0]["Скидка"].ToString(); }
            rowBirKunlik["Скидка"] = kunlikSkidka;
            if (kunlikSkidka.IndexOf(',') > -1)
            {
                int index = kunlikSkidka.IndexOf(',');
                string first_kunlikSkidka = kunlikSkidka.Substring(0, index);
                string last_kunlikSkidka = kunlikSkidka.Substring(index + 1);
                kunlikSkidka = first_kunlikSkidka + "." + last_kunlikSkidka;
            }


            if (tbKunlikShop.Rows[0]["Пластик"].ToString() == "") { kunlikPlastik = "0"; }
            else { kunlikPlastik = tbKunlikShop.Rows[0]["Пластик"].ToString(); }
            rowBirKunlik["Пластик"] = kunlikPlastik;
            if (kunlikPlastik.IndexOf(',') > -1)
            {
                int index = kunlikPlastik.IndexOf(',');
                string first_kunlikPlastik = kunlikPlastik.Substring(0, index);
                string last_kunlikPlastik = kunlikPlastik.Substring(index + 1);
                kunlikPlastik = first_kunlikPlastik + "." + last_kunlikPlastik;
            }

            if (tbKunlikShop.Rows[0]["Насия"].ToString() == "") { kunlikNasiya = "0"; }
            else { kunlikNasiya = tbKunlikShop.Rows[0]["Насия"].ToString(); }
            rowBirKunlik["Насия"] = kunlikNasiya;
            if (kunlikNasiya.IndexOf(',') > -1)
            {
                int index = kunlikNasiya.IndexOf(',');
                string first_kunlikNasiya = kunlikNasiya.Substring(0, index);
                string last_kunlikNasiya = kunlikNasiya.Substring(index + 1);
                kunlikNasiya = first_kunlikNasiya + "." + last_kunlikNasiya;
            }

            if (tbKunlikReturnProduct.Rows[0]["Кайт_сумма"].ToString() == "") { kunlikQaytSumma = "0"; }
            else { kunlikQaytSumma = tbKunlikReturnProduct.Rows[0]["Кайт_сумма"].ToString(); }
            rowBirKunlik["Кайт_сумма"] = kunlikQaytSumma;
            if (kunlikQaytSumma.IndexOf(',') > -1)
            {
                int index = kunlikQaytSumma.IndexOf(',');
                string first_kunlikQaytSumma = kunlikQaytSumma.Substring(0, index);
                string last_kunlikQaytSumma = kunlikQaytSumma.Substring(index + 1);
                kunlikQaytSumma = first_kunlikQaytSumma + "." + last_kunlikQaytSumma;
            }

            if (tbKunlikNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { kunlikNasiyaQaytishi = "0"; }
            else { kunlikNasiyaQaytishi = tbKunlikNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString(); }
            rowBirKunlik["Насия_кайтиши"] = kunlikNasiyaQaytishi;
            if (kunlikNasiyaQaytishi.IndexOf(',') > -1)
            {
                int index = kunlikNasiyaQaytishi.IndexOf(',');
                string first_kunlikNasiyaQaytishi = kunlikNasiyaQaytishi.Substring(0, index);
                string last_kunlikNasiyaQaytishi = kunlikNasiyaQaytishi.Substring(index + 1);
                kunlikNasiyaQaytishi = first_kunlikNasiyaQaytishi + "." + last_kunlikNasiyaQaytishi;
            }

            double DkunlikNaqd = double.Parse(kunlikNaqd, CultureInfo.InvariantCulture);
            double DkunlikPlastik = double.Parse(kunlikPlastik, CultureInfo.InvariantCulture);
            double DkunlikNasiyaQaytishi = double.Parse(kunlikNasiyaQaytishi, CultureInfo.InvariantCulture);
            double DkunlikQaytSumma = double.Parse(kunlikQaytSumma, CultureInfo.InvariantCulture);
            double DKunlikSkidka = double.Parse(kunlikSkidka, CultureInfo.InvariantCulture);
            double jamiKunlikSumma = DkunlikNaqd + DkunlikPlastik + DkunlikNasiyaQaytishi - DkunlikQaytSumma - DKunlikSkidka;
            rowBirKunlik["Жами_сумма"] = jamiKunlikSumma.ToString();

            tbBirKunlik.Rows.Add(rowBirKunlik);

            tbKunlikShop.Clear();
            tbKunlikShop.Dispose();
            tbKunlikReturnProduct.Clear();
            tbKunlikReturnProduct.Dispose();
            tbKunlikNasiyaQaytishi.Clear();
            tbKunlikNasiyaQaytishi.Dispose(); // Birkunlik savdo tugashi

            if (tbShop.Rows.Count > 0)
            {
                string queryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbShop.Rows[managerShop.Position]["id"] + "'";
                tbCart = new DataTable();
                objDBAccess.readDatathroughAdapter(queryCart, tbCart);
                managerCart = (CurrencyManager)BindingContext[tbCart];
                dbgridCart.DataSource = tbCart;
                dbgridCart.Columns[0].Visible = false;
                dbgridCart.Columns[1].Visible = false;
                dbgridCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbCart.Dispose();
            }
            else
            {
                string queryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id=0";
                tbCart = new DataTable();
                objDBAccess.readDatathroughAdapter(queryCart, tbCart);
                managerCart = (CurrencyManager)BindingContext[tbCart];
                dbgridCart.DataSource = tbCart;
                dbgridCart.Columns[0].Visible = false;
                dbgridCart.Columns[1].Visible = false;
                dbgridCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbCart.Dispose();
            }
            dbgridJami.DataSource = tbBirKunlik;
            dbgridJami.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            objDBAccess.closeConn();
            tbShop.Dispose();
        }
        public void Refresh()
        {

            tbBirKunlik.Clear();
            DateTime dt_now = DateTime.Now;
            string date = dt_now.ToString("yyyy-MM-dd");
            string queryShopKunlik = "select sum(naqd) as Накд, sum(plastik) as Пластик, sum(nasiya) as Насия from shop where date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryShopKunlik, tbKunlikShop);

            string queryKunlikReturnProduct = "select sum(summa) as Кайт_сумма from returnproduct where sold=1 and date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryKunlikReturnProduct, tbKunlikReturnProduct);

            string queryKunlikNasiyaQaytishi = "select sum(given_summa) as Насия_кайтиши from payhistory where date like '" + date + "%'";
            objDBAccess.readDatathroughAdapter(queryKunlikNasiyaQaytishi, tbKunlikNasiyaQaytishi);

            string kunlikNasiyaQaytishi = "", kunlikQaytSumma = "", kunlikNaqd = "", kunlikPlastik = "", kunlikNasiya = "";

            DataRow rowBirKunlik = tbBirKunlik.NewRow();
            if (tbKunlikShop.Rows[0]["Накд"].ToString() == "") { kunlikNaqd = "0"; }
            else { kunlikNaqd = tbKunlikShop.Rows[0]["Накд"].ToString(); }
            rowBirKunlik["Накд"] = kunlikNaqd;
            if (kunlikNaqd.IndexOf(',') > -1)
            {
                int index = kunlikNaqd.IndexOf(',');
                string first_kunlikNaqd = kunlikNaqd.Substring(0, index);
                string last_kulikNaqd = kunlikNaqd.Substring(index + 1);
                kunlikNaqd = first_kunlikNaqd + "." + last_kulikNaqd;
            }

            if (tbKunlikShop.Rows[0]["Пластик"].ToString() == "") { kunlikPlastik = "0"; }
            else { kunlikPlastik = tbKunlikShop.Rows[0]["Пластик"].ToString(); }
            rowBirKunlik["Пластик"] = kunlikPlastik;
            if (kunlikPlastik.IndexOf(',') > -1)
            {
                int index = kunlikPlastik.IndexOf(',');
                string first_kunlikPlastik = kunlikPlastik.Substring(0, index);
                string last_kunlikPlastik = kunlikPlastik.Substring(index + 1);
                kunlikPlastik = first_kunlikPlastik + "." + last_kunlikPlastik;
            }

            if (tbKunlikShop.Rows[0]["Насия"].ToString() == "") { kunlikNasiya = "0"; }
            else { kunlikNasiya = tbKunlikShop.Rows[0]["Насия"].ToString(); }
            rowBirKunlik["Насия"] = kunlikNasiya;
            if (kunlikNasiya.IndexOf(',') > -1)
            {
                int index = kunlikNasiya.IndexOf(',');
                string first_kunlikNasiya = kunlikNasiya.Substring(0, index);
                string last_kunlikNasiya = kunlikNasiya.Substring(index + 1);
                kunlikNasiya = first_kunlikNasiya + "." + last_kunlikNasiya;
            }

            if (tbKunlikReturnProduct.Rows[0]["Кайт_сумма"].ToString() == "") { kunlikQaytSumma = "0"; }
            else { kunlikQaytSumma = tbKunlikReturnProduct.Rows[0]["Кайт_сумма"].ToString(); }
            rowBirKunlik["Кайт_сумма"] = kunlikQaytSumma;
            if (kunlikQaytSumma.IndexOf(',') > -1)
            {
                int index = kunlikQaytSumma.IndexOf(',');
                string first_kunlikQaytSumma = kunlikQaytSumma.Substring(0, index);
                string last_kunlikQaytSumma = kunlikQaytSumma.Substring(index + 1);
                kunlikQaytSumma = first_kunlikQaytSumma + "." + last_kunlikQaytSumma;
            }

            if (tbKunlikNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString() == "") { kunlikNasiyaQaytishi = "0"; }
            else { kunlikNasiyaQaytishi = tbKunlikNasiyaQaytishi.Rows[0]["Насия_кайтиши"].ToString(); }
            rowBirKunlik["Насия_кайтиши"] = kunlikNasiyaQaytishi;
            if (kunlikNasiyaQaytishi.IndexOf(',') > -1)
            {
                int index = kunlikNasiyaQaytishi.IndexOf(',');
                string first_kunlikNasiyaQaytishi = kunlikNasiyaQaytishi.Substring(0, index);
                string last_kunlikNasiyaQaytishi = kunlikNasiyaQaytishi.Substring(index + 1);
                kunlikNasiyaQaytishi = first_kunlikNasiyaQaytishi + "." + last_kunlikNasiyaQaytishi;
            }

            double DkunlikNaqd = double.Parse(kunlikNaqd, CultureInfo.InvariantCulture);
            double DkunlikPlastik = double.Parse(kunlikPlastik, CultureInfo.InvariantCulture);
            double DkunlikNasiyaQaytishi = double.Parse(kunlikNasiyaQaytishi, CultureInfo.InvariantCulture);
            double DkunlikQaytSumma = double.Parse(kunlikQaytSumma, CultureInfo.InvariantCulture);
            double jamiKunlikSumma = DkunlikNaqd + DkunlikPlastik + DkunlikNasiyaQaytishi - DkunlikQaytSumma;
            rowBirKunlik["Жами_сумма"] = jamiKunlikSumma.ToString();

            tbBirKunlik.Rows.Add(rowBirKunlik);

            tbKunlikShop.Clear();
            tbKunlikShop.Dispose();
            tbKunlikReturnProduct.Clear();
            tbKunlikReturnProduct.Dispose();
            tbKunlikNasiyaQaytishi.Clear();
            tbKunlikNasiyaQaytishi.Dispose(); // Birkunlik savdo tugashi

            // int shopPosition = managerShop.Position;
            //int cartPosition = managerCart.Position;
            /* txtSearch.Text = ""; maskVaqt.Clear();
             string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
             string queryShop = "select shop.id, shop.naqd as Накд, shop.plastik as Пластик, shop.nasiya as Насия, shop.jamisumma as Жамисумма, shop.date as сана, shop.status_server as статус_сэрвэр,userprofile.first_name as Сотувчи from shop inner join userprofile on shop.sellar_id=userprofile.id where shop.date like '%" + date + "%'";
             if(tbShop.Rows.Count > 0) { tbShop.Clear(); }

             objDBAccess.readDatathroughAdapter(queryShop, tbShop);

             if (tbShop.Rows.Count > 0)
             {
                 string queryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id='" + tbShop.Rows[managerShop.Position]["id"] + "'";
                 tbCart.Clear();
                 objDBAccess.readDatathroughAdapter(queryCart, tbCart);

             }
             else
             {
                 string queryCart = "select shop_id,product_id, name as Номи, price as Нархи, quantity as Микдори, total as Умумий_сумма from cart where shop_id=0";
                 tbCart.Clear();
                 objDBAccess.readDatathroughAdapter(queryCart, tbCart);
             }
             objDBAccess.closeConn();*/
            //managerShop.Position = shopPosition;
            //managerCart.Position = cartPosition;
        }
    }
}
