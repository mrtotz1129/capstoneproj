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
    public partial class LoanApplicationDB : Form
    {
        public LoanApplicationDB()
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
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT MEMBER.MemberID as [ID], CONCAT(MEMBER.fName,' ',MEMBER.mName,' ',MEMBER.lName) as [Name], DATEDIFF(YEAR, MEMBER.birthDate, @DateNow ) as [Age], MEMBERTYPE.MemberTypeName as [Member Type] FROM MEMBER, MEMBERTYPE WHERE MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            DataSet ds = con.executeDataSet(sql, parameters, "Member");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Member";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void closedLoanType(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
             foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                //SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value.ToString());
                //if (Convert.ToBoolean(row.Cells[7].Value) == true)
                //{
                //    btnStatus.Text = "DELETE";
                //}
                //else
                //{
                //    btnStatus.Text = "ACTIVATE";
                //}
            }
        }
        private void cobFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDatabase();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            var child = new SLS.Loan.Application.LoanType();
            child.FormClosed += closedLoanType;
            child.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
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
    }
}
