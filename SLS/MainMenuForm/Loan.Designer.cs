namespace SLS.MainMenuForm
{
    partial class Loan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loan));
            this.loanMenuStrip = new System.Windows.Forms.MenuStrip();
            this.maintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.chargesModeTerm = new System.Windows.Forms.ToolStripMenuItem();
            this.loanType = new System.Windows.Forms.ToolStripMenuItem();
            this.transaction = new System.Windows.Forms.ToolStripMenuItem();
            this.loanApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.approveReject = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseAmortization = new System.Windows.Forms.ToolStripMenuItem();
            this.loanPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.loanRestructure = new System.Windows.Forms.ToolStripMenuItem();
            this.reports = new System.Windows.Forms.ToolStripMenuItem();
            this.queries = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.loanMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // loanMenuStrip
            // 
            this.loanMenuStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loanMenuStrip.BackgroundImage")));
            this.loanMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loanMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintenance,
            this.transaction,
            this.reports,
            this.queries});
            this.loanMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.loanMenuStrip.Name = "loanMenuStrip";
            this.loanMenuStrip.Size = new System.Drawing.Size(1360, 28);
            this.loanMenuStrip.TabIndex = 0;
            this.loanMenuStrip.Text = "menuStrip1";
            // 
            // maintenance
            // 
            this.maintenance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("maintenance.BackgroundImage")));
            this.maintenance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.maintenance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargesModeTerm,
            this.loanType});
            this.maintenance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintenance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.maintenance.Name = "maintenance";
            this.maintenance.Size = new System.Drawing.Size(110, 24);
            this.maintenance.Text = "Maintenance";
            // 
            // chargesModeTerm
            // 
            this.chargesModeTerm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chargesModeTerm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chargesModeTerm.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chargesModeTerm.Name = "chargesModeTerm";
            this.chargesModeTerm.Size = new System.Drawing.Size(250, 24);
            this.chargesModeTerm.Text = "Charges, Mode and Term";
            this.chargesModeTerm.Click += new System.EventHandler(this.modeTermPayment_Click);
            // 
            // loanType
            // 
            this.loanType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loanType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loanType.ForeColor = System.Drawing.Color.MidnightBlue;
            this.loanType.Name = "loanType";
            this.loanType.Size = new System.Drawing.Size(250, 24);
            this.loanType.Text = "Loan Type";
            this.loanType.Click += new System.EventHandler(this.loanType_Click);
            // 
            // transaction
            // 
            this.transaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("transaction.BackgroundImage")));
            this.transaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.transaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loanApplication,
            this.approveReject,
            this.releaseAmortization,
            this.loanPayment,
            this.loanRestructure});
            this.transaction.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transaction.ForeColor = System.Drawing.Color.MidnightBlue;
            this.transaction.Name = "transaction";
            this.transaction.Size = new System.Drawing.Size(100, 24);
            this.transaction.Text = "Transaction";
            // 
            // loanApplication
            // 
            this.loanApplication.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loanApplication.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loanApplication.ForeColor = System.Drawing.Color.MidnightBlue;
            this.loanApplication.Name = "loanApplication";
            this.loanApplication.Size = new System.Drawing.Size(232, 24);
            this.loanApplication.Text = "Loan Application";
            this.loanApplication.Click += new System.EventHandler(this.loanApplication_Click);
            // 
            // approveReject
            // 
            this.approveReject.BackColor = System.Drawing.Color.WhiteSmoke;
            this.approveReject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.approveReject.ForeColor = System.Drawing.Color.MidnightBlue;
            this.approveReject.Name = "approveReject";
            this.approveReject.Size = new System.Drawing.Size(232, 24);
            this.approveReject.Text = "Approve / Reject";
            this.approveReject.Click += new System.EventHandler(this.approveReject_Click);
            // 
            // releaseAmortization
            // 
            this.releaseAmortization.BackColor = System.Drawing.Color.WhiteSmoke;
            this.releaseAmortization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.releaseAmortization.ForeColor = System.Drawing.Color.MidnightBlue;
            this.releaseAmortization.Name = "releaseAmortization";
            this.releaseAmortization.Size = new System.Drawing.Size(232, 24);
            this.releaseAmortization.Text = "Release / Amortization";
            this.releaseAmortization.Click += new System.EventHandler(this.releaseAmortization_Click);
            // 
            // loanPayment
            // 
            this.loanPayment.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loanPayment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loanPayment.ForeColor = System.Drawing.Color.MidnightBlue;
            this.loanPayment.Name = "loanPayment";
            this.loanPayment.Size = new System.Drawing.Size(232, 24);
            this.loanPayment.Text = "Loan Payment";
            this.loanPayment.Click += new System.EventHandler(this.loanPayment_Click);
            // 
            // loanRestructure
            // 
            this.loanRestructure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loanRestructure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loanRestructure.ForeColor = System.Drawing.Color.MidnightBlue;
            this.loanRestructure.Name = "loanRestructure";
            this.loanRestructure.Size = new System.Drawing.Size(232, 24);
            this.loanRestructure.Text = "Loan Restructure";
            this.loanRestructure.Click += new System.EventHandler(this.loanRestructure_Click);
            // 
            // reports
            // 
            this.reports.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reports.BackgroundImage")));
            this.reports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.reports.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reports.ForeColor = System.Drawing.Color.MidnightBlue;
            this.reports.Name = "reports";
            this.reports.Size = new System.Drawing.Size(73, 24);
            this.reports.Text = "Reports";
            // 
            // queries
            // 
            this.queries.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("queries.BackgroundImage")));
            this.queries.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.queries.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queries.ForeColor = System.Drawing.Color.MidnightBlue;
            this.queries.Name = "queries";
            this.queries.Size = new System.Drawing.Size(73, 24);
            this.queries.Text = "Queries";
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1360, 551);
            this.pnlMain.TabIndex = 1;
            // 
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1360, 581);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.loanMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.loanMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Loan";
            this.Text = "loanMenuStrip";
            this.loanMenuStrip.ResumeLayout(false);
            this.loanMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip loanMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem maintenance;
        private System.Windows.Forms.ToolStripMenuItem transaction;
        private System.Windows.Forms.ToolStripMenuItem reports;
        private System.Windows.Forms.ToolStripMenuItem queries;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem chargesModeTerm;
        private System.Windows.Forms.ToolStripMenuItem loanType;
        private System.Windows.Forms.ToolStripMenuItem loanApplication;
        private System.Windows.Forms.ToolStripMenuItem approveReject;
        private System.Windows.Forms.ToolStripMenuItem releaseAmortization;
        private System.Windows.Forms.ToolStripMenuItem loanPayment;
        private System.Windows.Forms.ToolStripMenuItem loanRestructure;
    }
}