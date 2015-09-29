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

namespace SLS
{
    public partial class Login : Form
    {
        public Int32 isValid;
        public Login()
        {
            InitializeComponent();
            defaultAll();
        }
        public void defaultAll()
        {
            hideError();
        }
        public void hideError()
        {
            e1.Visible = false;
            e2.Visible = false;
        }
        public void validateAll()
        {
            isValid = 0;
            SLS.Validate.NoWhiteSpace Validation = new SLS.Validate.NoWhiteSpace();
            if (Validation.Check(txtUser.Text.ToString()) == 1)
            {
                e1.Visible = true;
                isValid = 1;
            }
            if (Validation.Check(txtPass.Text.ToString()) == 1)
            {
                e2.Visible = true;
                isValid = 1;
            }
        }
        private void txtUser_Enter(object sender, EventArgs e)
        {
            e1.Visible = false;
        }
        private void txtPass_Enter(object sender, EventArgs e)
        {
            e2.Visible = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            validateAll();
            if(isValid == 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT UserID, [password]  FROM [USER] where username COLLATE Latin1_General_CS_AS = @username";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@username", txtUser.Text);
                SqlDataReader reader = con.executeReader(sql, parameters);
                if (reader.HasRows)
                {
                    reader.Read();
                    if(txtPass.Text == Convert.ToString(reader.GetString(1)))
                    {
                        MessageBox.Show("Login success.", "Logged In", MessageBoxButtons.OK);
                        this.Hide();
                        SLS.Static.UserID = Convert.ToInt32(reader.GetInt32(0));
                        var Menu = new MainMenu();
                        Menu.Closed += (s, args) => this.Close();
                        Menu.Show();
                    }
                    else
                    {
                        e2.Visible = true;
                        MessageBox.Show("The password you entered is incorrect.", "Not Logged In", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    e1.Visible = true;
                    e2.Visible = true;
                    MessageBox.Show("The username you entered does not belong to any account.", "Not Logged In", MessageBoxButtons.OK);
                } 
            }
            else
            {
                MessageBox.Show("The username or password is incorrect.", "Not Logged In", MessageBoxButtons.OK);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
