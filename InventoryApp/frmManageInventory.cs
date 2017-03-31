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
        string strBtnName = "";

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
            txtTitle.Focus();
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

        private void frmButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            strBtnName = btn.Text;
            this.Close();
        }


        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    strBtnName = btn.Text;
        //    this.Close();
        //}

        private void saveProduct(string title, string creator, string price)
        {
            //if (ValidData(title, creator, price))
            //{
                string strFormatedPrice = formatPrice(price);
                this.Tag = "Type: " + strSelectedRdo +
                    "; \t Title: " + title + "; \t " +
                     lblCreator.Text + ": " + creator +
                     "; \t Price: " + strFormatedPrice;
            //}
        }

        private bool ValidData(string title, string creator, string price)
        {
            //MessageBox.Show("title: " + Convert.ToString(isPresent(title)));
            //MessageBox.Show("creator: " + Convert.ToString(isPresent(creator)));
            //MessageBox.Show("price: " + Convert.ToString(isPresent(price)));
            if ((titleIsValid(title)) &&
                (creatorIsValid(creator)) &&
                (priceIsValid(price))
               )
            {
                //MessageBox.Show("All: true");
                return true;
            }
            //MessageBox.Show("All: false");
            return false;
        }

        private bool priceIsValid(string price)
        {
            if (isPresent(price))
            {
                return isDecimal(price);
            }
            else
            {
                MessageBox.Show("Price is a required field.", "Entry Error");
                txtPrice.Focus();
                return false;
            }
        }

        private bool creatorIsValid(string creator)
        {
            if (isPresent(creator))
            {
                return true;
            }
            else
            {
                MessageBox.Show(lblCreator.Text + " is a required field.", "Entry Error");
                txtCreator.Focus();
                return false;
            }
        }

        private bool titleIsValid(string title)
        {
            if (isPresent(title))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Title is a required filed", "Entry Error");
                txtTitle.Focus();
                return false;
            }
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
                //MessageBox.Show("All fields are required.  Please enter a value.");
                return false;
            }
        }

        private string formatPrice(string strPrice)
        {
            decimal decPrice = Convert.ToDecimal(strPrice);
            string strFormatedPrice = String.Format("{0:c}", decPrice);
            return strFormatedPrice;
        }

        private void frmManageInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (strBtnName)
            {
                case "Cancel":
                    //MessageBox.Show(strBtnName);
                    if (isPresent(txtTitle.Text) || isPresent(txtCreator.Text) || isPresent(txtPrice.Text))
                    {
                        DialogResult button =
                        MessageBox.Show
                        (
                            "Exit without saving?",
                            "Save",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2
                        );
                        e.Cancel = (button != DialogResult.Yes);
                    }
                    break;
                case "Save":
                    if (ValidData(txtTitle.Text, txtCreator.Text, txtPrice.Text))
                    {
                        saveProduct(txtTitle.Text, txtCreator.Text, txtPrice.Text);
                    } else
                    {
                        e.Cancel = true;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
