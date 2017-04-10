using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_control_practice
{
    public partial class frmMain : Form
    {
        private Inventory inventory = new Inventory();

        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            inventory.add(new Product(int.Parse(txtCode.Text), txtName.Text, int.Parse(txtQuantity.Text), double.Parse(txtPrice.Text)));

            txtCode.Clear();
            txtName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
        }

        private void cmdReport_Click(object sender, EventArgs e)
        {
            txtReports.Text = inventory.report();
        }

        private void cmdRead_Click(object sender, EventArgs e)
        {
            Product product = inventory.search(txtSearch.Text);

            if (product != null)
                txtReports.Text = product.ToString();
            else
                MessageBox.Show("No se encontro el producto");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            inventory.delete(txtSearch.Text);
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            inventory.insert(new Product(int.Parse(txtCode.Text), txtName.Text, int.Parse(txtQuantity.Text), double.Parse(txtPrice.Text)), int.Parse(txtPosition.Text));
        }

        private void cmdAddAtBegin_Click(object sender, EventArgs e)
        {
            inventory.addAtBegin(new Product(int.Parse(txtCode.Text), txtName.Text, int.Parse(txtQuantity.Text), double.Parse(txtPrice.Text)));
        }
    }
}
