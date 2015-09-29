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
    public partial class TermOfPayment : Form
    {
        public Int32 NoDays = 0;
        public TermOfPayment()
        {
            InitializeComponent();
            defaultAll();
        }

        public void defaultAll()
        {
            txtNoDays.Clear();
            er1.Visible = false;
            if (SLS.Static.ID != 0)
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT noOfDays FROM TERM where TermID = " + SLS.Static.ID + " ";
                SqlDataReader reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtNoDays.Text = Convert.ToString(reader[0]);
                    NoDays = Convert.ToInt32(reader[0]);
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if (checkValues() == 0)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO TERM (noOfDays, status) VALUES (@noOfDays, @status)";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@noOfDays", txtNoDays.Text);
                    parameters.Add("@status", true);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("Adding a term of payment is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a term of payment is not successful.", "Error", MessageBoxButtons.OK);
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
               String sql = "UPDATE TERM SET noOfDays = @noOfDays WHERE TermID = " + SLS.Static.ID + " ";
               Dictionary<String, Object> parameters = new Dictionary<string, object>();
               parameters.Add("@noOfDays", txtNoDays.Text);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

        public Int32 checkValues()
        {
            //Required Fields Validation
            Int32 isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            try
            {
                Convert.ToInt32(txtNoDays.Text);
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT daysInterval FROM TERM";
                SqlDataReader reader = con.executeReader(sql);
                while (reader.Read())
                {
                    if (SLS.Static.ID == 0)
                    {
                        if (Convert.ToInt32(txtNoDays.Text) == Convert.ToInt32(reader.GetInt32(0)))
                        {
                            er1.Visible = true;
                            isValid = 1;
                        }
                    }
                    else
                    {
                        if (NoDays != Convert.ToInt32(txtNoDays.Text))
                        {
                            if (Convert.ToInt32(txtNoDays.Text) == Convert.ToInt32(reader[0]))
                            {
                                er1.Visible = true;
                                isValid = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                isValid = 1;
                er1.Visible = true;
            }

            return isValid;
        }

    }
}
