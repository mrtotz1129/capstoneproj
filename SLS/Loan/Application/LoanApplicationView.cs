using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLS.Loan.Application
{
    public partial class LoanApplicationView : Form
    {
        public LoanApplicationView()
        {
            InitializeComponent();
        }

        private void LoanApplicationView_Load(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.lOANTableAdapter.FillBy(this.sLSDBDataSet1.LOAN);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            this.lOANTableAdapter.FillBy(this.sLSDBDataSet1.LOAN);
        }
    }
}
