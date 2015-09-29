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

namespace SLS.SavingsDeposit.Application
{
    public partial class Dormancy : Form
    {
        String[] timeString = { "Day/s", "Week/s", "Month/s", "Year/s" };
        String[] NatureString = { "Fixed Amount", "Percentage" };
        String[] ModeString = { "Day", "Week", "Month", "Year" };

        Int32 DormancyID, result;

        public Dormancy()
        {
            InitializeComponent();
            defaultAll();
        }
        
        public void defaultAll()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT savingsTypeName FROM SAVINGSTYPE where hasDormancy = 0";
            SqlDataReader reader = con.executeReader(sql);
            cobSavingsType.Items.Clear();
            int i = 0;
            while (reader.Read())
            {
                string str = reader[0].ToString();
                cobSavingsType.Items.Insert(i, "" + str);
                i += 1;
            }
            cobSavingsType.Text = "";
            cobSavingsType.Enabled = true;
            er1.Visible = true;

            txtInactiveValue.Text = "";
            er2.Visible = true;

            cobInactiveTime.Items.Clear();
            for (i = 0; i < timeString.Length; i++)
            {
                cobInactiveTime.Items.Insert(i, "" + timeString[i]);
            }
            cobInactiveTime.Text = "";
            er3.Visible = true;

            txtDeductAmount.Text = "";
            er4.Visible = true;

            cobDeductNature.Items.Clear();
            for (i = 0; i < NatureString.Length; i++)
            {
                cobDeductNature.Items.Insert(i, "" + NatureString[i]);
            }
            cobDeductNature.Text = "";
            er5.Visible = true;

            cobDeductMode.Items.Clear();
            for (i = 0; i < ModeString.Length; i++)
            {
                cobDeductMode.Items.Insert(i, "" + ModeString[i]);
            }
            cobDeductMode.Text = "";
            er6.Visible = true;

            txtActivateFee.Text = "";
            er7.Visible = true;

            if (SLS.Static.ID != 0)
            {
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT DORMANCY.DormancyID, SAVINGSTYPE.savingsTypeName, DORMANCY.inactivityValue, DORMANCY.inactivityTime, DORMANCY.deductionAmount, DORMANCY.isPercentage, DORMANCY.deductionMode, DORMANCY.activationFee, DORMANCY.[status] FROM DORMANCY, SAVINGSTYPE WHERE DORMANCY.SavingsTypeID = SAVINGSTYPE.SavingsTypeID AND DORMANCY.DormancyID = " + SLS.Static.ID + " ";
                reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    DormancyID = Convert.ToInt32(reader[0]);

                    cobSavingsType.Items.Insert(cobSavingsType.Items.Count, "" + reader[1].ToString());
                    int index = cobSavingsType.Items.IndexOf(reader[1]);
                    cobSavingsType.SelectedIndex = index;
                    cobSavingsType.Enabled = false;
                    er1.Visible = false;

                    txtInactiveValue.Text = Convert.ToString(reader[2]);
                    er2.Visible = false;

                    cobInactiveTime.SelectedIndex = Convert.ToInt32(reader[3]);
                    er3.Visible = false;

                    txtDeductAmount.Text = Convert.ToString(reader[4]);
                    er4.Visible = false;

                    cobDeductNature.SelectedIndex = Convert.ToInt32(reader[5]);
                    er5.Visible = false;

                    cobDeductMode.SelectedIndex = Convert.ToInt32(reader[6]);
                    er6.Visible = false;

                    txtActivateFee.Text = Convert.ToString(reader[7]);
                    er7.Visible = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(SLS.Static.ID == 0)
            {
                if (checkValues() == 1)
                {
                    MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO DORMANCY (inactivityValue, inactivityTime, deductionAmount, isPercentage, deductionMode, activationFee, [status], SavingsTypeID) VALUES (@inactivityValue, @inactivityTime, @deductionAmount, @isPercentage, @deductionMode, @activationFee, @status, (SELECT SavingsTypeID FROM SAVINGSTYPE WHERE savingsTypeName = @savingsTypeName))";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@inactivityValue", txtInactiveValue.Text);
                    parameters.Add("@inactivityTime", cobInactiveTime.SelectedIndex);
                    parameters.Add("@deductionAmount", txtDeductAmount.Text);
                    parameters.Add("@isPercentage", cobDeductNature.SelectedIndex);
                    parameters.Add("@deductionMode", cobDeductMode.SelectedIndex);
                    parameters.Add("@activationFee", txtActivateFee.Text);
                    parameters.Add("@status", true);
                    parameters.Add("@savingsTypeName", cobSavingsType.SelectedItem.ToString());
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a dormancy is successful.", "Saved", MessageBoxButtons.OK);
                        con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        sql = "UPDATE SAVINGSTYPE SET hasDormancy = 'true' WHERE SavingsTypeID = (SELECT SavingsTypeID FROM DORMANCY WHERE DormancyID = (SELECT MAX(DormancyID) FROM DORMANCY))";
                        parameters = new Dictionary<string, object>();
                        parameters.Add("@status", true);
                        result = Convert.ToInt32(con.executeNonQuery(sql, parameters));

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a dormancy is not suuccessful.", "Error", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                    if (checkValues() == 1)
                    {
                        MessageBox.Show("Some required field/s are missing or invalid.", "Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        String sql = "UPDATE DORMANCY SET inactivityValue = @inactivityValue, inactivityTime = @inactivityTime, deductionAmount = @deductionAmount, isPercentage = @isPercentage, deductionMode = @deductionMode, activationFee = @activationFee, [status] = @status, SavingsTypeID = (SELECT SavingsTypeID FROM SAVINGSTYPE WHERE savingsTypeName = @savingsTypeName) WHERE DormancyID = @DormancyID";
                        Dictionary<String, Object> parameters = new Dictionary<string, object>();
                        parameters.Add("@inactivityValue", txtInactiveValue.Text);
                        parameters.Add("@inactivityTime", cobInactiveTime.SelectedIndex);
                        parameters.Add("@deductionAmount", txtDeductAmount.Text);
                        parameters.Add("@isPercentage", cobDeductNature.SelectedIndex);
                        parameters.Add("@deductionMode", cobDeductMode.SelectedIndex);
                        parameters.Add("@activationFee", txtActivateFee.Text);
                        parameters.Add("@status", true);
                        parameters.Add("@savingsTypeName", cobSavingsType.Text.ToString());
                        parameters.Add("@DormancyID", DormancyID);
                        result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        if (result == 1)
                        {
                            MessageBox.Show("Updated.", "Saved", MessageBoxButtons.OK);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Not Updated.", "Error", MessageBoxButtons.OK);
                        }
                    }
                }
        }
        private Int32 checkValues()
        {
            int isValid = 0;
            if (cobSavingsType.Text.ToString() == "")
            {
                er1.Visible = true;
                isValid = 1;
            }
            try
            {
                Convert.ToInt32(txtInactiveValue.Text);
            }
            catch
            {
                er2.Visible = true;
                isValid = 1;
            }
            if(cobInactiveTime.Text.ToString() == "")
            {
                er3.Visible = true;
                isValid = 1;
            }
            try
            {
                Convert.ToDecimal(txtDeductAmount.Text);
            }
            catch
            {
                er4.Visible = true;
                isValid = 1;
            }
            if(cobDeductNature.Text.ToString() == "")
            {
                er5.Visible = true;
                isValid = 1;
            }
            if(cobDeductMode.Text.ToString() == "")
            {
                er6.Visible = true;
                isValid = 1;
            }
            try
            {
                Convert.ToDecimal(txtActivateFee.Text);
            }
            catch
            {
                er7.Visible = true;
                isValid = 1;
            }
            return isValid;
        }

        private void cobSavingsType_Enter(object sender, EventArgs e)
        {
            er1.Visible = false;
        }

        private void txtInactiveValue_Enter(object sender, EventArgs e)
        {
            er2.Visible = false;
        }

        private void cobInactiveTime_Enter(object sender, EventArgs e)
        {
            er3.Visible = false;
        }

        private void txtDeductAmount_Enter(object sender, EventArgs e)
        {
            er4.Visible = false;
        }

        private void cobDeductNature_Enter(object sender, EventArgs e)
        {
            er5.Visible = false;
        }

        private void cobDeductMode_Enter(object sender, EventArgs e)
        {
            er6.Visible = false;
        }

        private void txtActivateFee_Enter(object sender, EventArgs e)
        {
            er7.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
