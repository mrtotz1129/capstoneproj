using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.Loan.Database
{
    public partial class LoanTypeDB : Form
    {
        public LoanTypeDB()
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
                if(cobFilter.SelectedIndex == 0)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "SELECT LoanTypeID as [ID], loanTypeName as [Loan Type], minAmount as [Minimum Amount], maxAmount as [Maximum Amount], CONCAT(noOfComaker, ' Members') as [No. of Co-maker], CONCAT(entitlement, ' %') as [Entitlement], CONCAT(eligibility, ' %') as [Eligibility], [status] as [Status] FROM LOANTYPE";
                    DataSet ds = con.executeDataSet(sql, "Savings Type");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Savings Type";
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (cobFilter.SelectedIndex == 1)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "SELECT LoanTypeID as [ID], loanTypeName as [Loan Type], minAmount as [Minimum Amount], maxAmount as [Maximum Amount], CONCAT(noOfComaker, ' Members') as [No. of Co-maker], CONCAT(entitlement, ' %') as [Entitlement], CONCAT(eligibility, ' %') as [Eligibility], [status] as [Status] FROM LOANTYPE WHERE [status] = 1";
                    DataSet ds = con.executeDataSet(sql, "Savings Type");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Savings Type";
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (cobFilter.SelectedIndex == 2)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "SELECT LoanTypeID as [ID], loanTypeName as [Loan Type], minAmount as [Minimum Amount], maxAmount as [Maximum Amount], CONCAT(noOfComaker, ' Members') as [No. of Co-maker], CONCAT(entitlement, ' %') as [Entitlement], CONCAT(eligibility, ' %') as [Eligibility], [status] as [Status] FROM LOANTYPE WHERE [status] = 0";
                    DataSet ds = con.executeDataSet(sql, "Savings Type");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Savings Type";
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "SELECT LoanTypeID as [ID], loanTypeName as [Loan Type], minAmount as [Minimum Amount], maxAmount as [Maximum Amount], CONCAT(noOfComaker, ' Members') as [No. of Co-maker], CONCAT(entitlement, ' %') as [Entitlement], CONCAT(eligibility, ' %') as [Eligibility], [status] as [Status] FROM LOANTYPE";
                    DataSet ds = con.executeDataSet(sql, "Savings Type");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Savings Type";
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else
            {

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            var child = new SLS.Loan.Application.LoanType();
            child.FormClosed += closedLoanType;
            child.ShowDialog();
        }

        private void closedLoanType(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(SLS.Static.ID != 0)
            {
                var child = new SLS.Loan.Application.LoanType();
                child.FormClosed += closedLoanType;
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
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value.ToString());
                if (Convert.ToBoolean(row.Cells[7].Value) == true)
                {
                    btnStatus.Text = "DELETE";
                }
                else
                {
                    btnStatus.Text = "ACTIVATE";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void cobFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDatabase();
        }
    }
}
