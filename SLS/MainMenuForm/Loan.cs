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
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            SLS.Loan.Database.ChargeModeTermDB CM = new SLS.Loan.Database.ChargeModeTermDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            CM.TopLevel = false;
            CM.Dock = DockStyle.None;
            CM.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(CM);
        }

        private void modeTermPayment_Click(object sender, EventArgs e)
        {
            SLS.Loan.Database.ChargeModeTermDB CM = new SLS.Loan.Database.ChargeModeTermDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            CM.TopLevel = false;
            CM.Dock = DockStyle.None;
            CM.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(CM);
        }

        private void loanType_Click(object sender, EventArgs e)
        {
            SLS.Loan.Database.LoanTypeDB LT = new SLS.Loan.Database.LoanTypeDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            LT.TopLevel = false;
            LT.Dock = DockStyle.None;
            LT.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(LT);
        }

        private void loanApplication_Click(object sender, EventArgs e)
        {
            SLS.Loan.Database.LoanApplicationDB LA = new SLS.Loan.Database.LoanApplicationDB();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            LA.TopLevel = false;
            LA.Dock = DockStyle.None;
            LA.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(LA);
        }

        private void approveReject_Click(object sender, EventArgs e)
        {
            SLS.Loan.Database.ApproveReject AR = new SLS.Loan.Database.ApproveReject();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            AR.TopLevel = false;
            AR.Dock = DockStyle.None;
            AR.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(AR);
        }

        private void releaseAmortization_Click(object sender, EventArgs e)
        {
            SLS.Loan.Database.ReleaseAmor RA = new SLS.Loan.Database.ReleaseAmor();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            RA.TopLevel = false;
            RA.Dock = DockStyle.None;
            RA.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(RA);
        }

        private void loanPayment_Click(object sender, EventArgs e)
        {
            SLS.Loan.Database.LoanPayment LP = new SLS.Loan.Database.LoanPayment();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            LP.TopLevel = false;
            LP.Dock = DockStyle.None;
            LP.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(LP);
        }

        private void loanRestructure_Click(object sender, EventArgs e)
        {
            SLS.Loan.Database.LoanRestruct LR = new SLS.Loan.Database.LoanRestruct();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            LR.TopLevel = false;
            LR.Dock = DockStyle.None;
            LR.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(LR);
        }
    }
}
