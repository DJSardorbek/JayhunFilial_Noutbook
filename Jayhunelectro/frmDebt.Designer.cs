namespace Jayhunelectro
{
    partial class frmDebt
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTasdiqlash = new FontAwesome.Sharp.IconButton();
            this.comboDebitor = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboTel1 = new System.Windows.Forms.ComboBox();
            this.comboTel2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJamiSumma = new System.Windows.Forms.TextBox();
            this.btnNew = new FontAwesome.Sharp.IconButton();
            this.txtFISH = new System.Windows.Forms.TextBox();
            this.txtTel1 = new System.Windows.Forms.TextBox();
            this.txtTel2 = new System.Windows.Forms.TextBox();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBarcode = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.label1.Location = new System.Drawing.Point(27, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мижоз фиш:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.label2.Location = new System.Drawing.Point(27, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тэл_1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.label3.Location = new System.Drawing.Point(421, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тэл_2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.label4.Location = new System.Drawing.Point(27, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "Кайтариш санаси:";
            // 
            // btnTasdiqlash
            // 
            this.btnTasdiqlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTasdiqlash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnTasdiqlash.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTasdiqlash.FlatAppearance.BorderSize = 0;
            this.btnTasdiqlash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTasdiqlash.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTasdiqlash.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            this.btnTasdiqlash.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTasdiqlash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTasdiqlash.IconSize = 24;
            this.btnTasdiqlash.Location = new System.Drawing.Point(667, 338);
            this.btnTasdiqlash.Name = "btnTasdiqlash";
            this.btnTasdiqlash.Size = new System.Drawing.Size(135, 36);
            this.btnTasdiqlash.TabIndex = 12;
            this.btnTasdiqlash.Text = "Тасдиклаш";
            this.btnTasdiqlash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTasdiqlash.UseVisualStyleBackColor = false;
            this.btnTasdiqlash.Click += new System.EventHandler(this.btnTasdiqlash_Click);
            // 
            // comboDebitor
            // 
            this.comboDebitor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboDebitor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboDebitor.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.comboDebitor.FormattingEnabled = true;
            this.comboDebitor.Location = new System.Drawing.Point(165, 70);
            this.comboDebitor.Name = "comboDebitor";
            this.comboDebitor.Size = new System.Drawing.Size(530, 35);
            this.comboDebitor.TabIndex = 21;
            this.comboDebitor.SelectedIndexChanged += new System.EventHandler(this.comboDebitor_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.dateTimePicker1.Location = new System.Drawing.Point(215, 138);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(587, 34);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // comboTel1
            // 
            this.comboTel1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboTel1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTel1.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.comboTel1.FormattingEnabled = true;
            this.comboTel1.Location = new System.Drawing.Point(103, 205);
            this.comboTel1.Name = "comboTel1";
            this.comboTel1.Size = new System.Drawing.Size(300, 35);
            this.comboTel1.TabIndex = 23;
            this.comboTel1.SelectedIndexChanged += new System.EventHandler(this.comboTel1_SelectedIndexChanged);
            // 
            // comboTel2
            // 
            this.comboTel2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboTel2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTel2.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.comboTel2.FormattingEnabled = true;
            this.comboTel2.Location = new System.Drawing.Point(497, 204);
            this.comboTel2.Name = "comboTel2";
            this.comboTel2.Size = new System.Drawing.Size(305, 35);
            this.comboTel2.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.label5.Location = new System.Drawing.Point(27, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 27);
            this.label5.TabIndex = 25;
            this.label5.Text = "Жами Сумма:";
            // 
            // txtJamiSumma
            // 
            this.txtJamiSumma.Enabled = false;
            this.txtJamiSumma.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.txtJamiSumma.Location = new System.Drawing.Point(175, 268);
            this.txtJamiSumma.Name = "txtJamiSumma";
            this.txtJamiSumma.Size = new System.Drawing.Size(627, 34);
            this.txtJamiSumma.TabIndex = 26;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Red;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNew.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnNew.IconColor = System.Drawing.Color.Gainsboro;
            this.btnNew.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNew.IconSize = 24;
            this.btnNew.Location = new System.Drawing.Point(710, 71);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(92, 35);
            this.btnNew.TabIndex = 27;
            this.btnNew.Text = "Йанги";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtFISH
            // 
            this.txtFISH.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.txtFISH.Location = new System.Drawing.Point(165, 70);
            this.txtFISH.Name = "txtFISH";
            this.txtFISH.Size = new System.Drawing.Size(530, 34);
            this.txtFISH.TabIndex = 28;
            this.txtFISH.Visible = false;
            // 
            // txtTel1
            // 
            this.txtTel1.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.txtTel1.Location = new System.Drawing.Point(103, 206);
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(300, 34);
            this.txtTel1.TabIndex = 29;
            this.txtTel1.Visible = false;
            // 
            // txtTel2
            // 
            this.txtTel2.Font = new System.Drawing.Font("Calibri", 16.25F);
            this.txtTel2.Location = new System.Drawing.Point(497, 204);
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(305, 34);
            this.txtTel2.TabIndex = 30;
            this.txtTel2.Visible = false;
            this.txtTel2.TextChanged += new System.EventHandler(this.txtTel2_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.Backspace;
            this.btnCancel.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.IconSize = 24;
            this.btnCancel.Location = new System.Drawing.Point(516, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 36);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Оркага";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBarcode
            // 
            this.pictureBarcode.Location = new System.Drawing.Point(88, 314);
            this.pictureBarcode.Name = "pictureBarcode";
            this.pictureBarcode.Size = new System.Drawing.Size(130, 60);
            this.pictureBarcode.TabIndex = 32;
            this.pictureBarcode.TabStop = false;
            this.pictureBarcode.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // frmDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 404);
            this.Controls.Add(this.pictureBarcode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtTel2);
            this.Controls.Add(this.txtTel1);
            this.Controls.Add(this.txtFISH);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtJamiSumma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboTel2);
            this.Controls.Add(this.comboTel1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboDebitor);
            this.Controls.Add(this.btnTasdiqlash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDebt";
            this.Text = "Насия Ойнаси";
            this.Load += new System.EventHandler(this.frmDebt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnTasdiqlash;
        private System.Windows.Forms.ComboBox comboDebitor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboTel1;
        private System.Windows.Forms.ComboBox comboTel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJamiSumma;
        private FontAwesome.Sharp.IconButton btnNew;
        private System.Windows.Forms.TextBox txtFISH;
        private System.Windows.Forms.TextBox txtTel1;
        private System.Windows.Forms.TextBox txtTel2;
        private FontAwesome.Sharp.IconButton btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBarcode;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}