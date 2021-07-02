namespace Jayhunelectro
{
    partial class frmSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSales));
            this.dbgridProducts = new System.Windows.Forms.DataGridView();
            this.ctxtMenuProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveBasketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbgridBasket = new System.Windows.Forms.DataGridView();
            this.ctxtMenuBasket = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTulovSumma = new System.Windows.Forms.ComboBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconButton7 = new FontAwesome.Sharp.IconButton();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printWaiting = new System.Drawing.Printing.PrintDocument();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.ComboGuruh = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridProducts)).BeginInit();
            this.ctxtMenuProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridBasket)).BeginInit();
            this.ctxtMenuBasket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgridProducts
            // 
            this.dbgridProducts.AllowUserToAddRows = false;
            this.dbgridProducts.AllowUserToDeleteRows = false;
            this.dbgridProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbgridProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridProducts.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridProducts.ColumnHeadersHeight = 60;
            this.dbgridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridProducts.ContextMenuStrip = this.ctxtMenuProducts;
            this.dbgridProducts.Location = new System.Drawing.Point(12, 76);
            this.dbgridProducts.Margin = new System.Windows.Forms.Padding(5);
            this.dbgridProducts.MultiSelect = false;
            this.dbgridProducts.Name = "dbgridProducts";
            this.dbgridProducts.ReadOnly = true;
            this.dbgridProducts.RowTemplate.ContextMenuStrip = this.ctxtMenuProducts;
            this.dbgridProducts.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridProducts.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dbgridProducts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dbgridProducts.RowTemplate.Height = 30;
            this.dbgridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridProducts.Size = new System.Drawing.Size(1081, 213);
            this.dbgridProducts.TabIndex = 0;
            this.dbgridProducts.Visible = false;
            this.dbgridProducts.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridProducts_RowPostPaint);
            this.dbgridProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbgridProducts_KeyDown);
            // 
            // ctxtMenuProducts
            // 
            this.ctxtMenuProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveBasketToolStripMenuItem});
            this.ctxtMenuProducts.Name = "ctxtMenuProducts";
            this.ctxtMenuProducts.Size = new System.Drawing.Size(173, 26);
            // 
            // moveBasketToolStripMenuItem
            // 
            this.moveBasketToolStripMenuItem.Name = "moveBasketToolStripMenuItem";
            this.moveBasketToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.moveBasketToolStripMenuItem.Text = "Корзинкага олиш";
            this.moveBasketToolStripMenuItem.Click += new System.EventHandler(this.moveBasketToolStripMenuItem_Click);
            // 
            // dbgridBasket
            // 
            this.dbgridBasket.AllowUserToAddRows = false;
            this.dbgridBasket.AllowUserToDeleteRows = false;
            this.dbgridBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridBasket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbgridBasket.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridBasket.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridBasket.ColumnHeadersHeight = 60;
            this.dbgridBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridBasket.ContextMenuStrip = this.ctxtMenuBasket;
            this.dbgridBasket.Location = new System.Drawing.Point(1, 76);
            this.dbgridBasket.Margin = new System.Windows.Forms.Padding(5);
            this.dbgridBasket.MultiSelect = false;
            this.dbgridBasket.Name = "dbgridBasket";
            this.dbgridBasket.ReadOnly = true;
            this.dbgridBasket.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridBasket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridBasket.Size = new System.Drawing.Size(1103, 546);
            this.dbgridBasket.TabIndex = 2;
            this.dbgridBasket.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridBasket_RowPostPaint);
            this.dbgridBasket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbgridBasket_KeyDown);
            // 
            // ctxtMenuBasket
            // 
            this.ctxtMenuBasket.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.ctxtMenuBasket.Name = "ctxtMenuBasket";
            this.ctxtMenuBasket.Size = new System.Drawing.Size(121, 26);
            this.ctxtMenuBasket.TabStop = true;
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.deleteToolStripMenuItem.Text = "Ўчириш";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(38, 35);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(398, 36);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 16.25F);
            this.label3.Location = new System.Drawing.Point(740, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 26);
            this.label3.TabIndex = 26;
            this.label3.Text = "Тўлов суммаси";
            // 
            // txtTulovSumma
            // 
            this.txtTulovSumma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTulovSumma.BackColor = System.Drawing.Color.White;
            this.txtTulovSumma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtTulovSumma.Enabled = false;
            this.txtTulovSumma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTulovSumma.Font = new System.Drawing.Font("Calibri", 18.25F);
            this.txtTulovSumma.FormattingEnabled = true;
            this.txtTulovSumma.IntegralHeight = false;
            this.txtTulovSumma.ItemHeight = 29;
            this.txtTulovSumma.Location = new System.Drawing.Point(745, 35);
            this.txtTulovSumma.Name = "txtTulovSumma";
            this.txtTulovSumma.Size = new System.Drawing.Size(320, 36);
            this.txtTulovSumma.TabIndex = 31;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 36;
            this.iconPictureBox2.Location = new System.Drawing.Point(1, 35);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(36, 36);
            this.iconPictureBox2.TabIndex = 23;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.iconPictureBox2_Click);
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
            this.iconButton7.Location = new System.Drawing.Point(1068, 35);
            this.iconButton7.Margin = new System.Windows.Forms.Padding(5);
            this.iconButton7.Name = "iconButton7";
            this.iconButton7.Size = new System.Drawing.Size(36, 36);
            this.iconButton7.TabIndex = 11;
            this.iconButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton7.UseVisualStyleBackColor = false;
            this.iconButton7.Click += new System.EventHandler(this.iconButton7_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // printWaiting
            // 
            this.printWaiting.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printWaiting_PrintPage);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 16.25F);
            this.label2.Location = new System.Drawing.Point(-4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 26);
            this.label2.TabIndex = 35;
            this.label2.Text = "Махсулот_номи ёки штрих_код";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 16.25F);
            this.label1.Location = new System.Drawing.Point(433, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 26);
            this.label1.TabIndex = 37;
            this.label1.Text = "Гурух";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BorderRadius = 8;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(918, 626);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(186, 36);
            this.guna2Button1.TabIndex = 38;
            this.guna2Button1.Text = "F10 - Бэкор килиш";
            this.guna2Button1.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button4.BorderRadius = 8;
            this.guna2Button4.CheckedState.Parent = this.guna2Button4;
            this.guna2Button4.CustomImages.Parent = this.guna2Button4;
            this.guna2Button4.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.HoverState.Parent = this.guna2Button4;
            this.guna2Button4.Location = new System.Drawing.Point(770, 626);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
            this.guna2Button4.Size = new System.Drawing.Size(138, 36);
            this.guna2Button4.TabIndex = 41;
            this.guna2Button4.Text = "F6 - Навбат";
            this.guna2Button4.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button2.BorderRadius = 8;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(575, 626);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(185, 36);
            this.guna2Button2.TabIndex = 42;
            this.guna2Button2.Text = "F9 - Навбат кўриш";
            this.guna2Button2.Click += new System.EventHandler(this.iconButton3_Click_2);
            // 
            // guna2Button3
            // 
            this.guna2Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button3.BorderRadius = 8;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Location = new System.Drawing.Point(354, 626);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(209, 36);
            this.guna2Button3.TabIndex = 43;
            this.guna2Button3.Text = "F5 - Корзинкага олиш";
            this.guna2Button3.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button5.BorderRadius = 8;
            this.guna2Button5.CheckedState.Parent = this.guna2Button5;
            this.guna2Button5.CustomImages.Parent = this.guna2Button5;
            this.guna2Button5.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.HoverState.Parent = this.guna2Button5;
            this.guna2Button5.Location = new System.Drawing.Point(184, 626);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.ShadowDecoration.Parent = this.guna2Button5;
            this.guna2Button5.Size = new System.Drawing.Size(158, 36);
            this.guna2Button5.TabIndex = 44;
            this.guna2Button5.Text = "F2 - Касса";
            this.guna2Button5.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // guna2Button6
            // 
            this.guna2Button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button6.BorderRadius = 8;
            this.guna2Button6.CheckedState.Parent = this.guna2Button6;
            this.guna2Button6.CustomImages.Parent = this.guna2Button6;
            this.guna2Button6.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button6.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.HoverState.Parent = this.guna2Button6;
            this.guna2Button6.Location = new System.Drawing.Point(12, 626);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.ShadowDecoration.Parent = this.guna2Button6;
            this.guna2Button6.Size = new System.Drawing.Size(158, 36);
            this.guna2Button6.TabIndex = 45;
            this.guna2Button6.Text = "Чек созлаш";
            this.guna2Button6.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // ComboGuruh
            // 
            this.ComboGuruh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboGuruh.Font = new System.Drawing.Font("Calibri", 18F);
            this.ComboGuruh.FormattingEnabled = true;
            this.ComboGuruh.Location = new System.Drawing.Point(438, 34);
            this.ComboGuruh.Name = "ComboGuruh";
            this.ComboGuruh.Size = new System.Drawing.Size(301, 37);
            this.ComboGuruh.TabIndex = 46;
            this.ComboGuruh.SelectedIndexChanged += new System.EventHandler(this.ComboGuruh_SelectedIndexChanged);
            this.ComboGuruh.TextUpdate += new System.EventHandler(this.ComboGuruh_TextUpdate);
            this.ComboGuruh.RightToLeftChanged += new System.EventHandler(this.ComboGuruh_RightToLeftChanged);
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 661);
            this.Controls.Add(this.ComboGuruh);
            this.Controls.Add(this.guna2Button6);
            this.Controls.Add(this.guna2Button5);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button4);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbgridProducts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTulovSumma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconButton7);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dbgridBasket);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmSales";
            this.Text = "Сотиш Ойнаси";
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.SizeChanged += new System.EventHandler(this.frmSales_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridProducts)).EndInit();
            this.ctxtMenuProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridBasket)).EndInit();
            this.ctxtMenuBasket.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dbgridProducts;
        public System.Windows.Forms.DataGridView dbgridBasket;
        public System.Windows.Forms.ContextMenuStrip ctxtMenuProducts;
        public System.Windows.Forms.ToolStripMenuItem moveBasketToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxtMenuBasket;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private FontAwesome.Sharp.IconButton iconButton7;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtTulovSumma;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printWaiting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2Button guna2Button1;
        public Guna.UI2.WinForms.Guna2Button guna2Button4;
        public Guna.UI2.WinForms.Guna2Button guna2Button2;
        public Guna.UI2.WinForms.Guna2Button guna2Button3;
        public Guna.UI2.WinForms.Guna2Button guna2Button5;
        public Guna.UI2.WinForms.Guna2Button guna2Button6;
        private System.Windows.Forms.ComboBox ComboGuruh;
    }
}