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

namespace SLS.TimeDeposit
{
    public partial class TimeDepositRates : Form
    {
        public TimeDepositRates()
        {
            InitializeComponent();
            defaultAll();
        }
        public void defaultAll()
        {
            txtNoOfDays.Text = "";
            er1.Visible = true;

            txtMinAmount.Text = "";
            er2.Visible = true;

            txtMaxAmount.Text = "";
            er3.Visible = true;

            txtInterest.Text = "";
            er4.Visible = true;

            if (SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT noOfDays, minAmount, maxAmount, interest as [Interest] FROM TIMEDEPOSITRATES WHERE TimeDepositRatesID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtNoOfDays.Text = Convert.ToString(reader[0]);
                    er1.Visible = false;
                    txtMinAmount.Text = Convert.ToString(reader[1]);
                    er2.Visible = false;
                    txtMaxAmount.Text = Convert.ToString(reader[2]);
                    er3.Visible = false;
                    txtInterest.Text = Convert.ToString(reader[3]);
                    er4.Visible = false;
                }
            }
        }

        private void txtNoOfDays_Enter(object sender, EventArgs e)
        {
            er1.Visible = false;
        }

        private void txtMinAmount_Enter(object sender, EventArgs e)
        {
            er2.Visible = false;
        }

        private void txtMaxAmount_Enter(object sender, EventArgs e)
        {
            er3.Visible = false;
        }

        private void txtInterest_Enter(object sender, EventArgs e)
        {
            er4.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if (checkValues() == 1)
                {
                    MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO TIMEDEPOSITRATES (NoOfDays, minAmount, maxAmount, interest, [status]) VALUES (@NoOfDays, @minAmount, @maxAmount, @interest, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@NoOfDays", Convert.ToInt32(txtNoOfDays.Text));
                    parameters.Add("@minAmount", Convert.ToDecimal(txtMinAmount.Text));
                    parameters.Add("@maxAmount", Convert.ToDecimal(txtMaxAmount.Text));
                    parameters.Add("@interest", Convert.ToDecimal(txtInterest.Text));
                    parameters.Add("@status", true);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a time deposit rate is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        defaultAll();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a time deposit rate is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (checkValues() == 1)
                {
                    MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE TIMEDEPOSITRATES SET noOfDays = @noOfDays, minAmount = @minAmount, maxAmount = @maxAmount, interest = @interest WHERE TimeDepositRatesID = @TimeDepositRatesID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@noOfDays", Convert.ToInt32(txtNoOfDays.Text));
                    parameters.Add("@minAmount", Convert.ToDecimal(txtMinAmount.Text));
                    parameters.Add("@maxAmount", Convert.ToDecimal(txtMaxAmount.Text));
                    parameters.Add("@interest", Convert.ToDecimal(txtInterest.Text));
                    parameters.Add("@TimeDepositRatesID", SLS.Static.ID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Updating a time deposit rate is successful.", "Saved", MessageBoxButtons.OK);
                        defaultAll();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Updating a time deposit rate is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        public Int32 checkValues()
        {
            Int32 isValid = 0, i = 0;
            try
            {
                Convert.ToInt32(txtNoOfDays.Text);
            }
            catch (Exception)
            {
                er1.Visible = true;
                isValid = 1;
            }
            try
            {
                Convert.ToDecimal(txtMinAmount.Text);
            }
            catch (Exception)
            {
                er2.Visible = true;
                isValid = 1;
                i = 1;
            }
            try
            {
                Convert.ToDecimal(txtMaxAmount.Text);
            }
            catch (Exception)
            {
                er3.Visible = true;
                isValid = 1;
                i = 1;
            }
            if(i != 1)
            {
                if(Convert.ToDecimal(txtMinAmount.Text) > Convert.ToDecimal(txtMaxAmount.Text))
                {
                    er2.Visible = true;
                    er3.Visible = true;
                    isValid = 1;
                }
            }
            try
            {
                Convert.ToDecimal(txtInterest.Text);
            }
            catch (Exception)
            {
                er4.Visible = true;
                isValid = 1;
            }
            return isValid;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
