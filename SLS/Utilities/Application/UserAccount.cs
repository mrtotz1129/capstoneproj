using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.Utilities.Application
{
    public partial class UserAccount : Form
    {
        String[] questionString = { "What is your pet’s name?", "In what year was your father born?", "What was the name of your elementary / primary school?", "What was your childhood nickname?", "What was the name of the hospital where you were born?" };
        String[] accountString = { "Administrator", "User" };
        String pass1 = "";
        String pass2 = "";

        public UserAccount()
        {
            InitializeComponent();
            defaultAll();
        }

        public Int32 checkValues()
        {
            //Required Fields Validation
            Int32 isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            if (ctrlString.checkString(txtFN.Text) == 1)
            {
                isValid = 1;
                er2.Visible = true;
            }
            if (ctrlString.checkString(txtLN.Text) == 1)
            {
                isValid = 1;
                er1.Visible = true;
            }
            if (txtMN.Text != "")
            {
                if (ctrlString.checkString(txtMN.Text) == 1)
                {
                    isValid = 1;
                    er3.Visible = true;
                }
            }
            pass1 = txtPass.Text;
            pass2 = txtCPass.Text;
            if(pass1.CompareTo(pass2)==1)
            {
                MessageBox.Show("Password do not match!", "Error");
                er7.Visible = true;
                isValid = 1;
            }
            try
            {
                Convert.ToInt32(cmbAccount.SelectedIndex);
            }
            catch (Exception)
            {
                isValid = 1;
                er5.Visible = true;
            }
            try
            {
                Convert.ToInt32(cmbQuestion.SelectedIndex);
            }
            catch (Exception)
            {
                isValid = 1;
                er5.Visible = true;
            }
            return isValid;
        }

        public void defaultAll()
        {
            txtFN.Clear();
            txtMN.Clear();
            txtLN.Clear();
            txtUser.Clear();
            txtPass.Clear();
            txtCPass.Clear();
            txtAnswer.Clear();
            cmbQuestion.Items.Clear();
            for (int i = 0; i < questionString.Length; i++)
            {
                cmbQuestion.Items.Insert(i, "" + questionString[i]);
            }
            cmbAccount.Items.Clear();
            for (int i = 0; i < accountString.Length; i++)
            {
                cmbAccount.Items.Insert(i, "" + accountString[i]);
            }
            er1.Visible = false;
            er2.Visible = false;
            er3.Visible = false;
            er4.Visible = false;
            er5.Visible = false;
            er6.Visible = false;
            er7.Visible = false;
            er8.Visible = false;
            er9.Visible = false;
            if (SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT fName, mName, lName, username, [password], accountID, securityQuestion, securityAnswer FROM [USER] where UserID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtFN.Text = Convert.ToString(reader[0]);
                    txtMN.Text = Convert.ToString(reader[1]);
                    txtLN.Text = Convert.ToString(reader[2]);
                    txtUser.Text = Convert.ToString(reader[3]);
                    txtPass.Text = Convert.ToString(reader[4]);
                    cmbAccount.SelectedIndex = Convert.ToInt32(reader[5]);
                    cmbQuestion.SelectedIndex = Convert.ToInt32(reader[6]);
                    txtAnswer.Text = Convert.ToString(reader[7]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if (checkValues() == 0)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO [USER] (fName, mName, lName, username, [password], accountID, securityQuestion, securityAnswer, status) VALUES (@fName, @mName, @lName, @username, @password, @accountID, @securityQuestion, @securityAnswer, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@fName", txtFN.Text);
                    parameters.Add("@mName", txtMN.Text);
                    parameters.Add("@lName", txtLN.Text);
                    parameters.Add("@username", txtUser.Text);
                    parameters.Add("@password", txtPass.Text);
                    parameters.Add("@accountID", Convert.ToInt32(cmbAccount.SelectedIndex));
                    parameters.Add("@securityQuestion", Convert.ToInt32(cmbQuestion.SelectedIndex));
                    parameters.Add("@securityAnswer", txtAnswer.Text);
                    parameters.Add("@status", true);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a User Account is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a User Account is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Some required fields are missing/invalid!", "Error");
                }
            }
            else
            {
                if (checkValues() == 0)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE [USER SET fName = @fName, mName = @mName, lName = @lName, username = @username, [password] = @password, accountID = @accountID, securityQuestion = @securityQuestion, securityAnswer = @securityAnswer WHERE UserID = " + SLS.Static.ID + " ";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@fName", txtFN.Text);
                    parameters.Add("@mName", txtMN.Text);
                    parameters.Add("@lName", txtLN.Text);
                    parameters.Add("@username", txtUser.Text);
                    parameters.Add("@password", txtPass.Text);
                    parameters.Add("@accountID", Convert.ToInt32(cmbAccount.SelectedIndex));
                    parameters.Add("@securityQuestion", Convert.ToInt32(cmbQuestion.SelectedIndex));
                    parameters.Add("@securityAnswer", txtAnswer.Text);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Updating a User Account is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        defaultAll();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Updating a User Account is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Some required fields are missing/invalid!", "Error");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }
    }
}