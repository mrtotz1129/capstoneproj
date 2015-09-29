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
    public partial class CloseAccount : Form
    {
        public CloseAccount()
        {
            InitializeComponent();
            defaultAll();
        }
        public void defaultAll()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT FORMAT(MEMBER.MemberID,'00000000'), CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName), MEMBERTYPE.MemberTypeName, SAVINGSTYPE.savingsTypeName, SAVINGSTYPE.interestRate, SAVINGSTYPE.initialDeposit, SAVINGSTYPE.maintainingBalance, SAVINGSTYPE.balanceToEarn, case SAVINGSTYPE.maxWithdrawAmount when 0 then 'Not Available' else CONCAT( (CONVERT(nvarchar, SAVINGSTYPE.maxWithdrawAmount)), case SAVINGSTYPE.maxWithdrawMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end) end, CONCAT(DORMANCY.inactivityValue, ' ',(case DORMANCY.inactivityTime when 0 then 'Day/s' when 1 then 'Week/s' when 2 then 'Month/s' else 'Year/s' end)), CONCAT(DORMANCY.deductionAmount, (case DORMANCY.isPercentage when 0 then ' Pesos ' else ' % ' end), (case DORMANCY.deductionMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)), DORMANCY.activationFee, FORMAT(SAVINGSACCOUNT.SavingsAccountID,'00000000'), SAVINGSACCOUNT.dateOpened, SAVINGSACCOUNT.currentBalance FROM MEMBER, MEMBERTYPE, APPLICABLESAVINGS, SAVINGSTYPE, DORMANCY, SAVINGSACCOUNT WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID and MEMBERTYPE.MemberTypeID = APPLICABLESAVINGS.MemberTypeID and APPLICABLESAVINGS.SavingsTypeID = SAVINGSTYPE.SavingsTypeID and SAVINGSTYPE.SavingsTypeID = DORMANCY.SavingsTypeID and SAVINGSTYPE.SavingsTypeID = SAVINGSACCOUNT.SavingsTypeID and SAVINGSACCOUNT.MemberID = MEMBER.MemberID and SAVINGSACCOUNT.SavingsAccountID = " + SLS.Static.ID + "";
            SqlDataReader reader = con.executeReader(sql);
            if (reader.HasRows)
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
                sql = "SELECT CONCAT('SAV - ', FORMAT(SAVINGSACCOUNT.SavingsAccountID,'00000000')) as [Savings Account ID], CASE SAVINGSTRANSACTION.transactionType when 1 then 'Deposit' when 2 then 'Withdraw' when 3 then 'Annual Increase' else 'Dormancy Deduction' end as [Transaction Type], SAVINGSTRANSACTION.transactionAmount as [Amount], SAVINGSTRANSACTION.transactionDate as [Date], SAVINGSTRANSACTION.transactionRepresentative as [Representative], SAVINGSTRANSACTION.currentBalance as [Balance] FROM SAVINGSACCOUNT, SAVINGSTRANSACTION WHERE SAVINGSACCOUNT.SavingsAccountID = SAVINGSTRANSACTION.SavingsAccountID and SAVINGSACCOUNT.SavingsAccountID = " + SLS.Static.ID + "";
                DataSet ds = con.executeDataSet(sql, "Account");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Account";
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO SAVINGSTRANSACTION(transactionDate, transactionType, transactionAmount, transactionRepresentative, currentBalance, SavingsAccountID) VALUES (@transactionDate, @transactionType, @transactionAmount, @transactionRepresentative, @currentBalance, @SavingsAccountID)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@transactionDate", Convert.ToDateTime(DateTime.Now.ToLongDateString()));
            parameters.Add("@transactionType", '2');
            parameters.Add("@transactionAmount", Convert.ToDecimal(txtCurrentBalance.Text));
            parameters.Add("@transactionRepresentative", txtMemberName.Text);
            parameters.Add("@currentBalance", '0');
            parameters.Add("@SavingsAccountID", SLS.Static.ID);
            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
            if (result == 1)
            {
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "UPDATE SAVINGSACCOUNT SET dateClosed = @dateClosed, currentBalance = '0' WHERE SavingsAccountID = @SavingsAccountID";
                parameters = new Dictionary<string, object>();
                parameters.Add("@dateClosed", Convert.ToDateTime(DateTime.Now.ToLongDateString()));
                parameters.Add("@SavingsAccountID", SLS.Static.ID);
                result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                if (result == 1)
                {
                    MessageBox.Show("Closing a savings account is successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    defaultAll();
                    btnSave.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Closing a savings account is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
