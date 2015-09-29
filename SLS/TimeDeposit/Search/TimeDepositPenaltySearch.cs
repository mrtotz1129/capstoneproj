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
    public partial class TimeDepositPenaltySearch : Form
    {
        public TimeDepositPenaltySearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SLS.Static.sqlParams = "SELECT TimeDepositPenaltyID as [ID], CONCAT(minElapsed, ' - ', maxElapsed) as [Elapsed Time], reducedBy as [Interest Reduced By], [status] as [Status] FROM TIMEDEPOSITPENALTY  WHERE (TimeDepositPenaltyID LIKE '%@TimeDepositPenaltyID%') and" +
                                                                                                                                                                                                                           "(@elapsedTime between minElapsed and maxElapsed ) and" +
                                                                                                                                                                                                                           "(reducedBy = @reducedBy) ";
           SLS.Static.parameters = new Dictionary<string, object>();
           SLS.Static.parameters.Add("@elapsedTime", Convert.ToInt32(textBox1.Text));
           SLS.Static.parameters.Add("@reducedBy", textBox2.Text.ToString());
           
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        }
    }
}
