namespace DataVerseTrigger.Controls.Filters
{
    partial class FiltersScheduled
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWeekDays = new System.Windows.Forms.Label();
            this.chkWeekDays = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkRecurrency = new System.Windows.Forms.CheckedListBox();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lnkClearFilters = new System.Windows.Forms.LinkLabel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.chkStatus = new System.Windows.Forms.CheckedListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlFilters.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.pnlStatus);
            this.pnlFilters.Controls.Add(this.panel2);
            this.pnlFilters.Controls.Add(this.panel1);
            this.pnlFilters.Controls.Add(this.panel6);
            this.pnlFilters.Controls.Add(this.btnApplyFilter);
            this.pnlFilters.Controls.Add(this.lnkClearFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkWeekDays);
            this.panel2.Controls.Add(this.lblWeekDays);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 268);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 248);
            this.panel2.TabIndex = 29;
            // 
            // lblWeekDays
            // 
            this.lblWeekDays.AutoSize = true;
            this.lblWeekDays.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWeekDays.Location = new System.Drawing.Point(0, 0);
            this.lblWeekDays.Name = "lblWeekDays";
            this.lblWeekDays.Size = new System.Drawing.Size(74, 20);
            this.lblWeekDays.TabIndex = 10;
            this.lblWeekDays.Text = "Message";
            // 
            // chkWeekDays
            // 
            this.chkWeekDays.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkWeekDays.FormattingEnabled = true;
            this.chkWeekDays.Location = new System.Drawing.Point(0, 20);
            this.chkWeekDays.MultiColumn = true;
            this.chkWeekDays.Name = "chkWeekDays";
            this.chkWeekDays.Size = new System.Drawing.Size(450, 211);
            this.chkWeekDays.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkRecurrency);
            this.panel1.Controls.Add(this.lblFrequency);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 183);
            this.panel1.TabIndex = 28;
            // 
            // chkRecurrency
            // 
            this.chkRecurrency.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkRecurrency.FormattingEnabled = true;
            this.chkRecurrency.Location = new System.Drawing.Point(0, 20);
            this.chkRecurrency.Name = "chkRecurrency";
            this.chkRecurrency.Size = new System.Drawing.Size(450, 142);
            this.chkRecurrency.TabIndex = 16;
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFrequency.Location = new System.Drawing.Point(0, 0);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(84, 20);
            this.lblFrequency.TabIndex = 15;
            this.lblFrequency.Text = "Frequency";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtName);
            this.panel6.Controls.Add(this.lblName);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(450, 65);
            this.panel6.TabIndex = 27;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtName.Location = new System.Drawing.Point(0, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(450, 26);
            this.txtName.TabIndex = 4;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnApplyFilter.Location = new System.Drawing.Point(0, 891);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(450, 39);
            this.btnApplyFilter.TabIndex = 4;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // lnkClearFilters
            // 
            this.lnkClearFilters.AutoSize = true;
            this.lnkClearFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkClearFilters.Location = new System.Drawing.Point(0, 0);
            this.lnkClearFilters.Name = "lnkClearFilters";
            this.lnkClearFilters.Size = new System.Drawing.Size(115, 20);
            this.lnkClearFilters.TabIndex = 26;
            this.lnkClearFilters.TabStop = true;
            this.lnkClearFilters.Text = "Remove Filters";
            this.lnkClearFilters.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearFilters_LinkClicked);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.chkStatus);
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 516);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(450, 100);
            this.pnlStatus.TabIndex = 31;
            // 
            // chkStatus
            // 
            this.chkStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkStatus.FormattingEnabled = true;
            this.chkStatus.Location = new System.Drawing.Point(0, 20);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(450, 73);
            this.chkStatus.TabIndex = 20;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 20);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status";
            // 
            // FiltersScheduled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFilters);
            this.Name = "FiltersScheduled";
            this.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.LinkLabel lnkClearFilters;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWeekDays;
        private System.Windows.Forms.CheckedListBox chkWeekDays;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox chkRecurrency;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.CheckedListBox chkStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}
