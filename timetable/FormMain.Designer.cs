namespace timetable
{
    partial class FormMain
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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.GUI_semester = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GUI_update = new System.Windows.Forms.Button();
            this.GUI_login = new System.Windows.Forms.Button();
            this.GUI_refresh = new System.Windows.Forms.Button();
            this.GUI_week = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GUI_tips = new System.Windows.Forms.Label();
            this.loadText = new System.Windows.Forms.Label();
            this.barLoad = new System.Windows.Forms.ProgressBar();
            this.lvkb = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GUI_semester
            // 
            this.GUI_semester.FormattingEnabled = true;
            this.GUI_semester.Location = new System.Drawing.Point(92, 26);
            this.GUI_semester.Name = "GUI_semester";
            this.GUI_semester.Size = new System.Drawing.Size(121, 25);
            this.GUI_semester.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GUI_update);
            this.panel1.Controls.Add(this.GUI_login);
            this.panel1.Controls.Add(this.GUI_refresh);
            this.panel1.Controls.Add(this.GUI_week);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GUI_semester);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 72);
            this.panel1.TabIndex = 1;
            // 
            // GUI_update
            // 
            this.GUI_update.Location = new System.Drawing.Point(573, 27);
            this.GUI_update.Name = "GUI_update";
            this.GUI_update.Size = new System.Drawing.Size(75, 23);
            this.GUI_update.TabIndex = 6;
            this.GUI_update.Text = "button1";
            this.GUI_update.UseVisualStyleBackColor = true;
            this.GUI_update.Click += new System.EventHandler(this.GUI_update_Click);
            // 
            // GUI_login
            // 
            this.GUI_login.Location = new System.Drawing.Point(839, 27);
            this.GUI_login.Name = "GUI_login";
            this.GUI_login.Size = new System.Drawing.Size(75, 23);
            this.GUI_login.TabIndex = 5;
            this.GUI_login.Text = "button1";
            this.GUI_login.UseVisualStyleBackColor = true;
            this.GUI_login.Click += new System.EventHandler(this.GUI_login_Click);
            // 
            // GUI_refresh
            // 
            this.GUI_refresh.Location = new System.Drawing.Point(697, 27);
            this.GUI_refresh.Name = "GUI_refresh";
            this.GUI_refresh.Size = new System.Drawing.Size(75, 23);
            this.GUI_refresh.TabIndex = 4;
            this.GUI_refresh.Text = "button1";
            this.GUI_refresh.UseVisualStyleBackColor = true;
            this.GUI_refresh.Click += new System.EventHandler(this.GUI_refresh_Click);
            // 
            // GUI_week
            // 
            this.GUI_week.FormattingEnabled = true;
            this.GUI_week.Location = new System.Drawing.Point(388, 26);
            this.GUI_week.Name = "GUI_week";
            this.GUI_week.Size = new System.Drawing.Size(121, 25);
            this.GUI_week.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前周";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前学期";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.GUI_tips);
            this.panel2.Controls.Add(this.loadText);
            this.panel2.Controls.Add(this.barLoad);
            this.panel2.Controls.Add(this.lvkb);
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 473);
            this.panel2.TabIndex = 1;
            // 
            // GUI_tips
            // 
            this.GUI_tips.AutoSize = true;
            this.GUI_tips.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GUI_tips.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GUI_tips.Location = new System.Drawing.Point(438, 160);
            this.GUI_tips.Margin = new System.Windows.Forms.Padding(3);
            this.GUI_tips.Name = "GUI_tips";
            this.GUI_tips.Size = new System.Drawing.Size(62, 35);
            this.GUI_tips.TabIndex = 2;
            this.GUI_tips.Text = "tips";
            // 
            // loadText
            // 
            this.loadText.AutoSize = true;
            this.loadText.Location = new System.Drawing.Point(447, 204);
            this.loadText.Name = "loadText";
            this.loadText.Size = new System.Drawing.Size(53, 17);
            this.loadText.TabIndex = 2;
            this.loadText.Text = "加载中...";
            // 
            // barLoad
            // 
            this.barLoad.Location = new System.Drawing.Point(257, 201);
            this.barLoad.Name = "barLoad";
            this.barLoad.Size = new System.Drawing.Size(445, 23);
            this.barLoad.TabIndex = 1;
            // 
            // lvkb
            // 
            this.lvkb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvkb.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvkb.FullRowSelect = true;
            this.lvkb.GridLines = true;
            this.lvkb.HideSelection = false;
            this.lvkb.Location = new System.Drawing.Point(0, 0);
            this.lvkb.Name = "lvkb";
            this.lvkb.Size = new System.Drawing.Size(960, 473);
            this.lvkb.TabIndex = 0;
            this.lvkb.UseCompatibleStateImageBehavior = false;
            this.lvkb.View = System.Windows.Forms.View.Details;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 545);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ComboBox GUI_semester;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvkb;
        private System.Windows.Forms.ProgressBar barLoad;
        private System.Windows.Forms.Label loadText;
        private System.Windows.Forms.ComboBox GUI_week;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GUI_refresh;
        private System.Windows.Forms.Label GUI_tips;
        private System.Windows.Forms.Button GUI_login;
        private System.Windows.Forms.Button GUI_update;
    }
}