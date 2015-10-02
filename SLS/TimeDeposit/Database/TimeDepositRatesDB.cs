using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.TimeDeposit.Database
{
    public partial class TimeDepositRatesDB : Form
    {
        public TimeDepositRatesDB()
        {
            InitializeComponent();
            loadDatabase();
            defaultAll();
        }
        String[] FilterString = { "No Filter", "Active", "Not Active" };
        public void defaultAll()
        {
            cobFilter.Items.Clear();
            for (int i = 0; i < FilterString.Length; i++)
            {
                cobFilter.Items.Add("" + FilterString[i]);
            }
        }
        public void loadDatabase()
        {
            this.tIMEDEPOSITRATESVIEWTableAdapter.Fill(this.sLSDBDataSet5.TIMEDEPOSITRATESVIEW);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value.ToString());
                if(Convert.ToBoolean(row.Cells[4].Value) == true)
                {
                    btnStatus.Text = "DELETE";
                }
                else
                {
                    btnStatus.Text = "ACTIVATE";
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            var child = new SLS.TimeDeposit.TimeDepositRates();
            child.FormClosed += closedTimeDepositRates;
            child.ShowDialog();
        }

        public void closedTimeDepositRates(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                var child = new SLS.TimeDeposit.TimeDepositRates();
                child.FormClosed += closedTimeDepositRates;
                child.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select data from the database.", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (btnStatus.Text == "DELETE")
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "UPDATE TIMEDEPOSITRATES SET [status] = @status WHERE TimeDepositRatesID = @TimeDepositRatesID";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@status", false);
                parameters.Add("@TimeDepositRatesID", SLS.Static.ID);
                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                if (result == 1)
                {
                    MessageBox.Show("Updating a time deposit rate is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SLS.Static.ID = 0;
                    loadDatabase();
                }
                else
                {
                    MessageBox.Show("Updating a time deposit rate is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "UPDATE TIMEDEPOSITRATES SET [status] = @status WHERE TimeDepositRatesID = @TimeDepositRatesID";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@status", true);
                parameters.Add("@TimeDepositRatesID", SLS.Static.ID);
                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                if (result == 1)
                {
                    MessageBox.Show("Updating a time deposit rate is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SLS.Static.ID = 0;
                    loadDatabase();
                }
                else
                {
                    MessageBox.Show("Updating a time deposit rate is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TimeDepositRatesDB_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sLSDBDataSet5.TIMEDEPOSITRATESVIEW' table. You can move, or remove it, as needed.
            

        }
    }
}
