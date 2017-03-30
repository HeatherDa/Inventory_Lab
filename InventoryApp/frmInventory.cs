using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class frmBookStoreInventory : Form
    {
        public frmBookStoreInventory()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                switch (Convert.ToString(btn.Tag))
                {
                    case "add":
                        Form addProd = new frmManageInventory();
                        addProd.Text = "Add Product";
                        addProd.ShowDialog();
                        lstInventory.Items.Add(addProd.Tag);
                        break;
                    case "delete":
                        lstInventory.Items.RemoveAt(lstInventory.SelectedIndex);
                        break;
                    case "update":
                        Form updateProd = new frmManageInventory();
                        updateProd.Text = "Update Product";
                        updateProd.Tag = lstInventory.Items[lstInventory.SelectedIndex].ToString();
                        //MessageBox.Show(Convert.ToString(updateProd.Tag));
                        updateProd.ShowDialog();
                        lstInventory.Items.RemoveAt(lstInventory.SelectedIndex);
                        lstInventory.Items.Add(updateProd.Tag);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Somthing Happened");
            }
        }
    }
}
