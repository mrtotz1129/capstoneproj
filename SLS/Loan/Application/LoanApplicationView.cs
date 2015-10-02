using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SLS.Loan.Application
{
    public partial class LoanApplicationView : Form
    {
        public LoanApplicationView()
        {
            InitializeComponent();
            this.lOANTableAdapter.FillBy(this.sLSDBDataSet1.LOAN);
        }

        private void LoanApplicationView_Load(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }



        private void btnLoan_Click(object sender, EventArgs e)
        {
            
        }


    }
}
