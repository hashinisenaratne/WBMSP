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
    public partial class Contact : Form
    {
        private Water_Board_Management.Database db1;
        private Water_Board_Management.Database db2;
        private bool b1;
        private String[] original;
        private bool isFullAcc;

        private static Contact singleton=null;

        public static Contact createContact()
        {
            if (singleton == null)
            {
                singleton = new Contact();
            }
            return singleton;
        }

        public static Contact createContact(int acc)
        {
            if (singleton == null)
            {
                singleton = new Contact(acc);
            }
            return singleton;
        }

              
        public Contact()
        {
            InitializeComponent();
            db1 = new Water_Board_Management.Database("inprogress", "refno");
            db2 = new Water_Board_Management.Database("account", "accountNo");
            b1 = false;
            original = new String[3];
        }

        public Contact(int acc)
        {
            InitializeComponent();
            db1 = new Water_Board_Management.Database("inprogress", "refno");
            db2 = new Water_Board_Management.Database("account", "accountNo");
            b1 = false;
            original = new String[3];
            
            radioButton1.Enabled = false;
            accntN.Text = acc.ToString();
            accntN.ReadOnly = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!b1)
            {
                int n;
                if (radioButton1.Checked)
                {
                    if ((!(int.TryParse(accntN.Text, out n))) || (accntN.Text.Contains(".")) || (accntN.Text.Length < 5))
                    {
                        MessageBox.Show("Please enter a valid reference number", "Invalid reference number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        button1.Text = "Cancel";
                        panel1.Enabled = false; ;
                        loadDetails(db1, accntN.Text);
                        setDefault();
                        panel2.Visible = true;
                        b1 = true;
                        isFullAcc = false;
                    }
                }
                else if (radioButton2.Checked)
                {
                    if ((!(int.TryParse(accntN.Text, out n))) || (accntN.Text.Contains(".")) || (accntN.Text.Length < 7))
                    {
                        MessageBox.Show("Please enter a valid account number", "Invalid account number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        button1.Text = "Cancel";
                        panel1.Enabled = false; ;
                        loadDetails(db2, accntN.Text);
                        setDefault();
                        panel2.Visible = true;
                        b1 = true;
                        isFullAcc = true;
                    }
                }   
            }
            else
            {
                panel1.Enabled = true; ;
                panel2.Visible = false;
                button1.Text = "edit";
                b1 = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label1.Text = "Reference number";
                accntN.MaxLength = 5;
            }
            else if (radioButton2.Checked)
            {
                label1.Text = "Account number";
                accntN.MaxLength = 7;
            }
        }

        private void loadDetails(Water_Board_Management.Database d,String key)
        {
            if (d.hasEntry(key))
            {
                original[0] = d.get("mail", key);
                String con = d.get("contact", key);
                while (con.Length != 10)
                {
                    con = "0" + con;
                }
                original[1] = con;
                original[2] = d.get("email", key);
                button2.Enabled = button3.Enabled = true;
            }
            else
            {
                original[0] = "No such record found. Please check whether the reference/account number is correct";
                original[1] = "";
                original[2] = "";
                button2.Enabled = button3.Enabled = false;
            }
            
        }

        private void setDefault()
        {
            mailTxt.Text = original[0];
            phnTxt.Text = original[1];
            emailTxt.Text = original[2];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setDefault();           
        }

        private bool checkValidity()
        {
            int n;
            if (String.IsNullOrWhiteSpace(mailTxt.Text))
            {
                MessageBox.Show("Please enter a valid mail address", "Invalid mail address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if ((String.IsNullOrWhiteSpace(phnTxt.Text)) || (!(int.TryParse(phnTxt.Text, out n)))||(phnTxt.Text.Length<10))
            {
                MessageBox.Show("Please enter a valid phone number", "Invalid phone number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if ((String.IsNullOrWhiteSpace(emailTxt.Text)) || (!(emailTxt.Text.Contains("@"))) || (!(emailTxt.Text.Contains("."))))
            {
                MessageBox.Show("Please enter a valid email address", "Invalid email address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkValidity())
            {
                if (!mailTxt.Text.Equals(original[0]))
                {
                    updateDB("mail", mailTxt.Text);
                }
                if (!phnTxt.Text.Equals(original[1]))
                {
                    updateDB("contact", phnTxt.Text);
                }
                if (!emailTxt.Text.Equals(original[2]))
                {
                    updateDB("email", emailTxt.Text);
                }
                MessageBox.Show("Changes to contact details were successfully saved.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateDB(String col,String nVal)
        {
            if (!isFullAcc)
            {
                db1.update(col, accntN.Text, nVal);
            }
            else
            {
                db2.update(col, accntN.Text, nVal);
            }
        }

        private void Contact_FormClosing(object sender, FormClosingEventArgs e)
        {
            singleton = null;
        }
    }
}
