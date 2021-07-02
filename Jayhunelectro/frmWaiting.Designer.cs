namespace Jayhunelectro
{
    partial class frmWaiting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dbgridWaiting = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dbgridWaitingCart = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridWaitingCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgridWaiting
            // 
            this.dbgridWaiting.AllowUserToAddRows = false;
            this.dbgridWaiting.AllowUserToDeleteRows = false;
            this.dbgridWaiting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridWaiting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridWaiting.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridWaiting.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridWaiting.ColumnHeadersHeight = 60;
            this.dbgridWaiting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridWaiting.Location = new System.Drawing.Point(2, 79);
            this.dbgridWaiting.Margin = new System.Windows.Forms.Padding(5);
            this.dbgridWaiting.MultiSelect = false;
            this.dbgridWaiting.Name = "dbgridWaiting";
            this.dbgridWaiting.ReadOnly = true;
            this.dbgridWaiting.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 16.75F);
            this.dbgridWaiting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridWaiting.Size = new System.Drawing.Size(1101, 241);
            this.dbgridWaiting.TabIndex = 0;
            this.dbgridWaiting.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridWaiting_CellClick);
            this.dbgridWaiting.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridWaiting_RowPostPaint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(681, 615);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "F5-Корзинкага олиш";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Gainsboro;
            this.button2.Location = new System.Drawing.Point(891, 615);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "F10-Базага кайтариш";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 18.25F);
            this.txtSearch.Location = new System.Drawing.Point(40, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(962, 37);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dbgridWaitingCart
            // 
            this.dbgridWaitingCart.AllowUserToAddRows = false;
            this.dbgridWaitingCart.AllowUserToDeleteRows = false;
            this.dbgridWaitingCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbgridWaitingCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridWaitingCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridWaitingCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dbgridWaitingCart.ColumnHeadersHeight = 60;
            this.dbgridWaitingCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbgridWaitingCart.Location = new System.Drawing.Point(3, 324);
            this.dbgridWaitingCart.MultiSelect = false;
            this.dbgridWaitingCart.Name = "dbgridWaitingCart";
            this.dbgridWaitingCart.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbgridWaitingCart.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dbgridWaitingCart.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 16.75F);
            this.dbgridWaitingCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgridWaitingCart.Size = new System.Drawing.Size(1101, 288);
            this.dbgridWaitingCart.TabIndex = 19;
            this.dbgridWaitingCart.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dbgridWaitingCart_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.label1.Location = new System.Drawing.Point(-2, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 29);
            this.label1.TabIndex = 20;
            this.label1.Text = "Кутиш жадвали";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Gainsboro;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 37;
            this.iconPictureBox2.Location = new System.Drawing.Point(2, 5);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(37, 37);
            this.iconPictureBox2.TabIndex = 24;
            this.iconPictureBox2.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Consolas", 16.25F);
            this.radioButton1.Location = new System.Drawing.Point(1010, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(102, 30);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Чек...";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // frmWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 661);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbgridWaitingCart);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dbgridWaiting);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmWaiting";
            this.Text = "Waiting Window";
            this.Load += new System.EventHandler(this.frmWaiting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridWaitingCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbgridWaiting;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dbgridWaitingCart;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
    }
}