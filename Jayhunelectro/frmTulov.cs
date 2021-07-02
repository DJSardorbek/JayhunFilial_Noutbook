using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Jayhunelectro
{
    public partial class frmTulov : MetroFramework.Forms.MetroForm
    {
        public frmTulov()
        {
            InitializeComponent();
        }
        DBAccess objDBAccess = new DBAccess();
        public static MySqlCommand cmdShop, cmdDebtor, cmdCart, cmdDebt, cmdDebtCart;
        public static DataTable tbDebtor, tbCart;
        public static DataTable tbNasiya;
        public static CurrencyManager managerCart, managerDebtor, managerNasiya;
        public string shopId = "";
        public string footer = "";
        public string print = "";
        public void btnNaqd_Click(object sender, EventArgs e)
        {
            //To'lov naqd pulda amalga oshirilganda

            DateTime dt_now = DateTime.Now;
            string str_tulovSumma = txtTulov.Text;
            str_tulovSumma = DoubleToStr(str_tulovSumma);
            double Dtulov_summa = double.Parse(str_tulovSumma, CultureInfo.InvariantCulture);
            string skidka = txtSSumma.Text;
            skidka = DoubleToStr(skidka);
            double Dskidka = double.Parse(skidka, CultureInfo.InvariantCulture);
            double result_sum = Dtulov_summa - Dskidka;

            cmdShop = new MySqlCommand("update shop set naqd='" + DoubleToStr(result_sum.ToString()) + "', plastik=0, nasiya=0, jamisumma='" + str_tulovSumma + "',difference='" + DoubleToStr(Dskidka.ToString()) + "', status_tulov=1, date='" + dt_now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + shopId + "'");
            objDBAccess.executeQuery(cmdShop);
            cmdShop.Dispose();
            MessageBox.Show("Тўлов муваффакиятли амалга оширилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            print += "Тўланди :\nНакд : " + str_tulovSumma + "\n";
            print += "Скидка : : " + skidka + "\n";
            print += footer;
            printDocument1.Print();
            CreateBarcode(shopId);
            printBarCode();
            shopId = "";
            frmCashDesk cashDesk = new frmCashDesk();
            cashDesk.Refresh();
            Close();
        }
        BarcodeLib.Barcode barCode = new BarcodeLib.Barcode();
        public void CreateBarcode(string barcode)
        {
            errorProvider1.Clear();
            int nW = Convert.ToInt32(130);
            int nH = Convert.ToInt32(60);

            barCode.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.CODE128;
            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    barCode.IncludeLabel = true;
                    barCode.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType),
                        "RotateNoneFlipNone", true);
                    pictureBarcode.Image = barCode.Encode(type, barcode, Color.Black, Color.White, nW, nH);

                }
                pictureBarcode.Width = pictureBarcode.Image.Width;
                pictureBarcode.Height = pictureBarcode.Image.Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTulov_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && btnNaqd.Visible == true)
            {
                btnNaqd_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4 && btnPlastik.Visible == true)
            {
                btnPlastik_Click(sender, e);
            }
            if (e.KeyCode == Keys.F8)
            {
                btnNasiya_Click(sender, e);
            }
            if (e.KeyCode == Keys.F2)
            {
                btnTulov_Click(sender, e);
            }
            e.Handled = true;
        }

        public void btnPlastik_Click(object sender, EventArgs e)
        {
            //To'lov plastikda amalga oshirilganda
            DateTime dt_now = DateTime.Now;
            string str_tulovSumma = txtTulov.Text;
            str_tulovSumma = DoubleToStr(str_tulovSumma);
            double Dtulov_summa = double.Parse(str_tulovSumma, CultureInfo.InvariantCulture);
            string skidka = txtSSumma.Text;
            skidka = DoubleToStr(skidka);
            double Dskidka = double.Parse(skidka, CultureInfo.InvariantCulture);
            double result_sum = Dtulov_summa - Dskidka;

            cmdShop = new MySqlCommand("update shop set naqd=0, plastik='" + DoubleToStr(result_sum.ToString()) + "', nasiya=0, jamisumma='" + str_tulovSumma + "',difference='" + DoubleToStr(Dskidka.ToString()) + "', status_tulov=1, date='" + dt_now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + shopId + "'");
            objDBAccess.executeQuery(cmdShop);
            cmdShop.Dispose();
            MessageBox.Show("Тўлов муваффакиятли амалга оширилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            print += "Тўланди :\nПластик : " + str_tulovSumma + "\n";
            print += "Скидка : " + skidka + "\n";
            print += footer;
            printDocument1.Print();
            CreateBarcode(shopId);
            printBarCode();
            shopId = "";
            frmCashDesk cashDesk = new frmCashDesk();
            cashDesk.Refresh();
            Close();
        }

        private void btnQoshish_Click(object sender, EventArgs e)
        {
            if (txtMiqdor.Text == "")
            {
                MessageBox.Show("Товар микдорини киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMiqdor.Text.IndexOf(',') > -1)
            {
                MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMiqdor.Clear();
                return;
            }
            double summa = double.Parse(txtMiqdor.Text, CultureInfo.InvariantCulture) * double.Parse(comboPrice.Text, CultureInfo.InvariantCulture);
            txtNasiya.Text = summa.ToString();
            string str_Nasiya = txtNasiya.Text;
            if (str_Nasiya.IndexOf(',') > -1)
            {
                int index_nasiya = str_Nasiya.IndexOf(',');
                string first_nasiya = str_Nasiya.Substring(0, index_nasiya);
                string last_nasiya = str_Nasiya.Substring(index_nasiya + 1);
                str_Nasiya = first_nasiya + "." + last_nasiya;
            }
            double Nasiya = double.Parse(str_Nasiya, CultureInfo.InvariantCulture);
            double jamiNasiya = 0;
            string str_JamiNasiya = txtJamiNasiya.Text;
            if (str_JamiNasiya != "")
            {
                if (str_JamiNasiya.IndexOf(',') > -1)
                {
                    int index = str_JamiNasiya.IndexOf(',');
                    string first_jamiNasiya = str_JamiNasiya.Substring(0, index);
                    string last_jamiNasiya = str_JamiNasiya.Substring(index + 1);
                    str_JamiNasiya = first_jamiNasiya + "." + last_jamiNasiya;
                }
                jamiNasiya = double.Parse(str_JamiNasiya, CultureInfo.InvariantCulture);
            }
            jamiNasiya += Nasiya;
            txtJamiNasiya.Text = jamiNasiya.ToString();
            DataRow row = tbNasiya.NewRow();
            row["product_id"] = tbCart.Rows[managerCart.Position]["product_id"].ToString();
            string queryBarcode = "select barcode from product where product_id='" + tbCart.Rows[managerCart.Position]["product_id"].ToString() + "'";
            DataTable tbBarcode = new DataTable();
            objDBAccess.readDatathroughAdapter(queryBarcode, tbBarcode);

            row["barcode"] = tbBarcode.Rows[0]["barcode"].ToString();
            tbBarcode.Clear();
            tbBarcode.Dispose();

            row["Номи"] = tbCart.Rows[managerCart.Position]["Номи"].ToString();
            row["Нархи"] = tbCart.Rows[managerCart.Position]["Нархи"].ToString();
            double miqdor = double.Parse(txtMiqdor.Text, CultureInfo.InvariantCulture);
            row["Насия_микдори"] = miqdor.ToString();
            row["Умумий_сумма"] = txtNasiya.Text;
            tbNasiya.Rows.Add(row);
            txtMiqdor.Clear();
            txtNasiya.Clear();
        }


        private void txtMiqdor_TextChanged(object sender, EventArgs e)
        {
            /*if(txtMiqdor.Text!="")
            {
                double parsedValue;
                if (!double.TryParse(txtMiqdor.Text, out parsedValue))
                {
                    txtMiqdor.Clear();
                    return;
                }
                decimal summa = decimal.Parse(txtMiqdor.Text, CultureInfo.InvariantCulture) * decimal.Parse(comboPrice.Text, CultureInfo.InvariantCulture);
                txtNasiya.Text = summa.ToString();
            }
            else
            {
                txtNasiya.Clear();
            }*/
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmTulov_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(print, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        public string DoubleToStr(string s)
        {
            if (s.IndexOf(',') > -1)
            {
                int index = s.IndexOf(',');
                string first = s.Substring(0, index);
                string last = s.Substring(index + 1);
                s = first + "." + last;
            }
            return s;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSkidka.Text != "")
            {
                double parsedValue;
                if (!double.TryParse(txtSkidka.Text, out parsedValue))
                {
                    txtSkidka.Clear();
                    return;
                }
                string s_tulov = txtTulov.Text;
                s_tulov = DoubleToStr(s_tulov);
                double tulov = double.Parse(s_tulov, CultureInfo.InvariantCulture);
                double total = tulov * double.Parse(txtSkidka.Text, CultureInfo.InvariantCulture) / 100;
                txtSSumma.Text = total.ToString();
            }
            else
            {
                txtSSumma.Text = "";
            }
        }

        private void printBarCode()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            doc.Print();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBarcode.Width, pictureBarcode.Height);
            pictureBarcode.DrawToBitmap(bm, new Rectangle(0, 0, pictureBarcode.Width, pictureBarcode.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dbgridNasiya_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridNasiya.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btmNew_Click(object sender, EventArgs e)
        {
            comboFISH.Visible = false;
            comboTel1.Visible = false;
            comboTel2.Visible = false;

            txtFISH.Visible = true;
            txtTel1.Visible = true;
            txtTel2.Visible = true;
            btmNew.Enabled = false;
        }

        public void btnTulov_Click(object sender, EventArgs e)
        {
            string naqd = "0", plastik = "0", nasiya = "0", skidka = "0";
            //Nasiya yo'q bo'lsa
            if (panelNayisa.Enabled == false)
            {
                if (txtNaqd.Text == "" && txtPlastik.Text == "")
                {
                    MessageBox.Show("Тўлов суммасини тўланг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNaqd.Text.IndexOf(',') > -1 || txtPlastik.Text.IndexOf(',') > -1)
                {
                    MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNaqd.Clear();
                    txtPlastik.Clear();
                    return;
                }
                if (txtNaqd.Text != "")
                {
                    naqd = txtNaqd.Text;
                }

                if (txtPlastik.Text != "")
                {
                    plastik = txtPlastik.Text;
                }
                if (txtSSumma.Text != "0")
                {
                    skidka = txtSSumma.Text;
                    skidka = DoubleToStr(skidka);
                }
                string jamiTulov = txtTulov.Text;
                if (jamiTulov.IndexOf(',') > -1)
                {
                    int index_t = jamiTulov.IndexOf(',');
                    string first_t = jamiTulov.Substring(0, index_t);
                    string last_t = jamiTulov.Substring(index_t + 1);
                    jamiTulov = first_t + "." + last_t;
                }
                if ((double.Parse(naqd, CultureInfo.InvariantCulture) + double.Parse(plastik, CultureInfo.InvariantCulture) + double.Parse(skidka, CultureInfo.InvariantCulture)) > double.Parse(jamiTulov, CultureInfo.InvariantCulture)
                    || (double.Parse(naqd, CultureInfo.InvariantCulture) + double.Parse(plastik, CultureInfo.InvariantCulture) + double.Parse(skidka, CultureInfo.InvariantCulture)) < double.Parse(jamiTulov, CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Тўловни тўгри киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime dt_now = DateTime.Now;
                cmdShop = new MySqlCommand("update shop set naqd='" + naqd + "', plastik='" + plastik + "', nasiya=0, jamisumma='" + jamiTulov + "',difference='" + DoubleToStr(skidka) + "', status_tulov=1, date='" + dt_now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + shopId + "'");
                objDBAccess.executeQuery(cmdShop);
                cmdShop.Dispose();
                MessageBox.Show("Тўлов муваффакиятли амалга оширилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                print += "Тўланди :\nНакд : " + naqd + "\n";
                print += "Пластик : " + plastik + "\n";
                print += "Скидка : " + skidka + "\n";
                print += footer;
                printDocument1.Print();
                CreateBarcode(shopId);
                printBarCode();
                frmCashDesk cashDesk = new frmCashDesk();
                cashDesk.Refresh();
                Close();
            }

            //Nasiya aralash bo'lsa

            if (panelNayisa.Enabled == true)
            {
                if (txtJamiNasiya.Text == "")
                {
                    MessageBox.Show("Тўлов суммасини тўланг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNaqd.Text.IndexOf(',') > -1) // Agar naqd pul , bilan kiritilsa
                {
                    MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNaqd.Clear();
                    return;
                }

                if (txtPlastik.Text.IndexOf(',') > -1) // Agar plastik , bilan kiritilsa
                {
                    MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPlastik.Clear();
                    return;
                }

                if (txtNaqd.Text != "")
                {
                    naqd = txtNaqd.Text;
                }

                if (txtPlastik.Text != "")
                {
                    plastik = txtPlastik.Text;
                }
                if (txtSSumma.Text != "0")
                {
                    skidka = txtSSumma.Text;
                    skidka = DoubleToStr(skidka);
                }
                if (txtJamiNasiya.Text != "")
                {
                    if (txtJamiNasiya.Text.IndexOf(',') > -1)
                    {
                        int index_jamiSumma = txtJamiNasiya.Text.IndexOf(',');
                        string first_jamiNasiya = txtJamiNasiya.Text.Substring(0, index_jamiSumma);
                        string last_jamiNasiya = txtJamiNasiya.Text.Substring(index_jamiSumma + 1);
                        nasiya = first_jamiNasiya + "." + last_jamiNasiya;
                    }
                    else
                    { nasiya = txtJamiNasiya.Text; }
                }
                string tulov = txtTulov.Text;
                if (tulov.IndexOf(',') > -1)
                {
                    int index = tulov.IndexOf(',');
                    string first = tulov.Substring(0, index);
                    string last = tulov.Substring(index + 1);
                    tulov = first + "." + last;
                }
                if ((double.Parse(naqd, CultureInfo.InvariantCulture) + double.Parse(plastik, CultureInfo.InvariantCulture) + double.Parse(nasiya, CultureInfo.InvariantCulture) + double.Parse(skidka, CultureInfo.InvariantCulture)) != double.Parse(tulov, CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Тўловни тўгри киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (comboFISH.Visible && comboTel1.Visible && comboTel2.Visible)
                {
                    //debt jadvali bo'sh yoki bo'shmasligini tekshiramiz
                    int Debt_id = 0;
                    string queryDebt = "select * from debt order by id desc limit 1";
                    DataTable tbDebt = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebt, tbDebt);
                    if (tbDebt.Rows.Count > 0) //Agar bo'sh bo'lmasa debt_id+=1 bo'ladi
                    {
                        Debt_id = int.Parse(tbDebt.Rows[0]["id"].ToString()) + 1;
                    }
                    else { Debt_id = 1; } // Agar bo'sh bo'lsa debt_id = 1 bo'ladi
                    tbDebt.Clear();
                    tbDebt.Dispose();

                    //debt jadvaliga debtor_id, shop_id, return_date larni yozamiz
                    string Debtor_id = tbDebtor.Rows[managerDebtor.Position]["id"].ToString();
                    string date_now = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                    cmdDebt = new MySqlCommand("insert into debt (id,debtor_id, shop_id, return_date) values('" + Debt_id + "','" + Debtor_id + "', '" + shopId + "','" + date_now + "' )");
                    objDBAccess.executeQuery(cmdDebt);
                    cmdDebt.Dispose();

                    //cartdebt jadvali bo'sh yoki bo'shmasligini tekshirishimiz kerek
                    int cartDebt_id = 0;
                    string queryCartDebt = "select * from cartdebt";
                    DataTable tbCartDebt = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryCartDebt, tbCartDebt);
                    if (tbCartDebt.Rows.Count == 0) //Agar bo'sh bo'lsa
                    {
                        cartDebt_id = 1;
                        int Count = managerNasiya.Count;
                        managerNasiya.Position = 0;
                        string product_id = "", name = "", price = "", quantity = "", total = "", barcode = "";
                        for (int i = 0; i < Count; i++) //tbNasiya jadvalidagi maxsulotlarni har birini cartdebtga kiritib chiqamiz
                        {

                            barcode = tbNasiya.Rows[managerNasiya.Position]["barcode"].ToString();
                            product_id = tbNasiya.Rows[managerNasiya.Position]["product_id"].ToString();
                            name = tbNasiya.Rows[managerNasiya.Position]["Номи"].ToString();
                            price = tbNasiya.Rows[managerNasiya.Position]["Нархи"].ToString();
                            quantity = tbNasiya.Rows[managerNasiya.Position]["Насия_микдори"].ToString();//
                            if (quantity.IndexOf(',') > -1)
                            {
                                int index = quantity.IndexOf(',');
                                string first_quantity = quantity.Substring(0, index);
                                string last_quantity = quantity.Substring(index + 1);
                                quantity = first_quantity + "." + last_quantity;
                            }
                            total = tbNasiya.Rows[managerNasiya.Position]["Умумий_сумма"].ToString();//
                            if (total.IndexOf(',') > -1)
                            {
                                int index = total.IndexOf(',');
                                string first_total = total.Substring(0, index);
                                string last_total = total.Substring(index + 1);
                                total = first_total + "." + last_total;
                            }
                            if (managerNasiya.Position == 0)
                            {
                                cmdDebtCart = new MySqlCommand("insert into cartdebt (id,debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                                "values('" + cartDebt_id + "','" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'" + barcode + "')");
                                objDBAccess.executeQuery(cmdDebtCart);
                                cmdDebtCart.Dispose();
                            }
                            else
                            {
                                cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                                "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'" + barcode + "')");
                                objDBAccess.executeQuery(cmdDebtCart);
                                cmdDebtCart.Dispose();
                            }
                            managerNasiya.Position++;
                        }
                    }


                    else //Agar cartdebt bo'sh bo'lmasa
                    {
                        cartDebt_id = 1;
                        int Count = managerNasiya.Count;
                        managerNasiya.Position = 0;
                        string product_id = "", name = "", price = "", quantity = "", total = "", barcode = "";
                        string old_givenQuantity = "", old_total = "", old_debtQuantity = "", old_debtPrice = "";
                        for (int i = 0; i < Count; i++)
                        {
                            barcode = tbNasiya.Rows[managerNasiya.Position]["barcode"].ToString();
                            product_id = tbNasiya.Rows[managerNasiya.Position]["product_id"].ToString();
                            name = tbNasiya.Rows[managerNasiya.Position]["Номи"].ToString();
                            price = tbNasiya.Rows[managerNasiya.Position]["Нархи"].ToString();
                            quantity = tbNasiya.Rows[managerNasiya.Position]["Насия_микдори"].ToString(); //
                            if (quantity.IndexOf(',') > -1)
                            {
                                int index = quantity.IndexOf(',');
                                string first_quantity = quantity.Substring(0, index);
                                string last_quantity = quantity.Substring(index + 1);
                                quantity = first_quantity + "." + last_quantity;
                            }
                            total = tbNasiya.Rows[managerNasiya.Position]["Умумий_сумма"].ToString(); //
                            if (total.IndexOf(',') > -1)
                            {
                                int index = total.IndexOf(',');
                                string first_total = total.Substring(0, index);
                                string last_total = total.Substring(index + 1);
                                total = first_total + "." + last_total;
                            }
                            string queryCartDebtProduct = "select * from cartdebt where debtor_id='" + Debtor_id + "' and product_id='" + product_id + "' order by id desc limit 1";
                            DataTable tbCartDebtProduct = new DataTable();
                            objDBAccess.readDatathroughAdapter(queryCartDebtProduct, tbCartDebtProduct);
                            if (tbCartDebtProduct.Rows.Count == 1) // Agar ushbu maxsulotdan avval olingan bo'lsa
                            {
                                //2 xil xolat bor . 1- holat avvalgi narx katta bo'lsa
                                if (double.Parse(tbCartDebtProduct.Rows[0]["price"].ToString(), CultureInfo.InvariantCulture) > double.Parse(price, CultureInfo.InvariantCulture))
                                {
                                    cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                                   "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'" + barcode + "')");
                                    objDBAccess.executeQuery(cmdDebtCart);
                                    cmdDebtCart.Dispose();
                                }
                                //2 - holat avvalgi narx teng bo'lsa
                                else if (double.Parse(tbCartDebtProduct.Rows[0]["price"].ToString(), CultureInfo.InvariantCulture) == double.Parse(price, CultureInfo.InvariantCulture))
                                {
                                    old_givenQuantity = tbCartDebtProduct.Rows[0]["given_quantity"].ToString(); // Avvalgi berilgan miqdor//
                                    if (old_givenQuantity.IndexOf(',') > -1)
                                    {
                                        int index = old_givenQuantity.IndexOf(',');
                                        string first_oldGivenQuantity = old_givenQuantity.Substring(0, index);
                                        string last_oldGivenQuantity = old_givenQuantity.Substring(index + 1);
                                        old_givenQuantity = first_oldGivenQuantity + "." + last_oldGivenQuantity;
                                    }
                                    old_total = tbCartDebtProduct.Rows[0]["total"].ToString();  // Avvalgi umumiy summa
                                    old_debtQuantity = tbCartDebtProduct.Rows[0]["debt_quantity"].ToString();  // Avvalgi qolgan miqdor //
                                    if (old_debtQuantity.IndexOf(',') > -1)
                                    {
                                        int index = old_debtQuantity.IndexOf(',');
                                        string first_oldDebtQuantity = old_debtQuantity.Substring(0, index);
                                        string last_oldDebtQuantity = old_debtQuantity.Substring(index + 1);
                                        old_debtQuantity = first_oldDebtQuantity + "." + last_oldDebtQuantity;
                                    }
                                    old_debtPrice = tbCartDebtProduct.Rows[0]["debt_price"].ToString();  // Avvalgi qolgan summa //
                                    if (old_debtPrice.IndexOf(',') > -1)
                                    {
                                        int index = old_debtPrice.IndexOf(',');
                                        string first_oldDebtPrice = old_debtPrice.Substring(0, index);
                                        string last_oldDebtPrice = old_debtPrice.Substring(index + 1);
                                        old_debtPrice = first_oldDebtPrice + "." + last_oldDebtPrice;
                                    }

                                    double Dold_givenQuantity = double.Parse(old_givenQuantity, CultureInfo.InvariantCulture);
                                    double Dquantity = double.Parse(quantity, CultureInfo.InvariantCulture);
                                    double result_givenQuantity = Dold_givenQuantity + Dquantity; // umumiy berilgan miqdor
                                    string str_result_givenQuantity = result_givenQuantity.ToString();
                                    if (str_result_givenQuantity.IndexOf(',') > -1)
                                    {
                                        int index = str_result_givenQuantity.IndexOf(',');
                                        string first_result_givenQuantity = str_result_givenQuantity.Substring(0, index);
                                        string last_result_givenQuantity = str_result_givenQuantity.Substring(index + 1);
                                        str_result_givenQuantity = first_result_givenQuantity + "." + last_result_givenQuantity;
                                    }

                                    double Dold_total = double.Parse(old_total, CultureInfo.InvariantCulture);
                                    double Dtotal = double.Parse(total, CultureInfo.InvariantCulture);
                                    double result_total = Dold_total + Dtotal; // umumiy berilgan summa
                                    string str_result_total = result_total.ToString();
                                    if (str_result_total.IndexOf(',') > -1)
                                    {
                                        int index = str_result_total.IndexOf(',');
                                        string first_result_total = str_result_total.Substring(0, index);
                                        string last_result_total = str_result_total.Substring(index + 1);
                                        str_result_total = first_result_total + "." + last_result_total;
                                    }

                                    double Dold_debtQuantity = double.Parse(old_debtQuantity, CultureInfo.InvariantCulture);
                                    double result_debtQuantity = Dold_debtQuantity + Dquantity; // umumiy qolgan miqdor
                                    string str_result_debtQuantity = result_debtQuantity.ToString();
                                    if (str_result_debtQuantity.IndexOf(',') > -1)
                                    {
                                        int index = str_result_debtQuantity.IndexOf(',');
                                        string first_result_debtQuantity = str_result_debtQuantity.Substring(0, index);
                                        string last_result_debtQuantity = str_result_debtQuantity.Substring(index + 1);
                                        str_result_debtQuantity = first_result_debtQuantity + "." + last_result_debtQuantity;
                                    }

                                    double Dold_debtPrice = double.Parse(old_debtPrice, CultureInfo.InvariantCulture);
                                    double result_debtPrice = Dold_debtPrice + Dtotal; // umumiy qolgan summa
                                    string str_result_debtPrice = result_debtPrice.ToString();
                                    if (str_result_debtPrice.IndexOf(',') > -1)
                                    {
                                        int index = str_result_debtPrice.IndexOf(',');
                                        string first_result_debtPrice = str_result_debtPrice.Substring(0, index);
                                        string last_result_debtPrice = str_result_debtPrice.Substring(index + 1);
                                        str_result_debtPrice = first_result_debtPrice + "." + last_result_debtPrice;
                                    }

                                    cmdDebtCart = new MySqlCommand("update cartdebt set given_quantity='" + str_result_givenQuantity + "', total='" + str_result_total + "', debt_quantity='" + str_result_debtQuantity + "', debt_price='" + str_result_debtPrice + "' where product_id='" + product_id + "' and debtor_id='" + Debtor_id + "'");
                                    objDBAccess.executeQuery(cmdDebtCart);
                                    cmdDebtCart.Dispose();
                                }
                            }
                            else  // Agar ushbu maxsulotdan avval olinmagan bo'lsa
                            {
                                cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                                  "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'" + barcode + "')");
                                objDBAccess.executeQuery(cmdDebtCart);
                                cmdDebtCart.Dispose();
                            }
                            tbCartDebtProduct.Clear();
                            tbCartDebtProduct.Dispose();
                            managerNasiya.Position++;
                        }
                    }
                    tbCartDebt.Clear();
                    tbCartDebt.Dispose();

                    //shopni naqd, plastik, nasiya, jamisumma, status_tulov, debt ustunlarini update qilamiz
                    DateTime dt_now = DateTime.Now;

                    string jamiTulov = txtTulov.Text;
                    if (jamiTulov.IndexOf(',') > -1)
                    {
                        int index_t = jamiTulov.IndexOf(',');
                        string first_t = jamiTulov.Substring(0, index_t);
                        string last_t = jamiTulov.Substring(index_t + 1);
                        jamiTulov = first_t + "." + last_t;
                    }
                    cmdShop = new MySqlCommand("update shop set naqd='" + naqd + "', plastik='" + plastik + "', nasiya='" + nasiya + "', jamisumma='" + jamiTulov + "',difference='" + DoubleToStr(skidka) + "', status_tulov=1, debt=1, date='" + dt_now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + shopId + "'");
                    objDBAccess.executeQuery(cmdShop);
                    cmdShop.Dispose();

                    //umumiy_qarz debtor jadvaliga yozilishi kerek  
                    string old_umumiyQarz = tbDebtor.Rows[managerDebtor.Position]["umumiy_qarz"].ToString();
                    double Dold_umumiyQarz = double.Parse(old_umumiyQarz, CultureInfo.InvariantCulture);
                    string str_JamiNasiya = txtJamiNasiya.Text;
                    if (str_JamiNasiya.IndexOf(',') > -1)
                    {
                        int index = str_JamiNasiya.IndexOf(',');
                        string first_JamiNasiya = str_JamiNasiya.Substring(0, index);
                        string last_JamiNasiya = str_JamiNasiya.Substring(index + 1);
                        str_JamiNasiya = first_JamiNasiya + "." + last_JamiNasiya;
                    }
                    double DJamiNasiya = double.Parse(str_JamiNasiya, CultureInfo.InvariantCulture);

                    double result_umumiyQarz = Dold_umumiyQarz + DJamiNasiya;
                    string str_result_umumiyQarz = result_umumiyQarz.ToString();
                    if (str_result_umumiyQarz.IndexOf(',') > -1)
                    {
                        int index = str_result_umumiyQarz.IndexOf(',');
                        string first_result_umumiyQarz = str_result_umumiyQarz.Substring(0, index);
                        string last_result_umumiyQarz = str_result_umumiyQarz.Substring(index + 1);
                        str_result_umumiyQarz = first_result_umumiyQarz + "." + last_result_umumiyQarz;
                    }
                    cmdDebtor = new MySqlCommand("update debtor set umumiy_qarz='" + str_result_umumiyQarz + "' where id='" + Debtor_id + "'");
                    objDBAccess.executeQuery(cmdDebtor);
                    cmdDebtor.Dispose();

                }
                else if (txtFISH.Visible && txtTel1.Visible && txtTel2.Visible) // Agar debtor tanlanmagan bo'lsa, yangi bo'lsa
                {
                    if (txtFISH.Text == "" || txtTel1.Text == "")
                    {
                        MessageBox.Show("Малумотлар тўлик эмас, Илтомос тэкшириб кўринг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //yangi debtorni debtor jadvaliga qo'shamiz + debtor jadvali bo'sh yoki bo'shmasligini tekshiramiz
                    string Debtor_id = "";
                    if (tbDebtor.Rows.Count == 0) // Agar bo'sh bo'lsa
                    {
                        string str_JamiNasiya = txtJamiNasiya.Text;
                        if (str_JamiNasiya.IndexOf(',') > -1)
                        {
                            int index = str_JamiNasiya.IndexOf(',');
                            string first_JamiNasiya = str_JamiNasiya.Substring(0, index);
                            string last_JamiNasiya = str_JamiNasiya.Substring(index + 1);
                            str_JamiNasiya = first_JamiNasiya + "." + last_JamiNasiya;
                        }

                        cmdDebtor = new MySqlCommand("insert into debtor (id, mijoz_fish, tel_1, tel_2, umumiy_qarz, difference, status_difference) values(1,'" + txtFISH.Text + "', '" + txtTel1.Text + "', '" + txtTel2.Text + "', '" + str_JamiNasiya + "',0,0)");
                        objDBAccess.executeQuery(cmdDebtor);
                        cmdDebtor.Dispose();
                        Debtor_id = "1";
                    }
                    else if (tbDebtor.Rows.Count > 0) // Agar bo'sh bo'lmasa
                    {
                        string queryDebtor_id = "select * from debtor order by id desc limit 1";
                        DataTable tbDebtor_id = new DataTable();
                        objDBAccess.readDatathroughAdapter(queryDebtor_id, tbDebtor_id);
                        Debtor_id = tbDebtor_id.Rows[0]["id"].ToString();
                        int debtor = int.Parse(Debtor_id) + 1;
                        Debtor_id = debtor.ToString();
                        tbDebtor_id.Clear();
                        tbDebtor_id.Dispose();
                        string str_JamiNasiya = txtJamiNasiya.Text;
                        if (str_JamiNasiya.IndexOf(',') > -1)
                        {
                            int index = str_JamiNasiya.IndexOf(',');
                            string first_JamiNasiya = str_JamiNasiya.Substring(0, index);
                            string last_JamiNasiya = str_JamiNasiya.Substring(index + 1);
                            str_JamiNasiya = first_JamiNasiya + "." + last_JamiNasiya;
                        }
                        cmdDebtor = new MySqlCommand("insert into debtor (id,mijoz_fish, tel_1, tel_2, umumiy_qarz, difference, status_difference) values('" + Debtor_id + "','" + txtFISH.Text + "', '" + txtTel1.Text + "', '" + txtTel2.Text + "', '" + str_JamiNasiya + "',0,0)");
                        objDBAccess.executeQuery(cmdDebtor);
                        cmdDebtor.Dispose();
                    }
                    //debt jadvali bo'sh yoki bo'shmasligini tekshiramiz
                    int Debt_id = 0;
                    string queryDebt = "select * from debt order by id desc limit 1";
                    DataTable tbDebt = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebt, tbDebt);
                    if (tbDebt.Rows.Count > 0) //Agar bo'sh bo'lmasa debt_id+=1 bo'ladi
                    {
                        Debt_id = int.Parse(tbDebt.Rows[0]["id"].ToString()) + 1;
                    }
                    else { Debt_id = 1; } // Agar bo'sh bo'lsa debt_id = 1 bo'ladi
                    tbDebt.Clear();
                    tbDebt.Dispose();

                    //debt jadvaliga debtor_id, shop_id, return_date larni yozamiz
                    string date_now = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                    cmdDebt = new MySqlCommand("insert into debt (id,debtor_id, shop_id, return_date) values('" + Debt_id + "','" + Debtor_id + "', '" + shopId + "','" + date_now + "' )");
                    objDBAccess.executeQuery(cmdDebt);
                    cmdDebt.Dispose();

                    // cartdebt jadvaliga cart jadvalidagi ma'lumotlarni kiritamiz
                    //cartdebt jadvali bo'sh yoki bo'shmasligini tekshirishimiz kerek
                    int cartDebt_id = 0;
                    string queryCartDebt = "select * from cartdebt";
                    DataTable tbCartDebt = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryCartDebt, tbCartDebt);
                    if (tbCartDebt.Rows.Count == 0) //Agar bo'sh bo'lsa cartdebt_id = 1 bo'ladi
                    {
                        cartDebt_id = 1;
                        int Count = managerNasiya.Count;
                        managerNasiya.Position = 0;
                        string product_id = "", name = "", price = "", quantity = "", total = "", barcode = "";
                        for (int i = 0; i < Count; i++) // maxsulotlarni har birini cartdebtga kiritib chiqamiz
                        {
                            barcode = tbNasiya.Rows[managerNasiya.Position]["barcode"].ToString();
                            product_id = tbNasiya.Rows[managerNasiya.Position]["product_id"].ToString();
                            name = tbNasiya.Rows[managerNasiya.Position]["Номи"].ToString();
                            price = tbNasiya.Rows[managerNasiya.Position]["Нархи"].ToString();
                            quantity = tbNasiya.Rows[managerNasiya.Position]["Насия_микдори"].ToString(); // 
                            if (quantity.IndexOf(',') > -1)
                            {
                                int index = quantity.IndexOf(',');
                                string first_quantity = quantity.Substring(0, index);
                                string last_quantity = quantity.Substring(index + 1);
                                quantity = first_quantity + "." + last_quantity;
                            }
                            total = tbNasiya.Rows[managerNasiya.Position]["Умумий_сумма"].ToString();  //
                            if (total.IndexOf(',') > -1)
                            {
                                int index = total.IndexOf(',');
                                string first_total = total.Substring(0, index);
                                string last_total = total.Substring(index + 1);
                                total = first_total + "." + last_total;
                            }
                            if (managerNasiya.Position == 0)
                            {
                                cmdDebtCart = new MySqlCommand("insert into cartdebt (id,debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                                "values('" + cartDebt_id + "','" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'" + barcode + "')");
                                objDBAccess.executeQuery(cmdDebtCart);
                                cmdDebtCart.Dispose();
                            }
                            else
                            {
                                cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                                "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'" + barcode + "')");
                                objDBAccess.executeQuery(cmdDebtCart);
                                cmdDebtCart.Dispose();
                            }
                            managerNasiya.Position++;
                        }
                    }
                    else // Agar bo'sh bo'lmasa cartdebt_id+=1 bo'ladi
                    {
                        int Count = managerNasiya.Count;
                        managerNasiya.Position = 0;
                        string product_id = "", name = "", price = "", quantity = "", total = "", barcode = "";
                        for (int i = 0; i < Count; i++) // maxsulotlarni har birini cartdebtga kiritib chiqamiz
                        {
                            barcode = tbNasiya.Rows[managerNasiya.Position]["barcode"].ToString();
                            product_id = tbNasiya.Rows[managerNasiya.Position]["product_id"].ToString();
                            name = tbNasiya.Rows[managerNasiya.Position]["Номи"].ToString();
                            price = tbNasiya.Rows[managerNasiya.Position]["Нархи"].ToString();
                            quantity = tbNasiya.Rows[managerNasiya.Position]["Насия_микдори"].ToString(); //
                            if (quantity.IndexOf(',') > -1)
                            {
                                int index = quantity.IndexOf(',');
                                string first_quantity = quantity.Substring(0, index);
                                string last_quantity = quantity.Substring(index + 1);
                                quantity = first_quantity + "." + last_quantity;
                            }
                            total = tbNasiya.Rows[managerNasiya.Position]["Умумий_сумма"].ToString(); //
                            if (total.IndexOf(',') > -1)
                            {
                                int index = total.IndexOf(',');
                                string first_total = total.Substring(0, index);
                                string last_total = total.Substring(index + 1);
                                total = first_total + "." + last_total;
                            }
                            cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                            "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'" + barcode + "')");
                            objDBAccess.executeQuery(cmdDebtCart);
                            cmdDebtCart.Dispose();
                            managerNasiya.Position++;
                        }
                    }
                    tbCartDebt.Clear();
                    tbCartDebt.Dispose();

                    //shopni naqd, plastik, nasiya, jamisumma, status_tulov, debt ustunlarini update qilamiz
                    DateTime dt_now = DateTime.Now;

                    string jamiTulov = txtTulov.Text;
                    if (jamiTulov.IndexOf(',') > -1)
                    {
                        int index_t = jamiTulov.IndexOf(',');
                        string first_t = jamiTulov.Substring(0, index_t);
                        string last_t = jamiTulov.Substring(index_t + 1);
                        jamiTulov = first_t + "." + last_t;
                    }

                    cmdShop = new MySqlCommand("update shop set naqd='" + naqd + "', plastik='" + plastik + "', nasiya='" + nasiya + "', jamisumma='" + jamiTulov + "',difference='" + DoubleToStr(skidka) + "', status_tulov=1, debt=1, date='" + dt_now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + shopId + "'");
                    objDBAccess.executeQuery(cmdShop);
                    cmdShop.Dispose();
                }
                MessageBox.Show("Тўлов муваффакиятли амалга оширилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                print += "Тўланди :\nНакд : " + naqd + "\n";
                print += "Пластик : " + plastik + "\n";
                print += "Скидка : " + skidka + "\n";
                print += "Насия : " + nasiya + "\n";
                print += footer;
                printDocument1.Print();
                CreateBarcode(shopId);
                printBarCode();
                frmCashDesk cashDesk = new frmCashDesk();
                cashDesk.Refresh();
                Close();
            }
        }

        public void btnNasiya_Click(object sender, EventArgs e)
        {
            Width = 825; Height = 750;
            panelNayisa.Visible = true;
            StartPosition = FormStartPosition.CenterScreen;
            Top = 15;
            //debtor jadvalidagi qarzdorlarni comboboxlarga yozamiz
            string queryDebtor = "select * from debtor";
            tbDebtor = new DataTable();
            objDBAccess.readDatathroughAdapter(queryDebtor, tbDebtor);
            managerDebtor = (CurrencyManager)BindingContext[tbDebtor];
            comboFISH.DataSource = tbDebtor;
            comboFISH.DisplayMember = "mijoz_fish";

            comboTel1.DataSource = tbDebtor;
            comboTel1.DisplayMember = "tel_1";

            comboTel2.DataSource = tbDebtor;
            comboTel2.DisplayMember = "tel_2";

            //cart jadvalidagi tovarlarni comboProduct ga yozamiz
            string queryCart = "select product_id, name as Номи, price as Нархи,quantity as Микдори, total as Умумий_сумма from cart " +
                "inner join shop on cart.shop_id=shop.id where shop.id='" + shopId + "' and shop.debt=0";
            tbCart = new DataTable();
            objDBAccess.readDatathroughAdapter(queryCart, tbCart);
            managerCart = (CurrencyManager)BindingContext[tbCart];
            comboProduct.DataSource = tbCart;
            comboProduct.DisplayMember = "Номи";

            comboPrice.DataSource = tbCart;
            comboPrice.DisplayMember = "Нархи";

            comboQuantity.DataSource = tbCart;
            comboQuantity.DisplayMember = "Микдори";

            tbNasiya = new DataTable();
            tbNasiya.Columns.Add("product_id", typeof(int));
            tbNasiya.Columns.Add("barcode");
            tbNasiya.Columns.Add("Номи");
            tbNasiya.Columns.Add("Нархи");
            tbNasiya.Columns.Add("Насия_микдори");
            tbNasiya.Columns.Add("Умумий_сумма");
            managerNasiya = (CurrencyManager)BindingContext[tbNasiya];
            dbgridNasiya.DataSource = tbNasiya;
            dbgridNasiya.Columns[0].Visible = false;
            dbgridNasiya.Columns[1].Visible = false;
            dbgridNasiya.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            panelNayisa.Enabled = true;
            btnNaqd.Visible = false;
            btnPlastik.Visible = false;
            btnNasiya.Visible = false;
        }
    }
}
