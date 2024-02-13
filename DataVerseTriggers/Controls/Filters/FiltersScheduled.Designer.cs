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
            this.chkRecurrency = new System.Windows.Forms.CheckedListBox();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.lblWeekDays = new System.Windows.Forms.Label();
            this.chkWeekDays = new System.Windows.Forms.CheckedListBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lnkClearFilters = new System.Windows.Forms.LinkLabel();
            this.pnlFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.chkRecurrency);
            this.pnlFilters.Controls.Add(this.lblFrequency);
            this.pnlFilters.Controls.Add(this.lblWeekDays);
            this.pnlFilters.Controls.Add(this.chkWeekDays);
            this.pnlFilters.Controls.Add(this.btnApplyFilter);
            this.pnlFilters.Controls.Add(this.lnkClearFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.TabIndex = 12;
            // 
            // chkRecurrency
            // 
            this.chkRecurrency.FormattingEnabled = true;
            this.chkRecurrency.Location = new System.Drawing.Point(17, 64);
            this.chkRecurrency.Name = "chkRecurrency";
            this.chkRecurrency.Size = new System.Drawing.Size(380, 142);
            this.chkRecurrency.TabIndex = 14;
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(13, 31);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(84, 20);
            this.lblFrequency.TabIndex = 5;
            this.lblFrequency.Text = "Frequency";
            // 
            // lblWeekDays
            // 
            this.lblWeekDays.AutoSize = true;
            this.lblWeekDays.Location = new System.Drawing.Point(13, 226);
            this.lblWeekDays.Name = "lblWeekDays";
            this.lblWeekDays.Size = new System.Drawing.Size(74, 20);
            this.lblWeekDays.TabIndex = 3;
            this.lblWeekDays.Text = "Message";
            // 
            // chkWeekDays
            // 
            this.chkWeekDays.FormattingEnabled = true;
            this.chkWeekDays.Location = new System.Drawing.Point(17, 259);
            this.chkWeekDays.MultiColumn = true;
            this.chkWeekDays.Name = "chkWeekDays";
            this.chkWeekDays.Size = new System.Drawing.Size(380, 211);
            this.chkWeekDays.TabIndex = 9;
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
            // FiltersScheduled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFilters);
            this.Name = "FiltersScheduled";
            this.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Label lblWeekDays;
        private System.Windows.Forms.CheckedListBox chkWeekDays;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.CheckedListBox chkRecurrency;
        private System.Windows.Forms.LinkLabel lnkClearFilters;
    }
}
