namespace Water_Board_Management
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loginUsername = new System.Windows.Forms.TextBox();
            this.loginPassword = new System.Windows.Forms.TextBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.linkLabelApply = new System.Windows.Forms.LinkLabel();
            this.panelSelectCategory = new System.Windows.Forms.Panel();
            this.linkLabelWastageManagement = new System.Windows.Forms.LinkLabel();
            this.linkLabelCreateUser = new System.Windows.Forms.LinkLabel();
            this.linkLabelChangeUser = new System.Windows.Forms.LinkLabel();
            this.linkLabelMaintenance = new System.Windows.Forms.LinkLabel();
            this.linkLabelHelpDesk = new System.Windows.Forms.LinkLabel();
            this.linkLabelBilling = new System.Windows.Forms.LinkLabel();
            this.linkLabelNewConnection = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newAuthLevel = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.confPassword = new System.Windows.Forms.TextBox();
            this.newUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wait = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panelLogin.SuspendLayout();
            this.panelSelectCategory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wait)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(62, 148);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(680, 530);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(96, 49);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit System";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Graphis", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please fill your\r\nlogin details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginUsername
            // 
            this.loginUsername.Location = new System.Drawing.Point(30, 67);
            this.loginUsername.MaxLength = 20;
            this.loginUsername.Name = "loginUsername";
            this.loginUsername.Size = new System.Drawing.Size(138, 20);
            this.loginUsername.TabIndex = 3;
            this.loginUsername.Text = "USERNAME";
            this.loginUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loginUsername.Enter += new System.EventHandler(this.loginUsername_Enter);
            this.loginUsername.Leave += new System.EventHandler(this.loginUsername_Leave);
            // 
            // loginPassword
            // 
            this.loginPassword.Location = new System.Drawing.Point(30, 112);
            this.loginPassword.MaxLength = 20;
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.Size = new System.Drawing.Size(138, 20);
            this.loginPassword.TabIndex = 4;
            this.loginPassword.Text = "PASSWORD";
            this.loginPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loginPassword.Enter += new System.EventHandler(this.loginPassword_Enter);
            this.loginPassword.Leave += new System.EventHandler(this.loginPassword_Leave);
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelLogin.Controls.Add(this.linkLabelApply);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.loginPassword);
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Controls.Add(this.loginUsername);
            this.panelLogin.Location = new System.Drawing.Point(67, 152);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(200, 202);
            this.panelLogin.TabIndex = 5;
            // 
            // linkLabelApply
            // 
            this.linkLabelApply.AutoSize = true;
            this.linkLabelApply.Location = new System.Drawing.Point(-1, 179);
            this.linkLabelApply.Name = "linkLabelApply";
            this.linkLabelApply.Size = new System.Drawing.Size(202, 13);
            this.linkLabelApply.TabIndex = 5;
            this.linkLabelApply.TabStop = true;
            this.linkLabelApply.Text = "Click to apply for a new water connection";
            this.linkLabelApply.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelApply_LinkClicked);
            // 
            // panelSelectCategory
            // 
            this.panelSelectCategory.BackColor = System.Drawing.Color.Transparent;
            this.panelSelectCategory.Controls.Add(this.linkLabelWastageManagement);
            this.panelSelectCategory.Controls.Add(this.linkLabelCreateUser);
            this.panelSelectCategory.Controls.Add(this.linkLabelChangeUser);
            this.panelSelectCategory.Controls.Add(this.linkLabelMaintenance);
            this.panelSelectCategory.Controls.Add(this.linkLabelHelpDesk);
            this.panelSelectCategory.Controls.Add(this.linkLabelBilling);
            this.panelSelectCategory.Controls.Add(this.linkLabelNewConnection);
            this.panelSelectCategory.Controls.Add(this.label2);
            this.panelSelectCategory.Location = new System.Drawing.Point(67, 152);
            this.panelSelectCategory.Name = "panelSelectCategory";
            this.panelSelectCategory.Size = new System.Drawing.Size(10, 10);
            this.panelSelectCategory.TabIndex = 5;
            // 
            // linkLabelWastageManagement
            // 
            this.linkLabelWastageManagement.AutoSize = true;
            this.linkLabelWastageManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelWastageManagement.Location = new System.Drawing.Point(64, 202);
            this.linkLabelWastageManagement.Name = "linkLabelWastageManagement";
            this.linkLabelWastageManagement.Size = new System.Drawing.Size(175, 18);
            this.linkLabelWastageManagement.TabIndex = 3;
            this.linkLabelWastageManagement.TabStop = true;
            this.linkLabelWastageManagement.Text = "Wastage Management";
            this.linkLabelWastageManagement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWastageManagement_LinkClicked);
            // 
            // linkLabelCreateUser
            // 
            this.linkLabelCreateUser.AutoSize = true;
            this.linkLabelCreateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelCreateUser.Location = new System.Drawing.Point(87, 287);
            this.linkLabelCreateUser.Name = "linkLabelCreateUser";
            this.linkLabelCreateUser.Size = new System.Drawing.Size(137, 18);
            this.linkLabelCreateUser.TabIndex = 2;
            this.linkLabelCreateUser.TabStop = true;
            this.linkLabelCreateUser.Text = "Create New User";
            this.linkLabelCreateUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCreateUser_LinkClicked);
            // 
            // linkLabelChangeUser
            // 
            this.linkLabelChangeUser.AutoSize = true;
            this.linkLabelChangeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelChangeUser.Location = new System.Drawing.Point(32, 260);
            this.linkLabelChangeUser.Name = "linkLabelChangeUser";
            this.linkLabelChangeUser.Size = new System.Drawing.Size(238, 18);
            this.linkLabelChangeUser.TabIndex = 2;
            this.linkLabelChangeUser.TabStop = true;
            this.linkLabelChangeUser.Text = "Change User Account Settings";
            this.linkLabelChangeUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelChangeUser_LinkClicked);
            // 
            // linkLabelMaintenance
            // 
            this.linkLabelMaintenance.AutoSize = true;
            this.linkLabelMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelMaintenance.Location = new System.Drawing.Point(102, 167);
            this.linkLabelMaintenance.Name = "linkLabelMaintenance";
            this.linkLabelMaintenance.Size = new System.Drawing.Size(103, 18);
            this.linkLabelMaintenance.TabIndex = 1;
            this.linkLabelMaintenance.TabStop = true;
            this.linkLabelMaintenance.Text = "Maintenance";
            this.linkLabelMaintenance.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMaintenance_LinkClicked);
            // 
            // linkLabelHelpDesk
            // 
            this.linkLabelHelpDesk.AutoSize = true;
            this.linkLabelHelpDesk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelHelpDesk.Location = new System.Drawing.Point(111, 132);
            this.linkLabelHelpDesk.Name = "linkLabelHelpDesk";
            this.linkLabelHelpDesk.Size = new System.Drawing.Size(86, 18);
            this.linkLabelHelpDesk.TabIndex = 1;
            this.linkLabelHelpDesk.TabStop = true;
            this.linkLabelHelpDesk.Text = "Help Desk";
            this.linkLabelHelpDesk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelpDesk_LinkClicked);
            // 
            // linkLabelBilling
            // 
            this.linkLabelBilling.AutoSize = true;
            this.linkLabelBilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelBilling.Location = new System.Drawing.Point(127, 98);
            this.linkLabelBilling.Name = "linkLabelBilling";
            this.linkLabelBilling.Size = new System.Drawing.Size(53, 18);
            this.linkLabelBilling.TabIndex = 1;
            this.linkLabelBilling.TabStop = true;
            this.linkLabelBilling.Text = "Billing";
            this.linkLabelBilling.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBilling_LinkClicked);
            // 
            // linkLabelNewConnection
            // 
            this.linkLabelNewConnection.AutoSize = true;
            this.linkLabelNewConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelNewConnection.Location = new System.Drawing.Point(83, 67);
            this.linkLabelNewConnection.Name = "linkLabelNewConnection";
            this.linkLabelNewConnection.Size = new System.Drawing.Size(141, 18);
            this.linkLabelNewConnection.TabIndex = 1;
            this.linkLabelNewConnection.TabStop = true;
            this.linkLabelNewConnection.Text = "New Connections";
            this.linkLabelNewConnection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNewConnection_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Graphis", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Please select a category \r\nto work with";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(573, 530);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(96, 49);
            this.buttonLogout.TabIndex = 6;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.logout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.newAuthLevel);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonCreate);
            this.groupBox1.Controls.Add(this.newPassword);
            this.groupBox1.Controls.Add(this.confPassword);
            this.groupBox1.Controls.Add(this.newUsername);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Location = new System.Drawing.Point(506, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 277);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details";
            this.groupBox1.Visible = false;
            // 
            // newAuthLevel
            // 
            this.newAuthLevel.FormattingEnabled = true;
            this.newAuthLevel.Items.AddRange(new object[] {
            "Administrator",
            "Customer",
            "Data Operator",
            "Customer Related Officer",
            "Zonal Officer"});
            this.newAuthLevel.Location = new System.Drawing.Point(25, 189);
            this.newAuthLevel.Name = "newAuthLevel";
            this.newAuthLevel.Size = new System.Drawing.Size(182, 21);
            this.newAuthLevel.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCancel.Location = new System.Drawing.Point(131, 243);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCreate.Location = new System.Drawing.Point(24, 243);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.create_Click);
            // 
            // newPassword
            // 
            this.newPassword.Location = new System.Drawing.Point(24, 91);
            this.newPassword.MaxLength = 20;
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(182, 20);
            this.newPassword.TabIndex = 1;
            this.newPassword.UseSystemPasswordChar = true;
            // 
            // confPassword
            // 
            this.confPassword.Location = new System.Drawing.Point(25, 138);
            this.confPassword.MaxLength = 20;
            this.confPassword.Name = "confPassword";
            this.confPassword.Size = new System.Drawing.Size(182, 20);
            this.confPassword.TabIndex = 1;
            this.confPassword.UseSystemPasswordChar = true;
            // 
            // newUsername
            // 
            this.newUsername.Location = new System.Drawing.Point(24, 45);
            this.newUsername.MaxLength = 20;
            this.newUsername.Name = "newUsername";
            this.newUsername.Size = new System.Drawing.Size(182, 20);
            this.newUsername.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(39, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Authentication Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(79, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Info;
            this.label5.Location = new System.Drawing.Point(48, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Confirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(78, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username";
            // 
            // wait
            // 
            this.wait.Image = ((System.Drawing.Image)(resources.GetObject("wait.Image")));
            this.wait.Location = new System.Drawing.Point(300, 200);
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(200, 200);
            this.wait.TabIndex = 8;
            this.wait.TabStop = false;
            this.wait.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 92);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.panelSelectCategory);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logincs";
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelSelectCategory.ResumeLayout(false);
            this.panelSelectCategory.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wait)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loginUsername;
        private System.Windows.Forms.TextBox loginPassword;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelSelectCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabelNewConnection;
        private System.Windows.Forms.LinkLabel linkLabelMaintenance;
        private System.Windows.Forms.LinkLabel linkLabelHelpDesk;
        private System.Windows.Forms.LinkLabel linkLabelBilling;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.LinkLabel linkLabelChangeUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.TextBox newUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox confPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox newAuthLevel;
        private System.Windows.Forms.PictureBox wait;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.LinkLabel linkLabelCreateUser;
        private System.Windows.Forms.LinkLabel linkLabelApply;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.LinkLabel linkLabelWastageManagement;
    }
}