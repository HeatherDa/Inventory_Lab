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


        // tests if data is sent form frmInventroy then if data is present
        // parses data and propigates form
        private void frmManageInventory_Load(object sender, EventArgs e)
        {
            rdoBook.Select();
            txtTitle.Focus();
            string sentData = Convert.ToString(this.Tag);
            if (sentData != "")
            {
                String[] input = sentData.Split(':', ';');
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

        // sets form wide variables
        int indexOfSelectedRdo = 0;
        string strSelectedRdo = "";
        string strBtnName = "";

        // iterates over collection of rado buttopns to dertimine state and updates
        // variables based on state
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

        // called when state of rasio buttons changes
        // updates name of the creator label
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

        // closes form when any button of form is clicked
        // updates the strBtnName string variable  to the text on the sending button
        // so that the functions called during the form close event can use the variable
        private void frmButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            strBtnName = btn.Text;
            this.Close();
        }

        // function to create a string based off the data in the txtBoxes then 
        // save the string in to the Tag attribute of the form
        private void saveProduct(string title, string creator, string price)
        {
            string strFormatedPrice = formatPrice(price);
            this.Tag = "Type: " + strSelectedRdo +
                "; \t Title: " + title + "; \t " +
                    lblCreator.Text + ": " + creator +
                    "; \t Price: " + strFormatedPrice;
        }


        // function used to validate the data in the txtBoxes
        private bool ValidData(string title, string creator, string price)
        {
            if ((titleIsValid(title)) &&
                (creatorIsValid(creator)) &&
                (priceIsValid(price))
               )
            {
                return true;
            }
            return false;
        }

        // function called by the ValidData() function to validate the price txtBox
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

        // function called by the ValidData() function to validate the creator txtBox
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

        // function called by the ValidData() function to validate the title txtBox
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

        // function called by the priceIsValid() function to validate the price txtBox is a decimal
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

        // function called by the various validation methods to determine if the txtBoxes have text in them
        private bool isPresent(string text)
        {
            if (text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // function to take a sting of numbers and format them as currency
        private string formatPrice(string strPrice)
        {
            decimal decPrice = Convert.ToDecimal(strPrice);
            string strFormatedPrice = String.Format("{0:c}", decPrice);
            return strFormatedPrice;
        }

        // function that calls other functions when the form closing event is triggered
        private void frmManageInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (strBtnName)
            {
                case "Cancel":
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
