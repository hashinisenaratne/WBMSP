using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Water_Board_Management;


namespace Water_Board_Management_WastageManagement
{
    public partial class FormWastage : Form
    {
        public static Form wastageform = null;

        Database dbmeter = new Database("meter", "month");
        Database dbcompl = new Database("complaint", "submmitedOn");
        int selectionMode = 0;
        Details detail;
        string search;

        public static Form Create()                          //implementation of singleton
        {
            if (wastageform == null)
            {
                return (wastageform = new FormWastage());
            }
            else
            {
                return wastageform;
            }
        }

        public FormWastage()
        {
            InitializeComponent();
            comboBoxMonths.SelectedIndex = 0;
            YearPicker1.Visible = false;
            comboBoxMonths.Visible = false;
            panel3.Visible = false;
            detail = new Details();
        }

        private void radioButtonMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMonth.Checked)
            {
                selectionMode = 0;
                YearPicker1.Visible = true;
                comboBoxMonths.Visible = true;
                label2.Visible = true;
            }
        }

        private void radioButtonYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonYear.Checked)
            {
                selectionMode = 1;
                YearPicker1.Visible = true;
                comboBoxMonths.Visible = false;
                label2.Visible = false;
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            panel3.Visible = true;
            
            if (selectionMode == 0)
                search = comboBoxMonths.SelectedItem.ToString() + "/" + YearPicker1.Value.Year;
            else
                search = (YearPicker1.Value.Year).ToString();
            calcute(search, selectionMode);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Enabled = true;
            textBoxNRW.Text = textBoxReleased.Text = textBoxUsage.Text = "";

        }

        private void calcute(string month, int mode)
        {
            if (selectionMode == 0)
            {
                if (!dbmeter.hasEntry(month))
                {
                    MessageBox.Show("Data has not been entered for this duration", "Sorry, Cannot provide Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panel3.Visible = false;
                    panel2.Enabled = true;
                }
                else
                {
                    string[] data = dbmeter.getRow(month);
                    if ((int.Parse(data[1]) - int.Parse(data[2])) < 0)
                    {
                        MessageBox.Show("Data has not been entered completely for this duration", "Sorry, Can only provide limited Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxUsage.Text = data[2];
                        detail.setdata("Detailed Wastage Report", "For the Duration: " + month, "Remarks: Data has not entered completely for this duration", "Complaints regarding water wastage (Illegal Connections)",
                            "Usage Amount for the selected duration", "Released units for the duration",
                            "Non Revenue Water in units for the duration", data[2], "-", "-");
                    }
                    else
                    {
                        textBoxUsage.Text = data[2];
                        textBoxReleased.Text = data[1];
                        textBoxNRW.Text = (int.Parse(data[1]) - int.Parse(data[2])).ToString();
                        detail.setdata("Detailed Wastage Report", "For the Duration: " + month, "", "Complaints regarding water wastage (Illegal Connections)",
                            "Usage Amount for the selected duration", "Released units for the duration",
                            "Non Revenue Water in units for the duration", data[2], data[1],
                            ((int.Parse(data[1]) - int.Parse(data[2])).ToString()));
                    }
                }
            }
            else
            {
                if (!dbmeter.hasEntry("January" + "/" + month))
                {
                    MessageBox.Show("Data has not entered for this duration", "Sorry, Cannot provide Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panel3.Visible = false;
                    panel2.Enabled = true;
                }
                else
                {
                    string[] databulk = dbmeter.getlike("bulk", month);
                    string[] datausag = dbmeter.getlike("usag", month);
                    int sumbulk = 0;
                    int sumusag = 0;

                    for (int i = 0; i < databulk.Length; i++)
                    {
                        sumbulk += int.Parse(databulk[i]);
                    }
                    for (int i = 0; i < datausag.Length; i++)
                    {
                        sumusag += int.Parse(datausag[i]);
                    }



                    if ((sumbulk - sumusag) < 0)
                    {
                        MessageBox.Show("Data has not entered completely for this duration", "Sorry, Can only provide limited Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxUsage.Text = sumusag.ToString();
                        detail.setdata("Detailed Wastage Report", "For the Duration: " + month, "Remarks: Data has not entered completely for this duration", "Complaints regarding water wastage (Illegal Connections)",
                            "Usage Amount for the selected duration", "Released units for the duration",
                            "Non Revenue Water in units for the duration", sumusag.ToString(), "-", "-");
                    }
                    else
                    {
                        textBoxUsage.Text = sumusag.ToString();
                        textBoxReleased.Text = sumbulk.ToString();
                        textBoxNRW.Text = (sumbulk - sumusag).ToString();
                        detail.setdata("Detailed Wastage Report", "For the Duration: " + month, "", "Complaints regarding water wastage (Illegal Connections)",
                            "Usage Amount for the selected duration", "Released units for the duration",
                            "Non Revenue Water in units for the duration", sumusag.ToString(), sumbulk.ToString(),
                            (sumbulk - sumusag).ToString());
                    }
                }
            }
        }



        private void buttonReport_Click(object sender, EventArgs e)
        {
            //
            buttonClose.Visible=true;
            bindingSource1.Add(detail);
            reportViewer1.Visible = true;
        }

        private void FormWastage_FormClosing(object sender, FormClosingEventArgs e)
        {
            wastageform = null;
        }

        private void FormWastage_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            reportViewer1.Visible = false;

        }

    }

    public class Details{
        public string title;
        public string duration;
        public string subtitle1;
        public string subtitle2;
        public string field1;
        public string field2;
        public string field3;
        public string data1;
        public string data2;
        public string data3;
        public string[] complaints;
        public string[] accono;
        public void setdata(string tile,string duration,string subtitle1,string subtitle2,string field1,string field2,string field3,string data1,string data2,string data3)
        {
            this.title=tile;this.duration=duration;this.subtitle1=subtitle1;
            this.subtitle2 = subtitle2;
            this.field1 = field1;
            this.field2 = field2;
            this.field3 = field3;
            this.data1 = data1;
            this.data2 = data2;
            this.data3 = data3;
        }
        public string rtitle
        {
            get
            {
                return title;
            }
        }
        public string rtduration
        {
            get
            {
                return duration;
            }
        }
        public string rsubtitle1
        {
            get
            {
                return subtitle1;
            }
        }
        public string rsubtitle2
        {
            get
            {
                return subtitle2;
            }
        }
        public string rfield1
        {
            get
            {
                return field1;
            }
        }
        public string rfield2
        {
            get
            {
                return field2;
            }
        }
        public string rfield3
        {
            get
            {
                return field3;
            }
        }
        public string rdata1
        {
            get
            {
                return data1;
            }
        }
        public string rdata2
        {
            get
            {
                return data2;
            }
        }
        public string rdata3
        {
            get
            {
                return data3;
            }
        }
        public string[] rcomplaints
        {
            get
            {
                return complaints;
            }
        }
        public string[] raccono
        {
            get
            {
                return accono;
            }
        }
    }
}
