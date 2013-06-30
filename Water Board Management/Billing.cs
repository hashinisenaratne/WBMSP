using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Water_Board_Management_Billing
{
    public partial class Billing : Form
    {

        public static Billing singleton = null;

        Water_Board_Management.Database db, userDB, dbEntry, dbC, dbBUlk;
        bill bill;
        int authLevel, accountNumber;
        Form complainForm;

        public Billing()
        {
            InitializeComponent();
            dbBUlk = new Water_Board_Management.Database("meter", "month");
            userDB = new Water_Board_Management.Database("account", "accountNo");
            accountNumber = 1001667;
            setUser(1);
            label50.Text = System.DateTime.Today.ToLongDateString();
            db = new Water_Board_Management.Database("a" + accountNumber, "month");

        }

        public Billing(int auth, int account)
        {
            InitializeComponent();
            userDB = new Water_Board_Management.Database("account", "accountNo");
            dbBUlk = new Water_Board_Management.Database("meter", "month");
            authLevel = auth;
            accountNumber = account;
            db = new Water_Board_Management.Database("a" + accountNumber, "month");
            setUser(authLevel);

            label50.Text = System.DateTime.Today.ToLongDateString();

        }


        public void setUser(int num)
        {
            if (num == 0)
            {
                DataEntryButton.Visible = true;
                label3.Visible = false;
                complain.Visible = false;
            }
            else if (num == 1)
            {
                customerHanlde();

            }
            else if (num == 2)
            {
                DataEntryPanel.Visible = true;
                BulkButton.Visible = true;
                label3.Visible = false;
                DataEntryButton.Visible = false;
                BillRecordButton.Visible = false;
                complain.Visible = false;
            }
            else if (num == 3)
            {
                CCPanel.Visible = true;
                DataEntryButton.Visible = false;
                BillRecordButton.Visible = false;
                label3.Visible = false;
                complain.Visible = false;

            }
            else if (num == 4)
            {
                CCPanel.Visible = true;
                DataEntryPanel.Visible = false;
                BillRecordButton.Visible = false;
                DataEntryButton.Visible = false;
                label3.Visible = false;
                complain.Visible = false;

            }


        }

        public void customerHanlde()
        {
            DataEntryButton.Visible = false;
            BillRecordButton.Visible = false;
            panel3.Visible = true;
            label2.Text = userDB.get("name", Convert.ToString(accountNumber));
            label10.Text = Convert.ToString(accountNumber);
            label13.Text = userDB.get("category", Convert.ToString(accountNumber));


        }

        public void customerCareHandle()
        {

            if (userDB.hasEntry(textBox7.Text) == true)
            {
                label29.Text = userDB.get("category", textBox7.Text);
            }
            else
            {
                label29.Text = "";
                MessageBox.Show("Account Does Not Exist!!");

            }

        }

        public static Billing Create(int auth, String accountNo)
        {
            int accNo;
            if (singleton == null)
            {
                if (int.TryParse(accountNo, out accNo))
                    return singleton = new Billing(auth, accNo);
                else
                    return singleton = new Billing(auth, 0);

            }
            return singleton;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\b";
        }



        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "1";
            }
            else
            {
                textBox1.Text += "1";
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "2";
            }
            else
            {
                textBox1.Text += "2";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "3";
            }
            else
            {
                textBox1.Text += "3";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "4";
            }
            else
            {
                textBox1.Text += "4";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "5";
            }
            else
            {
                textBox1.Text += "5";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "6";
            }
            else
            {
                textBox1.Text += "6";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "7";
            }
            else
            {
                textBox1.Text += "7";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "8";
            }
            else
            {
                textBox1.Text += "8";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "9";
            }
            else
            {
                textBox1.Text += "9";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                button1_Click(sender, e);
                textBox1.Text += "0";
            }
            else
            {
                textBox1.Text += "0";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == '.')
                {
                    if (textBox1.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '-')
                {
                    if (!String.IsNullOrEmpty(textBox1.Text))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '\b') ;
                else
                    e.Handled = true;
            }

            if (Convert.ToInt32(e.KeyChar) == (int)Keys.Enter)
            {
                button2_Click(sender, e);
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter The Usage")
            {
                textBox1.Text = "";
                label4.Visible = false;
            }
            else
            {
                label4.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = 0;

            if (textBox1.Text == "Enter The Usage")
            {
                errorProvider1.SetError(textBox1, "Enter a value");
            }
            else if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Enter a value");
            }
            else
            {
                errorProvider1.Dispose();
                num = Convert.ToInt32(textBox1.Text);
            }

            if (comboBox2.Text == "Select A Category")
            {
                errorProvider1.SetError(comboBox2, "Select a Category");
            }
            else
            {
                label4.Text = "Rs. " + calculate(textBox1.Text, comboBox2.Text);
                label4.Visible = true;
            }

        }


        private void button11_Click(object sender, EventArgs e)
        {
            DataEntryPanel.SendToBack();
            CCPanel.SendToBack();
            panel4.Visible = true;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataEntryPanel.SendToBack();
            CCPanel.SendToBack();
            panel5.Visible = true;
        }


        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter The Acc No:")
            {
                textBox2.Text = "";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (DataEntryPanel.Visible == false)
            {
                CCPanel.Visible = false;
                DataEntryPanel.Visible = true;

            }
            else
            {
                DataEntryPanel.Visible = false;
            }
        }



        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {

                if (e.KeyChar == '.')
                {
                    if (textBox3.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '-')
                {
                    if (!String.IsNullOrEmpty(textBox3.Text))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '\b') ;
                else
                    e.Handled = true;
            }

            if (Convert.ToInt32(e.KeyChar) == (int)Keys.Enter)
            {
                button20_Click(sender, e);
                label26.Text = "Rs. " + Convert.ToString(calculate(textBox3.Text, label28.Text));

            }
        }



        private double calculate(string txt, string category)
        {
            int num;
            double result;
            double sum = 0;

            num = Convert.ToInt32(txt);

            if (category == "Domestic")
            {
                if (num == 0)
                {
                    result = 50;
                }
                else if (num < 6)
                {
                    result = 50 + num * 3;
                }
                else if (num < 11)
                {
                    result = 65 + (num - 5) * 7 + 5 * 3;
                }
                else if (num < 16)
                {
                    result = 70 + (num - 10) * 15 + 5 * 3 + 7 * 5;
                }
                else if (num < 21)
                {
                    result = 80 + (num - 15) * 30 + 5 * 3 + 5 * 7 + 5 * 15;
                }
                else if (num < 26)
                {
                    result = 100 + (num - 20) * 50 + 5 * 30 + 5 * 3 + 5 * 7 + 5 * 15;
                }
                else if (num < 31)
                {
                    result = 200 + (num - 25) * 75 + 5 * 50 + 5 * 30 + 5 * 3 + 5 * 7 + 5 * 15;
                }
                else if (num < 41)
                {
                    result = 400 + (num - 30) * 90 + 5 * 75 + 5 * 50 + 5 * 30 + 5 * 3 + 5 * 7 + 5 * 15;
                }
                else if (num < 51)
                {
                    result = 650 + (num - 40) * 105 + 5 * 90 + 5 * 75 + 5 * 50 + 5 * 30 + 5 * 3 + 5 * 7 + 5 * 15;
                }
                else if (num < 76)
                {
                    result = 1000 + (num - 50) * 110 + 5 * 105 + 5 * 90 + 5 * 75 + 5 * 50 + 5 * 30 + 5 * 3 + 5 * 7 + 5 * 15;
                }
                else
                {
                    result = 1600 + (num - 75) * 120 + 5 * 110 + 5 * 105 + 5 * 90 + 5 * 75 + 5 * 50 + 5 * 30 + 5 * 3 + 5 * 7 + 5 * 15;
                }

                sum = Convert.ToDouble(result);
            }

            if (category == "Business")
            {
                if (num == 0)
                {
                    result = 250;
                }
                else if (num < 26)
                {
                    result = 250 + num * 65;
                }
                else if (num < 51)
                {
                    result = 500 + num * 65;
                }
                else if (num < 101)
                {
                    result = 1000 + num * 65;
                }
                else
                {
                    result = 1500 + num * 65;
                }
                sum = Convert.ToDouble(result);

            }

            return sum;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            button20_Click(sender, e);

            if (comboBox3.Text == "")
            {
                errorProvider1.SetError(comboBox3, "Select A Month");
            }
            else
            {
                errorProvider1.Dispose();
            }

            if (comboBox4.Text == "")
            {
                errorProvider1.SetError(comboBox4, "Select A Year");
            }
            else
            {
                errorProvider1.Dispose();

            }
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Enter a valide number");
            }
            else if (Convert.ToInt32(textBox3.Text) < 0)
            {
                errorProvider1.SetError(textBox3, "Enter a valide number");
            }
            else
            {
                errorProvider1.Dispose();
                double result = calculate(textBox3.Text, label28.Text);
                label26.Text = "Rs. " + Convert.ToString(result);
                int units = Convert.ToInt32(textBox3.Text);
                double amount = result;
                bill = new bill(comboBox3.Text, comboBox4.Text, units, amount, textBox5.Text);
                dbEntry = new Water_Board_Management.Database("a" + textBox2.Text, "month");

                if (dbEntry.hasEntry(bill.getMonth()) == true)
                {
                    if (MessageBox.Show("Do you want to update the data?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dbEntry.updateMany(new String[] { "units", "amount", "remarks" }, bill.getMonth(), new String[] { Convert.ToString(bill.getUnits()), Convert.ToString(bill.getAmount()), bill.getRemarks() });
                        MessageBox.Show("Successfully Updated Data");
                        textBox3.Text = "";
                        label26.Text = "";
                        textBox5.Text = "";
                    }

                }
                else
                {
                    dbEntry.insert(new Water_Board_Management.BillingRow(bill.getMonth(), bill.getUnits(), bill.getAmount(), bill.getRemarks()));
                    MessageBox.Show("Successfully Entered Data");
                    textBox3.Text = "";
                    label26.Text = "";
                    textBox5.Text = "";
                }

                if (dbBUlk.hasEntry(bill.getMonth()) == true)
                {
                    int usage;
                    usage = Convert.ToInt32(dbBUlk.get("usag", bill.getMonth()));
                    usage += bill.getUnits();
                    dbBUlk.update("usag", bill.getMonth(), Convert.ToString(usage));
                }
                else
                {
                    dbBUlk.insert(new Water_Board_Management.MeterRow(bill.getMonth(), 0, bill.getUnits()));
                }


            }
        }



        private void button23_Click(object sender, EventArgs e)
        {
            if (CCPanel.Visible == false)
            {
                CCPanel.Visible = true;

            }
            else
            {
                CCPanel.Visible = false;
            }
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "Enter The Acc No:")
            {
                textBox7.Text = "";
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void button20_Click(object sender, EventArgs e)
        {
            string account = "a" + textBox2.Text;

            if (userDB.hasEntry(textBox2.Text) == true)
            {
                label28.Text = userDB.get("category", textBox2.Text);

            }
            else
            {
                MessageBox.Show("Account Does Not Exist!!");
            }


        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {

                if (e.KeyChar == '.')
                {
                    if (textBox2.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '-')
                {
                    if (!String.IsNullOrEmpty(textBox2.Text))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '\b') ;
                else
                    e.Handled = true;
            }

            if (Convert.ToInt32(e.KeyChar) == (int)Keys.Enter)
            {
                button20_Click(sender, e);

            }
        }


        private void comboBox7_TextChanged(object sender, EventArgs e)
        {
            string str;
            db = new Water_Board_Management.Database("a" + accountNumber, "month");

            str = comboBox1.Text + "/" + comboBox7.Text;
            if (db.hasEntry(str) == true)
            {
                label11.Text = db.get("units", str);
                label12.Text = "Rs. " + db.get("amount", str);
            }
            else if (comboBox7.Text == "")
            {

            }
            else
            {
                label11.Text = "N/A";
                label12.Text = "N/A";
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox7_TextChanged(sender, e);

        }


        private void button21_Click(object sender, EventArgs e)
        {
            customerCareHandle();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {

                if (e.KeyChar == '.')
                {
                    if (textBox2.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '-')
                {
                    if (!String.IsNullOrEmpty(textBox2.Text))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '\b') ;
                else
                    e.Handled = true;
            }
            if (Convert.ToInt32(e.KeyChar) == (int)Keys.Enter)
            {
                button21_Click(sender, e);
            }
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            button21_Click(sender, e);
            string str;
            dbC = new Water_Board_Management.Database("a" + textBox7.Text, "month");

            str = comboBox5.Text + "/" + comboBox6.Text;
            if (dbC.hasEntry(str) == true)
            {
                label41.Text = dbC.get("units", str);
                label42.Text = "Rs. " + dbC.get("amount", str);
                label43.Text = dbC.get("remarks", str);
            }
            else if (comboBox6.Text == "")
            {

            }
            else
            {
                label41.Text = "N/A";
                label42.Text = "N/A";
                label43.Text = "N/A";
            }
        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            comboBox5_TextChanged(sender, e);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (CCPanel.Visible == false)
            {
                DataEntryPanel.Visible = false;
                CCPanel.Visible = true;

            }
            else
            {
                CCPanel.Visible = false;
            }
        }

        private void Billing_FormClosing(object sender, FormClosingEventArgs e)
        {
            singleton = null;

            if (complainForm!=null)
                complainForm.Close();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            DataEntryPanel.SendToBack();
            BulkPanel.Visible = true;
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            BulkPanel.Visible = false;
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            string st;
            if (comboBox8.Text == "" || comboBox9.Text == "" || textBox4.Text == "")
            {
                if (comboBox8.Text == "")
                {
                    errorProvider1.SetError(comboBox8, "Select A Month");
                }
                if (comboBox9.Text == "")
                {
                    errorProvider1.SetError(comboBox9, "Select A Year");
                }
                if (textBox4.Text == "")
                {
                    errorProvider1.SetError(textBox4, "Enter a Valide Value");
                }

            }
            else
            {
                errorProvider1.Dispose();

                st = comboBox8.Text + "/" + comboBox9.Text;

                if (dbBUlk.hasEntry(st) == true)
                {
                    if (MessageBox.Show("Update the existing bulk meter value", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        dbBUlk.update("bulk", st, textBox4.Text);
                        BulkPanel.Visible = false;
                        comboBox8.Text = "";
                        comboBox9.Text = "";
                        textBox4.Text = "";
                    }
                }
                else
                {
                    dbBUlk.insert(new Water_Board_Management.MeterRow(st, Convert.ToInt32(textBox4.Text), 0));
                    MessageBox.Show("Bulk Meter Value Successfully Entered");
                    BulkPanel.Visible = false;
                    comboBox8.Text = "";
                    comboBox9.Text = "";
                    textBox4.Text = "";
                }

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {

                if (e.KeyChar == '.')
                {
                    if (textBox2.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '-')
                {
                    if (!String.IsNullOrEmpty(textBox2.Text))
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == '\b') ;
                else
                    e.Handled = true;
            }
        }

        private void complain_Click(object sender, EventArgs e)
        {
            wait.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            complainForm = Water_Board_Management_HelpDesk.HelpDesk.Create(authLevel, accountNumber.ToString());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            complainForm.Visible = true;
            complainForm.Activate();
            wait.Visible = false;
        }

    }

    class bill
    {
        string month;
        string year;
        int units;
        double amount;
        string remarks;

        public bill(string month, string year, int units, double amount, string remarks)
        {
            this.month = month;
            this.year = year;
            this.units = units;
            this.amount = amount;
            this.remarks = remarks;
        }

        public string getMonth()
        {
            return month + "/" + year;
        }

        public int getUnits()
        {
            return units;
        }

        public double getAmount()
        {
            return amount;
        }

        public string getRemarks()
        {
            if (remarks == "")
            {
                return "N/A";
            }
            else
            {
                return remarks;
            }
        }

    }

}