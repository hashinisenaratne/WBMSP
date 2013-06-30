namespace Water_Board_Management_WastageManagement
{
    partial class FormWastage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWastage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxReleased = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonReport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNRW = new System.Windows.Forms.TextBox();
            this.textBoxUsage = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.comboBoxMonths = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.YearPicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonYear = new System.Windows.Forms.RadioButton();
            this.buttonClose = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 403);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxReleased);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.buttonReset);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.buttonReport);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.textBoxNRW);
            this.panel3.Controls.Add(this.textBoxUsage);
            this.panel3.Location = new System.Drawing.Point(37, 219);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(698, 176);
            this.panel3.TabIndex = 18;
            // 
            // textBoxReleased
            // 
            this.textBoxReleased.Location = new System.Drawing.Point(358, 47);
            this.textBoxReleased.Name = "textBoxReleased";
            this.textBoxReleased.ReadOnly = true;
            this.textBoxReleased.Size = new System.Drawing.Size(150, 20);
            this.textBoxReleased.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Usage Amount for the selected duration";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(41, 139);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 15;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Released units for the duration";
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(508, 139);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(121, 28);
            this.buttonReport.TabIndex = 14;
            this.buttonReport.Text = "Detailed Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Non Revenue Water in units for the duration";
            // 
            // textBoxNRW
            // 
            this.textBoxNRW.Location = new System.Drawing.Point(358, 74);
            this.textBoxNRW.Name = "textBoxNRW";
            this.textBoxNRW.ReadOnly = true;
            this.textBoxNRW.Size = new System.Drawing.Size(150, 20);
            this.textBoxNRW.TabIndex = 13;
            // 
            // textBoxUsage
            // 
            this.textBoxUsage.Location = new System.Drawing.Point(358, 19);
            this.textBoxUsage.Name = "textBoxUsage";
            this.textBoxUsage.ReadOnly = true;
            this.textBoxUsage.Size = new System.Drawing.Size(150, 20);
            this.textBoxUsage.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonGo);
            this.panel2.Controls.Add(this.comboBoxMonths);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.YearPicker1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.radioButtonMonth);
            this.panel2.Controls.Add(this.radioButtonYear);
            this.panel2.Location = new System.Drawing.Point(43, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 199);
            this.panel2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Pick a Month or a Year for Calculate Non-Revenue-Water";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(503, 167);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(121, 26);
            this.buttonGo.TabIndex = 16;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // comboBoxMonths
            // 
            this.comboBoxMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonths.FormattingEnabled = true;
            this.comboBoxMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxMonths.Location = new System.Drawing.Point(503, 90);
            this.comboBoxMonths.Name = "comboBoxMonths";
            this.comboBoxMonths.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMonths.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(407, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Month";
            // 
            // YearPicker1
            // 
            this.YearPicker1.CustomFormat = "yyyy";
            this.YearPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.YearPicker1.Location = new System.Drawing.Point(503, 122);
            this.YearPicker1.Name = "YearPicker1";
            this.YearPicker1.ShowUpDown = true;
            this.YearPicker1.Size = new System.Drawing.Size(121, 20);
            this.YearPicker1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Year";
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMonth.Location = new System.Drawing.Point(36, 92);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(204, 21);
            this.radioButtonMonth.TabIndex = 7;
            this.radioButtonMonth.TabStop = true;
            this.radioButtonMonth.Text = "Check Summary for a month";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            this.radioButtonMonth.CheckedChanged += new System.EventHandler(this.radioButtonMonth_CheckedChanged);
            // 
            // radioButtonYear
            // 
            this.radioButtonYear.AutoSize = true;
            this.radioButtonYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonYear.Location = new System.Drawing.Point(36, 119);
            this.radioButtonYear.Name = "radioButtonYear";
            this.radioButtonYear.Size = new System.Drawing.Size(193, 21);
            this.radioButtonYear.TabIndex = 8;
            this.radioButtonYear.TabStop = true;
            this.radioButtonYear.Text = "Check Summary for a year";
            this.radioButtonYear.UseVisualStyleBackColor = true;
            this.radioButtonYear.CheckedChanged += new System.EventHandler(this.radioButtonYear_CheckedChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(644, 102);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(110, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close Report";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(28, 139);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(725, 400);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.Visible = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Water_Board_Management_WastageManagement.Details);
            // 
            // FormWastage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.panel1);
            this.Name = "FormWastage";
            this.Text = "Wastage Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWastage_FormClosing);
            this.Load += new System.EventHandler(this.FormWastage_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker YearPicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMonths;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonYear;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.TextBox textBoxNRW;
        private System.Windows.Forms.TextBox textBoxReleased;
        private System.Windows.Forms.TextBox textBoxUsage;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonClose;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}