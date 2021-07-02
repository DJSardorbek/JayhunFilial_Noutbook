namespace Jayhunelectro
{
    partial class SoldList
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
            this.dbgridShop = new System.Windows.Forms.DataGridView();
            this.dbgridCart = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.maskVaqt = new System.Windows.Forms.MaskedTextBox();
            this.txtSearch = new MetroSet_UI.Controls.MetroSetTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReturn = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.dbgridJami = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.comboMonth = new System.Windows.Forms.ComboBox();
            this.dbgridBirOylik = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dbgridShopOylik = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtQaytYear = new System.Windows.Forms.TextBox();
            this.comboQaytMonth = new System.Windows.Forms.ComboBox();
            this.dbgridJamiQaytgan = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dbgridReturnProduct = new System.Windows.Forms.DataGridView();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridCart)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridJami)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridBirOylik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridShopOylik)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridJamiQaytgan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridReturnProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgridShop
            // 
            this.dbgridShop.AllowUserToAddRows = false;
            this.dbgridShop.AllowUserToDeleteRows = false;
            this.dbgridShop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridShop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridShop.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridShop.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridShop.ColumnHeadersHeight = 60;
            this.dbgridShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridShop.Location = new System.Drawing.Point(0, 185);
            this.dbgridShop.MultiSelect = false;
            this.dbgridShop.Name = "dbgridShop";
            this.dbgridShop.ReadOnly = true;
            this.dbgridShop.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridShop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridShop.Size = new System.Drawing.Size(1096, 162);
            this.dbgridShop.TabIndex = 0;
            this.dbgridShop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridShop_CellClick);
            this.dbgridShop.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridShop_RowPostPaint);
            // 
            // dbgridCart
            // 
            this.dbgridCart.AllowUserToAddRows = false;
            this.dbgridCart.AllowUserToDeleteRows = false;
            this.dbgridCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridCart.ColumnHeadersHeight = 60;
            this.dbgridCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridCart.Location = new System.Drawing.Point(0, 351);
            this.dbgridCart.MultiSelect = false;
            this.dbgridCart.Name = "dbgridCart";
            this.dbgridCart.ReadOnly = true;
            this.dbgridCart.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridCart.Size = new System.Drawing.Size(1096, 238);
            this.dbgridCart.TabIndex = 1;
            this.dbgridCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridCart_CellClick);
            this.dbgridCart.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridCart_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.label1.Location = new System.Drawing.Point(-2, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Савдо жадвали";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.dateTimePicker1.Location = new System.Drawing.Point(805, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(291, 36);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(142, 27);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1107, 661);
            this.tabControl1.TabIndex = 25;
            this.tabControl1.SizeChanged += new System.EventHandler(this.tabControl1_SizeChanged);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.iconButton1);
            this.tabPage1.Controls.Add(this.maskVaqt);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnReturn);
            this.tabPage1.Controls.Add(this.iconPictureBox2);
            this.tabPage1.Controls.Add(this.dbgridJami);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.dbgridCart);
            this.tabPage1.Controls.Add(this.dbgridShop);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1099, 626);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Бугунги савдо";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // maskVaqt
            // 
            this.maskVaqt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maskVaqt.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskVaqt.Location = new System.Drawing.Point(735, 4);
            this.maskVaqt.Mask = "00:00";
            this.maskVaqt.Name = "maskVaqt";
            this.maskVaqt.Size = new System.Drawing.Size(64, 37);
            this.maskVaqt.TabIndex = 43;
            this.maskVaqt.ValidatingType = typeof(System.DateTime);
            this.maskVaqt.TextChanged += new System.EventHandler(this.maskVaqt_TextChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AutoCompleteCustomSource = null;
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSearch.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSearch.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 16F);
            this.txtSearch.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtSearch.Image = null;
            this.txtSearch.IsDerivedStyle = true;
            this.txtSearch.Lines = null;
            this.txtSearch.Location = new System.Drawing.Point(46, 3);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.Size = new System.Drawing.Size(469, 38);
            this.txtSearch.Style = MetroSet_UI.Enums.Style.Light;
            this.txtSearch.StyleManager = null;
            this.txtSearch.TabIndex = 42;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.ThemeAuthor = "Narwin";
            this.txtSearch.ThemeName = "MetroLite";
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.WatermarkText = "Махсулот номи...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(658, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 29);
            this.label2.TabIndex = 41;
            this.label2.Text = "Вакти";
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReturn.IconChar = FontAwesome.Sharp.IconChar.Reply;
            this.btnReturn.IconColor = System.Drawing.Color.Gainsboro;
            this.btnReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReturn.IconSize = 24;
            this.btnReturn.Location = new System.Drawing.Point(899, 590);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(200, 36);
            this.btnReturn.TabIndex = 40;
            this.btnReturn.Text = "F10-Кайтиб олиш";
            this.btnReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 37;
            this.iconPictureBox2.Location = new System.Drawing.Point(3, 3);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(37, 37);
            this.iconPictureBox2.TabIndex = 26;
            this.iconPictureBox2.TabStop = false;
            // 
            // dbgridJami
            // 
            this.dbgridJami.AllowUserToAddRows = false;
            this.dbgridJami.AllowUserToDeleteRows = false;
            this.dbgridJami.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridJami.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridJami.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridJami.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridJami.ColumnHeadersHeight = 60;
            this.dbgridJami.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridJami.Location = new System.Drawing.Point(0, 45);
            this.dbgridJami.MultiSelect = false;
            this.dbgridJami.Name = "dbgridJami";
            this.dbgridJami.ReadOnly = true;
            this.dbgridJami.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridJami.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridJami.Size = new System.Drawing.Size(1096, 110);
            this.dbgridJami.TabIndex = 25;
            this.dbgridJami.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridJami_RowPostPaint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtYear);
            this.tabPage2.Controls.Add(this.comboMonth);
            this.tabPage2.Controls.Add(this.dbgridBirOylik);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dbgridShopOylik);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1099, 626);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ойлик савдо";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtYear
            // 
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYear.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtYear.Location = new System.Drawing.Point(1016, 3);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(80, 37);
            this.txtYear.TabIndex = 35;
            // 
            // comboMonth
            // 
            this.comboMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMonth.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboMonth.FormattingEnabled = true;
            this.comboMonth.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.comboMonth.Location = new System.Drawing.Point(889, 3);
            this.comboMonth.Name = "comboMonth";
            this.comboMonth.Size = new System.Drawing.Size(121, 37);
            this.comboMonth.TabIndex = 34;
            this.comboMonth.SelectedIndexChanged += new System.EventHandler(this.comboMonth_SelectedIndexChanged);
            // 
            // dbgridBirOylik
            // 
            this.dbgridBirOylik.AllowUserToAddRows = false;
            this.dbgridBirOylik.AllowUserToDeleteRows = false;
            this.dbgridBirOylik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridBirOylik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridBirOylik.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridBirOylik.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridBirOylik.ColumnHeadersHeight = 60;
            this.dbgridBirOylik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridBirOylik.Location = new System.Drawing.Point(0, 45);
            this.dbgridBirOylik.MultiSelect = false;
            this.dbgridBirOylik.Name = "dbgridBirOylik";
            this.dbgridBirOylik.ReadOnly = true;
            this.dbgridBirOylik.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridBirOylik.RowTemplate.Height = 30;
            this.dbgridBirOylik.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridBirOylik.Size = new System.Drawing.Size(1096, 105);
            this.dbgridBirOylik.TabIndex = 33;
            this.dbgridBirOylik.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridBirOylik_RowPostPaint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(-2, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 29);
            this.label4.TabIndex = 32;
            this.label4.Text = "Савдо жадвали";
            // 
            // dbgridShopOylik
            // 
            this.dbgridShopOylik.AllowUserToAddRows = false;
            this.dbgridShopOylik.AllowUserToDeleteRows = false;
            this.dbgridShopOylik.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridShopOylik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridShopOylik.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridShopOylik.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridShopOylik.ColumnHeadersHeight = 60;
            this.dbgridShopOylik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridShopOylik.Location = new System.Drawing.Point(0, 181);
            this.dbgridShopOylik.MultiSelect = false;
            this.dbgridShopOylik.Name = "dbgridShopOylik";
            this.dbgridShopOylik.ReadOnly = true;
            this.dbgridShopOylik.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridShopOylik.RowTemplate.Height = 30;
            this.dbgridShopOylik.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridShopOylik.Size = new System.Drawing.Size(1096, 442);
            this.dbgridShopOylik.TabIndex = 31;
            this.dbgridShopOylik.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridShopOylik_RowPostPaint);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtQaytYear);
            this.tabPage3.Controls.Add(this.comboQaytMonth);
            this.tabPage3.Controls.Add(this.dbgridJamiQaytgan);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.dbgridReturnProduct);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1099, 626);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Кайтган товарлар";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtQaytYear
            // 
            this.txtQaytYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaytYear.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQaytYear.Location = new System.Drawing.Point(1016, 3);
            this.txtQaytYear.Name = "txtQaytYear";
            this.txtQaytYear.Size = new System.Drawing.Size(80, 37);
            this.txtQaytYear.TabIndex = 30;
            // 
            // comboQaytMonth
            // 
            this.comboQaytMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboQaytMonth.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboQaytMonth.FormattingEnabled = true;
            this.comboQaytMonth.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.comboQaytMonth.Location = new System.Drawing.Point(889, 3);
            this.comboQaytMonth.Name = "comboQaytMonth";
            this.comboQaytMonth.Size = new System.Drawing.Size(121, 37);
            this.comboQaytMonth.TabIndex = 28;
            this.comboQaytMonth.SelectedIndexChanged += new System.EventHandler(this.comboQaytMonth_SelectedIndexChanged);
            // 
            // dbgridJamiQaytgan
            // 
            this.dbgridJamiQaytgan.AllowUserToAddRows = false;
            this.dbgridJamiQaytgan.AllowUserToDeleteRows = false;
            this.dbgridJamiQaytgan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridJamiQaytgan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridJamiQaytgan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridJamiQaytgan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridJamiQaytgan.ColumnHeadersHeight = 60;
            this.dbgridJamiQaytgan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridJamiQaytgan.Location = new System.Drawing.Point(3, 45);
            this.dbgridJamiQaytgan.MultiSelect = false;
            this.dbgridJamiQaytgan.Name = "dbgridJamiQaytgan";
            this.dbgridJamiQaytgan.ReadOnly = true;
            this.dbgridJamiQaytgan.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridJamiQaytgan.RowTemplate.Height = 30;
            this.dbgridJamiQaytgan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridJamiQaytgan.Size = new System.Drawing.Size(1093, 105);
            this.dbgridJamiQaytgan.TabIndex = 26;
            this.dbgridJamiQaytgan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridJamiQaytgan_RowPostPaint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(-2, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Кайтган товарлар жадвали";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dbgridReturnProduct
            // 
            this.dbgridReturnProduct.AllowUserToAddRows = false;
            this.dbgridReturnProduct.AllowUserToDeleteRows = false;
            this.dbgridReturnProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridReturnProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbgridReturnProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridReturnProduct.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridReturnProduct.ColumnHeadersHeight = 60;
            this.dbgridReturnProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridReturnProduct.Location = new System.Drawing.Point(3, 181);
            this.dbgridReturnProduct.MultiSelect = false;
            this.dbgridReturnProduct.Name = "dbgridReturnProduct";
            this.dbgridReturnProduct.ReadOnly = true;
            this.dbgridReturnProduct.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridReturnProduct.RowTemplate.Height = 30;
            this.dbgridReturnProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridReturnProduct.Size = new System.Drawing.Size(1093, 442);
            this.dbgridReturnProduct.TabIndex = 0;
            this.dbgridReturnProduct.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridReturnProduct_RowPostPaint);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.SeaGreen;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconButton1.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 28;
            this.iconButton1.Location = new System.Drawing.Point(521, 4);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(140, 36);
            this.iconButton1.TabIndex = 45;
            this.iconButton1.Text = "Смен ёпиш";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // SoldList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 661);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SoldList";
            this.Text = "SoldList";
            this.Load += new System.EventHandler(this.SoldList_Load);
            this.SizeChanged += new System.EventHandler(this.SoldList_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridCart)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridJami)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridBirOylik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridShopOylik)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridJamiQaytgan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridReturnProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dbgridShop;
        public System.Windows.Forms.DataGridView dbgridCart;
        public System.Windows.Forms.DataGridView dbgridJami;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public MetroSet_UI.Controls.MetroSetTextBox txtSearch;
        public System.Windows.Forms.MaskedTextBox maskVaqt;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dbgridReturnProduct;
        public System.Windows.Forms.DataGridView dbgridJamiQaytgan;
        private System.Windows.Forms.ComboBox comboQaytMonth;
        private System.Windows.Forms.TextBox txtQaytYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox comboMonth;
        public System.Windows.Forms.DataGridView dbgridBirOylik;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dbgridShopOylik;
        public System.Windows.Forms.TabControl tabControl1;
        public FontAwesome.Sharp.IconButton btnReturn;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}