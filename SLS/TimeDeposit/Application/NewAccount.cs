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
    public partial class NewAccount : Form
    {
        public Int32 MemberID, RateID = 0;

        public NewAccount()
        {
            InitializeComponent();
            defaultAll();
        }

        public void defaultAll()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT FORMAT(MEMBER.MemberID,'00000000') as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, '" + (DateTime.Now).ToString("yyyy-MM-dd") + "' ) as [Age], MEMBERTYPE.MemberTypeName as [Member Type] FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID AND MEMBER.MemberID = " + SLS.Static.ID + " ";
            SqlDataReader reader = con.executeReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                MemberID = Convert.ToInt32(reader[0]);
                txtMemberID.Text = "MEM - " + Convert.ToString(reader[0]);
                txtMemberName.Text = Convert.ToString(reader[1]);
                txtMemberType.Text = Convert.ToString(reader[3]);
            }
            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            sql = "SELECT DISTINCT(TIMEDEPOSITRATES.noOfDays) FROM MEMBERTYPE, TIMEDEPOSITRATES WHERE MEMBERTYPE.TimeApplicable = 1 AND TIMEDEPOSITRATES.[status] = 1";
            reader = con.executeReader(sql);
            cobNoOfDays.Items.Clear();
            int i = 0;
            while(reader.Read())
            {
                string str = reader[0].ToString();
                cobNoOfDays.Items.Insert(i, "" + str + " Days");
                i += 1;
            }
            cobNoOfDays.Text = "";
            cobNoOfDays.Enabled = true;
            er1.Visible = true;
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    txtTimeAccount.Text = "TIME - " + (reader.GetInt32(0) + 1).ToString("00000000");
                }
            }
            catch (Exception)
            {
                txtTimeAccount.Text = "TIME - 00000001";
            }
            txtNow.Text = Convert.ToString(DateTime.Now.ToLongDateString());
        }

        private void cobNoOfDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT TimeDepositRatesID as [ID], CONCAT(noOfDays, ' Days') as [No. Of Days], CONCAT(minAmount,' - ', maxAmount) as [Amount Range], CONCAT(interest, ' %') as [Interest], [status] as [Status] FROM TIMEDEPOSITRATES WHERE CONCAT(noOfDays, ' Days') = '" + cobNoOfDays.SelectedItem + "'";
                DataSet ds = con.executeDataSet(sql, "Time Deposit Rates");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Time Deposit Rates";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            {

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                RateID = Convert.ToInt32(row.Cells[0].Value);
                txtRange.Text = row.Cells[2].Value.ToString();
                txtInterest.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RateID == 0 || checkValues() != 0)
            {
                if(RateID == 0)
                {
                    MessageBox.Show("Choose a time deposit rate.", "Error");
                }
                else if(checkValues() != 0)
                {
                    MessageBox.Show("Some required fields are missing or invalid.", "Error");
                }
            }
            else
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "  INSERT INTO TIMEDEPOSITACCOUNT(MemberID,TimeDepositRatesID,dateOpened,dateMaturity,currentBalance,isClosed) VALUES (@MemberID,@TimeDepositRatesID,@dateOpened,DATEADD(DAY,(SELECT noOfDays FROM TIMEDEPOSITRATES WHERE TimeDepositRatesID = @RatesID),@DateNow),@currentBalance,@isClosed)";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@MemberID", SLS.Static.ID);
                parameters.Add("@TimeDepositRatesID", RateID);
                parameters.Add("@dateOpened", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
                parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
                parameters.Add("@RatesID", RateID);
                parameters.Add("@currentBalance", Convert.ToDecimal(txtAmount.Text));
                parameters.Add("@isClosed", false);
                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                this.Close();
            }
        }

        private int checkValues()
        { 
            Int32 isValid = 0;
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT minAmount, maxAmount FROM TIMEDEPOSITRATES WHERE TimeDepositRatesID = @RateID";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@RateID", Convert.ToInt32(RateID));
            SqlDataReader reader = con.executeReader(sql, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                if (Convert.ToDecimal(txtAmount.Text) <= Convert.ToDecimal(reader[0]) || Convert.ToDecimal(txtAmount.Text) >= Convert.ToDecimal(reader[1]))
                {
                    er1.Visible = true;
                    isValid = 1;
                }
            }
            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
