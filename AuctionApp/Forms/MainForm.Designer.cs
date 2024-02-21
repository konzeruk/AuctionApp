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
            SuspendLayout();
            // 
            // listBoxCategory
            // 
            listBoxCategory.FormattingEnabled = true;
            listBoxCategory.ItemHeight = 15;
            listBoxCategory.Location = new Point(12, 12);
            listBoxCategory.Name = "listBoxCategory";
            listBoxCategory.Size = new Size(422, 424);
            listBoxCategory.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 450);
            Controls.Add(listBoxCategory);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxCategory;
    }
}