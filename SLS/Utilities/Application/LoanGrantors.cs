using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SLS.Utilities.Application
{
    public partial class LoanGrantors : Form
    {
        public LoanGrantors()
        {
            InitializeComponent();
            defaultAll();
        }

        public void defaultAll()
        {
            txtFN.Clear();
            txtMN.Clear();
            txtLN.Clear();
            txtPosition.Clear();
            er1.Visible = false;
            er2.Visible = false;
            er3.Visible = false;
            er4.Visible = false;
            if (SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT fName, mName, lName, position FROM LOANGRANTOR where lgID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtFN.Text = Convert.ToString(reader[0]);
                    txtMN.Text = Convert.ToString(reader[1]);
                    txtLN.Text = Convert.ToString(reader[2]);
                    txtPosition.Text = Convert.ToString(reader[3]);
                }
            }
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
            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if (checkValues() == 0)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO LOANGRANTOR (fName, mName, lName, position, [status]) VALUES (@fName, @mName, @lName, @position, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@fName", txtFN.Text);
                    parameters.Add("@mName", txtMN.Text);
                    parameters.Add("@lName", txtLN.Text);
                    parameters.Add("@position", txtPosition.Text);
                    parameters.Add("@status", true);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a loan grantor is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a loan grantor is not successful.", "Error", MessageBoxButtons.OK);
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
                    String sql = "UPDATE LOANGRANTOR SET fName = @fName, mName = @mName, lName = @lName, position = @position WHERE lgID = " + SLS.Static.ID + " ";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@fName", txtFN.Text);
                    parameters.Add("@mName", txtMN.Text);
                    parameters.Add("@lName", txtLN.Text);
                    parameters.Add("@position", txtPosition.Text);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Updating a loan grantor is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        defaultAll();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Updating a loan grantor is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Some required fields are missing/invalid!", "Error");
                }
            }
        }
    }
}
