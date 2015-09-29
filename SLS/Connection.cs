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
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }
        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtServer.Text != "" && txtDatabase.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection("Integrated Security = true; Data Source = " + txtServer.Text + "; Initial Catalog = " + txtDatabase.Text + "");
                    con.Open();
                    this.Hide();
                    SLS.Static.Server = txtServer.Text;
                    SLS.Static.Database = txtDatabase.Text;
                    var Login = new Login();
                    Login.Closed += (s, args) => this.Close();
                    Login.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Server Instance and/or Database Name is invalid.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Server Instance and/or Database Name is invalid.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
