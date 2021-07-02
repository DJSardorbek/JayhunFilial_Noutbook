namespace Jayhunelectro
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCashDesk = new FontAwesome.Sharp.IconButton();
            this.btnDebt = new FontAwesome.Sharp.IconButton();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.btnSales = new FontAwesome.Sharp.IconButton();
            this.btnChiqish = new FontAwesome.Sharp.IconButton();
            this.btnSoldList = new FontAwesome.Sharp.IconButton();
            this.btnWaiting = new FontAwesome.Sharp.IconButton();
            this.btnRecieveFilial = new FontAwesome.Sharp.IconButton();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblSoat = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProfil = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblSend = new System.Windows.Forms.Label();
            this.TimerSend = new System.Windows.Forms.Timer(this.components);
            this.Soat = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCashDesk);
            this.panel1.Controls.Add(this.btnDebt);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnSales);
            this.panel1.Controls.Add(this.btnChiqish);
            this.panel1.Controls.Add(this.btnSoldList);
            this.panel1.Controls.Add(this.btnWaiting);
            this.panel1.Controls.Add(this.btnRecieveFilial);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 700);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 33);
            this.button1.TabIndex = 21;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCashDesk
            // 
            this.btnCashDesk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnCashDesk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashDesk.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCashDesk.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCashDesk.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnCashDesk.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCashDesk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCashDesk.IconSize = 36;
            this.btnCashDesk.Location = new System.Drawing.Point(0, 249);
            this.btnCashDesk.Name = "btnCashDesk";
            this.btnCashDesk.Size = new System.Drawing.Size(215, 77);
            this.btnCashDesk.TabIndex = 1;
            this.btnCashDesk.Text = "Касса";
            this.btnCashDesk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCashDesk.UseVisualStyleBackColor = false;
            this.btnCashDesk.Click += new System.EventHandler(this.btnCashDesk_Click);
            // 
            // btnDebt
            // 
            this.btnDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnDebt.FlatAppearance.BorderSize = 0;
            this.btnDebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDebt.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDebt.IconChar = FontAwesome.Sharp.IconChar.List;
            this.btnDebt.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDebt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDebt.IconSize = 36;
            this.btnDebt.Location = new System.Drawing.Point(0, 415);
            this.btnDebt.Name = "btnDebt";
            this.btnDebt.Size = new System.Drawing.Size(215, 77);
            this.btnDebt.TabIndex = 18;
            this.btnDebt.Text = "Насия Рўйхати";
            this.btnDebt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDebt.UseVisualStyleBackColor = false;
            this.btnDebt.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(158)))), ((int)(((byte)(253)))));
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.btnMenu.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 36;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(215, 77);
            this.btnMenu.TabIndex = 20;
            this.btnMenu.Text = "Асосий Ойна";
            this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSales.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSales.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
            this.btnSales.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSales.IconSize = 36;
            this.btnSales.Location = new System.Drawing.Point(0, 83);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(215, 77);
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "Сотиш Ойнаси";
            this.btnSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnChiqish
            // 
            this.btnChiqish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnChiqish.FlatAppearance.BorderSize = 0;
            this.btnChiqish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiqish.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChiqish.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnChiqish.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnChiqish.IconColor = System.Drawing.Color.Gainsboro;
            this.btnChiqish.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChiqish.IconSize = 36;
            this.btnChiqish.Location = new System.Drawing.Point(0, 581);
            this.btnChiqish.Name = "btnChiqish";
            this.btnChiqish.Size = new System.Drawing.Size(215, 77);
            this.btnChiqish.TabIndex = 19;
            this.btnChiqish.Text = "Чикиш";
            this.btnChiqish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChiqish.UseVisualStyleBackColor = false;
            this.btnChiqish.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // btnSoldList
            // 
            this.btnSoldList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnSoldList.FlatAppearance.BorderSize = 0;
            this.btnSoldList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoldList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSoldList.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSoldList.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnSoldList.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSoldList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSoldList.IconSize = 36;
            this.btnSoldList.Location = new System.Drawing.Point(0, 332);
            this.btnSoldList.Name = "btnSoldList";
            this.btnSoldList.Size = new System.Drawing.Size(215, 77);
            this.btnSoldList.TabIndex = 17;
            this.btnSoldList.Text = "Сотилганлар Рўйхати";
            this.btnSoldList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSoldList.UseVisualStyleBackColor = false;
            this.btnSoldList.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // btnWaiting
            // 
            this.btnWaiting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnWaiting.FlatAppearance.BorderSize = 0;
            this.btnWaiting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWaiting.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnWaiting.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.btnWaiting.IconColor = System.Drawing.Color.Gainsboro;
            this.btnWaiting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWaiting.IconSize = 36;
            this.btnWaiting.Location = new System.Drawing.Point(0, 166);
            this.btnWaiting.Name = "btnWaiting";
            this.btnWaiting.Size = new System.Drawing.Size(215, 77);
            this.btnWaiting.TabIndex = 15;
            this.btnWaiting.Text = "Кутиш Ойнаси";
            this.btnWaiting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWaiting.UseVisualStyleBackColor = false;
            this.btnWaiting.Click += new System.EventHandler(this.btnWaiting_Click);
            // 
            // btnRecieveFilial
            // 
            this.btnRecieveFilial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnRecieveFilial.FlatAppearance.BorderSize = 0;
            this.btnRecieveFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecieveFilial.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRecieveFilial.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRecieveFilial.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleDown;
            this.btnRecieveFilial.IconColor = System.Drawing.Color.Gainsboro;
            this.btnRecieveFilial.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRecieveFilial.IconSize = 36;
            this.btnRecieveFilial.Location = new System.Drawing.Point(0, 498);
            this.btnRecieveFilial.Name = "btnRecieveFilial";
            this.btnRecieveFilial.Size = new System.Drawing.Size(215, 77);
            this.btnRecieveFilial.TabIndex = 16;
            this.btnRecieveFilial.Text = "Товар Кабули";
            this.btnRecieveFilial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecieveFilial.UseVisualStyleBackColor = false;
            this.btnRecieveFilial.Click += new System.EventHandler(this.btnRecieveFilial_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.lblSoat);
            this.panelMenu.Controls.Add(this.lblUser);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Controls.Add(this.label3);
            this.panelMenu.Controls.Add(this.lblProfil);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelMenu.Location = new System.Drawing.Point(235, 60);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1123, 700);
            this.panelMenu.TabIndex = 1;
            // 
            // lblSoat
            // 
            this.lblSoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoat.AutoSize = true;
            this.lblSoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSoat.Location = new System.Drawing.Point(679, 662);
            this.lblSoat.Name = "lblSoat";
            this.lblSoat.Size = new System.Drawing.Size(69, 29);
            this.lblSoat.TabIndex = 7;
            this.lblSoat.Text = "Соат";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUser.Location = new System.Drawing.Point(882, 617);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(118, 29);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "Профил :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(679, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Профил :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(679, 617);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Фойдаланувчи :";
            // 
            // lblProfil
            // 
            this.lblProfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProfil.AutoSize = true;
            this.lblProfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProfil.Location = new System.Drawing.Point(803, 565);
            this.lblProfil.Name = "lblProfil";
            this.lblProfil.Size = new System.Drawing.Size(118, 29);
            this.lblProfil.TabIndex = 5;
            this.lblProfil.Text = "Профил :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(677, 108);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jayhun Electro";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Jayhunelectro.Properties.Resources.jayhun;
            this.pictureBox1.Location = new System.Drawing.Point(773, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Consolas", 22F);
            this.lblDisplay.Location = new System.Drawing.Point(47, 21);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(191, 36);
            this.lblDisplay.TabIndex = 2;
            this.lblDisplay.Text = "Асосий Ойна";
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSend.Location = new System.Drawing.Point(633, 28);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(31, 29);
            this.lblSend.TabIndex = 51;
            this.lblSend.Text = "...";
            // 
            // TimerSend
            // 
            this.TimerSend.Interval = 10000;
            this.TimerSend.Tick += new System.EventHandler(this.TimerSend_Tick);
            // 
            // Soat
            // 
            this.Soat.Enabled = true;
            this.Soat.Interval = 1000;
            this.Soat.Tick += new System.EventHandler(this.Soat_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 30;
            this.iconPictureBox1.Location = new System.Drawing.Point(20, 27);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(30, 30);
            this.iconPictureBox1.TabIndex = 4;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimizeBox = false;
            this.Name = "frmMainMenu";
            this.Text = ".";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainMenu_FormClosing);
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.Shown += new System.EventHandler(this.frmMainMenu_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainMenu_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public FontAwesome.Sharp.IconButton btnWaiting;
        public FontAwesome.Sharp.IconButton btnSales;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        public FontAwesome.Sharp.IconButton btnChiqish;
        public FontAwesome.Sharp.IconButton btnDebt;
        public FontAwesome.Sharp.IconButton btnSoldList;
        public FontAwesome.Sharp.IconButton btnRecieveFilial;
        public FontAwesome.Sharp.IconButton btnMenu;
        public System.Windows.Forms.Label lblDisplay;
        private FontAwesome.Sharp.IconButton btnCashDesk;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Timer TimerSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblProfil;
        private System.Windows.Forms.Label lblSoat;
        private System.Windows.Forms.Timer Soat;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}