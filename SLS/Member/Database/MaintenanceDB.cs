﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.Member.Database
{
    public partial class MaintenanceDB : Form
    {
        public MaintenanceDB()
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
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = SLS.Static.sql;
                DataSet ds = con.executeDataSet(sql, "Member Type");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Member Type";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                String sql = SLS.Static.sqlParams;
                DataSet ds = con.executeDataSet(sql, SLS.Static.parameters,"Member Type");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Member Type";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SLS.Static.ID = 0;
            var child = new SLS.Member.Application.MemberType();
            child.FormClosed += closedMemberType;
            child.ShowDialog();
        }
        public void closedMemberType(object sender, FormClosedEventArgs e)
        {
            SLS.Static.ID = 0;
            loadDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                var child = new SLS.Member.Application.MemberType();
                child.FormClosed += closedMemberType;
                child.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select data from the database.", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SLS.Static.ID != 0)
            {
                if (btnDelete.Text == "DELETE")
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE MEMBERTYPE SET [status] = @status WHERE MemberTypeID = @MemberTypeID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", false);
                    parameters.Add("@MemberTypeID", SLS.Static.ID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("A Member Type is Updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDatabase();
                        btnDelete.Text = "DELETE";
                    }
                    else
                    {
                        MessageBox.Show("A Member Type is Not Updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SQLStatement con = new SQLStatement(SLS.Static.Server, SLS.Static.Database);
                    String sql = "UPDATE MEMBERTYPE SET [status] = @status WHERE MemberTypeID = @MemberTypeID";
                    Dictionary<String, Object> parameters = new Dictionary<string, object>();
                    parameters.Add("@status", true);
                    parameters.Add("@MemberTypeID", SLS.Static.ID);
                    int result = Convert.ToInt32(con.executeNonQuery(sql, parameters));
                    if (result == 1)
                    {
                        MessageBox.Show("A Member Type is Updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDatabase();
                        btnDelete.Text = "DELETE";
                    }
                    else
                    {
                        MessageBox.Show("A Member Type is Not Updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose a record to be updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SLS.Static.ID = Convert.ToInt32(row.Cells[0].Value.ToString());
                if (Convert.ToBoolean(row.Cells[7].Value) == true)
                {
                    btnDelete.Text = "DELETE";
                }
                else
                {
                    btnDelete.Text = "ACTIVATE";
                }
            }
        }
    }
}
