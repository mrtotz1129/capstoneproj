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
    public partial class TimeDepositPenalty : Form
    {
        public Decimal min, max;
        public TimeDepositPenalty()
        {
            InitializeComponent();
            defaultAll();
        }

        public void defaultAll()
        {
            txtMin.Text = "";
            er1.Visible = true;

            txtMax.Text = "";
            er2.Visible = true;

            txtReducedBy.Text = "";
            er3.Visible = true;

            if(SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT minElapsed, maxElapsed, reducedBy FROM TIMEDEPOSITPENALTY WHERE TimeDepositPenaltyID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtMin.Text = Convert.ToString(reader[0]);
                    min = Convert.ToDecimal(reader[0]);
                    er1.Visible = false;
                    txtMax.Text = Convert.ToString(reader[1]);
                    max = Convert.ToDecimal(reader[1]);
                    er2.Visible = false;
                    txtReducedBy.Text = Convert.ToString(reader[2]);
                    er3.Visible = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if(checkValues() == 1)
                {
                    MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO TIMEDEPOSITPENALTY (minElapsed, maxElapsed, reducedBy, [status]) VALUES (@minElapsed, @maxElapsed, @reducedBy, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@minElapsed", Convert.ToDecimal(txtMin.Text));
                    parameters.Add("@maxElapsed", Convert.ToDecimal(txtMax.Text));
                    parameters.Add("@reducedBy", Convert.ToDecimal(txtReducedBy.Text));
                    parameters.Add("@status", true);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a time deposit penalty is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a time deposit penalty is successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    String sql = "UPDATE TIMEDEPOSITPENALTY SET minElapsed = @minElapsed, maxElapsed = @maxElapsed, reducedBy = @reducedBy WHERE TimeDepositPenaltyID = @TimeDepositPenaltyID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@minElapsed", Convert.ToDecimal(txtMin.Text));
                    parameters.Add("@maxElapsed", Convert.ToDecimal(txtMax.Text));
                    parameters.Add("@reducedBy", Convert.ToDecimal(txtReducedBy.Text));
                    parameters.Add("@TimeDepositPenaltyID", SLS.Static.ID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Updating a time deposit is successful.", "Saved", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Updating a time deposit is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        public Int32 checkValues()
        {
            Int32 isValid = 0, check = 0;
            try
            {
                Convert.ToDecimal(txtMin.Text);
                if(Convert.ToDecimal(txtMin.Text) > 99)
                {
                    er1.Visible = true;
                    isValid = 1;
                    check = 1;
                }

            }
            catch
            {
                er1.Visible = true;
                isValid = 1;
                check = 1;
            }
            try
            {
                Convert.ToDecimal(txtMax.Text);
                if (Convert.ToDecimal(txtMax.Text) > 100)
                {
                    er2.Visible = true;
                    isValid = 1;
                    check = 1;
                }
            }
            catch
            {
                er2.Visible = true;
                isValid = 1;
                check = 1;
            }
            if (check == 0 && Convert.ToDecimal(txtMin.Text) > Convert.ToDecimal(txtMax.Text))
            {
                er1.Visible = true;
                er2.Visible = true;
                isValid = 1;
                check = 1;
            }
            if (check == 0 && SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT minElapsed, maxElapsed FROM TIMEDEPOSITPENALTY WHERE [status] = 1";
                SqlDataReader reader = con.executeReader(sql);
                if(reader.HasRows)
                {
                    while (reader.Read() && isValid == 0)
                    {
                        if (min != Convert.ToDecimal(reader[0]) && max != Convert.ToDecimal(reader[1]))
                        {
                            for (Decimal i = Convert.ToDecimal(txtMin.Text); (i <= Convert.ToDecimal(txtMax.Text)) && isValid == 0; i = i + Convert.ToDecimal(0.01))
                            {
                                if (i >= Convert.ToDecimal(reader[0]) && i <= Convert.ToDecimal(reader[1]))
                                {
                                    er1.Visible = true;
                                    er2.Visible = true;
                                    isValid = 1;
                                }
                            }
                        }
                    }
                }
            }
            else if (check == 0 && SLS.Static.ID == 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT minElapsed, maxElapsed FROM TIMEDEPOSITPENALTY WHERE [status] = 1";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    while (reader.Read() && isValid == 0)
                    {
                        for (Decimal i = Convert.ToDecimal(txtMin.Text); (i <= Convert.ToDecimal(txtMax.Text)) && isValid == 0; i = i + Convert.ToDecimal(0.01))
                        {
                            if (i >= Convert.ToDecimal(reader[0]) && i <= Convert.ToDecimal(reader[1]))
                            {
                                er1.Visible = true;
                                er2.Visible = true;
                                isValid = 1;
                            }
                        }
                    }
                }
            }
            try
            {
                Convert.ToDecimal(txtReducedBy.Text);
                if (Convert.ToDecimal(txtReducedBy.Text) > 100)
                {
                    er3.Visible = true;
                    isValid = 1;
                }
            }
            catch
            {
                er3.Visible = true;
                isValid = 1;
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

        private void txtMin_Enter(object sender, EventArgs e)
        {
            er1.Visible = false;
        }

        private void txtMax_Enter(object sender, EventArgs e)
        {
            er2.Visible = false;
        }

        private void txtReducedBy_Enter(object sender, EventArgs e)
        {
            er3.Visible = false;
        }
    }
}
