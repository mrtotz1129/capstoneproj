using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SLS.Loan.Application
{
    public partial class ModeOfPayment : Form
    {
        public Int32 daysInterval = 0;
        public ModeOfPayment()
        {
            InitializeComponent();
            defaultAll();
        }

        public Int32 checkValues()
        {
            //Required Fields Validation
            Int32 isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            if (ctrlString.checkString(txtModeName.Text) == 1)
            {
                isValid = 1;
                er1.Visible = true;
            }
            try
            {
                Convert.ToInt32(txtDaysInterval.Text);
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT daysInterval FROM MODE";
                SqlDataReader reader = con.executeReader(sql);
                while(reader.Read())
                {
                    if (SLS.Static.ID == 0)
                    {
                        if (Convert.ToInt32(txtDaysInterval.Text) == Convert.ToInt32(reader.GetInt32(0)))
                        {
                            er2.Visible = true;
                            isValid = 1;
                        }
                    }
                    else
                    {
                        if(daysInterval != Convert.ToInt32(txtDaysInterval.Text))
                        {
                            if (Convert.ToInt32(txtDaysInterval.Text) == Convert.ToInt32(reader[0]))
                            {
                                er2.Visible = true;
                                isValid = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                isValid = 1;
                er2.Visible = true;
            }

            return isValid;
        }
        
        public void defaultAll()
        {
            txtModeName.Clear();
            txtDaysInterval.Clear();
            er1.Visible = false;
            er2.Visible = false;
            if (SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT modeName, daysInterval FROM MODE where ModeID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtModeName.Text = Convert.ToString(reader[0]);
                    txtDaysInterval.Text = Convert.ToString(reader[1]);
                    daysInterval = Convert.ToInt32(reader[1]);
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if (checkValues() == 0)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO MODE (modeName, daysInterval, [status]) VALUES (@modeName, @daysInterval, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@modeName", txtModeName.Text);
                    parameters.Add("@daysInterval", txtDaysInterval.Text);
                    parameters.Add("@status", true);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a mode of payment is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a mode of payment is not successful.", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                        MessageBox.Show("Some required fields are missing/invalid!", "Error");
                }
            }
            else
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "UPDATE MODE SET modeName = @modeName, daysInterval = @daysInterval WHERE ModeID = " + SLS.Static.ID + " ";                   
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@modeName", txtModeName.Text);
                parameters.Add("@daysInterval", txtDaysInterval.Text);
                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                if (result == 1)
                {
                    MessageBox.Show("Updating a mode of payment is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    defaultAll();
                    this.Close();
                }
                else
                {
                     MessageBox.Show("Updating a mode of payment is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
