namespace GamePlaceUI
{
    partial class SearchForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.PROD_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_PLAT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_CAT_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(597, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product: ";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(69, 9);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(522, 20);
            this.txtProduct.TabIndex = 2;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROD_ID,
            this.PROD_NM,
            this.PROD_PLAT_CD,
            this.PROD_CAT_CD,
            this.PROD_PRICE});
            this.dgvProduct.Location = new System.Drawing.Point(12, 35);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(750, 400);
            this.dgvProduct.TabIndex = 3;
            this.dgvProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_DoubleClick);
            // 
            // PROD_ID
            // 
            this.PROD_ID.DataPropertyName = "PROD_ID";
            this.PROD_ID.HeaderText = "ID";
            this.PROD_ID.Name = "PROD_ID";
            this.PROD_ID.ReadOnly = true;
            // 
            // PROD_NM
            // 
            this.PROD_NM.DataPropertyName = "PROD_NM";
            this.PROD_NM.HeaderText = "Product Name";
            this.PROD_NM.Name = "PROD_NM";
            this.PROD_NM.ReadOnly = true;
            this.PROD_NM.Width = 250;
            // 
            // PROD_PLAT_CD
            // 
            this.PROD_PLAT_CD.DataPropertyName = "PROD_PLAT_CD";
            this.PROD_PLAT_CD.HeaderText = "Platform";
            this.PROD_PLAT_CD.Name = "PROD_PLAT_CD";
            this.PROD_PLAT_CD.ReadOnly = true;
            this.PROD_PLAT_CD.Width = 125;
            // 
            // PROD_CAT_CD
            // 
            this.PROD_CAT_CD.DataPropertyName = "PROD_CAT_CD";
            this.PROD_CAT_CD.HeaderText = "Category";
            this.PROD_CAT_CD.Name = "PROD_CAT_CD";
            this.PROD_CAT_CD.ReadOnly = true;
            this.PROD_CAT_CD.Width = 125;
            // 
            // PROD_PRICE
            // 
            this.PROD_PRICE.DataPropertyName = "PROD_PRICE";
            this.PROD_PRICE.HeaderText = "Price";
            this.PROD_PRICE.Name = "PROD_PRICE";
            this.PROD_PRICE.ReadOnly = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_PLAT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_CAT_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_PRICE;
    }
}