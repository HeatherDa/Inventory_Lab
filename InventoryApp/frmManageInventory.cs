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
    public partial class frmManageInventory : Form
    {
        public frmManageInventory()
        {
            InitializeComponent();
        }


        int indexOfSelectedRdo = 0;
        string strSelectedRdo = "";

        private void rdoProduct_Select(object sender, EventArgs e)
        {
            foreach (RadioButton rdo in grpProductType.Controls)
            {
                if (rdo.Checked)
                {
                    indexOfSelectedRdo = Convert.ToInt16(rdo.Tag);
                    strSelectedRdo = rdo.Text;
                }
            }
            updateProductForm(indexOfSelectedRdo);
        }

        private void updateProductForm(int selectedRdo)
        {
            switch (selectedRdo)
            {
                case 1:
                    lblCreator.Text = "Author";
                    break;
                case 2:
                    lblCreator.Text = "Editor";
                    break;
                case 3:
                    lblCreator.Text = "Artist";
                    break;
                default:
                    break;
            }
        }

        private void frmManageInventory_Load(object sender, EventArgs e)
        {
            rdoBook.Select();
            string sentData = Convert.ToString(this.Tag);
            if (sentData != "")
            {
                String[] input= sentData.Split(':',';');
                //MessageBox.Show(input[1]);
                switch (input[1].Trim())
                {
                    case "Book":
                        rdoBook.Select();
                        break;
                    case "Periodical":
                        rdoPeriodical.Select();
                        break;
                    case "Album":
                        rdoAlbum.Select(); 
                        break;
                    default:
                        break;
                }

                txtTitle.Text = input[3].Trim();//get title data
                txtCreator.Text = input[5].Trim();//get creator data
                txtPrice.Text = input[7].Substring(2).Trim(); //get price data and take off $ sign  
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult button = 
                MessageBox.Show(
                    "Are you sure you don't want to save", 
                    "Save", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
            if (button == DialogResult.Yes)
            {
            }
            //else
            //{
                
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // test case for data, will need to instantaite object in future and pass object
            if (ValidData(txtTitle.Text, txtCreator.Text, txtPrice.Text))
            {
                string strFormatedPrice = formatPrice(txtPrice.Text);
                this.Tag = "Type: " + strSelectedRdo +
                    "; \t Title: " + txtTitle.Text + "; \t " +
                     lblCreator.Text + ": " + txtCreator.Text +
                     "; \t Price: " + strFormatedPrice;
                this.Close();
            }
        }

        private bool ValidData(string title, string creator, string price)
        {
            if ( (isPresent(title) ) &&
                 (isPresent(creator) ) &&
                 (isPresent(price)  && isDecimal(price) ) 
               )
            {
                return true;
            }
            return false;
        }

        private bool isDecimal(string text)
        {
            decimal number = 0m;
            if (Decimal.TryParse(text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please enter a number in the price field");
                return false;
            }
        }


        private bool isPresent(string text)
        {
            if (text != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("All fields are required.  Please enter a value.");
                return false;
            }
        }

        private string formatPrice(string strPrice)
        {
            decimal decPrice = Convert.ToDecimal(strPrice);
            string strFormatedPrice = String.Format("{0:c}", decPrice);
            return strFormatedPrice;
        }
    }
}
