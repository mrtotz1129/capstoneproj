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
    public partial class Time : Form
    {
        public Time()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            SLS.Static.sql = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, @DateNow ) as [Age], MEMBERTYPE.MemberTypeName as [Member Type] FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            SLS.TimeDeposit.Database.TransactionDB Mt = new SLS.TimeDeposit.Database.TransactionDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Mt.TopLevel = false;
            Mt.Dock = DockStyle.None;
            Mt.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Mt);
        }

        private void timeDepositRates_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT TimeDepositRatesID as [ID], CONCAT(noOfDays, ' Days') as [No. Of Days], CONCAT(minAmount,' - ', maxAmount) as [Amount Range], CONCAT(interest, ' %') as [Interest], [status] as [Status] FROM TIMEDEPOSITRATES";
            SLS.TimeDeposit.Database.TimeDepositRatesDB Tr = new SLS.TimeDeposit.Database.TimeDepositRatesDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Tr.TopLevel = false;
            Tr.Dock = DockStyle.None;
            Tr.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Tr);
        }

        private void timeDepositPenalty_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT TimeDepositPenaltyID as [ID], CONCAT(minElapsed, ' - ', maxElapsed) as [Elapsed Time], reducedBy as [Interest Reduced By], [status] as [Status] FROM TIMEDEPOSITPENALTY";
            SLS.TimeDeposit.Database.TimeDepositPenaltyDB Tp = new SLS.TimeDeposit.Database.TimeDepositPenaltyDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Tp.TopLevel = false;
            Tp.Dock = DockStyle.None;
            Tp.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Tp);
        }

        private void transaction_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, @DateNow ) as [Age], MEMBERTYPE.MemberTypeName as [Member Type] FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            SLS.TimeDeposit.Database.TransactionDB Mt = new SLS.TimeDeposit.Database.TransactionDB();
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
