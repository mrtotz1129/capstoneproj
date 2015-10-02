namespace SLS.MainMenuForm
{
    partial class Savings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Savings));
            this.savingsMenuStrip = new System.Windows.Forms.MenuStrip();
            this.maintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.savingsType = new System.Windows.Forms.ToolStripMenuItem();
            this.dormancy = new System.Windows.Forms.ToolStripMenuItem();
            this.transaction = new System.Windows.Forms.ToolStripMenuItem();
            this.reports = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.savingsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // savingsMenuStrip
            // 
            this.savingsMenuStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("savingsMenuStrip.BackgroundImage")));
            this.savingsMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.savingsMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintenance,
            this.transaction,
            this.reports});
            this.savingsMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.savingsMenuStrip.Name = "savingsMenuStrip";
            this.savingsMenuStrip.Size = new System.Drawing.Size(1360, 28);
            this.savingsMenuStrip.TabIndex = 0;
            this.savingsMenuStrip.Text = "savingsMenuStrip";
            // 
            // maintenance
            // 
            this.maintenance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("maintenance.BackgroundImage")));
            this.maintenance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.maintenance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savingsType,
            this.dormancy});
            this.maintenance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintenance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.maintenance.Name = "maintenance";
            this.maintenance.Size = new System.Drawing.Size(110, 24);
            this.maintenance.Text = "Maintenance";
            // 
            // savingsType
            // 
            this.savingsType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.savingsType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.savingsType.ForeColor = System.Drawing.Color.MidnightBlue;
            this.savingsType.Name = "savingsType";
            this.savingsType.Size = new System.Drawing.Size(167, 24);
            this.savingsType.Text = "Savings Type";
            this.savingsType.Click += new System.EventHandler(this.savingsType_Click);
            // 
            // dormancy
            // 
            this.dormancy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dormancy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dormancy.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dormancy.Name = "dormancy";
            this.dormancy.Size = new System.Drawing.Size(167, 24);
            this.dormancy.Text = "Dormancy";
            this.dormancy.Click += new System.EventHandler(this.dormancy_Click);
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
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(0, 31);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1360, 551);
            this.pnlMain.TabIndex = 1;
            // 
            // Savings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1360, 581);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.savingsMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.savingsMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Savings";
            this.Text = "MemberForm";
            this.savingsMenuStrip.ResumeLayout(false);
            this.savingsMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip savingsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem maintenance;
        private System.Windows.Forms.ToolStripMenuItem transaction;
        private System.Windows.Forms.ToolStripMenuItem reports;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem savingsType;
        private System.Windows.Forms.ToolStripMenuItem dormancy;
    }
}