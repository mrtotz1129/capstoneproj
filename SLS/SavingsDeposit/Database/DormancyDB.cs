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

namespace SLS.SavingsDeposit.Database
{
    public partial class DormancyDB : Form
    {
        public DormancyDB()
        {
            InitializeComponent();
            loadDatabase(); defaultAll();
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
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = SLS.Static.sql;
            DataSet ds = con.executeDataSet(sql, "Dormancy");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Dormancy";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            var child = new SLS.SavingsDeposit.Application.Dormancy();
            child.FormClosed += closedDormancy;
            child.ShowDialog();
        }

        public void closedDormancy(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                var child = new SLS.SavingsDeposit.Application.Dormancy();
                child.FormClosed += closedDormancy;
                child.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select data from the database.", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                if (btnStatus.Text == "DELETE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE DORMANCY SET [status] = 'false' WHERE DormancyID = @DormancyID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@DormancyID", SLS.Static.ID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Updating a dormancy is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        sql = "UPDATE SAVINGSTYPE SET hasDormancy = 'false' WHERE SavingsTypeID = (SELECT SavingsTypeID FROM DORMANCY WHERE DormancyID = @DormancyID)";
                        parameters = new Dictionary<string, object>();
                        parameters.Add("@DormancyID", SLS.Static.ID); 
                        result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        if (result == 1)
                        {
                            loadDatabase();
                            btnStatus.Text = "DELETE";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Updating a dormancy is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "SELECT SAVINGSTYPE.hasDormancy FROM SAVINGSTYPE, DORMANCY WHERE SAVINGSTYPE.SavingsTypeID = DORMANCY.SavingsTypeID and DORMANCY.DormancyID = "+ SLS.Static.ID +" ";
                    SqlDataReader reader = con.executeReader(sql);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if(Convert.ToString(reader.GetValue(0)) == "False")
                        {
                            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                            sql = "UPDATE DORMANCY SET [status] = 'true' WHERE DormancyID = @DormancyID";
                            Dictionary<String, Object> parameters = new Dictionary<string, object>();
                            parameters.Add("@DormancyID", SLS.Static.ID);
                            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                            if (result == 1)
                            {
                                MessageBox.Show("Updating a dormancy is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                                sql = "UPDATE SAVINGSTYPE SET hasDormancy = 'true' WHERE SavingsTypeID = (SELECT SavingsTypeID FROM DORMANCY WHERE DormancyID = @DormancyID)";
                                parameters = new Dictionary<string, object>();
                                parameters.Add("@DormancyID", SLS.Static.ID);
                                result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                                if (result == 1)
                                {
                                    loadDatabase();
                                    btnStatus.Text = "DELETE";
                                }
                            }
                            else
                            {
                                MessageBox.Show("Updating a dormancy is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is an active dormancy for the savings type. \n Try to disable the currently active dormancy to activate another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        sql = "UPDATE DORMANCY SET [status] = 'true' WHERE DormancyID = @DormancyID";
                        Dictionary<String, Object> parameters = new Dictionary<string, object>();
                        parameters = new Dictionary<string, object>();
                        parameters.Add("@DormancyID", SLS.Static.ID);
                        int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        if (result == 1)
                        {
                            MessageBox.Show("Updating a dormancy is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                            sql = "UPDATE SAVINGSTYPE SET hasDormancy = 'true' WHERE SavingsTypeID = (SELECT SavingsTypeID FROM DORMANCY WHERE DormancyID = @DormancyID)";
                            parameters = new Dictionary<string, object>();
                            parameters.Add("@DormancyID", SLS.Static.ID);
                            result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                            if(result == 1)
                            {
                                loadDatabase();
                                btnStatus.Text = "DELETE";
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Updating a dormancy is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } 
                }
            }
            else
            {
                MessageBox.Show("Please choose a record to be updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value.ToString());
                if (Convert.ToBoolean(row.Cells[5].Value) == true)
                {
                    btnStatus.Text = "DELETE";
                }
                else
                {
                    btnStatus.Text = "ACTIVATE";
                }
            }
        }
    }
}
