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

namespace SLS.Loan.Application
{
    public partial class LoanChargeName : Form
    {
        public LoanChargeName()
        {
            InitializeComponent();
            defaultAll();
        }

        public void defaultAll()
        {
            txtLoanChargeName.Clear();
            er1.Visible = false;
            if (SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT chargeName FROM CHARGES where ChargeID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtLoanChargeName.Text = Convert.ToString(reader[0]);
                }
            }

        }

        public Int32 checkValues()
        {
            //Required Fields Validation
            Int32 isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            if (ctrlString.checkString(txtLoanChargeName.Text) == 1)
            {
                isValid = 1;
                er1.Visible = true;
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
                    String sql = "INSERT INTO CHARGES (chargeName, [status]) VALUES (@chargeName, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@chargeName", txtLoanChargeName.Text);
                    parameters.Add("@status", true);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a term of payment is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a term of payment is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Some required fields are missing/invalid!", "Error");
                }
            }
            else
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "UPDATE CHARGES SET chargeName = @chargeName WHERE ChargeID = " + SLS.Static.ID + " ";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@chargeName", txtLoanChargeName.Text);
                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                if (result == 1)
                {
                    MessageBox.Show("Updating a mode of payment is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    defaultAll();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Updating a mode of payment is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
