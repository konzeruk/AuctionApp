namespace AuctionApp.Forms
{
    partial class AddProductForm
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
            labelName = new Label();
            labelPrice = new Label();
            labelDateEnd = new Label();
            labelCategory = new Label();
            textBoxName = new TextBox();
            numericUpDownPrice = new NumericUpDown();
            dateTimePickerDateEnd = new DateTimePicker();
            comboBoxCategory = new ComboBox();
            bOk = new Button();
            bCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelName.Location = new Point(12, 9);
            labelName.Margin = new Padding(5, 0, 5, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(160, 25);
            labelName.TabIndex = 0;
            labelName.Text = "Название товара";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelPrice.Location = new Point(14, 73);
            labelPrice.Margin = new Padding(5, 0, 5, 0);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(122, 25);
            labelPrice.TabIndex = 1;
            labelPrice.Text = "Цена товара";
            // 
            // labelDateEnd
            // 
            labelDateEnd.AutoSize = true;
            labelDateEnd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelDateEnd.Location = new Point(12, 137);
            labelDateEnd.Margin = new Padding(5, 0, 5, 0);
            labelDateEnd.Name = "labelDateEnd";
            labelDateEnd.Size = new Size(216, 25);
            labelDateEnd.TabIndex = 2;
            labelDateEnd.Text = "Дата окончания торгов";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCategory.Location = new Point(12, 201);
            labelCategory.Margin = new Padding(5, 0, 5, 0);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(101, 25);
            labelCategory.TabIndex = 3;
            labelCategory.Text = "Категория";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 37);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(257, 33);
            textBoxName.TabIndex = 4;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Location = new Point(12, 101);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(257, 33);
            numericUpDownPrice.TabIndex = 5;
            // 
            // dateTimePickerDateEnd
            // 
            dateTimePickerDateEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateEnd.Location = new Point(14, 165);
            dateTimePickerDateEnd.Name = "dateTimePickerDateEnd";
            dateTimePickerDateEnd.Size = new Size(255, 33);
            dateTimePickerDateEnd.TabIndex = 6;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(12, 229);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(257, 33);
            comboBoxCategory.TabIndex = 7;
            // 
            // bOk
            // 
            bOk.Location = new Point(12, 280);
            bOk.Name = "bOk";
            bOk.Size = new Size(87, 38);
            bOk.TabIndex = 8;
            bOk.Text = "OK";
            bOk.UseVisualStyleBackColor = true;
            bOk.Click += bOk_Click;
            // 
            // bCancel
            // 
            bCancel.Location = new Point(182, 280);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(87, 38);
            bCancel.TabIndex = 9;
            bCancel.Text = "Отмена";
            bCancel.UseVisualStyleBackColor = true;
            bCancel.Click += bCancel_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 330);
            ControlBox = false;
            Controls.Add(bCancel);
            Controls.Add(bOk);
            Controls.Add(comboBoxCategory);
            Controls.Add(dateTimePickerDateEnd);
            Controls.Add(numericUpDownPrice);
            Controls.Add(textBoxName);
            Controls.Add(labelCategory);
            Controls.Add(labelDateEnd);
            Controls.Add(labelPrice);
            Controls.Add(labelName);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "AddProductForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelPrice;
        private Label labelDateEnd;
        private Label labelCategory;
        private TextBox textBoxName;
        private NumericUpDown numericUpDownPrice;
        private DateTimePicker dateTimePickerDateEnd;
        private ComboBox comboBoxCategory;
        private Button bOk;
        private Button bCancel;
    }
}