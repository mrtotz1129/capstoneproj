using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.Member.Database
{
    public partial class TransactionDB : Form
    {
        public TransactionDB()
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
            String sql = SLS.Static.sqlParams;
            DataSet ds = con.executeDataSet(sql,SLS.Static.parameters ,"Member");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Member";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnMemberApp_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            var child = new SLS.Member.Application.MembershipApplication();
            child.FormClosed += closedMemberApp;
            child.ShowDialog();

        }

        public void closedMemberApp(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                if (SLS.Static.ID != 0)
                {
                    var child = new SLS.Member.Application.MembershipApplication();
                    child.FormClosed += closedMemberApp;
                    child.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select data from the database.", "Error", MessageBoxButtons.OK);
                }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value);
                if (Convert.ToBoolean(row.Cells[2].Value) == true)
                {

                }
                else if (Convert.ToBoolean(row.Cells[2].Value) == false)
                {

                }
                SLS.Static.selected = 0;
            }
        }


    }
}
