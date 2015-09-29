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

namespace SLS.SavingsDeposit.Search
{
    public partial class DormancySearch : Form
    {
        public DormancySearch()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SLS.Static.sqlParams = "SELECT DORMANCY.DormancyID as [ID], SAVINGSTYPE.savingsTypeName as [Savings Type], CONCAT(DORMANCY.inactivityValue, ' ',(case DORMANCY.inactivityTime when 0 then 'Day/s' when 1 then 'Week/s' when 2 then 'Month/s' else 'Year/s' end)) as [Inactivity Period], CONCAT(DORMANCY.deductionAmount, (case DORMANCY.isPercentage when 0 then ' Pesos ' else ' % ' end), (case DORMANCY.deductionMode when 0 then ' / Day' when 1 then ' / Week' when 2 then ' / Month' else ' / Year' end)) as [Deduction], DORMANCY.activationFee as [Activation Fee], DORMANCY.[status] as [Status] FROM DORMANCY, SAVINGSTYPE WHERE DORMANCY.SavingsTypeID = SAVINGSTYPE.SavingsTypeID WHERE (DormancyID LIKE '%@DormancyID%') and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           "(inactivityValue = @inactivityValue%') and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           "(inactivityTime = @inactivityTime) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           "(deductionAmount = @deductionAmount) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           "(isPercentage = @isPercentage) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           "(deductionMode = @deductionMode) and" +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           "(activationFee = @activationFee) and " +
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           "(SavingsTypeID = @SavingsTypeID";

            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@SavingsTypeID", cobSavingsType.Text.ToString());
            SLS.Static.parameters.Add("@inactivityValue", Convert.ToInt32(txtInactiveValue.Text));
            SLS.Static.parameters.Add("@inactivityTime", Convert.ToInt32(cobInactiveTime.SelectedIndex+1));
            SLS.Static.parameters.Add("@deductionAmount", Convert.ToInt32(txtDeductAmount.Text));
            SLS.Static.parameters.Add("@isPercentage", Convert.ToBoolean(cobDeductNature.SelectedIndex));
            SLS.Static.parameters.Add("@deductionMode", Convert.ToBoolean(cobDeductMode.SelectedIndex));
            SLS.Static.parameters.Add("@activationFee", Convert.ToInt32(txtActivateFee.Text));
      }
    }
}