using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        bool newFile = true;
        bool saved = true;
        string strSaved = "";
        string fileName = "new";
        string docPath = "";
        string fullPath = "";
        string frmName = "Book Store Inventory - ";


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
                        updateSaved(false);
                        break;
                    case "delete":
                        DialogResult button =
                            MessageBox.Show(
                                "Are you sure you want to delete this item?", "Delete Item!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);
                        if(button == DialogResult.Yes) lstInventory.Items.RemoveAt(lstInventory.SelectedIndex); //remove selected item if user says yes
                        updateSaved(false);
                        break;
                    case "update":
                        Form updateProd = new frmManageInventory();
                        int selectedIndex = lstInventory.SelectedIndex;
                        updateProd.Text = "Update Product";
                        updateProd.Tag = lstInventory.Items[selectedIndex].ToString(); //pass data about selected item to new form
                        updateProd.ShowDialog(); 
                        lstInventory.Items.RemoveAt(lstInventory.SelectedIndex); //remove previous entry
                        lstInventory.Items.Insert(selectedIndex, updateProd.Tag); //insert updated entry at same location as previous entry
                        updateSaved(false);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            //    MessageBox.Show(ex.Message+"\n"+ ex.GetType().ToString(), "Exception!");
            }
        }

        private void updateSaved(bool v)
        {
            if (v)
            {
                saved = true;
                strSaved = "";
            }
            else
            {
                saved = false;
                strSaved = "*";
            }
            updateTitleBar();
        }

        private void menuItmSave_Click(object sender, EventArgs e)
        {
            if (!newFile)
            {
                saveInventory();
            }
            else
            {
                saveInventoryAs();
                newFile = false;
            }

        }
        private void menuItmSaveAs_Click(object sender, EventArgs e)
        {
            saveInventoryAs();
        }

        private void menuItemLoad_Click(object sender, EventArgs e)
        {
            loadInventory();
        }

        // Functions for saving/loading the inventory list
        private void saveInventory()
        {
            if (fileName != "new")
            {
                string[] arrInventoyLines = new string[lstInventory.Items.Count];
                arrInventoyLines = getInventoryLines(lstInventory.Items);

                using (StreamWriter outputFile = new StreamWriter(docPath + @"\" + fileName))
                {
                    foreach (string line in arrInventoyLines)
                        outputFile.WriteLine(line);
                }
                updateSaved(true);
            }
        }
        private void saveInventoryAs()
        {
            string[] arrInventoyLines = new string[lstInventory.Items.Count];
            arrInventoyLines = getInventoryLines(lstInventory.Items);

            SaveFileDialog saveAS = new SaveFileDialog();
            saveAS.Filter = "Inventory File|*.txt";
            saveAS.Title = "Save an Inventory File";
            saveAS.ShowDialog();
            if (saveAS.FileName != "")
            {
                fileName = saveAS.FileName;
                if (!fileName.Contains(".txt"))
                {
                    fileName += ".txt";
                }
                docPath = System.IO.Path.GetDirectoryName(fileName) + @"\";
                fileName = fileName.Substring(docPath.Length);
                fullPath = docPath + fileName;
                //MessageBox.Show(fileName + "\n" + docPath + "\n" + fullPath);
            //}
            using (StreamWriter outputFile = new StreamWriter(docPath + @"\" + fileName))
                {
                    foreach (string line in arrInventoyLines)
                        outputFile.WriteLine(line);
                }
            updateSaved(true);   
            }
        }

        private async void loadInventory()
        {
            OpenFileDialog loadInv = new OpenFileDialog();
            loadInv.ShowDialog();
            if (loadInv.FileName != "")
            {
                fileName = loadInv.FileName;
                docPath = System.IO.Path.GetDirectoryName(fileName) + @"\";
                fileName = fileName.Substring(docPath.Length);
                fullPath = docPath + fileName;
            }

            string resultText = "";

            try
            {
                using (StreamReader inventory = new StreamReader(fullPath))
                {
                    String line = await inventory.ReadToEndAsync();
                    resultText += line;
                    resultText += "\n";
                }
            }
            catch (Exception)
            {
                resultText = "Could not read the file";
            }

            lstInventory.Items.Clear();

            string[] arrLoadedItems = resultText.Split('※');
            string[] arrTrimedItems = new string[arrLoadedItems.Length - 1];

            for (int i = 0; i < arrTrimedItems.Length; i++)
            {
                arrTrimedItems[i] = arrLoadedItems[i];
            }
            foreach (var item in arrTrimedItems)
            {
                if (item != "")
                lstInventory.Items.Add(item);
            }
            newFile = false;
            updateTitleBar();
        }


        private string[] getInventoryLines(ListBox.ObjectCollection items)
        {
            string[] lines = new string[items.Count];
            int i = 0;
            foreach (var item in items)
            {
                lines[i] = item.ToString();
                lines[i] += "※";
                i++;
            }
            return lines;
        }

        private void frmBookStoreInventory_Load(object sender, EventArgs e)
        {
            updateTitleBar();
        }

        private void updateTitleBar()
        {
            this.Text = frmName + fileName + strSaved;
        }

        private void frmBookStoreInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult result =
                MessageBox.Show
                (
                    "Exit without saving?", "Exit?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2
                );
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
