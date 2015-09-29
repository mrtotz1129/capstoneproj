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
            String sql = SLS.Static.sql;
            DataSet ds = con.executeDataSet(sql, SLS.Static.parameters, "Member");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Member";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                var child = new SLS.TimeDeposit.Application.NewAccount();
                child.FormClosed += closedNewAccount;
                child.ShowDialog();
            }
            else
            {

            }
        }

        private void closedNewAccount(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnClosure_Click(object sender, EventArgs e)
        {
            if(SLS.Static.ID != 0)
            {
                var child = new SLS.TimeDeposit.Application.SearchAccount();
                child.FormClosed += closedClosureRenewal;
                child.ShowDialog();
            }
            else
            {

            }
        }

        private void closedClosureRenewal(object sender, FormClosedEventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                var child = new SLS.TimeDeposit.Application.ClosureRenewal();
                child.FormClosed += closedCloseClosure;
                child.ShowDialog();
            }
            else
            {
                loadDatabase();
            }
        }
        public void closedCloseClosure(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value);
            }
        }
    }
}
