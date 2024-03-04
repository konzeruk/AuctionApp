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
            dataGridViewProducts = new DataGridView();
            ColumnName = new DataGridViewTextBoxColumn();
            ColumnPrice = new DataGridViewTextBoxColumn();
            ColumnDateEnd = new DataGridViewTextBoxColumn();
            bUpdataPrice = new DataGridViewButtonColumn();
            bBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Columns.AddRange(new DataGridViewColumn[] { ColumnName, ColumnPrice, ColumnDateEnd, bUpdataPrice });
            dataGridViewProducts.Location = new Point(12, 12);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowTemplate.Height = 25;
            dataGridViewProducts.Size = new Size(684, 404);
            dataGridViewProducts.TabIndex = 0;
            dataGridViewProducts.CellContentClick += dataGridViewProducts_CellContentClick;
            // 
            // ColumnName
            // 
            ColumnName.HeaderText = "Название";
            ColumnName.Name = "ColumnName";
            ColumnName.ReadOnly = true;
            // 
            // ColumnPrice
            // 
            ColumnPrice.HeaderText = "Цена";
            ColumnPrice.Name = "ColumnPrice";
            ColumnPrice.ReadOnly = true;
            // 
            // ColumnDateEnd
            // 
            ColumnDateEnd.HeaderText = "Дата окончания";
            ColumnDateEnd.Name = "ColumnDateEnd";
            ColumnDateEnd.ReadOnly = true;
            // 
            // bUpdataPrice
            // 
            bUpdataPrice.HeaderText = "";
            bUpdataPrice.Name = "bUpdataPrice";
            bUpdataPrice.Text = "Ставка";
            bUpdataPrice.UseColumnTextForButtonValue = true;
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
            bBack.Click += bBack_Click;
            // 
            // BargainingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 480);
            ControlBox = false;
            Controls.Add(bBack);
            Controls.Add(dataGridViewProducts);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BargainingForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewProducts;
        private Button bBack;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnPrice;
        private DataGridViewTextBoxColumn ColumnDateEnd;
        private DataGridViewButtonColumn bUpdataPrice;
    }
}