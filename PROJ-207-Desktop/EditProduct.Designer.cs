namespace PROJ_207_Project_2
{
	partial class EditProduct
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
			idLabel=new Label();
			idTextBox=new TextBox();
			nameTextBox=new TextBox();
			nameLabel=new Label();
			saveButton=new Button();
			closeButton=new Button();
			SuspendLayout();
			// 
			// idLabel
			// 
			idLabel.AutoSize=true;
			idLabel.Location=new Point(12, 9);
			idLabel.Name="idLabel";
			idLabel.Size=new Size(18, 15);
			idLabel.TabIndex=0;
			idLabel.Text="ID";
			// 
			// idTextBox
			// 
			idTextBox.Location=new Point(12, 27);
			idTextBox.Name="idTextBox";
			idTextBox.ReadOnly=true;
			idTextBox.Size=new Size(200, 23);
			idTextBox.TabIndex=1;
			// 
			// nameTextBox
			// 
			nameTextBox.Location=new Point(12, 71);
			nameTextBox.MaxLength=50;
			nameTextBox.Name="nameTextBox";
			nameTextBox.Size=new Size(200, 23);
			nameTextBox.TabIndex=2;
			// 
			// nameLabel
			// 
			nameLabel.AutoSize=true;
			nameLabel.Location=new Point(12, 53);
			nameLabel.Name="nameLabel";
			nameLabel.Size=new Size(39, 15);
			nameLabel.TabIndex=3;
			nameLabel.Text="Name";
			// 
			// saveButton
			// 
			saveButton.Location=new Point(12, 100);
			saveButton.Name="saveButton";
			saveButton.Size=new Size(97, 23);
			saveButton.TabIndex=4;
			saveButton.Text="Save";
			saveButton.UseVisualStyleBackColor=true;
			saveButton.Click+=saveButton_Click;
			// 
			// closeButton
			// 
			closeButton.Location=new Point(115, 100);
			closeButton.Name="closeButton";
			closeButton.Size=new Size(97, 23);
			closeButton.TabIndex=5;
			closeButton.Text="Close";
			closeButton.UseVisualStyleBackColor=true;
			closeButton.Click+=closeButton_Click;
			// 
			// EditProduct
			// 
			AutoScaleDimensions=new SizeF(7F, 15F);
			AutoScaleMode=AutoScaleMode.Font;
			ClientSize=new Size(221, 132);
			Controls.Add(closeButton);
			Controls.Add(saveButton);
			Controls.Add(nameLabel);
			Controls.Add(nameTextBox);
			Controls.Add(idTextBox);
			Controls.Add(idLabel);
			Name="EditProduct";
			Text="Edit Product";
			Load+=EditProduct_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label idLabel;
		private TextBox idTextBox;
		private TextBox nameTextBox;
		private Label nameLabel;
		private Button saveButton;
		private Button closeButton;
	}
}