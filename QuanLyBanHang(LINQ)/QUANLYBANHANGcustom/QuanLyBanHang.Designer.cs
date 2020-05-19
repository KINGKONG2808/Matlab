namespace QUANLYBANHANGcustom
{
    partial class QuanLyBanHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodeProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtNameProduct = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbKindOfProduct = new System.Windows.Forms.ComboBox();
            this.ma_sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma_loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.don_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code Product";
            // 
            // txtCodeProduct
            // 
            this.txtCodeProduct.Location = new System.Drawing.Point(212, 37);
            this.txtCodeProduct.Name = "txtCodeProduct";
            this.txtCodeProduct.Size = new System.Drawing.Size(249, 22);
            this.txtCodeProduct.TabIndex = 1;
            this.txtCodeProduct.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unit Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kind of Product";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(212, 205);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(249, 22);
            this.txtUnitPrice.TabIndex = 5;
            this.txtUnitPrice.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtNameProduct
            // 
            this.txtNameProduct.Location = new System.Drawing.Point(212, 92);
            this.txtNameProduct.Name = "txtNameProduct";
            this.txtNameProduct.Size = new System.Drawing.Size(249, 22);
            this.txtNameProduct.TabIndex = 7;
            this.txtNameProduct.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(540, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 33);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(540, 92);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(97, 33);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(540, 150);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 33);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(540, 205);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 33);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma_sp,
            this.ten_sp,
            this.ma_loai,
            this.don_gia});
            this.dataGridView1.Location = new System.Drawing.Point(12, 279);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(652, 302);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // cbKindOfProduct
            // 
            this.cbKindOfProduct.FormattingEnabled = true;
            this.cbKindOfProduct.Location = new System.Drawing.Point(212, 150);
            this.cbKindOfProduct.Name = "cbKindOfProduct";
            this.cbKindOfProduct.Size = new System.Drawing.Size(249, 24);
            this.cbKindOfProduct.TabIndex = 13;
            // 
            // ma_sp
            // 
            this.ma_sp.DataPropertyName = "ma_sp";
            this.ma_sp.HeaderText = "CodeProduct";
            this.ma_sp.MinimumWidth = 6;
            this.ma_sp.Name = "ma_sp";
            this.ma_sp.Width = 125;
            // 
            // ten_sp
            // 
            this.ten_sp.DataPropertyName = "ten_sp";
            this.ten_sp.HeaderText = "NameProduct";
            this.ten_sp.MinimumWidth = 6;
            this.ten_sp.Name = "ten_sp";
            this.ten_sp.Width = 125;
            // 
            // ma_loai
            // 
            this.ma_loai.DataPropertyName = "ma_loai";
            this.ma_loai.HeaderText = "KindOfProduct";
            this.ma_loai.MinimumWidth = 6;
            this.ma_loai.Name = "ma_loai";
            this.ma_loai.Width = 125;
            // 
            // don_gia
            // 
            this.don_gia.DataPropertyName = "don_gia";
            this.don_gia.HeaderText = "UnitPrices";
            this.don_gia.MinimumWidth = 6;
            this.don_gia.Name = "don_gia";
            this.don_gia.Width = 125;
            // 
            // QuanLyBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 593);
            this.Controls.Add(this.cbKindOfProduct);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNameProduct);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodeProduct);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodeProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtNameProduct;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbKindOfProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_sp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_sp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn don_gia;
    }
}

