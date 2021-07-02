namespace Jayhunelectro
{
    partial class frmCashDesk
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
            this.dbgridCashShop = new System.Windows.Forms.DataGridView();
            this.dbgridCashCart = new System.Windows.Forms.DataGridView();
            this.txtSearch = new MetroSet_UI.Controls.MetroSetTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton7 = new FontAwesome.Sharp.IconButton();
            this.btnNasiya = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnTulov = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridCashShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridCashCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgridCashShop
            // 
            this.dbgridCashShop.AllowUserToAddRows = false;
            this.dbgridCashShop.AllowUserToDeleteRows = false;
            this.dbgridCashShop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridCashShop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridCashShop.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridCashShop.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridCashShop.ColumnHeadersHeight = 60;
            this.dbgridCashShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridCashShop.Location = new System.Drawing.Point(2, 75);
            this.dbgridCashShop.MultiSelect = false;
            this.dbgridCashShop.Name = "dbgridCashShop";
            this.dbgridCashShop.ReadOnly = true;
            this.dbgridCashShop.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridCashShop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridCashShop.Size = new System.Drawing.Size(1103, 228);
            this.dbgridCashShop.TabIndex = 0;
            this.dbgridCashShop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridCashShop_CellClick);
            this.dbgridCashShop.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridCashShop_RowPostPaint);
            // 
            // dbgridCashCart
            // 
            this.dbgridCashCart.AllowUserToAddRows = false;
            this.dbgridCashCart.AllowUserToDeleteRows = false;
            this.dbgridCashCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridCashCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridCashCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridCashCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridCashCart.ColumnHeadersHeight = 60;
            this.dbgridCashCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridCashCart.Location = new System.Drawing.Point(3, 309);
            this.dbgridCashCart.MultiSelect = false;
            this.dbgridCashCart.Name = "dbgridCashCart";
            this.dbgridCashCart.ReadOnly = true;
            this.dbgridCashCart.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridCashCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridCashCart.Size = new System.Drawing.Size(1103, 310);
            this.dbgridCashCart.TabIndex = 1;
            this.dbgridCashCart.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridCashCart_RowPostPaint);
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
            this.txtSearch.Location = new System.Drawing.Point(46, 2);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.Size = new System.Drawing.Size(928, 38);
            this.txtSearch.Style = MetroSet_UI.Enums.Style.Light;
            this.txtSearch.StyleManager = null;
            this.txtSearch.TabIndex = 44;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.ThemeAuthor = "Narwin";
            this.txtSearch.ThemeName = "MetroLite";
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.WatermarkText = "Чек...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.label1.Location = new System.Drawing.Point(-3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 29);
            this.label1.TabIndex = 45;
            this.label1.Text = "Тўлов жадвали";
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 24;
            this.iconButton1.Location = new System.Drawing.Point(490, 623);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(144, 36);
            this.iconButton1.TabIndex = 50;
            this.iconButton1.Text = "Чек созлаш";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton7
            // 
            this.iconButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconButton7.FlatAppearance.BorderSize = 0;
            this.iconButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton7.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iconButton7.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton7.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.iconButton7.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton7.IconSize = 24;
            this.iconButton7.Location = new System.Drawing.Point(982, 2);
            this.iconButton7.Margin = new System.Windows.Forms.Padding(5);
            this.iconButton7.Name = "iconButton7";
            this.iconButton7.Size = new System.Drawing.Size(123, 38);
            this.iconButton7.TabIndex = 49;
            this.iconButton7.Text = "Йангилаш";
            this.iconButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton7.UseVisualStyleBackColor = false;
            this.iconButton7.Click += new System.EventHandler(this.iconButton7_Click);
            // 
            // btnNasiya
            // 
            this.btnNasiya.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNasiya.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnNasiya.FlatAppearance.BorderSize = 0;
            this.btnNasiya.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNasiya.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNasiya.IconChar = FontAwesome.Sharp.IconChar.Dna;
            this.btnNasiya.IconColor = System.Drawing.Color.Gainsboro;
            this.btnNasiya.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNasiya.IconSize = 24;
            this.btnNasiya.Location = new System.Drawing.Point(773, 623);
            this.btnNasiya.Name = "btnNasiya";
            this.btnNasiya.Size = new System.Drawing.Size(125, 36);
            this.btnNasiya.TabIndex = 48;
            this.btnNasiya.Text = "F8-Насия";
            this.btnNasiya.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNasiya.UseVisualStyleBackColor = false;
            this.btnNasiya.Click += new System.EventHandler(this.btnNasiya_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.btnCancel.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.IconSize = 24;
            this.btnCancel.Location = new System.Drawing.Point(906, 623);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(199, 36);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "F10-Бэкор килиш";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTulov
            // 
            this.btnTulov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTulov.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnTulov.FlatAppearance.BorderSize = 0;
            this.btnTulov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTulov.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTulov.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTulov.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnTulov.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnTulov.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTulov.IconSize = 24;
            this.btnTulov.Location = new System.Drawing.Point(642, 623);
            this.btnTulov.Margin = new System.Windows.Forms.Padding(5);
            this.btnTulov.Name = "btnTulov";
            this.btnTulov.Size = new System.Drawing.Size(123, 36);
            this.btnTulov.TabIndex = 46;
            this.btnTulov.Text = "F2-Тўлов";
            this.btnTulov.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTulov.UseVisualStyleBackColor = false;
            this.btnTulov.Click += new System.EventHandler(this.btnTulov_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 37;
            this.iconPictureBox2.Location = new System.Drawing.Point(3, 2);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(37, 37);
            this.iconPictureBox2.TabIndex = 43;
            this.iconPictureBox2.TabStop = false;
            // 
            // frmCashDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 661);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.iconButton7);
            this.Controls.Add(this.btnNasiya);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTulov);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.dbgridCashCart);
            this.Controls.Add(this.dbgridCashShop);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCashDesk";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmCashDesk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridCashShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridCashCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbgridCashShop;
        private System.Windows.Forms.DataGridView dbgridCashCart;
        public MetroSet_UI.Controls.MetroSetTextBox txtSearch;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label1;
        public FontAwesome.Sharp.IconButton btnCancel;
        public FontAwesome.Sharp.IconButton btnTulov;
        public FontAwesome.Sharp.IconButton btnNasiya;
        private FontAwesome.Sharp.IconButton iconButton7;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}