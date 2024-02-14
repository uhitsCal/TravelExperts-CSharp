using PROJ_207_Project_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJ_207_Project_2
{
    /*Main form for Managing Suppliers
     * 
     * Contributor: Calvin C
     * 
     * 08-04-2023
     */

    public partial class SuppliersForm : Form
    {
        Supplier? currentSupplier = null;
        ProductSupplier? currentProduct = null;

        public SuppliersForm()
        {
            InitializeComponent();
        }

        //when the suppliers form load
        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(430, 540);//set window size
            DisplaySuppliers();//update list
            HideProduct();//hide products
        }

        //method to update and display the Suppliers
        private void DisplaySuppliers()
        {
            lvSupplier.Items.Clear(); //clear listview
            using (TravelExpertsContext db = new TravelExpertsContext())//establish connection to database
            {
                //Create a List of objects of the database
                List<Supplier> Suppliers = db.Suppliers.ToList();
                //select supplier id and supplier name from database
                var supplyquery = from supply in Suppliers
                                  orderby supply.SupplierId
                                  select new
                                  {
                                      supply.SupplierId,
                                      supply.SupName
                                  };
                //add suppliers to the listview
                int sline = 0;
                foreach (var s in supplyquery)
                {
                    lvSupplier.Items.Add(s.SupplierId.ToString());
                    lvSupplier.Items[sline].SubItems.Add(s.SupName);
                    sline++;
                }
            }
        }

        //method to update and display Products
        private void DisplayProducts()
        {
            lvProducts.Items.Clear();//clear listview
            using (TravelExpertsContext db = new TravelExpertsContext())//establish connection to database
            {
                int ID = Convert.ToInt32(lvSupplier.SelectedItems[0].SubItems[0].Text);//set ID from the selected ID from suppliers
                //Create a List of objects of the database
                List<ProductSupplier> prodsup = db.ProductsSuppliers.ToList(); //list object for ProductsSupplier
                List<Product> products = db.Products.ToList(); //list objects for products

                //select product id and product name from database
                var productquery = from ps in prodsup
                                   where ps.SupplierId == ID //ID = the selected supplierID
                                   join prod in products
                                   on ps.ProductId equals prod.ProductId
                                   orderby ps.ProductId
                                   select new
                                   {
                                       ps.ProductSupplierId,
                                       ps.ProductId,
                                       ps.SupplierId,
                                       prod.ProdName
                                   };
                //add products to the listview
                int pline = 0;
                foreach (var p in productquery)
                {
                    lvProducts.Items.Add(p.ProductId.ToString());
                    lvProducts.Items[pline].SubItems.Add(p.ProdName.ToString());
                    pline++;
                }
            }
        }

        //method for adjusting the window size to display product when supplier is selected
        private void lvSupplier_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvSupplier.SelectedItems.Count == 1)
            {
                ClientSize = new Size(800, 540);//set window size
                ShowProduct();
                DisplayProducts();
            }
            else
            {
                ClientSize = new Size(430, 540);//set window size
                HideProduct();
            }
        }
        //method to hide product
        private void HideProduct()
        {
            lvProducts.Visible = false;
            lblProd.Visible = false;
            btnAddProd.Visible = false;
            btnDelProd.Visible = false;
        }
        //method to show product
        private void ShowProduct()
        {
            lvProducts.Visible = true;
            lblProd.Visible = true;
            btnAddProd.Visible = true;
            btnDelProd.Visible = true;
        }

        //Add button for supplier
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            AddModifySupplier secondForm = new AddModifySupplier();//Create object for the SupplierProduct Form
            secondForm.isAdd = true; //set add to true
            secondForm.supplier = null; //set to null
            DialogResult result = secondForm.ShowDialog(); //second form window opens

            if (result == DialogResult.OK) //if user press Ok on second form
            {
                currentSupplier = secondForm.supplier; //currentSupplier equals the product from the second form
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())//connect to database
                    {
                        if (currentSupplier != null)//if currentSupplier is not null (Data from second form collected)
                        {
                            db.Suppliers.Add(currentSupplier);//Add to the collections of objects
                            db.SaveChanges(); //save change to database
                            DisplaySuppliers(); //display updated database
                        }
                    }
                }
                catch (Exception ex) //if something goes wrong with adding a supplier
                {
                    MessageBox.Show("Error while adding a new Supplier: " + ex.Message, ex.GetType().ToString());
                }
            }
        }

        //Modify button for suppliers
        private void btnModSupplier_Click(object sender, EventArgs e)
        {
            AddModifySupplier secondForm = new AddModifySupplier();//Create object for the Supplier Form
            secondForm.isAdd = false; //set add to false

            try //validate if a supplier is selected
            {
                int ID = Convert.ToInt32(lvSupplier.SelectedItems[0].SubItems[0].Text); //set ID to the selected Supplier ID
                string name = lvSupplier.SelectedItems[0].SubItems[1].Text; //Set name to the name of Supplier 
                secondForm.SetSupplierDetail(ID, name);//sets the details on secondform as selected Supplier

                using (TravelExpertsContext db = new TravelExpertsContext()) //connect to database
                {
                    currentSupplier = db.Suppliers.Find(ID); //set currentSupplier to the SupplierID
                    secondForm.supplier = currentSupplier; //set supplier in second form as the current selected supplier
                }

                DialogResult result = secondForm.ShowDialog(); //show the second form

                if (result == DialogResult.OK) //if user press Ok on second form
                {
                    try
                    {
                        using (TravelExpertsContext db = new TravelExpertsContext())//connect to database
                        {
                            if (secondForm.supplier != null) //data is collected by second form
                            {
                                currentSupplier = db.Suppliers.Find(ID);//find the selected Supplier by ID

                                if (currentSupplier != null) //if currentsupplier is not null
                                {
                                    //copy data over from second form to the currentsupplier object
                                    currentSupplier.SupplierId = secondForm.supplier.SupplierId;
                                    currentSupplier.SupName = secondForm.supplier.SupName;

                                    db.SaveChanges(); //save changes to database
                                    DisplaySuppliers();//update viewlist
                                }
                            }
                        }
                    }
                    catch (Exception ex)//error while modifying a Supplier
                    {
                        MessageBox.Show("Error while Modifying a Supplier: " + ex.Message,
                            ex.GetType().ToString());
                    }

                }
            }
            catch (Exception ex)//if supplier was not selected
            {
                MessageBox.Show("Please select a Supplier to modify");
            }
        }
        //Delete button for suppliers
        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            try //validate if an item is selected
            {
                int ID = Convert.ToInt32(lvSupplier.SelectedItems[0].SubItems[0].Text);//set ID to the selected Supplier ID

                using (TravelExpertsContext db = new TravelExpertsContext())//connect to database
                {
                    currentSupplier = db.Suppliers.Find(ID); //set currentSupplier to the supplier by selected Supplier ID
                }
                if (currentSupplier != null)//if currentSupplier is not null
                {
                    // get confirmation
                    DialogResult answer = MessageBox.Show(
                        $"Do you want to delete {currentSupplier.SupName} and all the products related?",
                        "Confirm Delete", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes) // confirmed
                    {

                        try
                        {
                            using (TravelExpertsContext db = new TravelExpertsContext()) //connect to db
                            {
                                //get a list object of productsupplierid related to the supplier
                                List<ProductSupplier> prodsup = db.ProductsSuppliers.Where(x => x.SupplierId == currentSupplier.SupplierId).ToList();

                                foreach (var p in prodsup)
                                {
                                    //find all existing productsupplierID and delete them
                                    var book = db.BookingDetails.Where(b => b.ProductSupplierId == p.ProductSupplierId);
                                    db.BookingDetails.RemoveRange(book);//delete in bookingdetails
                                    var package = db.PackagesProductsSuppliers.Where(x => x.ProductSupplierId == p.ProductSupplierId);
                                    db.PackagesProductsSuppliers.RemoveRange(package);//delete in packageproductsupplier
                                }
                                db.ProductsSuppliers.RemoveRange(prodsup); //delete in productsupplierid

                                //find all existing products within selected supplier and delete them
                                var all = db.ProductsSuppliers.Where(x => x.SupplierId == currentSupplier.SupplierId);
                                db.ProductsSuppliers.RemoveRange(all);
                                db.SaveChanges();

                                if (currentSupplier != null) // if current supplier is not null
                                {
                                    db.Suppliers.Remove(currentSupplier); // delete supplier from the collection of objects
                                    db.SaveChanges(); // save the change to the database
                                    DisplaySuppliers(); //updates listview with most current db data
                                }
                            }
                        }
                        catch (Exception ex) //error for removing 
                        {
                            MessageBox.Show("Error while removing a supplier: " + ex.Message,
                                ex.GetType().ToString());
                        }
                    }

                }
            }
            catch (Exception ex) //message to select a Supplier
            {
                MessageBox.Show("Please select a Supplier to Remove");
            }
        }

        //Add button for products
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            AddDelProduct secondForm = new AddDelProduct(); // Create object for the Product Form
            secondForm.isAdd = true;
            secondForm.productsupply = null;

            string supID = lvSupplier.SelectedItems[0].SubItems[0].Text; //set ID to the Supplier ID in string
            string name = lvSupplier.SelectedItems[0].SubItems[1].Text; //Set name to the name of Supplier 
            secondForm.SetCurrentSupplier(name, supID); //sets the details on secondform as selected Supplier

            DialogResult result = secondForm.ShowDialog(); // displays the form modal
            if (result == DialogResult.OK) // user clicked Accept
            {
                currentProduct = secondForm.productsupply;//contains productid and supplierid

                //verifying if product is already in the product viewlist
                int tempid = (int)currentProduct.ProductId;
                ListViewItem prodID = lvProducts.FindItemWithText(tempid.ToString());

                if (prodID == null) //null if there was no match - does not exist in the list
                {
                    try
                    {
                        using (TravelExpertsContext db = new TravelExpertsContext())//connect to database
                        {
                            if (currentProduct != null)
                            {
                                db.ProductsSuppliers.Add(currentProduct);// adds to the collection of objects
                                db.SaveChanges();// saves changes to the database
                                DisplayProducts();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while adding Product: " + ex.Message,
                            ex.GetType().ToString());
                    }
                }
                else //if product exist in the viewlist 
                {
                    MessageBox.Show("Product already Exist");
                }

            }
        }

        //Delete button for product
        private void btnDelProd_Click(object sender, EventArgs e)
        {
            try//verify that a product is selected
            {
                int ID = Convert.ToInt32(lvProducts.SelectedItems[0].SubItems[0].Text); //set ID to the product ID 
                int supID = Convert.ToInt32(lvSupplier.SelectedItems[0].SubItems[0].Text); //set supID to the Supplier ID
                var delprod = new ProductSupplier { ProductId = ID, SupplierId = supID };//set variable to new object with product id and supplier id
                using (TravelExpertsContext db = new TravelExpertsContext()) // connect to database
                {
                    try
                    {
                        currentProduct = db.ProductsSuppliers.Where(x => x.ProductId == ID).Where(c => c.SupplierId == supID).Single(); //set currentSupplier to the selected Supplier ID
                    }
                    catch (Exception ex)//if there was a duplicate products in one supplier
                    {
                        MessageBox.Show("error while trying to delete product: occurs when one supplier has duplicate products.");
                        return;
                    }
                    var currentprodname = db.Products.Find(ID);
                    if (currentProduct != null)//if currentSupplier is not null - verify that a product was selected
                    {
                        // get confirmation
                        DialogResult answer = MessageBox.Show(
                            $"Do you want to delete {currentprodname.ProdName}?",
                            "Confirm Delete", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (answer == DialogResult.Yes)//confirmed
                        {
                            try
                            {
                                if (currentProduct != null) //if current product is not null - a product selected
                                {
                                    db.ProductsSuppliers.Remove(currentProduct); // delete from the collection of objects
                                    db.SaveChanges(); //save the change to the database
                                    DisplayProducts(); //updates listview with most current db data
                                }

                            }
                            catch (Exception ex) //error for removing 
                            {
                                MessageBox.Show("Error while removing : " + ex.Message,
                                    ex.GetType().ToString());
                            }
                        }

                    }

                }
            }
            catch (Exception ex) //error to select product
            {
                MessageBox.Show("Please select a Product to delete");
            }
        }
    }
}
