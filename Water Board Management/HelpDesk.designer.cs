namespace Water_Board_Management_HelpDesk
{
    partial class HelpDesk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpDesk));
            this.hdTabs = new System.Windows.Forms.TabControl();
            this.hdTab1 = new System.Windows.Forms.TabPage();
            this.refNo = new System.Windows.Forms.Label();
            this.subm1 = new System.Windows.Forms.Button();
            this.addInfoBx = new System.Windows.Forms.TextBox();
            this.addInfo = new System.Windows.Forms.Label();
            this.subtypeCmb = new System.Windows.Forms.ComboBox();
            this.subtype = new System.Windows.Forms.Label();
            this.maintypeCmb = new System.Windows.Forms.ComboBox();
            this.mainType = new System.Windows.Forms.Label();
            this.hdTab2 = new System.Windows.Forms.TabPage();
            this.details = new System.Windows.Forms.GroupBox();
            this.detailbx = new System.Windows.Forms.TextBox();
            this.subm2 = new System.Windows.Forms.Button();
            this.refNBx = new System.Windows.Forms.TextBox();
            this.refN = new System.Windows.Forms.Label();
            this.inquiryCmb = new System.Windows.Forms.ComboBox();
            this.inquiry = new System.Windows.Forms.Label();
            this.hdTab3 = new System.Windows.Forms.TabPage();
            this.refNum = new System.Windows.Forms.Label();
            this.subm3 = new System.Windows.Forms.Button();
            this.aplSubCmb = new System.Windows.Forms.ComboBox();
            this.aplSubTyp = new System.Windows.Forms.Label();
            this.applCmb = new System.Windows.Forms.ComboBox();
            this.applType = new System.Windows.Forms.Label();
            this.hdTop = new System.Windows.Forms.Panel();
            this.accnt = new System.Windows.Forms.Label();
            this.accNumBx = new System.Windows.Forms.TextBox();
            this.hdTabs.SuspendLayout();
            this.hdTab1.SuspendLayout();
            this.hdTab2.SuspendLayout();
            this.details.SuspendLayout();
            this.hdTab3.SuspendLayout();
            this.SuspendLayout();
            // 
            // hdTabs
            // 
            this.hdTabs.Controls.Add(this.hdTab1);
            this.hdTabs.Controls.Add(this.hdTab2);
            this.hdTabs.Controls.Add(this.hdTab3);
            this.hdTabs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdTabs.ItemSize = new System.Drawing.Size(250, 25);
            this.hdTabs.Location = new System.Drawing.Point(11, 151);
            this.hdTabs.Name = "hdTabs";
            this.hdTabs.SelectedIndex = 0;
            this.hdTabs.Size = new System.Drawing.Size(765, 404);
            this.hdTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.hdTabs.TabIndex = 0;
            this.hdTabs.SelectedIndexChanged += new System.EventHandler(this.hdTabs_SelectedIndexChanged);
            // 
            // hdTab1
            // 
            this.hdTab1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hdTab1.BackgroundImage")));
            this.hdTab1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hdTab1.Controls.Add(this.refNo);
            this.hdTab1.Controls.Add(this.subm1);
            this.hdTab1.Controls.Add(this.addInfoBx);
            this.hdTab1.Controls.Add(this.addInfo);
            this.hdTab1.Controls.Add(this.subtypeCmb);
            this.hdTab1.Controls.Add(this.subtype);
            this.hdTab1.Controls.Add(this.maintypeCmb);
            this.hdTab1.Controls.Add(this.mainType);
            this.hdTab1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hdTab1.Location = new System.Drawing.Point(4, 29);
            this.hdTab1.Name = "hdTab1";
            this.hdTab1.Padding = new System.Windows.Forms.Padding(3);
            this.hdTab1.Size = new System.Drawing.Size(757, 371);
            this.hdTab1.TabIndex = 0;
            this.hdTab1.Text = "Complaints";
            this.hdTab1.UseVisualStyleBackColor = true;
            // 
            // refNo
            // 
            this.refNo.AutoSize = true;
            this.refNo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refNo.ForeColor = System.Drawing.Color.DarkRed;
            this.refNo.Location = new System.Drawing.Point(29, 335);
            this.refNo.Name = "refNo";
            this.refNo.Size = new System.Drawing.Size(194, 22);
            this.refNo.TabIndex = 7;
            this.refNo.Text = "Reference Number :";
            this.refNo.Visible = false;
            // 
            // subm1
            // 
            this.subm1.BackColor = System.Drawing.Color.Honeydew;
            this.subm1.ForeColor = System.Drawing.Color.Green;
            this.subm1.Location = new System.Drawing.Point(636, 292);
            this.subm1.Name = "subm1";
            this.subm1.Size = new System.Drawing.Size(102, 34);
            this.subm1.TabIndex = 6;
            this.subm1.Text = "Submit";
            this.subm1.UseVisualStyleBackColor = false;
            this.subm1.Visible = false;
            this.subm1.Click += new System.EventHandler(this.subm1_Click);
            // 
            // addInfoBx
            // 
            this.addInfoBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addInfoBx.Location = new System.Drawing.Point(186, 211);
            this.addInfoBx.MaxLength = 100;
            this.addInfoBx.Multiline = true;
            this.addInfoBx.Name = "addInfoBx";
            this.addInfoBx.Size = new System.Drawing.Size(355, 67);
            this.addInfoBx.TabIndex = 5;
            this.addInfoBx.Visible = false;
            // 
            // addInfo
            // 
            this.addInfo.AutoSize = true;
            this.addInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addInfo.Location = new System.Drawing.Point(30, 211);
            this.addInfo.Name = "addInfo";
            this.addInfo.Size = new System.Drawing.Size(136, 32);
            this.addInfo.TabIndex = 4;
            this.addInfo.Text = "Additional Information\r\n(max 100 characters)";
            this.addInfo.Visible = false;
            // 
            // subtypeCmb
            // 
            this.subtypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subtypeCmb.DropDownWidth = 180;
            this.subtypeCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtypeCmb.FormattingEnabled = true;
            this.subtypeCmb.Items.AddRange(new object[] {
            "Water Leakage",
            "Meter Defect",
            "High Bill",
            "Other . . ."});
            this.subtypeCmb.Location = new System.Drawing.Point(186, 155);
            this.subtypeCmb.Name = "subtypeCmb";
            this.subtypeCmb.Size = new System.Drawing.Size(180, 24);
            this.subtypeCmb.TabIndex = 3;
            this.subtypeCmb.Visible = false;
            this.subtypeCmb.SelectedIndexChanged += new System.EventHandler(this.subtypeCmb_SelectedIndexChanged);
            // 
            // subtype
            // 
            this.subtype.AutoSize = true;
            this.subtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtype.Location = new System.Drawing.Point(30, 158);
            this.subtype.Name = "subtype";
            this.subtype.Size = new System.Drawing.Size(67, 16);
            this.subtype.TabIndex = 2;
            this.subtype.Text = "Sub Type";
            this.subtype.Visible = false;
            // 
            // maintypeCmb
            // 
            this.maintypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maintypeCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintypeCmb.FormattingEnabled = true;
            this.maintypeCmb.Items.AddRange(new object[] {
            "Water Leakage",
            "Meter Defect",
            "High Bill",
            "Illegal Connections"});
            this.maintypeCmb.Location = new System.Drawing.Point(186, 97);
            this.maintypeCmb.Name = "maintypeCmb";
            this.maintypeCmb.Size = new System.Drawing.Size(180, 24);
            this.maintypeCmb.TabIndex = 1;
            this.maintypeCmb.SelectedIndexChanged += new System.EventHandler(this.maintypeCmb_SelectedIndexChanged);
            // 
            // mainType
            // 
            this.mainType.AutoSize = true;
            this.mainType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainType.Location = new System.Drawing.Point(30, 100);
            this.mainType.Name = "mainType";
            this.mainType.Size = new System.Drawing.Size(103, 16);
            this.mainType.TabIndex = 0;
            this.mainType.Text = "Complaint Type";
            // 
            // hdTab2
            // 
            this.hdTab2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hdTab2.BackgroundImage")));
            this.hdTab2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hdTab2.Controls.Add(this.details);
            this.hdTab2.Controls.Add(this.subm2);
            this.hdTab2.Controls.Add(this.refNBx);
            this.hdTab2.Controls.Add(this.refN);
            this.hdTab2.Controls.Add(this.inquiryCmb);
            this.hdTab2.Controls.Add(this.inquiry);
            this.hdTab2.Location = new System.Drawing.Point(4, 29);
            this.hdTab2.Name = "hdTab2";
            this.hdTab2.Padding = new System.Windows.Forms.Padding(3);
            this.hdTab2.Size = new System.Drawing.Size(757, 371);
            this.hdTab2.TabIndex = 1;
            this.hdTab2.Text = "Inquiries";
            this.hdTab2.UseVisualStyleBackColor = true;
            // 
            // details
            // 
            this.details.Controls.Add(this.detailbx);
            this.details.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.details.ForeColor = System.Drawing.Color.MidnightBlue;
            this.details.Location = new System.Drawing.Point(30, 198);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(708, 167);
            this.details.TabIndex = 8;
            this.details.TabStop = false;
            this.details.Text = "Details";
            this.details.Visible = false;
            // 
            // detailbx
            // 
            this.detailbx.AcceptsReturn = true;
            this.detailbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailbx.ForeColor = System.Drawing.Color.Maroon;
            this.detailbx.Location = new System.Drawing.Point(10, 23);
            this.detailbx.Multiline = true;
            this.detailbx.Name = "detailbx";
            this.detailbx.ReadOnly = true;
            this.detailbx.Size = new System.Drawing.Size(692, 138);
            this.detailbx.TabIndex = 0;
            // 
            // subm2
            // 
            this.subm2.BackColor = System.Drawing.Color.Honeydew;
            this.subm2.ForeColor = System.Drawing.Color.Green;
            this.subm2.Location = new System.Drawing.Point(636, 158);
            this.subm2.Name = "subm2";
            this.subm2.Size = new System.Drawing.Size(102, 34);
            this.subm2.TabIndex = 7;
            this.subm2.Text = "Submit";
            this.subm2.UseVisualStyleBackColor = false;
            this.subm2.Visible = false;
            this.subm2.Click += new System.EventHandler(this.subm2_Click);
            // 
            // refNBx
            // 
            this.refNBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refNBx.Location = new System.Drawing.Point(186, 132);
            this.refNBx.MaxLength = 5;
            this.refNBx.Name = "refNBx";
            this.refNBx.Size = new System.Drawing.Size(97, 22);
            this.refNBx.TabIndex = 5;
            this.refNBx.Visible = false;
            this.refNBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.refNBx_KeyPress);
            // 
            // refN
            // 
            this.refN.AutoSize = true;
            this.refN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refN.Location = new System.Drawing.Point(30, 137);
            this.refN.Name = "refN";
            this.refN.Size = new System.Drawing.Size(122, 16);
            this.refN.TabIndex = 4;
            this.refN.Text = "Reference Number";
            this.refN.Visible = false;
            // 
            // inquiryCmb
            // 
            this.inquiryCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inquiryCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inquiryCmb.FormattingEnabled = true;
            this.inquiryCmb.Items.AddRange(new object[] {
            "Complaint",
            "Appeal",
            "New Connection"});
            this.inquiryCmb.Location = new System.Drawing.Point(186, 76);
            this.inquiryCmb.Name = "inquiryCmb";
            this.inquiryCmb.Size = new System.Drawing.Size(180, 24);
            this.inquiryCmb.TabIndex = 3;
            this.inquiryCmb.SelectedIndexChanged += new System.EventHandler(this.inquiryCmb_SelectedIndexChanged);
            // 
            // inquiry
            // 
            this.inquiry.AutoSize = true;
            this.inquiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inquiry.Location = new System.Drawing.Point(30, 79);
            this.inquiry.Name = "inquiry";
            this.inquiry.Size = new System.Drawing.Size(95, 16);
            this.inquiry.TabIndex = 2;
            this.inquiry.Text = "Inquiry about a";
            // 
            // hdTab3
            // 
            this.hdTab3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hdTab3.BackgroundImage")));
            this.hdTab3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hdTab3.Controls.Add(this.refNum);
            this.hdTab3.Controls.Add(this.subm3);
            this.hdTab3.Controls.Add(this.aplSubCmb);
            this.hdTab3.Controls.Add(this.aplSubTyp);
            this.hdTab3.Controls.Add(this.applCmb);
            this.hdTab3.Controls.Add(this.applType);
            this.hdTab3.Location = new System.Drawing.Point(4, 29);
            this.hdTab3.Name = "hdTab3";
            this.hdTab3.Size = new System.Drawing.Size(757, 371);
            this.hdTab3.TabIndex = 2;
            this.hdTab3.Text = "Appeals";
            this.hdTab3.UseVisualStyleBackColor = true;
            // 
            // refNum
            // 
            this.refNum.AutoSize = true;
            this.refNum.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refNum.ForeColor = System.Drawing.Color.DarkRed;
            this.refNum.Location = new System.Drawing.Point(26, 293);
            this.refNum.Name = "refNum";
            this.refNum.Size = new System.Drawing.Size(194, 22);
            this.refNum.TabIndex = 9;
            this.refNum.Text = "Reference Number :";
            this.refNum.Visible = false;
            // 
            // subm3
            // 
            this.subm3.BackColor = System.Drawing.Color.Honeydew;
            this.subm3.ForeColor = System.Drawing.Color.Green;
            this.subm3.Location = new System.Drawing.Point(632, 226);
            this.subm3.Name = "subm3";
            this.subm3.Size = new System.Drawing.Size(102, 34);
            this.subm3.TabIndex = 8;
            this.subm3.Text = "Submit";
            this.subm3.UseVisualStyleBackColor = false;
            this.subm3.Visible = false;
            this.subm3.Click += new System.EventHandler(this.subm3_Click);
            // 
            // aplSubCmb
            // 
            this.aplSubCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aplSubCmb.DropDownWidth = 180;
            this.aplSubCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aplSubCmb.FormattingEnabled = true;
            this.aplSubCmb.Location = new System.Drawing.Point(186, 157);
            this.aplSubCmb.Name = "aplSubCmb";
            this.aplSubCmb.Size = new System.Drawing.Size(180, 24);
            this.aplSubCmb.TabIndex = 7;
            this.aplSubCmb.Visible = false;
            this.aplSubCmb.SelectedIndexChanged += new System.EventHandler(this.aplSubCmb_SelectedIndexChanged);
            // 
            // aplSubTyp
            // 
            this.aplSubTyp.AutoSize = true;
            this.aplSubTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aplSubTyp.Location = new System.Drawing.Point(30, 160);
            this.aplSubTyp.Name = "aplSubTyp";
            this.aplSubTyp.Size = new System.Drawing.Size(67, 16);
            this.aplSubTyp.TabIndex = 6;
            this.aplSubTyp.Text = "Sub Type";
            this.aplSubTyp.Visible = false;
            // 
            // applCmb
            // 
            this.applCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.applCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applCmb.FormattingEnabled = true;
            this.applCmb.Items.AddRange(new object[] {
            "Category change",
            "Supply Enlargement",
            "Edit contact details"});
            this.applCmb.Location = new System.Drawing.Point(186, 97);
            this.applCmb.Name = "applCmb";
            this.applCmb.Size = new System.Drawing.Size(180, 24);
            this.applCmb.TabIndex = 5;
            this.applCmb.SelectedIndexChanged += new System.EventHandler(this.applCmb_SelectedIndexChanged);
            // 
            // applType
            // 
            this.applType.AutoSize = true;
            this.applType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applType.Location = new System.Drawing.Point(30, 100);
            this.applType.Name = "applType";
            this.applType.Size = new System.Drawing.Size(87, 16);
            this.applType.TabIndex = 4;
            this.applType.Text = "Appeal Type";
            // 
            // hdTop
            // 
            this.hdTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hdTop.BackgroundImage")));
            this.hdTop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hdTop.Location = new System.Drawing.Point(8, 87);
            this.hdTop.Name = "hdTop";
            this.hdTop.Size = new System.Drawing.Size(768, 63);
            this.hdTop.TabIndex = 1;
            // 
            // accnt
            // 
            this.accnt.AutoSize = true;
            this.accnt.BackColor = System.Drawing.Color.Transparent;
            this.accnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accnt.ForeColor = System.Drawing.Color.DarkCyan;
            this.accnt.Location = new System.Drawing.Point(41, 213);
            this.accnt.Name = "accnt";
            this.accnt.Size = new System.Drawing.Size(142, 20);
            this.accnt.TabIndex = 3;
            this.accnt.Text = "Account Number";
            // 
            // accNumBx
            // 
            this.accNumBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accNumBx.Location = new System.Drawing.Point(201, 209);
            this.accNumBx.MaxLength = 7;
            this.accNumBx.Name = "accNumBx";
            this.accNumBx.Size = new System.Drawing.Size(113, 24);
            this.accNumBx.TabIndex = 4;
            this.accNumBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.accNumBx_KeyPress);
            // 
            // HelpDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.accNumBx);
            this.Controls.Add(this.accnt);
            this.Controls.Add(this.hdTop);
            this.Controls.Add(this.hdTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HelpDesk";
            this.Text = "Help Desk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.helpDesk_FormClosing);
            this.Load += new System.EventHandler(this.helpDesk_Load);
            this.hdTabs.ResumeLayout(false);
            this.hdTab1.ResumeLayout(false);
            this.hdTab1.PerformLayout();
            this.hdTab2.ResumeLayout(false);
            this.hdTab2.PerformLayout();
            this.details.ResumeLayout(false);
            this.details.PerformLayout();
            this.hdTab3.ResumeLayout(false);
            this.hdTab3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl hdTabs;
        private System.Windows.Forms.TabPage hdTab1;
        private System.Windows.Forms.TabPage hdTab2;
        private System.Windows.Forms.Panel hdTop;
        private System.Windows.Forms.TabPage hdTab3;
        private System.Windows.Forms.Label accnt;
        private System.Windows.Forms.TextBox accNumBx;
        private System.Windows.Forms.ComboBox maintypeCmb;
        private System.Windows.Forms.Label mainType;
        private System.Windows.Forms.ComboBox subtypeCmb;
        private System.Windows.Forms.Label subtype;
        private System.Windows.Forms.TextBox addInfoBx;
        private System.Windows.Forms.Label addInfo;
        private System.Windows.Forms.Button subm1;
        private System.Windows.Forms.Label refNo;
        private System.Windows.Forms.ComboBox inquiryCmb;
        private System.Windows.Forms.Label inquiry;
        private System.Windows.Forms.TextBox refNBx;
        private System.Windows.Forms.Label refN;
        private System.Windows.Forms.Button subm2;
        private System.Windows.Forms.GroupBox details;
        private System.Windows.Forms.TextBox detailbx;
        private System.Windows.Forms.ComboBox aplSubCmb;
        private System.Windows.Forms.Label aplSubTyp;
        private System.Windows.Forms.ComboBox applCmb;
        private System.Windows.Forms.Label applType;
        private System.Windows.Forms.Label refNum;
        private System.Windows.Forms.Button subm3;
    }
}

