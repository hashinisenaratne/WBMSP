using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Water_Board_Management_NewConnections;
using Water_Board_Management_HelpDesk;
using Water_Board_Management_Maintenance;
using Water_Board_Management_Billing;
using Water_Board_Management_WastageManagement;

namespace Water_Board_Management
{
    public partial class Login : Form
    {
        Database loginDb;
        int authLevel, opening;
        String[] loginDetails;
        Form[] openForms = new Form[5];


        public Login()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Size.Height < 600)
                this.SetBounds(Location.X, Location.Y - 8, Size.Width, Size.Height + 16);
            else
            {
                timer1.Stop();
                this.SetBounds(Location.X, Location.Y + 2, Size.Width, Size.Height - 4);
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            timer2.Start();
            loginDb = new Database("login", "username");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Start();
        }

        private void loginUsername_Enter(object sender, EventArgs e)
        {
            if (loginUsername.Text == "USERNAME")
            {
                loginUsername.Text = "";
            }
        }

        private void loginPassword_Enter(object sender, EventArgs e)
        {
            if (loginPassword.Text == "PASSWORD")
            {
                loginPassword.Text = "";
                loginPassword.UseSystemPasswordChar = true;
            }
        }

        private void loginUsername_Leave(object sender, EventArgs e)
        {
            if (loginUsername.Text == "")
            {
                loginUsername.Text = "USERNAME";
            }
        }

        private void loginPassword_Leave(object sender, EventArgs e)
        {
            if (loginPassword.Text == "")
            {
                loginPassword.UseSystemPasswordChar = false;
                loginPassword.Text = "PASSWORD";
            }
        }
        private void resetLoginFields()
        {
            loginUsername.Text = "USERNAME";
            loginPassword.UseSystemPasswordChar = false;
            loginPassword.Text = "PASSWORD";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (loginDb.hasEntry(loginUsername.Text))
            {
                loginDetails = loginDb.getRow(loginUsername.Text);
                if (loginDetails[1] == loginPassword.Text)
                {
                    timer1.Tick -= timer1_Tick;
                    timer1.Tick -= loginPanelMoveIn;
                    timer1.Tick += new EventHandler(loginPanelMoveOut);
                    timer1.Start();
                    authLevel = int.Parse(loginDetails[2]);
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect. Please enter again.", "Login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginPassword.UseSystemPasswordChar = false;
                    loginPassword.Text = "PASSWORD";
                }
            }
            else
                MessageBox.Show("Username not found. Contact administration for a valid username.", "Login Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loginPanelMoveOut(object sender, EventArgs e)
        {
            if (panelLogin.Size.Width > 0 || panelLogin.Size.Height > 0)
                panelLogin.SetBounds(panelLogin.Location.X, panelLogin.Location.Y, panelLogin.Size.Width - 16, panelLogin.Size.Height - 16);
            else
            {
                timer1.Stop();
                timer1.Tick -= loginPanelMoveOut;
                timer1.Tick += new EventHandler(categoryPanelMoveIn);
                timer1.Start();
            }
        }

        private void categoryPanelMoveOut(object sender, EventArgs e)
        {
            if (panelSelectCategory.Size.Width > 0 || panelSelectCategory.Size.Height > 0)
                panelSelectCategory.SetBounds(panelSelectCategory.Location.X, panelSelectCategory.Location.Y, panelSelectCategory.Size.Width - 16, panelSelectCategory.Size.Height - 16);
            else
            {
                timer1.Stop();
                timer1.Tick -= categoryPanelMoveOut;
                timer1.Tick += new EventHandler(loginPanelMoveIn);
                timer1.Start();
            }
        }

        private void loginPanelMoveIn(object sender, EventArgs e)
        {
            if (panelLogin.Size.Width < 200 || panelLogin.Size.Height < 200)
                panelLogin.SetBounds(panelLogin.Location.X, panelLogin.Location.Y, panelLogin.Size.Width + 16, panelLogin.Size.Height + 16);
            else
            {
                timer1.Stop();
            }
        }

        private void categoryPanelMoveIn(object sender, EventArgs e)
        {
            if (authLevel == 0)
                linkLabelCreateUser.Visible = true;
            else
                linkLabelCreateUser.Visible = false;
            if (authLevel == 1)
                linkLabelMaintenance.Visible=linkLabelWastageManagement.Visible = false;
            else
                linkLabelMaintenance.Visible = linkLabelWastageManagement.Visible = true;
            if (panelSelectCategory.Size.Width < 300 || panelSelectCategory.Size.Height < 300)
                panelSelectCategory.SetBounds(panelSelectCategory.Location.X, panelSelectCategory.Location.Y, panelSelectCategory.Size.Width + 16, panelSelectCategory.Size.Height + 16);
            else
            {
                timer1.Stop();
                buttonLogout.Visible = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabelNewConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            opening = 0;
            wait.Visible = true;
            backgroundWorker1.RunWorkerAsync();

        }

        private void linkLabelBilling_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            opening = 1;
            wait.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void linkLabelHelpDesk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            opening = 2;
            wait.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void linkLabelMaintenance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            opening = 3;
            wait.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void linkLabelWastageManagement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            opening = 4;
            wait.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void linkLabelChangeUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelSelectCategory.Enabled = false;
            buttonLogout.Enabled = false;
            newUsername.Text = loginDetails[0];
            newUsername.Enabled = false;
            newAuthLevel.SelectedIndex = int.Parse(loginDetails[2]);
            newAuthLevel.Enabled = false;
            buttonCreate.Text = "Submit";
            buttonCreate.Click -= create_Click;
            buttonCreate.Click += new EventHandler(submit_Click);
            groupBox1.Visible = true;
        }

        private void linkLabelCreateUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelSelectCategory.Enabled = false;
            buttonLogout.Enabled = false;
            groupBox1.Visible = true;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            buttonLogout.Visible = false;
            resetLoginFields();
            timer1.Tick -= categoryPanelMoveIn;
            timer1.Tick += new EventHandler(categoryPanelMoveOut);
            timer1.Start();
            for (int i = 0; i < openForms.Length; i++)
            {
                if (openForms[i] != null)
                    openForms[i].Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            newAuthLevel.Enabled = true;
            panelSelectCategory.Enabled = true;
            buttonLogout.Enabled = true;
            groupBox1.Visible = false;
            newUsername.Enabled = true;
            buttonCreate.Text = "Create";
            buttonCreate.Click -= submit_Click;
            buttonCreate.Click += new EventHandler(create_Click);
            resetCreateFields();
        }

        private void resetCreateFields()
        {
            newUsername.Text = "";
            newPassword.Text = "";
            confPassword.Text = "";
            newAuthLevel.SelectedIndex = -1;
        }

        private bool validateNewUser()
        {
            if (newUsername.TextLength < 4)
            {
                MessageBox.Show("Username is too short. Please enter more than 3 characters.", "User Creation Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (newPassword.TextLength < 4)
            {
                MessageBox.Show("Password is too short. Please enter more than 3 characters.", "User Creation Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (newPassword.Text != confPassword.Text)
            {
                MessageBox.Show("Password confirmation failed. Please confirm the password correctly.", "User Creation Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (newAuthLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Authentication Level cannot be empty.", "User Creation Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void create_Click(object sender, EventArgs e)
        {
            if (validateNewUser())
            {
                if (!loginDb.hasEntry(newUsername.Text))
                {
                    Row loginRow = new LoginRow(newUsername.Text, newPassword.Text, (short)newAuthLevel.SelectedIndex);
                    loginDb.insert(loginRow);
                    MessageBox.Show("User created successfully!", "User Creation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelSelectCategory.Enabled = true;
                    buttonLogout.Enabled = true;
                    groupBox1.Visible = false;
                    resetCreateFields();
                }
                else
                    MessageBox.Show("Username already exists. Please use a different username", "User Creation Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (validateNewUser())
            {
                loginDb.update("password", loginDetails[0], newPassword.Text);
                MessageBox.Show("User updated successfully!", "User Creation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelSelectCategory.Enabled = true;
                buttonLogout.Enabled = true;
                groupBox1.Visible = false;
                buttonCreate.Click -= submit_Click;
                buttonCreate.Click += new EventHandler(create_Click);
                resetCreateFields();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (opening)
            {
                case 0:
                    {
                        openForms[0] = FormNewConnection.Create(authLevel);
                        break;
                    }
                case 1:
                    {
                        openForms[1] = Billing.Create(authLevel, loginDetails[0]);
                        break;
                    }
                case 2:
                    {
                        openForms[2] = HelpDesk.Create(authLevel, loginDetails[0]);
                        break;
                    }
                case 3:
                    {
                        openForms[3] = Maintenance.Create(authLevel);
                        break;
                    }
                case 4:
                    {
                        openForms[4] = FormWastage.Create();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            openForms[opening].Visible = true;
            openForms[opening].Activate();
            wait.Visible = false;
        }

        private void linkLabelApply_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            wait.Visible = true;
            buttonLogin.Enabled = false;
            linkLabelApply.Enabled = false;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Form form = FormNewConnection.Create(1);
            wait.Visible = false;
            form.ShowDialog((IWin32Window)this);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonLogin.Enabled = true;
            linkLabelApply.Enabled = true;
        }
    }
}
