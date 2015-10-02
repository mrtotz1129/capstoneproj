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

namespace SLS.Utilities.Database
{
    public partial class CreditInvestigationDB : Form
    {
        public CreditInvestigationDB()
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
            if(SLS.Static.hasSearch == 0)
            {
                this.cREDITINVESTIGATORVIEWTableAdapter.Fill(this.sLSDBDataSet9.CREDITINVESTIGATORVIEW);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                this.cREDITINVESTIGATORVIEWTableAdapter.Fill(this.sLSDBDataSet9.CREDITINVESTIGATORVIEW);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            var child = new SLS.Utilities.Application.CreditInvestigator();
            child.FormClosed += closedCI;
            child.ShowDialog();
        }
        public void closedCI(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                var child = new SLS.Utilities.Application.CreditInvestigator();
                child.FormClosed += closedCI;
                child.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select data from the database.", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                if (btnStatus.Text == "DELETE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE CREDITINVESTIGATOR SET [status] = @status WHERE ciID = @ciID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", false);
                    parameters.Add("@ciID", SLS.Static.ID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("A Credit Investigator is Updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDatabase();
                        btnStatus.Text = "DELETE";
                    }
                    else
                    {
                        MessageBox.Show("A Credit Investigator is Not Updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE CREDITINVESTIGATOR SET [status] = @status WHERE ciID = @ciID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", true);
                    parameters.Add("@ciID", SLS.Static.ID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("A Credit Investigator is Updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDatabase();
                        btnStatus.Text = "DELETE";
                    }
                    else
                    {
                        MessageBox.Show("A Credit Investigator is Not Updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (Convert.ToBoolean(row.Cells[4].Value) == true)
                {
                    btnStatus.Text = "DELETE";
                }
                else
                {
                    btnStatus.Text = "ACTIVATE";
                }
            }
        }

        private void CreditInvestigationDB_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sLSDBDataSet9.CREDITINVESTIGATORVIEW' table. You can move, or remove it, as needed.
            

        }
    }
}
