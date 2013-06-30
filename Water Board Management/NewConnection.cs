using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;
using Water_Board_Management;

namespace Water_Board_Management_NewConnections
{
    public partial class FormNewConnection : Form                               //new connection handling form
    {
        public static Form newconnform = null;

        int listboxindex = 0;                                       //object used to handle form details
        ApplicationForm appToAccept1;
        ApplicationForm appToProgress;

        Database dbapp = new Database("application", "refno");      //Database accessing objects
        Database dbapp1 = new Database("application", "refno");
        Database dbmap = new Database("mapno", "category");
        Database dbprog = new Database("inprogress", "refno");
        Database dbmail = new Database("mail", "no");
        Database dbacc = new Database("account", "accountNo");
        Database dbbill = new Database("account", "year");
        Database dblogin = new Database("login", "username");

        public FormNewConnection(int level)                                                          //initialization
        {
            appToAccept1 = new BusinessApplicationForm(null, null, null, null, null, null, null, null, null, null, 0,
                null, false, false, null, null, null, null, 0);
            appToProgress = new BusinessApplicationForm(null, null, null, null, null, null, null, null, null, null, 0,
                null, false, false, null, null, null, null, 0);
            InitializeComponent();
            comboTitle.SelectedIndex = 0;
            comboBoxApplicantType.SelectedIndex = 0;
            comboBoxPreviousCategory.SelectedIndex = 0;
            comboCategory.SelectedIndex = 0;
            if (level == 1)
            {
                tabControlNewConnection.TabPages.Remove(tabPageWaiting);
                tabControlNewConnection.TabPages.Remove(tabPagePeogress);
                //tabControlNewConnection.ItemSize.= 767;
            }
            if (level == 2)
            {
                buttonRejectA.Visible = buttonRejectG.Visible = buttonCertifyA.Visible=buttonCertifyG.Visible=
                    label19.Visible=label20.Visible=buttonNextProgress.Visible= false;
            }
            if (level == 3)
            {
                buttonRejectA.Visible = buttonRejectG.Visible = buttonEditWaiting.Visible = buttonWaitingSubmit.Visible
                    = buttonProgressEdit.Visible = buttonProgressSubmit.Visible = buttonNextProgress.Visible = false;
            }
            if(level==4)
            {
                tabControlNewConnection.TabPages.Remove(tabPageApplication);
            }
        }

        public static Form Create(int level)                          //implementation of singleton
        {
            if (newconnform == null)
            {
                return (newconnform = new FormNewConnection(level));
            }
            else
            {
                return newconnform;
            }
        }


        private void FormNewConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            newconnform = null;
        }


        /**************tab1 to input application***********************/

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {//set visibility of components when category changed
            if (comboCategory.SelectedIndex == 0)
            {
                label14.Visible = false;
                label15.Visible = false;
                textBox1Company.Visible = false;
                textBoxPost.Visible = false;
            }
            if (comboCategory.SelectedIndex == 1)
            {
                label14.Visible = true;
                label15.Visible = true;
                textBox1Company.Visible = true;
                textBoxPost.Visible = true;
            }
        }

        private void checkBoxPreviousConnection_CheckedChanged(object sender, EventArgs e)
        {//set visibility of components if had an previous account
            if (checkBoxPreviousConnection.Checked)
            {
                label11.Enabled = true;
                label12.Enabled = true;
                textBoxPreviousAccountNo.Enabled = true;
                comboBoxPreviousCategory.Enabled = true;
            }
            if (checkBoxPreviousConnection.Checked == false)
            {
                label11.Enabled = false;
                label12.Enabled = false;
                textBoxPreviousAccountNo.Enabled = false;
                comboBoxPreviousCategory.Enabled = false;
            }
        }

        private void buttonSubmitApplication_Click(object sender, EventArgs e)//submit button tab1 click
        {
            bool containsLetter = false;                      //phone no validating
            string phoneNumber = textBoxContact.Text.Trim();
            if (phoneNumber.Length < 10)
                containsLetter = true;
            else
            {
                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    if (!char.IsNumber(phoneNumber[i]))
                    {
                        containsLetter = true;
                    }
                }
            }
            if (containsLetter)
            {
                MessageBox.Show("Please enter all the data before submission and make sure contact no and NIC no is valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool nicwrong = false;                              //nic validating
            string nic = textBoxNIC.Text;
            if (nic.Length < 10)
                nicwrong = true;
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    if (!char.IsNumber(nic[i]))
                    {
                        nicwrong = true;
                    }
                }
                if (nic[9] != 'V' && nic[9] != 'v')
                    nicwrong = true;
            }
            if (nicwrong)
            {
                MessageBox.Show("Please enter all the data before submission and make sure NIC no is in correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (valid())                                        //validating of required fields filled
            {
                ApplicationRow approw;
                int refno;
                if (dbmap.hasEntry("reference"))
                {
                    refno = int.Parse(dbmap.get("no", "reference"));//get a reference no  from database 'mapno'
                    int upref = refno + 1;
                    dbmap.update("no", "reference", upref.ToString());
                }
                else
                {
                    dbmap.insert(new MapnoRow("reference",10001));
                    refno = 10000;
                }

                if (comboCategory.SelectedIndex == 0)           //add data to database 'applicaton' if domestoc category
                {
                    ApplicationForm app = new ApplicationForm(comboTitle.SelectedItem.ToString(), textBoxName.Text, textBoxNIC.Text,
                        comboCategory.SelectedItem.ToString(), textBoxAddressConnection.Text, textBoxGramaNiladhari.Text, textBoxDivisionalSec.Text,
                        textBoxDistrict.Text, textBoxAddressMail.Text, textBoxEmail.Text, int.Parse(textBoxContact.Text),
                        comboBoxApplicantType.SelectedItem.ToString(), checkBoxDocsSubmitted.Checked, checkBoxPreviousConnection.Checked, textBoxPreviousAccountNo.Text,
                        comboBoxPreviousCategory.SelectedItem.ToString(), refno);//reference 0*************dn
                    approw = new ApplicationRow(app.title, app.name, app.nic, app.category, app.address,
                        app.gramaDivision, app.divisionalSecretariat, app.district, app.mail, app.email, app.contact,
                        app.applicantType, app.submittedDocs, app.preaccountNo, app.preCategory, app.refno, null, null, 0, 0);

                    dbapp.insert(approw);
                }
                else                                    //add data to database 'applicaton' if business category
                {
                    BusinessApplicationForm app1 = new BusinessApplicationForm(comboTitle.SelectedItem.ToString(), textBoxName.Text, textBoxNIC.Text,
                        comboCategory.SelectedItem.ToString(), textBoxAddressConnection.Text, textBoxGramaNiladhari.Text, textBoxDivisionalSec.Text,
                        textBoxDistrict.Text, textBoxAddressMail.Text, textBoxEmail.Text, int.Parse(textBoxContact.Text),
                        comboBoxApplicantType.SelectedItem.ToString(), checkBoxDocsSubmitted.Checked, checkBoxPreviousConnection.Checked, textBoxPreviousAccountNo.Text,
                        comboBoxPreviousCategory.SelectedItem.ToString(), textBox1Company.Text, textBoxPost.Text, refno);//reference 0****dn
                    approw = new ApplicationRow(app1.title, app1.name, app1.nic, app1.category, app1.address,
                        app1.gramaDivision, app1.divisionalSecretariat, app1.district, app1.mail, app1.email, app1.contact,
                        app1.applicantType, app1.submittedDocs, app1.preaccountNo, app1.preCategory, app1.refno,
                        app1.company, app1.post, 0, 0);
                    dbapp.insert(approw);
                }

                //show the reference no via message box
                MessageBox.Show("Your Connection Reference No is: " + refno, "Reference Number", MessageBoxButtons.OK);
                button2Click();                 //clear all fields
            }
            else   //show an error message if not completed the application
                MessageBox.Show("Please enter all the required data before submission", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        public bool valid()//application valid method
        {

            if (textBoxName.Text == "" || textBoxNIC.Text == "" || textBoxAddressConnection.Text == "" || textBoxGramaNiladhari.Text == ""
                || textBoxDivisionalSec.Text == "" || textBoxDistrict.Text == "" || textBoxAddressMail.Text == "" || textBoxContact.Text == "")
                return false;
            if (checkBoxPreviousConnection.Checked && textBoxPreviousAccountNo.Text == "")
                return false;
            if (comboCategory.SelectedIndex == 1 && (textBox1Company.Text == "" || textBoxPost.Text == ""))
                return false;
            return true;

        }

        private void buttonClearApplication_Click(object sender, EventArgs e)//clear button action
        {
            button2Click();
        }
        private void button2Click()// clear method of tab1
        {
            textBoxName.Text = ""; textBoxNIC.Text = ""; textBoxAddressConnection.Text = ""; textBoxGramaNiladhari.Text = "";
            textBoxDivisionalSec.Text = ""; textBoxDistrict.Text = ""; textBoxAddressMail.Text = ""; textBoxContact.Text = "";
            textBoxEmail.Text = ""; textBoxPreviousAccountNo.Text = ""; textBox1Company.Text = ""; textBoxPost.Text = "";

            checkBoxDocsSubmitted.Checked = false; checkBoxPreviousConnection.Checked = false;

            comboTitle.SelectedIndex = 0; comboBoxApplicantType.SelectedIndex = 0; comboBoxPreviousCategory.SelectedIndex = 0;
            comboCategory.SelectedIndex = 0;
        }





        /****************************tab2 for confirm documents***********/

        private void buttonRefreshApplicantList_Click(object sender, EventArgs e)//refresh button action
        {
            clr();
        }
        private void clr()//refresh method of tab2
        {
            textBoxWaitingName.Text = ""; textBoxWaitingAddress.Text = ""; textBoxWaitingContact.Text = "";
                                                              //Update waiting list with database details
            string[] refnos = dbapp1.getColumn("refno");
            listViewApplicants.Items.Clear();
            for (int i = 0; i < refnos.Length; i++)
            {
                listViewApplicants.Items.Add(refnos[i]);
            }
            buttonWaitingSubmit.Enabled = false; buttonEditWaiting.Enabled = false;

            textBoxWaitingName.ReadOnly = true; textBoxWaitingAddress.ReadOnly = true; textBoxWaitingContact.ReadOnly = true;
            buttonCertifyG.Enabled = buttonRejectG.Enabled = buttonCertifyA.Enabled = buttonRejectA.Enabled = false;

        }


        private void buttonEditWaiting_Click(object sender, EventArgs e)//edit button action
        {
             textBoxWaitingAddress.ReadOnly = false; textBoxWaitingContact.ReadOnly = false;
            buttonCertifyG.Enabled = buttonRejectG.Enabled = buttonCertifyA.Enabled = buttonRejectA.Enabled = true;
            if (buttonCertifyG.Text == "Not Yet Certified. Click to Certify")
                buttonRejectG.Enabled = true;
            else
                buttonRejectG.Enabled = false;
            if (buttonCertifyA.Text == "Not Yet Certified. Click to Certify")
                buttonRejectA.Enabled = true;
            else
                buttonRejectA.Enabled = false;
        }

        private void buttonWaitingSubmit_Click(object sender, EventArgs e)//save button action
        {
            appToAccept1.setname(textBoxWaitingName.Text);
            appToAccept1.setaddress(textBoxWaitingAddress.Text);
            appToAccept1.setcontact(int.Parse(textBoxWaitingContact.Text));
            //if only one document is confirmed and the other still not, update database 'application'
            if (!(appToAccept1.confirmA == 2 && appToAccept1.confirmG == 2) && !(appToAccept1.confirmA == 1 && appToAccept1.confirmG == 1))
            {

                dbapp1.updateMany(new string[] { "name", "mail", "contact", "confirmG", "confirmA" }, listViewApplicants.SelectedItems[0].Text,
                    new string[]{textBoxWaitingName.Text,textBoxWaitingAddress.Text,textBoxWaitingContact.Text,appToAccept1.confirmG.ToString()
                        ,appToAccept1.confirmA.ToString()});
            }

            //if both are confirmed add data to 'inprogress' database and delete data from 'application' database
            else if (appToAccept1.confirmA == 1 && appToAccept1.confirmG == 1)
            {
                string[] vals = dbapp1.getRow(listViewApplicants.SelectedItems[0].Text);
                dbprog.insert(new InProgressRow(vals[0], textBoxWaitingName.Text, vals[2], vals[3], vals[4], vals[5], vals[6], vals[7], textBoxWaitingAddress.Text,
                    vals[9], int.Parse(textBoxWaitingContact.Text), vals[11], true, vals[13], vals[14], int.Parse(vals[15]), vals[16], vals[17],
                    "Approved",""));
                dbapp1.delete(listViewApplicants.SelectedItems[0].Text);
                clr();
            }
            clr();
        }

        //set the text of confirm button related to gramaniladari certificate
        private void buttonCertifyG_Click(object sender, EventArgs e)
        {
            if (buttonCertifyG.Text == "Checked and Certified. Click if Not")
            {
                buttonCertifyG.Text = "Not Yet Certified. Click to Certify";
                buttonRejectG.Enabled = true;
                appToAccept1.confirmG = 0;
            }
            else if (buttonCertifyG.Text == "Not Yet Certified. Click to Certify")
            {
                buttonCertifyG.Text = "Checked and Certified. Click if Not";
                buttonRejectG.Enabled = false;
                appToAccept1.confirmG = 1;
            }
        }

        //set the text of confirm button related to Assesment notice
        private void buttonCertifyA_Click(object sender, EventArgs e)
        {
            if (buttonCertifyA.Text == "Checked and Certified. Click if Not")
            {
                buttonCertifyA.Text = "Not Yet Certified. Click to Certify";
                buttonRejectA.Enabled = true;
                appToAccept1.confirmA = 0;
            }
            else if (buttonCertifyA.Text == "Not Yet Certified. Click to Certify")
            {
                buttonCertifyA.Text = "Checked and Certified. Click if Not";
                buttonRejectA.Enabled = false;
                appToAccept1.confirmA = 1;
            }
        }

        private void buttonRejectG_Click(object sender, EventArgs e)//rejection of gramaniladari certificate
        {
            //delete from 'application' database and add to 'mail' database
            string value = "";
            if (InputBox("Reasoning", "Reason for rejecting GramaNiladari Certificate:", ref value) == DialogResult.OK)
            {
                string reasonG = value;
                if (value == "")
                    MessageBox.Show("Please enter a reason for rejection. Otherwise considered as not rejected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    appToAccept1.confirmG = 2;

                    string msg = "Your GramaNiladari Certificate has been rejected because of the reason: " + value;
                    MailRow mrow = new MailRow(int.Parse(listViewApplicants.SelectedItems[0].Text), textBoxWaitingName.Text, textBoxWaitingAddress.Text, msg);
                    dbmail.insert(mrow);
                    dbapp1.delete(listViewApplicants.SelectedItems[0].Text);
                    clr();

                }
            }
        }

        private void buttonRejectA_Click(object sender, EventArgs e)//rejection of assesment notice
        {
            //delete from 'application' database and add to 'mail' database
            string value = "";
            if (InputBox("Reasoning", "Reason for rejecting Assesment Notice:", ref value) == DialogResult.OK)
            {
                string reasonA = value;
                if (value == "")
                    MessageBox.Show("Please enter a reason for rejection. Otherwise considered as not rejected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    appToAccept1.confirmA = 2;
                    string msg = "Your Assesment Notice has been rejected because of the reason: " + value;
                    MailRow mrow = new MailRow(int.Parse(listViewApplicants.SelectedItems[0].Text), textBoxWaitingName.Text, textBoxWaitingAddress.Text, msg);
                    dbmail.insert(mrow);
                    dbapp1.delete(listViewApplicants.SelectedItems[0].Text);
                    clr();
                }
            }
        }

        private void listViewApplicants_SelectedIndexChanged(object sender, EventArgs e)//when selected item changed
        {//set properties of buttons
            textBoxWaitingName.ReadOnly = true; textBoxWaitingAddress.ReadOnly = true; textBoxWaitingContact.ReadOnly = true;
            buttonCertifyG.Enabled = buttonRejectG.Enabled = buttonCertifyA.Enabled = buttonRejectA.Enabled = false;
            //if an item is selected get data from databases and show in text fields
            if (listViewApplicants.SelectedIndices.Count != 0)
            {
                buttonWaitingSubmit.Enabled = buttonEditWaiting.Enabled = true;

                textBoxWaitingName.Text = appToAccept1.name = dbapp1.get("name", listViewApplicants.SelectedItems[0].Text);
                textBoxWaitingAddress.Text = appToAccept1.mail = dbapp1.get("mail", listViewApplicants.SelectedItems[0].Text);
                appToAccept1.contact = int.Parse(dbapp1.get("contact", listViewApplicants.SelectedItems[0].Text));
                appToAccept1.confirmA = int.Parse(dbapp1.get("confirmA", listViewApplicants.SelectedItems[0].Text));
                appToAccept1.confirmG = int.Parse(dbapp1.get("confirmG", listViewApplicants.SelectedItems[0].Text));
                textBoxWaitingContact.Text = appToAccept1.contact.ToString();
                if (appToAccept1.confirmA == 1)
                {
                    buttonCertifyA.Text = "Checked and Certified. Click if Not";
                }
                else
                {
                    buttonCertifyA.Text = "Not Yet Certified. Click to Certify";
                }
                if (appToAccept1.confirmG == 1)
                {
                    buttonCertifyG.Text = "Checked and Certified. Click if Not";
                }
                else
                {
                    buttonCertifyG.Text = "Not Yet Certified. Click to Certify";
                }
            }
            else//if no item selected
            {
                buttonWaitingSubmit.Enabled = buttonEditWaiting.Enabled = false;
                textBoxWaitingName.Text = ""; textBoxWaitingAddress.Text = ""; textBoxWaitingContact.Text = "";
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)//to get a input window
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }




        /**************tab 3 for set and view the progress***********************/

        private void draw() //to show the progress of each connection
        {

            listBoxProgress.Refresh();
            Rectangle rc = listBoxProgress.GetItemRectangle(listboxindex);
            LinearGradientBrush brush = new LinearGradientBrush(
                rc, Color.Transparent, Color.Red, LinearGradientMode.ForwardDiagonal);
            Graphics g = Graphics.FromHwnd(listBoxProgress.Handle);

            g.FillRectangle(brush, rc);
        }

        private void buttonNextProgress_Click(object sender, EventArgs e)//next button action
        {
            if (listboxindex < 6)                               //if not to finalize
            {
                if (MessageBox.Show("Are you sure that you need to advance the progress?",
                    "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (listboxindex == 1)                      //to enter estimate
                    {
                        string value = "";
                        if (InputBox("Estimate Summary", "Please enter the summary of estimate:", ref value) == DialogResult.OK)
                        {
                            appToProgress.estimateSummary = value;
                            if (value == "")
                                MessageBox.Show("Please enter the summary of estimate. Otherwise considered as not progressed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                string summary = value;
                                dbprog.updateMany(new string[]{"estimateSummary", "progress"},listViewInProgress.SelectedItems[0].Text,new string[] {summary,"Estimated"});
                                listboxindex++;
                                draw();
                            }
                        }
                    }
                    else
                    {
                        listboxindex++;
                        draw();
                    }
                }
            }
            //create an account and add to 'account' database, create bill database for each user
            else if (listboxindex == 6)                 
            {
                if (MessageBox.Show("Are you sure that you need to advance the progress? This will create an account",
                     "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int accountno;
                    if (dbmap.hasEntry("account"))
                    {
                        accountno = int.Parse(dbmap.get("no", "account"));
                        dbmap.update("no", "account", (accountno + 1).ToString());
                    }
                    else
                    {
                        accountno = 1000000;
                        dbmap.insert(new MapnoRow("account",1000001));
                    }
                    String[] row = dbprog.getRow(listViewInProgress.SelectedItems[0].Text);
                    dbprog.delete(listViewInProgress.SelectedItems[0].Text);
                    AccountRow accrow = new AccountRow(accountno, row[0], textBoxInProgressName.Text, row[2], row[3], row[4],
                        row[5], row[6], row[7],textBoxInProgressAddress.Text, row[9], int.Parse(textBoxInProgressContact.Text), row[11], row[16], row[17],
                        int.Parse(listViewInProgress.SelectedItems[0].Text));
                    dbacc.insert(accrow);
                    dbbill.createBillingTable(accountno);
                    string password=createRandomPassword(10);
                    LoginRow logrow=new LoginRow(accountno.ToString(),password,1);
                    dblogin.insert(logrow);
                    MailRow mrow=new MailRow(accountno,textBoxInProgressName.Text,textBoxInProgressAddress.Text,
                        "Your username for the user account: "+accountno+", password: "+password);
                    dbmail.insert(mrow);
                    MessageBox.Show("Assigned Account No (Username) is: " + accountno+"\nLogin Password is: "+password, "Account Number and Login Password", MessageBoxButtons.OK);
                    clrprog();
                }
                else
                {
                    dbprog.update("progress", listViewInProgress.SelectedItems[0].Text, "Connection Established");
                }
            }

        }

        private string createRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void buttonRefreshInProgressList_Click(object sender, EventArgs e)//refresh button action
        {
            clrprog();
        }


        private void clrprog()//refresh method
        {
            textBoxInProgressName.Text = ""; textBoxInProgressAddress.Text = ""; textBoxInProgressContact.Text = "";

            string[] refnos = dbprog.getColumn("refno");
            listViewInProgress.Items.Clear();
            for (int i = 0; i < refnos.Length; i++)
            {
                listViewInProgress.Items.Add(refnos[i]);
            }
            buttonProgressEdit.Enabled = false; buttonProgressSubmit.Enabled = false;

            textBoxInProgressName.ReadOnly = true; textBoxInProgressAddress.ReadOnly = true; textBoxInProgressContact.ReadOnly = true;
            buttonNextProgress.Enabled = false;
            listBoxProgress.Refresh();

        }

        private void buttonProgressEdit_Click(object sender, EventArgs e)//edit button action
        {
            textBoxInProgressContact.ReadOnly = false; textBoxInProgressAddress.ReadOnly = false;
            buttonNextProgress.Enabled = true;
        }


        private void buttonProgressSubmit_Click(object sender, EventArgs e)//save button action
        {
            textBoxInProgressName.ReadOnly = textBoxInProgressContact.ReadOnly = textBoxInProgressAddress.ReadOnly = true;
            buttonNextProgress.Enabled = false;
            if (listboxindex!=7)
            {
                //if not finalized update the datebase 'inprogress'
                appToProgress.setname(textBoxInProgressName.Text);
                appToProgress.setaddress(textBoxInProgressAddress.Text);
                appToProgress.setcontact(int.Parse(textBoxInProgressContact.Text));
                String[] progress = {"Approved","Visited","Estimated","Voucher Prepared","Payment Received",
                                        "Bond Signed","Connection Established","Finalized"};
                appToProgress.setprogress(progress[listboxindex]);

                dbprog.updateMany(new string[] { "name", "mail", "contact", "progress" },
                    listViewInProgress.SelectedItems[0].Text,
                    new string[] { textBoxInProgressName.Text, textBoxInProgressAddress.Text, textBoxInProgressContact.Text, appToProgress.progress });
                clrprog();
            }
        }


        private void listViewInProgress_SelectedIndexChanged(object sender, EventArgs e)//when selected item of listview changed
        {
            textBoxInProgressName.ReadOnly = textBoxInProgressContact.ReadOnly = textBoxInProgressAddress.ReadOnly = true;
            buttonNextProgress.Enabled = false;
            //if an item is selected get data from databases and show in text fields
            if (listViewInProgress.SelectedIndices.Count != 0)
            {
                String[] row = dbprog.getRow(listViewInProgress.SelectedItems[0].Text);
                
                buttonProgressEdit.Enabled = buttonProgressSubmit.Enabled = true;
                appToProgress.name = textBoxInProgressName.Text = row[1];
                appToProgress.mail = textBoxInProgressAddress.Text = row[8];
                appToProgress.contact = int.Parse(row[10]);
                textBoxInProgressContact.Text = appToProgress.contact.ToString();
                string listboxstr = row[18];

                if (listboxstr == "Approved")
                    listboxindex = 0;
                else if (listboxstr == "Visited")
                    listboxindex = 1;
                else if (listboxstr == "Estimated")
                    listboxindex = 2;
                else if (listboxstr == "Voucher Prepared")
                    listboxindex = 3;
                else if (listboxstr == "Payment Received")
                    listboxindex = 4;
                else if (listboxstr == "Bond Signed")
                    listboxindex = 5;
                else if (listboxstr == "Connection Established")
                    listboxindex = 6;
                else if (listboxstr == "Finalized")
                    listboxindex = 7;
                draw();

            }
            else//if no item is selected
            {
                buttonProgressEdit.Enabled = buttonProgressSubmit.Enabled = false;
                textBoxInProgressName.Text = ""; textBoxInProgressContact.Text = ""; textBoxInProgressAddress.Text = "";
                listBoxProgress.Refresh();
            }
        }

    }





    public class ApplicationForm //class application form
    {
        public String title;
        public String name;
        public String nic;
        public String category;
        public String address;
        public String gramaDivision;
        public String divisionalSecretariat;
        public String district;
        public String mail;
        public String email;
        public int contact;
        public String applicantType;
        public bool submittedDocs;
        public bool preConnection;
        public String preaccountNo;
        public String preCategory;
        public int refno;
        public int confirmG;//0-not yet,1-confirmed,2-rejected
        public int confirmA;//0-not yet,1-confirmed,2-rejected
        public string progress;
        public string estimateSummary;

                                        //constructor
        public ApplicationForm(String dsg, String nm, String id, String cat, String add, String gd, String ds,
            String dst, String ml, String eml, int cnt, String atyp, bool sd, bool prc, String acc, String pcat, int rn)
        {
            title = dsg; name = nm; nic = id; category = cat; address = add; gramaDivision = gd; divisionalSecretariat = ds;
            district = dst; mail = ml; email = eml; contact = cnt; applicantType = atyp; submittedDocs = sd;
            preConnection = prc; preaccountNo = acc; preCategory = pcat; refno = rn;
        }

        public void setname(String nm) { name = nm; }
        public void setaddress(String add) { mail = add; }
        public void setcontact(int no) { contact = no; }
        public void setprogress(string pr) { progress = pr; }

    }





    public class BusinessApplicationForm : ApplicationForm  //inherited class from ApplicationForm
    {
        public string company;
        public string post;
                                    //constructor
        public BusinessApplicationForm(String dsg, String nm, String id, String cat, String add, String gd,
            String ds, String dst, String ml, String eml, int cnt, String atyp, bool sd, bool prc, String acc,
            String pcat, string com, string pt, int rn)
            : base(dsg, nm, id, cat, add, gd, ds, dst, ml, eml, cnt, atyp, sd, prc, acc, pcat, rn)
        {
            company = com;
            post = pt;
        }
    }
}
