using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.MainMenuForm
{
    public partial class Savings : Form
    {
        public Savings()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            SLS.Static.sql = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, @DateNow ) as [Age], MEMBERTYPE.MemberTypeName as [Member Type] FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            SLS.SavingsDeposit.Database.TransactionDB Mt = new SLS.SavingsDeposit.Database.TransactionDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Mt.TopLevel = false;
            Mt.Dock = DockStyle.None;
            Mt.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Mt);
        }

        private void savingsType_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT SavingsTypeID as [ID], savingsTypeName as [Savings Type], interestRate as [Interest Rate], initialDeposit as [Initial Deposit], maintainingBalance as [Maintaining Balance], balanceToEarn as [Balance To Earn Rate], case maxWithdrawAmount when 0 then 'Not Available' else CONCAT( (CONVERT(nvarchar, maxWithdrawAmount)), (case maxWithdrawMode when 1 then ' / Day' when 2 then ' / Week' when 3 then ' / Month' else ' / Year' end)) end as [Maximum Withdrawal], [status] as [Status] FROM SAVINGSTYPE";
            SLS.SavingsDeposit.Database.SavingsTypeDB Ss = new SLS.SavingsDeposit.Database.SavingsTypeDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Ss.TopLevel = false;
            Ss.Dock = DockStyle.None;
            Ss.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Ss);
        }

        private void dormancy_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT DORMANCY.DormancyID as [ID], SAVINGSTYPE.savingsTypeName as [Savings Type], CONCAT(DORMANCY.inactivityValue, ' ',(case DORMANCY.inactivityTime when 0 then 'Day/s' when 1 then 'Week/s' when 2 then 'Month/s' else 'Year/s' end)) as [Inactivity Period], CONCAT(DORMANCY.deductionAmount, (case DORMANCY.isPercentage when 0 then ' Pesos ' else ' % ' end), (case DORMANCY.deductionMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)) as [Deduction], DORMANCY.activationFee as [Activation Fee], DORMANCY.[status] as [Status] FROM DORMANCY, SAVINGSTYPE WHERE DORMANCY.SavingsTypeID = SAVINGSTYPE.SavingsTypeID";
            SLS.SavingsDeposit.Database.DormancyDB Sd = new SLS.SavingsDeposit.Database.DormancyDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Sd.TopLevel = false;
            Sd.Dock = DockStyle.None;
            Sd.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Sd);
        }

        private void transaction_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, @DateNow ) as [Age], MEMBERTYPE.MemberTypeName as [Member Type] FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            SLS.SavingsDeposit.Database.TransactionDB Mt = new SLS.SavingsDeposit.Database.TransactionDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Mt.TopLevel = false;
            Mt.Dock = DockStyle.None;
            Mt.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Mt);
        }
    }
}
