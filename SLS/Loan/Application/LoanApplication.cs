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

namespace SLS.Loan.Application
{
    public partial class LoanApplication: Form
    {
        public LoanApplication()
        {
            InitializeComponent();
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO LOAN (MemberID, LoanTypeID, applyAmount, TermID, ModeID, dateApplied) VALUES (@MemID, @LTypeID, @ApplyAmt, @TermID, @ModeID, @dateApplied)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@MemId", Convert.ToInt32(textBox1.Text));
            parameters.Add("@LTypeID", Convert.ToInt32(textBox6.Text));
            parameters.Add("@ApplyAmt", textBox4.Text);
            parameters.Add("@TermID", Convert.ToInt32(textBox7.Text));
            parameters.Add("@ModeID", Convert.ToInt32(textBox8.Text));
            parameters.Add("@dateApplied", date);
            SqlDataReader reader = con.executeReader(sql, parameters);
            MessageBox.Show("Loan Application Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
