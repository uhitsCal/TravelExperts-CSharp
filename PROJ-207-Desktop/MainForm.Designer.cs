namespace PROJ_207_Project_2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            packagesButton=new Button();
            suppliersButton=new Button();
            productsButton=new Button();
            SuspendLayout();
            // 
            // packagesButton
            // 
            packagesButton.Location=new Point(12, 12);
            packagesButton.Name="packagesButton";
            packagesButton.Size=new Size(75, 23);
            packagesButton.TabIndex=0;
            packagesButton.Text="Packages";
            packagesButton.UseVisualStyleBackColor=true;
            packagesButton.Click+=packagesButton_Click;
            // 
            // suppliersButton
            // 
            suppliersButton.Location=new Point(12, 41);
            suppliersButton.Name="suppliersButton";
            suppliersButton.Size=new Size(75, 23);
            suppliersButton.TabIndex=1;
            suppliersButton.Text="Suppliers";
            suppliersButton.UseVisualStyleBackColor=true;
            suppliersButton.Click+=suppliersButton_Click;
            // 
            // productsButton
            // 
            productsButton.Location=new Point(12, 70);
            productsButton.Name="productsButton";
            productsButton.Size=new Size(75, 23);
            productsButton.TabIndex=2;
            productsButton.Text="Products";
            productsButton.UseVisualStyleBackColor=true;
            productsButton.Click+=productsButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(353, 213);
            Controls.Add(productsButton);
            Controls.Add(suppliersButton);
            Controls.Add(packagesButton);
            Name="MainForm";
            Text="Employee Data Management Tool";
            ResumeLayout(false);
        }

        #endregion

        private Button packagesButton;
        private Button suppliersButton;
        private Button productsButton;
    }
}