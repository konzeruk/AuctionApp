namespace AuctionApp.Forms
{
    partial class BidForm
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
            numericUpDownPrice = new NumericUpDown();
            bOk = new Button();
            bCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownPrice.Location = new Point(12, 12);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(258, 33);
            numericUpDownPrice.TabIndex = 1;
            // 
            // bOk
            // 
            bOk.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            bOk.Location = new Point(12, 51);
            bOk.Name = "bOk";
            bOk.Size = new Size(101, 35);
            bOk.TabIndex = 2;
            bOk.Text = "ОК";
            bOk.UseVisualStyleBackColor = true;
            bOk.Click += bOk_Click;
            // 
            // bCancel
            // 
            bCancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            bCancel.Location = new Point(169, 51);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(101, 35);
            bCancel.TabIndex = 3;
            bCancel.Text = "Отмена";
            bCancel.UseVisualStyleBackColor = true;
            bCancel.Click += bCancel_Click;
            // 
            // BidForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 96);
            ControlBox = false;
            Controls.Add(bCancel);
            Controls.Add(bOk);
            Controls.Add(numericUpDownPrice);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BidForm";
            Text = "Ставка";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private NumericUpDown numericUpDownPrice;
        private Button bOk;
        private Button bCancel;
    }
}