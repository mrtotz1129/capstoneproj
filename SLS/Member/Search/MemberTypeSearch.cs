using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.Member.Search
{
    public partial class MemberTypeSearch : Form
    {
        public MemberTypeSearch()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SLS.Static.sqlParams = "SELECT MemberTypeID as [Member Type ID], MemberTypeName as [Member Type\nName], CONCAT(MinAgeRequired, ' - ', MaxAgeRequired,' years old') as [Age Requirement], SavingsApplicable as [Savings Deposit], TimeApplicable as [Time Deposit], LoanApplicable as [Loan Services], case LoanApplicable when 0 then 'Not Available' else CONVERT(nvarchar,ShareRequired) end as [Share Capital], [status] as [Status] FROM MEMBERTYPE WHERE (MemberTypeName LIKE '%@MemberTypeName%') and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(@Age between MinAgeRequired and MaxAgeRequired) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(SavingsApplicable = @SavingsApplicable) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(TimeApplicable = @TimeApplicable) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(LoanApplicable = @LoanApplicable)";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@MemberTypeName", txtMemberName.Text.ToString());
            SLS.Static.parameters.Add("@Age", Convert.ToInt32(txtAge.Text));
            SLS.Static.parameters.Add("@SavingsApplicable", Convert.ToBoolean(ckbSavings.CheckState));
            SLS.Static.parameters.Add("@TimeApplicable", Convert.ToBoolean(ckbLoan.CheckState));
            SLS.Static.parameters.Add("@LoanApplicable", Convert.ToBoolean(ckbTime.CheckState));
            SLS.Static.hasSearch = 1;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SLS.Static.hasSearch = 0;
            this.Close();
        }
    }
}
