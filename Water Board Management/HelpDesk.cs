using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Water_Board_Management_HelpDesk
{
    public partial class HelpDesk : Form
    {
        private bool isCustomer;        
        private int accountNo;
        private Converter cdb;
        private Water_Board_Management.Database db;		//complaint database
        private Water_Board_Management.Database db2;	//appeal database
        private Water_Board_Management.Database db3;	//account database with accountNo as key
        private Water_Board_Management.Database db4;    //account database with referenceNo as key
        private Water_Board_Management.Database db5;    //inProgress database

        private static HelpDesk singleton=null;

        public static HelpDesk Create(int authlevel, String acc)
        {
            int accNo;
            if (singleton == null)
                if (int.TryParse(acc, out accNo))
                {
                    singleton = new HelpDesk(authlevel, accNo);
                }
                else
                {
                    singleton = new HelpDesk(authlevel,0);
                }
            return singleton;
        }
        
        
        public HelpDesk()
        {
            InitializeComponent();            
            accountNo = 1258489;
            isCustomer = true;
            //isCustomer = false;
            cdb = new Converter();

            db = new Water_Board_Management.Database("complaint", "referenceNo");
            db2 = new Water_Board_Management.Database("appeal", "referenceNo");
            db3 = new Water_Board_Management.Database("account", "accountNo");
            db4 = new Water_Board_Management.Database("account", "refno");
            db5=new Water_Board_Management.Database("inprogress","refno");
        }
                
        public HelpDesk(int id, int acctNo)
        {
            InitializeComponent();
            accountNo = acctNo;
            if (id == 1)
                isCustomer = true;
            else
                isCustomer = false;

            cdb = new Converter();
            
            db = new Water_Board_Management.Database("complaint", "referenceNo");
            db2 = new Water_Board_Management.Database("appeal", "referenceNo");
            db3 = new Water_Board_Management.Database("account", "accountNo");
            db4 = new Water_Board_Management.Database("account", "refno");
            db5 = new Water_Board_Management.Database("inprogress", "refNo");
        }

        private void helpDesk_Load(object sender, EventArgs e)
        {
            if (isCustomer)
            {
                accNumBx.Text = accountNo.ToString();                
                accNumBx.ReadOnly = true;
            }
        }

        //Prevents user from entering non-numeric characters as the account number
		private void accNumBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if(!(e.KeyChar == '\b'))
                    e.Handled = true;
            }
        }        

        private void makeVisible1()
        {
            subtype.Visible = true;
            subtypeCmb.Visible = true;
            addInfo.Top = 211;
            addInfo.Visible = true;
            addInfoBx.Top = 211;
            addInfoBx.Visible = true;
            subtypeCmb.DropDownWidth = 180;
            subm1.Visible = false;
            refNo.Visible = false;
            addInfoBx.Clear();
        }

        private void maintypeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (maintypeCmb.SelectedIndex == 0)
            {
                subtypeCmb.Items.Clear();
                subtype.Text = "Leakage Type";
                subtypeCmb.Items.AddRange(new String[] { "Leak of a transmission line", "Leak of a supply line", "Leak of a sock valve", "Leak near the meter" });
                subtypeCmb.Text = "Select leakage type";
                addInfo.Text = "Leakage Location \n(compulsory)";
                makeVisible1();
            }
            else if (maintypeCmb.SelectedIndex == 1)
            {
                subtype.Text = "Defect Type";
                subtypeCmb.Items.Clear();
                subtypeCmb.Items.AddRange(new String[] {"Meter damage","Meter racing","Stolen meter"});
                subtypeCmb.Text = "Select defect type";
                addInfo.Text = "Additional Information";
                makeVisible1();
            }
            else if (maintypeCmb.SelectedIndex == 2)
            {
                subtype.Text = "Reason for Suspicion";
                subtypeCmb.Items.Clear();                
                subtypeCmb.Items.AddRange(new String[] { "Bill amount is much higher than usual", "Bill does not comply with the usage","Other" });
                subtypeCmb.Text = "Select a reason";
                addInfo.Text = "Additional Information";
                makeVisible1();
                subtypeCmb.DropDownWidth = 370;
            }
            if (maintypeCmb.SelectedIndex == 3)
            {
                addInfo.Text = "Information\n(compulsory)";
                makeVisible1();                
                subtype.Visible = false;
                subtypeCmb.Visible = false;
                subm1.Visible = true;
                addInfoBx.Top = 155;
                addInfo.Top = 158;
            }
        }

        private void subtypeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subtypeCmb.SelectedIndex >= 0)
                subm1.Visible = true;
            refNo.Visible = false;
            addInfoBx.Clear();
        }

        private void subm1_Click(object sender, EventArgs e)
        {
            int tp;
            if (String.IsNullOrWhiteSpace(accNumBx.Text))
            {
                MessageBox.Show("Please enter the account number", "No account number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((!(int.TryParse(accNumBx.Text, out tp))) || (accNumBx.Text.Contains(".")) || (accNumBx.Text.Length < 7)||(!db3.hasEntry(accNumBx.Text)))
            {
                MessageBox.Show("Please enter a valid account number", "Invalid account number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if ((maintypeCmb.SelectedIndex == 0) && (String.IsNullOrWhiteSpace(addInfoBx.Text)))
            {
                MessageBox.Show("Please specify the leakage location", "Info Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((maintypeCmb.SelectedIndex == 3) && (String.IsNullOrWhiteSpace(addInfoBx.Text)))
            {
                MessageBox.Show("Please enter more information", "Info Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((maintypeCmb.SelectedIndex == 2) && (subtypeCmb.SelectedIndex == 2) && (String.IsNullOrWhiteSpace(addInfoBx.Text)))
            {
                MessageBox.Show("Please specify a reason for suspicion", "Info Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int r = genRefNo(0);
                refNo.Text = "Reference Number : ";
                for (int i = 1; i <= (5 - r.ToString().Length); i++)
                {
                    refNo.Text += "0";
                }
                refNo.Text += r;
                refNo.Visible = true;

                Complaint temp;
                String day = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString();

                if (maintypeCmb.SelectedIndex == 3)
                {
                    temp = new Complaint(r, Int32.Parse(accNumBx.Text), maintypeCmb.SelectedItem.ToString(), "", addInfoBx.Text, day);                    
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(addInfoBx.Text))
                    {
                        temp = new Complaint(r, Int32.Parse(accNumBx.Text), maintypeCmb.SelectedItem.ToString(), subtypeCmb.SelectedItem.ToString(), day);                    
                    }
                    else
                    {
                        temp = new Complaint(r, Int32.Parse(accNumBx.Text), maintypeCmb.SelectedItem.ToString(), subtypeCmb.SelectedItem.ToString(), addInfoBx.Text, day);                    
                    }
                }                               
                cdb.storeComplaint(db, temp);
            }
        }

        //Generates a reference number for new complaint or new appeal (n=0 for complaint, 1 for appeal)
		private int genRefNo(int n)    
        {
            int r;
            Random rn=new Random();
            r=rn.Next(0,100000);
            Water_Board_Management.Database tempD=db;

            if (n == 0)
                tempD = db;
            else if (n == 1)
                tempD = db2;

            while (tempD.hasEntry(r.ToString()))
            {
                r = rn.Next(0, 100000);
            }            
            
            return r;
        }

		 //Prevents user from entering non-numeric characters as the reference number
        private void refNBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (!(e.KeyChar == '\b'))
                    e.Handled = true;
            }
        }

        private void inquiryCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            details.Visible = false;
            if ((inquiryCmb.SelectedIndex == 0) || (inquiryCmb.SelectedIndex == 1))
            {
                refN.Visible = true;
                refNBx.Clear();
                refNBx.Visible = true;
                subm2.Visible = true;
            }
            else if (inquiryCmb.SelectedIndex == 2)
            {
                refN.Visible = true;
                refNBx.Clear();
                refNBx.Visible = true;
                subm2.Visible = true;
            }
        }

        private void subm2_Click(object sender, EventArgs e)
        {
            int n;
            if (String.IsNullOrWhiteSpace(refNBx.Text))
			{
                MessageBox.Show("Please enter the reference number", "No reference number", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
            else if ((!(int.TryParse(refNBx.Text,out n)))||(refNBx.Text.Contains("."))||(refNBx.Text.Length<5))
			{
                MessageBox.Show("Please enter a valid reference number", "Invalid reference number", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
            else
            {
                String[] t=null;

                if (inquiryCmb.SelectedIndex == 0)
                {
                    //gets complaint object from the database
                    t = printComplaint(refNBx.Text);
                }
                else if (inquiryCmb.SelectedIndex == 1)
                {
                    //gets appeal object from the database
                    t = printAppeal(refNBx.Text);
                }
                else if (inquiryCmb.SelectedIndex == 2)
                {
                    t = printAccount(refNBx.Text);
                }
                
                detailbx.Clear();
                for (int i = 0; i < t.Length; i++)
                {
                    detailbx.Text += (t[i] + Environment.NewLine);

                }                
                details.Visible = true;
            }
        }

        private void makeVisible2()
        {
            aplSubTyp.Visible = true;
            aplSubCmb.Visible = true;     
            subm3.Visible = false;
            refNum.Visible = false;            
        }

        private void applCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (applCmb.SelectedIndex == 0)
            {
                aplSubCmb.Items.Clear();
                aplSubTyp.Text = "Change Type";
                aplSubCmb.Items.AddRange(new String[] { "from Domestic to Industrial", "from Industrial to Domestic"});
                aplSubCmb.Text = "Select change";                
                makeVisible2();
            }
            else if (applCmb.SelectedIndex == 1)
            {
                aplSubTyp.Text = "Enlargement Type";
                aplSubCmb.Items.Clear();
                aplSubCmb.Items.AddRange(new String[] { "Type 1", "Type 2", "Type 3" });
                aplSubCmb.Text = "Select enlargement type";                
                makeVisible2();
            }
            else if (applCmb.SelectedIndex == 2)
            {
                aplSubCmb.Visible = false;
                aplSubTyp.Visible = false;
                subm3.Visible = false;
                refNum.Visible = false;
                
                Contact ct;
                if (isCustomer)
                    ct = Contact.createContact(accountNo);
                else
                    ct = Contact.createContact();
                               
                ct.Visible = true;
            }
        }

        private void aplSubCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aplSubCmb.SelectedIndex >= 0)
                subm3.Visible = true;
            refNum.Visible = false;
        
        }

        private void subm3_Click(object sender, EventArgs e)
        {
            String day = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString();
            
            int r = genRefNo(1);
            refNum.Text = "Reference Number : ";
            for (int i = 1; i <= (5 - r.ToString().Length); i++)	//apends 0 to the front of the generated reference number to
            {														//make its length exactly 5
                refNum.Text += "0";
            }
            refNum.Text += r;
            refNum.Visible = true;            

            Appeal temp = new Appeal(r, Int32.Parse(accNumBx.Text),applCmb.SelectedItem.ToString(),aplSubCmb.SelectedItem.ToString(),day);
            cdb.storeAppeal(db2, temp);
            
        }

        //Takes the details of a complaint object into a string array for display purposes
		private String[] printComplaint(String rn)
        {
            Complaint temp = cdb.retComplaint(db, rn);
            if (temp == null)
                return (new String[] { "Complaint not found!","Please check whether the entered reference number is correct." });
            
            String[] r = new String[5];

            r[0] = "Complaint : " + temp.getType() + " - " + temp.getSub();
            r[1] = "Reference Number : " + temp.getReference();
            r[2] = "Submitted on : " + temp.getSubmit();
            r[3] = "Info  : " + temp.getAdd();

            if (temp.isCompleted())
                r[4] = "Completed on : " + temp.getComplete();
            else
                r[4] = "Progress : " +temp.getProgress();
            return r;
        }

		//Takes the details of an appeal object into a string array for display purposes
        private String[] printAppeal(String rn)
        {
            Appeal temp = cdb.retAppeal(db2, rn);
            if (temp == null)
                return (new String[] { "Appeal not found!", "Please check whether the entered reference number is correct." });

            String[] r = new String[6];

            r[0] = "Appeal : " + temp.getType() + " - " + temp.getSub();
            r[1] = "Reference Number : " + temp.getReference();
            r[2] = "Submitted on : " + temp.getSubmit();

            if (temp.isValidated())
                r[3] = "Validated: Yes";
            else
                r[3] = "Validated: No";            
            
            if (temp.isCompleted())
                r[4] = "Completed on : " + temp.getComplete();
            else
                r[4] = "Progress : " + temp.getProgress();

            if (String.IsNullOrWhiteSpace(temp.getAdd()))
                r[5] = "";
            else
                r[5] = "Additional details: " + temp.getAdd();

            return r;
        }

        private String[] printAccount(String rn)
        {
            String[] r=new String[8];
            
            if ((!db5.hasEntry(rn))&&(!db4.hasEntry(rn)))
                r=new String[] { "Record not found!", "Please check whether the entered reference number is correct." };
                        
            else if (db4.hasEntry(rn))
            {
                String[] det=db4.getRow(rn);
                
                r[0] = "Congratulations! Your account has been successfully created.";
                r[1] = "Client: " + det[1] + " " + det[2];
                r[2] = "Account No: " + det[0];
                r[3] = "Category: " + det[4];
                r[4] = "Address: " + det[5];
                r[5]="Phone: "+det[11];
                r[6] = "Email: " + det[10];
                r[7] = "";
            }

            else if (db5.hasEntry(rn))
            {
                String[] det = db5.getRow(rn);

                r[0] = "Creation of your account is in progress.";
                r[1] = "Client: " + det[0] + " " + det[1];                
                r[2] = "Category: " + det[3];
                r[3] = "Address: " + det[4];
                r[4] = "Phone: " + det[10];
                r[5]="Email: " + det[9];
                if(det[12].Equals("True"))
                    r[6] = "Documents Submitted? Yes ";
                else if(det[12].Equals("False"))
                    r[6]="Documents Submitted? No ";
                r[7]="Progress: "+det[18];
            }           

            return r;
        }

        private void hdTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hdTabs.SelectedIndex == 1)
            {
                accnt.Visible = false;
                accNumBx.Visible = false;
            }
            else if((!accnt.Visible)||(!accNumBx.Visible))
            {
                accnt.Visible = true;
                accNumBx.Visible = true;
            }
        }

        private void helpDesk_FormClosing(object sender, FormClosingEventArgs e)
        {
            singleton = null;
        }
    }
}
