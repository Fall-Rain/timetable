namespace timetable
{
    partial class FormLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.GUI_User_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GUI_User_Pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GUI_verfyCode = new System.Windows.Forms.TextBox();
            this.verfyCodeImg = new System.Windows.Forms.PictureBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.GUI_rememberpassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.verfyCodeImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(107, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // GUI_User_Name
            // 
            this.GUI_User_Name.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GUI_User_Name.Location = new System.Drawing.Point(188, 59);
            this.GUI_User_Name.Name = "GUI_User_Name";
            this.GUI_User_Name.Size = new System.Drawing.Size(235, 33);
            this.GUI_User_Name.TabIndex = 1;
            this.GUI_User_Name.Enter += new System.EventHandler(this.selectall);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(119, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码：";
            // 
            // GUI_User_Pwd
            // 
            this.GUI_User_Pwd.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GUI_User_Pwd.Location = new System.Drawing.Point(188, 107);
            this.GUI_User_Pwd.Name = "GUI_User_Pwd";
            this.GUI_User_Pwd.PasswordChar = '●';
            this.GUI_User_Pwd.Size = new System.Drawing.Size(235, 33);
            this.GUI_User_Pwd.TabIndex = 2;
            this.GUI_User_Pwd.Enter += new System.EventHandler(this.selectall);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(107, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "验证码：";
            // 
            // GUI_verfyCode
            // 
            this.GUI_verfyCode.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GUI_verfyCode.Location = new System.Drawing.Point(188, 154);
            this.GUI_verfyCode.Name = "GUI_verfyCode";
            this.GUI_verfyCode.Size = new System.Drawing.Size(103, 33);
            this.GUI_verfyCode.TabIndex = 3;
            this.GUI_verfyCode.Enter += new System.EventHandler(this.selectall);
            // 
            // verfyCodeImg
            // 
            this.verfyCodeImg.Location = new System.Drawing.Point(297, 154);
            this.verfyCodeImg.Name = "verfyCodeImg";
            this.verfyCodeImg.Size = new System.Drawing.Size(126, 31);
            this.verfyCodeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.verfyCodeImg.TabIndex = 2;
            this.verfyCodeImg.TabStop = false;
            this.verfyCodeImg.Click += new System.EventHandler(this.verfyCodeImg_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(206, 221);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(112, 28);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "登录";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // GUI_rememberpassword
            // 
            this.GUI_rememberpassword.AutoSize = true;
            this.GUI_rememberpassword.Location = new System.Drawing.Point(334, 226);
            this.GUI_rememberpassword.Name = "GUI_rememberpassword";
            this.GUI_rememberpassword.Size = new System.Drawing.Size(75, 21);
            this.GUI_rememberpassword.TabIndex = 5;
            this.GUI_rememberpassword.Text = "记住密码";
            this.GUI_rememberpassword.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 308);
            this.Controls.Add(this.GUI_rememberpassword);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.verfyCodeImg);
            this.Controls.Add(this.GUI_verfyCode);
            this.Controls.Add(this.GUI_User_Pwd);
            this.Controls.Add(this.GUI_User_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.verfyCodeImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GUI_User_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GUI_User_Pwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox verfyCodeImg;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox GUI_verfyCode;
        private System.Windows.Forms.CheckBox GUI_rememberpassword;
    }
}

