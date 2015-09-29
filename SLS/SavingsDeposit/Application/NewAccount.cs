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
    public partial class NewAccount : Form
    {
        public Int32 MemberID, SavingsID = 0;
        public String SavingsName, DormancyName;
        public NewAccount()
        {
            InitializeComponent();
            defaultAll();
        }
        public void defaultAll()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT FORMAT(MEMBER.MemberID,'00000000') as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, '" + (DateTime.Now).ToString("yyyy-MM-dd") + "' ) as [Age] , MEMBERTYPE.MemberTypeID, MEMBERTYPE.MemberTypeName FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID AND MEMBER.MemberID = " + SLS.Static.ID + " ";
            SqlDataReader reader = con.executeReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                MemberID = Convert.ToInt32(reader[0]);
                txtMemberID.Text = "MEM - " + Convert.ToString(reader[0]);
                txtMemberName.Text = Convert.ToString(reader[1]);
                txtMemberType.Text = Convert.ToString(reader[4]);
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT SAVINGSTYPE.SavingsTypeID, SAVINGSTYPE.savingsTypeName FROM SAVINGSTYPE, APPLICABLESAVINGS WHERE SAVINGSTYPE.SavingsTypeID = APPLICABLESAVINGS.SavingsTypeID AND APPLICABLESAVINGS.MemberTypeID = " + Convert.ToString(reader[3]) + " and SAVINGSTYPE.hasDormancy = 'true' and SAVINGSTYPE.[status] = 1";
                reader = con.executeReader(sql);
                cobSavingsType.Items.Clear();
                int i = 0;
                while (reader.Read())
                {
                    string str = reader[1].ToString();
                    cobSavingsType.Items.Insert(i, "" + str);
                    i += 1;
                }
                cobSavingsType.Text = "";
                cobSavingsType.Enabled = true;
                er2.Visible = true;
                SavingsID = 0;
            }

            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            sql = "SELECT MAX(SavingsAccountID) FROM SAVINGSACCOUNT";
            reader = con.executeReader(sql);
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    txtSavAccount.Text = "SAV - " + (reader.GetInt32(0) + 1).ToString("00000000");
                }
            }
            catch(Exception)
            {
                txtSavAccount.Text = "SAV - 00000001";
            }
            txtDate.Text = DateTime.Now.ToLongDateString();
            
        }

        private void cobSavingsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SavingsName = cobSavingsType.Text.ToString();
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT SAVINGSTYPE.SavingsTypeID, SAVINGSTYPE.interestRate, SAVINGSTYPE.initialDeposit, SAVINGSTYPE.maintainingBalance, balanceToEarn, CONCAT(DORMANCY.inactivityValue, ' ',(case DORMANCY.inactivityTime when 0 then 'Day/s' when 1 then 'Week/s' when 2 then 'Month/s' else 'Year/s' end)) as [Inactivity Period], CONCAT(DORMANCY.deductionAmount, (case DORMANCY.isPercentage when 0 then ' Pesos ' else ' % ' end), (case DORMANCY.deductionMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)) as [Deduction], DORMANCY.activationFee as [Activation Fee], case SAVINGSTYPE.maxWithdrawAmount when 0 then 'Not Available' else CONCAT( (CONVERT(nvarchar, SAVINGSTYPE.maxWithdrawAmount)), (case SAVINGSTYPE.maxWithdrawMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)) end FROM SAVINGSTYPE, DORMANCY WHERE SAVINGSTYPE.SavingsTypeID = DORMANCY.SavingsTypeID and SAVINGSTYPE.savingsTypeName = @savingsTypeName";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@savingsTypeName", SavingsName);
            SqlDataReader reader = con.executeReader(sql, parameters);
            while (reader.Read())
            {
                SavingsID = reader.GetInt32(0);
                txtInterest.Text = reader.GetDecimal(1).ToString();
                txtInitial.Text = reader.GetDecimal(2).ToString();
                txtMainBal.Text = reader.GetDecimal(3).ToString();
                txtBalToEarn.Text = reader.GetDecimal(4).ToString();
                txtDormancy.Text = reader.GetValue(5).ToString();
                txtDeductDetails.Text = reader.GetValue(6).ToString();
                txtActivationFee.Text = reader.GetValue(7).ToString();
                txtMaxWithdraw.Text = reader.GetValue(8).ToString();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkValues() == 1)
            {
                MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "INSERT INTO SAVINGSACCOUNT(MemberID, SavingsTypeID, dateOpened, currentBalance) VALUES (@MemberID, @SavingsTypeID, @dateOpened, @currentBalance)";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@MemberID", MemberID);
                parameters.Add("@SavingsTypeID", SavingsID);
                parameters.Add("@dateOpened", Convert.ToDateTime(txtDate.Text));
                parameters.Add("@currentBalance", txtDeposit.Text);
                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                if (result == 1)
                {
                    MessageBox.Show("Creating a new savings account is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "INSERT INTO SAVINGSTRANSACTION(transactionDate, transactionType, transactionAmount, transactionRepresentative, currentBalance, SavingsAccountID) VALUES (@transactionDate, @transactionType, @transactionAmount, (SELECT CONCAT(fName,' ',mName,' ', lName) FROM MEMBER WHERE MemberID = @MemberID), @currentBalance, (SELECT MAX(SavingsAccountID) FROM SAVINGSACCOUNT))";
                    parameters = new Dictionary<string, object>();
                    parameters.Add("@transactionDate", Convert.ToDateTime(txtDate.Text));
                    parameters.Add("@transactionType", 1);
                    parameters.Add("@transactionAmount", txtDeposit.Text);
                    parameters.Add("@MemberID", MemberID);
                    parameters.Add("@currentBalance", txtDeposit.Text);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Creating a new savings account is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int checkValues()
        {
            int isValid = 0;
            if(SavingsID == 0)
            {
                er2.Visible = true;
                isValid = 1;
            }
            try
            {
                if(Convert.ToDecimal(txtDeposit.Text) < Convert.ToDecimal(txtInitial.Text))
                {
                    er1.Visible = true;
                    isValid = 1;
                }
            }
            catch (Exception)
            {
                er1.Visible = true;
                isValid = 1;
            }
            return isValid;
        }

        private void txtDeposit_Enter(object sender, EventArgs e)
        {
            er1.Visible = false;
        }

        private void cobSavingsType_Enter(object sender, EventArgs e)
        {
            er2.Visible = false;
        }
    }
}
