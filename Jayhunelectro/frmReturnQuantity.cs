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
    public partial class frmReturnQuantity : MetroFramework.Forms.MetroForm
    {
        public frmReturnQuantity()
        {
            InitializeComponent();
        }
        //Tovarlarni qaytarib olish uchun
        public string shop_id = "", product_id = "", old_price = "", current_price = "", sold_quantity="", name="", total="", barcode="";
        public bool sold = false, debt = false;

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmReturnQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                iconButton2_Click(sender, e);
            }
        }

        public string debtor_id = "", umumiy_qarz="", debt_quantity = "", debt_price = "", given_quantity = "", cartdebt_total = "", cartdebt_id = "";
        public string diff=""; // Cartdebt ma'lumotlari uchun
        
        public static MySqlCommand cmdShop, cmdCart, cmdProduct, cmdReturnProduct, cmdDebtor, cmdCartDebt;
        DBAccess objDBAccess = new DBAccess();
        public void iconButton2_Click(object sender, EventArgs e)
        {
            if (txtQaytarishQuantity.Text == "") return;
            

            //Sotilgan tovarlar qaytib kelgan bo'lsa
            if (sold == true && debt == false)
            {
                if (txtQaytarishQuantity.Text.IndexOf(',') > -1)
                {
                    MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQaytarishQuantity.Clear();
                    return;
                }
                string str_sotilganQuantity = txtSotilganQuantity.Text;
                if (str_sotilganQuantity.IndexOf(',') > -1)
                {
                    int index = str_sotilganQuantity.IndexOf(',');
                    string first_str_sotilganQuantity = str_sotilganQuantity.Substring(0, index);
                    string last_str_sotilganQuantity = str_sotilganQuantity.Substring(index + 1);
                    str_sotilganQuantity = first_str_sotilganQuantity + "." + last_str_sotilganQuantity;
                }
                if (double.Parse(txtQaytarishQuantity.Text, CultureInfo.InvariantCulture) > double.Parse(str_sotilganQuantity, CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Кайтариш микдори кўп киритилди!\nСотилган микдор '" + sold_quantity + "'", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double quantityQaytarish = double.Parse(txtQaytarishQuantity.Text, CultureInfo.InvariantCulture);
                double dOld_price = double.Parse(txtOld_price.Text, CultureInfo.InvariantCulture);
                double total = quantityQaytarish * dOld_price;
                txtQaytarishSumma.Text = total.ToString();
                string summa = txtQaytarishSumma.Text; //
                if(summa.IndexOf(',') > -1)
                {
                    int index = summa.IndexOf(',');
                    string first_summa = summa.Substring(0, index);
                    string last_summa = summa.Substring(index + 1);
                    summa = first_summa + "." + last_summa;
                }
                //Product jadvalidan qaytarilayotgan maxsulot ma'lumotlarini olamiz
                DataTable tbProduct = new DataTable();
                string queryProduct = "select * from product where product_id='" + product_id + "'";
                objDBAccess.readDatathroughAdapter(queryProduct, tbProduct);
                string quantityProduct = tbProduct.Rows[0]["quantity"].ToString(); //
                if(quantityProduct.IndexOf(',') > -1)
                {
                    int index = quantityProduct.IndexOf(',');
                    string first_quantityProduct = quantityProduct.Substring(0, index);
                    string last_quantityProduct = quantityProduct.Substring(index + 1);
                    quantityProduct = first_quantityProduct + "." + last_quantityProduct;
                }
                current_price = tbProduct.Rows[0]["price"].ToString();
                barcode = tbProduct.Rows[0]["barcode"].ToString();
                tbProduct.Clear();
                tbProduct.Dispose();
                double DquantityProduct = double.Parse(quantityProduct, CultureInfo.InvariantCulture);
                double DQaytarishQuantity = double.Parse(txtQaytarishQuantity.Text, CultureInfo.InvariantCulture);
                double result_quantityProduct = DquantityProduct + DQaytarishQuantity;
                string str_result_quantityProduct = result_quantityProduct.ToString(); //
                if (str_result_quantityProduct.IndexOf(',') > -1)
                {
                    int index = str_result_quantityProduct.IndexOf(',');
                    string first_str_result_quantityProduct = str_result_quantityProduct.Substring(0, index);
                    string last_str_result_quantityProduct = str_result_quantityProduct.Substring(index + 1);
                    str_result_quantityProduct = first_str_result_quantityProduct + "." + last_str_result_quantityProduct;
                }

                //returnproduct jadvali uchun difference
                double Dcurrent_price = double.Parse(current_price, CultureInfo.InvariantCulture);
                double Dold_price = double.Parse(old_price, CultureInfo.InvariantCulture);
                double difference = (Dcurrent_price - Dold_price) * quantityQaytarish;
                string str_difference = difference.ToString(); //
                if (str_difference.IndexOf(',') > -1)
                {
                    int index = str_difference.IndexOf(',');
                    string first_str_difference = str_difference.Substring(0, index);
                    string last_str_difference = str_difference.Substring(index + 1);
                    str_difference = first_str_difference + "." + last_str_difference;
                }

                //Returnproduct jadvali bo'sh yoki bo'shmasligini tekshirib olamiz
                DataTable tbReturnProduct_idIs_Null = new DataTable();
                string queryReturnProduct_idIs_Null = "select id from returnproduct order by id desc limit 1";
                objDBAccess.readDatathroughAdapter(queryReturnProduct_idIs_Null, tbReturnProduct_idIs_Null);
                int returnProduct_id = 0;
                if (tbReturnProduct_idIs_Null.Rows.Count > 0) // Agar bo'sh bo'lmasa returnProduct_id +=1 bo'ladi
                { returnProduct_id = int.Parse(tbReturnProduct_idIs_Null.Rows[0]["id"].ToString()) + 1; }
                else { returnProduct_id = 1; }  // Agar bo'sh bo'lsa returnProduct_id = 1 bo'ladi
                tbReturnProduct_idIs_Null.Clear();
                tbReturnProduct_idIs_Null.Dispose();

                // Productdan quantity miqdoriga qo'shib qo'yamiz
                cmdProduct = new MySqlCommand("update product set quantity='" + str_result_quantityProduct + "' where product_id='" + product_id + "'");
                objDBAccess.executeQuery(cmdProduct);

                // return productga (id, shop_id, product_id, return_quantity, summa, date, difference) yoziladi
                DateTime dt_now = DateTime.Now;
                cmdReturnProduct = new MySqlCommand("insert into returnproduct (id,shop_id,product_id, return_quantity, summa, sold, debt, date, difference,status_server,barcode) " +
                    "values('" + returnProduct_id + "', '" + shop_id + "', '" + product_id + "', '" + txtQaytarishQuantity.Text + "', '" + summa + "',1,0, '" + dt_now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + str_difference + "',0,'"+barcode+"')");
                objDBAccess.executeQuery(cmdReturnProduct);

                cmdProduct.Dispose();
                cmdReturnProduct.Dispose();

                MessageBox.Show("Товар муваффакиятли кайтариб олинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // SoldList soldList = new SoldList();
                //soldList.Refresh();
                Close();
            }
            //Nasiya qaytib kelgan bo'lsa
            if(debt == true && sold == false) //shu yer
            {
                if (txtQaytarishQuantity.Text.IndexOf(',') > -1)
                {
                    MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQaytarishQuantity.Clear();
                    return;
                }

                string str_sotilganQuantity = txtSotilganQuantity.Text;
                if (str_sotilganQuantity.IndexOf(',') > -1)
                {
                    int index = str_sotilganQuantity.IndexOf(',');
                    string first_str_sotilganQuantity = str_sotilganQuantity.Substring(0, index);
                    string last_str_sotilganQuantity = str_sotilganQuantity.Substring(index + 1);
                    str_sotilganQuantity = first_str_sotilganQuantity + "." + last_str_sotilganQuantity;
                }

                if (double.Parse(txtQaytarishQuantity.Text, CultureInfo.InvariantCulture) > double.Parse(str_sotilganQuantity, CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Кайтариш микдори кўп киритилди!\nКолган микдор '" + debt_quantity + "'", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double quantityQaytarish = double.Parse(txtQaytarishQuantity.Text, CultureInfo.InvariantCulture);
                double dOld_price = double.Parse(txtOld_price.Text, CultureInfo.InvariantCulture);
                double total = quantityQaytarish * dOld_price;
                txtQaytarishSumma.Text = total.ToString();
                string summa = txtQaytarishSumma.Text;
                if (summa.IndexOf(',') > -1)
                {
                    int index = summa.IndexOf(',');
                    string first_summa = summa.Substring(0, index);
                    string last_summa = summa.Substring(index + 1);
                    summa = first_summa + "." + last_summa;
                }

                //Product jadvalidan qaytarilayotgan maxsulot ma'lumotlarini olamiz
                DataTable tbProduct = new DataTable();
                string queryProduct = "select * from product where product_id='" + product_id + "'";
                objDBAccess.readDatathroughAdapter(queryProduct, tbProduct);
                string quantityProduct = tbProduct.Rows[0]["quantity"].ToString();//
                if (quantityProduct.IndexOf(',') > -1)
                {
                    int index = quantityProduct.IndexOf(',');
                    string first_quantityProduct = quantityProduct.Substring(0, index);
                    string last_quantityProduct = quantityProduct.Substring(index + 1);
                    quantityProduct = first_quantityProduct + "." + last_quantityProduct;
                }

                current_price = tbProduct.Rows[0]["price"].ToString();
                barcode = tbProduct.Rows[0]["barcode"].ToString();
                tbProduct.Clear();
                tbProduct.Dispose();

                double DquantityProduct = double.Parse(quantityProduct, CultureInfo.InvariantCulture);
                double DQaytarishQuantity = double.Parse(txtQaytarishQuantity.Text, CultureInfo.InvariantCulture);
                double result_quantityProduct = DquantityProduct + DQaytarishQuantity;
                string str_result_quantityProduct = result_quantityProduct.ToString(); //
                if (str_result_quantityProduct.IndexOf(',') > -1)
                {
                    int index = str_result_quantityProduct.IndexOf(',');
                    string first_str_result_quantityProduct = str_result_quantityProduct.Substring(0, index);
                    string last_str_result_quantityProduct = str_result_quantityProduct.Substring(index + 1);
                    str_result_quantityProduct = first_str_result_quantityProduct + "." + last_str_result_quantityProduct;
                }

                //returnproduct jadvali uchun difference
                double Dcurrent_price = double.Parse(current_price, CultureInfo.InvariantCulture);
                double Dold_price = double.Parse(old_price, CultureInfo.InvariantCulture);
                double difference = (Dcurrent_price - Dold_price) * quantityQaytarish;
                string str_difference = difference.ToString(); //
                if (str_difference.IndexOf(',') > -1)
                {
                    int index = str_difference.IndexOf(',');
                    string first_str_difference = str_difference.Substring(0, index);
                    string last_str_difference = str_difference.Substring(index + 1);
                    str_difference = first_str_difference + "." + last_str_difference;
                }

                //Returnproduct jadvali bo'sh yoki bo'shmasligini tekshirib olamiz
                DataTable tbReturnProduct_idIs_Null = new DataTable();
                string queryReturnProduct_idIs_Null = "select id from returnproduct order by id desc limit 1";
                objDBAccess.readDatathroughAdapter(queryReturnProduct_idIs_Null, tbReturnProduct_idIs_Null);
                int returnProduct_id = 0;
                if (tbReturnProduct_idIs_Null.Rows.Count > 0) // Agar bo'sh bo'lmasa returnProduct_id +=1 bo'ladi
                { returnProduct_id = int.Parse(tbReturnProduct_idIs_Null.Rows[0]["id"].ToString()) + 1; }
                else { returnProduct_id = 1; }  // Agar bo'sh bo'lsa returnProduct_id = 1 bo'ladi
                tbReturnProduct_idIs_Null.Clear();
                tbReturnProduct_idIs_Null.Dispose();

                // Productdan quantity miqdoriga qo'shib qo'yamiz
                cmdProduct = new MySqlCommand("update product set quantity='" + str_result_quantityProduct + "' where product_id='" + product_id + "'");
                objDBAccess.executeQuery(cmdProduct);

                // return productga (id, shop_id, product_id, return_quantity, summa, date, difference) yoziladi
                DateTime dt_now = DateTime.Now;
                cmdReturnProduct = new MySqlCommand("insert into returnproduct (id,shop_id,product_id, return_quantity, summa, sold, debt, date, difference,status_server,barcode) " +
                    "values('" + returnProduct_id + "', '" + shop_id + "', '" + product_id + "', '" + txtQaytarishQuantity.Text + "', '" + summa + "',0,1, '" + dt_now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + str_difference + "',0,'"+barcode+"')");
                objDBAccess.executeQuery(cmdReturnProduct);

                cmdProduct.Dispose();
                cmdReturnProduct.Dispose();

                //Debtor jadvalidan debtorni umumiy_qarzini kamaytiramiz
                double Dumumiy_qarz = double.Parse(umumiy_qarz, CultureInfo.InvariantCulture);
                double result_umumiyQarz = Dumumiy_qarz - (Dcurrent_price * DQaytarishQuantity);
                string str_result_umumiyQarz = result_umumiyQarz.ToString();
                if (str_result_umumiyQarz.IndexOf(',') > -1)
                {
                    int index = str_result_umumiyQarz.IndexOf(',');
                    string first_str_result_umumiyQarz = str_result_umumiyQarz.Substring(0, index);
                    string last_str_result_umumiyQarz = str_result_umumiyQarz.Substring(index + 1);
                    str_result_umumiyQarz = first_str_result_umumiyQarz + "." + last_str_result_umumiyQarz;
                }
                cmdDebtor = new MySqlCommand("update debtor set umumiy_qarz='"+ str_result_umumiyQarz + "' where id='"+debtor_id+"'");
                objDBAccess.executeQuery(cmdDebtor);

                //Cartdebt jadvalidan given_quantity, total, debt_quantity, debt_price, difference larni kamaytiramiz

                if(given_quantity.IndexOf(',') > -1)
                {
                    int index = given_quantity.IndexOf(',');
                    string first_given_quantity = given_quantity.Substring(0, index);
                    string last_given_quantity = given_quantity.Substring(index + 1);
                    given_quantity = first_given_quantity + "." + last_given_quantity;
                }
                double Dgiven_quantity = double.Parse(given_quantity, CultureInfo.InvariantCulture);
                double result_givenQuantity = Dgiven_quantity - DQaytarishQuantity;
                string str_result_givenQuantity = result_givenQuantity.ToString();
                if (str_result_givenQuantity.IndexOf(',') > -1)
                {
                    int index = str_result_givenQuantity.IndexOf(',');
                    string first_str_result_givenQuantity = str_result_givenQuantity.Substring(0, index);
                    string last_str_result_givenQuantity = str_result_givenQuantity.Substring(index + 1);
                    str_result_givenQuantity = first_str_result_givenQuantity + "." + last_str_result_givenQuantity;
                }

                double Dcartdebt_total = double.Parse(cartdebt_total, CultureInfo.InvariantCulture);
                double result_total = Dcartdebt_total - (DQaytarishQuantity * Dold_price);
                string str_result_total = result_total.ToString();
                if (str_result_total.IndexOf(',') > -1)
                {
                    int index = str_result_total.IndexOf(',');
                    string first_str_result_total = str_result_total.Substring(0, index);
                    string last_str_result_total = str_result_total.Substring(index + 1);
                    str_result_total = first_str_result_total + "." + last_str_result_total;
                }

                if (debt_quantity.IndexOf(',') > -1)
                {
                    int index = debt_quantity.IndexOf(',');
                    string first_debt_quantity = debt_quantity.Substring(0, index);
                    string last_debt_quantity = debt_quantity.Substring(index + 1);
                    debt_quantity = first_debt_quantity + "." + last_debt_quantity;
                }
                double Ddebt_quantity = double.Parse(debt_quantity, CultureInfo.InvariantCulture);//
                double result_debtQuantity = Ddebt_quantity - DQaytarishQuantity;
                string str_result_debtQuantity = result_debtQuantity.ToString();
                if (str_result_debtQuantity.IndexOf(',') > -1)
                {
                    int index = str_result_debtQuantity.IndexOf(',');
                    string first_str_result_debtQuantity = str_result_debtQuantity.Substring(0, index);
                    string last_str_result_debtQuantity = str_result_debtQuantity.Substring(index + 1);
                    str_result_debtQuantity = first_str_result_debtQuantity + "." + last_str_result_debtQuantity;
                }

                if (debt_price.IndexOf(',') > -1)
                {
                    int index = debt_price.IndexOf(',');
                    string first_debt_price = debt_price.Substring(0, index);
                    string last_debt_price = debt_price.Substring(index + 1);
                    debt_price = first_debt_price + "." + last_debt_price;
                }
                double Ddebt_price = double.Parse(debt_price, CultureInfo.InvariantCulture);//
                double result_debtPrice = Ddebt_price - (DQaytarishQuantity * Dcurrent_price);
                string str_result_debtPrice = result_debtPrice.ToString();
                if (str_result_debtPrice.IndexOf(',') > -1)
                {
                    int index = str_result_debtPrice.IndexOf(',');
                    string first_str_result_debtPrice = str_result_debtPrice.Substring(0, index);
                    string last_str_result_debtPrice = str_result_debtPrice.Substring(index + 1);
                    str_result_debtPrice = first_str_result_debtPrice + "." + last_str_result_debtPrice;
                }

                if (diff.IndexOf(',') > -1)
                {
                    int index = diff.IndexOf(',');
                    string first_diff = diff.Substring(0, index);
                    string last_diff = diff.Substring(index + 1);
                    diff = first_diff + "." + last_diff;
                }
                double Ddiff = double.Parse(diff, CultureInfo.InvariantCulture);//
                double result_difference = Ddiff - difference;
                string str_result_difference = result_difference.ToString();
                if (str_result_difference.IndexOf(',') > -1)
                {
                    int index = str_result_difference.IndexOf(',');
                    string first_str_result_difference = str_result_difference.Substring(0, index);
                    string last_str_result_difference = str_result_difference.Substring(index + 1);
                    str_result_difference = first_str_result_difference + "." + last_str_result_difference;
                }

                cmdCartDebt = new MySqlCommand("update cartdebt set given_quantity='" + str_result_givenQuantity + "', total='" + str_result_total + "', debt_quantity='" + str_result_debtQuantity + "', debt_price='" + str_result_debtPrice + "', difference='" + str_result_difference + "' where id='" + cartdebt_id + "' and debtor_id='" + debtor_id + "' and product_id='" + product_id + "'");
                objDBAccess.executeQuery(cmdCartDebt);

                cmdDebtor.Dispose();
                cmdCartDebt.Dispose();

                frmDebtList debtList = new frmDebtList();
                debtList.Refresh();
                MessageBox.Show("Товар муваффакиятли кайтариб олинди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void frmReturnQuantity_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            if (sold == true && debt == false)
            {
                txtProduct.Text = name;
                txtOld_price.Text = old_price;
                txtSotilganQuantity.Text = sold_quantity;
                lblMiqdor.Text = "Сотилган микдор :";
            }
            if(debt == true && sold == false)
            {
                txtProduct.Text = name;
                txtOld_price.Text = old_price;
                txtSotilganQuantity.Text = debt_quantity;
                lblMiqdor.Text = "Колган микдор :";
            }
        }
    }
}
