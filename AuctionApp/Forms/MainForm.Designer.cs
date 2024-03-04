namespace AuctionApp.Forms
{
    partial class MainForm
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
            listBoxCategory = new ListBox();
            labelCategory = new Label();
            bAddProduct = new Button();
            SuspendLayout();
            // 
            // listBoxCategory
            // 
            listBoxCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxCategory.FormattingEnabled = true;
            listBoxCategory.ItemHeight = 21;
            listBoxCategory.Location = new Point(12, 52);
            listBoxCategory.Name = "listBoxCategory";
            listBoxCategory.Size = new Size(422, 382);
            listBoxCategory.TabIndex = 0;
            listBoxCategory.MouseDoubleClick += listBoxCategory_MouseDoubleClick;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCategory.Location = new Point(12, 17);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(178, 25);
            labelCategory.TabIndex = 1;
            labelCategory.Text = "Категории товаров";
            // 
            // bAddProduct
            // 
            bAddProduct.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            bAddProduct.Location = new Point(275, 12);
            bAddProduct.Name = "bAddProduct";
            bAddProduct.Size = new Size(159, 34);
            bAddProduct.TabIndex = 2;
            bAddProduct.Text = "Добавить товар";
            bAddProduct.UseVisualStyleBackColor = true;
            bAddProduct.Click += bAddProduct_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 454);
            Controls.Add(bAddProduct);
            Controls.Add(labelCategory);
            Controls.Add(listBoxCategory);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxCategory;
        private Label labelCategory;
        private Button bAddProduct;
    }
}