namespace PROJ_207_Project_2
{
    partial class AddModifySupplier
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
            lblId = new Label();
            txtID = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(30, 24);
            lblId.Name = "lblId";
            lblId.Size = new Size(70, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Supplier ID: ";
            // 
            // txtID
            // 
            txtID.Location = new Point(110, 21);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 1;
            txtID.Tag = "Supplier ID";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 68);
            lblName.Name = "lblName";
            lblName.Size = new Size(88, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Supplier Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(110, 65);
            txtName.Name = "txtName";
            txtName.Size = new Size(172, 23);
            txtName.TabIndex = 3;
            txtName.Tag = "Supplier Name";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(30, 120);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "&Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(177, 120);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddModifySupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 164);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtID);
            Controls.Add(lblId);
            Name = "AddModifySupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += AddModifySupplier_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtID;
        private Label lblName;
        private TextBox txtName;
        private Button btnOk;
        private Button btnCancel;
    }
}