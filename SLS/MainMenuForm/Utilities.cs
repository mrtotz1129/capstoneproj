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
    public partial class Utilities : Form
    {
        public Utilities()
        {
            InitializeComponent();
        }

        private void creditInvestigators_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT ciID as [Credit Investigator ID], fName as [First Name], mName as [Middle Name], lName as [Last Name], status as [status] FROM CREDITINVESTIGATOR";
            SLS.Utilities.Database.CreditInvestigationDB ciDB = new SLS.Utilities.Database.CreditInvestigationDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            ciDB.TopLevel = false;
            ciDB.Dock = DockStyle.None;
            ciDB.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(ciDB);
        }

        private void loanGrantors_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT lgID as [Loan Grantor ID], fName as [First Name], mName as [Middle Name], lName as [Last Name], position as [Position], status as [status] FROM LOANGRANTOR";
            SLS.Utilities.Database.LoanGrantorsDB lgDB = new SLS.Utilities.Database.LoanGrantorsDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            lgDB.TopLevel = false;
            lgDB.Dock = DockStyle.None;
            lgDB.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(lgDB);
        }

        private void userAccount_Click(object sender, EventArgs e)
        {
            SLS.Static.sql = "SELECT UserID as [User Account ID], fName as [First Name], mName as [Middle Name], lName as [Last Name], accountID as [Account Type], status as [status] FROM [USER]";
            SLS.Utilities.Database.UserAccountDB uaDB = new SLS.Utilities.Database.UserAccountDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            uaDB.TopLevel = false;
            uaDB.Dock = DockStyle.None;
            uaDB.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(uaDB);
        }
    }
}
