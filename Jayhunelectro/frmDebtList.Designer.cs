namespace Jayhunelectro
{
    partial class frmDebtList
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.conMenuDebtCart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.тўлашToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbgridDebtSumma = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dbgridDebtCart = new System.Windows.Forms.DataGridView();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.comboSearchTypes = new System.Windows.Forms.ComboBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.dbgridJamiNasiya = new System.Windows.Forms.DataGridView();
            this.btnQaytaribOlish = new FontAwesome.Sharp.IconButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.comboMonth = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dbgridPayhistory = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtSearchQaytOlish = new MetroSet_UI.Controls.MetroSetTextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblDebtor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dbgridSoldhistoryShop = new System.Windows.Forms.DataGridView();
            this.btnQaytOlish = new FontAwesome.Sharp.IconButton();
            this.dbgridSoldHistoryCart = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dbgridReturnProductTotal = new System.Windows.Forms.DataGridView();
            this.txtQaytYear = new System.Windows.Forms.TextBox();
            this.comboQaytMonth = new System.Windows.Forms.ComboBox();
            this.dbgridReturnProduct = new System.Windows.Forms.DataGridView();
            this.conMenuDebtCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridDebtSumma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridDebtCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridJamiNasiya)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridPayhistory)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridSoldhistoryShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridSoldHistoryCart)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridReturnProductTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridReturnProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.txtSearch.Location = new System.Drawing.Point(38, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(643, 36);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // conMenuDebtCart
            // 
            this.conMenuDebtCart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тўлашToolStripMenuItem});
            this.conMenuDebtCart.Name = "contextMenuStrip1";
            this.conMenuDebtCart.Size = new System.Drawing.Size(112, 26);
            // 
            // тўлашToolStripMenuItem
            // 
            this.тўлашToolStripMenuItem.Name = "тўлашToolStripMenuItem";
            this.тўлашToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.тўлашToolStripMenuItem.Text = "Тўлаш";
            this.тўлашToolStripMenuItem.Click += new System.EventHandler(this.тўлашToolStripMenuItem_Click);
            // 
            // dbgridDebtSumma
            // 
            this.dbgridDebtSumma.AllowUserToAddRows = false;
            this.dbgridDebtSumma.AllowUserToDeleteRows = false;
            this.dbgridDebtSumma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridDebtSumma.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbgridDebtSumma.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridDebtSumma.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridDebtSumma.ColumnHeadersHeight = 60;
            this.dbgridDebtSumma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridDebtSumma.Location = new System.Drawing.Point(0, 188);
            this.dbgridDebtSumma.MultiSelect = false;
            this.dbgridDebtSumma.Name = "dbgridDebtSumma";
            this.dbgridDebtSumma.ReadOnly = true;
            this.dbgridDebtSumma.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 16.75F);
            this.dbgridDebtSumma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridDebtSumma.Size = new System.Drawing.Size(1099, 172);
            this.dbgridDebtSumma.TabIndex = 15;
            this.dbgridDebtSumma.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridDebtSumma_CellClick);
            this.dbgridDebtSumma.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridDebtSumma_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.label1.Location = new System.Drawing.Point(-3, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Насия жадвали";
            // 
            // dbgridDebtCart
            // 
            this.dbgridDebtCart.AllowUserToAddRows = false;
            this.dbgridDebtCart.AllowUserToDeleteRows = false;
            this.dbgridDebtCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridDebtCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbgridDebtCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridDebtCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridDebtCart.ColumnHeadersHeight = 60;
            this.dbgridDebtCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridDebtCart.ContextMenuStrip = this.conMenuDebtCart;
            this.dbgridDebtCart.Location = new System.Drawing.Point(0, 366);
            this.dbgridDebtCart.MultiSelect = false;
            this.dbgridDebtCart.Name = "dbgridDebtCart";
            this.dbgridDebtCart.ReadOnly = true;
            this.dbgridDebtCart.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 16.75F);
            this.dbgridDebtCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridDebtCart.Size = new System.Drawing.Size(1099, 218);
            this.dbgridDebtCart.TabIndex = 15;
            this.dbgridDebtCart.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridDebtCart_RowPostPaint);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 36;
            this.iconPictureBox2.Location = new System.Drawing.Point(1, 3);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(36, 36);
            this.iconPictureBox2.TabIndex = 24;
            this.iconPictureBox2.TabStop = false;
            // 
            // comboSearchTypes
            // 
            this.comboSearchTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSearchTypes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboSearchTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearchTypes.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.comboSearchTypes.FormattingEnabled = true;
            this.comboSearchTypes.Items.AddRange(new object[] {
            "Мижоз_фиш",
            "Тэл_1",
            "Тэл_2"});
            this.comboSearchTypes.Location = new System.Drawing.Point(687, 3);
            this.comboSearchTypes.Name = "comboSearchTypes";
            this.comboSearchTypes.Size = new System.Drawing.Size(196, 36);
            this.comboSearchTypes.TabIndex = 29;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWave;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(956, 590);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(140, 36);
            this.iconButton1.TabIndex = 31;
            this.iconButton1.Text = "F2-Тўлов";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // dbgridJamiNasiya
            // 
            this.dbgridJamiNasiya.AllowUserToAddRows = false;
            this.dbgridJamiNasiya.AllowUserToDeleteRows = false;
            this.dbgridJamiNasiya.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridJamiNasiya.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridJamiNasiya.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridJamiNasiya.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridJamiNasiya.ColumnHeadersHeight = 60;
            this.dbgridJamiNasiya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridJamiNasiya.Location = new System.Drawing.Point(0, 45);
            this.dbgridJamiNasiya.MultiSelect = false;
            this.dbgridJamiNasiya.Name = "dbgridJamiNasiya";
            this.dbgridJamiNasiya.ReadOnly = true;
            this.dbgridJamiNasiya.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 16.75F);
            this.dbgridJamiNasiya.RowTemplate.Height = 30;
            this.dbgridJamiNasiya.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridJamiNasiya.Size = new System.Drawing.Size(1099, 108);
            this.dbgridJamiNasiya.TabIndex = 28;
            this.dbgridJamiNasiya.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridJamiNasiya_RowPostPaint);
            // 
            // btnQaytaribOlish
            // 
            this.btnQaytaribOlish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQaytaribOlish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnQaytaribOlish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQaytaribOlish.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQaytaribOlish.IconChar = FontAwesome.Sharp.IconChar.Reply;
            this.btnQaytaribOlish.IconColor = System.Drawing.Color.Gainsboro;
            this.btnQaytaribOlish.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQaytaribOlish.IconSize = 30;
            this.btnQaytaribOlish.Location = new System.Drawing.Point(770, 590);
            this.btnQaytaribOlish.Name = "btnQaytaribOlish";
            this.btnQaytaribOlish.Size = new System.Drawing.Size(183, 36);
            this.btnQaytaribOlish.TabIndex = 32;
            this.btnQaytaribOlish.Text = "Кайтариб олиш";
            this.btnQaytaribOlish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQaytaribOlish.UseVisualStyleBackColor = false;
            this.btnQaytaribOlish.Click += new System.EventHandler(this.btnQaytaribOlish_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1107, 661);
            this.tabControl1.TabIndex = 33;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtYear);
            this.tabPage1.Controls.Add(this.comboMonth);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.iconPictureBox2);
            this.tabPage1.Controls.Add(this.iconButton1);
            this.tabPage1.Controls.Add(this.btnQaytaribOlish);
            this.tabPage1.Controls.Add(this.comboSearchTypes);
            this.tabPage1.Controls.Add(this.dbgridDebtCart);
            this.tabPage1.Controls.Add(this.dbgridJamiNasiya);
            this.tabPage1.Controls.Add(this.dbgridDebtSumma);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1099, 626);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Насия рўйхати";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtYear
            // 
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYear.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtYear.Location = new System.Drawing.Point(1016, 3);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(80, 37);
            this.txtYear.TabIndex = 34;
            // 
            // comboMonth
            // 
            this.comboMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.comboMonth.TabIndex = 33;
            this.comboMonth.SelectedIndexChanged += new System.EventHandler(this.comboMonth_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dbgridPayhistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1099, 626);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Тўлов тарихи";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dbgridPayhistory
            // 
            this.dbgridPayhistory.AllowUserToAddRows = false;
            this.dbgridPayhistory.AllowUserToDeleteRows = false;
            this.dbgridPayhistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridPayhistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridPayhistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridPayhistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridPayhistory.ColumnHeadersHeight = 60;
            this.dbgridPayhistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridPayhistory.Location = new System.Drawing.Point(0, 3);
            this.dbgridPayhistory.MultiSelect = false;
            this.dbgridPayhistory.Name = "dbgridPayhistory";
            this.dbgridPayhistory.ReadOnly = true;
            this.dbgridPayhistory.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridPayhistory.RowTemplate.Height = 30;
            this.dbgridPayhistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridPayhistory.Size = new System.Drawing.Size(1096, 620);
            this.dbgridPayhistory.TabIndex = 34;
            this.dbgridPayhistory.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridPayhistory_RowPostPaint);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtSearchQaytOlish);
            this.tabPage3.Controls.Add(this.iconPictureBox1);
            this.tabPage3.Controls.Add(this.lblDebtor);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.dbgridSoldhistoryShop);
            this.tabPage3.Controls.Add(this.btnQaytOlish);
            this.tabPage3.Controls.Add(this.dbgridSoldHistoryCart);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1099, 626);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Олинганлик тарихи";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtSearchQaytOlish
            // 
            this.txtSearchQaytOlish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchQaytOlish.AutoCompleteCustomSource = null;
            this.txtSearchQaytOlish.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSearchQaytOlish.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSearchQaytOlish.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSearchQaytOlish.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearchQaytOlish.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSearchQaytOlish.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtSearchQaytOlish.Font = new System.Drawing.Font("Calibri", 16F);
            this.txtSearchQaytOlish.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtSearchQaytOlish.Image = null;
            this.txtSearchQaytOlish.IsDerivedStyle = true;
            this.txtSearchQaytOlish.Lines = null;
            this.txtSearchQaytOlish.Location = new System.Drawing.Point(45, 3);
            this.txtSearchQaytOlish.MaxLength = 32767;
            this.txtSearchQaytOlish.Multiline = false;
            this.txtSearchQaytOlish.Name = "txtSearchQaytOlish";
            this.txtSearchQaytOlish.ReadOnly = false;
            this.txtSearchQaytOlish.Size = new System.Drawing.Size(623, 36);
            this.txtSearchQaytOlish.Style = MetroSet_UI.Enums.Style.Light;
            this.txtSearchQaytOlish.StyleManager = null;
            this.txtSearchQaytOlish.TabIndex = 43;
            this.txtSearchQaytOlish.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearchQaytOlish.ThemeAuthor = "Narwin";
            this.txtSearchQaytOlish.ThemeName = "MetroLite";
            this.txtSearchQaytOlish.UseSystemPasswordChar = false;
            this.txtSearchQaytOlish.WatermarkText = "Махсулот номи...";
            this.txtSearchQaytOlish.TextChanged += new System.EventHandler(this.txtSearchQaytOlish_TextChanged);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 36;
            this.iconPictureBox1.Location = new System.Drawing.Point(3, 3);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(36, 36);
            this.iconPictureBox1.TabIndex = 41;
            this.iconPictureBox1.TabStop = false;
            // 
            // lblDebtor
            // 
            this.lblDebtor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDebtor.AutoSize = true;
            this.lblDebtor.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDebtor.Location = new System.Drawing.Point(773, 3);
            this.lblDebtor.Name = "lblDebtor";
            this.lblDebtor.Size = new System.Drawing.Size(100, 29);
            this.lblDebtor.TabIndex = 39;
            this.lblDebtor.Text = "Карздор";
            this.lblDebtor.Click += new System.EventHandler(this.lblDebtor_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(666, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 29);
            this.label2.TabIndex = 38;
            this.label2.Text = "Карздор :";
            // 
            // dbgridSoldhistoryShop
            // 
            this.dbgridSoldhistoryShop.AllowUserToAddRows = false;
            this.dbgridSoldhistoryShop.AllowUserToDeleteRows = false;
            this.dbgridSoldhistoryShop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridSoldhistoryShop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridSoldhistoryShop.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridSoldhistoryShop.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridSoldhistoryShop.ColumnHeadersHeight = 60;
            this.dbgridSoldhistoryShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridSoldhistoryShop.Location = new System.Drawing.Point(1, 45);
            this.dbgridSoldhistoryShop.MultiSelect = false;
            this.dbgridSoldhistoryShop.Name = "dbgridSoldhistoryShop";
            this.dbgridSoldhistoryShop.ReadOnly = true;
            this.dbgridSoldhistoryShop.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridSoldhistoryShop.RowTemplate.Height = 30;
            this.dbgridSoldhistoryShop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridSoldhistoryShop.Size = new System.Drawing.Size(1096, 225);
            this.dbgridSoldhistoryShop.TabIndex = 37;
            this.dbgridSoldhistoryShop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridSoldhistoryShop_CellClick);
            this.dbgridSoldhistoryShop.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridSoldhistoryShop_RowPostPaint);
            // 
            // btnQaytOlish
            // 
            this.btnQaytOlish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQaytOlish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnQaytOlish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQaytOlish.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQaytOlish.IconChar = FontAwesome.Sharp.IconChar.Reply;
            this.btnQaytOlish.IconColor = System.Drawing.Color.Gainsboro;
            this.btnQaytOlish.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQaytOlish.IconSize = 30;
            this.btnQaytOlish.Location = new System.Drawing.Point(911, 590);
            this.btnQaytOlish.Name = "btnQaytOlish";
            this.btnQaytOlish.Size = new System.Drawing.Size(186, 36);
            this.btnQaytOlish.TabIndex = 36;
            this.btnQaytOlish.Text = "Кайтариб олиш";
            this.btnQaytOlish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQaytOlish.UseVisualStyleBackColor = false;
            this.btnQaytOlish.Click += new System.EventHandler(this.btnQaytOlish_Click);
            // 
            // dbgridSoldHistoryCart
            // 
            this.dbgridSoldHistoryCart.AllowUserToAddRows = false;
            this.dbgridSoldHistoryCart.AllowUserToDeleteRows = false;
            this.dbgridSoldHistoryCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridSoldHistoryCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridSoldHistoryCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridSoldHistoryCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridSoldHistoryCart.ColumnHeadersHeight = 60;
            this.dbgridSoldHistoryCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridSoldHistoryCart.Location = new System.Drawing.Point(1, 276);
            this.dbgridSoldHistoryCart.MultiSelect = false;
            this.dbgridSoldHistoryCart.Name = "dbgridSoldHistoryCart";
            this.dbgridSoldHistoryCart.ReadOnly = true;
            this.dbgridSoldHistoryCart.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridSoldHistoryCart.RowTemplate.Height = 30;
            this.dbgridSoldHistoryCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridSoldHistoryCart.Size = new System.Drawing.Size(1096, 312);
            this.dbgridSoldHistoryCart.TabIndex = 35;
            this.dbgridSoldHistoryCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridSoldHistoryCart_CellClick);
            this.dbgridSoldHistoryCart.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridSoldHistoryCart_RowPostPaint);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.dbgridReturnProductTotal);
            this.tabPage4.Controls.Add(this.txtQaytYear);
            this.tabPage4.Controls.Add(this.comboQaytMonth);
            this.tabPage4.Controls.Add(this.dbgridReturnProduct);
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1099, 626);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Кайтган товарлар";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(-2, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 29);
            this.label3.TabIndex = 40;
            this.label3.Text = "Кайтган товарлар жадвали";
            // 
            // dbgridReturnProductTotal
            // 
            this.dbgridReturnProductTotal.AllowUserToAddRows = false;
            this.dbgridReturnProductTotal.AllowUserToDeleteRows = false;
            this.dbgridReturnProductTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridReturnProductTotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridReturnProductTotal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridReturnProductTotal.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridReturnProductTotal.ColumnHeadersHeight = 60;
            this.dbgridReturnProductTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridReturnProductTotal.Location = new System.Drawing.Point(1, 46);
            this.dbgridReturnProductTotal.MultiSelect = false;
            this.dbgridReturnProductTotal.Name = "dbgridReturnProductTotal";
            this.dbgridReturnProductTotal.ReadOnly = true;
            this.dbgridReturnProductTotal.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridReturnProductTotal.RowTemplate.Height = 30;
            this.dbgridReturnProductTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridReturnProductTotal.Size = new System.Drawing.Size(1096, 105);
            this.dbgridReturnProductTotal.TabIndex = 39;
            this.dbgridReturnProductTotal.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridReturnProductTotal_RowPostPaint);
            // 
            // txtQaytYear
            // 
            this.txtQaytYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQaytYear.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQaytYear.Location = new System.Drawing.Point(1016, 3);
            this.txtQaytYear.Name = "txtQaytYear";
            this.txtQaytYear.Size = new System.Drawing.Size(80, 37);
            this.txtQaytYear.TabIndex = 38;
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
            this.comboQaytMonth.TabIndex = 37;
            this.comboQaytMonth.SelectedIndexChanged += new System.EventHandler(this.comboQaytMonth_SelectedIndexChanged);
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
            this.dbgridReturnProduct.Location = new System.Drawing.Point(1, 186);
            this.dbgridReturnProduct.MultiSelect = false;
            this.dbgridReturnProduct.Name = "dbgridReturnProduct";
            this.dbgridReturnProduct.ReadOnly = true;
            this.dbgridReturnProduct.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridReturnProduct.RowTemplate.Height = 30;
            this.dbgridReturnProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridReturnProduct.Size = new System.Drawing.Size(1096, 437);
            this.dbgridReturnProduct.TabIndex = 36;
            this.dbgridReturnProduct.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridReturnProduct_RowPostPaint);
            // 
            // frmDebtList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 661);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDebtList";
            this.Text = "Насия Рўйхати";
            this.Load += new System.EventHandler(this.frmDebtList_Load);
            this.SizeChanged += new System.EventHandler(this.frmDebtList_SizeChanged);
            this.conMenuDebtCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridDebtSumma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridDebtCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridJamiNasiya)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridPayhistory)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridSoldhistoryShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridSoldHistoryCart)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridReturnProductTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridReturnProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem тўлашToolStripMenuItem;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.ComboBox comboSearchTypes;
        public System.Windows.Forms.ContextMenuStrip conMenuDebtCart;
        public System.Windows.Forms.DataGridView dbgridDebtSumma;
        public System.Windows.Forms.DataGridView dbgridDebtCart;
        public System.Windows.Forms.DataGridView dbgridJamiNasiya;
        public FontAwesome.Sharp.IconButton iconButton1;
        public FontAwesome.Sharp.IconButton btnQaytaribOlish;
        public System.Windows.Forms.DataGridView dbgridPayhistory;
        public System.Windows.Forms.DataGridView dbgridSoldHistoryCart;
        public System.Windows.Forms.DataGridView dbgridReturnProduct;
        public FontAwesome.Sharp.IconButton btnQaytOlish;
        public System.Windows.Forms.DataGridView dbgridSoldhistoryShop;
        public System.Windows.Forms.Label lblDebtor;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        public MetroSet_UI.Controls.MetroSetTextBox txtSearchQaytOlish;
        public System.Windows.Forms.TextBox txtQaytYear;
        public System.Windows.Forms.ComboBox comboQaytMonth;
        public System.Windows.Forms.DataGridView dbgridReturnProductTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox comboMonth;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TabPage tabPage4;
    }
}