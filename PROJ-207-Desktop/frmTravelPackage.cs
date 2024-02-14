using Microsoft.EntityFrameworkCore.Query.Internal;
using PROJ_207_Project_2.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


    /*Main form for Managing Packages 
     * 
     * Contributor: Calvin, Gabriel
     * 
     * 08-07-2023
     */

namespace PROJ_207_Project_2
{
    public partial class frmTravelPackage : Form
    {

        Package currentPkg = null; // current package
        List<int> packageIds = null; // all package ids
        List<PackagesProductsSupplier> currentPkgProdSup = null; // current pkg prod sup 

        List<int> supplierIds = null; // all supplier ids
        Supplier currentSup = null; // current supplier

        List<int> productIds = null; // all product ids
        Product currentProd = null; // current product

        List<int> productSupplierIds = null; // all prod sup ids
        ProductSupplier currentProdSup = null; // current prod sup

        public frmTravelPackage()
        {
            InitializeComponent();
        }

        /* -----------------------------
           PACKAGE TAB
           ----------------------------- */

        /// <summary>
        /// Loads combobox list of package, product, product-supplier, and supplier ids on-load
        /// </summary>
        private void frmTravelPackage_Load(object sender, EventArgs e)
        {
            this.Text = "Travel Experts Form";
            RefreshPkgComboBox();
            DisplayPackageProduct();
        }

        private void RefreshPkgComboBox(bool lastIndex = false)
        {
            int selectIndex = 0;
            packageIds = PackageDB.GetPackageIds();

            if (packageIds.Count > 0) // if there are packages 
            {
                PkgIdComboBox.DataSource = packageIds;

                if (lastIndex == true)
                {
                    selectIndex = PkgIdComboBox.Items.Count - 1;
                }

                PkgIdComboBox.SelectedIndex = selectIndex; // triggers selectedindexchanged 
            }
            else
            {
                MessageBox.Show("There are no packages. Add a package in the database and restart the application ", "Empty Load");
                Application.Exit();
            }
        }

        private void PkgIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(PkgIdComboBox.SelectedValue);
            try
            {
                currentPkg = PackageDB.GetPackage(selectedId);
                DisplayCurrentPkgData();
                DisplayPackageProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving package with selected ID: " + ex.Message,
                    ex.GetType().ToString());
            }
        }

        private void DisplayCurrentPkgData()
        {
            if (currentPkg != null)
            {
                PkgNameTextBox.Text = currentPkg.PkgName;
                PkgBasePriceTextBox.Text = currentPkg.PkgBasePrice.ToString("c");

                if (currentPkg.PkgStartDate == null)
                    pkgStartDateDateTimePicker.Text = "";
                else
                {
                    DateTime startDate = (DateTime)currentPkg.PkgStartDate;
                    pkgStartDateDateTimePicker.Text = startDate.ToShortDateString();
                }

                if (currentPkg.PkgEndDate == null)
                    pkgEndDateDateTimePicker.Text = "";
                else
                {
                    DateTime endDate = (DateTime)currentPkg.PkgEndDate;
                    pkgEndDateDateTimePicker.Text = endDate.ToShortDateString();
                }

                if (currentPkg.PkgDesc == null)
                    PkgDescTextBox.Text = "";
                else
                {
                    string desc = (string)currentPkg.PkgDesc;
                    PkgDescTextBox.Text = desc;
                }

                if (currentPkg.PkgAgencyCommission == null)
                    PkgAgencyCommissionTextBox.Text = "";
                else
                {
                    decimal commission = (decimal)currentPkg.PkgAgencyCommission;
                    PkgAgencyCommissionTextBox.Text = commission.ToString("c");
                }

                currentPkgProdSup = PackageProductSupplierDB.GetProductsSuppliersByPackageId(currentPkg.PackageId);
                //packageProductSupplierDataGridView.DataSource = currentPkgProdSup;
            }
            else
                MessageBox.Show("This package does not exist. Please try again.");
        }
        //
        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            frmAddModifyPackage addForm = new frmAddModifyPackage();
            addForm.addPackage = true;
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentPkg = addForm.package;
                PkgIdComboBox.Text = currentPkg.PackageId.ToString();
                this.DisplayCurrentPkgData();
                RefreshPkgComboBox(true);
                MessageBox.Show("New package has been added.");
            }
        }

        private void btnModPackage_Click(object sender, EventArgs e)
        {
            frmAddModifyPackage updateForm = new frmAddModifyPackage();
            updateForm.addPackage = false;
            updateForm.currentPkg = currentPkg;
            DialogResult result = updateForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentPkg = updateForm.currentPkg;
                MessageBox.Show("Package has been modified.");
            }
            else if (result == DialogResult.Retry)
            {
                currentPkg = PackageDB.GetPackage(currentPkg.PackageId);
            }
            DisplayCurrentPkgData();

        }

        private void btnNewProducts_Click(object sender, EventArgs e)
        {
            frmAddNewPkgProdSup newProdForm = new frmAddNewPkgProdSup();
            newProdForm.currentPkg = currentPkg;
            DialogResult result = newProdForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("New product supplier has been added to the package.");
                DisplayPackageProduct();
            }
        }

        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //method to update and display Products
        private void DisplayPackageProduct()
        {
            //get package id
            int ID = currentPkg.PackageId;
            lvPackageProd.Items.Clear();//clear listview
            using (TravelExpertsContext db = new TravelExpertsContext())//establish connection to database
            {
                //Create a List of objects of the database
                List<PackagesProductsSupplier> packprodsup = db.PackagesProductsSuppliers.ToList();//list objects for package product supplier
                List<ProductSupplier> prodsup = db.ProductsSuppliers.ToList(); //list object for ProductsSupplier
                List<Product> products = db.Products.ToList(); //list objects for products
                List<Supplier> suppliers = db.Suppliers.ToList();// list of objects for suppliers

                //select product id and product name from database
                var query = from pps in packprodsup
                            where pps.PackageId == ID
                            join ps in prodsup
                            on pps.ProductSupplierId equals ps.ProductSupplierId
                            join p in products
                            on ps.ProductId equals p.ProductId
                            join s in suppliers
                            on ps.SupplierId equals s.SupplierId
                            orderby s.SupplierId
                            select new
                            {
                                s.SupName,
                                p.ProdName
                            };
                int line = 0;
                foreach (var q in query)
                {
                    lvPackageProd.Items.Add(q.SupName.ToString());
                    lvPackageProd.Items[line].SubItems.Add(q.ProdName.ToString());
                    line++;
                }
            }
        }

        private void btnDeleteProd_Click(object sender, EventArgs e)
        {
            try//verify that a product is selected
            {
                var SelectedSupName = lvPackageProd.SelectedItems[0].SubItems[0].Text; //get the Supplier Name
                var SelectedProdName = lvPackageProd.SelectedItems[0].SubItems[1].Text; //get product name

                DialogResult answer = MessageBox.Show(
                        $"Do you want to delete {SelectedProdName} from {SelectedSupName}?",
                        "Confirm Delete", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (answer == DialogResult.Yes) // confirmed
                {

                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        Supplier SUPPLY = new Supplier();
                        Product PRODUCT = new Product();
                        //get supplier and product id
                        List<Supplier> sup = db.Suppliers.Where(x => x.SupName == SelectedSupName).ToList();
                        List<Product> prod = db.Products.Where(x => x.ProdName == SelectedProdName).ToList();

                        SUPPLY.SupplierId = sup[0].SupplierId;
                        PRODUCT.ProductId = prod[0].ProductId;

                        //find the productsupplierid that match supplier and productid
                        List<ProductSupplier> prodsupID = db.ProductsSuppliers.Where(p => p.SupplierId == SUPPLY.SupplierId && p.ProductId == PRODUCT.ProductId).ToList();
                        int ID = prodsupID[0].ProductSupplierId;

                        //delete product from the packagesproductsupplier based on the productsupplierid
                        List<PackagesProductsSupplier> prodsup = db.PackagesProductsSuppliers.Where(x => x.ProductSupplierId == ID).ToList();
                        db.PackagesProductsSuppliers.Remove(prodsup[0]);
                        db.SaveChanges();
                    }
                    MessageBox.Show($"The product {SelectedProdName} has been Deleted");
                    DisplayPackageProduct();
                }
            }
            catch (Exception ex) //error to select product
            {
                MessageBox.Show("Please select a Product to delete");
            }
        }

        private void btnDeletePackage_Click(object sender, EventArgs e)
        {
            //get package id
            int ID = currentPkg.PackageId;
            DialogResult answer = MessageBox.Show(
                        $"Do you want to delete PackageID {ID} and all related products?",
                        "Confirm Delete", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (answer == DialogResult.Yes) // confirmed
            {
                //delete from all existing areas
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    //get a list of products with the current packageid and delete it
                    List<PackagesProductsSupplier> packsuplist = db.PackagesProductsSuppliers.Where(x => x.PackageId == ID).ToList();
                    db.PackagesProductsSuppliers.RemoveRange(packsuplist);

                    //List of Bookingid with the packageid
                    List<Booking> bookID = db.Bookings.Where(x => x.PackageId == ID).ToList();
                    //remove all related BookingID in bookdetail
                    foreach (var b in bookID)
                    {
                        var BookDetailID = db.BookingDetails.Where(x => x.BookingId == b.BookingId).ToList();
                        db.BookingDetails.RemoveRange(BookDetailID);
                    }
                    db.Bookings.RemoveRange(bookID); // remove all bookingid
                    //remove package
                    var pack = db.Packages.Where(x => x.PackageId == ID).ToList();
                    db.Packages.RemoveRange(pack);
                    db.SaveChanges();
                }
                MessageBox.Show("Package has been Deleted");
                RefreshPkgComboBox();
                DisplayPackageProduct();
            }
        }
    }
}

