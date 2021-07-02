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
using MySql.Data.MySqlClient;

namespace Jayhunelectro
{
    public partial class frmEditPrice : MetroFramework.Forms.MetroForm
    {
        public frmEditPrice()
        {
            InitializeComponent();
        }

        public string product = "", old_price = "", barcode="", edit_id="";
        DBAccess objDBAccess = new DBAccess();
        public static MySqlCommand cmdPriceCart, cmdChangedPrice, cmdProduct;
        private void frmEditPrice_Load(object sender, EventArgs e)
        {
            txtName.Text = product;
            txtOldPrice.Text = old_price;
        }

        static async Task<string> PostURI(Uri u, HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "token 3b3650ae90df953d29521e55492920b531d7cc6f");
                try
                {
                    HttpResponseMessage result = await client.PostAsync(u, c);
                    if (result.IsSuccessStatusCode)
                    {
                        using (HttpContent content = result.Content)
                        {
                            response = await content.ReadAsStringAsync();
                        }
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

        public string DoubleToStr(string s)
        {
            if(s.IndexOf(',')> -1)
            {
                int index = s.IndexOf(',');
                string first = s.Substring(0, index);
                string last = s.Substring(index + 1);
            }
            return s;
        }

        private void frmEditPrice_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmEditPrice_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                guna2Button2_Click_1(sender, e);
            }
        }

        public void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtNewPrice.Text == "") return;
            if (txtNewPrice.Text.IndexOf(',') > -1) { txtNewPrice.Text = ""; MessageBox.Show("Нукта билан киритинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            string new_price = txtNewPrice.Text;
            Uri u = new Uri("http://jayhun.backoffice.uz/ipa/productfilial/up/");

            var payload = "{\"barcode\": \""+barcode+"\",\"price\": \"" + new_price + "\"}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, content));
            t.Wait();
            if (t.Result == "Error!")
            {
                MessageBox.Show("Сeрвeр билан богланишда хатолик, илтимос интeрнeтни тeкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (t.Result != "Error!")
            {
                string str_oldPrice = DoubleToStr(txtOldPrice.Text);
                double Dold_price = double.Parse(str_oldPrice);
                string str_newPrice = DoubleToStr(txtNewPrice.Text);
                double Dnew_Price = double.Parse(str_newPrice);
                double difference = Dnew_Price - Dold_price; // bitta maxsulot farqi

                //Product jadvalidan qoldiqni olamiz
                string queryProductQuan = "select quantity from product where barcode='" + barcode + "'";
                DataTable tbProductQuan = new DataTable();
                objDBAccess.readDatathroughAdapter(queryProductQuan, tbProductQuan);
                string str_quan = tbProductQuan.Rows[0]["quantity"].ToString();
                str_quan = DoubleToStr(str_quan);
                double Dquan = double.Parse(str_quan);
                tbProductQuan.Clear();
                tbProductQuan.Dispose();
                double totalPr_diff = difference * Dquan; // Umumiy farq
                
                //Pricecart jadvalidan id ni belgilab olamiz
                double prcId = 0;
                string queryPrId = "select id from pricecart order by id desc limit 1";
                DataTable tbPrId = new DataTable();
                objDBAccess.readDatathroughAdapter(queryPrId, tbPrId);
                if (tbPrId.Rows.Count ==0) { prcId = 1; }
                else { prcId = int.Parse(tbPrId.Rows[0]["id"].ToString(), CultureInfo.InvariantCulture) + 1; }
                tbPrId.Clear();
                tbPrId.Dispose();

                //Changedprice jadvalidan ushbu kundagi narx o'zgarish bor yoki yo'qligini tekshiramiz
                string queryDif = "select difference from changedprice where id='" + edit_id + "'";
                DataTable tbDifference = new DataTable();
                objDBAccess.readDatathroughAdapter(queryDif, tbDifference);

                if (tbDifference.Rows.Count > 0) // Agar ushbu kunda o'zgartirilgan bo'lsa difference+=totalPr_diff bo'ladi
                {
                    string str_diff = tbDifference.Rows[0]["difference"].ToString();
                    str_diff = DoubleToStr(str_diff);
                    double old_diff = double.Parse(str_diff);
                    double total_diff = old_diff + totalPr_diff; // umumiy farq
                    cmdChangedPrice = new MySqlCommand("update changedprice set difference='" + DoubleToStr(total_diff.ToString()) + "' where id='" + edit_id + "'");
                    objDBAccess.executeQuery(cmdChangedPrice);
                    cmdChangedPrice.Dispose();
                }
                else // Agar ushbu sanada bo'lmasa difference = totalPr_diff ga teng bo'ladi
                {
                    cmdChangedPrice = new MySqlCommand("update changedprice set difference='" + DoubleToStr(totalPr_diff.ToString()) + "' where id='" + edit_id + "'");
                    objDBAccess.executeQuery(cmdChangedPrice);
                    cmdChangedPrice.Dispose();
                }
                tbDifference.Clear();
                tbDifference.Dispose();
                cmdPriceCart = new MySqlCommand("insert into pricecart (id,ch_id,pr_name,old_price,new_price,residue,difference,total_diff) values('" + prcId + "','" + edit_id.ToString() + "','" + product + "','" + str_oldPrice + "','" + str_newPrice + "','"+str_quan+"','" + DoubleToStr(difference.ToString()) + "','"+DoubleToStr(totalPr_diff.ToString())+"')");
                objDBAccess.executeQuery(cmdPriceCart);
                cmdPriceCart.Dispose();
                frmTovarQabuli frmTovar = new frmTovarQabuli();
                frmTovar.RefreshPrice();
                frmTovar.Dispose();

                //Endi product jadvalidagi maxsulotni narxini update qilamiz
                cmdProduct = new MySqlCommand("update product set price='" + str_newPrice + "' where barcode='" + barcode + "'");
                objDBAccess.executeQuery(cmdProduct);
                cmdProduct.Dispose();
                this.Close();
            }
        }

        public void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
