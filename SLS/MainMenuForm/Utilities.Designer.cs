namespace SLS.MainMenuForm
{
    partial class Utilities
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
            this.loanMenuStrip = new System.Windows.Forms.MenuStrip();
            this.companyDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.administration = new System.Windows.Forms.ToolStripMenuItem();
            this.userAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.creditInvestigators = new System.Windows.Forms.ToolStripMenuItem();
            this.loanGrantors = new System.Windows.Forms.ToolStripMenuItem();
            this.auditTrail = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.loanMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // loanMenuStrip
            // 
            this.loanMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loanMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyDetails,
            this.administration,
            this.auditTrail});
            this.loanMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.loanMenuStrip.Name = "loanMenuStrip";
            this.loanMenuStrip.Size = new System.Drawing.Size(1276, 28);
            this.loanMenuStrip.TabIndex = 0;
            this.loanMenuStrip.Text = "menuStrip1";
            // 
            // companyDetails
            // 
            this.companyDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.companyDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyDetails.ForeColor = System.Drawing.Color.MidnightBlue;
            this.companyDetails.Name = "companyDetails";
            this.companyDetails.Size = new System.Drawing.Size(136, 24);
            this.companyDetails.Text = "Company Details";
            // 
            // administration
            // 
            this.administration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.administration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userAccount,
            this.creditInvestigators,
            this.loanGrantors});
            this.administration.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.administration.ForeColor = System.Drawing.Color.MidnightBlue;
            this.administration.Name = "administration";
            this.administration.Size = new System.Drawing.Size(122, 24);
            this.administration.Text = "Administration";
            // 
            // userAccount
            // 
            this.userAccount.Name = "userAccount";
            this.userAccount.Size = new System.Drawing.Size(210, 24);
            this.userAccount.Text = "User Account";
            this.userAccount.Click += new System.EventHandler(this.userAccount_Click);
            // 
            // creditInvestigators
            // 
            this.creditInvestigators.Name = "creditInvestigators";
            this.creditInvestigators.Size = new System.Drawing.Size(210, 24);
            this.creditInvestigators.Text = "Credit Investigators";
            this.creditInvestigators.Click += new System.EventHandler(this.creditInvestigators_Click);
            // 
            // loanGrantors
            // 
            this.loanGrantors.Name = "loanGrantors";
            this.loanGrantors.Size = new System.Drawing.Size(210, 24);
            this.loanGrantors.Text = "Loan Grantors";
            this.loanGrantors.Click += new System.EventHandler(this.loanGrantors_Click);
            // 
            // auditTrail
            // 
            this.auditTrail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.auditTrail.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auditTrail.ForeColor = System.Drawing.Color.MidnightBlue;
            this.auditTrail.Name = "auditTrail";
            this.auditTrail.Size = new System.Drawing.Size(91, 24);
            this.auditTrail.Text = "Audit Trail";
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1360, 551);
            this.pnlMain.TabIndex = 1;
            // 
            // Utilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1276, 581);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.loanMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.loanMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Utilities";
            this.Text = "loanMenuStrip";
            this.loanMenuStrip.ResumeLayout(false);
            this.loanMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip loanMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem companyDetails;
        private System.Windows.Forms.ToolStripMenuItem administration;
        private System.Windows.Forms.ToolStripMenuItem auditTrail;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem userAccount;
        private System.Windows.Forms.ToolStripMenuItem creditInvestigators;
        private System.Windows.Forms.ToolStripMenuItem loanGrantors;
    }
}