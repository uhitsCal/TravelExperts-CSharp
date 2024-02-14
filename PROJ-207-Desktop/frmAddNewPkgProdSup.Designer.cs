namespace PROJ_207_Project_2
{
    partial class frmAddNewPkgProdSup
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
            components = new System.ComponentModel.Container();
            Label packageIdLabel;
            Label lblSupplier;
            Label label1;
            packageProductSupplierBindingSource = new BindingSource(components);
            SavePkgProdSup = new Button();
            btnClosePkgProdSup = new Button();
            packageBindingSource = new BindingSource(components);
            productSupplierBindingSource = new BindingSource(components);
            supplierBindingSource = new BindingSource(components);
            productBindingSource = new BindingSource(components);
            txtPackID = new TextBox();
            cboSupName = new ComboBox();
            cboProdName = new ComboBox();
            packageIdLabel = new Label();
            lblSupplier = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)packageProductSupplierBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)packageBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productSupplierBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)supplierBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // packageIdLabel
            // 
            packageIdLabel.AutoSize = true;
            packageIdLabel.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            packageIdLabel.Location = new Point(23, 29);
            packageIdLabel.Margin = new Padding(2, 0, 2, 0);
            packageIdLabel.Name = "packageIdLabel";
            packageIdLabel.Size = new Size(92, 19);
            packageIdLabel.TabIndex = 3;
            packageIdLabel.Text = "Package ID:";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblSupplier.Location = new Point(43, 71);
            lblSupplier.Margin = new Padding(2, 0, 2, 0);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(72, 19);
            lblSupplier.TabIndex = 5;
            lblSupplier.Text = "Supplier: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(43, 110);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 19);
            label1.TabIndex = 6;
            label1.Text = "Product: ";
            // 
            // SavePkgProdSup
            // 
            SavePkgProdSup.BackColor = Color.MediumSeaGreen;
            SavePkgProdSup.FlatStyle = FlatStyle.Popup;
            SavePkgProdSup.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            SavePkgProdSup.ForeColor = SystemColors.ButtonHighlight;
            SavePkgProdSup.Location = new Point(43, 190);
            SavePkgProdSup.Margin = new Padding(2, 3, 2, 3);
            SavePkgProdSup.Name = "SavePkgProdSup";
            SavePkgProdSup.Size = new Size(71, 38);
            SavePkgProdSup.TabIndex = 1;
            SavePkgProdSup.Text = "&Add";
            SavePkgProdSup.UseVisualStyleBackColor = false;
            SavePkgProdSup.Click += SavePkgProdSup_Click;
            // 
            // btnClosePkgProdSup
            // 
            btnClosePkgProdSup.BackColor = Color.OrangeRed;
            btnClosePkgProdSup.FlatStyle = FlatStyle.Popup;
            btnClosePkgProdSup.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnClosePkgProdSup.ForeColor = SystemColors.ButtonHighlight;
            btnClosePkgProdSup.Location = new Point(209, 190);
            btnClosePkgProdSup.Margin = new Padding(2, 3, 2, 3);
            btnClosePkgProdSup.Name = "btnClosePkgProdSup";
            btnClosePkgProdSup.Size = new Size(71, 38);
            btnClosePkgProdSup.TabIndex = 2;
            btnClosePkgProdSup.Text = "&Close";
            btnClosePkgProdSup.UseVisualStyleBackColor = false;
            btnClosePkgProdSup.Click += btnClosePkgProdSup_Click;
            // 
            // supplierBindingSource
            // 
            supplierBindingSource.DataSource = typeof(Models.Supplier);
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Models.Product);
            // 
            // txtPackID
            // 
            txtPackID.Location = new Point(130, 29);
            txtPackID.Name = "txtPackID";
            txtPackID.Size = new Size(47, 23);
            txtPackID.TabIndex = 7;
            // 
            // cboSupName
            // 
            cboSupName.FormattingEnabled = true;
            cboSupName.Location = new Point(130, 71);
            cboSupName.Name = "cboSupName";
            cboSupName.Size = new Size(150, 23);
            cboSupName.TabIndex = 8;
            cboSupName.SelectionChangeCommitted += cboSupName_SelectionChangeCommitted;
            // 
            // cboProdName
            // 
            cboProdName.FormattingEnabled = true;
            cboProdName.Location = new Point(130, 110);
            cboProdName.Name = "cboProdName";
            cboProdName.Size = new Size(150, 23);
            cboProdName.TabIndex = 9;
            // 
            // frmAddNewPkgProdSup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(331, 276);
            Controls.Add(cboProdName);
            Controls.Add(cboSupName);
            Controls.Add(txtPackID);
            Controls.Add(label1);
            Controls.Add(lblSupplier);
            Controls.Add(packageIdLabel);
            Controls.Add(btnClosePkgProdSup);
            Controls.Add(SavePkgProdSup);
            Margin = new Padding(2, 3, 2, 3);
            Name = "frmAddNewPkgProdSup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddNewPkgProdSup";
            Load += frmAddNewPkgProdSup_Load;
            ((System.ComponentModel.ISupportInitialize)packageProductSupplierBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)packageBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)productSupplierBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)supplierBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource packageProductSupplierBindingSource;
        private Button SavePkgProdSup;
        private Button btnClosePkgProdSup;
        private BindingSource packageBindingSource;
        private TextBox txtPackageId;
        private BindingSource productSupplierBindingSource;
        private ComboBox cboSupplier;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private ComboBox cboProduct;
        private BindingSource supplierBindingSource;
        private BindingSource productBindingSource;
        private TextBox txtPackID;
        private ComboBox cboSupName;
        private ComboBox cboProdName;
    }
}
