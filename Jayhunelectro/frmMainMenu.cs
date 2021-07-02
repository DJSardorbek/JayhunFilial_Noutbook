using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Jayhunelectro
{
    public partial class frmMainMenu : MetroFramework.Forms.MetroForm
    
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }
        DataTable tbShopId;
        CurrencyManager managertb;
        public static MySqlCommand cmdShopId;
        public static string filial_id = "",filial="";
        public static DataTable tbFilial_id;
        public static bool Recieve = false;
        public static string header = "", headerCash = "";
        public static string footer = "", footerCash = "";
        DBAccess objDBAccess = new DBAccess();
        public Form activateForm = null;


        public void openChildForm(Form childForm)
        {
            if (activateForm != null)
                activateForm.Close();
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMenu.Controls.Add(childForm);
            panelMenu.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            if (frmLogin.staff_id == "1")
            {
                btnSales.Visible = false;
                btnWaiting.Visible = false;
                btnCashDesk.Visible = false;
                btnSoldList.Location = new Point(0, 83);
                btnDebt.Location = new Point(0, 166);
                btnRecieveFilial.Location = new Point(0, 249);
                btnChiqish.Location = new Point(0, 332);
            }
            if(frmLogin.staff_id=="2") //Filial sotuvchisi
            {
                btnSales.Location = new Point(0, 83);
                btnWaiting.Location = new Point(0,166);
                btnCashDesk.Visible = false;
                btnSoldList.Visible = false;
                btnDebt.Visible = false;
                btnRecieveFilial.Visible = false;
                btnChiqish.Location = new Point(0,249);
            }
            if(frmLogin.staff_id=="3") // Kassir
            {
                btnSales.Visible = false;
                btnWaiting.Visible = false;
                btnCashDesk.Location = new Point(0,83);
                btnSoldList.Location = new Point(0,166);
                btnDebt.Location = new Point(0,249);
                btnRecieveFilial.Visible = false;
                btnChiqish.Location = new Point(0, 332);
            }

            try
            {
                string ShopId = "select * from shopId where password='"+frmLogin.password1+"'";
                tbShopId = new DataTable();
                objDBAccess.readDatathroughAdapter(ShopId, tbShopId);
                if(tbShopId.Rows.Count > 0)
                {
                    frmSales.shopID = int.Parse(tbShopId.Rows[0]["shop_id"].ToString());
                    if (int.Parse(tbShopId.Rows[0]["shop_id"].ToString()) != 0)
                    { 
                        frmSales.shop = true;
                        cmdShopId = new MySqlCommand("update shopId set mac_address='" + frmLogin.mac_address + "' where password='" + frmLogin.password1 + "'");
                        objDBAccess.executeQuery(cmdShopId);
                        cmdShopId.Dispose();
                    }
                    else
                    {
                        frmSales.shop = false;
                    }
                }
                tbShopId.Clear();
                tbShopId.Dispose();
            }
            catch(Exception ex)
            {

            }

            string queryFilial_id = "select * from filial";
            tbFilial_id = new DataTable();
            objDBAccess.readDatathroughAdapter(queryFilial_id, tbFilial_id);
            filial_id = tbFilial_id.Rows[0]["id"].ToString();
            filial = tbFilial_id.Rows[0]["name"].ToString();
            tbFilial_id.Dispose();

            string queryProfil = "select * from staff where id='" + frmLogin.staff_id + "'";
            DataTable tbProfil = new DataTable();
            objDBAccess.readDatathroughAdapter(queryProfil, tbProfil);
            lblProfil.Text = tbProfil.Rows[0]["staff"].ToString();
            tbProfil.Clear();
            tbProfil.Dispose();

            lblUser.Text = frmLogin.sellar;
            frmCheck frmCheck = new frmCheck();
            header = frmCheck.txtHeader.Text;
            footer = frmCheck.txtFooter.Text;
            frmCheck.Dispose();
            frmCashCheck frmCash = new frmCashCheck();
            headerCash = frmCash.txtHeader.Text;
            footerCash = frmCash.txtFooter.Text;
            frmCash.Dispose();

            string send = "select * from send";
            DataTable tbSend = new DataTable();
            objDBAccess.readDatathroughAdapter(send, tbSend);
            if(tbSend.Rows.Count > 0)
            {
                string password = tbSend.Rows[0]["password"].ToString();
                if (password == frmLogin.password1)
                {
                    TimerSend.Enabled = true;
                }
            }
            tbSend.Dispose();

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new SoldList());
            lblDisplay.Text = btnSoldList.Text;
            btnSales.BackColor = Color.FromArgb(30, 31, 68);
            btnMenu.BackColor = Color.FromArgb(30, 31, 68);
            btnWaiting.BackColor = Color.FromArgb(30, 31, 68);
            btnDebt.BackColor = Color.FromArgb(30, 31, 68);
            btnSoldList.BackColor = Color.FromArgb(75, 158, 253);
            btnRecieveFilial.BackColor = Color.FromArgb(30, 31, 68);
            btnChiqish.BackColor = Color.FromArgb(30, 31, 68);
            btnCashDesk.BackColor = Color.FromArgb(30, 31, 68);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Close();
        }

      
        private void iconButton5_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDebtList());
            lblDisplay.Text = btnDebt.Text;
            btnSales.BackColor = Color.FromArgb(30, 31, 68);
            btnMenu.BackColor = Color.FromArgb(30, 31, 68);
            btnWaiting.BackColor = Color.FromArgb(30, 31, 68);
            btnDebt.BackColor = Color.FromArgb(75, 158, 253);
            btnSoldList.BackColor = Color.FromArgb(30, 31, 68);
            btnRecieveFilial.BackColor = Color.FromArgb(30, 31, 68);
            btnChiqish.BackColor = Color.FromArgb(30, 31, 68);
            btnCashDesk.BackColor = Color.FromArgb(30, 31, 68);
        }

        public void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            string queryShopId = "select * from shopId where password='"+frmLogin.password1+"'";
            tbShopId = new DataTable();
            objDBAccess.readDatathroughAdapter(queryShopId, tbShopId);
            if(tbShopId.Rows.Count > 0)
            {
                cmdShopId = new MySqlCommand("update shopId set shop_id='" + frmSales.shopID + "' where password='"+frmLogin.password1+"'");
                objDBAccess.executeQuery(cmdShopId);
            }
            else
            {
                string queryId = "select * from shopid order by id desc limit 1";
                DataTable tbSId = new DataTable();
                objDBAccess.readDatathroughAdapter(queryId, tbSId);
                if (tbSId.Rows.Count == 0)
                {
                    cmdShopId = new MySqlCommand("insert into shopId values(1,'" + frmSales.shopID + "','" + frmLogin.mac_address + "','" + frmLogin.password1 + "')");
                    objDBAccess.executeQuery(cmdShopId);
                }
                else
                {
                    cmdShopId = new MySqlCommand("insert into shopId (shop_id,mac_address,password) values('" + frmSales.shopID + "','" + frmLogin.mac_address + "','"+frmLogin.password1+"')");
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
            if(activateForm != null)
            {
                activateForm.Close();
                activateForm = null;
            }
            frmSales.shopID = 0;
            frmSales.shop = false;
            //Close();
        }

        int esc = 0;

        private void frmMainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                esc++;
                if(esc == 2)
                {
                    Close();
                    e.SuppressKeyPress = true;
                }
            }
            if (btnSales.BackColor == Color.FromArgb(75, 158, 253))
            {
                frmSales sales = new frmSales();
                if(e.KeyCode == Keys.F5)
                {
                    sales.moveBasketToolStripMenuItem_Click(sender, e);
                }
                if(e.KeyCode == Keys.F6)
                {
                    sales.iconButton3_Click(sender , e);
                }
                if(e.KeyCode == Keys.F9)
                {
                    btnWaiting_Click(sender, e);
                }
                if(e.KeyCode == Keys.F10)
                {
                    sales.iconButton5_Click(sender ,e);
                }
                if(e.KeyCode == Keys.F2)
                {
                    sales.btnCash_Click(sender, e);
                }
            }
            if(btnWaiting.BackColor == Color.FromArgb(75, 158, 253))
            {
                frmWaiting waiting = new frmWaiting();
                if (e.KeyCode == Keys.F5)
                {
                    waiting.button1_Click(sender, e);
                    btnSales_Click(sender, e);
                }
                if(e.KeyCode == Keys.F10)
                {
                    waiting.button2_Click(sender, e);
                }
            }
            if(btnDebt.BackColor == Color.FromArgb(75, 158, 253))
            {
                frmDebtList debtList = new frmDebtList();
                if(e.KeyCode == Keys.F2 && debtList.tabControl1.SelectedIndex == 0)
                {
                    debtList.тўлашToolStripMenuItem_Click(sender, e);
                }
            }
            if(btnSoldList.BackColor == Color.FromArgb(75, 158, 253))
            {
                SoldList soldList = new SoldList();
                if(e.KeyCode == Keys.F10 && soldList.tabControl1.SelectedIndex == 0)
                {
                    soldList.btnReturn_Click(sender, e);
                }
            }
            if(btnCashDesk.BackColor == Color.FromArgb(75, 158, 253))
            {
                frmCashDesk cashDesk = new frmCashDesk();
                if(e.KeyCode == Keys.F2)
                {
                    cashDesk.btnTulov_Click(sender, e);
                }
                if(e.KeyCode == Keys.F8)
                {
                    cashDesk.btnNasiya_Click(sender, e);
                }
                if(e.KeyCode == Keys.F10)
                {
                    cashDesk.btnCancel_Click(sender, e);
                }
            }
            
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
                panel1.Dock = DockStyle.None; 
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Bars;
            }
            else
            {
                panel1.Visible = true;
                panel1.Dock = DockStyle.Left;
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            }
        }

        public void btnSales_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSales());
            lblDisplay.Text = btnSales.Text;
            btnSales.BackColor = Color.FromArgb(75, 158, 253);
            btnMenu.BackColor = Color.FromArgb(30, 31, 68);
            btnWaiting.BackColor = Color.FromArgb(30, 31, 68);
            btnDebt.BackColor = Color.FromArgb(30, 31, 68);
            btnSoldList.BackColor = Color.FromArgb(30, 31, 68);
            btnRecieveFilial.BackColor = Color.FromArgb(30, 31, 68);
            btnChiqish.BackColor = Color.FromArgb(30, 31, 68);
            btnCashDesk.BackColor = Color.FromArgb(30, 31, 68);
        }

        public void btnWaiting_Click(object sender, EventArgs e)
        {
            openChildForm(new frmWaiting());
            lblDisplay.Text = btnWaiting.Text;
            btnSales.BackColor = Color.FromArgb(30, 31, 68);
            btnMenu.BackColor = Color.FromArgb(30, 31, 68);
            btnWaiting.BackColor = Color.FromArgb(75, 158, 253);
            btnDebt.BackColor = Color.FromArgb(30, 31, 68);
            btnSoldList.BackColor = Color.FromArgb(30, 31, 68);
            btnRecieveFilial.BackColor = Color.FromArgb(30, 31, 68);
            btnChiqish.BackColor = Color.FromArgb(30, 31, 68);
            btnCashDesk.BackColor = Color.FromArgb(30, 31, 68);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if(activateForm !=null)
            activateForm.Close();
            lblDisplay.Text = btnMenu.Text;
            btnSales.BackColor = Color.FromArgb(30, 31, 68);
            btnMenu.BackColor = Color.FromArgb(75, 158, 253);
            btnWaiting.BackColor = Color.FromArgb(30, 31, 68);
            btnDebt.BackColor = Color.FromArgb(30, 31, 68);
            btnSoldList.BackColor = Color.FromArgb(30, 31, 68);
            btnRecieveFilial.BackColor = Color.FromArgb(30, 31, 68);
            btnChiqish.BackColor = Color.FromArgb(30, 31, 68);
            btnCashDesk.BackColor = Color.FromArgb(30, 31, 68);
        }

        private void btnRecieveFilial_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTovarQabuli());
            lblDisplay.Text = btnRecieveFilial.Text;
            btnRecieveFilial.BackColor = Color.FromArgb(75, 158, 253);
            btnCashDesk.BackColor = Color.FromArgb(30, 31, 68);
            btnSales.BackColor = Color.FromArgb(30, 31, 68);
            btnMenu.BackColor = Color.FromArgb(30, 31, 68);
            btnWaiting.BackColor = Color.FromArgb(30, 31, 68);
            btnDebt.BackColor = Color.FromArgb(30, 31, 68);
            btnSoldList.BackColor = Color.FromArgb(30, 31, 68);
            btnChiqish.BackColor = Color.FromArgb(30, 31, 68);
        }

        private void btnCashDesk_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCashDesk());
            lblDisplay.Text = btnCashDesk.Text;
            btnCashDesk.BackColor = Color.FromArgb(75, 158, 253);
            btnSales.BackColor = Color.FromArgb(30, 31, 68);
            btnMenu.BackColor = Color.FromArgb(30, 31, 68);
            btnWaiting.BackColor = Color.FromArgb(30, 31, 68);
            btnDebt.BackColor = Color.FromArgb(30, 31, 68);
            btnSoldList.BackColor = Color.FromArgb(30, 31, 68);
            btnRecieveFilial.BackColor = Color.FromArgb(30, 31, 68);
            btnChiqish.BackColor = Color.FromArgb(30, 31, 68);
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
                        response = result.StatusCode.ToString();
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

        public static CurrencyManager managerSoldShop, managerDebtShop, managerMixShop, managerPayHistory, managerDebtRetPro, managerSoldRetPro;
        public static MySqlCommand cmdSendShop, cmdSendPayHistory, cmdSendReturnProduct, cmdChangeDebtor;

        private void frmMainMenu_Shown(object sender, EventArgs e)
        {
            
        }

        private void Soat_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblSoat.Text = dt.ToString("dd - MMMM, yyyy hh:mm:ss");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Jayhun Electro\nJayhun Electro\n*****************", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
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
        
        public static DataTable tbSoldShop, tbSendPayHistory, tbSendReturnProduct;
        public static DataTable tbDebtShop, tbDebtDebtor, tbMixShop, tbPayDebtor;
        public static DataTable tbSoldRetPro, tbSoldRetDebtor, tbDebtRetPro, tbDebtRetDebtor, tbChangeDebtor;
        public static CurrencyManager managerChangeDebtor;
        public static bool send_finish = true;
        private void TimerSend_Tick(object sender, EventArgs e)
        {
            if(send_finish)
            {
                button1_Click(sender, e);
            }
        }
        
        //Savdoni internetga jo'natish uchun
        public void button1_Click(object sender, EventArgs e)
        {
            send_finish = false;
            //Nasiyasiz savdolar uchun
            string querySoldShop = "select * from shop where status_tulov = 1 and debt = 0 and status_server = 0";
            tbSoldShop = new DataTable();
            objDBAccess.readDatathroughAdapter(querySoldShop, tbSoldShop);
            managerSoldShop = (CurrencyManager)BindingContext[tbSoldShop];
            if (managerSoldShop.Count > 0)
            {
                managerSoldShop.Position = 0;
                int CountSoldShop = managerSoldShop.Count;
                string jamisumma = "", naqd = "", plastik = "", sellar_id = ""; //shop jadvali
                for (int i = 0; i < CountSoldShop; i++)
                {
                    jamisumma = tbSoldShop.Rows[managerSoldShop.Position]["jamisumma"].ToString();//
                    if (jamisumma.IndexOf(',') > -1)
                    {
                        int index = jamisumma.IndexOf(',');
                        string first_jamisumma = jamisumma.Substring(0, index);
                        string last_jamisumma = jamisumma.Substring(index + 1);
                        jamisumma = first_jamisumma + "." + last_jamisumma;
                    }
                    naqd = tbSoldShop.Rows[managerSoldShop.Position]["naqd"].ToString();//
                    if (naqd.IndexOf(',') > -1)
                    {
                        int index = naqd.IndexOf(',');
                        string first_naqd = naqd.Substring(0, index);
                        string last_naqd = naqd.Substring(index + 1);
                        naqd = first_naqd + "." + last_naqd;
                    }
                    plastik = tbSoldShop.Rows[managerSoldShop.Position]["plastik"].ToString();//
                    if (plastik.IndexOf(',') > -1)
                    {
                        int index = plastik.IndexOf(',');
                        string first_plastik = plastik.Substring(0, index);
                        string last_plastik = plastik.Substring(index + 1);
                        plastik = first_plastik + "." + last_plastik;
                    }
                    sellar_id = tbSoldShop.Rows[managerSoldShop.Position]["sellar_id"].ToString();
                    
                    Uri u = new Uri("http://jayhun.backoffice.uz/ipa/shop/add/");

                    var payload = "{\"summa\": \"" + jamisumma + "\",\"naqd\": \"" + naqd + "\",\"plastik\": \"" + plastik + "\",\"saler\": \"" + sellar_id + "\",\"filial\": \"" + filial_id + "\"}";
                    //MessageBox.Show(payload);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result == "Error!")
                    {
                        lblSend.Text = "Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!";
                    }
                    else if (t.Result != "Error!")
                    {
                        lblSend.Text = "Савдо жўнатиломокда...";
                        cmdSendShop = new MySqlCommand("update shop set status_server=1 where id='" + tbSoldShop.Rows[managerSoldShop.Position]["id"] + "'");
                        objDBAccess.executeQuery(cmdSendShop);
                        cmdSendShop.Dispose();
                    }
                    managerSoldShop.Position++;
                }
            }
            else
            {
                lblSend.Text = "Савдо жўнатилган...";
            }
            tbSoldShop.Clear();
            tbSoldShop.Dispose();

            //Nasiya aralash savdo uchun
            string queryMixShop = "select * from shop where status_tulov = 1 and debt = 1 and status_server = 0";
            tbMixShop = new DataTable();
            objDBAccess.readDatathroughAdapter(queryMixShop, tbMixShop);
            managerMixShop = (CurrencyManager)BindingContext[tbMixShop];
            if(managerMixShop.Count > 0)
            {
                managerMixShop.Position = 0;
                int CountMixShop = managerMixShop.Count;
                string jamisumma = "",naqd="",plastik="", nasiya = "", sellar_id = ""; //shop jadvali
                string fio = "", phone1 = "", debts = "", difference = ""; // debtor va debt jadvali
                for (int i = 0; i < CountMixShop; i++)
                {
                    jamisumma = tbMixShop.Rows[managerMixShop.Position]["jamisumma"].ToString();//
                    if (jamisumma.IndexOf(',') > -1)
                    {
                        int index = jamisumma.IndexOf(',');
                        string first_jamisumma = jamisumma.Substring(0, index);
                        string last_jamisumma = jamisumma.Substring(index + 1);
                        jamisumma = first_jamisumma + "." + last_jamisumma;
                    }
                    naqd = tbMixShop.Rows[managerMixShop.Position]["naqd"].ToString();//
                    if (naqd.IndexOf(',') > -1)
                    {
                        int index = naqd.IndexOf(',');
                        string first_naqd = naqd.Substring(0, index);
                        string last_naqd = naqd.Substring(index + 1);
                        naqd = first_naqd + "." + last_naqd;
                    }
                    plastik = tbMixShop.Rows[managerMixShop.Position]["plastik"].ToString();//
                    if (plastik.IndexOf(',') > -1)
                    {
                        int index = plastik.IndexOf(',');
                        string first_plastik = plastik.Substring(0, index);
                        string last_plastik = plastik.Substring(index + 1);
                        plastik = first_plastik + "." + last_plastik;
                    }
                    nasiya = tbMixShop.Rows[managerMixShop.Position]["nasiya"].ToString();//
                    if (nasiya.IndexOf(',') > -1)
                    {
                        int index = nasiya.IndexOf(',');
                        string first_nasiya = nasiya.Substring(0, index);
                        string last_nasiya = nasiya.Substring(index + 1);
                        nasiya = first_nasiya + "." + last_nasiya;
                    }
                    sellar_id = tbMixShop.Rows[managerMixShop.Position]["sellar_id"].ToString();

                    string queryDebtDebtor = "select debtor.mijoz_fish, debtor.tel_1, debtor.umumiy_qarz, debtor.difference, debt.return_date from debtor inner join debt on debtor.id = debt.debtor_id where debt.shop_id='" + tbMixShop.Rows[managerMixShop.Position]["id"] + "'";
                    tbDebtDebtor = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebtDebtor, tbDebtDebtor);
                    fio = tbDebtDebtor.Rows[0]["mijoz_fish"].ToString();
                    phone1 = tbDebtDebtor.Rows[0]["tel_1"].ToString();
                    debts = tbDebtDebtor.Rows[0]["umumiy_qarz"].ToString();
                    difference = tbDebtDebtor.Rows[0]["difference"].ToString();
                    tbDebtDebtor.Clear();
                    tbDebtDebtor.Dispose();

                    Uri u = new Uri("http://jayhun.backoffice.uz/ipa/shop/add/");

                    var payload = "{\"summa\": \"" + jamisumma + "\",\"naqd\": \""+naqd+"\",\"plastik\": \""+plastik+"\",\"nasiya\": \"" + nasiya + "\",\"saler\": \"" + sellar_id + "\",\"filial\": \"" + filial_id + "\",\"fio\": \"" + fio + "\",\"phone1\": \"" + phone1 + "\",\"debts\": \"" + debts + "\",\"difference\": \"" + difference + "\"}";
                    //MessageBox.Show(payload);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result == "Error!")
                    {
                        lblSend.Text = "Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!";
                    }
                    else if (t.Result != "Error!")
                    {
                        lblSend.Text = "Савдо жўнатиломокда...";
                        cmdSendShop = new MySqlCommand("update shop set status_server=1 where id='" + tbMixShop.Rows[managerMixShop.Position]["id"] + "'");
                        objDBAccess.executeQuery(cmdSendShop);
                        cmdSendShop.Dispose();
                    }
                    managerMixShop.Position++;
                }
            }
            else
            {
                lblSend.Text = "Савдо жўнатилган...";
            }
            tbMixShop.Clear();
            tbMixShop.Dispose();

            //Nasiya uchun
            string queryDebtShop = "select * from shop where status_tulov = 0 and debt = 1 and status_server = 0";
            tbDebtShop = new DataTable();
            objDBAccess.readDatathroughAdapter(queryDebtShop, tbDebtShop);
            managerDebtShop = (CurrencyManager)BindingContext[tbDebtShop];
            if(managerDebtShop.Count > 0)
            {
                managerDebtShop.Position = 0;
                int CountDebtShop = managerDebtShop.Count;
                string jamisumma = "",nasiya="", sellar_id = ""; //shop jadvali
                string fio = "", phone1 = "", debts="", difference=""; // debtor va debt jadvali
                for(int i = 0; i < CountDebtShop; i++ )
                {
                    jamisumma = tbDebtShop.Rows[managerDebtShop.Position]["jamisumma"].ToString();//
                    if (jamisumma.IndexOf(',') > -1)
                    {
                        int index = jamisumma.IndexOf(',');
                        string first_jamisumma = jamisumma.Substring(0, index);
                        string last_jamisumma = jamisumma.Substring(index + 1);
                        jamisumma = first_jamisumma + "." + last_jamisumma;
                    }
                    
                    nasiya = tbDebtShop.Rows[managerDebtShop.Position]["nasiya"].ToString();//
                    if (nasiya.IndexOf(',') > -1)
                    {
                        int index = nasiya.IndexOf(',');
                        string first_nasiya = nasiya.Substring(0, index);
                        string last_nasiya = nasiya.Substring(index + 1);
                        nasiya = first_nasiya + "." + last_nasiya;
                    }
                    sellar_id = tbDebtShop.Rows[managerDebtShop.Position]["sellar_id"].ToString();
                    
                    string queryDebtDebtor = "select debtor.mijoz_fish, debtor.tel_1, debtor.umumiy_qarz, debtor.difference, debt.return_date from debtor inner join debt on debtor.id = debt.debtor_id where debt.shop_id='"+ tbDebtShop.Rows[managerDebtShop.Position]["id"] + "'";
                    tbDebtDebtor = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebtDebtor, tbDebtDebtor);
                    fio = tbDebtDebtor.Rows[0]["mijoz_fish"].ToString();
                    phone1 = tbDebtDebtor.Rows[0]["tel_1"].ToString();
                    debts = tbDebtDebtor.Rows[0]["umumiy_qarz"].ToString();
                    difference = tbDebtDebtor.Rows[0]["difference"].ToString();
                    tbDebtDebtor.Clear();
                    tbDebtDebtor.Dispose();

                    Uri u = new Uri("http://jayhun.backoffice.uz/ipa/shop/add/");

                    var payload = "{\"summa\": \"" + jamisumma + "\",\"naqd\": \"0\",\"plastik\": \"0\",\"nasiya\": \""+nasiya+"\",\"saler\": \"" + sellar_id + "\",\"filial\": \"" + filial_id + "\",\"fio\": \""+fio+"\",\"phone1\": \""+phone1+"\",\"debts\": \""+debts+"\",\"difference\": \""+difference+"\"}";
                    //MessageBox.Show(payload);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result == "Error!")
                    {
                        lblSend.Text = "Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!";
                    }
                    else if (t.Result != "Error!")
                    {
                        lblSend.Text = "Савдо жўнатиломокда...";
                        cmdSendShop = new MySqlCommand("update shop set status_server=1 where id='" + tbDebtShop.Rows[managerDebtShop.Position]["id"] + "'");
                        objDBAccess.executeQuery(cmdSendShop);
                        cmdSendShop.Dispose();
                    }
                    managerDebtShop.Position++;
                }
            }
            else
            {
                lblSend.Text = "Савдо жўнатилган...";
            }
            tbDebtShop.Clear();
            tbDebtShop.Dispose();
            
            //Payhistory uchun
            string queryPayHistory = "select * from payhistory where status_server = 0";
            tbSendPayHistory = new DataTable();
            objDBAccess.readDatathroughAdapter(queryPayHistory, tbSendPayHistory);
            managerPayHistory = (CurrencyManager)BindingContext[tbSendPayHistory];
            if(managerPayHistory.Count > 0)
            {
                managerPayHistory.Position = 0;
                int CountPayHistory = managerPayHistory.Count;
                string summa = ""; //payhistory jadvali
                string fio = "", phone1 = ""; // debtor va debt jadvali
                for (int i = 0; i < CountPayHistory; i++)
                {
                    summa = tbSendPayHistory.Rows[managerPayHistory.Position]["given_summa"].ToString();//
                    if (summa.IndexOf(',') > -1)
                    {
                        int index = summa.IndexOf(',');
                        string first_summa = summa.Substring(0, index);
                        string last_summa = summa.Substring(index + 1);
                        summa = first_summa + "." + last_summa;
                    }
                    string queryPayDebtor = "select debtor.mijoz_fish,debtor.tel_1 from debtor inner join payhistory on debtor.id = payhistory.debtor_id where debtor.id='"+tbSendPayHistory.Rows[managerPayHistory.Position]["debtor_id"]+"'";
                    tbPayDebtor = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryPayDebtor, tbPayDebtor);
                    fio = tbPayDebtor.Rows[0]["mijoz_fish"].ToString();
                    phone1 = tbPayDebtor.Rows[0]["tel_1"].ToString();
                    tbPayDebtor.Clear();
                    tbPayDebtor.Dispose();
                    Uri u = new Uri("http://jayhun.backoffice.uz/ipa/payhistory/add/");

                    var payload = "{\"fio\": \"" + fio + "\",\"phone1\": \"" + phone1+"\",\"summa\": \""+summa+"\",\"filial\": \"" + filial_id + "\"}";
                    //MessageBox.Show(payload);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result == "Error!")
                    {
                        lblSend.Text = "Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!";
                    }
                    else if (t.Result != "Error!")
                    {
                        lblSend.Text = "Савдо жўнатиломокда...";
                        cmdSendShop = new MySqlCommand("update payhistory set status_server=1 where id='" + tbSendPayHistory.Rows[managerPayHistory.Position]["id"] + "'");
                        objDBAccess.executeQuery(cmdSendShop);
                        cmdSendShop.Dispose();
                    }
                    managerPayHistory.Position++;
                }
            }
            else
            {
                lblSend.Text = "Савдо жўнатилган...";
            }
            tbSendPayHistory.Clear();
            tbSendPayHistory.Dispose();

            //ReturnProduct savdo uchun
            string queryReturnProduct = "select * from returnproduct where sold = 1 and status_server=0";
            tbSoldRetPro = new DataTable();
            objDBAccess.readDatathroughAdapter(queryReturnProduct, tbSoldRetPro);
            managerSoldRetPro = (CurrencyManager)BindingContext[tbSoldRetPro];
            if(managerSoldRetPro.Count > 0)
            {
                managerSoldRetPro.Position = 0;
                int CountSoldRetPro = managerSoldRetPro.Count;
                string product = "", return_quan = "", summa = "", difference = "", barcode=""; // returnproduct jadvali
                for(int i = 0; i<CountSoldRetPro; i++)
                {
                    product = tbSoldRetPro.Rows[managerSoldRetPro.Position]["product_id"].ToString();
                    barcode = tbSoldRetPro.Rows[managerSoldRetPro.Position]["barcode"].ToString();
                    return_quan = tbSoldRetPro.Rows[managerSoldRetPro.Position]["return_quantity"].ToString(); //
                    if (return_quan.IndexOf(',') > -1)
                    {
                        int index = return_quan.IndexOf(',');
                        string first_return_quan = return_quan.Substring(0, index);
                        string last_return_quan = return_quan.Substring(index + 1);
                        return_quan = first_return_quan + "." + last_return_quan;
                    }
                    summa = tbSoldRetPro.Rows[managerSoldRetPro.Position]["summa"].ToString(); //
                    if (summa.IndexOf(',') > -1)
                    {
                        int index = summa.IndexOf(',');
                        string first_summa = summa.Substring(0, index);
                        string last_summa = summa.Substring(index + 1);
                        summa = first_summa + "." + last_summa;
                    }
                    difference = tbSoldRetPro.Rows[managerSoldRetPro.Position]["difference"].ToString(); //
                    if (difference.IndexOf(',') > -1)
                    {
                        int index = difference.IndexOf(',');
                        string first_difference = difference.Substring(0, index);
                        string last_difference = difference.Substring(index + 1);
                        difference = first_difference + "." + last_difference;
                    }

                    Uri u = new Uri("http://jayhun.backoffice.uz/ipa/returnproduct/add/");

                    var payload = "{\"product\": \"" + product + "\",\"return_quan\": \"" + return_quan + "\",\"summa\": \"" + summa + "\",\"difference\": \""+ difference + "\",\"filial\": \"" + filial_id + "\",\"status\": \"0\",\"barcode\": \""+barcode+"\"}";
                    //MessageBox.Show(payload);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result == "Error!")
                    {
                        lblSend.Text = "Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!";
                    }
                    else if (t.Result != "Error!")
                    {
                        lblSend.Text = "Савдо жўнатиломокда...";
                        cmdSendShop = new MySqlCommand("update returnproduct set status_server=1 where id='" + tbSoldRetPro.Rows[managerSoldRetPro.Position]["id"] + "'");
                        objDBAccess.executeQuery(cmdSendShop);
                        cmdSendShop.Dispose();
                    }

                    managerSoldRetPro.Position++;
                }
            }
            else
            {
                lblSend.Text = "Савдо жўнатилган...";
            }
            tbSoldRetPro.Clear();
            tbSoldRetPro.Dispose();

            //ReturnProduct nasiya uchun
            string queryDebtRetPro = "select * from returnproduct where debt = 1 and status_server = 0";
            tbDebtRetPro = new DataTable();
            objDBAccess.readDatathroughAdapter(queryDebtRetPro, tbDebtRetPro);
            managerDebtRetPro = (CurrencyManager)BindingContext[tbDebtRetPro];
            if (managerDebtRetPro.Count > 0)
            {
                managerDebtRetPro.Position = 0;
                int CountDebtRetPro = managerDebtRetPro.Count;
                string product = "", return_quan = "", summa = "", difference = "", barcode=""; // returnproduct jadvali
                string fio = "", phone1 = "";
                for (int i = 0; i < CountDebtRetPro; i++)
                {
                    product = tbDebtRetPro.Rows[managerDebtRetPro.Position]["product_id"].ToString();
                    barcode = tbDebtRetPro.Rows[managerDebtRetPro.Position]["barcode"].ToString();
                    return_quan = tbDebtRetPro.Rows[managerDebtRetPro.Position]["return_quantity"].ToString(); //
                    if (return_quan.IndexOf(',') > -1)
                    {
                        int index = return_quan.IndexOf(',');
                        string first_return_quan = return_quan.Substring(0, index);
                        string last_return_quan = return_quan.Substring(index + 1);
                        return_quan = first_return_quan + "." + last_return_quan;
                    }
                    summa = tbDebtRetPro.Rows[managerDebtRetPro.Position]["summa"].ToString(); //
                    if (summa.IndexOf(',') > -1)
                    {
                        int index = summa.IndexOf(',');
                        string first_summa = summa.Substring(0, index);
                        string last_summa = summa.Substring(index + 1);
                        summa = first_summa + "." + last_summa;
                    }
                    difference = tbDebtRetPro.Rows[managerDebtRetPro.Position]["difference"].ToString(); //
                    if (difference.IndexOf(',') > -1)
                    {
                        int index = difference.IndexOf(',');
                        string first_difference = difference.Substring(0, index);
                        string last_difference = difference.Substring(index + 1);
                        difference = first_difference + "." + last_difference;
                    }

                    string queryDebtRetDebtor = "select debtor.mijoz_fish, debtor.tel_1 from debtor inner join debt on debtor.id = debt.debtor_id where debt.shop_id='" + tbDebtRetPro.Rows[managerDebtRetPro.Position]["shop_id"] + "'";
                    tbDebtRetDebtor = new DataTable();
                    objDBAccess.readDatathroughAdapter(queryDebtRetDebtor, tbDebtRetDebtor);
                    fio = tbDebtRetDebtor.Rows[0]["mijoz_fish"].ToString();
                    phone1 = tbDebtRetDebtor.Rows[0]["tel_1"].ToString();
                    tbDebtRetDebtor.Clear();
                    tbDebtRetDebtor.Dispose();
                    Uri u = new Uri("http://jayhun.backoffice.uz/ipa/returnproduct/add/");

                    var payload = "{\"product\": \"" + product + "\",\"return_quan\": \"" + return_quan + "\",\"summa\": \"" + summa + "\",\"difference\": \"" + difference + "\",\"filial\": \"" + filial_id + "\",\"status\": \"1\",\"fio\": \""+fio+"\",\"phone1\": \""+phone1+"\",\"barcode\": \""+barcode+"\"}";
                    //MessageBox.Show(payload);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result == "Error!")
                    {
                        lblSend.Text = "Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!";
                    }
                    else if (t.Result != "Error!")
                    {
                        lblSend.Text = "Савдо жўнатиломокда...";
                        cmdSendShop = new MySqlCommand("update returnproduct set status_server=1 where id='" + tbDebtRetPro.Rows[managerDebtRetPro.Position]["id"] + "'");
                        objDBAccess.executeQuery(cmdSendShop);
                        cmdSendShop.Dispose();
                    }

                    managerDebtRetPro.Position++;
                }
            }
            else
            {
                lblSend.Text = "Савдо жўнатилган...";
            }
            tbDebtRetPro.Clear();
            tbDebtRetPro.Dispose();

            //Nasiya o'zgarishi uchun
            string queryChangeDebtor = "select * from debtor where status_difference=1";
            tbChangeDebtor = new DataTable();
            objDBAccess.readDatathroughAdapter(queryChangeDebtor, tbChangeDebtor);
            managerChangeDebtor = (CurrencyManager)BindingContext[tbChangeDebtor];
            if(managerChangeDebtor.Count > 0)
            {
                managerChangeDebtor.Position = 0;
                int CountChangeDebtor = managerChangeDebtor.Count;
                string fio = "", phone1 = "", debts = "", difference = "";
                for(int i = 0; i<CountChangeDebtor; i++)
                {
                    fio = tbChangeDebtor.Rows[managerChangeDebtor.Position]["mijoz_fish"].ToString();
                    phone1 = tbChangeDebtor.Rows[managerChangeDebtor.Position]["tel_1"].ToString();
                    debts = tbChangeDebtor.Rows[managerChangeDebtor.Position]["umumiy_qarz"].ToString();
                    difference = tbChangeDebtor.Rows[managerChangeDebtor.Position]["difference"].ToString();

                    Uri u = new Uri("http://jayhun.backoffice.uz/ipa/debtor/up/");

                    var payload = "{\"fio\": \"" + fio + "\",\"phone1\": \"" + phone1 + "\",\"debts\": \"" + debts + "\",\"difference\": \"" + difference + "\"}";

                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var t = Task.Run(() => PostURI(u, content));
                    t.Wait();
                    if (t.Result == "Error!")
                    {
                        lblSend.Text = "Сэрвэр билан богланишда хатолик, илтимос интэрнэтни тэкширинг!";
                    }
                    else if (t.Result != "Error!")
                    {
                        lblSend.Text = "Савдо жўнатиломокда...";
                        cmdSendShop = new MySqlCommand("update debtor set status_difference = 0 where id='" + tbChangeDebtor.Rows[managerChangeDebtor.Position]["id"] + "'");
                        objDBAccess.executeQuery(cmdSendShop);
                        cmdSendShop.Dispose();
                    }
                    managerChangeDebtor.Position++;
                }
            }
            else
            {
                lblSend.Text = "Савдо жўнатилган...";
            }
            tbChangeDebtor.Clear();
            tbChangeDebtor.Dispose();

            send_finish = true;
        }
    }
}
