namespace AuctionApp
{
    partial class AuthForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelAuth = new Label();
            labelLogin = new Label();
            labelPassword = new Label();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            labelError = new Label();
            bEntry = new Button();
            SuspendLayout();
            // 
            // labelAuth
            // 
            labelAuth.AutoSize = true;
            labelAuth.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelAuth.Location = new Point(50, 9);
            labelAuth.Name = "labelAuth";
            labelAuth.Size = new Size(212, 45);
            labelAuth.TabIndex = 0;
            labelAuth.Text = "Авторизация";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelLogin.Location = new Point(12, 94);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(65, 25);
            labelLogin.TabIndex = 1;
            labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelPassword.Location = new Point(12, 182);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(78, 25);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Пароль";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLogin.Location = new Point(12, 122);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(299, 33);
            textBoxLogin.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(12, 210);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(299, 33);
            textBoxPassword.TabIndex = 4;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelError.Location = new Point(12, 255);
            labelError.Name = "labelError";
            labelError.Size = new Size(0, 17);
            labelError.TabIndex = 5;
            // 
            // bEntry
            // 
            bEntry.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            bEntry.Location = new Point(50, 313);
            bEntry.Name = "bEntry";
            bEntry.Size = new Size(212, 43);
            bEntry.TabIndex = 6;
            bEntry.Text = "Вход";
            bEntry.UseVisualStyleBackColor = true;
            bEntry.Click += bEntry_Click;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 368);
            Controls.Add(bEntry);
            Controls.Add(labelError);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(labelPassword);
            Controls.Add(labelLogin);
            Controls.Add(labelAuth);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "AuthForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAuth;
        private Label labelLogin;
        private Label labelPassword;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Label labelError;
        private Button bEntry;
    }
}
