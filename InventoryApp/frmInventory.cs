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

        string fileName = "";
        string docPath = "";
        string fullPath = "";

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
            catch (Exception)
            {
            //    MessageBox.Show(ex.Message+"\n"+ ex.GetType().ToString(), "Exception!");
            }
        }

        private void menuItmSave_Click(object sender, EventArgs e)
        {
            if (fileName != "")
            {
                saveInventory();
            }
            else
            {
                saveInventoryAs();
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
            string[] arrInventoyLines = new string[lstInventory.Items.Count];
            arrInventoyLines = getInventoryLines(lstInventory.Items);

            using (StreamWriter outputFile = new StreamWriter(docPath + @"\" + fileName))
            {
                foreach (string line in arrInventoyLines)
                    outputFile.WriteLine(line);
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
            }
            using (StreamWriter outputFile = new StreamWriter(docPath + @"\" + fileName))
                {
                    foreach (string line in arrInventoyLines)
                        outputFile.WriteLine(line);
                }
            }

        private async void loadInventory()
        {
            OpenFileDialog loadInv = new OpenFileDialog();
            loadInv.ShowDialog();

            fileName = loadInv.FileName;
            docPath = System.IO.Path.GetDirectoryName(fileName) + @"\";
            fileName = fileName.Substring(docPath.Length);
            fullPath = docPath + fileName;

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




            MessageBox.Show(resultText);
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
   }
}
