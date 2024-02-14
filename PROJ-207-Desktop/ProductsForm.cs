/*
 * Main form for managing products.
 * 
 * Keegan Beaulieu
 * 
 * 2023-07-30
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PROJ_207_Project_2.Models;

namespace PROJ_207_Project_2
{
	public partial class ProductsForm : Form
	{
		public ProductsForm()
		{
			InitializeComponent();
		}

		// Refreshes the list box.
		private void RefreshListBox()
		{
			TravelExpertsContext db = new TravelExpertsContext();

			int selectionIndex = productsListBox.SelectedIndex;

			productsListBox.DataSource = db.Products.ToList();

			if (selectionIndex >= 0 && selectionIndex < productsListBox.Items.Count)
				productsListBox.SelectedIndex = selectionIndex;
		}

		// Initialize form.
		private void ProductsForm_Load(object sender, EventArgs e)
		{
			productColumnNames.Text = "ID".PadRight(Product.ID_COLUMN_WIDTH) + "Name";
			RefreshListBox();
		}

		private int GetSelectedProductId()
		{
			string? selectedString = productsListBox.SelectedValue.ToString();

			if (selectedString == null)
				return -1;

			return Convert.ToInt32(selectedString.Substring(0, Product.ID_COLUMN_WIDTH));
		}

		// Open form to edit currently selected product.
		private void editButton_Click(object sender, EventArgs e)
		{
			int selectedProductId = GetSelectedProductId();
			if (selectedProductId == -1)
				return;

			Form editProduct = new EditProduct(selectedProductId);
			editProduct.ShowDialog(this);

			RefreshListBox();
		}

		// Is this product referenced by a supplier>
		private bool ReferencedBySupplier(int productId, TravelExpertsContext db)
		{
			try {
				db.ProductsSuppliers.First(ps => ps.ProductId == productId);

				return true;
			} catch {
				return false;
			}
		}

		// Is this product referenced by a package?
		private bool ReferencedByPackage(int productId, TravelExpertsContext db)
		{
			try {
				db.PackagesProductsSuppliers.First(pps => pps.ProductSupplier.ProductId == productId);

				return true;
			} catch {
				return false;
			}
		}

		// Delete currently selected product.
		private void deleteButton_Click(object sender, EventArgs e)
		{
			TravelExpertsContext db = new TravelExpertsContext();

			int selectedProductId = GetSelectedProductId();
			if (selectedProductId == -1)
				return;

			if (ReferencedBySupplier(selectedProductId, db)) {
				bool referencedByPackage = ReferencedByPackage(selectedProductId, db);
				string referencedByString = referencedByPackage ? "supplier and package" : "supplier";

				DialogResult result = MessageBox.Show(
					$"Are you sure you want to delete this product? It is referenced by a {referencedByString}.",
					"Confirm delete.",
					MessageBoxButtons.YesNo
				);

				if (result == DialogResult.No)
					return;

				if (referencedByPackage)
					db.PackagesProductsSuppliers.Where(pps => pps.ProductSupplier.ProductId == selectedProductId).ExecuteDelete();

				db.BookingDetails.Where(bd => (bd.ProductSupplier != null) ? bd.ProductSupplier.ProductId == selectedProductId : false).ExecuteDelete();
				db.ProductsSuppliers.Where(ps => ps.ProductId == selectedProductId).ExecuteDelete();
			}

			db.Products.Where(product => product.ProductId == selectedProductId).ExecuteDelete();

			RefreshListBox();
		}

		// Open form to create new product.
		private void createButton_Click(object sender, EventArgs e)
		{
			// -1 means no product selected, so create a new one.
			Form editProduct = new EditProduct();
			editProduct.ShowDialog(this);

			RefreshListBox();
		}

		// Close the form.
		private void closeButton_Click_1(object sender, EventArgs e)
		{
			Close();
		}
	}
}
