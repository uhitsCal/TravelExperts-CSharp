//Author: Gabriel V Gomes
//When: July 2023

using PROJ_207_Project_2.Models;
using System;
using System.Windows.Forms;

namespace PROJ_207_Project_2
{
    public partial class frmAddModifyPackage : Form
    {
        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

        public bool addPackage; // true if Add, and false if Modify
        public Package currentPkg; // frmMain sets current package
        public Package package = new Package();


        private void frmAddModifyPackage_Load(object sender, EventArgs e)
        {
            if (addPackage)
            {
                this.Text = "Add Package";
            }
            else
            {
                this.Text = "Modify Package";
                DisplayCurrentPkg();
            }
        }


        private void DisplayCurrentPkg()
        {
            txtID.Text = currentPkg.PackageId.ToString();
            txtName.Text = currentPkg.PkgName.ToString();
            txtBasePrice.Text = currentPkg.PkgBasePrice.ToString();

            if (currentPkg.PkgStartDate == null)
                dtpStart.Text = "";
            else
            {
                DateTime startDate = (DateTime)currentPkg.PkgStartDate;
                dtpStart.Text = startDate.ToShortDateString();
            }

            if (currentPkg.PkgEndDate == null)
                dtpEnd.Text = "";
            else
            {
                DateTime endDate = (DateTime)currentPkg.PkgEndDate;
                dtpEnd.Text = endDate.ToShortDateString();
            }

            if (currentPkg.PkgDesc == null)
                txtDescription.Text = "";
            else
            {
                string desc = (string)currentPkg.PkgDesc;
                txtDescription.Text = desc;
            }

            if (currentPkg.PkgAgencyCommission == null)
                txtCommission.Text = "";
            else
            {
                decimal commission = (decimal)currentPkg.PkgAgencyCommission;
                txtCommission.Text = commission.ToString();
            }
        }

        private void PkgSaveButton_Click(object sender, EventArgs e)
        {

            if (IsValidDates() && IsValidPkgData() && IsValidPrices())
            {
                Console.WriteLine("Dates are valid");
                if (addPackage)
                {
                    this.PutPackageData();
                    try
                    {
                        package.PackageId = PackageDB.AddPackage(package);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {

                    package.PackageId = currentPkg.PackageId;
                    this.PutPackageData();

                    try
                    {
                        if (!PackageDB.UpdatePackage(currentPkg, package))
                        {
                            MessageBox.Show("Another user has updated or deleted current package", "Concurrency Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            currentPkg = package;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while updating: " + ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        private void PutPackageData()
        {
            package.PkgName = txtName.Text;
            package.PkgDesc = txtDescription.Text;
            package.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);

            //if (dtpStart.Text == "")
            //    package.PkgStartDate = null;
            //else
                package.PkgStartDate = Convert.ToDateTime(dtpStart.Text);

            //if (dtpEnd.Text == "")
            //    package.PkgEndDate = null;
            //else
                package.PkgEndDate = Convert.ToDateTime(dtpEnd.Text);

            if (txtCommission.Text == "")
                package.PkgAgencyCommission = null;
            else
                package.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text);

        }


        private bool IsValidDates()
        {
            bool valid = true; // empty is valid
            DateTime startDate;
            DateTime endDate;

            if (dtpStart.Text != "" && dtpEnd.Text != "") // if dates not empty
            {
                // for Start Date input
                if (DateTime.TryParse(dtpStart.Text, out startDate)) // if valid date
                {
                    endDate = Convert.ToDateTime(dtpEnd.Text);
                    // if start date is greater than end date
                    if (endDate <= startDate)
                    {
                        valid = false;
                        MessageBox.Show("Start Date must be earlier than End Date", "Data Error");
                        dtpStart.Focus();
                    }
                }
                else // if invalid date
                {
                    valid = false;
                    MessageBox.Show("Please enter Start Date in format MM/DD/YYYY", "Data Error");
                    dtpStart.Focus();
                }
                // for End Date input
                if (DateTime.TryParse(dtpEnd.Text, out endDate)) // if valid date
                {
                    startDate = Convert.ToDateTime(dtpStart.Text);
                    // if start date is greater than end date
                    if (startDate >= endDate)
                    {
                        valid = false;
                    }
                }
                else // if invalid date TRALALLAALA
                {
                    valid = false;
                    MessageBox.Show("Please enter End Date in format MM/DD/YYYY", "Data Error");
                    dtpStart.Focus();
                }
            }
            return valid;
        }
        private bool IsValidPrices()
        {
            bool valid = true;
            decimal basePrice;
            decimal commPrice;
            if (txtCommission != null) // if commission is not null
            {
                commPrice = Convert.ToDecimal(txtCommission.Text);
                basePrice = Convert.ToDecimal(txtBasePrice.Text);
                if (commPrice > basePrice)
                {
                    valid = false;
                    MessageBox.Show("Agency Commission must be less than the Base Price", "Data Error");
                    txtCommission.Focus();
                }
            }
            return valid;
        }

        private bool IsValidPkgData()
        {
            return
                Validator.IsPresent(txtName) &&
                Validator.IsPresent(txtDescription) &&
                Validator.IsPresent(txtBasePrice) &&
                Validator.IsDecimal(txtBasePrice) &&
                (txtCommission.Text == "" || Validator.IsDecimal(txtCommission));
        }

        private void PkgCloseButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void PkgIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
