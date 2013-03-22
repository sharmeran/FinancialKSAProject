namespace FinancialStatmentsProcessor.Views.Administration
{
    partial class LoginForm
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
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.txt_Username = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.btn_Login = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(170, 249);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.NullText = "Username";
            this.txt_Username.Size = new System.Drawing.Size(253, 20);
            this.txt_Username.TabIndex = 0;
            this.txt_Username.TabStop = false;
            this.txt_Username.ThemeName = "Aqua";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(170, 287);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.NullText = "Password";
            this.radTextBox1.PasswordChar = '*';
            this.radTextBox1.Size = new System.Drawing.Size(253, 20);
            this.radTextBox1.TabIndex = 1;
            this.radTextBox1.TabStop = false;
            this.radTextBox1.ThemeName = "Aqua";
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(170, 349);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(253, 24);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "Login";
            this.btn_Login.ThemeName = "Aqua";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::FinancialStatmentsProcessor.Properties.Resources.LoginEn;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(601, 530);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.txt_Username);
            this.Name = "LoginForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "LoginForm";
            this.ThemeName = "Aqua";
            ((System.ComponentModel.ISupportInitialize)(this.txt_Username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        private Telerik.WinControls.UI.RadTextBox txt_Username;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadButton btn_Login;
    }
}
