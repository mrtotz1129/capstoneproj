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

namespace SLS.Member.Application
{
    public partial class MemberType : Form
    {
        public Int32 MemberTypeID;
        public string errMsg;
        public MemberType()
        {
            InitializeComponent();
            defaultAll();
        }
        private void ckbLoan_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbLoan.Checked == true)
            {
                txtShare.Enabled = true;
                er5.Visible = true;
                txtShare.Clear();
            }
            else
            {
                txtShare.Enabled = false;
                er5.Visible = false;
                txtShare.Clear();
            }
        }
        public void defaultAll()
        {
            txtMemName.Text = "";
            txtMinAge.Text = "";
            txtMaxAge.Text = "";
            txtFee.Text = "";
            ckbSavings.Checked = false;
            ckbTime.Checked = false;
            ckbLoan.Checked = false;
            txtShare.Text = "";
            er1.Visible = true;
            er2.Visible = true;
            er3.Visible = true;
            er4.Visible = true;
            er5.Visible = false;
            if (SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT MemberTypeID, MemberTypeName, MinAgeRequired, MaxAgeRequired, Fee, SavingsApplicable, TimeApplicable, LoanApplicable, ShareRequired FROM MEMBERTYPE where MemberTypeID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    MemberTypeID = Convert.ToInt32(reader[0]);
                    txtMemName.Text = Convert.ToString(reader[1]);
                    txtMinAge.Text = Convert.ToString(reader[2]);
                    txtMaxAge.Text = Convert.ToString(reader[3]);
                    txtFee.Text = Convert.ToString(reader[4]);
                    if (Convert.ToString(reader[5]) == "True")
                    {
                        ckbSavings.Checked = true;
                    }
                    else
                    {
                        ckbSavings.Checked = false;
                    }
                    if (Convert.ToString(reader[6]) == "True")
                    {
                        ckbTime.Checked = true;
                    }
                    else
                    {
                        ckbTime.Checked = false;
                    }
                    if (Convert.ToString(reader[7]) == "True")
                    {
                        ckbLoan.Checked = true;
                        txtShare.Enabled = true;
                        txtShare.Text = Convert.ToString(reader[8]);
                    }
                    else
                    {
                        ckbLoan.Checked = false;
                        txtShare.Enabled = false;
                        txtShare.Clear();
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

        private Int32 checkValues()
        {
            Int32 isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            isValid = ctrlString.checkString(txtMemName.Text);
            if (isValid == 1)
            {
                er1.Visible = true;
            }
            try
            {
                if (Convert.ToInt32(txtMinAge.Text) >= Convert.ToInt32(txtMaxAge.Text))
                {
                    er2.Visible = true;
                    er3.Visible = true;
                    isValid = 1;
                }
            }
            catch(Exception)
            {
                try
                {
                    Convert.ToInt32(txtMinAge.Text);
                }
                catch (Exception)
                {
                    er2.Visible = true;
                    isValid = 1;
                }
                try
                {
                    Convert.ToInt32(txtMaxAge.Text);
                }
                catch (Exception)
                {
                    er3.Visible = true;
                    isValid = 1;
                }
            }
            try
            {
                Convert.ToDecimal(txtFee.Text);
            }
            catch (Exception)
            {
                er4.Visible = true;
                isValid = 1;
            }
            if (txtShare.Text == "" && ckbLoan.Checked == false)
            {
                txtShare.Text = "0";
            }
            else
            {
                try
                {
                    Convert.ToDecimal(txtShare.Text);
                }
                catch (Exception)
                {
                    er5.Visible = true;
                    isValid = 1;
                }
            }
            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if (checkValues() == 1)
                {
                    MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO MEMBERTYPE (MemberTypeName, SavingsApplicable, TimeApplicable, LoanApplicable, MinAgeRequired, MaxAgeRequired, Fee, ShareRequired, [status]) VALUES (@MemberTypeName, @SavingsApplicable, @TimeApplicable, @LoanApplicable, @MinAgeRequired,  @MaxAgeRequired, @Fee, @ShareRequired, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@MemberTypeName", txtMemName.Text);
                    parameters.Add("@SavingsApplicable", ckbSavings.CheckState);
                    parameters.Add("@TimeApplicable", ckbTime.CheckState);
                    parameters.Add("@LoanApplicable", ckbLoan.CheckState);
                    parameters.Add("@minAgeRequired", txtMinAge.Text);
                    parameters.Add("@maxAgeRequired", txtMaxAge.Text);
                    parameters.Add("@Fee", txtFee.Text);
                    parameters.Add("@ShareRequired", txtShare.Text);
                    parameters.Add("@status", true);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding member type is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        defaultAll();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a member type is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (checkValues() == 1)
                {
                    MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE MEMBERTYPE SET memberTypeName = @memberTypeName, SavingsApplicable = @SavingsApplicable, TimeApplicable = @TimeApplicable, LoanApplicable = @LoanApplicable, MinAgeRequired = @MinAgeRequired, MaxAgeRequired = @MaxAgeRequired, Fee = @Fee, ShareRequired = @ShareRequired WHERE MemberTypeID = @MemberTypeID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@MemberTypeName", txtMemName.Text);
                    parameters.Add("@SavingsApplicable", ckbSavings.CheckState);
                    parameters.Add("@TimeApplicable", ckbTime.CheckState);
                    parameters.Add("@LoanApplicable", ckbLoan.CheckState);
                    parameters.Add("@MinAgeRequired", txtMinAge.Text);
                    parameters.Add("@MaxAgeRequired", txtMaxAge.Text);
                    parameters.Add("@Fee", txtFee.Text);
                    parameters.Add("@ShareRequired", txtShare.Text);
                    parameters.Add("@MemberTypeID", MemberTypeID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Updating a member type is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        defaultAll();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Updating a member type is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMemName_Enter(object sender, EventArgs e)
        {
            er1.Visible = false;
        }

        private void txtMinAge_Enter(object sender, EventArgs e)
        {
            er2.Visible = false;
        }

        private void txtMaxAge_Enter(object sender, EventArgs e)
        {
            er3.Visible = false;
        }

        private void txtFee_Enter(object sender, EventArgs e)
        {
            er4.Visible = false;
        }

        private void txtShare_Enter(object sender, EventArgs e)
        {
            er5.Visible = false;
        }
    }
}
