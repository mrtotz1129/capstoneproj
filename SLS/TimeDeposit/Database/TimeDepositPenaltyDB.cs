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

namespace SLS.TimeDeposit.Database
{
    public partial class TimeDepositPenaltyDB : Form
    {
        public decimal min, max;
        public TimeDepositPenaltyDB()
        {
            InitializeComponent();
            loadDatabase();
        }
        public void loadDatabase()
        {
            this.tIMEDEPOSITPENALTYVIEWTableAdapter.Fill(this.sLSDBDataSet6.TIMEDEPOSITPENALTYVIEW);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            var child = new SLS.TimeDeposit.TimeDepositPenalty();
            child.FormClosed += closedTimeDepositPenalty;
            child.ShowDialog();
        }

        public void closedTimeDepositPenalty(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var child = new SLS.TimeDeposit.TimeDepositPenalty();
            child.FormClosed += closedTimeDepositPenalty;
            child.ShowDialog();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if(btnStatus.Text == "DELETE")
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "UPDATE TIMEDEPOSITPENALTY SET [status] = @status WHERE TimeDepositPenaltyID = @TimeDepositPenaltyID";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@status", false);
                parameters.Add("@TimeDepositPenaltyID", SLS.Static.ID);
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
                String sql = "SELECT minElapsed, maxElapsed FROM TIMEDEPOSITPENALTY WHERE TimeDepositPenaltyID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if(reader.HasRows)
                {
                    reader.Read();
                    min = Convert.ToDecimal(reader[0]);
                    max = Convert.ToDecimal(reader[1]);
                }
                int isValid = 0;
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT minElapsed, maxElapsed FROM TIMEDEPOSITPENALTY WHERE [status] = 1";
                reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    while (reader.Read() && isValid == 0)
                    {
                        for (Decimal i = min; (i <= max) && isValid == 0; i = i + Convert.ToDecimal(0.01))
                        {
                            if (i >= Convert.ToDecimal(reader[0]) && i <= Convert.ToDecimal(reader[1]))
                            {
                                isValid = 1;
                            }
                        }
                    }
                }
                if(isValid == 0)
                {
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "UPDATE TIMEDEPOSITPENALTY SET [status] = @status WHERE TimeDepositPenaltyID = @TimeDepositPenaltyID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", true);
                    parameters.Add("@TimeDepositPenaltyID", SLS.Static.ID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Updating a time deposit rate is successful.", "Saved", MessageBoxButtons.OK);
                        SLS.Static.ID = 0;
                        loadDatabase();
                    }
                    else
                    {
                        MessageBox.Show("Updating a time deposit rate is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Another elapsed time is active.\nDisable first the active one.", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value);
                if(Convert.ToBoolean(row.Cells[3].Value) == true)
                {
                    btnStatus.Text = "DELETE";
                }
                else
                {
                    btnStatus.Text = "ACTIVATE";
                }

            }
        }

        private void TimeDepositPenaltyDB_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sLSDBDataSet6.TIMEDEPOSITPENALTYVIEW' table. You can move, or remove it, as needed.
            

        }
    }
}
