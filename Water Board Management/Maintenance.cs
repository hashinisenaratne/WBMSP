using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Water_Board_Management_Maintenance
{
    public partial class Maintenance : Form
    {
        private String[] compRefs;
        private String[] applRefs;
        
        private Water_Board_Management.Database db1;
        private Water_Board_Management.Database db2;

        private Water_Board_Management_HelpDesk.Complaint[] cmpls;
        private Water_Board_Management_HelpDesk.Appeal[] appls;

        private int noComplaints;
        private int noAppeals;

        private Water_Board_Management_HelpDesk.Converter conv;
        private bool isComplaint;
        private bool[] updatedComp;
        private bool[] updatedAppl;
        private bool updated;

        public static Maintenance mnt=null;
        

        public Maintenance()
        {
            InitializeComponent();
            db1=new Water_Board_Management.Database("complaint","referenceNo");
            db2 = new Water_Board_Management.Database("appeal", "referenceNo");
            compRefs = db1.getColumn("referenceNo");
            applRefs = db2.getColumn("referenceNo");         
            conv = new Water_Board_Management_HelpDesk.Converter();
            isComplaint = false;
            updated = true;

            loadDetails();
        }

        public Maintenance(int authlevel)
        {
            if (authlevel != 1)
            {
                InitializeComponent();
                db1 = new Water_Board_Management.Database("complaint", "referenceNo");
                db2 = new Water_Board_Management.Database("appeal", "referenceNo");
                compRefs = db1.getColumn("referenceNo");
                applRefs = db2.getColumn("referenceNo");
                conv = new Water_Board_Management_HelpDesk.Converter();
                isComplaint = false;
                updated = true;

                loadDetails();
            }           
        }

        public static Maintenance Create(int id)
        {
            if (id == 1)
                return null;
            else
            {
                if (mnt == null)
                {
                    mnt = new Maintenance(id);
                }
                return mnt;
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void loadDetails()
        {
            cmpls = new Water_Board_Management_HelpDesk.Complaint[1000];
            appls = new Water_Board_Management_HelpDesk.Appeal[1000];
            noAppeals = noComplaints = 0;
            for (int i = 0; i < compRefs.Length; i++)
            {
                if ((db1.get("completed", compRefs[i]).Equals("False")) && (!db1.get("complainType", compRefs[i]).Equals("Illegal Connections")))
                {
                    cmpls[noComplaints] = conv.retComplaint(db1, compRefs[i]);
                    noComplaints++;
                }
            }
            updatedComp = new bool[noComplaints];
            for (int i = 0; i < applRefs.Length; i++)
            {
                if (db2.get("completed", applRefs[i]).Equals("False"))
                {
                    appls[noAppeals] = conv.retAppeal(db2, applRefs[i]);
                    noAppeals++;
                }
            }
            updatedAppl = new bool[noAppeals];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pending_button_Click(object sender, EventArgs e)
        {
            showComplaints();
        }        

        private void Setprogress_button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Set Progress";
            textBox2.Clear();
            textBox2.Visible = true;
            comboBox1.Visible = false;
            panel2.Visible = true;
        }
      
        private void Apeal_button_Click(object sender, EventArgs e)
        {
            showAppeals();
        }

        private void showComplaints()
        {
            button3.Visible = button5.Visible = button8.Visible = false;
            textBox1.Clear();
            panel2.Visible = false;
            String[] s = new String[noComplaints];
            for (int i = 0; i < noComplaints; i++)
            {
                s[i] = cmpls[i].getReference() + "\tPriority: " + cmpls[i].getPriority() + "\t\t" + cmpls[i].getType();
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(s);
            isComplaint = true;
        }

        private void showAppeals()
        {
            button3.Visible = button5.Visible = button8.Visible = false;
            panel2.Visible = false;
            String[] s = new String[noAppeals];
            for (int i = 0; i < noAppeals; i++)
            {
                s[i] = appls[i].getReference() + "\t" + appls[i].getType();
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(s);
            isComplaint = false;
            textBox1.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isComplaint)
                {
                    Water_Board_Management_HelpDesk.Complaint temp = cmpls[listBox1.SelectedIndex];
                    textBox1.Text = displayComplaint(temp);
                    button3.Visible = true;
                    button5.Visible = true;
                    button8.Visible = true;
                }
                else
                {
                    Water_Board_Management_HelpDesk.Appeal temp = appls[listBox1.SelectedIndex];
                    textBox1.Text = displayAppeal(temp);
                    button3.Visible = true;
                    button5.Visible = false;
                    button8.Visible = true;
                }
            }
            catch (IndexOutOfRangeException ee)
            {
            }

        }

        private String displayComplaint(Water_Board_Management_HelpDesk.Complaint c)
        {
            String r = "Reference no: " + c.getReference();
            r += Environment.NewLine + "Account no: " + c.getAccount();
            r += Environment.NewLine+"Type: " + c.getType();
            r += Environment.NewLine + "Sub Type: " + c.getSub();
            r += Environment.NewLine + "Details: " + c.getAdd();
            r += Environment.NewLine + "Submission Date: " + c.getSubmit();
            r += Environment.NewLine + "Progress: " + c.getProgress();
            r += Environment.NewLine + "Priority: " + c.getPriority();
            r += Environment.NewLine + "Completed? " + c.isCompleted();

            return r;
        }

        private String displayAppeal(Water_Board_Management_HelpDesk.Appeal a)
        {
            String r = "Reference no: " + a.getReference();
            r += Environment.NewLine + "Account no: " + a.getAccount();
            r += Environment.NewLine + "Type: " + a.getType();
            r += Environment.NewLine + "Sub Type: " + a.getSub();
            r += Environment.NewLine + "Validated: " + a.isValidated();
            r += Environment.NewLine + "Submission Date: " + a.getSubmit();
            r += Environment.NewLine + "Progress: " + a.getProgress();
            r += Environment.NewLine + "Completed? " + a.isCompleted();

            return r;
        }

        private void setpriority_button_click(object sender, EventArgs e)
        {
            label1.Text = "Set Priority";
            textBox2.Visible = false;
            comboBox1.Visible = true;            
            panel2.Visible = true;
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (isComplaint)
            {
                if (label1.Text.Equals("Set Progress"))
                {
                    cmpls[listBox1.SelectedIndex].setProgress(textBox2.Text);                    
                }
                else
                {
                    cmpls[listBox1.SelectedIndex].setPriority(Int32.Parse(comboBox1.SelectedItem.ToString()));
                }
                updatedComp[listBox1.SelectedIndex] = true;
                showComplaints();
            }
            else
            {
                appls[listBox1.SelectedIndex].setProgress(textBox2.Text);
                updatedAppl[listBox1.SelectedIndex] = true;
                showAppeals();
            }
            panel2.Visible = false;
            updated = false;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            panel2.Visible = false;
        }

        private void Completed_button_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr=MessageBox.Show("Do you really want to mark this job as completed? Once marked it cannot be undone.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr.ToString().Equals("Yes"))
            {
                if (isComplaint)
                {
                    cmpls[listBox1.SelectedIndex].complete();
                    updatedComp[listBox1.SelectedIndex] = true;
                    showComplaints();
                }
                else
                {
                    appls[listBox1.SelectedIndex].complete();
                    updatedAppl[listBox1.SelectedIndex] = true;
                    showAppeals();
                }
                updated = false;
            }            
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Do you want to update the database now?", "Update Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr.ToString().Equals("Yes"))
            {                
                for (int i = 0; i < noComplaints; i++)
                {
                    if (updatedComp[i])
                    {
                        db1.delete(cmpls[i].getReference().ToString());
                        conv.storeComplaint(db1, cmpls[i]);
                    }
                }
                for (int i = 0; i < noAppeals; i++)
                {
                    if (updatedAppl[i])
                    {
                        db2.delete(appls[i].getReference().ToString());
                        conv.storeAppeal(db2, appls[i]);
                    }
                }
                listBox1.Items.Clear();
                textBox1.Clear();
                loadDetails();
                updated = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!updated)
            {
                if (DialogResult.No == MessageBox.Show("You haven't updated the changes you made to the database. If you exit now they will be lost.\nDo you still want to exit?", "Database not Updated", MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
                    e.Cancel = true;
                else
                    mnt = null;
            }
            else
                mnt = null;
        }
    }
}
