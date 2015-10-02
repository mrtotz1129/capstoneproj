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
    public partial class Member : Form
    {
        public Member()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            SLS.Static.sqlParams = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, @DateNow ) as [Age], MEMBERTYPE.MemberTypeName as [Member Type] FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            SLS.Member.Database.TransactionDB Mt = new SLS.Member.Database.TransactionDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Mt.TopLevel = false;
            Mt.Dock = DockStyle.None;
            Mt.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Mt);
        }

        private void maintenance_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT MemberTypeID as [Member Type ID], MemberTypeName as [Member Type\nName], CONCAT(MinAgeRequired, ' - ', MaxAgeRequired,' years old') as [Age Requirement], SavingsApplicable as [Savings Deposit], TimeApplicable as [Time Deposit], LoanApplicable as [Loan Services], case LoanApplicable when 0 then 'Not Available' else CONVERT(nvarchar,ShareRequired) end as [Share Capital], [status] as [Status] FROM MEMBERTYPE";
            SLS.Member.Database.MaintenanceDB Mm = new SLS.Member.Database.MaintenanceDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Mm.TopLevel = false;
            Mm.Dock = DockStyle.None;
            Mm.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Mm);
        }

        private void transaction_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, @DateNow ) as [Age], MEMBERTYPE.MemberTypeName as [Member Type] FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            SLS.Member.Database.TransactionDB Mt = new SLS.Member.Database.TransactionDB();
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
