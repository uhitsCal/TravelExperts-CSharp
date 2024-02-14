using PROJ_207_Project_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace PROJ_207_Project_2
{
    /* Form to manage products for suppliers
     * 
     * Contributor: Calvin C
     * 
     * 08-04-2023
     */
    public partial class AddDelProduct : Form
    {
        public ProductSupplier productsupply; //set by main form
        public bool isAdd; //set by main form
        public AddDelProduct()
        {
            InitializeComponent();
        }
        //method for when the form loads
        private void AddDelProduct_Load(object sender, EventArgs e)
        {
            GetProducts();//get the products and displays it
            this.Text = "Add a Product";// change form title
            txtCurrentSupplier.ReadOnly = true;//read-only
            txtCurrentSupplierID.ReadOnly = true;//read-only
        }
        //set textboxs for current supplier id
        public void SetCurrentSupplier(string currentsupplier, string currentSupplierID)
        {
            txtCurrentSupplier.Text = currentsupplier;
            txtCurrentSupplierID.Text = currentSupplierID;
        }
        //display the products
        private void GetProducts()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // list of products ordered by the product name
                List<Product> products = db.Products.OrderBy(p => p.ProdName).ToList();
                cboProduct.DataSource = products;
                cboProduct.DisplayMember = "ProdName";
                cboProduct.ValueMember = "ProductId";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                if (isAdd) // Add
                {
                    productsupply = new ProductSupplier(); //make a new product supply object
                }
                if (productsupply != null) //update based on the value
                {
                    productsupply.ProductId = Convert.ToInt32(cboProduct.SelectedValue.ToString());
                    productsupply.SupplierId = Convert.ToInt32(txtCurrentSupplierID.Text);
                }

                this.DialogResult = DialogResult.OK; // closes the form
            }
        }
        //close window
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
