using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.SavingsDeposit.Application
{
    public partial class SearchAccount : Form
    {
        public SearchAccount()
        {
            InitializeComponent();
            loadDatabase();
        }
        public void loadDatabase()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT SAVINGSACCOUNT.SavingsAccountID, CONCAT('SAV - ', FORMAT(SAVINGSACCOUNT.SavingsAccountID,'00000000')) as [Savings Account ID], SAVINGSACCOUNT.MemberID as [Member ID], CONCAT(MEMBER.fName,' ' , MEMBER.mName, ' ', MEMBER.lName) as [Member Name], SAVINGSACCOUNT.SavingsTypeID as [Savings Type ID], SAVINGSTYPE.savingsTypeName as [Savings Type Name], SAVINGSTYPE.interestRate as [Interest Rate], SAVINGSTYPE.initialDeposit as [Initial Deposit], SAVINGSTYPE.maintainingBalance as [Maintaining Balance], SAVINGSTYPE.balanceToEarn as [Balance To Earn], case SAVINGSTYPE.maxWithdrawAmount when 0 then 'Not Available' else CONCAT( (CONVERT(nvarchar, SAVINGSTYPE.maxWithdrawAmount)), (case SAVINGSTYPE.maxWithdrawMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)) end as [Maximum Withdrawal], CONCAT(DORMANCY.inactivityValue, ' ',(case DORMANCY.inactivityTime when 0 then 'Day/s' when 1 then 'Week/s' when 2 then 'Month/s' else 'Year/s' end)) as [Inactivity Period], CONCAT(DORMANCY.deductionAmount, (case DORMANCY.isPercentage when 0 then ' Pesos ' else ' % ' end), (case DORMANCY.deductionMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)) as [Deduction], DORMANCY.activationFee[Activation Fee], SAVINGSACCOUNT.dateOpened as [Date Started], SAVINGSACCOUNT.currentBalance as [Current Balance] FROM SAVINGSACCOUNT, MEMBER, SAVINGSTYPE, DORMANCY WHERE SAVINGSACCOUNT.MemberID = MEMBER.MemberID and SAVINGSACCOUNT.SavingsTypeID = SAVINGSTYPE.SavingsTypeID and DORMANCY.SavingsTypeID = SAVINGSTYPE.SavingsTypeID and MEMBER.MemberID = " + SLS.Static.ID + " and SAVINGSACCOUNT.dateClosed IS NULL";
            DataSet ds = con.executeDataSet(sql, "Account");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Account";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
