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

namespace SLS
{
    public partial class MainMenu : Form
    {
        public string user;
        public string compName;
        public string compAddress;
        public string compContact;
        public MainMenu()
        {
            InitializeComponent();
            timer.Start();
            getInfos();
            user = "";
            compName = "";
            compAddress = "";
            compContact = "";
            OnStart();
            processDisplay();
        }

        public void OnStart()
        {
            MainMenuForm.Dashboard Das = new MainMenuForm.Dashboard();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Das.TopLevel = false;
            Das.Dock = DockStyle.None;
            Das.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Das);
        }

        public void processDisplay()
        {

        }

        private void getInfos()
        {
            try
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = "SELECT [USER].fName, [USER].mName, [USER].lName, COMPANY.companyName, COMPANY.street, COMPANY.brgy, COMPANY.city, COMPANY.mobileNoCountryCode, COMPANY.mobileNo, COMPANY.teleNoCountryCode, COMPANY.teleNo FROM [USER], COMPANY where [USER].UserID = @UserID";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@UserID", SLS.Static.UserID);
                SqlDataReader reader = con.executeReader(sql, parameters);
                while (reader.Read())
                {
                    try
                    {
                        user = string.Concat(user, reader.GetString(0));
                    }
                    catch(Exception)
                    {

                    }
                    try
                    {
                        user = string.Concat(user, ' ');
                        user = string.Concat(user, reader.GetString(1));
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        user = string.Concat(user, ' ');
                        user = string.Concat(user, reader.GetString(2));
                    }
                    catch (Exception)
                    {

                    }
                    lblUser.Text = user;
                    try
                    {
                        compName = string.Concat(compName, reader.GetString(3));
                    }
                    catch (Exception)
                    {

                    }
                    lblCompName.Text = compName;
                    try
                    {
                        compAddress = string.Concat(compAddress, reader.GetString(4));
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        compAddress = string.Concat(compAddress, ", "); 
                        compAddress = string.Concat(compAddress, reader.GetString(5));
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        compAddress = string.Concat(compAddress, ", ");
                        compAddress = string.Concat(compAddress, reader.GetString(6));
                    }
                    catch (Exception)
                    {

                    }
                    lblCompAddress.Text = compAddress;
                    try
                    {
                        compContact = string.Concat(compContact, reader.GetString(7));
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        compContact = string.Concat(compContact, reader.GetString(8));
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        compContact = string.Concat(compContact, " / ");
                        compContact = string.Concat(compContact, reader.GetString(9));
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        compContact = string.Concat(compContact, reader.GetString(10));
                    }
                    catch (Exception)
                    {

                    }
                    lblCompContact.Text = compContact;
                    //lblUser.Text = reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                    //lblCompName.Text = reader.GetString(3);
                    //lblCompAddress.Text = reader.GetString(4) + ", " + reader.GetString(5) + ", " + reader.GetString(6);
                    //lblCompContact.Text = reader.GetString(7) + " / " + reader.GetString(8);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot load program details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToShortTimeString();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            changeButtonLayout(0);
            MainMenuForm.Dashboard Das = new MainMenuForm.Dashboard();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Das.TopLevel = false;
            Das.Dock = DockStyle.None;
            Das.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Das);
        }
        private void btnMember_Click(object sender, EventArgs e)
        {
            changeButtonLayout(1);
            MainMenuForm.Member Mem = new MainMenuForm.Member();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Mem.TopLevel = false;
            Mem.Dock = DockStyle.None;
            Mem.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Mem);
        }
        private void btnTime_Click(object sender, EventArgs e)
        {
            changeButtonLayout(3);
            MainMenuForm.Time Tim = new MainMenuForm.Time();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Tim.TopLevel = false;
            Tim.Dock = DockStyle.None;
            Tim.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Tim);
        }
        private void btnSavings_Click(object sender, EventArgs e)
        {
            changeButtonLayout(2);
            MainMenuForm.Savings Sav = new MainMenuForm.Savings();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Sav.TopLevel = false;
            Sav.Dock = DockStyle.None;
            Sav.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Sav);
        }
        private void btnLoan_Click(object sender, EventArgs e)
        {
            changeButtonLayout(4);
            MainMenuForm.Loan Loa = new MainMenuForm.Loan();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            Loa.TopLevel = false;
            Loa.Dock = DockStyle.None;
            Loa.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(Loa);
        }
        private void btnUtilities_Click(object sender, EventArgs e)
        {
            changeButtonLayout(5);
            MainMenuForm.Utilities utilities = new MainMenuForm.Utilities();
            while (pnlMain.Controls.Count > 0)
                pnlMain.Controls[0].Dispose();
            utilities.TopLevel = false;
            utilities.Dock = DockStyle.None;
            utilities.Visible = true;
            pnlMain.Visible = true;
            pnlMain.Controls.Add(utilities);
        }
        private void changeButtonLayout (int buttonNum)
        {
            if (buttonNum == 0)
            {
                btnDashboard.ForeColor = Color.MidnightBlue;
                btnMember.ForeColor = Color.WhiteSmoke;
                btnLoan.ForeColor = Color.WhiteSmoke;
                btnSavings.ForeColor = Color.WhiteSmoke;
                btnTime.ForeColor = Color.WhiteSmoke;
                btnUtilities.ForeColor = Color.WhiteSmoke;
                btnDashboard.BackColor = Color.WhiteSmoke;
                btnMember.BackColor = Color.Transparent;
                btnLoan.BackColor = Color.Transparent;
                btnSavings.BackColor = Color.Transparent;
                btnTime.BackColor = Color.Transparent;
                btnUtilities.BackColor = Color.Transparent;
            }
            else if (buttonNum == 1)
            {
                btnDashboard.ForeColor = Color.WhiteSmoke;
                btnMember.ForeColor = Color.MidnightBlue;
                btnLoan.ForeColor = Color.WhiteSmoke;
                btnSavings.ForeColor = Color.WhiteSmoke;
                btnTime.ForeColor = Color.WhiteSmoke;
                btnUtilities.ForeColor = Color.WhiteSmoke;
                btnDashboard.BackColor = Color.Transparent;
                btnMember.BackColor = Color.WhiteSmoke;
                btnLoan.BackColor = Color.Transparent;
                btnSavings.BackColor = Color.Transparent;
                btnTime.BackColor = Color.Transparent;
                btnUtilities.BackColor = Color.Transparent;
            }
            else if (buttonNum == 2)
            {
                btnDashboard.ForeColor = Color.WhiteSmoke;
                btnMember.ForeColor = Color.WhiteSmoke;
                btnLoan.ForeColor = Color.WhiteSmoke;
                btnSavings.ForeColor = Color.MidnightBlue;
                btnTime.ForeColor = Color.WhiteSmoke;
                btnUtilities.ForeColor = Color.WhiteSmoke;
                btnDashboard.BackColor = Color.Transparent;
                btnMember.BackColor = Color.Transparent;
                btnLoan.BackColor = Color.Transparent;
                btnSavings.BackColor = Color.WhiteSmoke;
                btnTime.BackColor = Color.Transparent;
                btnUtilities.BackColor = Color.Transparent;
            }
            else if (buttonNum == 3)
            {
                btnDashboard.ForeColor = Color.WhiteSmoke;
                btnMember.ForeColor = Color.WhiteSmoke;
                btnLoan.ForeColor = Color.WhiteSmoke;
                btnSavings.ForeColor = Color.WhiteSmoke;
                btnTime.ForeColor = Color.MidnightBlue;
                btnUtilities.ForeColor = Color.WhiteSmoke;
                btnDashboard.BackColor = Color.Transparent;
                btnMember.BackColor = Color.Transparent;
                btnLoan.BackColor = Color.Transparent;
                btnSavings.BackColor = Color.Transparent;
                btnTime.BackColor = Color.WhiteSmoke;
                btnUtilities.BackColor = Color.Transparent;
            }
            else if (buttonNum == 4)
            {
                btnDashboard.ForeColor = Color.WhiteSmoke;
                btnMember.ForeColor = Color.WhiteSmoke;
                btnLoan.ForeColor = Color.MidnightBlue;
                btnSavings.ForeColor = Color.WhiteSmoke;
                btnTime.ForeColor = Color.WhiteSmoke;
                btnUtilities.ForeColor = Color.WhiteSmoke;
                btnDashboard.BackColor = Color.Transparent;
                btnMember.BackColor = Color.Transparent;
                btnLoan.BackColor = Color.WhiteSmoke;
                btnSavings.BackColor = Color.Transparent;
                btnTime.BackColor = Color.Transparent;
                btnUtilities.BackColor = Color.Transparent;
            }
            else if (buttonNum == 5)
            {
                btnDashboard.ForeColor = Color.WhiteSmoke;
                btnMember.ForeColor = Color.WhiteSmoke;
                btnLoan.ForeColor = Color.WhiteSmoke;
                btnSavings.ForeColor = Color.WhiteSmoke;
                btnTime.ForeColor = Color.WhiteSmoke;
                btnUtilities.ForeColor = Color.MidnightBlue;
                btnDashboard.BackColor = Color.Transparent;
                btnMember.BackColor = Color.Transparent;
                btnLoan.BackColor = Color.Transparent;
                btnSavings.BackColor = Color.Transparent;
                btnTime.BackColor = Color.Transparent;
                btnUtilities.BackColor = Color.WhiteSmoke;
            }
        }
    }
}
