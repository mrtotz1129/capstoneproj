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
    public partial class SavingsTypeSearch : Form
    {
        public SavingsTypeSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SLS.Static.sqlParams = "SELECT SavingsTypeID as [ID], savingsTypeName as [Savings Type], interestRate as [Interest Rate], initialDeposit as [Initial Deposit], maintainingBalance as [Maintaining Balance], balanceToEarn as [Balance To Earn Rate], case maxWithdrawAmount when 0 then 'Not Available' else CONCAT( (CONVERT(nvarchar, maxWithdrawAmount)), (case maxWithdrawMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)) end as [Maximum Withdrawal], [status] as [Status] FROM SAVINGSTYPE WHERE (SavingsTypeID LIKE '%@SavingsTypeID%') and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            "(SavingsTypeName LIKE '%@SavingsTypeName%') and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            "(initialDeposit = @initialDeposit) and " +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            "(maintainingBalance = @maintainingBalance) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            "(balanceToEarn = @balanceToEarn) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            "(interestRate = @interestRate) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            "(maxWithdrawAmount = @maxWithdrawAmount) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            "(maxWithdrawMode = @maxWithdrawMode) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            "(hasDormancy = @hasDormancy)";
           SLS.Static.parameters = new Dictionary<string, object>();
           SLS.Static.parameters.Add("@SavingsTypeID", textBox1.Text.ToString());
           SLS.Static.parameters.Add("@interestRate", Convert.ToInt32(textBox3.Text));
           SLS.Static.parameters.Add("@initialDeposit", Convert.ToInt32(textBox4.Text));
           SLS.Static.parameters.Add("@maintainingBalance", Convert.ToInt32(textBox5.Text));
           SLS.Static.parameters.Add("@balanceToEarn", Convert.ToInt32(textBox6.Text));
           SLS.Static.parameters.Add("@maxWithdrawalAmount", Convert.ToInt32(textBox7.Text));   
        }
    }
}
