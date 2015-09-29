namespace SLS.MainMenuForm
{
    partial class Time
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Time));
            this.timeMenuStrip = new System.Windows.Forms.MenuStrip();
            this.maintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.timeDepositRates = new System.Windows.Forms.ToolStripMenuItem();
            this.timeDepositPenalty = new System.Windows.Forms.ToolStripMenuItem();
            this.transaction = new System.Windows.Forms.ToolStripMenuItem();
            this.reports = new System.Windows.Forms.ToolStripMenuItem();
            this.membershipInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.membershipPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.approveReject = new System.Windows.Forms.ToolStripMenuItem();
            this.creditInvestigation = new System.Windows.Forms.ToolStripMenuItem();
            this.membershipApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.timeMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeMenuStrip
            // 
            this.timeMenuStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("timeMenuStrip.BackgroundImage")));
            this.timeMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.timeMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintenance,
            this.transaction,
            this.reports});
            this.timeMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.timeMenuStrip.Name = "timeMenuStrip";
            this.timeMenuStrip.Size = new System.Drawing.Size(1360, 28);
            this.timeMenuStrip.TabIndex = 0;
            this.timeMenuStrip.Text = "timeMenuStrip";
            // 
            // maintenance
            // 
            this.maintenance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("maintenance.BackgroundImage")));
            this.maintenance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.maintenance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeDepositRates,
            this.timeDepositPenalty});
            this.maintenance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintenance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.maintenance.Name = "maintenance";
            this.maintenance.Size = new System.Drawing.Size(110, 24);
            this.maintenance.Text = "Maintenance";
            // 
            // timeDepositRates
            // 
            this.timeDepositRates.BackColor = System.Drawing.Color.WhiteSmoke;
            this.timeDepositRates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.timeDepositRates.ForeColor = System.Drawing.Color.MidnightBlue;
            this.timeDepositRates.Name = "timeDepositRates";
            this.timeDepositRates.Size = new System.Drawing.Size(222, 24);
            this.timeDepositRates.Text = "Time Deposit Rates";
            this.timeDepositRates.Click += new System.EventHandler(this.timeDepositRates_Click);
            // 
            // timeDepositPenalty
            // 
            this.timeDepositPenalty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.timeDepositPenalty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.timeDepositPenalty.ForeColor = System.Drawing.Color.MidnightBlue;
            this.timeDepositPenalty.Name = "timeDepositPenalty";
            this.timeDepositPenalty.Size = new System.Drawing.Size(222, 24);
            this.timeDepositPenalty.Text = "Time Deposit Penalty";
            this.timeDepositPenalty.Click += new System.EventHandler(this.timeDepositPenalty_Click);
            // 
            // transaction
            // 
            this.transaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("transaction.BackgroundImage")));
            this.transaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.transaction.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transaction.ForeColor = System.Drawing.Color.MidnightBlue;
            this.transaction.Name = "transaction";
            this.transaction.Size = new System.Drawing.Size(100, 24);
            this.transaction.Text = "Transaction";
            this.transaction.Click += new System.EventHandler(this.transaction_Click);
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
            // membershipInformation
            // 
            this.membershipInformation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.membershipInformation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("membershipInformation.BackgroundImage")));
            this.membershipInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.membershipInformation.ForeColor = System.Drawing.Color.MidnightBlue;
            this.membershipInformation.Name = "membershipInformation";
            this.membershipInformation.Size = new System.Drawing.Size(264, 26);
            this.membershipInformation.Text = "Membership Information";
            // 
            // membershipPayment
            // 
            this.membershipPayment.BackColor = System.Drawing.Color.WhiteSmoke;
            this.membershipPayment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("membershipPayment.BackgroundImage")));
            this.membershipPayment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.membershipPayment.ForeColor = System.Drawing.Color.MidnightBlue;
            this.membershipPayment.Name = "membershipPayment";
            this.membershipPayment.Size = new System.Drawing.Size(264, 26);
            this.membershipPayment.Text = "Membership Payment";
            // 
            // approveReject
            // 
            this.approveReject.BackColor = System.Drawing.Color.WhiteSmoke;
            this.approveReject.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("approveReject.BackgroundImage")));
            this.approveReject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.approveReject.ForeColor = System.Drawing.Color.MidnightBlue;
            this.approveReject.Name = "approveReject";
            this.approveReject.Size = new System.Drawing.Size(264, 26);
            this.approveReject.Text = "Approve / Reject";
            // 
            // creditInvestigation
            // 
            this.creditInvestigation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.creditInvestigation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("creditInvestigation.BackgroundImage")));
            this.creditInvestigation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.creditInvestigation.ForeColor = System.Drawing.Color.MidnightBlue;
            this.creditInvestigation.Name = "creditInvestigation";
            this.creditInvestigation.Size = new System.Drawing.Size(264, 26);
            this.creditInvestigation.Text = "Credit Investigation";
            // 
            // membershipApplication
            // 
            this.membershipApplication.BackColor = System.Drawing.Color.WhiteSmoke;
            this.membershipApplication.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("membershipApplication.BackgroundImage")));
            this.membershipApplication.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.membershipApplication.ForeColor = System.Drawing.Color.MidnightBlue;
            this.membershipApplication.Name = "membershipApplication";
            this.membershipApplication.Size = new System.Drawing.Size(264, 26);
            this.membershipApplication.Text = "Application";
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1360, 551);
            this.pnlMain.TabIndex = 1;
            // 
            // Time
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1360, 581);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.timeMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.timeMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Time";
            this.Text = "MemberForm";
            this.timeMenuStrip.ResumeLayout(false);
            this.timeMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip timeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem maintenance;
        private System.Windows.Forms.ToolStripMenuItem transaction;
        private System.Windows.Forms.ToolStripMenuItem reports;
        private System.Windows.Forms.ToolStripMenuItem membershipInformation;
        private System.Windows.Forms.ToolStripMenuItem membershipPayment;
        private System.Windows.Forms.ToolStripMenuItem approveReject;
        private System.Windows.Forms.ToolStripMenuItem creditInvestigation;
        private System.Windows.Forms.ToolStripMenuItem membershipApplication;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem timeDepositRates;
        private System.Windows.Forms.ToolStripMenuItem timeDepositPenalty;
    }
}