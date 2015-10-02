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

namespace SLS.Loan.Application
{
    public partial class LoanType : Form
    {
        String[] GraceString = { "Per Day", "Per Week", "Per Month", "Per Year" };
        DataTable table = new DataTable();
        String[] chargesArr, modeArr;
        Int32[] termArr;
        Int32 charges, term, mode;

        public LoanType()
        {
            InitializeComponent();
            defaultAll();
        }

        public void defaultAll()
        {
            txtLoanType.Clear();
            ckbMemType.Checked = false;
            cListMemType.Items.Clear();
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT memberTypeName FROM MEMBERTYPE where LoanApplicable = 1 and [status] = 1 ORDER BY membertypename";
            SqlDataReader reader = con.executeReader(sql);
            int i = 0;
            while(reader.Read())
            {
                string str = reader[0].ToString();
                cListMemType.Items.Insert(i, "" + str);
                i += 1;
            }
            txtMinAmount.Clear();
            txtMaxAmount.Clear();
            txtNoOfComaker.Clear();
            txtEntitlement.Clear();
            txtEligibility.Clear();

            ckbGrace.Checked = false;
            txtGrace.Clear();
            txtGrace.Enabled = false;
            cobGrace.Items.Clear();
            cobGrace.Enabled = false;

            ckbMode.Checked = false;
            cListMode.Items.Clear();
            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            sql = "SELECT modeName FROM MODE where [status] = 1 ORDER BY daysInterval";
            reader = con.executeReader(sql);
            i = 0;
            while (reader.Read())
            {
                cListMode.Items.Insert(i, "" + Convert.ToString(reader.GetString(0)));
                i += 1;
            }

            ckbTerm.Checked = false;
            cListTerm.Items.Clear();
            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            sql = "SELECT noOfDays FROM TERM where [status] = 1 ORDER BY noOfDays";
            reader = con.executeReader(sql);
            i = 0;
            while (reader.Read())
            {
                cListTerm.Items.Insert(i, "" + Convert.ToString(reader.GetInt32(0)));
                i += 1;
            }

            ckbCharges.Checked = false;
            cListCharges.Items.Clear();
            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            sql = "SELECT chargeName FROM CHARGES where [status] = 1 ORDER BY chargeName";
            reader = con.executeReader(sql);
            i = 0;
            while (reader.Read())
            {
                if (reader.GetString(0) != "Interest On Loan")
                {
                    cListCharges.Items.Insert(i, "" + Convert.ToString(reader.GetString(0)));
                    i += 1;
                }
            }

            if(SLS.Static.ID != 0)
            {
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT LoanTypeID as [ID], loanTypeName as [Loan Type], minAmount as [Minimum Amount], maxAmount as [Maximum Amount], noOfComaker as [No. of Co-maker], entitlement as [Entitlement], eligibility as [Eligibility], [status] as [Status] FROM LOANTYPE WHERE LoanTypeID = " + SLS.Static.ID + " ";
                reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtLoanType.Text = Convert.ToString(reader[1]);
                    txtMinAmount.Text = Convert.ToString(reader[2]);
                    txtMaxAmount.Text = Convert.ToString(reader[3]);
                    txtNoOfComaker.Text = Convert.ToString(reader[4]);
                    txtEntitlement.Text = Convert.ToString(reader[5]);
                    txtEligibility.Text = Convert.ToString(reader[6]);
                }
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT MEMBERTYPE.memberTypeName FROM MEMBERTYPE, APPLICABLELOAN WHERE MEMBERTYPE.MemberTypeID = APPLICABLELOAN.MemberTypeID and APPLICABLELOAN.LoanTypeID = @LoanTypeID";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@LoanTypeID", SLS.Static.ID);
                reader = con.executeReader(sql, parameters);
                for (i = 0; i < cListMemType.Items.Count; i++)
                {
                    cListMemType.SetItemChecked(i, false);
                }
                while (reader.Read())
                {
                    int index = cListMemType.Items.IndexOf(reader.GetString(0));
                    cListMemType.SetItemChecked(index, true);
                }
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT DISTINCT(MODE.modeName) FROM MODE, LOANRATE, LOANTYPE WHERE MODE.ModeID = LOANRATE.ModeID and LOANRATE.LoanTypeID = LOANTYPE.LoanTypeID and LOANTYPE.LoanTypeID = @LoanTypeID";
                parameters = new Dictionary<string, object>();
                parameters.Add("@LoanTypeID", SLS.Static.ID);
                reader = con.executeReader(sql, parameters);
                for (i = 0; i < cListMode.Items.Count; i++)
                {
                    cListMode.SetItemChecked(i, false);
                }
                while (reader.Read())
                {
                    int index = cListMode.Items.IndexOf(reader.GetString(0));
                    cListMode.SetItemChecked(index, true);
                }
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT DISTINCT(TERM.noOfDays) FROM TERM, LOANRATE, LOANTYPE WHERE TERM.TermID = LOANRATE.TermID and LOANRATE.LoanTypeID = LOANTYPE.LoanTypeID and LOANTYPE.LoanTypeID = @LoanTypeID";
                parameters = new Dictionary<string, object>();
                parameters.Add("@LoanTypeID", SLS.Static.ID);
                reader = con.executeReader(sql, parameters);
                for (i = 0; i < cListTerm.Items.Count; i++)
                {
                    cListTerm.SetItemChecked(i, false);
                }
                while (reader.Read())
                {
                    int index = cListTerm.Items.IndexOf(Convert.ToString(reader.GetInt32(0)));
                    cListTerm.SetItemChecked(index, true);
                }
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT DISTINCT(CHARGES.chargeName) FROM CHARGES, LOANRATE, LOANTYPE WHERE CHARGES.ChargeID = LOANRATE.ChargeID and LOANRATE.LoanTypeID = LOANTYPE.LoanTypeID and LOANTYPE.LoanTypeID = @LoanTypeID";
                parameters = new Dictionary<string, object>();
                parameters.Add("@LoanTypeID", SLS.Static.ID);
                reader = con.executeReader(sql, parameters);
                for (i = 0; i < cListCharges.Items.Count; i++)
                {
                    cListCharges.SetItemChecked(i, false);
                }
                while (reader.Read())
                {
                    if (reader.GetString(0) != "Interest On Loan")
                    {
                        int index = cListCharges.Items.IndexOf(reader.GetString(0));
                        cListCharges.SetItemChecked(index, true);
                    }
                }

                defaultGrace();
            }
        }

        private void defaultGrace()
        {
            txtGrace.Clear();
            cobGrace.Items.Clear();
            for (int x = 0; x < GraceString.Length; x++)
            {
                cobGrace.Items.Insert(x, "" + GraceString[x]);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

        private void ckbMode_Click(object sender, EventArgs e)
        {
            if (ckbMode.Checked == true)
            {
                for (int i = 0; i < cListMode.Items.Count; i++)
                {
                    cListMode.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cListMode.Items.Count; i++)
                {
                    cListMode.SetItemChecked(i, false);
                }
            }
        }

        private void ckbTerm_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTerm.Checked == true)
            {
                for (int i = 0; i < cListTerm.Items.Count; i++)
                {
                    cListTerm.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cListTerm.Items.Count; i++)
                {
                    cListTerm.SetItemChecked(i, false);
                }
            }
        }

        private void ckbCharges_Click(object sender, EventArgs e)
        {
            if (ckbCharges.Checked == true)
            {
                for (int i = 0; i < cListCharges.Items.Count; i++)
                {
                    cListCharges.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cListCharges.Items.Count; i++)
                {
                    cListCharges.SetItemChecked(i, false);
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if(SLS.Static.ID == 0)
            {
                if (cListMode.CheckedItems.Count != 0 && cListTerm.CheckedItems.Count != 0)
                {
                    fillTable();
                    ckbMode.Enabled = false;
                    ckbTerm.Enabled = false;
                    ckbCharges.Enabled = false;
                    cListMode.Enabled = false;
                    cListTerm.Enabled = false;
                    cListCharges.Enabled = false;
                    btnDone.Enabled = false;
                }
            }
            else
            {

            }
            
        }
        public void fillTable()
        {
            if (SLS.Static.ID == 0)
            {
                try
                {

                    table.Columns.Add("ChargeID");
                    table.Columns.Add("Charges");
                    foreach (object modeChecked in cListMode.CheckedItems)
                    {
                        foreach (object termChecked in cListTerm.CheckedItems)
                        {
                            table.Columns.Add(new DataColumn("" + modeChecked.ToString() + " - " + termChecked.ToString(), typeof(Decimal)));
                        }
                    }
                }
                catch
                {

                }
                try
                {
                    DataRow Row = table.NewRow();
                    Row["ChargeID"] = 1;
                    Row["Charges"] = "Interest On Loan";
                    table.Rows.Add(Row);
                    foreach (object chargeChecked in cListCharges.CheckedItems)
                    {
                        SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        String sql = "SELECT ChargeID, chargeName FROM CHARGES WHERE chargeName = @chargeName";
                        Dictionary<String, Object> parameters = new Dictionary<string, object>();
                        parameters.Add("@chargeName", chargeChecked.ToString());
                        SqlDataReader reader = con.executeReader(sql, parameters);
                        if (reader.HasRows)
                        {
                            reader.Read();
                            Row = table.NewRow();
                            Row["ChargeID"] = reader[0].ToString();
                            Row["Charges"] = reader[1].ToString();
                            table.Rows.Add(Row);
                        }
                    }
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].Visible = false;


                }
                catch
                {

                }
            }
            else
            {

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    dataGridView1.CurrentCell.Selected = false;
                }
                txtRate.Focus();
                txtRate.Clear();
                    
            }
            catch
            {

            }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                dataGridView1.CurrentCell.Value = txtRate.Text;
                try
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex + 1];
                }
                catch
                {
                    try
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[cell.RowIndex + 1].Cells[2];
                    }
                    catch
                    {

                    }
                }

            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            table.Clear();
            table.Columns.Clear();
            dataGridView1.DataSource = table;
            ckbMode.Enabled = true;
            ckbTerm.Enabled = true;
            ckbCharges.Enabled = true;
            cListMode.Enabled = true;
            cListTerm.Enabled = true;
            cListCharges.Enabled = true;
            btnDone.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(SLS.Static.ID == 0)
            {
                if(checkValues() == 1)
                {
                    MessageBox.Show("Some required fields are missing or invalid.", "Error");
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO LOANTYPE (loanTypeName, minAmount, maxAmount, noOfComaker, entitlement, eligibility, gracePeriod, graceTime, penalty, [status]) VALUES (@loanTypeName, @minAmount, @maxAmount, @noOfComaker, @entitlement, @eligibility, @gracePeriod, @graceTime, @penalty, @status); SELECT CAST(scope_identity() AS int)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@loanTypeName", txtLoanType.Text);
                    parameters.Add("@minAmount", txtMinAmount.Text);
                    parameters.Add("@maxAmount", txtMaxAmount.Text);
                    parameters.Add("@noOfComaker", txtNoOfComaker.Text);
                    parameters.Add("@entitlement", txtEntitlement.Text);
                    parameters.Add("@eligibility", txtEligibility.Text);
                    parameters.Add("@gracePeriod", txtGrace.Text);
                    parameters.Add("@graceTime", cobGrace.SelectedIndex);
                    parameters.Add("@penalty", txtPenalty.Text);
                    parameters.Add("@status", true);
                    SqlDataReader reader = con.executeReader(sql, parameters);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        MessageBox.Show("Adding a loan type is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (object itemChecked in cListMemType.CheckedItems)
                        {
                            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                            sql = "INSERT INTO APPLICABLELOAN (LoanTypeID, MemberTypeID) VALUES (@LoanTypeID,(SELECT MemberTypeID FROM MEMBERTYPE WHERE memberTypeName = @memberTypeName))";
                            parameters = new Dictionary<string, object>();
                            parameters.Add("@LoanTypeID", reader[0]);
                            parameters.Add("@memberTypeName", itemChecked.ToString());
                            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        }
                        modeArr = new String[cListMode.Items.Count];
                        int sInd = 0;
                        for (int i = 0; i < cListMode.Items.Count; i++)
                        {
                            if (cListMode.GetItemCheckState(i) == CheckState.Checked)
                            {
                                modeArr[sInd] = Convert.ToString(cListMode.Items[i]);
                                sInd++;
                            }
                        }
                        termArr = new Int32[cListTerm.Items.Count];
                        sInd = 0;
                        for (int i = 0; i < cListTerm.Items.Count; i++)
                        {
                            if (cListMode.GetItemCheckState(i) == CheckState.Checked)
                            {
                                termArr[sInd] = Convert.ToInt32(cListTerm.Items[i].ToString());
                                sInd++;
                            }
                        }
                        for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
                        {
                            for (int k = 2; k <= dataGridView1.Columns.Count - 1; k++)
                            {
                                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                                sql = "INSERT INTO LOANRATE (ModeID, ChargeID, TermID, LoanTypeID, rate) VALUES ((SELECT ModeID FROM MODE WHERE modeName = @modeName AND [status] = 1), @ChargeID, (SELECT TermID FROM TERM WHERE noOfDays = @noOfDays AND [status] = 1), @LoanTypeID, @rate)";
                                parameters = new Dictionary<string, object>();
                                parameters.Add("@modeName", modeArr[(k - 2) / cListTerm.CheckedItems.Count]);
                                parameters.Add("@ChargeID", Convert.ToInt32(dataGridView1.Rows[j].Cells[0].Value.ToString()));
                                parameters.Add("@noOfDays", termArr[(k - 2) / cListMode.CheckedItems.Count]);
                                parameters.Add("@LoanTypeID", reader[0]);
                                parameters.Add("@rate", Convert.ToDecimal(dataGridView1.Rows[j].Cells[k].Value.ToString()));
                                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                            }
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a loan type is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        public Int32 checkValues()
        {
            Int32 isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            if(ctrlString.checkString(txtLoanType.Text) == 1)
            {
                isValid = 1;
                er1.Visible = true;
            }
            try
            {
                Convert.ToDecimal(txtMinAmount.Text);
            }
            catch
            {
                isValid = 1;
                er2.Visible = true;
            }
            try
            {
                Convert.ToDecimal(txtMaxAmount.Text);
            }
            catch
            {
                isValid = 1;
                er3.Visible = true;
            }
            try
            {
                Convert.ToInt32(txtNoOfComaker.Text);
            }
            catch
            {
                isValid = 1;
                er4.Visible = true;
            }
            try
            {
                Convert.ToDecimal(txtEntitlement.Text);
            }
            catch
            {
                isValid = 1;
                er5.Visible = true;
            }
            try
            {
                Convert.ToDecimal(txtEligibility.Text);
            }
            catch
            {
                isValid = 1;
                er6.Visible = true;
            }
            try
            {
                for (int j = 0; j <= dataGridView1.Rows.Count - 1 && isValid != 1; j++)
                {
                    for (int k = 2; k <= dataGridView1.Columns.Count - 1 && isValid != 1; k++)
                    {
                        try
                        {
                            Convert.ToDecimal(dataGridView1.Rows[j].Cells[k].Value.ToString());
                        }
                        catch
                        {
                            isValid = 1;
                        }
                    }
                }
            }
            catch
            {
                isValid = 1;
            }
            try
            {
                Convert.ToDecimal(txtGrace.Text);
            }
            catch
            {
                isValid = 1;
                er7.Visible = true;
            }
            try
            {
                Convert.ToInt32(cobGrace.SelectedIndex);
            }
            catch
            {
                isValid = 1;
                er8.Visible = true;
            }
            try
            {
                Convert.ToDecimal(txtPenalty.Text);
            }
            catch
            {
                isValid = 1;
                er9.Visible = true;
            }
            return isValid;
        }

        private void ckbGrace_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbGrace.Checked == true)
            {
                defaultGrace();
                cobGrace.Enabled = true;
                txtGrace.Enabled = true;
            }
            else
            {
                txtGrace.Clear();
                txtGrace.Enabled = false;
                cobGrace.Items.Clear();
                cobGrace.Enabled = false;
            }
        }
    }
}
