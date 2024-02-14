namespace PROJ_207_Project_2
{
    partial class SuppliersForm
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
            lvSupplier = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnAddProd = new Button();
            label1 = new Label();
            lvProducts = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            btnDelProd = new Button();
            btnModSupplier = new Button();
            btnAddSupplier = new Button();
            lblProd = new Label();
            btnDeleteSupplier = new Button();
            SuspendLayout();
            // 
            // lvSupplier
            // 
            lvSupplier.Activation = ItemActivation.OneClick;
            lvSupplier.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lvSupplier.Location = new Point(21, 32);
            lvSupplier.MultiSelect = false;
            lvSupplier.Name = "lvSupplier";
            lvSupplier.Size = new Size(370, 427);
            lvSupplier.TabIndex = 0;
            lvSupplier.UseCompatibleStateImageBehavior = false;
            lvSupplier.View = View.Details;
            lvSupplier.ItemSelectionChanged += lvSupplier_ItemSelectionChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Supplier ID";
            columnHeader1.Width = 69;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Supplier Name";
            columnHeader2.Width = 250;
            // 
            // btnAddProd
            // 
            btnAddProd.Location = new Point(539, 471);
            btnAddProd.Name = "btnAddProd";
            btnAddProd.Size = new Size(98, 29);
            btnAddProd.TabIndex = 1;
            btnAddProd.Text = "Add Product";
            btnAddProd.UseVisualStyleBackColor = true;
            btnAddProd.Click += btnAddProd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 3;
            label1.Text = "Suppliers";
            // 
            // lvProducts
            // 
            lvProducts.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            lvProducts.Location = new Point(449, 32);
            lvProducts.MultiSelect = false;
            lvProducts.Name = "lvProducts";
            lvProducts.Size = new Size(311, 427);
            lvProducts.TabIndex = 4;
            lvProducts.UseCompatibleStateImageBehavior = false;
            lvProducts.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Product ID";
            columnHeader3.Width = 68;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Product Name";
            columnHeader4.Width = 200;
            // 
            // btnDelProd
            // 
            btnDelProd.Location = new Point(645, 471);
            btnDelProd.Name = "btnDelProd";
            btnDelProd.Size = new Size(117, 29);
            btnDelProd.TabIndex = 5;
            btnDelProd.Text = "Delete Product";
            btnDelProd.UseVisualStyleBackColor = true;
            btnDelProd.Click += btnDelProd_Click;
            // 
            // btnModSupplier
            // 
            btnModSupplier.Location = new Point(154, 471);
            btnModSupplier.Name = "btnModSupplier";
            btnModSupplier.Size = new Size(115, 29);
            btnModSupplier.TabIndex = 6;
            btnModSupplier.Text = "Modify Supplier";
            btnModSupplier.UseVisualStyleBackColor = true;
            btnModSupplier.Click += btnModSupplier_Click;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Location = new Point(48, 471);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(99, 29);
            btnAddSupplier.TabIndex = 7;
            btnAddSupplier.Text = "Add Supplier";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // lblProd
            // 
            lblProd.AutoSize = true;
            lblProd.Location = new Point(449, 9);
            lblProd.Name = "lblProd";
            lblProd.Size = new Size(66, 20);
            lblProd.TabIndex = 8;
            lblProd.Text = "Products";
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.Location = new Point(274, 471);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(117, 29);
            btnDeleteSupplier.TabIndex = 9;
            btnDeleteSupplier.Text = "Delete Supplier";
            btnDeleteSupplier.UseVisualStyleBackColor = true;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;
            // 
            // SuppliersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 515);
            Controls.Add(btnDeleteSupplier);
            Controls.Add(lblProd);
            Controls.Add(btnAddSupplier);
            Controls.Add(btnModSupplier);
            Controls.Add(btnDelProd);
            Controls.Add(lvProducts);
            Controls.Add(label1);
            Controls.Add(btnAddProd);
            Controls.Add(lvSupplier);
            Name = "SuppliersForm";
            Text = "SuppliersForm";
            Load += SuppliersForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvSupplier;
        private Button btnAddProd;
        private Label label1;
        private ListView lvProducts;
        private Button btnDelProd;
        private Button btnModSupplier;
        private Button btnAddSupplier;
        private Label lblProd;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button btnDeleteSupplier;
    }
}