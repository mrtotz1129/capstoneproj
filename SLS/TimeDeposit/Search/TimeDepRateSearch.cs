using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.TimeDeposit.Search
{
    public partial class TimeDepositRateSearch : Form
    {
        public TimeDepositRateSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SLS.Static.sqlParams = "SELECT TimeDepositRatesID as [ID], CONCAT(noOfDays, ' Days') as [No. Of Days], CONCAT(minAmount,' - ', maxAmount) as [Amount Range], CONCAT(interest, ' %') as [Interest], [status] as [Status] FROM TIMEDEPOSITRATES WHERE (TimeDepositRatesID LIKE '%@TimeDepositratesID%') and" +
                                                                                                                                                                                                                                                                "(noOfDays = @noOfDays) and" +
                                                                                                                                                                                                                                                                "(@amountRange between minAmount and maxAmount) and" +
                                                                                                                                                                                                                                                            
                                                                                                                                                                                                                                                                "(interest = @interest)";
            SLS.Static.parameters = new Dictionary<string, object>();
            SLS.Static.parameters.Add("@noOfDays", Convert.ToInt32(textBox1.Text));
            SLS.Static.parameters.Add("@amountRange", Convert.ToInt32(textBox2.Text));
            SLS.Static.parameters.Add("@interest", Convert.ToInt32(textBox3.Text));
        }
    }
}
