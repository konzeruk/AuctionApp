namespace AuctionApp.Forms
{
    partial class BargainingForm
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
            dataGridViewProduct = new DataGridView();
            bBack = new Button();
            ColumnName = new DataGridViewTextBoxColumn();
            ColumnPhoto = new DataGridViewImageColumn();
            ColumnPrice = new DataGridViewTextBoxColumn();
            ColumnDataEnd = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduct).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProduct
            // 
            dataGridViewProduct.AllowUserToAddRows = false;
            dataGridViewProduct.AllowUserToDeleteRows = false;
            dataGridViewProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduct.Columns.AddRange(new DataGridViewColumn[] { ColumnName, ColumnPhoto, ColumnPrice, ColumnDataEnd });
            dataGridViewProduct.Location = new Point(12, 12);
            dataGridViewProduct.Name = "dataGridViewProduct";
            dataGridViewProduct.RowTemplate.Height = 25;
            dataGridViewProduct.Size = new Size(684, 404);
            dataGridViewProduct.TabIndex = 0;
            // 
            // bBack
            // 
            bBack.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            bBack.Location = new Point(12, 422);
            bBack.Name = "bBack";
            bBack.Size = new Size(111, 44);
            bBack.TabIndex = 1;
            bBack.Text = "Назад";
            bBack.UseVisualStyleBackColor = true;
            // 
            // ColumnName
            // 
            ColumnName.HeaderText = "Название";
            ColumnName.Name = "ColumnName";
            // 
            // ColumnPhoto
            // 
            ColumnPhoto.HeaderText = "Фото";
            ColumnPhoto.Name = "ColumnPhoto";
            // 
            // ColumnPrice
            // 
            ColumnPrice.HeaderText = "Цена";
            ColumnPrice.Name = "ColumnPrice";
            // 
            // ColumnDataEnd
            // 
            ColumnDataEnd.HeaderText = "Дата окончания";
            ColumnDataEnd.Name = "ColumnDataEnd";
            // 
            // BargainingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 480);
            Controls.Add(bBack);
            Controls.Add(dataGridViewProduct);
            Name = "BargainingForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewProduct;
        private Button bBack;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewImageColumn ColumnPhoto;
        private DataGridViewTextBoxColumn ColumnPrice;
        private DataGridViewTextBoxColumn ColumnDataEnd;
    }
}