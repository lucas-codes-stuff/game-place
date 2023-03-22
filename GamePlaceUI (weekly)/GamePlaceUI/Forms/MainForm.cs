using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlaceUI
{
    public partial class MainForm : Form
    {
        Product[] products;

        Category[] categories;
        Platform[] platforms;
        Rating[] ratings;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProductInForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Object obj = cbxProducts.SelectedItem;

            Product p = obj as Product;

            DisplayProductInForm(p);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();

            DialogResult dr = ab.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product s = GetProductFromForm();

            int newId = ProductDB.Add(s);
            s.PROD_ID = newId;

            ClearProductInForm();

            cbxProducts.Items.Add(s as Object);

            txtLastId.Text = newId.ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOpen_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = GetProductFromForm();

            int rc = ProductDB.Update(p);
            if (rc != 0)
            {
                ClearProductInForm();
                cbxProducts.Items.Clear();
                MainForm_Load(sender, e);
                MessageBox.Show($"Product was updated.", "Success");
            }
            else
            {
                MessageBox.Show("Check form values for valid data.", "Error: Update");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long id = long.Parse(txtId.Text);

            int result = ProductDB.Delete(id);

            if (result == 0)
            {
                MessageBox.Show("Product is already marked as deleted.", "Error: Delete");
            }
            else
            {
                ClearProductInForm();
                MessageBox.Show($"{result} row(s) affected.", "Success");
            }

            MainForm_Load(sender, e);
        }

        private void undeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long id = long.Parse(txtId.Text);

            int result = ProductDB.Undelete(id);

            if (result == 0)
            {
                MessageBox.Show("Product has not been marked as active.", "Error: Undelete");
            }
            else
            {
                ClearProductInForm();
                MessageBox.Show($"{result} row(s) affected.", "Success");
            }

            MainForm_Load(sender, e);
        }

        private void purgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long id = long.Parse(txtId.Text);

            int result = ProductDB.Purge(id);

            if (result == 0)
            {
                MessageBox.Show("Product has not been marked as deleted.", "Error: Purge");
            }
            else
            {
                ClearProductInForm();
                MessageBox.Show($"{result} row(s) affected.", "Success");
            }

            MainForm_Load(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            products = ProductDB.Inquire();

            cbxProducts.Items.AddRange(products);

            categories = CategoryDB.Inquire();
            platforms = PlatformDB.Inquire();
            ratings = RatingDB.Inquire();

            cbxCategory.Items.AddRange(categories);
            cbxPlatform.Items.AddRange(platforms);
            cbxRating.Items.AddRange(ratings);
        }
        public Product GetProductFromForm()
        {
            int id = int.Parse(txtId.Text);

            string name = txtName.Text;
            string publisher = txtPublisher.Text;
            string developer = txtDeveloper.Text;
            string description = txtDescription.Text;

            float price = 0f;
            if (txtPrice.Text.Length > 0)
            {
                price = float.Parse(txtPrice.Text);
            }

            // state, major is special
            // combo boxes are 0 indexed
            // add 1 to the combobox index value for id in table
            int platform = (cbxPlatform.SelectedIndex + 1);
            int rating = (cbxRating.SelectedIndex + 1);
            int category = (cbxCategory.SelectedIndex + 1);


            string added = DateTime.Now.ToShortDateString();
            if (txtAdd.Text.Length > 0)
            {
                added = txtAdd.Text;
            }

            string changed = DateTime.Now.ToShortDateString();
            if (txtChg.Text.Length > 0)
            {
                changed = txtChg.Text;
            }

            string status = txtStatus.Text;

            string image = txtImage.Text;

            Product p = new Product(id,
                 name, publisher,
                 developer, price, platform, rating,
                 category, description,
                 added, changed, status, image);

            return p;
        }
        public void DisplayProductInForm(Product p)
        {
            if (p != null)
            {
                txtId.Text = p.PROD_ID.ToString();
                txtName.Text = p.PROD_NM;
                txtPublisher.Text = p.PROD_PUB;
                txtDeveloper.Text = p.PROD_DEV;
                txtPrice.Text = p.PROD_PRICE.ToString();
                txtDescription.Text = p.PROD_DESCR;
                txtAdd.Text = p.PROD_ADD_DTM;
                txtChg.Text = p.PROD_CHG_DTM;
                txtStatus.Text = p.PROD_STAT_CD;
                txtImage.Text = p.PROD_IMAGE;
                pbxImage.Image = Image.FromFile(@".\Images\" + p.PROD_IMAGE.ToString());

                // state, major is special
                // combo boxes are 0 indexed
                // subtract 1 from the id in table
                // for selected index of combo box
                cbxCategory.SelectedIndex = (p.PROD_CAT_CD - 1);
                cbxPlatform.SelectedIndex = (p.PROD_PLAT_CD - 1);
                cbxRating.SelectedIndex = (p.PROD_RATING_CD - 1);
            }
            else
            {
                MessageBox.Show("Select a product to display.", "No Product Selected");
            }
        }
        public void ClearProductInForm()
        {
            txtId.Text = "-1";
            txtName.Text = "";
            txtPublisher.Text = "";
            txtDeveloper.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
            txtAdd.Text = "";
            txtChg.Text = "";
            txtStatus.Text = "";
            txtImage.Text = "";

            txtLastId.Text = "";

            cbxCategory.SelectedIndex = -1;
            cbxPlatform.SelectedIndex = -1;
            cbxRating.SelectedIndex = -1;

            cbxCategory.SelectedText = "";
            cbxPlatform.SelectedText = "";
            cbxRating.SelectedText = "";

            cbxProducts.SelectedIndex = -1;
            cbxProducts.SelectedText = "";
        }
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();

            DialogResult dr = sf.ShowDialog();

            if (sf.ID > 0)
            {
                int id = sf.ID;

                Product p = ProductDB.ListProduct(id);

                DisplayProductInForm(p);
            }


        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product p = GetProductFromForm();

            int rc = ProductDB.Update(p);
            if (rc != 0)
            {
                ClearProductInForm();
                cbxProducts.Items.Clear();
                MainForm_Load(sender, e);
                MessageBox.Show($"Product was updated.", "Success");
            }
            else
            {
                MessageBox.Show("Check form values for valid data.", "Error: Update");
            }
        }
    }
}
