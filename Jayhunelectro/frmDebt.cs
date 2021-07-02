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
    public partial class frmDebt : MetroFramework.Forms.MetroForm
    {
        public frmDebt()
        {
            InitializeComponent();
        }
        DBAccess objDBAccess = new DBAccess();
        public static string JamiSumma = "";
        public static string OlganSana = "";
        public string print = "";
        public string footer = "";
        public int shopID = 0;
        MySqlCommand cmdDebt,cmdShop, cmdDebtor, cmdDebtCart;
        DataTable tbDebtor;
        CurrencyManager managerDebtor;
        private void frmDebt_Load(object sender, EventArgs e)
        {
            string queryDebtor = "select * from debtor";
            tbDebtor = new DataTable();
            objDBAccess.readDatathroughAdapter(queryDebtor, tbDebtor);
            managerDebtor = (CurrencyManager)BindingContext[tbDebtor];
            comboDebitor.DataSource = tbDebtor;
            comboDebitor.DisplayMember = "mijoz_fish";
            comboTel1.DataSource = tbDebtor;
            comboTel1.DisplayMember = "tel_1";
            comboTel2.DataSource = tbDebtor;
            comboTel2.DisplayMember = "tel_2";
            //tbDebtor.Dispose();
            txtJamiSumma.Text = JamiSumma;
            objDBAccess.closeConn();
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


        private void txtTel2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboDebitor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboTel1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(print, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        private void btnBekorQilish_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            comboDebitor.Visible = false;
            comboTel1.Visible = false;
            comboTel2.Visible = false;
            txtFISH.Visible = true;
            txtTel1.Visible = true;
            txtTel2.Visible = true;
            btnNew.Enabled = false;

        }

        private void btnTasdiqlash_Click(object sender, EventArgs e)
        { 
            if (comboDebitor.Visible && comboTel1.Visible && comboTel2.Visible) // Agar debtor tanlangan bo'lsa
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
                cmdDebt = new MySqlCommand("insert into debt (id,debtor_id, shop_id, return_date) values('" + Debt_id + "','"+Debtor_id+"', '"+shopID+"','"+date_now+"' )");
                objDBAccess.executeQuery(cmdDebt);
                cmdDebt.Dispose();

                //cartdebt jadvali bo'sh yoki bo'shmasligini tekshirishimiz kerek
                int cartDebt_id = 0;
                string queryCartDebt = "select * from cartdebt";
                DataTable tbCartDebt = new DataTable();
                objDBAccess.readDatathroughAdapter(queryCartDebt, tbCartDebt);
                if(tbCartDebt.Rows.Count == 0) //Agar bo'sh bo'lsa
                {
                    cartDebt_id = 1;
                    string queryDebtBasket = "select * from cart where shop_id='" + shopID + "'";
                    DataTable tbDebtBasket = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebtBasket, tbDebtBasket); // cart jadvalidan barcha maxsulotlarni olamiz
                    CurrencyManager managerDebtBasket = (CurrencyManager)BindingContext[tbDebtBasket];
                    int Count = managerDebtBasket.Count;
                    managerDebtBasket.Position = 0;
                    string product_id = "", name = "", price = "", quantity = "", total = "", barcode="";
                    for(int i = 0; i<Count; i++) // maxsulotlarni har birini cartdebtga kiritib chiqamiz
                    {
                        string queryBarcode = "select barcode from product where product_id='" + tbDebtBasket.Rows[managerDebtBasket.Position]["product_id"].ToString() + "'";
                        DataTable tbBarcode = new DataTable();
                        objDBAccess.readDatathroughAdapter(queryBarcode, tbBarcode);

                        barcode = tbBarcode.Rows[0]["barcode"].ToString();
                        tbBarcode.Clear();
                        tbBarcode.Dispose();

                        product_id = tbDebtBasket.Rows[managerDebtBasket.Position]["product_id"].ToString();
                        name = tbDebtBasket.Rows[managerDebtBasket.Position]["name"].ToString();
                        price = tbDebtBasket.Rows[managerDebtBasket.Position]["price"].ToString();
                        quantity = tbDebtBasket.Rows[managerDebtBasket.Position]["quantity"].ToString();//
                        if(quantity.IndexOf(',') > -1)
                        {
                            int index = quantity.IndexOf(',');
                            string first_quantity = quantity.Substring(0, index);
                            string last_quantity = quantity.Substring(index + 1);
                            quantity = first_quantity + "." + last_quantity;
                        }
                        total = tbDebtBasket.Rows[managerDebtBasket.Position]["total"].ToString();//
                        if (total.IndexOf(',') > -1)
                        {
                            int index = total.IndexOf(',');
                            string first_total = total.Substring(0, index);
                            string last_total = total.Substring(index + 1);
                            total = first_total + "." + last_total;
                        }
                        if (managerDebtBasket.Position==0)
                        {
                            cmdDebtCart = new MySqlCommand("insert into cartdebt (id,debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                            "values('" + cartDebt_id + "','" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'"+barcode+"')");
                            objDBAccess.executeQuery(cmdDebtCart);
                            cmdDebtCart.Dispose();
                        }
                        else
                        {
                            cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                            "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'"+barcode+"')");
                            objDBAccess.executeQuery(cmdDebtCart);
                            cmdDebtCart.Dispose();
                        }
                        managerDebtBasket.Position++;
                    }
                    tbDebtBasket.Clear();
                    tbDebtBasket.Dispose();
                }


                else //Agar cartdebt bo'sh bo'lmasa
                {
                    string queryDebtBasket = "select * from cart where shop_id='" + shopID + "'";
                    DataTable tbDebtBasket = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebtBasket, tbDebtBasket); // cart jadvalidan barcha maxsulotlarni olamiz
                    CurrencyManager managerDebtBasket = (CurrencyManager)BindingContext[tbDebtBasket];
                    int Count = managerDebtBasket.Count;
                    managerDebtBasket.Position = 0;
                    string product_id = "", name = "", price = "", quantity = "", total = "", barcode="";
                    string  old_givenQuantity = "", old_total = "", old_debtQuantity="", old_debtPrice="";
                    for (int i = 0; i < Count; i++)
                    {
                        string queryBarcode = "select barcode from product where product_id='" + tbDebtBasket.Rows[managerDebtBasket.Position]["product_id"].ToString() + "'";
                        DataTable tbBarcode = new DataTable();
                        objDBAccess.readDatathroughAdapter(queryBarcode, tbBarcode);

                        barcode = tbBarcode.Rows[0]["barcode"].ToString();
                        tbBarcode.Clear();
                        tbBarcode.Dispose();
                        product_id = tbDebtBasket.Rows[managerDebtBasket.Position]["product_id"].ToString();
                        name = tbDebtBasket.Rows[managerDebtBasket.Position]["name"].ToString();
                        price = tbDebtBasket.Rows[managerDebtBasket.Position]["price"].ToString();
                        quantity = tbDebtBasket.Rows[managerDebtBasket.Position]["quantity"].ToString();//
                        if (quantity.IndexOf(',') > -1)
                        {
                            int index = quantity.IndexOf(',');
                            string first_quantity = quantity.Substring(0, index);
                            string last_quantity = quantity.Substring(index + 1);
                            quantity = first_quantity + "." + last_quantity;
                        }

                        total = tbDebtBasket.Rows[managerDebtBasket.Position]["total"].ToString();//
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
                               "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'"+barcode+"')");
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
                                    string first_old_givenQuantity = old_givenQuantity.Substring(0, index);
                                    string last_old_givenQuantity = old_givenQuantity.Substring(index + 1);
                                    old_givenQuantity = first_old_givenQuantity + "." + last_old_givenQuantity;
                                }

                                old_total = tbCartDebtProduct.Rows[0]["total"].ToString();  // Avvalgi umumiy summa//
                                if (old_total.IndexOf(',') > -1)
                                {
                                    int index = old_total.IndexOf(',');
                                    string first_old_total = old_total.Substring(0, index);
                                    string last_old_total = old_total.Substring(index + 1);
                                    old_total = first_old_total + "." + last_old_total;
                                }

                                old_debtQuantity = tbCartDebtProduct.Rows[0]["debt_quantity"].ToString();  // Avvalgi qolgan miqdor//
                                if (old_debtQuantity.IndexOf(',') > -1)
                                {
                                    int index = old_debtQuantity.IndexOf(',');
                                    string first_old_debtQuantity = old_debtQuantity.Substring(0, index);
                                    string last_old_debtQuantity = old_debtQuantity.Substring(index + 1);
                                    old_debtQuantity = first_old_debtQuantity + "." + last_old_debtQuantity;
                                }

                                old_debtPrice = tbCartDebtProduct.Rows[0]["debt_price"].ToString();  // Avvalgi qolgan summa//
                                if (old_debtPrice.IndexOf(',') > -1)
                                {
                                    int index = old_debtPrice.IndexOf(',');
                                    string first_old_debtPrice = old_debtPrice.Substring(0, index);
                                    string last_old_debtPrice = old_debtPrice.Substring(index + 1);
                                    old_debtPrice = first_old_debtPrice + "." + last_old_debtPrice;
                                }

                                double Dold_givenQuantity = double.Parse(old_givenQuantity, CultureInfo.InvariantCulture);
                                double Dquantity = double.Parse(quantity, CultureInfo.InvariantCulture);
                                double result_givenQuantity = Dold_givenQuantity + Dquantity;
                                string str_result_givenQuantity = result_givenQuantity.ToString();
                                if (str_result_givenQuantity.IndexOf(',') > -1)
                                {
                                    int index = str_result_givenQuantity.IndexOf(',');
                                    string first_str_result_givenQuantity = str_result_givenQuantity.Substring(0, index);
                                    string last_str_result_givenQuantity = str_result_givenQuantity.Substring(index + 1);
                                    str_result_givenQuantity = first_str_result_givenQuantity + "." + last_str_result_givenQuantity;
                                }

                                double Dold_total = double.Parse(old_total, CultureInfo.InvariantCulture);
                                double Dtotal = double.Parse(total, CultureInfo.InvariantCulture);
                                double result_total = Dold_total + Dtotal;
                                string str_result_total = result_total.ToString();
                                if (str_result_total.IndexOf(',') > -1)
                                {
                                    int index = str_result_total.IndexOf(',');
                                    string first_str_result_total = str_result_total.Substring(0, index);
                                    string last_str_result_total = str_result_total.Substring(index + 1);
                                    str_result_total = first_str_result_total + "." + last_str_result_total;
                                }

                                double Dold_debtQuantity = double.Parse(old_debtQuantity, CultureInfo.InvariantCulture);
                                double result_debtQuantity = Dold_debtQuantity + Dquantity;
                                string str_result_debtQuantity = result_debtQuantity.ToString();
                                if (str_result_debtQuantity.IndexOf(',') > -1)
                                {
                                    int index = str_result_debtQuantity.IndexOf(',');
                                    string first_str_result_debtQuantity = str_result_debtQuantity.Substring(0, index);
                                    string last_str_result_debtQuantity = str_result_debtQuantity.Substring(index + 1);
                                    str_result_debtQuantity = first_str_result_debtQuantity + "." + last_str_result_debtQuantity;
                                }

                                double Dold_debtPrice = double.Parse(old_debtPrice, CultureInfo.InvariantCulture);
                                double result_debtPrice = Dold_debtPrice + Dtotal;
                                string str_result_debtPrice = result_debtPrice.ToString();
                                if (str_result_debtPrice.IndexOf(',') > -1)
                                {
                                    int index = str_result_debtPrice.IndexOf(',');
                                    string first_str_result_debtPrice = str_result_debtPrice.Substring(0, index);
                                    string last_str_result_debtPrice = str_result_debtPrice.Substring(index + 1);
                                    str_result_debtPrice = first_str_result_debtPrice + "." + last_str_result_debtPrice;
                                }

                                cmdDebtCart = new MySqlCommand("update cartdebt set given_quantity='"+str_result_givenQuantity+"', total='"+str_result_total+"', debt_quantity='"+str_result_debtQuantity+"', debt_price='"+str_result_debtPrice+"' where product_id='"+product_id+"' and debtor_id='"+Debtor_id+"'");
                                objDBAccess.executeQuery(cmdDebtCart);
                                cmdDebtCart.Dispose();
                            }
                        }
                        else  // Agar ushbu maxsulotdan avval olinmagan bo'lsa
                        {
                            cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                              "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'"+barcode+"')");
                            objDBAccess.executeQuery(cmdDebtCart);
                            cmdDebtCart.Dispose();
                        }
                        tbCartDebtProduct.Clear();
                        tbCartDebtProduct.Dispose();
                        managerDebtBasket.Position++;
                    }
                    tbDebtBasket.Clear();
                    tbDebtBasket.Dispose();
                }
                tbCartDebt.Clear();
                tbCartDebt.Dispose();

                //shopda summa update qilinadi
                string strJamiSumma = txtJamiSumma.Text;
                if (strJamiSumma.IndexOf(',') > -1)
                {
                    int index = strJamiSumma.IndexOf(',');
                    string first_strJamiSumma = strJamiSumma.Substring(0, index);
                    string last_strJamiSumma = strJamiSumma.Substring(index + 1);
                    strJamiSumma = first_strJamiSumma + "." + last_strJamiSumma;
                }
                cmdShop = new MySqlCommand("update shop set nasiya='"+strJamiSumma+"',jamisumma='" + strJamiSumma + "', debt=1 where id='" + shopID + "'");
                objDBAccess.executeQuery(cmdShop);
                cmdShop.Dispose();

                //umumiy_qarz debtor jadvaliga yozilishi kerek
                string old_umumiyQarz = tbDebtor.Rows[managerDebtor.Position]["umumiy_qarz"].ToString();
                double Dold_umumiyQarz = double.Parse(old_umumiyQarz, CultureInfo.InvariantCulture);
                double DJamiSumma = double.Parse(strJamiSumma, CultureInfo.InvariantCulture);
                double result_umumiyQarz = Dold_umumiyQarz + DJamiSumma;
                string str_result_umumiyQarz = result_umumiyQarz.ToString();
                if (str_result_umumiyQarz.IndexOf(',') > -1)
                {
                    int index = str_result_umumiyQarz.IndexOf(',');
                    string first_str_result_umumiyQarz = str_result_umumiyQarz.Substring(0, index);
                    string last_str_result_umumiyQarz = str_result_umumiyQarz.Substring(index + 1);
                    str_result_umumiyQarz = first_str_result_umumiyQarz + "." + last_str_result_umumiyQarz;
                }
                cmdDebtor = new MySqlCommand("update debtor set umumiy_qarz='" + str_result_umumiyQarz + "' where id='" + Debtor_id + "'");
                objDBAccess.executeQuery(cmdDebtor);
                cmdDebtor.Dispose();
                
                MessageBox.Show("Махсулот насияга муваффакиятли бэрилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                print += "Насия : " + strJamiSumma + "\n";
                print += footer;
                printDocument1.Print();
                CreateBarcode(shopID.ToString());
                printBarCode();
                Close();
            }
            else if(txtFISH.Visible && txtTel1.Visible && txtTel2.Visible) // Agar debtor tanlanmagan bo'lsa, yangi bo'lsa 
            {

                if (txtFISH.Text=="" || txtTel1.Text=="")
                {
                    MessageBox.Show("Малумотлар тўлик эмас, Илтомос тэкшириб кўринг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //yangi debtorni debtor jadvaliga qo'shamiz + debtor jadvali bo'sh yoki bo'shmasligini tekshiramiz
                string strJamiSumma = txtJamiSumma.Text;
                if (strJamiSumma.IndexOf(',') > -1)
                {
                    int index = strJamiSumma.IndexOf(',');
                    string first_strJamiSumma = strJamiSumma.Substring(0, index);
                    string last_strJamiSumma = strJamiSumma.Substring(index + 1);
                    strJamiSumma = first_strJamiSumma + "." + last_strJamiSumma;
                }

                string Debtor_id="";
                if (tbDebtor.Rows.Count == 0) // Agar bo'sh bo'lsa
                {
                    cmdDebtor = new MySqlCommand("insert into debtor (id, mijoz_fish, tel_1, tel_2, umumiy_qarz, difference, status_difference) values(1,'" + txtFISH.Text + "', '" + txtTel1.Text + "', '" + txtTel2.Text + "', '" + strJamiSumma + "',0,0)");
                    objDBAccess.executeQuery(cmdDebtor);
                    cmdDebtor.Dispose();
                    Debtor_id = "1";
                }
                else if(tbDebtor.Rows.Count > 0) // Agar bo'sh bo'lmasa 
                {
                    string queryDebtor_id = "select * from debtor order by id desc limit 1";
                    DataTable tbDebtor_id = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebtor_id, tbDebtor_id);
                    Debtor_id = tbDebtor_id.Rows[0]["id"].ToString();
                    int debtor = int.Parse(Debtor_id) + 1;
                    Debtor_id = debtor.ToString();
                    tbDebtor_id.Clear();
                    tbDebtor_id.Dispose();
                    cmdDebtor = new MySqlCommand("insert into debtor (id,mijoz_fish, tel_1, tel_2, umumiy_qarz, difference, status_difference) values('" + Debtor_id+"','" + txtFISH.Text + "', '" + txtTel1.Text + "', '" + txtTel2.Text + "', '" + strJamiSumma + "',0,0)");
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
                cmdDebt = new MySqlCommand("insert into debt (id,debtor_id, shop_id, return_date) values('" + Debt_id + "','" + Debtor_id + "', '" + shopID + "','" + date_now + "' )");
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
                    string queryDebtBasket = "select * from cart where shop_id='" + shopID + "'";
                    DataTable tbDebtBasket = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebtBasket, tbDebtBasket); // cart jadvalidan barcha maxsulotlarni olamiz
                    CurrencyManager managerDebtBasket = (CurrencyManager)BindingContext[tbDebtBasket];
                    int Count = managerDebtBasket.Count;
                    managerDebtBasket.Position = 0;
                    string product_id = "", name = "", price = "", quantity = "", total = "", barcode="";
                    for (int i = 0; i < Count; i++) // maxsulotlarni har birini cartdebtga kiritib chiqamiz
                    {
                        string queryBarcode = "select barcode from product where product_id='" + tbDebtBasket.Rows[managerDebtBasket.Position]["product_id"].ToString() + "'";
                        DataTable tbBarcode = new DataTable();
                        objDBAccess.readDatathroughAdapter(queryBarcode, tbBarcode);

                        barcode = tbBarcode.Rows[0]["barcode"].ToString();
                        tbBarcode.Clear();
                        tbBarcode.Dispose();
                        product_id = tbDebtBasket.Rows[managerDebtBasket.Position]["product_id"].ToString();
                        name = tbDebtBasket.Rows[managerDebtBasket.Position]["name"].ToString();
                        price = tbDebtBasket.Rows[managerDebtBasket.Position]["price"].ToString();
                        quantity = tbDebtBasket.Rows[managerDebtBasket.Position]["quantity"].ToString(); //
                        if (quantity.IndexOf(',') > -1)
                        {
                            int index = quantity.IndexOf(',');
                            string first_quantity = quantity.Substring(0, index);
                            string last_quantity = quantity.Substring(index + 1);     
                            quantity = first_quantity + "." + last_quantity;
                        }

                        total = tbDebtBasket.Rows[managerDebtBasket.Position]["total"].ToString(); //
                        if (total.IndexOf(',') > -1)
                        {
                            int index = total.IndexOf(',');
                            string first_total = total.Substring(0, index);
                            string last_total = total.Substring(index + 1);
                            total = first_total + "." + last_total;
                        }

                        if (managerDebtBasket.Position == 0)
                        {
                            cmdDebtCart = new MySqlCommand("insert into cartdebt (id,debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                            "values('" + cartDebt_id + "','" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'"+barcode+"')");
                            objDBAccess.executeQuery(cmdDebtCart);
                            cmdDebtCart.Dispose();
                        }
                        else
                        {
                            cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                            "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'"+barcode+"')");
                            objDBAccess.executeQuery(cmdDebtCart);
                            cmdDebtCart.Dispose();
                        }
                        managerDebtBasket.Position++;
                    }
                    tbDebtBasket.Clear();
                    tbDebtBasket.Dispose();
                }
                else // Agar bo'sh bo'lmasa cartdebt_id+=1 bo'ladi
                {
                    string queryDebtBasket = "select * from cart where shop_id='" + shopID + "'";
                    DataTable tbDebtBasket = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebtBasket, tbDebtBasket); // cart jadvalidan barcha maxsulotlarni olamiz
                    CurrencyManager managerDebtBasket = (CurrencyManager)BindingContext[tbDebtBasket];
                    int Count = managerDebtBasket.Count;
                    managerDebtBasket.Position = 0;
                    string product_id = "", name = "", price = "", quantity = "", total = "", barcode="";
                    for (int i = 0; i < Count; i++) // maxsulotlarni har birini cartdebtga kiritib chiqamiz
                    {
                        string queryBarcode = "select barcode from product where product_id='" + tbDebtBasket.Rows[managerDebtBasket.Position]["product_id"].ToString() + "'";
                        DataTable tbBarcode = new DataTable();
                        objDBAccess.readDatathroughAdapter(queryBarcode, tbBarcode);

                        barcode = tbBarcode.Rows[0]["barcode"].ToString();

                        product_id = tbDebtBasket.Rows[managerDebtBasket.Position]["product_id"].ToString();
                        name = tbDebtBasket.Rows[managerDebtBasket.Position]["name"].ToString();
                        price = tbDebtBasket.Rows[managerDebtBasket.Position]["price"].ToString();
                        quantity = tbDebtBasket.Rows[managerDebtBasket.Position]["quantity"].ToString();//
                        if (quantity.IndexOf(',') > -1)
                        {
                            int index = quantity.IndexOf(',');
                            string first_quantity = quantity.Substring(0, index);
                            string last_quantity = quantity.Substring(index + 1);
                            quantity = first_quantity + "." + last_quantity;
                        }

                        total = tbDebtBasket.Rows[managerDebtBasket.Position]["total"].ToString();//
                        if (total.IndexOf(',') > -1)
                        {
                            int index = total.IndexOf(',');
                            string first_total = total.Substring(0, index);
                            string last_total = total.Substring(index + 1);
                            total = first_total + "." + last_total;
                        }

                        cmdDebtCart = new MySqlCommand("insert into cartdebt (debtor_id,product_id,name,price,given_quantity,total,return_quantity,return_price,debt_quantity,debt_price,difference,barcode) " +
                        "values('" + Debtor_id + "','" + product_id + "','" + name + "','" + price + "','" + quantity + "','" + total + "',0,0,'" + quantity + "','" + total + "',0,'"+barcode+"')");
                        objDBAccess.executeQuery(cmdDebtCart);
                        cmdDebtCart.Dispose();
                        managerDebtBasket.Position++;
                    }
                    tbDebtBasket.Clear();
                    tbDebtBasket.Dispose();
                }
                tbCartDebt.Clear();
                tbCartDebt.Dispose();
                cmdShop = new MySqlCommand("update shop set nasiya='"+ strJamiSumma + "',jamisumma='" + strJamiSumma + "',debt=1 where id='" + shopID + "'");
                objDBAccess.executeQuery(cmdShop);
                cmdShop.Dispose();
                MessageBox.Show("Махсулот насияга муваффакиятли бэрилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                print += "Насия : " + strJamiSumma + "\n";
                print += footer;
                printDocument1.Print();
                CreateBarcode(shopID.ToString());
                printBarCode();
                Close();
            }
        }
    }
}
