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

namespace SLS.Member.Application
{
    public partial class MembershipApplication : Form
    {
        String[] educString = { "Elementary", "High School", "College", "Masteral", "Doctoral" };
        String[] genderString = { "Male", "Female"};
        String[] civilStatusString = { "Single", "Married", "Widowed", "Separated"};
        String[] childGenderString = { "Male", "Female"};
        DataTable tableChild = new DataTable();
        Int32 sChild = 0, EmploymentInformationID = 0, employID = 0, occup = 0, emptype = 0, MemberID = 0, age = 0;
        Decimal initCapital = 0;

        public MembershipApplication()
        {
            InitializeComponent();
            defaultAll();
        }

        private void rbFullTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFullTime.Checked == true)
            {
                txtEmployerName.Enabled = true;
                txtEmployerAddress.Enabled = true;
                txtEmployerTelNo.Enabled = true;
                txtDateStarted.Enabled = true;
                txtMonthlySalary.Enabled = true;
                txtDepartment.Enabled = true;
                rbGovernment.Checked=true;
                rbGovernment.Enabled = true;
                rbPrivate.Enabled = true;
                rbAbroad.Enabled = true;
                txtTypeOfBusiness.Enabled = false;
                txtBusinessAdd.Enabled = false;
                txtStartingCapital.Enabled = false;
                txtPresentCapital.Enabled = false;
                txtMonthlyNetIncome.Enabled = false;
                txtTypeOfBusiness.Clear();
                txtBusinessAdd.Clear();
                txtStartingCapital.Clear();
                txtPresentCapital.Clear();
                txtMonthlyNetIncome.Clear();
                txtEmployerName.Clear();
                txtEmployerAddress.Clear();
                txtEmployerTelNo.Clear();
                txtDateStarted.Clear();
                txtMonthlySalary.Clear();
                txtDepartment.Clear();
            }
        }
        private void rbPartTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPartTime.Checked == true)
            {
                txtEmployerName.Enabled = true;
                txtEmployerAddress.Enabled = true;
                txtEmployerTelNo.Enabled = true;
                txtDateStarted.Enabled = true;
                txtMonthlySalary.Enabled = true;
                txtDepartment.Enabled = true;
                rbGovernment.Checked = true;
                rbGovernment.Enabled = true;
                rbPrivate.Enabled = true;
                rbAbroad.Enabled = true;
                txtTypeOfBusiness.Enabled = false;
                txtBusinessAdd.Enabled = false;
                txtStartingCapital.Enabled = false;
                txtPresentCapital.Enabled = false;
                txtMonthlyNetIncome.Enabled = false;
                txtTypeOfBusiness.Clear();
                txtBusinessAdd.Clear();
                txtStartingCapital.Clear();
                txtPresentCapital.Clear();
                txtMonthlyNetIncome.Clear();
                txtEmployerName.Clear();
                txtEmployerAddress.Clear();
                txtEmployerTelNo.Clear();
                txtDateStarted.Clear();
                txtMonthlySalary.Clear();
                txtDepartment.Clear();
            }
        }

        private void rbContractual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbContractual.Checked == true)
            {
                txtEmployerName.Enabled = true;
                txtEmployerAddress.Enabled = true;
                txtEmployerTelNo.Enabled = true;
                txtDateStarted.Enabled = true;
                txtMonthlySalary.Enabled = true;
                txtDepartment.Enabled = true;
                rbGovernment.Checked = true;
                rbGovernment.Enabled = true;
                rbPrivate.Enabled = true;
                rbAbroad.Enabled = true;
                txtTypeOfBusiness.Enabled = false;
                txtBusinessAdd.Enabled = false;
                txtStartingCapital.Enabled = false;
                txtPresentCapital.Enabled = false;
                txtMonthlyNetIncome.Enabled = false;
                txtTypeOfBusiness.Clear();
                txtBusinessAdd.Clear();
                txtStartingCapital.Clear();
                txtPresentCapital.Clear();
                txtMonthlyNetIncome.Clear();
                txtEmployerName.Clear();
                txtEmployerAddress.Clear();
                txtEmployerTelNo.Clear();
                txtDateStarted.Clear();
                txtMonthlySalary.Clear();
                txtDepartment.Clear();
            }
        }

        private void rbSelfEmployed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelfEmployed.Checked == true)
            {
                txtTypeOfBusiness.Enabled = true;
                txtBusinessAdd.Enabled = true;
                txtStartingCapital.Enabled = true;
                txtPresentCapital.Enabled = true;
                txtMonthlyNetIncome.Enabled = true;
                txtEmployerName.Enabled = false;
                txtEmployerAddress.Enabled = false;
                txtEmployerTelNo.Enabled = false;
                txtDateStarted.Enabled = false;
                txtMonthlySalary.Enabled = false;
                txtDepartment.Enabled = false;
                rbGovernment.Enabled = false;
                rbPrivate.Enabled = false;
                rbAbroad.Enabled = false;
                txtEmployerName.Clear();
                txtEmployerAddress.Clear();
                txtEmployerTelNo.Clear();
                txtDateStarted.Clear();
                txtMonthlySalary.Clear();
                txtDepartment.Clear();
            }
        }

        private void rbRetired_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRetired.Checked == true)
            {
                txtEmployerName.Enabled = false;
                txtEmployerAddress.Enabled = false;
                txtEmployerTelNo.Enabled = false;
                txtDateStarted.Enabled = false;
                txtMonthlySalary.Enabled = false;
                txtDepartment.Enabled = false;
                rbGovernment.Enabled = false;
                rbPrivate.Enabled = false;
                rbAbroad.Enabled = false;
                txtTypeOfBusiness.Enabled = false;
                txtBusinessAdd.Enabled = false;
                txtStartingCapital.Enabled = false;
                txtPresentCapital.Enabled = false;
                txtMonthlyNetIncome.Enabled = false;
                txtEmployerName.Clear();
                txtEmployerAddress.Clear();
                txtEmployerTelNo.Clear();
                txtDateStarted.Clear();
                txtMonthlySalary.Clear();
                txtDepartment.Clear();
                txtTypeOfBusiness.Clear();
                txtBusinessAdd.Clear();
                txtStartingCapital.Clear();
                txtPresentCapital.Clear();
                txtMonthlyNetIncome.Clear();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                txtFNLN.Enabled = true;
                txtFNMN.Enabled = true;
                txtFNFN.Enabled = true;
                dtFN.Enabled = true;
                label101.Visible = true;
                label102.Visible = true;
                label103.Visible = true;
            }
            else
            {
                txtFNLN.Enabled = false;
                txtFNMN.Enabled = false;
                txtFNFN.Enabled = false;
                dtFN.Enabled = false;
                txtFNLN.Clear();
                txtFNMN.Clear();
                txtFNFN.Clear();
                label101.Visible = false;
                label102.Visible = false;
                label103.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtMNLN.Enabled = true;
                txtMNMN.Enabled = true;
                txtMNFN.Enabled = true;
                dtMN.Enabled = true;
                label104.Visible = true;
                label105.Visible = true;
                label106.Visible = true;
            }
            else
            {
                txtMNLN.Enabled = false;
                txtMNMN.Enabled = false;
                txtMNFN.Enabled = false;
                dtMN.Enabled = false;
                txtMNLN.Clear();
                txtMNMN.Clear();
                txtMNFN.Clear();
                label104.Visible = false;
                label105.Visible = false;
                label106.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                txtSNLN.Enabled = true;
                txtSNMN.Enabled = true;
                txtSNFN.Enabled = true;
                dtSN.Enabled = true;
                checkBox4.Enabled = true;
                label107.Visible = true;
                label108.Visible = true;
                label109.Visible = true;
            }
            else
            {
                txtSNLN.Enabled = false;
                txtSNMN.Enabled = false;
                txtSNFN.Enabled = false;
                dtSN.Enabled = false;
                txtSNLN.Clear();
                txtSNMN.Clear();
                txtSNFN.Clear();
                checkBox4.Enabled = false;
                checkBox4.Checked = false;
                label107.Visible = false;
                label108.Visible = false;
                label109.Visible = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                txtCNLN.Enabled = true;
                txtCNMN.Enabled = true;
                txtCNFN.Enabled = true;
                cmbChildGender.Enabled = true;
                dtChild.Enabled = true;
                btnAddChild.Enabled = true;
                btnClearChild.Enabled = true;
                btnDeleteChild.Enabled = true;
                dataGridView1.Enabled = true;
                label110.Visible = true;
                label111.Visible = true;
                label112.Visible = true;
                label113.Visible = true;
            }
            else
            {
                txtCNLN.Enabled = false;
                txtCNMN.Enabled = false;
                txtCNFN.Enabled = false;
                cmbChildGender.Enabled = false;
                dtChild.Enabled = false;
                txtCNLN.Clear();
                txtCNMN.Clear();
                txtCNFN.Clear();
                btnAddChild.Enabled = false;
                btnClearChild.Enabled = false;
                btnDeleteChild.Enabled = false;
                dataGridView1.Enabled = false;
                label110.Visible = false;
                label111.Visible = false;
                label112.Visible = false;
                label113.Visible = false;
            }
        }
        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txtStreet2.Enabled = true;
                txtMunicipality2.Enabled = true;
                txtCity2.Enabled = true;
                txtZip2.Enabled = true;
                txtResidence2.Enabled = true;
                txtTelNo2.Enabled = true;
            }
            else
            {
                txtStreet2.Enabled = false;
                txtMunicipality2.Enabled = false;
                txtCity2.Enabled = false;
                txtZip2.Enabled = false;
                txtResidence2.Enabled = false;
                txtTelNo2.Enabled = false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void defaultAll()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT MAX(MemberID) FROM MEMBER";
            SqlDataReader reader = con.executeReader(sql);
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    txtMemberId.Text = "MEM - " + (reader.GetInt32(0) + 1).ToString("00000000");
                }
            }
            catch (Exception)
            {
                txtMemberId.Text = "MEM - 00000001";
            }

            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            sql = "SELECT MemberTypeName FROM MEMBERTYPE WHERE DATEDIFF(YEAR, @birthDate, @DateNow )BETWEEN MinAgeRequired AND MaxAgeRequired";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@birthDate", Convert.ToDateTime(dtDateBirth.Value));
            parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            reader = con.executeReader(sql, parameters);
            Int32 x = 0;
            cmbMemberType.Items.Clear();
            while (reader.Read())
            {
                cmbMemberType.Items.Insert(x, "" + reader.GetString(0));
                x++;
            }
            con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            sql = "SELECT CONCAT(fName,' ',mName,' ',lName) FROM CREDITINVESTIGATOR WHERE [status] = 1";
            reader = con.executeReader(sql);
            x = 0;
            cobCI.Items.Clear();
            while (reader.Read())
            {
                cobCI.Items.Insert(x, "" + reader.GetString(0));
                x++;
            }
            //Default Table Child
            try
            {
                tableChild.Clear();
                
            }
            catch
            {

            }
            finally
            {
                try
                {
                    tableChild.Columns.Add(new DataColumn("Last Name", typeof(string)));
                    tableChild.Columns.Add(new DataColumn("First Name", typeof(string)));
                    tableChild.Columns.Add(new DataColumn("Middle Name", typeof(string)));
                    tableChild.Columns.Add(new DataColumn("Gender", typeof(string)));
                    tableChild.Columns.Add(new DataColumn("Birthdate", typeof(string)));
                    dataGridView1.DataSource = tableChild;
                }
                catch
                {

                }
            }

            //Educational Attainment
            cmbEduc.Items.Clear();
            for(int i=0;i<educString.Length;i++)
            {
                cmbEduc.Items.Insert(i, "" + educString[i]);
            }

            //Gender
            cmbGender.Items.Clear();
            for (int i = 0; i < genderString.Length; i++)
            {
                cmbGender.Items.Insert(i, "" + genderString[i]);
            }

            //Child Gender
            cmbChildGender.Items.Clear();
            for (int i = 0; i < childGenderString.Length; i++)
            {
                cmbChildGender.Items.Insert(i, "" + childGenderString[i]);
            }

            //Civil Status
            cmbCivil.Items.Clear();
            for (int i = 0; i < civilStatusString.Length; i++)
            {
                cmbCivil.Items.Insert(i, "" + civilStatusString[i]);
            }

            //PersonalInformation
            txtLN.Clear();
            txtFN.Clear();
            txtMN.Clear();
            dtDateBirth.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            dtMembership.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            dtSeminar.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            txtGSISSSS.Clear();
            txtInitialCapital.Clear();
            txtMultiplier.Clear();
            txtAge.Clear();
            txtFee.Clear();
            //ContactInformation
            txtCPLN.Clear();
            txtCPFN.Clear();
            txtCPMN.Clear();
            txtContact.Clear();
            txtStreet.Clear();
            txtMunicipality.Clear();
            txtCity.Clear();
            txtZip.Clear();
            txtResidence.Clear();
            txtTelNo.Clear();
            checkBox2.Checked=false;
            txtStreet2.Clear();
            txtMunicipality2.Clear();
            txtCity2.Clear();
            txtZip2.Clear();
            txtResidence2.Clear();
            txtTelNo2.Clear();
            //EmploymentInformation
            rbGovernment.Checked = true; 
            txtEmployerName.Enabled = true;
            txtEmployerAddress.Enabled = true;
            txtEmployerTelNo.Enabled = true;
            txtDateStarted.Enabled = true;
            txtMonthlySalary.Enabled = true;
            txtDepartment.Enabled = true;
            rbGovernment.Enabled = true;
            rbPrivate.Enabled = true;
            rbAbroad.Enabled = true;
            txtTypeOfBusiness.Enabled = false;
            txtBusinessAdd.Enabled = false;
            txtStartingCapital.Enabled = false;
            txtPresentCapital.Enabled = false;
            txtMonthlyNetIncome.Enabled = false;
            txtTypeOfBusiness.Clear();
            txtBusinessAdd.Clear();
            txtStartingCapital.Clear();
            txtPresentCapital.Clear();
            txtMonthlyNetIncome.Clear();
            txtEmployerName.Clear();
            txtEmployerAddress.Clear();
            txtEmployerTelNo.Clear();
            txtDateStarted.Clear();
            txtMonthlySalary.Clear();
            txtDepartment.Clear();
            rbFullTime.Checked = true;
            //FamilyInformation
            //Mother
            checkBox1.Checked = false;
            txtMNLN.Enabled = false;
            txtMNMN.Enabled = false;
            txtMNFN.Enabled = false;
            dtMN.Enabled = false;
            txtMNLN.Clear();
            txtMNMN.Clear();
            txtMNFN.Clear();
            //Spouse
            checkBox3.Checked = false;
            txtSNLN.Enabled = false;
            txtSNMN.Enabled = false;
            txtSNFN.Enabled = false;
            dtSN.Enabled = false;
            txtSNLN.Clear();
            txtSNMN.Clear();
            txtSNFN.Clear();
            //Children
            checkBox4.Checked = false;
            txtCNLN.Enabled = false;
            txtCNMN.Enabled = false;
            txtCNFN.Enabled = false;
            dtChild.Enabled = false;
            cmbChildGender.Enabled = false;
            txtCNLN.Clear();
            txtCNMN.Clear();
            txtCNFN.Clear();
            btnAddChild.Enabled=false;
            btnDeleteChild.Enabled = false;
            btnClearChild.Enabled = false;
            //Father
            checkBox5.Checked = false;
            txtFNLN.Enabled = false;
            txtFNMN.Enabled = false;
            txtFNFN.Enabled = false;
            dtFN.Enabled = false;
            txtFNLN.Clear();
            txtFNMN.Clear();
            txtFNFN.Clear();

            //Asterisk in Family
            label101.Visible = false; label102.Visible = false;
            label103.Visible = false; label104.Visible = false;
            label105.Visible = false; label106.Visible = false;
            label107.Visible = false; label108.Visible = false;
            label109.Visible = false; label110.Visible = false;
            label111.Visible = false; label112.Visible = false;
            label113.Visible = false;


            if (SLS.Static.ID != 0)
            {
                //Personal Information UPDATE
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT MemberID, fName, mName, lName, gender, birthDate, civilStatus, gsisNo, educAttainment, paidMembershipFee, applyDate, seminarDate, initialCapital, multiplier, MEMBERTYPE.MemberTypeName FROM MEMBER, MEMBERTYPE WHERE MemberID = " + SLS.Static.ID + " AND MEMBER.MemberTypeID = MEMBERTYPE.MemberTypeID";
                reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtMemberId.Text = Convert.ToString(reader[0]);
                    txtFN.Text = Convert.ToString(reader[1]);
                    txtMN.Text = Convert.ToString(reader[2]);
                    txtLN.Text = Convert.ToString(reader[3]);
                        if (Convert.ToBoolean(reader[4]) == true)
                    {
                        cmbGender.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbGender.SelectedIndex = 1;
                    }
                    dtDateBirth.Text = (Convert.ToDateTime(reader[5])).ToString("MM/dd/yyyy");
                    cmbCivil.SelectedIndex = Convert.ToInt32(reader[6]);
                    txtGSISSSS.Text = Convert.ToString(reader[7]);
                    cmbEduc.SelectedIndex = Convert.ToInt32(reader[8]);
                    txtFee.Text = Convert.ToString(reader[9]);
                    dtMembership.Text = (Convert.ToDateTime(reader[10])).ToString("MM/dd/yyyy");
                    dtSeminar.Text = (Convert.ToDateTime(reader[11])).ToString("MM/dd/yyyy");
                    txtInitialCapital.Text = Convert.ToString(reader[12]);
                    txtMultiplier.Text = Convert.ToString(reader[13]);                    
                    int index = cmbMemberType.Items.IndexOf(reader[14]);
                    cmbMemberType.SelectedIndex = index;
                }
                //Contact Person UPDATE
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT contactLN, contactFN, contactMN, contactNo FROM CONTACTPERSON WHERE MemberID = " + SLS.Static.ID + "";
                reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtCPLN.Text = Convert.ToString(reader[0]);
                    txtCPFN.Text = Convert.ToString(reader[1]);
                    txtCPMN.Text = Convert.ToString(reader[2]);
                    txtContact.Text = Convert.ToString(reader[3]);
                }
                //Contact Information UPDATE
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT street, municipality, cityProvince, zipCode, residenceSince, telephoneNo FROM CONTACTINFORMATION WHERE MemberID = " + SLS.Static.ID + "";
                reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    txtStreet.Text = Convert.ToString(reader[0]);
                    txtMunicipality.Text = Convert.ToString(reader[1]);
                    txtCity.Text = Convert.ToString(reader[2]);
                    txtZip.Text = Convert.ToString(reader[3]);
                    txtResidence.Text = Convert.ToString(reader[4]);
                    txtTelNo.Text = Convert.ToString(reader[5]);
                }
                //Employment Information UPDATE
                con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                sql = "SELECT EmploymentInformationID, employmentNo FROM EMPLOYMENTINFORMATION WHERE MemberID = " + SLS.Static.ID + "";
                reader = con.executeReader(sql);
                if (reader.HasRows)
                {
                    reader.Read();
                    employID = Convert.ToInt32(reader[0]);
                    occup = Convert.ToInt32(reader[1]);
                }
                if (occup == 0  || occup == 1 || occup == 2)
                {
                    if(occup==0)
                    {
                        rbFullTime.Checked = true;
                    }
                    else
                    if(occup==1)
                    {
                        rbPartTime.Checked = true;
                    }
                    else
                    {
                        rbContractual.Checked = true;
                    }
                    //Employed UPDATE
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "SELECT employerName, employerAddress, employerType, employerTelNo, dateStarted, monthlySalary, department FROM EMPLOYED WHERE EmploymentInformationID = "+ employID.ToString() +"";
                    reader = con.executeReader(sql);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtEmployerName.Text = Convert.ToString(reader[0]);
                        txtEmployerAddress.Text = Convert.ToString(reader[1]);
                        emptype = Convert.ToInt32(reader[2]);
                        txtEmployerTelNo.Text = Convert.ToString(reader[3]);
                        txtDateStarted.Text = (Convert.ToDateTime(reader[4])).ToString("yyyy/MM/dd");
                        txtMonthlySalary.Text = Convert.ToString(reader[5]);
                        txtDepartment.Text = Convert.ToString(reader[6]);
                        if (emptype == 0)
                        {
                            rbGovernment.Checked = true;
                        }
                        else if (emptype == 1)
                        {
                            rbPrivate.Checked = true;
                        }
                        else
                        {
                            rbAbroad.Checked = true;
                        }
                    }
                }
                else if (occup == 3)
                {
                    //Self-Employed UPDATE
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "SELECT typeOfBusiness, startingCapital, monthlyNetIncome, businessAddress, presentCapital FROM SELFEMPLOYED WHERE EmploymentInformationID = "+ employID.ToString() +"";
                    reader = con.executeReader(sql);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtTypeOfBusiness.Text = Convert.ToString(reader[0]);
                        txtStartingCapital.Text = Convert.ToString(reader[1]);
                        txtMonthlyNetIncome.Text = Convert.ToString(reader[2]);
                        txtBusinessAdd.Text = Convert.ToString(reader[3]);
                        txtPresentCapital.Text = Convert.ToString(reader[4]);
                    }
                }
                else
                {
                    rbRetired.Checked = true;
                }
                //Family Information UPDATE
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "SELECT relationship, fName, mName, lName, birthDate, gender FROM FAMILYBACKGROUND WHERE MemberID = " + SLS.Static.ID + "";
                    reader = con.executeReader(sql);
                    while (reader.Read())
                    {
                        if (Convert.ToString(reader[0]) == "Father")
                        {
                            checkBox5.Checked = true;
                            txtFNFN.Text = Convert.ToString(reader[1]);
                            txtFNMN.Text = Convert.ToString(reader[2]);
                            txtFNLN.Text = Convert.ToString(reader[3]);
                            dtFN.Text = (Convert.ToDateTime(reader[4])).ToString("MM/dd/yyyy");
                        }
                        if (Convert.ToString(reader[0]) == "Mother")
                        {
                            checkBox1.Checked = true;
                            txtMNFN.Text = Convert.ToString(reader[1]);
                            txtMNMN.Text = Convert.ToString(reader[2]);
                            txtMNLN.Text = Convert.ToString(reader[3]);
                            dtMN.Text = (Convert.ToDateTime(reader[4])).ToString("MM/dd/yyyy");
                        }
                        if (Convert.ToString(reader[0]) == "Spouse")
                        {
                            checkBox3.Checked = true;
                            txtSNFN.Text = Convert.ToString(reader[1]);
                            txtSNMN.Text = Convert.ToString(reader[2]);
                            txtSNLN.Text = Convert.ToString(reader[3]);
                            dtSN.Text = (Convert.ToDateTime(reader[4])).ToString("MM/dd/yyyy");
                        }
                        if (Convert.ToString(reader[0]) == "Son" || Convert.ToString(reader[0]) == "Daughter")
                        {
                            checkBox4.Checked = true;
                            txtCNFN.Text = Convert.ToString(reader[1]);
                            txtCNMN.Text = Convert.ToString(reader[2]);
                            txtCNLN.Text = Convert.ToString(reader[3]);
                            dtChild.Text = (Convert.ToDateTime(reader[4])).ToString("MM/dd/yyyy");
                            cmbChildGender.SelectedIndex = Convert.ToInt32(reader[5]);
                            addChildren();
                            ClearChild();
                        }
                    }
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            defaultAll();
        }

        private void dtDateBirth_ValueChanged(object sender, EventArgs e)
        {
            age = DateTime.Now.Year - dtDateBirth.Value.Year - (DateTime.Now.DayOfYear < dtDateBirth.Value.DayOfYear ? 1 : 0);
            txtAge.Text = age.ToString();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "SELECT MemberTypeName FROM MEMBERTYPE WHERE DATEDIFF(YEAR, @birthDate , @DateNow )BETWEEN MinAgeRequired AND MaxAgeRequired";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@birthDate", Convert.ToDateTime(dtDateBirth.Value));
            parameters.Add("@DateNow", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            SqlDataReader reader = con.executeReader(sql,parameters);
            Int32 i=0;
            cmbMemberType.Items.Clear();
            while (reader.Read())
            {
                cmbMemberType.Items.Insert(i, "" + reader.GetString(0));
                i++;
            }
        }

        public void addChildren()
        {
            DataRow childRow = tableChild.NewRow();
            childRow["Last Name"] = txtCNLN.Text.Trim();
            childRow["First Name"] = txtCNFN.Text.Trim();
            childRow["Middle Name"] = txtCNMN.Text.Trim();
            childRow["Gender"] = cmbChildGender.SelectedItem.ToString();
            childRow["Birthdate"] = dtChild.Value.ToShortDateString();
            tableChild.Rows.Add(childRow);
            dataGridView1.DataSource = tableChild;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                try
                {
                    sChild = Convert.ToInt32(row.Index);
                    dtChild.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
                    txtCNLN.Text = row.Cells[0].Value.ToString();
                    txtCNFN.Text = row.Cells[1].Value.ToString();
                    txtCNMN.Text = row.Cells[2].Value.ToString();
                    cmbChildGender.SelectedItem = row.Cells[3].Value.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Selection!");
                }
            }
        }

        private void btnDeleteChild_Click(object sender, EventArgs e)
        {
            try
            {
                tableChild.Rows[sChild].Delete();
                txtCNFN.Clear();
                txtCNLN.Clear();
                txtCNMN.Clear();
                cmbChildGender.SelectedValue = " ";
                dtChild.Value = DateTime.Now;
                dataGridView1.DataSource = tableChild;
            }
            catch (Exception)
            {
            }
        }

        //Clear Child
        public void ClearChild()
        {
            txtCNFN.Clear();
            txtCNLN.Clear();
            txtCNMN.Clear();
            cmbChildGender.Items.Clear();
            for (int i = 0; i < childGenderString.Length; i++)
            {
                cmbChildGender.Items.Insert(i, "" + childGenderString[i]);
            }
            dtChild.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
        }

        private void btnClearChild_Click(object sender, EventArgs e)
        {
            ClearChild();
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            Int32 isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            isValid = ctrlString.checkString(txtCNFN.Text);
            isValid = ctrlString.checkString(txtCNLN.Text);
            if (ctrlString.checkString(txtCNFN.Text) == 1)
            {
                isValid = 1;
                label111.Visible = true;
            }
            if (ctrlString.checkString(txtCNLN.Text) == 1)
            {
                isValid = 1;
                label110.Visible = true;
            }
            try
            {
                Convert.ToInt32(cmbChildGender.SelectedIndex);
            }
            catch
            {
                isValid=1;
                label112.Visible = true;
            }
            if(isValid==0)
            {
                addChildren();
            }
            else
            {
                MessageBox.Show("Some required fields are missing/invalid!", "Error");
            }
            ClearChild();
        }

        //Validation of Form
        public Int32 checkValues()
        {
            //Required Fields Validation
            Int32 isValid = 0;
            SLS.Validate.Alpha ctrlString = new SLS.Validate.Alpha();
            if (ctrlString.checkString(txtFN.Text) == 1)
            {
                isValid = 1;
                er2.Visible = true;
            }
            if (ctrlString.checkString(txtLN.Text) == 1)
            {
                isValid = 1;
                er1.Visible = true;
            }
            if (ctrlString.checkString(txtCPLN.Text) == 1)
            {
                isValid = 1;
                label42.Visible = true;
            }
            if (ctrlString.checkString(txtCPFN.Text) == 1)
            {
                isValid = 1;
                label42.Visible = true;
            }
            if (txtCPMN.Text == "")
            {
                isValid = 0;
            }
            else
            {
                if (ctrlString.checkString(txtCPMN.Text) == 1)
                {
                    isValid = 1;
                    label42.Visible = true;
                }
                else
                {
                    isValid = 0;
                }
            }
            try
            {
                if(Convert.ToDecimal(txtInitialCapital.Text) < initCapital)
                {
                    isValid = 1;
                    er7.Visible = true;
                }
            }
            catch(Exception)
            {
                isValid = 1;
                er7.Visible = true;
            }
            try
            {
                Convert.ToDecimal(txtZip.Text);
            }
            catch (Exception)
            {
                isValid = 1;
                label24.Visible = true;
            }
            try
            {
                Convert.ToDecimal(txtFee.Text);
            }
            catch (Exception)
            {
                isValid = 1;
                er10.Visible = true;
            }
            try
            {
                Convert.ToInt32(txtMultiplier.Text);
            }
            catch (Exception)
            {
                isValid = 1;
                er8.Visible = true;
            }
            try
            {
                Convert.ToInt32(cobCI.SelectedIndex);
            }
            catch (Exception)
            {
                isValid = 1;
                er4.Visible = true;
            }
            try
            {
                Convert.ToInt32(txtContact.Text);
            }
            catch (Exception)
            {
                isValid = 1;
                label42.Visible = true;
            }

            try
            {
                Convert.ToInt32(cmbMemberType.SelectedIndex);
            }
            catch (Exception)
            {
                isValid = 1;
                er4.Visible = true;
            }
            try
            {
                Convert.ToInt32(cmbGender.SelectedIndex);
            }
            catch (Exception)
            {
                isValid = 1;
                er5.Visible = true;
            }
            
            //Not Required Fields Validation
            
            if(txtMN.Text=="")
            {
                isValid = 0;
            }
            else
            {
                if (ctrlString.checkString(txtMN.Text) == 1)
                {
                    isValid = 1;
                }
                else
                {
                    isValid = 0;
                }
            }
            if (txtMonthlySalary.Text != "")
            {
                try
                {
                    Convert.ToDecimal(txtMonthlySalary.Text);
                }
                catch (Exception)
                {
                    isValid = 1;
                }
            }
            if (txtStartingCapital.Text != "")
            {
                try
                {
                    Convert.ToDecimal(txtStartingCapital.Text);
                }
                catch (Exception)
                {
                    isValid = 1;
                }
            }
            if (txtPresentCapital.Text != "")
            {
                try
                {
                    Convert.ToDecimal(txtPresentCapital.Text);
                }
                catch (Exception)
                {
                    isValid = 1;
                }
            }
            if (txtMonthlyNetIncome.Text != "")
            {
                try
                {
                    Convert.ToDecimal(txtMonthlyNetIncome.Text);
                }
                catch (Exception)
                {
                    isValid = 1;
                }
            }


            //Family Validation
            if(checkBox5.Checked==true)
            {
                if (ctrlString.checkString(txtFNFN.Text) == 1)
                {
                    isValid = 1;
                    label102.Visible = true;
                }
                if (ctrlString.checkString(txtFNLN.Text) == 1)
                {
                    isValid = 1;
                    label101.Visible = true;
                }
            }
            if (checkBox1.Checked == true)
            {
                if (ctrlString.checkString(txtMNFN.Text) == 1)
                {
                    isValid = 1;
                    label105.Visible = true;
                }
                if (ctrlString.checkString(txtMNLN.Text) == 1)
                {
                    isValid = 1;
                    label104.Visible = true;
                }
            }
            if (checkBox3.Checked == true)
            {
                if (ctrlString.checkString(txtSNFN.Text) == 1)
                {
                    isValid = 1;
                    label108.Visible = true;
                }
                if (ctrlString.checkString(txtSNLN.Text) == 1)
                {
                    isValid = 1;
                    label107.Visible = true;
                }
            }
           
            if(rbFullTime.Checked==true)
            {
                occup = 0;
            }
            else
            if (rbPartTime.Checked==true)
            {
                occup = 1;
            }
            else
            if(rbContractual.Checked==true)
            {
                occup = 2;
            }
            else
            if (rbSelfEmployed.Checked==true)
            {
                occup=3;
            }
            else
            if(rbRetired.Checked==true)
            {
                occup = 4;
            }

            return isValid ;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID == 0)
            {
                if (checkValues() == 0)
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "INSERT INTO MEMBER (MemberTypeID, fName, mName, lName, gender, birthDate, civilStatus, gsisNo, educAttainment, paidMembershipFee, applyDate, seminarDate, initialCapital, multiplier, isActive) VALUES ((SELECT MemberTypeID FROM MEMBERTYPE WHERE MemberTypeName = @MemberTypeName), @fName, @mName, @lName, @gender, @birthDate, @civilStatus, @gsisNo, @educAttainment, @paidMembershipFee, @applyDate, @seminarDate, @isActive); SELECT SCOPE_IDENTIY()";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@MemberTypeName", cmbMemberType.SelectedItem.ToString());
                    parameters.Add("@fName", txtFN.Text);
                    parameters.Add("@mName", txtMN.Text);
                    parameters.Add("@lName", txtLN.Text);
                    parameters.Add("@gender", Convert.ToInt32(cmbGender.SelectedIndex));
                    parameters.Add("@birthDate", Convert.ToDateTime(dtDateBirth.Value));
                    parameters.Add("@civilStatus", Convert.ToInt32(cmbCivil.SelectedIndex));
                    parameters.Add("@gsisNo", txtGSISSSS.Text);
                    parameters.Add("@educAttainment", Convert.ToInt32(cmbEduc.SelectedIndex));
                    parameters.Add("@paidMembershipFee", Convert.ToDecimal(txtFee.Text));
                    parameters.Add("@applyDate", Convert.ToDateTime(dtMembership.Value));
                    parameters.Add("@seminarDate", Convert.ToDateTime(dtSeminar.Value));
                    parameters.Add("@isActive", true);
                    SqlDataReader reader = con.executeReader(sql, parameters);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        MemberID = reader.GetInt32(0);
                        MessageBox.Show("Adding a member is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        sql = "INSERT INTO CONTACTPERSON (contactFN, contactLN, contactMN, contactNo, MemberID) VALUES (@contactFN, @contactLN, @contactMN, @contactNo, @MemberID)";
                        parameters = new Dictionary<string, object>();
                        parameters.Add("@contactFN", txtCPFN.Text);
                        parameters.Add("@contactLN", txtCPLN.Text);
                        parameters.Add("@contactMN", txtCPMN.Text);
                        parameters.Add("@contactNo", txtContact.Text);
                        parameters.Add("@MemberID", MemberID);
                        int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));


                        sql = "INSERT INTO CONTACTINFORMATION (street, municipality, cityProvince, zipCode, residenceSince, telephoneNo, MemberID) VALUES (@street, @municipality, @cityProvince, @zipCode, @residenceSince, @telephoneNo, @MemberID)";
                        parameters = new Dictionary<string, object>();
                        parameters.Add("@street", txtStreet.Text);
                        parameters.Add("@municipality", txtMunicipality.Text);
                        parameters.Add("@cityProvince", txtCity.Text);
                        parameters.Add("@zipCode", txtZip.Text);
                        parameters.Add("@residenceSince", txtResidence.Text);
                        parameters.Add("@telephoneNo", txtTelNo.Text);
                        parameters.Add("@MemberID", MemberID);
                        result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        if (checkBox2.Checked == true)
                        {
                            sql = "INSERT INTO CONTACTINFORMATION (street, municipality, cityProvince, zipCode, residenceSince, telephoneNo, MemberID) VALUES (@street, @municipality, @cityProvince, @zipCode, @residenceSince, @telephoneNo, @MemberID)";
                            parameters = new Dictionary<string, object>();
                            parameters.Add("@street", txtStreet2.Text);
                            parameters.Add("@municipality", txtMunicipality2.Text);
                            parameters.Add("@cityProvince", txtCity2.Text);
                            parameters.Add("@zipCode", txtZip2.Text);
                            parameters.Add("@residenceSince", txtResidence2.Text);
                            parameters.Add("@telephoneNo", txtTelNo2.Text);
                            parameters.Add("@MemberID", MemberID);
                            result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        }

                        addToEmploymentInformation();
                        con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                        sql = "SELECT ISNULL(MAX(EmploymentInformationID),1) FROM EMPLOYMENTINFORMATION";
                        reader = con.executeReader(sql);
                        if (reader.HasRows)
                        {
                            reader.Read();
                            EmploymentInformationID = reader.GetInt32(0);
                        }
                        if (occup == 0 || occup == 1 || occup == 2)
                        {
                            addToEmployed();
                        }
                        else
                            if (occup == 3)
                            {
                                addToSelfEmployed();
                            }

                        if (checkBox5.Checked == true)
                        {
                            addFatherRelationship();
                        }
                        if (checkBox1.Checked == true)
                        {
                            addMotherRelationship();
                        }
                        if (checkBox3.Checked == true)
                        {
                            addSpouseRelationship();
                        }
                        if (tableChild.Rows.Count > 0)
                        {
                            for (int ind = 0; ind < tableChild.Rows.Count; ind++)
                            {
                                addChildrenRelationship(ind);
                            }
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Adding a member is not successful.", "Error", MessageBoxButtons.OK);
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
                String sql = "UPDATE MEMBER SET fName = @fName, mName = @mName, lName = @lName, gender = @gender, birthDate = @birthDate, civilStatus = @civilStatus, gsisNo = @gsisNo, educAttainment = @educAttainment, paidMembershipFee = @paidMembershipFee, applyDate = @applyDate, seminarDate = @seminarDate, initialCapital = @initialCapital, multiplier = @multiplier, MemberTypeID = (SELECT MemberTypeID FROM MEMBERTYPE WHERE MemberTypeName = @MemberTypeName) WHERE MemberID = " + SLS.Static.ID + " ";
                Dictionary<String, Object> parameters = new Dictionary<string, object>();
                parameters.Add("@fName", txtFN.Text);
                parameters.Add("@mName", txtMN.Text);
                parameters.Add("@lName", txtLN.Text);
                parameters.Add("@birthDate", Convert.ToDateTime(dtDateBirth.Value));
                parameters.Add("@gender", Convert.ToInt32(cmbGender.SelectedIndex));
                parameters.Add("@MemberTypeName", cmbMemberType.SelectedItem.ToString());
                parameters.Add("@civilStatus", Convert.ToInt32(cmbCivil.SelectedIndex));
                parameters.Add("@gsisNo", txtGSISSSS.Text);
                parameters.Add("@educAttainment", Convert.ToInt32(cmbEduc.SelectedIndex));
                parameters.Add("@paidMembershipFee", Convert.ToDecimal(txtFee.Text));
                parameters.Add("@applyDate", Convert.ToDateTime(dtMembership.Value));
                parameters.Add("@seminarDate", Convert.ToDateTime(dtSeminar.Value));
                parameters.Add("@initialCapital", Convert.ToDecimal(txtInitialCapital.Text));
                parameters.Add("@multiplier", Convert.ToInt32(txtMultiplier.Text));
                int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                if (result == 1)
                {
                    MessageBox.Show("Updating a member is successful.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Employment Information Delete
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "SELECT EmploymentInformationID FROM EMPLOYMENTINFORMATION WHERE MemberID = " + SLS.Static.ID + "";
                    SqlDataReader reader = con.executeReader(sql);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int employID = Convert.ToInt32(reader[0]);
                        //Employed Delete
                        sql = "DELETE FROM EMPLOYED WHERE EmploymentInformationID = employID";
                        parameters = new Dictionary<string, object>();
                        parameters.Add("employID", SLS.Static.ID);
                        result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                        //Self-Employed Delete
                        sql = "DELETE FROM SELFEMPLOYED WHERE EmploymentInformationID = employID";
                        parameters = new Dictionary<string, object>();
                        parameters.Add("employID", SLS.Static.ID);
                        result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    }
                    //Contact Person Delete
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "DELETE FROM CONTACTPERSON WHERE MemberID = @MemberID";
                    parameters = new Dictionary<string, object>();
                    parameters.Add("@MemberID", SLS.Static.ID);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    //Contact Information Delete
                    con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    sql = "DELETE FROM CONTACTINFORMATION WHERE MemberID = @MemberID";
                    parameters = new Dictionary<string, object>();
                    parameters.Add("@MemberID", SLS.Static.ID);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    sql = "DELETE FROM EMPLOYMENTINFORMATION WHERE MemberID = @MemberID";
                    parameters = new Dictionary<string, object>();
                    parameters.Add("@MemberID", SLS.Static.ID);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));

                    //Family BackGround Delete
                    sql = "DELETE FROM FAMILYBACKGROUND WHERE MemberID = @MemberID";
                    parameters = new Dictionary<string, object>();
                    parameters.Add("@MemberID", SLS.Static.ID);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    
                    
                    //UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE
                    
                    //Update Contact Person
                    sql = "INSERT INTO CONTACTPERSON (contactFN, contactLN, contactMN, contactNo, MemberID) VALUES (@contactFN, @contactLN, @contactMN, @contactNo, @MemberID) WHERE MemberID = @MemberID";
                    parameters = new Dictionary<string, object>();
                    parameters.Add("@contactFN", txtCPFN.Text);
                    parameters.Add("@contactLN", txtCPLN.Text);
                    parameters.Add("@contactMN", txtCPMN.Text);
                    parameters.Add("@contactNo", txtContact.Text);
                    parameters.Add("@MemberID", MemberID);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));

                    //Update Contact Information
                    sql = "INSERT INTO CONTACTINFORMATION (street, municipality, cityProvince, zipCode, residenceSince, telephoneNo, MemberID) VALUES (@street, @municipality, @cityProvince, @zipCode, @residenceSince, @telephoneNo, @MemberID) WHERE MemberID = @MemberID";
                    parameters = new Dictionary<string, object>();
                    parameters.Add("@street", txtStreet.Text);
                    parameters.Add("@municipality", txtMunicipality.Text);
                    parameters.Add("@cityProvince", txtCity.Text);
                    parameters.Add("@zipCode", txtZip.Text);
                    parameters.Add("@residenceSince", txtResidence.Text);
                    parameters.Add("@telephoneNo", txtTelNo.Text);
                    parameters.Add("@MemberID", MemberID);
                    result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (checkBox2.Checked == true)
                    {
                        sql = "INSERT INTO CONTACTINFORMATION (street, municipality, cityProvince, zipCode, residenceSince, telephoneNo, MemberID) VALUES (@street, @municipality, @cityProvince, @zipCode, @residenceSince, @telephoneNo, @MemberID) WHERE MemberID = @MemberID";
                        parameters = new Dictionary<string, object>();
                        parameters.Add("@street", txtStreet2.Text);
                        parameters.Add("@municipality", txtMunicipality2.Text);
                        parameters.Add("@cityProvince", txtCity2.Text);
                        parameters.Add("@zipCode", txtZip2.Text);
                        parameters.Add("@residenceSince", txtResidence2.Text);
                        parameters.Add("@telephoneNo", txtTelNo2.Text);
                        parameters.Add("@MemberID", MemberID);
                        result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    }

                    // Update Employment
                    addToEmploymentInformation();
                    sql = "SELECT ISNULL(MAX(EmploymentInformationID),1) FROM EMPLOYMENTINFORMATION";
                    reader = con.executeReader(sql);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        EmploymentInformationID = reader.GetInt32(0);
                    }
                    if (occup == 0 || occup == 1 || occup == 2)
                    {
                        addToEmployed();
                    }
                    else
                        if (occup == 3)
                        {
                            addToSelfEmployed();
                        }

                    if (checkBox5.Checked == true)
                    {
                        addFatherRelationship();
                    }
                    if (checkBox1.Checked == true)
                    {
                        addMotherRelationship();
                    }
                    if (checkBox3.Checked == true)
                    {
                        addSpouseRelationship();
                    }
                    if (tableChild.Rows.Count > 0)
                    {
                        for (int ind = 0; ind < tableChild.Rows.Count; ind++)
                        {
                            addChildrenRelationship(ind);
                        }
                    }


                    
                    
                    defaultAll();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Updating a member is not successful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Required Fields - Displays *****
        private void txtLN_Enter(object sender, EventArgs e)
        {
            er1.Visible = false;
        }

        private void txtFN_Enter(object sender, EventArgs e)
        {
            er2.Visible = false;
        }

        private void cmbMemberType_Enter(object sender, EventArgs e)
        {
            er4.Visible = false;
        }

        private void cmbGender_Enter(object sender, EventArgs e)
        {
            er5.Visible = false;
        }

        private void txtInitialCapital_Enter(object sender, EventArgs e)
        {
            er7.Visible = false;
        }

        private void txtMultiplier_Enter(object sender, EventArgs e)
        {
            er8.Visible = false;
        }

        private void txtCI_Enter(object sender, EventArgs e)
        {
            er9.Visible = false;
        }

        private void dtDateBirth_Enter(object sender, EventArgs e)
        {
            er3.Visible = false;
        }

        private void dtMembership_Enter(object sender, EventArgs e)
        {
            er6.Visible = false;
        }

        private void txtFNLN_Enter(object sender, EventArgs e)
        {
            label101.Visible = false;
        }

        private void txtFNFN_Enter(object sender, EventArgs e)
        {
            label102.Visible = false;
        }

        private void dtFN_Enter(object sender, EventArgs e)
        {
            label103.Visible = false;
        }

        private void txtMNLN_Enter(object sender, EventArgs e)
        {
            label104.Visible = false;
        }

        private void txtMNFN_Enter(object sender, EventArgs e)
        {
            label105.Visible = false;
        }

        private void dtMN_Enter(object sender, EventArgs e)
        {
            label106.Visible = false;
        }

        private void txtSNLN_Enter(object sender, EventArgs e)
        {
            label107.Visible = false;
        }

        private void txtSNFN_Enter(object sender, EventArgs e)
        {
            label108.Visible = false;
        }

        private void dtSN_Enter(object sender, EventArgs e)
        {
            label109.Visible = false;
        }

        private void txtCNLN_Enter(object sender, EventArgs e)
        {
            label110.Visible = false;
        }

        private void txtCNFN_Enter(object sender, EventArgs e)
        {
            label111.Visible = false;
        }

        private void cmbChildGender_Enter(object sender, EventArgs e)
        {
            label112.Visible = false;
        }

        private void dtChild_Enter(object sender, EventArgs e)
        {
            label113.Visible = false;
        }

        private void txtFee_Enter(object sender, EventArgs e)
        {
            er10.Visible = false;
        }

        private void dtSeminar_Enter(object sender, EventArgs e)
        {
            er11.Visible = false;
        }

        private void txtCPLN_Enter(object sender, EventArgs e)
        {
            label42.Visible = false;
        }

        private void txtStreet_Enter(object sender, EventArgs e)
        {
            label24.Visible = false;
        }

        private void txtMunicipality_Enter(object sender, EventArgs e)
        {
            label24.Visible = false;
        }

        private void txtCity_Enter(object sender, EventArgs e)
        {
            label24.Visible = false;
        }

        private void txtZip_Enter(object sender, EventArgs e)
        {
            label24.Visible = false;
        }

        private void txtResidence_Enter(object sender, EventArgs e)
        {
            label24.Visible = false;
        }

        private void txtTelNo_Enter(object sender, EventArgs e)
        {
            label24.Visible = false;
        }

       public void addToEmploymentInformation()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO EMPLOYMENTINFORMATION (employmentNo, MemberID) VALUES (@employmentNo, @MemberID)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@employmentNo", occup);
            parameters.Add("@MemberID", MemberID);
            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
           
            if (rbGovernment.Checked==true)
            {
                emptype = 1;
            }
            else
            if (rbPrivate.Checked==true)
            {
                emptype = 2;
            }
            else
            if (rbAbroad.Checked==true)
            {
                emptype = 3;
            }

        }
        
        public void addToEmployed()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO EMPLOYED (employerName, employerAddress, employerType, employerTelNo, dateStarted, monthlySalary, department, EmploymentInformationID) VALUES (@employerName, @employerAddress, @employerType, @employerTelNo, @dateStarted, @monthlySalary, @department, @EmploymentInformationID)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@employerName", txtEmployerName.Text);
            parameters.Add("@employerAddress", txtEmployerAddress.Text);
            parameters.Add("@employerType", emptype);
            parameters.Add("@employerTelNo", txtEmployerTelNo.Text);
            parameters.Add("@dateStarted", txtDateStarted.Text);
            parameters.Add("@monthlySalary", Convert.ToDecimal(txtMonthlySalary.Text));
            parameters.Add("@department", txtDepartment.Text);
            parameters.Add("@EmploymentInformationID", EmploymentInformationID);
            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
        }

        public void addToSelfEmployed()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO SELFEMPLOYED (typeOfBusiness, startingCapital, monthlyNetIncome, businessAddress, presentCapital, EmploymentInformationID) VALUES (@typeOfBusiness, @startingCapital, @monthlyNetIncome, @businessAddress, @presentCapital, @EmploymentInformationID)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@typeOfBusiness", txtTypeOfBusiness.Text);
            parameters.Add("@startingCapital", Convert.ToDecimal(txtStartingCapital.Text));
            parameters.Add("@monthlyNetIncome", Convert.ToDecimal(txtMonthlyNetIncome.Text));
            parameters.Add("@businessAddress", txtBusinessAdd.Text);
            parameters.Add("@presentCapital", Convert.ToDecimal(txtPresentCapital.Text));
            parameters.Add("@EmploymentInformationID", EmploymentInformationID);
            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
        }

        public void addFatherRelationship()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO FAMILYBACKGROUND (fName,mName, lName, birthDate, gender, relationship, MemberID) VALUES (@fName, @mName, @lName, @birthDate, @gender, @relationship, @MemberID)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@fName", txtFNFN.Text);
            parameters.Add("@mName", txtFNMN.Text);
            parameters.Add("@lName", txtFNLN.Text);
            parameters.Add("@birthDate", Convert.ToDateTime(dtFN.Value));
            parameters.Add("@gender", "1");
            parameters.Add("@relationship", "Father");
            parameters.Add("@MemberID", MemberID);
            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
        }

        public void addMotherRelationship()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO FAMILYBACKGROUND (fName,mName, lName, birthDate, gender, relationship, MemberID) VALUES (@fName, @mName, @lName, @birthDate, @gender, @relationship, @MemberID)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@fName", txtMNFN.Text);
            parameters.Add("@mName", txtMNMN.Text);
            parameters.Add("@lName", txtMNLN.Text);
            parameters.Add("@birthDate", Convert.ToDateTime(dtMN.Value));
            parameters.Add("@gender", "2");
            parameters.Add("@relationship", "Mother");
            parameters.Add("@MemberID", MemberID);
            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
        }

        public void addSpouseRelationship()
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO FAMILYBACKGROUND (fName,mName, lName, birthDate, gender, relationship, MemberID) VALUES (@fName, @mName, @lName, @birthDate, @gender, @relationship, @MemberID)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@fName", txtSNFN.Text);
            parameters.Add("@mName", txtSNMN.Text);
            parameters.Add("@lName", txtSNLN.Text);
            parameters.Add("@birthDate", Convert.ToDateTime(dtSN.Value));
            parameters.Add("@gender", "2");
            parameters.Add("@relationship", "Spouse");
            parameters.Add("@MemberID", MemberID);
            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
        }

        public void addChildrenRelationship(int ind)
        {
            string relship;
            bool childgend;
            if (tableChild.Rows[ind][3].ToString() == "1")
            {
                relship = "Son";
                childgend = true;
            }
            else
            {
                relship = "Daughter";
                childgend = false;
            }
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
            String sql = "INSERT INTO FAMILYBACKGROUND (fName,mName, lName, birthDate, gender, relationship, MemberID) VALUES (@fName, @mName, @lName, @birthDate, @gender, @relationship, @MemberID)";
            Dictionary<String, Object> parameters = new Dictionary<string, object>();
            parameters.Add("@fName", tableChild.Rows[ind][1].ToString());
            parameters.Add("@mName", tableChild.Rows[ind][2].ToString());
            parameters.Add("@lName", tableChild.Rows[ind][0].ToString());
            parameters.Add("@birthDate", tableChild.Rows[ind][4].ToString());
            parameters.Add("@gender", childgend);
            parameters.Add("@relationship", relship.ToString());
            parameters.Add("@MemberID", MemberID);
            int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
        }

        private void cmbMemberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
             String sql = "SELECT Fee, ShareRequired FROM MEMBERTYPE WHERE MemberTypeName = @MemberTypeName";
            Dictionary<String, Object> parameters = new Dictionary<string,object>();
            parameters.Add("@MemberTypeName",cmbMemberType.SelectedItem.ToString());
            SqlDataReader reader = con.executeReader(sql, parameters);
            if (reader.HasRows)
            {
                reader.Read();
                txtFee.Text = String.Format("{0:0.00}",reader[0]);
                txtFee.Enabled = false;
                if(Convert.ToDecimal(reader[1]) == 0)
                {
                    txtInitialCapital.Clear();
                    txtInitialCapital.Enabled = false;
                    txtMultiplier.Enabled = false;
                    label17.Enabled = false;
                    label74.Enabled = false;
                }
                else
                {
                    txtInitialCapital.Text = Convert.ToString(reader[1]);
                    initCapital = Convert.ToDecimal(reader[1]);
                    txtInitialCapital.Enabled = true;
                    txtMultiplier.Enabled =true;
                    label17.Enabled = true;
                    label74.Enabled = true;
                }
            }
        }
    }
}
