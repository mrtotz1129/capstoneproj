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
    public partial class Transaction : Form
    {
        String[] TransTypeString = { "Deposit","Withdraw" };

        public Transaction()
        {
            InitializeComponent();
            defaultAll();
        }
        public void defaultAll()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT FORMAT(MEMBER.MemberID,'00000000'), CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName), MEMBERTYPE.MemberTypeName, SAVINGSTYPE.savingsTypeName, SAVINGSTYPE.interestRate, SAVINGSTYPE.initialDeposit, SAVINGSTYPE.maintainingBalance, SAVINGSTYPE.balanceToEarn, case SAVINGSTYPE.maxWithdrawAmount when 0 then 'Not Available' else CONCAT( (CONVERT(nvarchar, SAVINGSTYPE.maxWithdrawAmount)), case SAVINGSTYPE.maxWithdrawMode when 1 then ' / Day' when 2 then ' / Week' when 3 then ' / Month' else ' / Year' end) end, CONCAT(DORMANCY.inactivityValue, ' ',(case DORMANCY.inactivityTime when 0 then 'Day/s' when 1 then 'Week/s' when 2 then 'Month/s' else 'Year/s' end)), CONCAT(DORMANCY.deductionAmount, (case DORMANCY.isPercentage when 0 then ' Pesos ' else ' % ' end), (case DORMANCY.deductionMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)), DORMANCY.activationFee, FORMAT(SAVINGSACCOUNT.SavingsAccountID,'00000000'), SAVINGSACCOUNT.dateOpened, SAVINGSACCOUNT.currentBalance FROM MEMBER, MEMBERTYPE, APPLICABLESAVINGS, SAVINGSTYPE, DORMANCY, SAVINGSACCOUNT WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID and MEMBERTYPE.MemberTypeID = APPLICABLESAVINGS.MemberTypeID and APPLICABLESAVINGS.SavingsTypeID = SAVINGSTYPE.SavingsTypeID and SAVINGSTYPE.SavingsTypeID = DORMANCY.SavingsTypeID and SAVINGSTYPE.SavingsTypeID = SAVINGSACCOUNT.SavingsTypeID and SAVINGSACCOUNT.MemberID = MEMBER.MemberID and SAVINGSACCOUNT.SavingsAccountID = " + SLS.Static.ID + "";
            SqlDataReader reader = con.executeReader(sql);
            if(reader.HasRows)
            {
                reader.Read();
                txtMemberID.Text = "MEM - " + reader.GetString(0);
                txtMemberName.Text = reader.GetString(1);
                txtMemberType.Text = reader.GetString(2);
                txtSavName.Text = reader.GetString(3);
                txtInterest.Text = reader.GetDecimal(4).ToString();
                txtInitial.Text = reader.GetDecimal(5).ToString();
                txtMainBal.Text = reader.GetDecimal(6).ToString();
                txtBalToEarn.Text = reader.GetDecimal(7).ToString();
                txtMaxWithdraw.Text = reader.GetString(8);
                txtDormancy.Text = reader.GetString(9);
                txtDeductDetails.Text = reader.GetString(10);
                txtActivationFee.Text = reader.GetDecimal(11).ToString();
                txtSavAccount.Text = "SAV - " + reader.GetString(12);
                txtDateStarted.Text = reader.GetDateTime(13).ToString();
                txtCurrentBalance.Text = reader.GetDecimal(14).ToString();
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT CONCAT('SAV - ', FORMAT(SAVINGSACCOUNT.SavingsAccountID,'00000000')) as [Savings Account ID], CASE SAVINGSTRANSACTION.transactionType when 1 then 'Deposit' when 2 then 'Withdraw' when 3 then 'Annual Increase' else 'Dormancy Deduction' end as [Transaction Type], SAVINGSTRANSACTION.transactionAmount as [Amount], SAVINGSTRANSACTION.transactionDate as [Date], SAVINGSTRANSACTION.transactionRepresentative as [Representative], SAVINGSTRANSACTION.currentBalance as [Balance] FROM SAVINGSACCOUNT, SAVINGSTRANSACTION WHERE SAVINGSACCOUNT.SavingsAccountID = SAVINGSTRANSACTION.SavingsAccountID and SAVINGSACCOUNT.SavingsAccountID = "+ SLS.Static.ID +"";
                DataSet ds = con.executeDataSet(sql, "Account");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Account";
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            txtTransDate.Text = DateTime.Now.ToLongDateString();
            txtTransDate.Enabled = false;

            cobTransType.Items.Clear();
            for (int i = 0; i < TransTypeString.Length; i++)
            {
                cobTransType.Items.Insert(i, "" + TransTypeString[i]);
            }
            cobTransType.Text = "";
            er1.Visible = true;

            txtRep.Text = "";
            er2.Visible = true;
            ckbRep.Checked = false;

            txtAmount.Text = "";
            er3.Visible = true;
        }
        private void ckbRep_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbRep.Checked == true)
            {
                txtRep.Text = txtMemberName.Text.ToString();
                txtRep.Enabled = false;
                er2.Visible = false;
            }
            else
            {
                txtRep.Text = "";
                txtRep.Enabled = true;
                er2.Visible = true;
            }
        }
        private void cobTransType_Enter(object sender, EventArgs e)
        {
            er1.Visible = false;
        }
        private void txtRep_Enter(object sender, EventArgs e)
        {
            er2.Visible = false;
        }
        private void txtAmount_Enter(object sender, EventArgs e)
        {
            er3.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(checkValues() == 1)
            {
                MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "INSERT INTO SAVINGSTRANSACTION(transactionDate, transactionType, transactionAmount, transactionRepresentative, currentBalance, SavingsAccountID) VALUES (@transactionDate, @transactionType, @transactionAmount, @transactionRepresentative, @currentBalance, @SavingsAccountID)";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@transactionDate", Convert.ToDateTime(txtTransDate.Text));
                parameters.Add("@transactionType", Convert.ToInt32(cobTransType.SelectedIndex) + 1);
                parameters.Add("@transactionAmount", txtAmount.Text);
                parameters.Add("@transactionRepresentative", txtRep.Text);
                if(cobTransType.SelectedIndex == 0)
                {
                    parameters.Add("@currentBalance", Convert.ToDecimal(txtCurrentBalance.Text) + Convert.ToDecimal(txtAmount.Text));
                }
                else
                {
                    parameters.Add("@currentBalance", Convert.ToDecimal(txtCurrentBalance.Text) - Convert.ToDecimal(txtAmount.Text));
                }
                parameters.Add("@SavingsAccountID", SLS.Static.ID);
                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                if(result == 1)
                {
                    MessageBox.Show("Transaction is successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "UPDATE SAVINGSACCOUNT SET currentBalance = @currentBalance WHERE SavingsAccountID = @SavingsAccountID";
                    parameters = new Dictionary<string, object>();
                    if(cobTransType.SelectedIndex == 0)
                    {
                        parameters.Add("@currentBalance", Convert.ToDecimal(txtCurrentBalance.Text) + Convert.ToDecimal(txtAmount.Text));
                    }
                    else
                    {
                        parameters.Add("@currentBalance", Convert.ToDecimal(txtCurrentBalance.Text) - Convert.ToDecimal(txtAmount.Text));
                    }
                    parameters.Add("@SavingsAccountID", SLS.Static.ID);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    defaultAll();
                }
                else
                {
                    MessageBox.Show("Transaction is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public Int32 checkValues()
        {
            Int32 isValid = 0;
            try
            {
                try
                {
                    if(cobTransType.SelectedIndex == 1)
                    {
                        if(Convert.ToDecimal(txtCurrentBalance.Text) - Convert.ToDecimal(txtAmount.Text) < Convert.ToDecimal(txtMainBal.Text))
                        {
                            er3.Visible = true;
                            isValid = 1;
                        }
                        else
                        {
                            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                            String sql = "SELECT SAVINGSTYPE.maxWithdrawMode, SAVINGSTYPE.maxWithdrawAmount FROM SAVINGSACCOUNT, SAVINGSTYPE WHERE SAVINGSACCOUNT.SavingsTypeID = SAVINGSTYPE.SavingsTypeID AND SAVINGSACCOUNT.SavingsAccountID = " + SLS.Static.ID + "";
                            SqlDataReader reader1 = con.executeReader(sql);
                            if(reader1.HasRows)
                            {
                                reader1.Read();
                                if(reader1.GetInt32(0) == 1)
                                {
                                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                                    sql = "SELECT ISNULL(SUM(transactionAmount),0) FROM SAVINGSTRANSACTION WHERE DATENAME(DAY,transactionDate) = DATENAME(DAY, " + Convert.ToString(DateTime.Now.ToLongDateString()) + " ) AND transactionType = 2 AND SavingsAccountID = " + SLS.Static.ID + "";
                                    SqlDataReader reader = con.executeReader(sql);
                                    if(reader.HasRows)
                                    {
                                        reader.Read();
                                        if(Convert.ToDecimal(reader.GetValue(0)) + Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(reader1.GetValue(1)))
                                        {
                                            er3.Visible = true;
                                            isValid = 1;
                                        }
                                    }
                                }
                                else if(reader1.GetInt32(0) == 2)
                                {
                                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                                    sql = "SELECT ISNULL(SUM(transactionAmount),0) FROM SAVINGSTRANSACTION WHERE DATENAME(WEEK,transactionDate) = DATENAME(WEEK, " + DateTime.Now.ToLongDateString() + " ) AND transactionType = 2 AND SavingsAccountID = " + SLS.Static.ID + "";
                                    SqlDataReader reader = con.executeReader(sql);
                                    if(reader.HasRows)
                                    {
                                        reader.Read();
                                        if(Convert.ToDecimal(reader1.GetValue(0)) + Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(reader1.GetValue(1)))
                                        {
                                            er3.Visible = true;
                                            isValid = 1;
                                        }
                                    }
                                }
                                else if(Convert.ToInt32(reader1.GetValue(0)) == 3)
                                {
                                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                                    sql = "SELECT ISNULL(SUM(transactionAmount),0) FROM SAVINGSTRANSACTION WHERE DATENAME(MONTH,transactionDate) = DATENAME(MONTH, @DateNow) AND transactionType = 2 AND SavingsAccountID = " + SLS.Static.ID + "";
                                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                                    parameters.Add("@DateNow", Convert.ToDateTime(txtTransDate.Text));
                                    SqlDataReader reader = con.executeReader(sql, parameters);
                                    if(reader.HasRows)
                                    {
                                        reader.Read();
                                        if(Convert.ToDecimal(reader.GetValue(0)) + Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(reader1.GetValue(1)))
                                        {
                                            er3.Visible = true;
                                            isValid = 1;
                                        }
                                    }
                                }
                                else if(reader1.GetInt32(0) == 4)
                                {
                                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                                    sql = "SELECT ISNULL(SUM(transactionAmount),0) FROM SAVINGSTRANSACTION WHERE DATENAME(YEAR,transactionDate) = DATENAME(YEAR, " + DateTime.Now.ToLongDateString() + ") AND transactionType = 2 AND SavingsAccountID = " + SLS.Static.ID + "";
                                    SqlDataReader reader = con.executeReader(sql);
                                    if(reader.HasRows)
                                    {
                                        reader.Read();
                                        if(Convert.ToDecimal(reader1.GetValue(0)) + Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(reader1.GetValue(1)))
                                        {
                                            er3.Visible = true;
                                            isValid = 1;
                                        }
                                        else
                                        {
                                            MessageBox.Show("" + Convert.ToString(reader.GetValue(0)));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if(cobTransType.SelectedIndex == 0)
                    {
                        try
                        {
                            Convert.ToDecimal(txtAmount.Text);
                        }
                        catch(Exception)
                        {
                            er3.Visible = true;
                            isValid = 1;
                        }
                    }
                    else
                    {
                        er3.Visible = true;
                        isValid = 1;
                    }
                }
                catch (Exception)
                {
                    er3.Visible = true;
                    isValid = 1;
                }
            }
            catch (Exception)
            {
                isValid = 1;
                er1.Visible = true;
            }
            return isValid;
        }

        private void cobTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cobTransType.SelectedIndex == 0)
            {
                ckbRep.Checked = false;
                ckbRep.Enabled = true;

                txtRep.Text = "";
                txtRep.Enabled = true;

                er2.Visible = true;
            }
            if(cobTransType.SelectedIndex == 1)
            {
                ckbRep.Checked = true;
                ckbRep.Enabled = false;

                txtRep.Text = txtMemberName.Text.ToString();
                txtRep.Enabled = false;

                er2.Visible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }     
    }
}
