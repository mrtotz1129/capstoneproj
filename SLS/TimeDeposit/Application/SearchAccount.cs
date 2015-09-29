using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.TimeDeposit.Application
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
            String sql = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], MEMBERTYPE.MemberTypeName as [Member Type Name], TIMEDEPOSITRATES.TimeDepositRatesID as [ID], CONCAT(TIMEDEPOSITRATES.noOfDays, ' Days') as [No. Of Days], CONCAT(TIMEDEPOSITRATES.minAmount,' - ', TIMEDEPOSITRATES.maxAmount) as [Amount Range], CONCAT(TIMEDEPOSITRATES.interest, ' %') as [Interest], TIMEDEPOSITACCOUNT.TimeDepositAccountID as [Time Deposit Account ID], TIMEDEPOSITACCOUNT.currentBalance as [Amount] FROM TIMEDEPOSITRATES, TIMEDEPOSITACCOUNT, MEMBER, MEMBERTYPE WHERE TIMEDEPOSITRATES.TimeDepositRatesID = TIMEDEPOSITACCOUNT.TimeDepositRatesID and TIMEDEPOSITACCOUNT.MemberID = MEMBER.MemberID and MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID and MEMBER.MemberID = " + SLS.Static.ID + "";
            DataSet ds = con.executeDataSet(sql, "Account");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Account";
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
