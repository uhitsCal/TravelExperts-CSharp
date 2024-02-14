/*
 * Form for editing/adding a product.
 * 
 * Keegan Beaulieu
 * 
 * 2023-07-30
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROJ_207_Project_2.Models;

namespace PROJ_207_Project_2
{
	public partial class EditProduct : Form
	{
		private int productId { get; set; } = 0;

		public EditProduct(int productId = -1)
		{
			InitializeComponent();

			this.productId = productId;
		}

		private void EditProduct_Load(object sender, EventArgs e)
		{
			if (productId == -1)
				return;

			TravelExpertsContext db = new TravelExpertsContext();

			Product product = db.Products.Single(product => product.ProductId == productId);

			idTextBox.Text = product.ProductId.ToString();
			nameTextBox.Text = product.ProdName;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			if (!Validator.IsPresent(nameTextBox))
				return;

			TravelExpertsContext db = new TravelExpertsContext();

			Product product = new Product();

			if (productId != -1)
				product.ProductId = productId;

			product.ProdName = nameTextBox.Text;

			if (productId == -1)
				db.Products.Add(product);
			else
				db.Products.Update(product);

			db.SaveChanges();

			Close();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
