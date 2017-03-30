namespace InventoryApp
{
    partial class frmManageInventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpProductType = new System.Windows.Forms.GroupBox();
            this.rdoAlbum = new System.Windows.Forms.RadioButton();
            this.rdoBook = new System.Windows.Forms.RadioButton();
            this.rdoPeriodical = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtCreator = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpProductType.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProductType
            // 
            this.grpProductType.Controls.Add(this.rdoAlbum);
            this.grpProductType.Controls.Add(this.rdoBook);
            this.grpProductType.Controls.Add(this.rdoPeriodical);
            this.grpProductType.Location = new System.Drawing.Point(12, 12);
            this.grpProductType.Name = "grpProductType";
            this.grpProductType.Size = new System.Drawing.Size(323, 52);
            this.grpProductType.TabIndex = 0;
            this.grpProductType.TabStop = false;
            this.grpProductType.Text = "Product Type";
            // 
            // rdoAlbum
            // 
            this.rdoAlbum.AutoSize = true;
            this.rdoAlbum.Location = new System.Drawing.Point(247, 19);
            this.rdoAlbum.Name = "rdoAlbum";
            this.rdoAlbum.Size = new System.Drawing.Size(54, 17);
            this.rdoAlbum.TabIndex = 3;
            this.rdoAlbum.TabStop = true;
            this.rdoAlbum.Tag = "3";
            this.rdoAlbum.Text = "Album";
            this.rdoAlbum.UseVisualStyleBackColor = true;
            this.rdoAlbum.CheckedChanged += new System.EventHandler(this.rdoProduct_Select);
            // 
            // rdoBook
            // 
            this.rdoBook.AutoSize = true;
            this.rdoBook.Location = new System.Drawing.Point(16, 19);
            this.rdoBook.Name = "rdoBook";
            this.rdoBook.Size = new System.Drawing.Size(50, 17);
            this.rdoBook.TabIndex = 1;
            this.rdoBook.TabStop = true;
            this.rdoBook.Tag = "1";
            this.rdoBook.Text = "Book";
            this.rdoBook.UseVisualStyleBackColor = true;
            this.rdoBook.CheckedChanged += new System.EventHandler(this.rdoProduct_Select);
            // 
            // rdoPeriodical
            // 
            this.rdoPeriodical.AutoSize = true;
            this.rdoPeriodical.Location = new System.Drawing.Point(113, 19);
            this.rdoPeriodical.Name = "rdoPeriodical";
            this.rdoPeriodical.Size = new System.Drawing.Size(71, 17);
            this.rdoPeriodical.TabIndex = 2;
            this.rdoPeriodical.TabStop = true;
            this.rdoPeriodical.Tag = "2";
            this.rdoPeriodical.Text = "Periodical";
            this.rdoPeriodical.UseVisualStyleBackColor = true;
            this.rdoPeriodical.CheckedChanged += new System.EventHandler(this.rdoProduct_Select);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(25, 77);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Location = new System.Drawing.Point(25, 102);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(35, 13);
            this.lblCreator.TabIndex = 2;
            this.lblCreator.Text = "label2";
            this.lblCreator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(25, 124);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(66, 73);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(247, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // txtCreator
            // 
            this.txtCreator.Location = new System.Drawing.Point(66, 99);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(247, 20);
            this.txtCreator.TabIndex = 6;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(66, 125);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(247, 20);
            this.txtPrice.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(164, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmManageInventory
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(348, 197);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpProductType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageInventory";
            this.Text = "Manage Inventory";
            this.Load += new System.EventHandler(this.frmManageInventory_Load);
            this.grpProductType.ResumeLayout(false);
            this.grpProductType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProductType;
        private System.Windows.Forms.RadioButton rdoBook;
        private System.Windows.Forms.RadioButton rdoPeriodical;
        private System.Windows.Forms.RadioButton rdoAlbum;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtCreator;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}