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

namespace PROJ_207_Project_2
{
    /*This module is the Adding and deleting suppliers
     * Adding new suppliers to the database
     * Editing current suppliers in the database
     * Verification to prevent duplicate suppliers with the ID
     * Contributor: Calvin C
     * 08-04-2023
     */
    public partial class AddModifySupplier : Form
    {
        public Supplier supplier; //set by main form
        public bool isAdd; //set by main form
        public AddModifySupplier()
        {
            InitializeComponent();
        }

        //form loads
        private void AddModifySupplier_Load(object sender, EventArgs e)
        {
            if (!isAdd)//if modify btn was clicked
            {
                this.Text = "Modify Supplier"; // change form title
                txtID.ReadOnly = true;
            }
            if (isAdd)// if add btn was clicked
            {
                this.Text = "Add a Supplier"; // change form title
            }
        }
        //Method to set the suppliers detail
        public void SetSupplierDetail(int ID, string name)
        {
            txtID.Text = ID.ToString();
            txtName.Text = name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //validation
            if (Validator.IsNonNegativeInt(txtID) &&
                Validator.IsPresent(txtID) &&
                Validator.IsPresent(txtName))
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    if (isAdd) //if Add btn was clicked
                    {
                        //verify if supplier ID already exist
                        var idchecker = db.Suppliers.Count(id => id.SupplierId == Convert.ToInt32(txtID.Text));
                        if (idchecker == 0)
                        {

                            supplier = new Supplier(); // create a Supplier object
                                                       //put data into the Supplier object
                            if (supplier != null) //if the Supplier object is not null
                            {
                                supplier.SupplierId = Convert.ToInt32(txtID.Text);
                                supplier.SupName = txtName.Text.ToUpper();
                            }
                            this.DialogResult = DialogResult.OK; //close form
                        }
                        else//if ID already exist
                        {
                            MessageBox.Show("ID already exist");
                            txtID.Focus();
                        }
                    }
                    if (supplier != null) //if the Supplier object is not null
                    {
                        supplier.SupplierId = Convert.ToInt32(txtID.Text);
                        supplier.SupName = txtName.Text.ToUpper(); ;
                    }
                    this.DialogResult = DialogResult.OK; //close form
                }
            }

        }
        //close window
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
