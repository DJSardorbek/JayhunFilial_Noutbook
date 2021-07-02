namespace Jayhunelectro
{
    partial class frmTovarQabuli
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dbgridProduct = new System.Windows.Forms.DataGridView();
            this.dbgirdPriceCart = new System.Windows.Forms.DataGridView();
            this.txtSearchPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.comboStaff = new System.Windows.Forms.ComboBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dbgridStaff = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblQayta = new System.Windows.Forms.Label();
            this.dbgridFakturaItem = new System.Windows.Forms.DataGridView();
            this.dbgridFaktura = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnQabulQilish = new FontAwesome.Sharp.IconButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dbgridPriceCart = new System.Windows.Forms.DataGridView();
            this.dbgridChangedPrice = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pricemonth = new System.Windows.Forms.DateTimePicker();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgirdPriceCart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridStaff)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFaktura)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridPriceCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridChangedPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dbgridProduct);
            this.tabPage3.Controls.Add(this.dbgirdPriceCart);
            this.tabPage3.Controls.Add(this.txtSearchPrice);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1099, 626);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Нархни ўзгартириш";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dbgridProduct
            // 
            this.dbgridProduct.AllowUserToAddRows = false;
            this.dbgridProduct.AllowUserToDeleteRows = false;
            this.dbgridProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridProduct.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbgridProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dbgridProduct.ColumnHeadersHeight = 60;
            this.dbgridProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridProduct.Location = new System.Drawing.Point(3, 44);
            this.dbgridProduct.MultiSelect = false;
            this.dbgridProduct.Name = "dbgridProduct";
            this.dbgridProduct.ReadOnly = true;
            this.dbgridProduct.RowHeadersVisible = false;
            this.dbgridProduct.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dbgridProduct.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridProduct.Size = new System.Drawing.Size(1093, 213);
            this.dbgridProduct.TabIndex = 5;
            this.dbgridProduct.Visible = false;
            this.dbgridProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbgridProduct_KeyDown);
            // 
            // dbgirdPriceCart
            // 
            this.dbgirdPriceCart.AllowUserToAddRows = false;
            this.dbgirdPriceCart.AllowUserToDeleteRows = false;
            this.dbgirdPriceCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgirdPriceCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgirdPriceCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgirdPriceCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbgirdPriceCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dbgirdPriceCart.ColumnHeadersHeight = 60;
            this.dbgirdPriceCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgirdPriceCart.Location = new System.Drawing.Point(3, 44);
            this.dbgirdPriceCart.MultiSelect = false;
            this.dbgirdPriceCart.Name = "dbgirdPriceCart";
            this.dbgirdPriceCart.ReadOnly = true;
            this.dbgirdPriceCart.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dbgirdPriceCart.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgirdPriceCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgirdPriceCart.Size = new System.Drawing.Size(1093, 579);
            this.dbgirdPriceCart.TabIndex = 6;
            this.dbgirdPriceCart.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgirdPriceCart_RowPostPaint);
            // 
            // txtSearchPrice
            // 
            this.txtSearchPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchPrice.Animated = true;
            this.txtSearchPrice.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtSearchPrice.BorderRadius = 4;
            this.txtSearchPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchPrice.DefaultText = "";
            this.txtSearchPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchPrice.DisabledState.Parent = this.txtSearchPrice;
            this.txtSearchPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchPrice.FocusedState.Parent = this.txtSearchPrice;
            this.txtSearchPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchPrice.HoverState.Parent = this.txtSearchPrice;
            this.txtSearchPrice.IconLeft = global::Jayhunelectro.Properties.Resources.search;
            this.txtSearchPrice.Location = new System.Drawing.Point(3, 3);
            this.txtSearchPrice.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtSearchPrice.Name = "txtSearchPrice";
            this.txtSearchPrice.PasswordChar = '\0';
            this.txtSearchPrice.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtSearchPrice.PlaceholderText = "махсулот номи & штрих код...";
            this.txtSearchPrice.SelectedText = "";
            this.txtSearchPrice.ShadowDecoration.Parent = this.txtSearchPrice;
            this.txtSearchPrice.Size = new System.Drawing.Size(1093, 36);
            this.txtSearchPrice.TabIndex = 0;
            this.txtSearchPrice.TextChanged += new System.EventHandler(this.txtSearchPrice_TextChanged);
            this.txtSearchPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchPrice_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.comboStaff);
            this.tabPage2.Controls.Add(this.txtPass);
            this.tabPage2.Controls.Add(this.txtSurname);
            this.tabPage2.Controls.Add(this.txtName);
            this.tabPage2.Controls.Add(this.dbgridStaff);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.iconButton2);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1099, 626);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ходим кўшиш";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ходимлар рўйхати :";
            // 
            // comboStaff
            // 
            this.comboStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboStaff.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboStaff.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStaff.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboStaff.FormattingEnabled = true;
            this.comboStaff.Location = new System.Drawing.Point(126, 138);
            this.comboStaff.Name = "comboStaff";
            this.comboStaff.Size = new System.Drawing.Size(960, 34);
            this.comboStaff.TabIndex = 9;
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPass.Location = new System.Drawing.Point(104, 195);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(866, 33);
            this.txtPass.TabIndex = 8;
            // 
            // txtSurname
            // 
            this.txtSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSurname.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSurname.Location = new System.Drawing.Point(139, 81);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(947, 33);
            this.txtSurname.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtName.Location = new System.Drawing.Point(84, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(1002, 33);
            this.txtName.TabIndex = 6;
            // 
            // dbgridStaff
            // 
            this.dbgridStaff.AllowUserToAddRows = false;
            this.dbgridStaff.AllowUserToDeleteRows = false;
            this.dbgridStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridStaff.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridStaff.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridStaff.ColumnHeadersHeight = 60;
            this.dbgridStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridStaff.Location = new System.Drawing.Point(3, 281);
            this.dbgridStaff.MultiSelect = false;
            this.dbgridStaff.Name = "dbgridStaff";
            this.dbgridStaff.ReadOnly = true;
            this.dbgridStaff.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridStaff.Size = new System.Drawing.Size(1093, 342);
            this.dbgridStaff.TabIndex = 4;
            this.dbgridStaff.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridStaff_RowPostPaint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Пароли :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Лавозими :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Фамилияси :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Исми :";
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButton2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(976, 194);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(110, 36);
            this.iconButton2.TabIndex = 5;
            this.iconButton2.Text = "Кўшиш";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblQayta);
            this.tabPage1.Controls.Add(this.dbgridFakturaItem);
            this.tabPage1.Controls.Add(this.dbgridFaktura);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.btnQabulQilish);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1099, 626);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Фактура";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblQayta
            // 
            this.lblQayta.AutoSize = true;
            this.lblQayta.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQayta.Location = new System.Drawing.Point(968, 3);
            this.lblQayta.Name = "lblQayta";
            this.lblQayta.Size = new System.Drawing.Size(128, 26);
            this.lblQayta.TabIndex = 49;
            this.lblQayta.Text = "Кайта юклаш";
            this.lblQayta.Visible = false;
            this.lblQayta.Click += new System.EventHandler(this.lblQayta_Click);
            // 
            // dbgridFakturaItem
            // 
            this.dbgridFakturaItem.AllowUserToAddRows = false;
            this.dbgridFakturaItem.AllowUserToDeleteRows = false;
            this.dbgridFakturaItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridFakturaItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridFakturaItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridFakturaItem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridFakturaItem.ColumnHeadersHeight = 60;
            this.dbgridFakturaItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridFakturaItem.Location = new System.Drawing.Point(3, 290);
            this.dbgridFakturaItem.MultiSelect = false;
            this.dbgridFakturaItem.Name = "dbgridFakturaItem";
            this.dbgridFakturaItem.ReadOnly = true;
            this.dbgridFakturaItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridFakturaItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridFakturaItem.Size = new System.Drawing.Size(1093, 298);
            this.dbgridFakturaItem.TabIndex = 48;
            this.dbgridFakturaItem.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridFakturaItem_RowPostPaint_1);
            // 
            // dbgridFaktura
            // 
            this.dbgridFaktura.AllowUserToAddRows = false;
            this.dbgridFaktura.AllowUserToDeleteRows = false;
            this.dbgridFaktura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridFaktura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridFaktura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridFaktura.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridFaktura.ColumnHeadersHeight = 60;
            this.dbgridFaktura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridFaktura.Location = new System.Drawing.Point(3, 30);
            this.dbgridFaktura.MultiSelect = false;
            this.dbgridFaktura.Name = "dbgridFaktura";
            this.dbgridFaktura.ReadOnly = true;
            this.dbgridFaktura.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridFaktura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridFaktura.Size = new System.Drawing.Size(1093, 254);
            this.dbgridFaktura.TabIndex = 2;
            this.dbgridFaktura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridFaktura_CellClick);
            this.dbgridFaktura.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridFaktura_RowPostPaint_1);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(-2, 1);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(398, 26);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "Малумотлар юкланмокда, илтимос кутинг!";
            this.lblStatus.Visible = false;
            // 
            // btnQabulQilish
            // 
            this.btnQabulQilish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQabulQilish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnQabulQilish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQabulQilish.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQabulQilish.IconChar = FontAwesome.Sharp.IconChar.ClipboardCheck;
            this.btnQabulQilish.IconColor = System.Drawing.Color.Gainsboro;
            this.btnQabulQilish.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQabulQilish.IconSize = 30;
            this.btnQabulQilish.Location = new System.Drawing.Point(929, 590);
            this.btnQabulQilish.Name = "btnQabulQilish";
            this.btnQabulQilish.Size = new System.Drawing.Size(170, 36);
            this.btnQabulQilish.TabIndex = 5;
            this.btnQabulQilish.Text = "Кабул килиш";
            this.btnQabulQilish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQabulQilish.UseVisualStyleBackColor = false;
            this.btnQabulQilish.Click += new System.EventHandler(this.btnQabulQilish_Click);
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
            this.tabControl1.TabIndex = 48;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dbgridPriceCart);
            this.tabPage4.Controls.Add(this.dbgridChangedPrice);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.pricemonth);
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1099, 626);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Нарх ўзгариш жадвали";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dbgridPriceCart
            // 
            this.dbgridPriceCart.AllowUserToAddRows = false;
            this.dbgridPriceCart.AllowUserToDeleteRows = false;
            this.dbgridPriceCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridPriceCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridPriceCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridPriceCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbgridPriceCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dbgridPriceCart.ColumnHeadersHeight = 60;
            this.dbgridPriceCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridPriceCart.Location = new System.Drawing.Point(0, 308);
            this.dbgridPriceCart.MultiSelect = false;
            this.dbgridPriceCart.Name = "dbgridPriceCart";
            this.dbgridPriceCart.ReadOnly = true;
            this.dbgridPriceCart.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dbgridPriceCart.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridPriceCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridPriceCart.Size = new System.Drawing.Size(1093, 315);
            this.dbgridPriceCart.TabIndex = 28;
            this.dbgridPriceCart.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridPriceCart_RowPostPaint);
            // 
            // dbgridChangedPrice
            // 
            this.dbgridChangedPrice.AllowUserToAddRows = false;
            this.dbgridChangedPrice.AllowUserToDeleteRows = false;
            this.dbgridChangedPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridChangedPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridChangedPrice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridChangedPrice.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridChangedPrice.ColumnHeadersHeight = 60;
            this.dbgridChangedPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridChangedPrice.Location = new System.Drawing.Point(0, 45);
            this.dbgridChangedPrice.MultiSelect = false;
            this.dbgridChangedPrice.Name = "dbgridChangedPrice";
            this.dbgridChangedPrice.ReadOnly = true;
            this.dbgridChangedPrice.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dbgridChangedPrice.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridChangedPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridChangedPrice.Size = new System.Drawing.Size(1093, 257);
            this.dbgridChangedPrice.TabIndex = 27;
            this.dbgridChangedPrice.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridChangedPrice_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 30);
            this.label1.TabIndex = 26;
            this.label1.Text = "Нарх ўзгариш жадвали";
            // 
            // pricemonth
            // 
            this.pricemonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pricemonth.CalendarFont = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pricemonth.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.pricemonth.Location = new System.Drawing.Point(802, 3);
            this.pricemonth.Name = "pricemonth";
            this.pricemonth.Size = new System.Drawing.Size(291, 36);
            this.pricemonth.TabIndex = 25;
            this.pricemonth.ValueChanged += new System.EventHandler(this.pricemonth_ValueChanged);
            // 
            // frmTovarQabuli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 661);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmTovarQabuli";
            this.Text = "Товар Кабули";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTovarQabuli_FormClosing);
            this.Load += new System.EventHandler(this.frmTovarQabuli_Load);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgirdPriceCart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridStaff)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFakturaItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridFaktura)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridPriceCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridChangedPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchPrice;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboStaff;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dbgridStaff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblQayta;
        public System.Windows.Forms.DataGridView dbgridFakturaItem;
        public System.Windows.Forms.DataGridView dbgridFaktura;
        private System.Windows.Forms.Label lblStatus;
        private FontAwesome.Sharp.IconButton btnQabulQilish;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.DateTimePicker pricemonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dbgridProduct;
        private System.Windows.Forms.DataGridView dbgirdPriceCart;
        private System.Windows.Forms.DataGridView dbgridPriceCart;
        public System.Windows.Forms.DataGridView dbgridChangedPrice;
    }
}