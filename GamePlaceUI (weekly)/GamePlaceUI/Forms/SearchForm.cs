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
    public partial class SearchForm : Form
    {
        public int ID { get; set; }
        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtProduct.Text;
            if(name.Length >0)
            {
                Product[] list = ProductDB.ListProduct(name);

                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = list;
            }


        }

        private void dgvProduct_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvProduct.CurrentCell.RowIndex;

                ID = int.Parse(dgvProduct.Rows[index].Cells[0].Value.ToString());

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nothing was selected","Error");
            }
     
          
        }
    }
}
