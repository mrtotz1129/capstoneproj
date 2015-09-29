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

namespace SLS.Loan.Database
{
    public partial class ChargeModeTermDB : Form
    {
        String[] StringFilter = {"All", "Active", "Not Active"};
        Int32 daysInterval = 0, noOfDays = 0;

        public ChargeModeTermDB()
        {
            InitializeComponent();
            defaultAll();
            loadDatabase();
        }
        public void defaultAll()
        {
            cobFilterCharge.Items.Clear();
            for(int i = 0; i < StringFilter.Length; i++)
            {
                cobFilterCharge.Items.Add(""+StringFilter[i]);
            }
            cobFilterCharge.SelectedIndex = 0;
            cobFilterMode.Items.Clear();
            for (int i = 0; i < StringFilter.Length; i++)
            {
                cobFilterMode.Items.Add("" + StringFilter[i]);
            }
            cobFilterMode.SelectedIndex = 0;
            cobFilterTerm.Items.Clear();
            for (int i = 0; i < StringFilter.Length; i++)
            {
                cobFilterTerm.Items.Add("" + StringFilter[i]);
            }
            cobFilterTerm.SelectedIndex = 0;
        }

        public void loadDatabase()
        {
            if (cobFilterCharge.SelectedIndex == 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT ChargeID as [ID], chargeName as [LoanCharge], [status] as [Status] FROM CHARGES";
                DataSet ds = con.executeDataSet(sql, "Charge");
                dataGridView3.DataSource = ds;
                dataGridView3.DataMember = "Charge";
                dataGridView3.Columns[0].Visible = false;
                dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (cobFilterCharge.SelectedIndex == 1)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT ChargeID as [ID], chargeName as [LoanCharge], [status] as [Status] FROM CHARGES WHERE [status] = 1";
                DataSet ds = con.executeDataSet(sql, "Charge");
                dataGridView3.DataSource = ds;
                dataGridView3.DataMember = "Charge";
                dataGridView3.Columns[0].Visible = false;
                dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (cobFilterCharge.SelectedIndex == 2)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT ChargeID as [ID], chargeName as [LoanCharge], [status] as [Status] FROM CHARGES WHERE [status] = 0";
                DataSet ds = con.executeDataSet(sql, "Charge");
                dataGridView3.DataSource = ds;
                dataGridView3.DataMember = "Charge";
                dataGridView3.Columns[0].Visible = false;
                dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (cobFilterMode.SelectedIndex == 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT ModeID as [ID], modeName as [Mode], [status] as [Status], daysInterval FROM MODE";
                DataSet ds = con.executeDataSet(sql, "Mode");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Mode";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (cobFilterMode.SelectedIndex == 1)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT ModeID as [ID], modeName as [Mode], [status] as [Status], daysInterval FROM MODE WHERE [status] = 1";
                DataSet ds = con.executeDataSet(sql, "Mode");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Mode";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            else if (cobFilterMode.SelectedIndex == 2)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT ModeID as [ID], modeName as [Mode], [status] as [Status], daysInterval  MODE WHERE [status] = 0";
                DataSet ds = con.executeDataSet(sql, "Mode");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Mode";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (cobFilterTerm.SelectedIndex == 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT TermID as [ID], noOfDays as [No. Of Days], [status] as [Status] FROM TERM";
                DataSet ds = con.executeDataSet(sql, "Term");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Term";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (cobFilterTerm.SelectedIndex == 1)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT TermID as [ID], noOfDays as [No. Of Days], [status] as [Status] FROM TERM WHERE [status] = 1";
                DataSet ds = con.executeDataSet(sql, "Term");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Term";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (cobFilterTerm.SelectedIndex == 2)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT TermID as [ID], noOfDays as [No. Of Days], [status] as [Status] FROM TERM WHERE [status] = 0";
                DataSet ds = con.executeDataSet(sql, "Term");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Term";
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void cobFilterTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDatabase();
        }

        private void cobFilterCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDatabase();
        }

        private void cobFilterMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDatabase();
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value);
                daysInterval = Convert.ToInt32(row.Cells[3].Value);
                if (Convert.ToBoolean(row.Cells[2].Value) == true)
                {
                    btnStatus.Text = "DELETE";
                }
                else if (Convert.ToBoolean(row.Cells[2].Value) == false)
                {
                    btnStatus.Text = "ACTIVATE";
                }
                SLS.Static.selected = 0;
            }
        }

        private void dataGridView2_SelectionChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value);
                noOfDays = Convert.ToInt32(row.Cells[1].Value);
                if (Convert.ToBoolean(row.Cells[2].Value) == true)
                {
                    btnStatus.Text = "DELETE";
                }
                else if (Convert.ToBoolean(row.Cells[2].Value) == false)
                {
                    btnStatus.Text = "ACTIVATE";
                }
                SLS.Static.selected = 1;
            }
        }

        private void dataGridView3_SelectionChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value);
                if (Convert.ToBoolean(row.Cells[2].Value) == true)
                {
                    btnStatus.Text = "DELETE";
                }
                else if (Convert.ToBoolean(row.Cells[2].Value) == false)
                {
                    btnStatus.Text = "ACTIVATE";
                }
                SLS.Static.selected = 2;
            }
        }

        public void chargeModeTerm(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (SLS.Static.selected == 0)
            {
                SLS.Static.ID = 0;
                var child = new SLS.Loan.Application.ModeOfPayment();
                child.FormClosed += chargeModeTerm;
                child.ShowDialog();
            }
            else if(SLS.Static.selected == 1)
            {
                SLS.Static.ID = 0;
                var child = new SLS.Loan.Application.TermOfPayment();
                child.FormClosed += chargeModeTerm;
                child.ShowDialog();
            }
            else
            {
                SLS.Static.ID = 0;
                var child = new SLS.Loan.Application.LoanChargeName();
                child.FormClosed += chargeModeTerm;
                child.ShowDialog();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SLS.Static.selected == 0)
            {
                if (SLS.Static.ID != 0)
                {
                    var child = new SLS.Loan.Application.ModeOfPayment();
                    child.FormClosed += chargeModeTerm;
                    child.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select data from the database.", "Error", MessageBoxButtons.OK);
                }
            }
            else if (SLS.Static.selected == 1)
            {
                if (SLS.Static.ID != 0)
                {
                    var child = new SLS.Loan.Application.TermOfPayment();
                    child.FormClosed += chargeModeTerm;
                    child.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select data from the database.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (SLS.Static.ID != 0)
                {
                    var child = new SLS.Loan.Application.LoanChargeName();
                    child.FormClosed += chargeModeTerm;
                    child.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select data from the database.", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void pnlMode_Enter(object sender, EventArgs e)
        {
            SLS.Static.selected = 0;
            SLS.Static.ID = 0;
            noOfDays = 0;
        }

        private void pnlTerm_Enter(object sender, EventArgs e)
        {
            SLS.Static.selected = 1;
            SLS.Static.ID = 0;
            daysInterval = 0;
        }

        private void pnlCharge_Enter(object sender, EventArgs e)
        {
            SLS.Static.selected = 2;
            SLS.Static.ID = 0;
            daysInterval = 0;
            noOfDays = 0;
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if(SLS.Static.selected == 0)
            {
                if(btnStatus.Text == "DELETE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE MODE SET [status] = @status WHERE ModeID = @ModeID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", false);
                    parameters.Add("@ModeID", SLS.Static.ID);
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
                else if(btnStatus.Text == "ACTIVATE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "SELECT daysInterval FROM MODE WHERE ModeID = " + SLS.Static.ID + " ";
                    SqlDataReader reader = con.executeReader(sql);
                    Int32 isValid = 0;
                    if(reader.HasRows && isValid == 0)
                    {
                        reader.Read();
                        if(daysInterval == reader.GetInt32(0))
                        {
                            isValid = 1;
                        }
                    }
                    if(isValid == 0)
                    {
                        con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        sql = "UPDATE MODE SET [status] = @status WHERE ModeID = @ModeID";
                        Dictionary<String, Object> parameters = new Dictionary<string, object>();
                        parameters.Add("@status", true);
                        parameters.Add("@ModeID", SLS.Static.ID);
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
                        MessageBox.Show("There is an existing mode of payment.","Error");
                    }
                }
            }
            else if (SLS.Static.selected == 1)
            {
                if (btnStatus.Text == "DELETE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE TERM SET [status] = @status WHERE TermID = @TermID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", false);
                    parameters.Add("@TermID", SLS.Static.ID);
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
                else if (btnStatus.Text == "ACTIVATE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "SELECT noOfDays FROM TERM WHERE TermID = " + SLS.Static.ID + " ";
                    SqlDataReader reader = con.executeReader(sql);
                    Int32 isValid = 0;
                    if (reader.HasRows && isValid == 0)
                    {
                        reader.Read();
                        if (noOfDays == reader.GetInt32(0))
                        {
                            isValid = 1;
                        }
                    }
                    if (isValid == 0)
                    {
                        con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        sql = "UPDATE TERM SET [status] = @status WHERE TermID = @TermID";
                        Dictionary<String, Object> parameters = new Dictionary<string, object>();
                        parameters.Add("@status", true);
                        parameters.Add("@TermID", SLS.Static.ID);
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
                        MessageBox.Show("There is an existing mode of payment.", "Error");
                    }
                }
            }
            else if (SLS.Static.selected == 2)
            {
                if (btnStatus.Text == "DELETE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE CHARGE SET [status] = @status WHERE ChargeID = @ChargeID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", false);
                    parameters.Add("@ChargeID", SLS.Static.ID);
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
                else if (btnStatus.Text == "ACTIVATE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE CHARGE SET [status] = @status WHERE ChargeID = @ChargeID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", true);
                    parameters.Add("@ChargeID", SLS.Static.ID);
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
        }
    }
}
