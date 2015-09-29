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

namespace SLS.SavingsDeposit.Application
{
    public partial class SavingsType : Form
    {
        Int32 result;
        String[] ModeString = { "Per Day", "Per Week", "Per Month", "Per Year" };
        public SavingsType()
        {
            InitializeComponent();
            defaultAll();
        }
        public void defaultAll()
        {
            txtSavName.Text = "";
            er1.Visible = true;

            txtInterest.Text = "";
            er2.Visible = true;

            txtInitial.Text = "";
            er3.Visible = true;

            ckbMaxWithdraw.Checked = false;

            txtMaxAmount.Text = "";
            er4.Visible = false;

            cobMaxMode.Items.Clear();
            for (int x = 0; x < ModeString.Length; x++)
            {
                cobMaxMode.Items.Insert(x, "" + ModeString[x]);
            }
            er5.Visible = false;

            txtMainBal.Text = "";
            er6.Visible = false;

            txtBalToEarn.Text = "";
            er7.Visible = true;

            ckbApplyAll.Checked = false;

            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT memberTypeName FROM MEMBERTYPE where SavingsApplicable = 1 and [status] = 1 ORDER BY membertypename";
            SqlDataReader reader = con.executeReader(sql);
            cklbMemberType.Items.Clear();
            int i = 0;
            while (reader.Read())
            {
                string str = reader[0].ToString();
                cklbMemberType.Items.Insert(i, "" + str);
                i += 1;
            }

            if (SLS.Static.ID != 0)
            {
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT SavingsTypeID, SavingsTypeName, initialDeposit, maintainingBalance, balanceToEarn, interestRate, maxWithdrawAmount, maxWithdrawMode, hasDormancy, [status] FROM SAVINGSTYPE WHERE SavingsTypeID = " + SLS.Static.ID + " ";
                reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();

                    txtSavName.Text = Convert.ToString(reader[1]);
                    er1.Visible = false;

                    txtInitial.Text = Convert.ToString(reader[2]);
                    er3.Visible = false;

                    txtMainBal.Text = Convert.ToString(reader[3]);
                    er6.Visible = false;

                    txtBalToEarn.Text = Convert.ToString(reader[4]);
                    er7.Visible = false;

                    txtInterest.Text = Convert.ToString(reader[5]);
                    er2.Visible = false;

                    if (Convert.ToDecimal(reader[6]) != 0)
                    {
                        ckbMaxWithdraw.Checked = true;

                        txtMaxAmount.Enabled = true;
                        txtMaxAmount.Text = Convert.ToString(reader[6]);
                        er4.Visible = false;

                        cobMaxMode.Enabled = true;
                        er5.Visible = false;
                        if (Convert.ToInt32(reader[7]) == 1)
                        {
                            cobMaxMode.Text = "Per Day";
                        }
                        else if (Convert.ToInt32(reader[7]) == 2)
                        {
                            cobMaxMode.Text = "Per Week";
                        }
                        else if (Convert.ToInt32(reader[7]) == 3)
                        {
                            cobMaxMode.Text = "Per Month";
                        }
                        else if (Convert.ToInt32(reader[7]) == 4)
                        {
                            cobMaxMode.Text = "Per Year";
                        }
                    }

                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "SELECT MEMBERTYPE.memberTypeName FROM MEMBERTYPE, APPLICABLESAVINGS WHERE MEMBERTYPE.MemberTypeID = APPLICABLESAVINGS.MemberTypeID and APPLICABLESAVINGS.SavingsTypeID = @SavingsTypeID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@SavingsTypeID", SLS.Static.ID);
                    reader = con.executeReader(sql, parameters);
                    for (i = 0; i < cklbMemberType.Items.Count; i++)
                    {
                        cklbMemberType.SetItemChecked(i, false);
                    }
                    while (reader.Read())
                    {
                        int index = cklbMemberType.Items.IndexOf(reader.GetString(0));
                        cklbMemberType.SetItemChecked(index, true);
                    }
                }
            }
        }

        private void ckbApplyAll_Click(object sender, EventArgs e)
        {
            if (ckbApplyAll.Checked == true)
            {
                for (int i = 0; i < cklbMemberType.Items.Count; i++)
                {
                    cklbMemberType.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cklbMemberType.Items.Count; i++)
                {
                    cklbMemberType.SetItemChecked(i, false);
                }
            }
        }

        private void cklbMemberType_Click(object sender, EventArgs e)
        {
            if (cklbMemberType.CheckedItems.Count == cklbMemberType.Items.Count)
            {
                ckbApplyAll.Checked = true;
            }
            else
            {
                ckbApplyAll.Checked = false;
            }
        }

        private void ckbMaxWithdraw_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMaxWithdraw.Checked == true)
            {
                txtMaxAmount.Enabled = true;
                er4.Visible = true;

                cobMaxMode.Enabled = true;
                er5.Visible = true;
            }
            else
            {
                txtMaxAmount.Text = "";
                txtMaxAmount.Enabled = false;
                er4.Visible = false;

                cobMaxMode.Text = "";
                cobMaxMode.Items.Clear();
                for (int x = 0; x < ModeString.Length; x++)
                {
                    cobMaxMode.Items.Insert(x, "" + ModeString[x]);
                }
                cobMaxMode.Enabled = false;
                er5.Visible = false;
            }
        }

        private int checkValues()
        {
            int isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            if (ctrlString.checkString(txtSavName.Text) == 1)
            {
                er1.Visible = true;
                isValid = 1;
            }
            try
            {
                Convert.ToDecimal(txtInterest.Text);
            }
            catch
            {
                er2.Visible = true;
                isValid = 1;
            }
            try
            {
                Convert.ToDecimal(txtInitial.Text);
            }
            catch
            {
                er3.Visible = true;
                isValid = 1;
            }
            if (ckbMaxWithdraw.Checked == true)
            {
                try
                {
                    if(Convert.ToDecimal(txtMaxAmount.Text) == 0)
                    {
                        er4.Visible = true;
                        isValid = 1;
                    }
                }
                catch (Exception)
                {
                    er4.Visible = true;
                    isValid = 1;
                }
            }
            else
            {
                txtMaxAmount.Text = "0";
            }
            try
            {
                Convert.ToDecimal(txtMainBal.Text);
            }
            catch
            {
                er6.Visible = true;
                isValid = 1;
            }
            try
            {
                Convert.ToDecimal(txtBalToEarn.Text);
            }
            catch
            {
                er7.Visible = true;
                isValid = 1;
            }
            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if (checkValues() != 0)
                {
                    MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO SAVINGSTYPE (savingsTypeName, interestRate, initialDeposit, maintainingBalance, balanceToEarn, maxWithdrawAmount, maxWithdrawMode, hasDormancy, [status]) VALUES (@savingsTypeName, @interestRate, @initialDeposit, @maintainingBalance, @balanceToEarn, @maxWithdrawAmount, @maxWithdrawMode, @hasDormancy, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@savingsTypeName", txtSavName.Text);
                    parameters.Add("@interestRate", txtInterest.Text);
                    parameters.Add("@initialDeposit", txtInitial.Text);
                    parameters.Add("@maintainingBalance", txtMainBal.Text);
                    parameters.Add("@balanceToEarn", txtBalToEarn.Text);
                    if (ckbMaxWithdraw.Checked == true)
                    {
                        parameters.Add("@maxWithdrawAmount", txtMaxAmount.Text);
                        parameters.Add("@maxWithdrawMode", (cobMaxMode.SelectedIndex) + 1);
                    }
                    else
                    {
                        parameters.Add("@maxWithdrawAmount", 0);
                        parameters.Add("@maxWithdrawMode", 0);
                    }
                    parameters.Add("@hasDormancy", false);
                    parameters.Add("@status", true);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a savings type is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (object itemChecked in cklbMemberType.CheckedItems)
                        {
                            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                            sql = "INSERT INTO APPLICABLESAVINGS (SavingsTypeID,MemberTypeID) VALUES ((SELECT MAX(SavingsTypeID) FROM SAVINGSTYPE),(SELECT MemberTypeID FROM MEMBERTYPE WHERE memberTypeName = @memberTypeName))";
                            parameters = new Dictionary<string, object>();
                            parameters.Add("@memberTypeName", itemChecked.ToString());
                            result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a savings type is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                if (checkValues() != 0)
                {
                    MessageBox.Show("Some required field/s are missing or invalid", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE SAVINGSTYPE SET savingsTypeName = @savingsTypeName, interestRate = @interestRate, initialDeposit = @initialDeposit, maintainingBalance = @maintainingBalance, balanceToEarn = @balanceToEarn, maxWithdrawAmount = @maxWithdrawAmount, maxWithdrawMode = @maxWithdrawMode, [status] = @status WHERE SavingsTypeID = @SavingsTypeID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@savingsTypeName", txtSavName.Text);
                    parameters.Add("@interestRate", txtInterest.Text);
                    parameters.Add("@initialDeposit", txtInitial.Text);
                    parameters.Add("@maintainingBalance", txtMainBal.Text);
                    parameters.Add("@balanceToEarn", txtBalToEarn.Text);
                    if (ckbMaxWithdraw.Checked == true)
                    {
                        parameters.Add("@maxWithdrawAmount", txtMaxAmount.Text);
                        parameters.Add("@maxWithdrawMode", (cobMaxMode.SelectedIndex) + 1);
                    }
                    else
                    {
                        parameters.Add("@maxWithdrawAmount", 0);
                        parameters.Add("@maxWithdrawMode", 0);
                    }
                    parameters.Add("@status", true);
                    parameters.Add("@SavingsTypeID", SLS.Static.ID);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Updating a savings type is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        sql = "DELETE FROM APPLICABLESAVINGS WHERE SavingsTypeID = @SavingsTypeID";
                        parameters = new Dictionary<string, object>();
                        parameters.Add("@SavingsTypeID", SLS.Static.ID);
                        result = Convert.ToInt32(con.executeNonQuery(sql, parameters));

                        foreach (object itemChecked in cklbMemberType.CheckedItems)
                        {
                            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                            sql = "INSERT INTO APPLICABLESAVINGS (SavingsTypeID,MemberTypeID) VALUES (@SavingsTypeID, (SELECT MemberTypeID FROM MEMBERTYPE WHERE memberTypeName = @memberTypeName))";
                            parameters = new Dictionary<string, object>();
                            parameters.Add("@SavingsTypeID", SLS.Static.ID);
                            parameters.Add("@memberTypeName", itemChecked.ToString());
                            result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Updating a savings type is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSavName_Enter(object sender, EventArgs e)
        {
            er1.Visible = false;
        }

        private void txtInterest_Enter(object sender, EventArgs e)
        {
            er2.Visible = false;
        }

        private void txtInitial_Enter(object sender, EventArgs e)
        {
            er3.Visible = false;
        }

        private void txtMaxAmount_Enter(object sender, EventArgs e)
        {
            er4.Visible = false;
        }
        private void cobMaxMode_Enter(object sender, EventArgs e)
        {
            er5.Visible = false;
        }

        private void txtMainBal_Enter(object sender, EventArgs e)
        {
            er6.Visible = false;
        }

        private void txtBalToEarn_Enter(object sender, EventArgs e)
        {
            er7.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

    }
}