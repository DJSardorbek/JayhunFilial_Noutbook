namespace Jayhunelectro
{
    partial class frmDebtTulov
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
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtEnterQuantity = new System.Windows.Forms.TextBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.txtQolganMiqdor = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnConfirm = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTotal.Location = new System.Drawing.Point(195, 315);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(589, 33);
            this.txtTotal.TabIndex = 24;
            // 
            // txtEnterQuantity
            // 
            this.txtEnterQuantity.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtEnterQuantity.Location = new System.Drawing.Point(195, 257);
            this.txtEnterQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.txtEnterQuantity.Name = "txtEnterQuantity";
            this.txtEnterQuantity.Size = new System.Drawing.Size(589, 36);
            this.txtEnterQuantity.TabIndex = 10;
            this.txtEnterQuantity.TextChanged += new System.EventHandler(this.txtEnterQuantity_TextChanged);
            // 
            // txtprice
            // 
            this.txtprice.Enabled = false;
            this.txtprice.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtprice.Location = new System.Drawing.Point(114, 194);
            this.txtprice.Margin = new System.Windows.Forms.Padding(5);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(670, 33);
            this.txtprice.TabIndex = 22;
            // 
            // txtQolganMiqdor
            // 
            this.txtQolganMiqdor.Enabled = false;
            this.txtQolganMiqdor.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQolganMiqdor.Location = new System.Drawing.Point(195, 134);
            this.txtQolganMiqdor.Margin = new System.Windows.Forms.Padding(5);
            this.txtQolganMiqdor.Name = "txtQolganMiqdor";
            this.txtQolganMiqdor.Size = new System.Drawing.Size(589, 33);
            this.txtQolganMiqdor.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtName.Location = new System.Drawing.Point(109, 73);
            this.txtName.Margin = new System.Windows.Forms.Padding(5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(675, 33);
            this.txtName.TabIndex = 20;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConfirm.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnConfirm.IconColor = System.Drawing.Color.Gainsboro;
            this.btnConfirm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfirm.IconSize = 24;
            this.btnConfirm.Location = new System.Drawing.Point(624, 373);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(160, 36);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "F2-Тўлаш";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.btnCancel.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.IconSize = 24;
            this.btnCancel.Location = new System.Drawing.Point(454, 373);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 36);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Бэкор килиш";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(27, 318);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 26);
            this.label9.TabIndex = 17;
            this.label9.Text = "Умумий_сумма :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(27, 260);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 26);
            this.label8.TabIndex = 16;
            this.label8.Text = "Тўлов микдори :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(27, 197);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 26);
            this.label7.TabIndex = 15;
            this.label7.Text = "Нархи :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(27, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 26);
            this.label6.TabIndex = 14;
            this.label6.Text = "Колган микдор :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Номи :";
            // 
            // frmDebtTulov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 433);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtEnterQuantity);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.txtQolganMiqdor);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDebtTulov";
            this.Padding = new System.Windows.Forms.Padding(33, 102, 33, 34);
            this.Text = "Насия тўлов";
            this.Load += new System.EventHandler(this.DebtTulov_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDebtTulov_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.TextBox txtEnterQuantity;
        public System.Windows.Forms.TextBox txtprice;
        public System.Windows.Forms.TextBox txtQolganMiqdor;
        public System.Windows.Forms.TextBox txtName;
        public FontAwesome.Sharp.IconButton btnConfirm;
    }
}