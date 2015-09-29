using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.SavingsDeposit.Search
{
    public partial class SavingsDepositSearch : Form
    {
        public SavingsDepositSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SLS.Static.sqlParams = "SELECT MemberTypeID as [Member Type ID], MemberTypeName as [Member Type\nName], CONCAT(MinAgeRequired, ' - ', MaxAgeRequired,' years old') as [Age Requirement], SavingsApplicable as [Savings Deposit], TimeApplicable as [Time Deposit], LoanApplicable as [Loan Services], case LoanApplicable when 0 then 'Not Available' else CONVERT(nvarchar,ShareRequired) end as [Share Capital], [status] as [Status] FROM MEMBERTYPE WHERE (MemberTypeID LIKE '%@MemberTypeID%') and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(MemberTypeName LIKE '%@MemberTypeName%') and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(@Age between MinAgeRequired and MaxAgeRequired) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(SavingsApplicable = @SavingsApplicable) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(TimeApplicable = @TimeApplicable) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                         "(LoanApplicable = @LoanApplicable)";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@MemberTypeID", textBox1.Text.ToString());
            SLS.Static.parameters.Add("@Age", Convert.ToInt32(textBox2.Text));
            SLS.Static.parameters.Add("@MemberTypeName", textBox3.Text); 
        }
    }
}
