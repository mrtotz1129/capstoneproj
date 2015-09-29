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

namespace SLS.TimeDeposit.Application
{
    public partial class ClosureRenewal : Form
    {
        public ClosureRenewal()
        {
            InitializeComponent();
            defaultAll();
        }

        public void defaultAll()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], MEMBERTYPE.MemberTypeName as [Member Type Name], TIMEDEPOSITRATES.TimeDepositRatesID as [ID], CONCAT(TIMEDEPOSITRATES.noOfDays, ' Days') as [No. Of Days], CONCAT(TIMEDEPOSITRATES.minAmount,' - ', TIMEDEPOSITRATES.maxAmount) as [Amount Range], CONCAT(TIMEDEPOSITRATES.interest, ' %') as [Interest], TIMEDEPOSITACCOUNT.TimeDepositAccountID as [Time Deposit Account ID], TIMEDEPOSITACCOUNT.currentBalance as [Amount] FROM TIMEDEPOSITRATES, TIMEDEPOSITACCOUNT, MEMBER, MEMBERTYPE WHERE TIMEDEPOSITRATES.TimeDepositRatesID = TIMEDEPOSITACCOUNT.TimeDepositRatesID and TIMEDEPOSITACCOUNT.MemberID = MEMBER.MemberID and MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID and MEMBER.MemberID = " + SLS.Static.ID + "";
            SqlDataReader reader = con.executeReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                txtMemberID.Text = "MEM - " + Convert.ToString(reader.GetInt32(0));
                txtMemberName.Text = reader.GetString(1);
                txtMemberType.Text = reader.GetString(2);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
