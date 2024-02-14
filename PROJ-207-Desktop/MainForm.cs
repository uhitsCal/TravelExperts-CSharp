namespace PROJ_207_Project_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void packagesButton_Click(object sender, EventArgs e)
        {
            using (var packagesForm = new frmTravelPackage()) {
                packagesForm.ShowDialog(this);
            }
        }

        private void suppliersButton_Click(object sender, EventArgs e)
        {
            using (var suppliersForm = new SuppliersForm()) {
                suppliersForm.ShowDialog(this);
            }
        }

        private void productsButton_Click(object sender, EventArgs e)
        {
            using (var productsForm = new ProductsForm()) {
                productsForm.ShowDialog(this);
            }
        }
    }
}