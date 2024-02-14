using Microsoft.EntityFrameworkCore;
using PROJ_207_Project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PROJ_207_Project_2
{
    /* Form to manage package and package product supplier
     * 
     * Contributor: Calvin
     * 
     * 08-07-2023
     */
    public partial class frmAddNewPkgProdSup : Form
    {
        public Package currentPkg;
        int selectedIndex;

        public frmAddNewPkgProdSup()
        {
            InitializeComponent();
        }

        private void frmAddNewPkgProdSup_Load(object sender, EventArgs e)
        {
            txtPackID.Text = currentPkg.PackageId.ToString(); //set text to current package
            txtPackID.ReadOnly = true; //read only
            this.Text = "Add New Product to Package";
            getSuppliers();

        }
        //method to display suppliers
        private void getSuppliers()
        {

            using (TravelExpertsContext db = new TravelExpertsContext()) //connect to db
            {
                List<Supplier> suppliers = db.Suppliers.OrderBy(s => s.SupplierId).ToList(); // get list sorted by id
                cboSupName.DataSource = suppliers;
                cboSupName.DisplayMember = "SupName";
                cboSupName.ValueMember = "SupplierId";
            }
            //set default
            cboSupName.SelectedIndex = -1;
            cboSupName.Text = "select a supplier";
        }
        //method to get products related to the selected supplier
        private void getProducts(int SelectedValue)
        {
            using (TravelExpertsContext db = new TravelExpertsContext()) //connect to db
            {
                List<ProductSupplier> productsup = db.ProductsSuppliers.Include(s => s.Product).Include(s => s.Supplier).Where(s => s.SupplierId == SelectedValue).OrderBy(s => s.ProductId).ToList(); // get list sorted by id
                cboProdName.DataSource = productsup;
                cboProdName.DisplayMember = "Product";
                cboProdName.ValueMember = "ProductId";
            }

        }

        //adds product to package
        private void SavePkgProdSup_Click(object sender, EventArgs e)
        {
            PackagesProductsSupplier packprodsup = new PackagesProductsSupplier(); // make object for packageproductsupplier
            try {
                using (TravelExpertsContext db = new TravelExpertsContext()) //connect to db
                {
                    //productsupplier id where supplierid and product id = the value in combobox
                    List<ProductSupplier> prodsupID = db.ProductsSuppliers
                        .Where(p => p.SupplierId == Convert.ToInt32(cboSupName.SelectedValue) && p.ProductId == Convert.ToInt32(cboProdName.SelectedValue))
                        .ToList();
                    packprodsup.PackageId = Convert.ToInt32(txtPackID.Text);
                    packprodsup.ProductSupplierId = prodsupID[0].ProductSupplierId;

                    //check if productsupplierid exist in packagesproductsupplier
                    List<PackagesProductsSupplier> verify = null; //set to null first

                    db.PackagesProductsSuppliers.Where(v => v.ProductSupplierId == packprodsup.ProductSupplierId
                    && v.PackageId == Convert.ToInt32(txtPackID.Text)).ToList();

                    // if verify contains a match then it wont be null
                    if (verify != null)
                    {
                        MessageBox.Show("Product from the supplier already exist.");
                    }
                    else //if its null
                    {
                        try
                        {
                            db.PackagesProductsSuppliers.Add(packprodsup);
                            db.SaveChanges();
                            this.DialogResult = DialogResult.OK; //close form
                        }
                        catch
                        {
                            MessageBox.Show("Product from the supplier already exist.");
                        }
                    }

                }
            } 
            catch 
            {
                MessageBox.Show("Please select a supplier and product to add.");
            }
            

            

        }

        private void btnClosePkgProdSup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //method to display products
        private void cboSupName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedIndex = Convert.ToInt32(cboSupName.SelectedValue); //assign the supplier id value to selectedindex
            getProducts(selectedIndex);//get products from selectedindex

        }
    }
}