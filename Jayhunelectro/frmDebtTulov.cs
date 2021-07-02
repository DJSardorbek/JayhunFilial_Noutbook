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
    public partial class frmDebtTulov : MetroFramework.Forms.MetroForm
    {
        public frmDebtTulov()
        {
            InitializeComponent();
        }
        public string name = "", price = "", qolgan_miqdor = "", debtor_id="", product_id="", umumiy_qarz="";

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDebtTulov_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                btnConfirm_Click(sender, e);
            }
            
        }

        private void txtEnterQuantity_TextChanged(object sender, EventArgs e)
        {
            /*if (txtEnterQuantity.Text != "")
            {
                double parsedValue;
                if (!double.TryParse(txtEnterQuantity.Text, out parsedValue))
                {
                    txtEnterQuantity.Clear();
                    return;
                }
                double quantity = double.Parse(txtEnterQuantity.Text, CultureInfo.InvariantCulture);
                double total = quantity * double.Parse(txtprice.Text, CultureInfo.InvariantCulture);
                txtTotal.Text = total.ToString();
            }

            else
            {
                txtTotal.Text = "";
            }*/
        }

        public static MySqlCommand cmdDebtCart, cmdDebtor, cmdPayhistory;
        DBAccess objDBAccess = new DBAccess();
        public void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtEnterQuantity.Text.IndexOf(',') > -1)
            {
                MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEnterQuantity.Clear();
                return;
            }
            if(qolgan_miqdor.IndexOf(',') > -1)
            {
                int index = qolgan_miqdor.IndexOf(',');
                string first_qolgan_miqdor = qolgan_miqdor.Substring(0, index);
                string last_qolgan_miqdor = qolgan_miqdor.Substring(index + 1);
                qolgan_miqdor = first_qolgan_miqdor + "." + last_qolgan_miqdor;
            }
            double DEnterQuantity = double.Parse(txtEnterQuantity.Text, CultureInfo.InvariantCulture);
            double Dprice = double.Parse(txtprice.Text, CultureInfo.InvariantCulture);
            double total = DEnterQuantity * Dprice;
            txtTotal.Text = total.ToString();
            string str_total = txtTotal.Text;
            if (str_total.IndexOf(',') > -1)
            {
                int index = str_total.IndexOf(',');
                string first_str_total = str_total.Substring(0, index);
                string last_str_total = str_total.Substring(index + 1);
                str_total = first_str_total + "." + last_str_total;
            }

            double Dqolgan_miqdor = double.Parse(qolgan_miqdor, CultureInfo.InvariantCulture);

            if (Dqolgan_miqdor * Dprice < total)
            {
                MessageBox.Show("Тўлов микдори ортикча киритилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Cartdebt jadvaliga natijaviy to'langan_miqdor, to'langan_summa, qolgan_summa larni update qilib qo'yamiz
            string queryCartDebt = "select * from cartdebt where product_id='" + product_id + "' and debtor_id='"+debtor_id+"'";
            DataTable tbCartProduct = new DataTable();
            objDBAccess.readDatathroughAdapter(queryCartDebt, tbCartProduct);
            string old_returnQuantity = tbCartProduct.Rows[0]["return_quantity"].ToString(); //eski to'langan miqdorni olamiz//
            if (old_returnQuantity.IndexOf(',') > -1)
            {
                int index = old_returnQuantity.IndexOf(',');
                string first_old_returnQuantity = old_returnQuantity.Substring(0, index);
                string last_old_returnQuantity = old_returnQuantity.Substring(index + 1);
                old_returnQuantity = first_old_returnQuantity + "." + last_old_returnQuantity;
            }
            string old_returnPrice = tbCartProduct.Rows[0]["return_price"].ToString();  //eski to'langan summani olamiz//
            if (old_returnPrice.IndexOf(',') > -1)
            {
                int index = old_returnPrice.IndexOf(',');
                string first_old_returnPrice = old_returnPrice.Substring(0, index);
                string last_old_returnPrice = old_returnPrice.Substring(index + 1);
                old_returnPrice = first_old_returnPrice + "." + last_old_returnPrice;
            }
            string old_qolganSumma = tbCartProduct.Rows[0]["debt_price"].ToString(); // eski qolgan_summa ni olamiz//
            if (old_qolganSumma.IndexOf(',') > -1)
            {
                int index = old_qolganSumma.IndexOf(',');
                string first_old_qolganSumma = old_qolganSumma.Substring(0, index);
                string last_old_qolganSumma = old_qolganSumma.Substring(index + 1);
                old_qolganSumma = first_old_qolganSumma + "." + last_old_qolganSumma;
            }
            string old_qolganMiqdor = tbCartProduct.Rows[0]["debt_quantity"].ToString(); // eski qolgan_miqdorni olamiz//
            if (old_qolganMiqdor.IndexOf(',') > -1)
            {
                int index = old_qolganMiqdor.IndexOf(',');
                string first_old_qolganMiqdor = old_qolganMiqdor.Substring(0, index);
                string last_old_qolganMiqdor = old_qolganMiqdor.Substring(index + 1);
                old_qolganMiqdor = first_old_qolganMiqdor + "." + last_old_qolganMiqdor;
            }
            string new_returnQuantity = txtEnterQuantity.Text; // yangi to'langan miqdor
            string new_returnPrice = str_total; // yangi to'langan summa

            double Dold_returnQuantity = double.Parse(old_returnQuantity, CultureInfo.InvariantCulture);
            double Dnew_returnQuantity = double.Parse(new_returnQuantity, CultureInfo.InvariantCulture);
            double result_returnQuantity = Dold_returnQuantity + Dnew_returnQuantity; // natijaviy to'langan miqdor
            string str_result_returnQuantity = result_returnQuantity.ToString();
            if (str_result_returnQuantity.IndexOf(',') > -1)
            {
                int index = str_result_returnQuantity.IndexOf(',');
                string first_str_result_returnQuantity = str_result_returnQuantity.Substring(0, index);
                string last_str_result_returnQuantity = str_result_returnQuantity.Substring(index + 1);
                str_result_returnQuantity = first_str_result_returnQuantity + "." + last_str_result_returnQuantity;
            }
            double Dold_returnPrice = double.Parse(old_returnPrice, CultureInfo.InvariantCulture);
            double Dnew_returnPrice = double.Parse(new_returnPrice, CultureInfo.InvariantCulture);
            double result_returnPrice = Dold_returnPrice + Dnew_returnPrice; //natijaviy to'langan summa
            string str_result_returnPrice = result_returnPrice.ToString();
            if (str_result_returnPrice.IndexOf(',') > -1)
            {
                int index = str_result_returnPrice.IndexOf(',');
                string first_str_result_returnPrice = str_result_returnPrice.Substring(0, index);
                string last_str_result_returnPrice = str_result_returnPrice.Substring(index + 1);
                str_result_returnPrice = first_str_result_returnPrice + "." + last_str_result_returnPrice;
            }

            double Dold_qolganSumma = double.Parse(old_qolganSumma, CultureInfo.InvariantCulture);
            double Dnew_qolganSumma = double.Parse(new_returnPrice, CultureInfo.InvariantCulture);
            double result_qolganSumma = Dold_qolganSumma - Dnew_qolganSumma;// natijaviy qolgan summa
            string str_result_qolganSumma = result_qolganSumma.ToString();
            if (str_result_qolganSumma.IndexOf(',') > -1)
            {
                int index = str_result_qolganSumma.IndexOf(',');
                string first_str_result_qolganSumma = str_result_qolganSumma.Substring(0, index);
                string last_str_result_qolganSumma = str_result_qolganSumma.Substring(index + 1);
                str_result_qolganSumma = first_str_result_qolganSumma + "." + last_str_result_qolganSumma;
            }

            double Dold_qolganMiqdor = double.Parse(old_qolganMiqdor, CultureInfo.InvariantCulture);
            double result_qolganMiqdor = Dold_qolganMiqdor - Dnew_returnQuantity; // natijaviy qolgan miqdor
            string str_result_qolganMiqdor = result_qolganMiqdor.ToString();
            if (str_result_qolganMiqdor.IndexOf(',') > -1)
            {
                int index = str_result_qolganMiqdor.IndexOf(',');
                string first_str_result_qolganMiqdor = str_result_qolganMiqdor.Substring(0, index);
                string last_str_result_qolganMiqdor = str_result_qolganMiqdor.Substring(index + 1);
                str_result_qolganMiqdor = first_str_result_qolganMiqdor + "." + last_str_result_qolganMiqdor;
            }

            cmdDebtCart = new MySqlCommand("update cartdebt set return_quantity='" + str_result_returnQuantity + "', return_price='" + str_result_returnPrice + "',debt_quantity='"+str_result_qolganMiqdor+"', debt_price='" + str_result_qolganSumma + "' where debtor_id='" + debtor_id + "' and product_id='" + product_id + "'");
            objDBAccess.executeQuery(cmdDebtCart);
            tbCartProduct.Clear();
            tbCartProduct.Dispose();

            // payhistory jadvaliga (id, debtor_id, given_summa, date) larni yozib qo'yamiz
            // payhistory jadvali bo'sh yoki bo'shmasligini tekshirib olishimiz kerek
            int payhistory_id = 0;
            string queryPayHistory_isNull = "select * from payhistory order by id desc limit 1";
            DataTable tbPayHistory_isNull = new DataTable();
            objDBAccess.readDatathroughAdapter(queryPayHistory_isNull, tbPayHistory_isNull);
            if(tbPayHistory_isNull.Rows.Count ==0) // Agar payhistory jadvali bo'sh bo'lsa id = 1 bo'ladi
            { payhistory_id = 1; }
            else { payhistory_id = int.Parse(tbPayHistory_isNull.Rows[0]["id"].ToString()) + 1; } // yoki id +=1 bo'ladi
            tbPayHistory_isNull.Clear();
            tbPayHistory_isNull.Dispose();

            DateTime dt = DateTime.Now;

            string queryCheck_date = "select * from payhistory where debtor_id='"+debtor_id+"' and date like '"+dt.ToString("yyyy-MM-dd")+"%'";
            DataTable tbCheck_date = new DataTable();
            objDBAccess.readDatathroughAdapter(queryCheck_date, tbCheck_date);
            if (tbCheck_date.Rows.Count > 0)
            {
                string payhistoryId = tbCheck_date.Rows[0]["id"].ToString();
                string given_summa_old = tbCheck_date.Rows[0]["given_summa"].ToString(); // bugun to'langan summani olamiz//
                if (given_summa_old.IndexOf(',') > -1)
                {
                    int index = given_summa_old.IndexOf(',');
                    string first_given_summa_old = given_summa_old.Substring(0, index);
                    string last_given_summa_old = given_summa_old.Substring(index + 1);
                    given_summa_old = first_given_summa_old + "." + last_given_summa_old;
                }
                //umumiy to'langan summani hisoblaymiz
                double Dgiven_summa_old = double.Parse(given_summa_old, CultureInfo.InvariantCulture);
                double result_given_summa = Dgiven_summa_old + total;
                string str_result_given_summa = result_given_summa.ToString();
                if(str_result_given_summa.IndexOf(',') > -1)
                {
                    int index = str_result_given_summa.IndexOf(',');
                    string first_str_result_given_summa = str_result_given_summa.Substring(0, index);
                    string last_str_result_given_summa = str_result_given_summa.Substring(index + 1);
                    str_result_given_summa = first_str_result_given_summa + "." + last_str_result_given_summa;
                }
                cmdPayhistory = new MySqlCommand("update payhistory set given_summa='" + str_result_given_summa + "', date='"+dt.ToString("yyyy-MM-dd HH:mm:ss") +"' where id='" + payhistoryId + "'");
                objDBAccess.executeQuery(cmdPayhistory);
                cmdPayhistory.Dispose();
            }
            else
            {
                cmdPayhistory = new MySqlCommand("insert into payhistory (id, debtor_id, given_summa, date, status_server) values('" + payhistory_id + "', '" + debtor_id + "', '" + str_total + "', '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "',0)");
                objDBAccess.executeQuery(cmdPayhistory);
                cmdPayhistory.Dispose();
            }
            tbCheck_date.Clear();
            tbCheck_date.Dispose();
            //debtor jadvaliga umumiy_qarzni update qilamiz
            string old_umumiyQarz = umumiy_qarz;
            double Dold_umumiyQarz = double.Parse(old_umumiyQarz, CultureInfo.InvariantCulture);
            double result_umumiyQarz = Dold_umumiyQarz - total;
            string str_result_umumiyQarz = result_umumiyQarz.ToString();
            if (str_result_umumiyQarz.IndexOf(',') > -1)
            {
                int index = str_result_umumiyQarz.IndexOf(',');
                string first_str_result_umumiyQarz = str_result_umumiyQarz.Substring(0, index);
                string last_str_result_umumiyQarz = str_result_umumiyQarz.Substring(index + 1);
                str_result_umumiyQarz = first_str_result_umumiyQarz + "." + last_str_result_umumiyQarz;
            }
            cmdDebtor = new MySqlCommand("update debtor set umumiy_qarz='" + str_result_umumiyQarz + "' where id='" + debtor_id + "'");
            objDBAccess.executeQuery(cmdDebtor);
            cmdDebtor.Dispose();

            MessageBox.Show("Тўлов муваффакиятли амалга оширилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            name = ""; qolgan_miqdor = ""; price = ""; debtor_id = ""; product_id = ""; umumiy_qarz = "";
            frmDebtList debtList = new frmDebtList();
            debtList.Refresh();
            Close();
        }

        private void DebtTulov_Load(object sender, EventArgs e)
        {
            txtEnterQuantity.Focus();
            this.KeyPreview = true;
            txtName.Text = name;
            txtprice.Text = price;
            txtQolganMiqdor.Text = qolgan_miqdor;
            
        }
    }
}
