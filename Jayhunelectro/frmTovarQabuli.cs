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
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Globalization;

namespace Jayhunelectro
{
    public partial class frmTovarQabuli : Form
    {
        public frmTovarQabuli()
        {
            InitializeComponent();
        }
        DBAccess objDBAccess = new DBAccess();
        public static DataTable tbUsers, tbStaff, tbProduct, tbPrice, tbChangedprice, tbPricecart;
        public static CurrencyManager managerFakturaItem, managerProduct, managerChangedprice;
        public static MySqlCommand cmdUser, cmdChangedPrice;
        public static string count="";
        public static string faktura_id = "";
        public static string status = "";
        public static bool edit = false;
        public static int edit_id = 0;
    
        private void tabControl1_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                objDBAccess.createConn();
                string queryUsers = "select first_name as Исми, last_name as Фамилияси, staff.staff as Лавозими, username as Фойдаланувчи_номи, password as Пароли from userprofile inner join staff where userprofile.staff_id = staff.id";
                tbUsers = new DataTable();
                objDBAccess.readDatathroughAdapter(queryUsers, tbUsers);
                dbgridStaff.DataSource = tbUsers;
                dbgridStaff.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbUsers.Dispose();
                string queryStaff = "select * from staff";
                tbStaff = new DataTable();
                objDBAccess.readDatathroughAdapter(queryStaff, tbStaff);
                comboStaff.DataSource = tbStaff;
                comboStaff.DisplayMember = "staff";
                objDBAccess.closeConn();
            }
            if(tabControl1.SelectedIndex == 2)
            {
                string queryProduct = "select product_id, name as номи,price as нархи,quantity as микдори, barcode as штрих_код from product limit 1";
                tbProduct = new DataTable();
                objDBAccess.readDatathroughAdapter(queryProduct, tbProduct);
                managerProduct = (CurrencyManager)BindingContext[tbProduct];
                dbgridProduct.DataSource = tbProduct;
                dbgridProduct.MaximumSize = new Size(this.dbgridProduct.Width, 400);
                dbgridProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dbgridProduct.Columns[0].Visible = false;
                dbgridProduct.RowHeadersVisible = false;
                dbgridProduct.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                DateTime dt_now = DateTime.Now;
                string dt_n = dt_now.ToString("yyyy-MM-dd");
                string queryPriceCart = "select pricecart.id, pricecart.ch_id, pricecart.pr_name as махсулот, pricecart.old_price as аввалги_нарх, pricecart.new_price as янги_нарх,pricecart.residue as колдик, pricecart.difference as битта_фарк, pricecart.total_diff as умумий_фарк from pricecart" +
                    " inner join changedprice on pricecart.ch_id = changedprice.id where changedprice.date like '" + dt_n + "%'";
                tbPrice = new DataTable();
                objDBAccess.readDatathroughAdapter(queryPriceCart, tbPrice);
                dbgirdPriceCart.DataSource = tbPrice;
                dbgirdPriceCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dbgirdPriceCart.Columns[0].Visible = false;
                dbgirdPriceCart.Columns[1].Visible = false;
                dbgirdPriceCart.DataSource = tbPrice;
            }
            if(tabControl1.SelectedIndex == 3)
            {
                string date = pricemonth.Value.ToString("yyyy-MM-dd");
                string queryChangedPrice = "select id, date as сана, difference as фарк from changedprice where date like '"+date+"%'";
                tbChangedprice = new DataTable();
                objDBAccess.readDatathroughAdapter(queryChangedPrice, tbChangedprice);
                managerChangedprice = (CurrencyManager)BindingContext[tbChangedprice];
                dbgridChangedPrice.DataSource = tbChangedprice;
                dbgridChangedPrice.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dbgridChangedPrice.Columns[0].Visible = false;
                if (tbChangedprice.Rows.Count > 0)
                {
                    string s_id = tbChangedprice.Rows[managerChangedprice.Position]["id"].ToString();
                    string queryPriceCart = "select id, ch_id, pr_name as махсулот, old_price as аввалги_нарх, new_price as янги_нарх,residue as колдик, difference as битта_фарк, total_diff as умумий_фарк from pricecart where ch_id='" + s_id+ "'";
                    tbPricecart = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryPriceCart, tbPricecart);
                    dbgridPriceCart.DataSource = tbPricecart;
                    dbgirdPriceCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    dbgridPriceCart.Columns[0].Visible = false;
                    dbgridPriceCart.Columns[1].Visible = false;
                }
                else
                {
                    string queryPriceCart = "select id, ch_id, pr_name as махсулот, old_price as аввалги_нарх, new_price as янги_нарх,residue as колдик, difference as битта_фарк, total_diff as умумий_фарк from pricecart where ch_id=0";
                    tbPricecart = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryPriceCart, tbPricecart);
                    dbgridPriceCart.DataSource = tbPricecart;
                    dbgirdPriceCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    dbgridPriceCart.Columns[0].Visible = false;
                    dbgridPriceCart.Columns[1].Visible = false;
                }
                tbChangedprice.Dispose();
                tbPricecart.Dispose();
            }
        }
        public void RefreshPrice()
        {
            DateTime dt_now = DateTime.Now;
            string dt_n = dt_now.ToString("yyyy-MM-dd");
            string queryPriceCart = "select pricecart.id, pricecart.ch_id, pricecart.pr_name as махсулот, pricecart.old_price as аввалги_нарх, pricecart.new_price as янги_нарх,pricecart.residue as колдик, pricecart.difference as битта_фарк, pricecart.total_diff as умумий_фарк from pricecart" +
                " inner join changedprice on pricecart.ch_id = changedprice.id where changedprice.date like '" + dt_n + "%'";
            try { tbPrice.Clear(); } catch (Exception) { }
            objDBAccess.readDatathroughAdapter(queryPriceCart, tbPrice);
        }
        public void RefreshUser()
        {
            objDBAccess.createConn();
            string queryUsers = "select first_name as Исми, last_name as Фамилияси, staff.staff as Лавозими, username as Фойдаланувчи_номи, password as Пароли from userprofile inner join staff where userprofile.staff_id = staff.id";
            if(tbUsers.Rows.Count > 0)
            tbUsers.Clear();
            objDBAccess.readDatathroughAdapter(queryUsers, tbUsers);
            objDBAccess.closeConn();
        }
        private void iconPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dbgridFakturaItem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFakturaItem.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridStaff_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridStaff.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
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

        public static async Task<string> GetObject(string restCallURL)
        {
            HttpClient apiCallClient = new HttpClient();
            string authToken = "token 3b3650ae90df953d29521e55492920b531d7cc6f";
            HttpRequestMessage apirequest = new HttpRequestMessage(HttpMethod.Get, restCallURL);
            apirequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apirequest.Headers.Add("Authorization", authToken);
            HttpResponseMessage apiCallResponse = await apiCallClient.SendAsync(apirequest);

            string requestresponse = await apiCallResponse.Content.ReadAsStringAsync();
            return requestresponse;
        }

        public class UserObject
        {
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public int staff { get; set; }
            public int filial { get; set; }
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            if(txtName.Text=="" || txtPass.Text=="" || txtSurname.Text=="")
            {
                MessageBox.Show("Малумотлар тўлик эмас,\nилтимос тэкшириб кайтадан уриниб кўринг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtPass.Text.Length < 6)
            {
                MessageBox.Show("Парол энг камида 6 хоналик бўлиши кэрэк!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Uri u = new Uri("http://jayhun.backoffice.uz/ipa/userprofile/");
            string password = txtPass.Text;
            string first_name = txtName.Text;
            string last_name = txtSurname.Text;
            string staff = (comboStaff.SelectedIndex + 1).ToString();
            string filial = frmMainMenu.filial_id;
            
            var payload = "{\"username\": \"Jayhunelectro\",\"password\": \"" + password + "\",\"first_name\": \"" + first_name + "\",\"last_name\": \"" + last_name + "\",\"staff\": \"" + staff + "\",\"filial\": \""+ filial + "\"}";
            //MessageBox.Show(payload);
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var t = Task.Run(() => PostURI(u, content));
            t.Wait();
            if (t.Result == "Error!")
            {
                MessageBox.Show("Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (t.Result != "Error!")
            {
                string UserContent = t.Result;
                string userId = "";
                UserObject user = JsonConvert.DeserializeObject<UserObject>(UserContent);
                userId = user.id.ToString();

                cmdUser = new MySqlCommand("insert into userprofile (id,password,first_name,last_name,staff_id) values('" + userId + "','" + password + "','" + first_name + "','" + last_name + "','" + staff + "')");
                objDBAccess.executeQuery(cmdUser);
                cmdUser.Dispose();
                MessageBox.Show("Йанги ходим муваффакиятли кўшилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
                txtPass.Clear();
                txtSurname.Clear();
                RefreshUser();
            }

        }
        public static DataTable tbDebtor, tbCartDebt;
        public static DataTable tbFaktura, tbFakturaItem;
        public static MySqlCommand cmdUpdateDebtor;
        public static CurrencyManager managerFaktura;
        public static CurrencyManager managerDebtor, managerCartDebt;

        public static bool cell = false;

        private async void dbgridFaktura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(cell == false)
            {
                cell = true;
                if(tbFaktura.Rows.Count > 0)
                {
                    if(tbFaktura.Rows.Count > 0) { tbFakturaItem.Clear(); }
                    else
                    {
                        tbFakturaItem = new DataTable();
                        tbFakturaItem.Columns.Add("product");
                        tbFakturaItem.Columns.Add("Номи");
                        tbFakturaItem.Columns.Add("Нархи");
                        tbFakturaItem.Columns.Add("Микдори");
                        tbFakturaItem.Columns.Add("Штрих_код");
                        tbFakturaItem.Columns.Add("Гурух");
                    }
                    string urlFakturaItem = "http://jayhun.backoffice.uz/ipa/fakturaitem/st1/?fak=" + tbFaktura.Rows[managerFaktura.Position]["id"].ToString();
                    string FakturaItemContent = await GetObject(urlFakturaItem);
                    JArray arrayFakturaItem = JArray.Parse(FakturaItemContent);
                    if (arrayFakturaItem != null)
                    {
                        foreach (var item in arrayFakturaItem)
                        {
                            DataRow rowFakturaItem = tbFakturaItem.NewRow();
                            rowFakturaItem["product"] = item["product"];
                            rowFakturaItem["Номи"] = item["name"];
                            rowFakturaItem["Нархи"] = item["price"];
                            rowFakturaItem["Микдори"] = item["quantity"];
                            rowFakturaItem["Штрих_код"] = item["barcode"];
                            rowFakturaItem["Гурух"] = item["group"].ToString();
                            tbFakturaItem.Rows.Add(rowFakturaItem);
                        }
                    }
                    managerFakturaItem = (CurrencyManager)BindingContext[tbFakturaItem];
                    dbgridFakturaItem.DataSource = tbFakturaItem;
                    dbgridFakturaItem.Columns[0].Visible = false;
                    dbgridFakturaItem.Columns[5].Visible = false;
                    dbgridFakturaItem.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
                cell = false;
            }
        }

        public static MySqlCommand cmdUpdateProd, cmdUpdateCartDebt;

        private void dbgridFaktura_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFaktura.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridFakturaItem_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFakturaItem.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void lblQayta_Click(object sender, EventArgs e)
        {
            frmTovarQabuli_Load(sender, e);
            lblQayta.Visible = false;
        }

        private void dbgirdPriceCart_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgirdPriceCart.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridChangedPrice_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridChangedPrice.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dbgridPriceCart_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridPriceCart.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        public void pricemonth_ValueChanged(object sender, EventArgs e)
        {
            string dt_time = pricemonth.Value.ToString("yyyy-MM-dd");
            string querySearch = "select id,date as сана, difference as фарк from changedprice where date like '" + dt_time + "%'";
            tbChangedprice.Clear();
            tbPricecart.Clear();
            objDBAccess.readDatathroughAdapter(querySearch, tbChangedprice);
            managerChangedprice = (CurrencyManager)BindingContext[tbChangedprice];
            if(tbChangedprice.Rows.Count > 0)
            {
                string queryPriceCart = "select id, ch_id, pr_name as махсулот, old_price as аввалги_нарх, new_price as янги_нарх,residue as колдик, difference as битта_фарк, total_diff as умумий_фарк from pricecart where ch_id='" + tbChangedprice.Rows[managerChangedprice.Position]["id"] + "'";
                objDBAccess.readDatathroughAdapter(queryPriceCart, tbPricecart);
                //dbgridPriceCart.DataSource = tbPricecart;
                //dbgridPriceCart.Columns[0].Visible = false;
                //dbgridPriceCart.Columns[1].Visible = false;
                //dbgirdPriceCart.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            }
        }

        private void frmTovarQabuli_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMainMenu.Recieve = false;
        }

        private void dbgridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dbgridProduct_KeyDown(object sender, KeyEventArgs e)
        {
            //if (edit == false)
            //{
            //    string query_changedId = "select id from changedprice order by id desc limit 1";
            //    DataTable tbId = new DataTable();
            //    objDBAccess.readDatathroughAdapter(query_changedId, tbId);
            //    DateTime dt_now = DateTime.Now;
            //    string dt_n = dt_now.ToString("yyyy-MM-dd");
            //    if (tbId.Rows.Count == 0)
            //    {
            //        edit_id = 1;
            //        edit = true;
            //        cmdChangedPrice = new MySqlCommand("insert into changedprice (id,date,difference) values(1,'" + dt_n + "',0)");
            //        objDBAccess.executeQuery(cmdChangedPrice);
            //        cmdChangedPrice.Dispose();
            //    }
            //    else
            //    {
            //        int nId = int.Parse(tbId.Rows[0]["id"].ToString(), CultureInfo.InvariantCulture);
            //        string query_changeddif = "select * from changedprice where date like '" + dt_n + "%'";
            //        DataTable tbCheck = new DataTable();
            //        objDBAccess.readDatathroughAdapter(query_changeddif, tbCheck);
            //        if (tbCheck.Rows.Count == 0)
            //        {
            //            nId += 1;
            //            edit_id = nId;
            //            edit = true;
            //            cmdChangedPrice = new MySqlCommand("insert into changedprice (id,date,difference) values('" + nId + "','" + dt_n + "',0)");
            //            objDBAccess.executeQuery(cmdChangedPrice);
            //            cmdChangedPrice.Dispose();
            //        }
            //        else
            //        {
            //            edit_id = nId;
            //            edit = true;
            //        }
            //        tbCheck.Clear();
            //        tbCheck.Dispose();
            //    }
            //    tbId.Clear();
            //    tbId.Dispose();
            //}
            if (e.KeyCode == Keys.Enter)
            {
                if (edit == false)
                {
                    string query_changedId = "select id from changedprice order by id desc limit 1";
                    DataTable tbId = new DataTable();
                    objDBAccess.readDatathroughAdapter(query_changedId, tbId);
                    DateTime dt_now = DateTime.Now;
                    string dt_n = dt_now.ToString("yyyy-MM-dd");
                    if (tbId.Rows.Count == 0)
                    {
                        edit_id = 1;
                        edit = true;
                        cmdChangedPrice = new MySqlCommand("insert into changedprice (id,date,difference) values(1,'" + dt_n + "',0)");
                        objDBAccess.executeQuery(cmdChangedPrice);
                    }
                    else
                    {
                        int nId = int.Parse(tbId.Rows[0]["id"].ToString(), CultureInfo.InvariantCulture);
                        string query_changeddif = "select * from changedprice where date like '" + dt_n + "%'";
                        DataTable tbCheck = new DataTable();
                        objDBAccess.readDatathroughAdapter(query_changeddif, tbCheck);
                        if (tbCheck.Rows.Count == 0)
                        {
                            nId += 1;
                            edit_id = nId;
                            edit = true;
                            cmdChangedPrice = new MySqlCommand("insert into changedprice (id,date,difference) values('" + nId + "','" + dt_n + "',0)");
                            objDBAccess.executeQuery(cmdChangedPrice);
                        }
                        else
                        {
                            edit_id = nId;
                            edit = true;
                        }
                        tbCheck.Clear();
                        tbCheck.Dispose();
                    }
                    tbId.Clear();
                    tbId.Dispose();
                }
                frmEditPrice editPrice = new frmEditPrice();
                editPrice.product = tbProduct.Rows[managerProduct.Position]["номи"].ToString();
                editPrice.old_price = tbProduct.Rows[managerProduct.Position]["нархи"].ToString();
                editPrice.barcode = tbProduct.Rows[managerProduct.Position]["штрих_код"].ToString();
                editPrice.edit_id = edit_id.ToString();
                editPrice.ShowDialog();
                txtSearchPrice.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void txtSearchPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchPrice.Text.Length > 2)
            {
                string querySearch = "";
                try
                {
                    double number = double.Parse(txtSearchPrice.Text, CultureInfo.InvariantCulture);
                    if (txtSearchPrice.Text.Length > 5)
                    {
                        querySearch = "select product_id,name as номи, price as нархи,quantity as микдори, barcode as штрих_код from product where barcode LIKE'%" + txtSearchPrice.Text + "%'";
                        tbProduct.Clear();
                        objDBAccess.readDatathroughAdapter(querySearch, tbProduct);
                        dbgridProduct.DataSource = tbProduct;
                        dbgridProduct.Visible = true;
                        dbgirdPriceCart.Visible = false;
                    }
                }
                catch (Exception)
                {
                    querySearch = "select product_id,name as номи, price as нархи,quantity as микдори, barcode as штрих_код from product where name LIKE'%" + txtSearchPrice.Text + "%'";
                    tbProduct.Clear();
                    objDBAccess.readDatathroughAdapter(querySearch, tbProduct);
                    dbgridProduct.DataSource = tbProduct;
                    dbgridProduct.Visible = true;
                    dbgirdPriceCart.Visible = false;
                }
            }
            else
            {
                dbgridProduct.Visible = false;
                dbgirdPriceCart.Visible = true;
                objDBAccess.createConn();
                string queryProduct = "select product_id,name as номи, price as нархи,quantity as микдори, barcode as штрих_код from product limit 1";
                try { tbProduct.Clear(); } catch (Exception) { }
                objDBAccess.readDatathroughAdapter(queryProduct, tbProduct);
            }
        }

        private void txtSearchPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && dbgridProduct.Visible)
            {
                dbgridProduct.Focus();
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Down && dbgridProduct.Visible == false)
            {
                dbgirdPriceCart.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if(edit == false)
                {
                    string query_changedId = "select id from changedprice order by id desc limit 1";
                    DataTable tbId = new DataTable();
                    objDBAccess.readDatathroughAdapter(query_changedId, tbId);
                    DateTime dt_now = DateTime.Now;
                    string dt_n = dt_now.ToString("yyyy-MM-dd");
                    if (tbId.Rows.Count == 0)
                    {
                        edit_id = 1;
                        edit = true;
                        cmdChangedPrice = new MySqlCommand("insert into changedprice (id,date,difference) values(1,'" + dt_n + "',0)");
                        objDBAccess.executeQuery(cmdChangedPrice);
                    }
                    else
                    {
                        int nId = int.Parse(tbId.Rows[0]["id"].ToString(), CultureInfo.InvariantCulture);
                        string query_changeddif = "select * from changedprice where date like '" + dt_n + "%'";
                        DataTable tbCheck = new DataTable();
                        objDBAccess.readDatathroughAdapter(query_changeddif, tbCheck);
                        if (tbCheck.Rows.Count == 0)
                        {
                            nId += 1;
                            edit_id = nId;
                            edit = true;
                            cmdChangedPrice = new MySqlCommand("insert into changedprice (id,date,difference) values('" + nId + "','" + dt_n + "',0)");
                            objDBAccess.executeQuery(cmdChangedPrice);
                        }
                        else
                        {
                            edit_id = nId;
                            edit = true;
                        }
                        tbCheck.Clear();
                        tbCheck.Dispose();
                    }
                    tbId.Clear();
                    tbId.Dispose();
                }
                frmEditPrice editPrice = new frmEditPrice();
                editPrice.product = tbProduct.Rows[managerProduct.Position]["номи"].ToString();
                editPrice.old_price = tbProduct.Rows[managerProduct.Position]["нархи"].ToString();
                editPrice.barcode = tbProduct.Rows[managerProduct.Position]["штрих_код"].ToString();
                editPrice.edit_id = edit_id.ToString();
                editPrice.ShowDialog();
                txtSearchPrice.Clear();
                e.SuppressKeyPress = true;
            }
        }

        public static DataTable GetJSONToDataTableUsingNewtonSoftDll(string JSONData)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(JSONData, (typeof(DataTable)));
            return dt;
        }


        public async void frmTovarQabuli_Load(object sender, EventArgs e)
        {
            if (frmMainMenu.Recieve == false)
            {
                try
                {
                    lblStatus.Visible = true;
                    tbFaktura = new DataTable();
                    tbFaktura.Columns.Add("id", typeof(int));
                    tbFaktura.Columns.Add("Сана");
                    tbFaktura.Columns.Add("Сумма");

                    string urlFaktura = "http://jayhun.backoffice.uz/ipa/faktura/st1/?fil=" + frmMainMenu.filial_id;
                    string FakturaContent = await GetObject(urlFaktura);
                    lblStatus.Visible = false;
                    JArray arrayFaktura = JArray.Parse(FakturaContent);
                    if (arrayFaktura != null)
                    {
                        foreach (var item in arrayFaktura)
                        {
                            DataRow rowFaktura = tbFaktura.NewRow();
                            rowFaktura["id"] = item["id"];
                            rowFaktura["Сана"] = item["date"];
                            rowFaktura["Сумма"] = item["summa"];
                            tbFaktura.Rows.Add(rowFaktura);
                        }

                    }

                    managerFaktura = (CurrencyManager)BindingContext[tbFaktura];
                    dbgridFaktura.DataSource = tbFaktura;
                    dbgridFaktura.Columns[0].Visible = false;
                    dbgridFaktura.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    tbFaktura.Dispose();
                    if (tbFaktura.Rows.Count > 0)
                    {
                        try
                        {
                            lblStatus.Visible = true;
                            tbFakturaItem = new DataTable();
                            tbFakturaItem.Columns.Add("product");
                            tbFakturaItem.Columns.Add("Номи");
                            tbFakturaItem.Columns.Add("Нархи");
                            tbFakturaItem.Columns.Add("Микдори");
                            tbFakturaItem.Columns.Add("Штрих_код");
                            tbFakturaItem.Columns.Add("Гурух");

                            string urlFakturaItem = "http://jayhun.backoffice.uz/ipa/fakturaitem/st1/?fak=" + tbFaktura.Rows[0]["id"].ToString();
                            string FakturaItemContent = await GetObject(urlFakturaItem);
                            lblStatus.Visible = false;
                            JArray arrayFakturaItem = JArray.Parse(FakturaItemContent);
                            if (arrayFakturaItem != null)
                            {
                                foreach (var item in arrayFakturaItem)
                                {
                                    DataRow rowFakturaItem = tbFakturaItem.NewRow();
                                    rowFakturaItem["product"] = item["product"];
                                    rowFakturaItem["Номи"] = item["name"];
                                    rowFakturaItem["Нархи"] = item["price"];
                                    rowFakturaItem["Микдори"] = item["quantity"];
                                    rowFakturaItem["Штрих_код"] = item["barcode"];
                                    rowFakturaItem["Гурух"] = item["group"];
                                    tbFakturaItem.Rows.Add(rowFakturaItem);
                                }
                            }
                            managerFakturaItem = (CurrencyManager)BindingContext[tbFakturaItem];
                            dbgridFakturaItem.DataSource = tbFakturaItem;
                            dbgridFakturaItem.Columns[0].Visible = false;
                            dbgridFakturaItem.Columns[5].Visible = false;
                            dbgridFakturaItem.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblStatus.Visible = false;
                            lblQayta.Visible = true;
                            return;
                        }
                    }
                    lblStatus.Visible = false;
                    frmMainMenu.Recieve = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Visible = false;
                    lblQayta.Visible = true;
                    return;
                }
            }
            else
            {
                dbgridFaktura.DataSource = tbFaktura;
                dbgridFaktura.Columns[0].Visible = false;
                dbgridFaktura.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                if(dbgridFaktura.Rows.Count > 0)
                {
                    dbgridFakturaItem.DataSource = tbFakturaItem;
                    dbgridFakturaItem.Columns[0].Visible = false;
                    dbgridFakturaItem.Columns[5].Visible = false;
                    dbgridFakturaItem.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
            }
        }

        public async void ShowRecieve()
        {
            try
            {
                lblStatus.Visible = true;
                if (frmMainMenu.Recieve) { tbFaktura.Clear(); }
                else
                {
                    tbFaktura = new DataTable();
                    tbFaktura.Columns.Add("id", typeof(int));
                    tbFaktura.Columns.Add("Сана");
                    tbFaktura.Columns.Add("Сумма");
                }
                string urlFaktura = "http://jayhun.backoffice.uz/ipa/faktura/st1/?fil=" + frmMainMenu.filial_id;
                string FakturaContent = await GetObject(urlFaktura);
                lblStatus.Visible = false;
                JArray arrayFaktura = JArray.Parse(FakturaContent);
                if (arrayFaktura != null)
                {
                    foreach (var item in arrayFaktura)
                    {
                        DataRow rowFaktura = tbFaktura.NewRow();
                        rowFaktura["id"] = item["id"];
                        rowFaktura["Сана"] = item["date"];
                        rowFaktura["Сумма"] = item["summa"];
                        tbFaktura.Rows.Add(rowFaktura);
                    }

                }

                managerFaktura = (CurrencyManager)BindingContext[tbFaktura];
                dbgridFaktura.DataSource = tbFaktura;
                dbgridFaktura.Columns[0].Visible = false;
                dbgridFaktura.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                tbFaktura.Dispose();
                try
                {
                    tbFakturaItem.Clear();
                }
                catch (Exception) { }
                if (tbFaktura.Rows.Count > 0)
                {
                    tbFakturaItem.Clear();
                    try
                    {
                        lblStatus.Visible = true;
                        
                        string urlFakturaItem = "http://jayhun.backoffice.uz/ipa/fakturaitem/st1/?fak=" + tbFaktura.Rows[0]["id"].ToString();
                        string FakturaItemContent = await GetObject(urlFakturaItem);
                        lblStatus.Visible = false;
                        JArray arrayFakturaItem = JArray.Parse(FakturaItemContent);
                        if (arrayFakturaItem != null)
                        {
                            foreach (var item in arrayFakturaItem)
                            {
                                DataRow rowFakturaItem = tbFakturaItem.NewRow();
                                rowFakturaItem["product"] = item["product"];
                                rowFakturaItem["Номи"] = item["name"];
                                rowFakturaItem["Нархи"] = item["price"];
                                rowFakturaItem["Микдори"] = item["quantity"];
                                rowFakturaItem["Штрих_код"] = item["barcode"];
                                rowFakturaItem["Гурух"] = item["group"];
                                tbFakturaItem.Rows.Add(rowFakturaItem);
                            }
                        }
                        managerFakturaItem = (CurrencyManager)BindingContext[tbFakturaItem];
                        dbgridFakturaItem.DataSource = tbFakturaItem;
                        dbgridFakturaItem.Columns[0].Visible = false;
                        dbgridFakturaItem.Columns[5].Visible = false;
                        dbgridFakturaItem.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblStatus.Visible = false;
                        lblQayta.Visible = true;
                        return;
                    }
                }
                lblStatus.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Visible = false;
                lblQayta.Visible = true;
                return;
            }
        }

        public string DoubleToStr(string str)
        {
            if(str.IndexOf(',') > -1)
            {
                int index = str.IndexOf(',');
                string first = str.Substring(0, index);
                string last = str.Substring(index + 1);
                str = first + "." + last;
                    


            }
            return str;
        }

        private async void btnQabulQilish_Click(object sender, EventArgs e)
        {
            if (tbFaktura.Rows.Count == 0) return;

            try
            {
                string faktura = tbFaktura.Rows[managerFaktura.Position]["id"].ToString();
                string filial = frmMainMenu.filial_id;
                Uri u = new Uri("http://jayhun.backoffice.uz/ipa/productfilial/add/");
                string payload = "{\"faktura\": \"" + faktura + "\",\"filial\": \"" + filial + "\"}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(u, content));
                t.Wait();
                if (t.Result == "Error!")
                {
                    MessageBox.Show("Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Интэрнэт билан богланишни тэкширинг!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Dastlab Fakturada kelgan tovarlarni maxsulot jadvaliga qabul qilamiz
            int CountRecieve = managerFakturaItem.Count;
            managerFakturaItem.Position = 0;
            string Recieve_barcode = "", Recieve_price = "", Recieve_quantity=""; // GetObject();
            string product_quantiy = "", product_price="";
            DataTable tbProductOne = new DataTable();
            for(int i = 0; i<CountRecieve; i++)
            {
                Recieve_barcode = tbFakturaItem.Rows[managerFakturaItem.Position]["Штрих_код"].ToString();
                Recieve_price = tbFakturaItem.Rows[managerFakturaItem.Position]["Нархи"].ToString();
                Recieve_quantity = tbFakturaItem.Rows[managerFakturaItem.Position]["Микдори"].ToString();//
                if(Recieve_quantity.IndexOf(',') > -1)
                {
                    int index = Recieve_quantity.IndexOf(',');
                    string first_Recieve_quantity = Recieve_quantity.Substring(0, index);
                    string last_Recieve_quantity = Recieve_quantity.Substring(index + 1);
                    Recieve_quantity = first_Recieve_quantity + "." + last_Recieve_quantity;
                }
                string queryProductOne = "select * from product where barcode='" + Recieve_barcode + "'";
                objDBAccess.readDatathroughAdapter(queryProductOne, tbProductOne);
                //Agar ushbu maxsulotdan avval olingan bo'lsa uni miqdorini , narxini update qilamiz
                if(tbProductOne.Rows.Count > 0)
                {
                    product_quantiy = tbProductOne.Rows[0]["quantity"].ToString();//
                    if (product_quantiy.IndexOf(',') > -1)
                    {
                        int index = product_quantiy.IndexOf(',');
                        string first_product_quantiy = product_quantiy.Substring(0, index);
                        string last_product_quantiy = product_quantiy.Substring(index + 1);
                        product_quantiy = first_product_quantiy + "." + last_product_quantiy;
                    }
                    product_price = tbProductOne.Rows[0]["price"].ToString();

                    double Dproduct_quantity = double.Parse(product_quantiy, CultureInfo.InvariantCulture);
                    double Drecieve_quantity = double.Parse(Recieve_quantity, CultureInfo.InvariantCulture);
                    double result_quantity = Dproduct_quantity + Drecieve_quantity; // natijaviy miqdor
                    string str_result_quantity = result_quantity.ToString();
                    if(str_result_quantity.IndexOf(',') > -1)
                    {
                        int index = str_result_quantity.IndexOf(',');
                        string first_str_result_quantity = str_result_quantity.Substring(0, index);
                        string last_str_result_quantity = str_result_quantity.Substring(index + 1);
                        str_result_quantity = first_str_result_quantity + "." + last_str_result_quantity;
                    }

                    double Dproduct_price = double.Parse(product_price, CultureInfo.InvariantCulture);
                    double Drecieve_price = double.Parse(Recieve_price, CultureInfo.InvariantCulture);

                    cmdUpdateProd = new MySqlCommand("update product set price='" + Recieve_price + "', quantity='" + str_result_quantity + "' where barcode='"+Recieve_barcode+"'");
                    objDBAccess.executeQuery(cmdUpdateProd);
                    cmdUpdateProd.Dispose();
                }
                //Agar ushbu maxsulotdan avval olinmagan bo'lsa, product jadvaliga kiritamiz
                else
                {
                    string Recieve_prodId = tbFakturaItem.Rows[managerFakturaItem.Position]["product"].ToString();
                    string Recieve_name = tbFakturaItem.Rows[managerFakturaItem.Position]["Номи"].ToString();
                    string Recieve_group = tbFakturaItem.Rows[managerFakturaItem.Position]["Гурух"].ToString();
                    string queryProduct_id = "select * from product order by id desc limit 1";
                    DataTable tbProduct_id = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryProduct_id, tbProduct_id);
                    if(tbProduct_id.Rows.Count ==0)
                    {
                        cmdUpdateProd = new MySqlCommand("insert into product (id,product_id,name,price,quantity,barcode,gurux) values(1,'"+Recieve_prodId+"','"+Recieve_name+"','"+Recieve_price+"','"+Recieve_quantity+"','"+Recieve_barcode+"','"+Recieve_group+"'");
                        objDBAccess.executeQuery(cmdUpdateProd);
                    }
                    else
                    {
                        cmdUpdateProd = new MySqlCommand("insert into product (product_id,name,price,quantity,barcode,gurux) values('" + Recieve_prodId + "','" + Recieve_name + "','" + Recieve_price + "','" + Recieve_quantity + "','" + Recieve_barcode + "','"+Recieve_group+"')");
                        objDBAccess.executeQuery(cmdUpdateProd);
                    }
                    tbProduct_id.Clear();
                    tbProduct_id.Dispose();
                }
                tbProductOne.Clear();
                tbProductOne.Dispose();
                managerFakturaItem.Position++;
            }

            MessageBox.Show("Фактурадаги товарлар махсулотлар жадвалига кўшилди!, Насиядаги махсулотлар кўриб чикилмокда!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Debtor jadvalidan debtorlarni ma'lumotlarini olamiz
            string queryDebtor = "select * from debtor";
            tbDebtor = new DataTable();
            objDBAccess.readDatathroughAdapter(queryDebtor, tbDebtor);
            managerDebtor = (CurrencyManager)BindingContext[tbDebtor];
            int countDebtor = managerDebtor.Count;
            managerDebtor.Position = 0;
            tbCartDebt = new DataTable();
            string debtor_id = "", debtDifference="", debtUmumiyQarz="", first="", given_quan="", total="", tul_miq="", tul_sum="",qol_miq="",qol_sum="", diff="" ;
            string old_price = "";
            string recieveBarcode = "", RecievePrice="";
            int CountRecieve1 = managerFakturaItem.Count;
            managerFakturaItem.Position = 0;
            for(int i = 0; i<CountRecieve1; i++)
            {
                recieveBarcode = tbFakturaItem.Rows[managerFakturaItem.Position]["Штрих_код"].ToString();
                RecievePrice = tbFakturaItem.Rows[managerFakturaItem.Position]["Нархи"].ToString();

                for (int j = 0; j < countDebtor; j++)
                {
                    debtor_id = tbDebtor.Rows[managerDebtor.Position]["id"].ToString();
                    debtDifference = tbDebtor.Rows[managerDebtor.Position]["difference"].ToString(); //
                    if (debtDifference.IndexOf(',') > -1)
                    {
                        int index = debtDifference.IndexOf(',');
                        string first_debtDifference = debtDifference.Substring(0, index);
                        string last_debtDifference = debtDifference.Substring(index + 1);
                        debtDifference = first_debtDifference + "." + last_debtDifference;
                    }
                    debtUmumiyQarz = tbDebtor.Rows[managerDebtor.Position]["umumiy_qarz"].ToString(); //
                    if (debtUmumiyQarz.IndexOf(',') > -1)
                    {
                        int index = debtUmumiyQarz.IndexOf(',');
                        string first_debtUmumiyQarz = debtUmumiyQarz.Substring(0, index);
                        string last_debtUmumiyQarz = debtUmumiyQarz.Substring(index + 1);
                        debtUmumiyQarz = first_debtUmumiyQarz + "." + last_debtUmumiyQarz;
                    }
                    string queryCartdebt = "select * from cartdebt where cartdebt.debtor_id='" + debtor_id + "' and barcode='" + recieveBarcode + "' order by id desc";
                    objDBAccess.readDatathroughAdapter(queryCartdebt, tbCartDebt);
                    managerCartDebt = (CurrencyManager)BindingContext[tbCartDebt];
                    if (tbCartDebt.Rows.Count > 1) // bu maxsulot 1 tadan ko'p bo'lsa
                    {
                        first = tbCartDebt.Rows[0]["id"].ToString();
                        double all_givenQuantity = 0, all_total = 0, all_qolganMiqdor = 0, all_qolgamSumma = 0, all_tolanganMiqdor = 0, all_tolanganSumma=0, all_difference = 0, debt_difference = 0;
                        int CountCartDebt = managerCartDebt.Count;
                        managerCartDebt.Position = 0;
                        for (int k = 0; k < CountCartDebt; k++)
                        {
                            old_price = tbCartDebt.Rows[managerCartDebt.Position]["price"].ToString();
                            double Dold_price = double.Parse(old_price, CultureInfo.InvariantCulture);
                            double Dnew_price = double.Parse(RecievePrice, CultureInfo.InvariantCulture);
                            //Agar yangi narx katta bo'lsa cartdebt jadvalidagi qolgan_summa bilan farq ni update qilamiz
                            if(Dnew_price > Dold_price)
                            {
                                // berilgan miqdor
                                given_quan = tbCartDebt.Rows[managerCartDebt.Position]["given_quantity"].ToString(); //
                                if (qol_miq.IndexOf(',') > -1)
                                {
                                    int index = qol_miq.IndexOf(',');
                                    string first_qol_miq = qol_miq.Substring(0, index);
                                    string last_qol_miq = qol_miq.Substring(index + 1);
                                    qol_miq = first_qol_miq + "." + last_qol_miq;
                                }
                                double Dgiven_quantity = double.Parse(given_quan, CultureInfo.InvariantCulture);
                                all_givenQuantity += Dgiven_quantity;
                                
                                // jami summa
                                total = tbCartDebt.Rows[managerCartDebt.Position]["total"].ToString(); // 
                                if (total.IndexOf(',') > -1)
                                {
                                    int index = total.IndexOf(',');
                                    string first_total = total.Substring(0, index);
                                    string last_total = total.Substring(index + 1);
                                    total = first_total + "." + last_total;
                                }
                                double Dtotal = double.Parse(total, CultureInfo.InvariantCulture);
                                all_total += Dtotal;
                                
                                //qolgan summa
                                qol_sum = tbCartDebt.Rows[managerCartDebt.Position]["debt_price"].ToString(); //
                                if (qol_sum.IndexOf(',') > -1)
                                {
                                    int index = qol_sum.IndexOf(',');
                                    string first_qol_sum = qol_sum.Substring(0, index);
                                    string last_qol_sum = qol_sum.Substring(index + 1);
                                    qol_sum = first_qol_sum + "." + last_qol_sum;
                                }
                                double Dqol_sum = double.Parse(qol_sum, CultureInfo.InvariantCulture);
                                //all_qolgamSumma += Dqol_sum;

                                //to'langan miqdor
                                tul_miq = tbCartDebt.Rows[managerCartDebt.Position]["return_quantity"].ToString(); //
                                if (tul_miq.IndexOf(',') > -1)
                                {
                                    int index = tul_miq.IndexOf(',');
                                    string first_tul_miq = tul_miq.Substring(0, index);
                                    string last_tul_miq = tul_miq.Substring(index + 1);
                                    tul_miq = first_tul_miq + "." + last_tul_miq;
                                }
                                double Dtul_miq = double.Parse(tul_miq, CultureInfo.InvariantCulture);
                                all_tolanganMiqdor += Dtul_miq;

                                //to'langan summa
                                tul_sum = tbCartDebt.Rows[managerCartDebt.Position]["return_price"].ToString(); //
                                if (tul_sum.IndexOf(',') > -1)
                                {
                                    int index = tul_sum.IndexOf(',');
                                    string first_tul_sum = tul_sum.Substring(0, index);
                                    string last_tul_sum = tul_sum.Substring(index + 1);
                                    tul_sum = first_tul_sum + "." + last_tul_sum;
                                }
                                double Dtul_sum = double.Parse(tul_sum, CultureInfo.InvariantCulture);
                                all_tolanganSumma += Dtul_sum;

                                //qolgan_summa, difference
                                qol_miq = tbCartDebt.Rows[managerCartDebt.Position]["debt_quantity"].ToString(); // avvalgi qolgan summa
                                if (qol_miq.IndexOf(',') > -1)
                                {
                                    int index = qol_miq.IndexOf(',');
                                    string first_qol_miq = qol_miq.Substring(0, index);
                                    string last_qol_miq = qol_miq.Substring(index + 1);
                                    qol_miq = first_qol_miq + "." + last_qol_miq;
                                }
                                double Dqol_miq = double.Parse(qol_miq, CultureInfo.InvariantCulture);
                                all_qolganMiqdor += Dqol_miq;

                                diff = tbCartDebt.Rows[managerCartDebt.Position]["difference"].ToString();  // avvalgi difference
                                if (diff.IndexOf(',') > -1)
                                {
                                    int index = diff.IndexOf(',');
                                    string first_diff = diff.Substring(0, index);
                                    string last_diff = diff.Substring(index + 1);
                                    diff = first_diff + "." + last_diff;
                                }
                                double Ddiff = double.Parse(diff, CultureInfo.InvariantCulture);
                                //all_difference += Ddiff;

                                double Result_qol_sum = Dnew_price * Dqol_miq;
                                all_qolgamSumma += Result_qol_sum;

                                double new_diff = (Dnew_price - Dold_price) * Dqol_miq;
                                double result_diff = Ddiff + new_diff;
                                all_difference += result_diff;
                                debt_difference += new_diff;
                            }
                            managerCartDebt.Position++;
                        }
                        all_total += debt_difference;
                        cmdUpdateCartDebt = new MySqlCommand("update cartdebt set price='"+RecievePrice+"',given_quantity='" + DoubleToStr(all_givenQuantity.ToString()) + "', total='" + DoubleToStr(all_total.ToString()) + "', return_quantity='" + DoubleToStr(all_tolanganMiqdor.ToString()) + "', return_price='" + DoubleToStr(all_tolanganSumma.ToString()) + "', debt_quantity='" + DoubleToStr(all_qolganMiqdor.ToString()) + "', debt_price='" + DoubleToStr(all_qolgamSumma.ToString()) + "', difference='" + DoubleToStr(all_difference.ToString()) + "' where id='"+first+"'");
                        objDBAccess.executeQuery(cmdUpdateCartDebt);
                        cmdUpdateCartDebt.Dispose();

                        cmdUpdateCartDebt = new MySqlCommand("delete from cartdebt where barcode='" + recieveBarcode + "' and debtor_id='" + debtor_id + "' and id!='" + first + "'");
                        objDBAccess.executeQuery(cmdUpdateCartDebt);
                        cmdUpdateCartDebt.Dispose();
                        //
                        double DdebtDifference = double.Parse(debtDifference, CultureInfo.InvariantCulture);
                        double DdebtUmumiyQarz = double.Parse(debtUmumiyQarz, CultureInfo.InvariantCulture);

                        double result_debtDifference = DdebtDifference + debt_difference;
                        string str_result_debtDifference = result_debtDifference.ToString(); //
                        if (str_result_debtDifference.IndexOf(',') > -1)
                        {
                            int index = str_result_debtDifference.IndexOf(',');
                            string first_str_result_debtDifference = str_result_debtDifference.Substring(0, index);
                            string last_str_result_debtDifference = str_result_debtDifference.Substring(index + 1);
                            str_result_debtDifference = first_str_result_debtDifference + "." + last_str_result_debtDifference;
                        }

                        double result_debtUmumiyQarz = DdebtUmumiyQarz + debt_difference;
                        string str_result_debtUmumiyQarz = result_debtUmumiyQarz.ToString(); //
                        if (str_result_debtUmumiyQarz.IndexOf(',') > -1)
                        {
                            int index = str_result_debtUmumiyQarz.IndexOf(',');
                            string first_str_result_debtUmumiyQarz = str_result_debtUmumiyQarz.Substring(0, index);
                            string last_str_result_debtUmumiyQarz = str_result_debtUmumiyQarz.Substring(index + 1);
                            str_result_debtUmumiyQarz = first_str_result_debtUmumiyQarz + "." + last_str_result_debtUmumiyQarz;
                        }
                        cmdUpdateDebtor = new MySqlCommand("update debtor set umumiy_qarz='" + str_result_debtUmumiyQarz + "', difference='" + str_result_debtDifference + "', status_difference=1 where id='"+debtor_id+"'");
                        objDBAccess.executeQuery(cmdUpdateDebtor);
                        cmdUpdateDebtor.Dispose();
                    }
                    else if (tbCartDebt.Rows.Count == 1) // 1 ta bo'lsa
                    {
                        old_price = tbCartDebt.Rows[managerCartDebt.Position]["price"].ToString();
                        double Dold_price = double.Parse(old_price, CultureInfo.InvariantCulture);
                        double Dnew_price = double.Parse(RecievePrice, CultureInfo.InvariantCulture);
                        if(Dnew_price > Dold_price)
                        {
                            total = tbCartDebt.Rows[managerCartDebt.Position]["total"].ToString(); // jamisumma
                            total = DoubleToStr(total);
                            qol_miq = tbCartDebt.Rows[managerCartDebt.Position]["debt_quantity"].ToString(); // avvalgi qolgan summa
                            if (qol_miq.IndexOf(',') > -1)
                            {
                                int index = qol_miq.IndexOf(',');
                                string first_qol_miq = qol_miq.Substring(0, index);
                                string last_qol_miq = qol_miq.Substring(index + 1);
                                qol_miq = first_qol_miq + "." + last_qol_miq;
                            }
                            double Dqol_miq = double.Parse(qol_miq, CultureInfo.InvariantCulture);

                            diff = tbCartDebt.Rows[managerCartDebt.Position]["difference"].ToString();  // avvalgi difference
                            if (diff.IndexOf(',') > -1)
                            {
                                int index = diff.IndexOf(',');
                                string first_diff = diff.Substring(0, index);
                                string last_diff = diff.Substring(index + 1);
                                diff = first_diff + "." + last_diff;
                            }

                            double Ddiff = double.Parse(diff, CultureInfo.InvariantCulture);

                            double Result_qol_sum = Dnew_price * Dqol_miq;
                            string str_Result_qol_sum = Result_qol_sum.ToString(); // 
                            if(str_Result_qol_sum.IndexOf(',') > -1)
                            {
                                int index = str_Result_qol_sum.IndexOf(',');
                                string first_str_Result_qol_sum = str_Result_qol_sum.Substring(0, index);
                                string last_str_Result_qol_sum = str_Result_qol_sum.Substring(index + 1);
                                str_Result_qol_sum = first_str_Result_qol_sum + "." + last_str_Result_qol_sum;
                            }

                            double new_diff = (Dnew_price - Dold_price) * Dqol_miq;
                            double result_diff = Ddiff + new_diff;
                            string str_result_diff = result_diff.ToString(); //
                            if(str_result_diff.IndexOf(',') > -1)
                            {
                                int index = str_result_diff.IndexOf(',');
                                string first_str_result_diff = str_result_diff.Substring(0, index);
                                string last_str_result_diff = str_result_diff.Substring(index + 1);
                                str_result_diff = first_str_result_diff + "." + last_str_result_diff;
                            }
                            double Dtotal = double.Parse(total);
                            double result_total = Dtotal + new_diff;
                            cmdUpdateCartDebt = new MySqlCommand("update cartdebt set price='"+RecievePrice+"',debt_price='" + str_Result_qol_sum + "', difference='" + str_result_diff + "', total='"+DoubleToStr(result_total.ToString())+"' where id='" + tbCartDebt.Rows[0]["id"].ToString() + "'");
                            objDBAccess.executeQuery(cmdUpdateCartDebt);
                            cmdUpdateCartDebt.Dispose();

                            double DdebtDifference = double.Parse(debtDifference, CultureInfo.InvariantCulture);
                            double DdebtUmumiyQarz = double.Parse(debtUmumiyQarz, CultureInfo.InvariantCulture);

                            double result_debtDifference = DdebtDifference + new_diff;
                            string str_result_debtDifference = result_debtDifference.ToString(); //
                            if (str_result_debtDifference.IndexOf(',') > -1)
                            {
                                int index = str_result_debtDifference.IndexOf(',');
                                string first_str_result_debtDifference = str_result_debtDifference.Substring(0, index);
                                string last_str_result_debtDifference = str_result_debtDifference.Substring(index + 1);
                                str_result_debtDifference = first_str_result_debtDifference + "." + last_str_result_debtDifference;
                            }

                            double result_debtUmumiyQarz = DdebtUmumiyQarz + new_diff;
                            string str_result_debtUmumiyQarz = result_debtUmumiyQarz.ToString(); //
                            if (str_result_debtUmumiyQarz.IndexOf(',') > -1)
                            {
                                int index = str_result_debtUmumiyQarz.IndexOf(',');
                                string first_str_result_debtUmumiyQarz = str_result_debtUmumiyQarz.Substring(0, index);
                                string last_str_result_debtUmumiyQarz = str_result_debtUmumiyQarz.Substring(index + 1);
                                str_result_debtUmumiyQarz = first_str_result_debtUmumiyQarz + "." + last_str_result_debtUmumiyQarz;
                            }
                            cmdUpdateDebtor = new MySqlCommand("update debtor set umumiy_qarz='" + str_result_debtUmumiyQarz + "', difference='" + str_result_debtDifference + "', status_difference=1 where id='" + debtor_id + "'");
                            objDBAccess.executeQuery(cmdUpdateDebtor);
                            cmdUpdateDebtor.Dispose();
                        }
                    }
                    tbCartDebt.Clear();
                    tbCartDebt.Dispose();
                    managerDebtor.Position++;
                }

                managerFakturaItem.Position++;

            }
            MessageBox.Show("Насиядаги савдолар муваффакиятли кўриб чикилди!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowRecieve();
        }

        private void dbgridFaktura_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dbgridFaktura.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
