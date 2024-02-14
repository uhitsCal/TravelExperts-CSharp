namespace PROJ_207_Project_2
{
	partial class ProductsForm
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
			if (disposing && (components != null)) {
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
			productsListBox=new ListBox();
			editButton=new Button();
			createButton=new Button();
			productColumnNames=new Label();
			deleteButton=new Button();
			closeButton=new Button();
			SuspendLayout();
			// 
			// productsListBox
			// 
			productsListBox.Font=new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
			productsListBox.FormattingEnabled=true;
			productsListBox.HorizontalScrollbar=true;
			productsListBox.ItemHeight=14;
			productsListBox.Location=new Point(12, 26);
			productsListBox.Name="productsListBox";
			productsListBox.Size=new Size(256, 228);
			productsListBox.TabIndex=0;
			// 
			// editButton
			// 
			editButton.Location=new Point(12, 260);
			editButton.Name="editButton";
			editButton.Size=new Size(125, 23);
			editButton.TabIndex=1;
			editButton.Text="Edit";
			editButton.UseVisualStyleBackColor=true;
			editButton.Click+=editButton_Click;
			// 
			// createButton
			// 
			createButton.Location=new Point(12, 289);
			createButton.Name="createButton";
			createButton.Size=new Size(255, 23);
			createButton.TabIndex=3;
			createButton.Text="Create New";
			createButton.UseVisualStyleBackColor=true;
			createButton.Click+=createButton_Click;
			// 
			// productColumnNames
			// 
			productColumnNames.AutoSize=true;
			productColumnNames.Font=new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
			productColumnNames.Location=new Point(12, 8);
			productColumnNames.Name="productColumnNames";
			productColumnNames.Size=new Size(133, 14);
			productColumnNames.TabIndex=4;
			productColumnNames.Text="productColumnNames";
			// 
			// deleteButton
			// 
			deleteButton.Location=new Point(143, 260);
			deleteButton.Name="deleteButton";
			deleteButton.Size=new Size(125, 23);
			deleteButton.TabIndex=5;
			deleteButton.Text="Delete";
			deleteButton.UseVisualStyleBackColor=true;
			deleteButton.Click+=deleteButton_Click;
			// 
			// closeButton
			// 
			closeButton.Location=new Point(12, 318);
			closeButton.Name="closeButton";
			closeButton.Size=new Size(255, 23);
			closeButton.TabIndex=6;
			closeButton.Text="Close";
			closeButton.UseVisualStyleBackColor=true;
			closeButton.Click+=closeButton_Click_1;
			// 
			// ProductsForm
			// 
			AutoScaleDimensions=new SizeF(7F, 15F);
			AutoScaleMode=AutoScaleMode.Font;
			ClientSize=new Size(279, 352);
			Controls.Add(closeButton);
			Controls.Add(deleteButton);
			Controls.Add(productColumnNames);
			Controls.Add(createButton);
			Controls.Add(editButton);
			Controls.Add(productsListBox);
			Name="ProductsForm";
			Text="ProductsForm";
			Load+=ProductsForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox productsListBox;
		private Button editButton;
		private Button createButton;
		private Label productColumnNames;
		private Button deleteButton;
		private Button closeButton;
	}
}