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
                        DialogResult button =
                            MessageBox.Show(
                                "Are you sure you want to delete this item?", "Delete Item!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);
                        if(button == DialogResult.Yes) lstInventory.Items.RemoveAt(lstInventory.SelectedIndex); //remove selected item if user says yes
                        break;
                    case "update":
                        Form updateProd = new frmManageInventory();
                        int selectedIndex = lstInventory.SelectedIndex;
                        updateProd.Text = "Update Product";
                        updateProd.Tag = lstInventory.Items[selectedIndex].ToString(); //pass data about selected item to new form
                        updateProd.ShowDialog(); 
                        lstInventory.Items.RemoveAt(lstInventory.SelectedIndex); //remove previous entry
                        lstInventory.Items.Insert(selectedIndex, updateProd.Tag); //insert updated entry at same location as previous entry
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message+"\n"+ ex.GetType().ToString(), "Exception!"); }
        }
    }
}
