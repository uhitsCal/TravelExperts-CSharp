
using System;

namespace PROJ_207_Project_2
{
    partial class frmTravelPackage
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
            Label packageIdLabel1;
            Label pkgAgencyCommissionLabel;
            Label pkgBasePriceLabel;
            Label pkgDescLabel;
            Label pkgEndDateLabel;
            Label pkgNameLabel;
            Label pkgStartDateLabel;
            TabControl = new TabControl();
            PackageTab = new TabPage();
            btnDeletePackage = new Button();
            btnDeleteProd = new Button();
            lvPackageProd = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            panel10 = new Panel();
            label7 = new Label();
            btnNewProducts = new Button();
            btnExitApplication = new Button();
            btnModPackage = new Button();
            btnAddPackage = new Button();
            PkgIdComboBox = new ComboBox();
            PkgAgencyCommissionTextBox = new TextBox();
            PkgBasePriceTextBox = new TextBox();
            PkgDescTextBox = new TextBox();
            pkgEndDateDateTimePicker = new DateTimePicker();
            PkgNameTextBox = new TextBox();
            pkgStartDateDateTimePicker = new DateTimePicker();
            packageProductSupplierBindingSource = new BindingSource(components);
            productBindingSource = new BindingSource(components);
            productSupplierBindingSource = new BindingSource(components);
            packageIdLabel1 = new Label();
            pkgAgencyCommissionLabel = new Label();
            pkgBasePriceLabel = new Label();
            pkgDescLabel = new Label();
            pkgEndDateLabel = new Label();
            pkgNameLabel = new Label();
            pkgStartDateLabel = new Label();
            TabControl.SuspendLayout();
            PackageTab.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)packageProductSupplierBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productSupplierBindingSource).BeginInit();
            SuspendLayout();
            // 
            // packageIdLabel1
            // 
            packageIdLabel1.AutoSize = true;
            packageIdLabel1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            packageIdLabel1.Location = new Point(10, 64);
            packageIdLabel1.Margin = new Padding(5, 0, 5, 0);
            packageIdLabel1.Name = "packageIdLabel1";
            packageIdLabel1.Size = new Size(80, 19);
            packageIdLabel1.TabIndex = 13;
            packageIdLabel1.Tag = "Package ID";
            packageIdLabel1.Text = "Package ID:";
            // 
            // pkgAgencyCommissionLabel
            // 
            pkgAgencyCommissionLabel.AutoSize = true;
            pkgAgencyCommissionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pkgAgencyCommissionLabel.Location = new Point(10, 344);
            pkgAgencyCommissionLabel.Margin = new Padding(5, 0, 5, 0);
            pkgAgencyCommissionLabel.Name = "pkgAgencyCommissionLabel";
            pkgAgencyCommissionLabel.Size = new Size(87, 19);
            pkgAgencyCommissionLabel.TabIndex = 2;
            pkgAgencyCommissionLabel.Tag = "Package Commission";
            pkgAgencyCommissionLabel.Text = "Commission:";
            // 
            // pkgBasePriceLabel
            // 
            pkgBasePriceLabel.AutoSize = true;
            pkgBasePriceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pkgBasePriceLabel.Location = new Point(10, 307);
            pkgBasePriceLabel.Margin = new Padding(5, 0, 5, 0);
            pkgBasePriceLabel.Name = "pkgBasePriceLabel";
            pkgBasePriceLabel.Size = new Size(73, 19);
            pkgBasePriceLabel.TabIndex = 4;
            pkgBasePriceLabel.Tag = "Package Base";
            pkgBasePriceLabel.Text = "Base Price:";
            // 
            // pkgDescLabel
            // 
            pkgDescLabel.AutoSize = true;
            pkgDescLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pkgDescLabel.Location = new Point(10, 215);
            pkgDescLabel.Margin = new Padding(5, 0, 5, 0);
            pkgDescLabel.Name = "pkgDescLabel";
            pkgDescLabel.Size = new Size(81, 19);
            pkgDescLabel.TabIndex = 6;
            pkgDescLabel.Tag = "Package Desc";
            pkgDescLabel.Text = "Description:";
            // 
            // pkgEndDateLabel
            // 
            pkgEndDateLabel.AutoSize = true;
            pkgEndDateLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pkgEndDateLabel.Location = new Point(10, 177);
            pkgEndDateLabel.Margin = new Padding(5, 0, 5, 0);
            pkgEndDateLabel.Name = "pkgEndDateLabel";
            pkgEndDateLabel.Size = new Size(68, 19);
            pkgEndDateLabel.TabIndex = 8;
            pkgEndDateLabel.Tag = "End Date";
            pkgEndDateLabel.Text = "End Date:";
            // 
            // pkgNameLabel
            // 
            pkgNameLabel.AutoSize = true;
            pkgNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pkgNameLabel.Location = new Point(10, 104);
            pkgNameLabel.Margin = new Padding(5, 0, 5, 0);
            pkgNameLabel.Name = "pkgNameLabel";
            pkgNameLabel.Size = new Size(48, 19);
            pkgNameLabel.TabIndex = 10;
            pkgNameLabel.Tag = "Package Name";
            pkgNameLabel.Text = "Name:";
            // 
            // pkgStartDateLabel
            // 
            pkgStartDateLabel.AutoSize = true;
            pkgStartDateLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pkgStartDateLabel.Location = new Point(10, 139);
            pkgStartDateLabel.Margin = new Padding(5, 0, 5, 0);
            pkgStartDateLabel.Name = "pkgStartDateLabel";
            pkgStartDateLabel.Size = new Size(74, 19);
            pkgStartDateLabel.TabIndex = 12;
            pkgStartDateLabel.Tag = "Start Date";
            pkgStartDateLabel.Text = "Start Date:";
            // 
            // TabControl
            // 
            TabControl.Controls.Add(PackageTab);
            TabControl.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TabControl.Location = new Point(14, 14);
            TabControl.Margin = new Padding(5);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(871, 687);
            TabControl.TabIndex = 2;
            // 
            // PackageTab
            // 
            PackageTab.AutoScroll = true;
            PackageTab.BackColor = SystemColors.HighlightText;
            PackageTab.Controls.Add(btnDeletePackage);
            PackageTab.Controls.Add(btnDeleteProd);
            PackageTab.Controls.Add(lvPackageProd);
            PackageTab.Controls.Add(panel10);
            PackageTab.Controls.Add(btnNewProducts);
            PackageTab.Controls.Add(btnExitApplication);
            PackageTab.Controls.Add(btnModPackage);
            PackageTab.Controls.Add(btnAddPackage);
            PackageTab.Controls.Add(packageIdLabel1);
            PackageTab.Controls.Add(PkgIdComboBox);
            PackageTab.Controls.Add(pkgAgencyCommissionLabel);
            PackageTab.Controls.Add(PkgAgencyCommissionTextBox);
            PackageTab.Controls.Add(pkgBasePriceLabel);
            PackageTab.Controls.Add(PkgBasePriceTextBox);
            PackageTab.Controls.Add(pkgDescLabel);
            PackageTab.Controls.Add(PkgDescTextBox);
            PackageTab.Controls.Add(pkgEndDateLabel);
            PackageTab.Controls.Add(pkgEndDateDateTimePicker);
            PackageTab.Controls.Add(pkgNameLabel);
            PackageTab.Controls.Add(PkgNameTextBox);
            PackageTab.Controls.Add(pkgStartDateLabel);
            PackageTab.Controls.Add(pkgStartDateDateTimePicker);
            PackageTab.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            PackageTab.ForeColor = SystemColors.ControlText;
            PackageTab.Location = new Point(4, 26);
            PackageTab.Margin = new Padding(5);
            PackageTab.Name = "PackageTab";
            PackageTab.Padding = new Padding(5);
            PackageTab.Size = new Size(863, 657);
            PackageTab.TabIndex = 0;
            PackageTab.Text = " Travel Package";
            // 
            // btnDeletePackage
            // 
            btnDeletePackage.BackColor = Color.MediumSeaGreen;
            btnDeletePackage.FlatStyle = FlatStyle.Popup;
            btnDeletePackage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeletePackage.ForeColor = SystemColors.ButtonHighlight;
            btnDeletePackage.Location = new Point(546, 166);
            btnDeletePackage.Margin = new Padding(4);
            btnDeletePackage.Name = "btnDeletePackage";
            btnDeletePackage.Size = new Size(279, 48);
            btnDeletePackage.TabIndex = 34;
            btnDeletePackage.Text = "Delete Package";
            btnDeletePackage.UseVisualStyleBackColor = false;
            btnDeletePackage.Click += btnDeletePackage_Click;
            // 
            // btnDeleteProd
            // 
            btnDeleteProd.BackColor = Color.MediumSeaGreen;
            btnDeleteProd.FlatStyle = FlatStyle.Popup;
            btnDeleteProd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteProd.ForeColor = SystemColors.ButtonHighlight;
            btnDeleteProd.Location = new Point(546, 556);
            btnDeleteProd.Margin = new Padding(4);
            btnDeleteProd.Name = "btnDeleteProd";
            btnDeleteProd.Size = new Size(279, 48);
            btnDeleteProd.TabIndex = 33;
            btnDeleteProd.Text = "Delete Product";
            btnDeleteProd.UseVisualStyleBackColor = false;
            btnDeleteProd.Click += btnDeleteProd_Click;
            // 
            // lvPackageProd
            // 
            lvPackageProd.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lvPackageProd.Location = new Point(15, 429);
            lvPackageProd.Name = "lvPackageProd";
            lvPackageProd.Size = new Size(465, 220);
            lvPackageProd.TabIndex = 32;
            lvPackageProd.UseCompatibleStateImageBehavior = false;
            lvPackageProd.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Supplier";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Product";
            columnHeader2.Width = 150;
            // 
            // panel10
            // 
            panel10.BackColor = Color.MediumSeaGreen;
            panel10.Controls.Add(label7);
            panel10.Location = new Point(15, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(400, 45);
            panel10.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(86, 5);
            label7.Name = "label7";
            label7.Size = new Size(152, 25);
            label7.TabIndex = 13;
            label7.Text = "Travel Packages";
            // 
            // btnNewProducts
            // 
            btnNewProducts.BackColor = Color.MediumSeaGreen;
            btnNewProducts.FlatStyle = FlatStyle.Popup;
            btnNewProducts.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNewProducts.ForeColor = SystemColors.ButtonHighlight;
            btnNewProducts.Location = new Point(546, 461);
            btnNewProducts.Margin = new Padding(4);
            btnNewProducts.Name = "btnNewProducts";
            btnNewProducts.Size = new Size(279, 48);
            btnNewProducts.TabIndex = 3;
            btnNewProducts.Text = "Add &New Product";
            btnNewProducts.UseVisualStyleBackColor = false;
            btnNewProducts.Click += btnNewProducts_Click;
            // 
            // btnExitApplication
            // 
            btnExitApplication.BackColor = Color.OrangeRed;
            btnExitApplication.FlatStyle = FlatStyle.Popup;
            btnExitApplication.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExitApplication.ForeColor = SystemColors.ButtonHighlight;
            btnExitApplication.Location = new Point(546, 251);
            btnExitApplication.Margin = new Padding(4);
            btnExitApplication.Name = "btnExitApplication";
            btnExitApplication.Size = new Size(279, 48);
            btnExitApplication.TabIndex = 4;
            btnExitApplication.Text = "&Exit";
            btnExitApplication.UseVisualStyleBackColor = false;
            btnExitApplication.Click += btnExitApplication_Click;
            // 
            // btnModPackage
            // 
            btnModPackage.BackColor = Color.MediumSeaGreen;
            btnModPackage.FlatStyle = FlatStyle.Popup;
            btnModPackage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnModPackage.ForeColor = SystemColors.ButtonHighlight;
            btnModPackage.Location = new Point(546, 89);
            btnModPackage.Margin = new Padding(2);
            btnModPackage.Name = "btnModPackage";
            btnModPackage.Size = new Size(279, 48);
            btnModPackage.TabIndex = 2;
            btnModPackage.Text = "&Modify Package";
            btnModPackage.UseVisualStyleBackColor = false;
            btnModPackage.Click += btnModPackage_Click;
            // 
            // btnAddPackage
            // 
            btnAddPackage.BackColor = Color.MediumSeaGreen;
            btnAddPackage.FlatStyle = FlatStyle.Popup;
            btnAddPackage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddPackage.ForeColor = SystemColors.ButtonHighlight;
            btnAddPackage.Location = new Point(546, 7);
            btnAddPackage.Margin = new Padding(2);
            btnAddPackage.Name = "btnAddPackage";
            btnAddPackage.Size = new Size(279, 48);
            btnAddPackage.TabIndex = 1;
            btnAddPackage.Text = "&Add Package";
            btnAddPackage.UseVisualStyleBackColor = false;
            btnAddPackage.Click += btnAddPackage_Click;
            // 
            // PkgIdComboBox
            // 
            PkgIdComboBox.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            PkgIdComboBox.FormattingEnabled = true;
            PkgIdComboBox.Location = new Point(145, 64);
            PkgIdComboBox.Margin = new Padding(5);
            PkgIdComboBox.Name = "PkgIdComboBox";
            PkgIdComboBox.Size = new Size(255, 27);
            PkgIdComboBox.TabIndex = 0;
            PkgIdComboBox.Tag = "Package ID";
            PkgIdComboBox.SelectedIndexChanged += PkgIdComboBox_SelectedIndexChanged;
            // 
            // PkgAgencyCommissionTextBox
            // 
            PkgAgencyCommissionTextBox.Enabled = false;
            PkgAgencyCommissionTextBox.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            PkgAgencyCommissionTextBox.Location = new Point(145, 341);
            PkgAgencyCommissionTextBox.Margin = new Padding(5);
            PkgAgencyCommissionTextBox.Name = "PkgAgencyCommissionTextBox";
            PkgAgencyCommissionTextBox.Size = new Size(255, 24);
            PkgAgencyCommissionTextBox.TabIndex = 3;
            PkgAgencyCommissionTextBox.Tag = "Package Commission";
            // 
            // PkgBasePriceTextBox
            // 
            PkgBasePriceTextBox.Enabled = false;
            PkgBasePriceTextBox.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            PkgBasePriceTextBox.Location = new Point(145, 307);
            PkgBasePriceTextBox.Margin = new Padding(5);
            PkgBasePriceTextBox.Name = "PkgBasePriceTextBox";
            PkgBasePriceTextBox.Size = new Size(255, 24);
            PkgBasePriceTextBox.TabIndex = 5;
            PkgBasePriceTextBox.Tag = "Package Base Price";
            // 
            // PkgDescTextBox
            // 
            PkgDescTextBox.Enabled = false;
            PkgDescTextBox.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            PkgDescTextBox.Location = new Point(145, 215);
            PkgDescTextBox.Margin = new Padding(5);
            PkgDescTextBox.Multiline = true;
            PkgDescTextBox.Name = "PkgDescTextBox";
            PkgDescTextBox.Size = new Size(255, 84);
            PkgDescTextBox.TabIndex = 7;
            PkgDescTextBox.Tag = "Package Description";
            // 
            // pkgEndDateDateTimePicker
            // 
            pkgEndDateDateTimePicker.Enabled = false;
            pkgEndDateDateTimePicker.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            pkgEndDateDateTimePicker.Format = DateTimePickerFormat.Short;
            pkgEndDateDateTimePicker.Location = new Point(145, 177);
            pkgEndDateDateTimePicker.Margin = new Padding(5);
            pkgEndDateDateTimePicker.Name = "pkgEndDateDateTimePicker";
            pkgEndDateDateTimePicker.Size = new Size(255, 24);
            pkgEndDateDateTimePicker.TabIndex = 9;
            pkgEndDateDateTimePicker.Tag = "End Date";
            // 
            // PkgNameTextBox
            // 
            PkgNameTextBox.Enabled = false;
            PkgNameTextBox.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            PkgNameTextBox.Location = new Point(145, 101);
            PkgNameTextBox.Margin = new Padding(5);
            PkgNameTextBox.Name = "PkgNameTextBox";
            PkgNameTextBox.Size = new Size(255, 24);
            PkgNameTextBox.TabIndex = 11;
            PkgNameTextBox.Tag = "Package Name";
            // 
            // pkgStartDateDateTimePicker
            // 
            pkgStartDateDateTimePicker.Enabled = false;
            pkgStartDateDateTimePicker.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            pkgStartDateDateTimePicker.Format = DateTimePickerFormat.Short;
            pkgStartDateDateTimePicker.Location = new Point(145, 139);
            pkgStartDateDateTimePicker.Margin = new Padding(5);
            pkgStartDateDateTimePicker.Name = "pkgStartDateDateTimePicker";
            pkgStartDateDateTimePicker.Size = new Size(255, 24);
            pkgStartDateDateTimePicker.TabIndex = 13;
            pkgStartDateDateTimePicker.Tag = "Start Date";
            // 
            // frmTravelPackage
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(892, 708);
            Controls.Add(TabControl);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmTravelPackage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Travel Experts";
            Load += frmTravelPackage_Load;
            TabControl.ResumeLayout(false);
            PackageTab.ResumeLayout(false);
            PackageTab.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)packageProductSupplierBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)productSupplierBindingSource).EndInit();
            ResumeLayout(false);
        }

        private void btnNewProducts_Click(EventArgs e, object sender) => throw new NotImplementedException();

        private void btnExitApplication_Click(EventArgs e, object sender) => throw new NotImplementedException();

        #endregion

        private TabControl TabControl;
        private TabPage PackageTab;
        private Button btnExitApplication;
        private Button btnModPackage;
        private Button btnAddPackage;
        private Button btnNewProducts;
        private ComboBox PkgIdComboBox;
        private TextBox PkgAgencyCommissionTextBox;
        private TextBox PkgBasePriceTextBox;
        private TextBox PkgDescTextBox;
        private DateTimePicker pkgEndDateDateTimePicker;
        private TextBox PkgNameTextBox;
        private DateTimePicker pkgStartDateDateTimePicker;
        private BindingSource packageProductSupplierBindingSource;
        private BindingSource productSupplierBindingSource;
        private BindingSource productBindingSource;
        private Panel panel10;
        private Label label7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Button btnDeleteProd;
        private ListView lvPackageProd;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnDeletePackage;
    }
}

