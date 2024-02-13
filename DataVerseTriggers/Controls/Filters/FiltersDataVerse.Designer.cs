using DataVerseTrigger.Controls.Forms;

namespace DataVerseTrigger.Controls.Filters
{
    partial class FiltersDataVerse
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.attributesSelector1 = new AttributesSelector();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.chkMessages = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblScope = new System.Windows.Forms.Label();
            this.chkScope = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkRunAs = new System.Windows.Forms.CheckedListBox();
            this.lblRunAs = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFilterExpression = new System.Windows.Forms.Label();
            this.txtFilterExpression = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFilterAttributes = new System.Windows.Forms.Label();
            this.txtFilterAttributes = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lnkClearFilters = new System.Windows.Forms.LinkLabel();
            this.pnlFilters.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.panel6);
            this.pnlFilters.Controls.Add(this.panel5);
            this.pnlFilters.Controls.Add(this.panel4);
            this.pnlFilters.Controls.Add(this.panel3);
            this.pnlFilters.Controls.Add(this.panel2);
            this.pnlFilters.Controls.Add(this.panel1);
            this.pnlFilters.Controls.Add(this.btnApplyFilter);
            this.pnlFilters.Controls.Add(this.lnkClearFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.TabIndex = 12;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.attributesSelector1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(450, 198);
            this.panel6.TabIndex = 24;
            // 
            // attributesSelector1
            // 
            this.attributesSelector1.AutoSize = true;
            this.attributesSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributesSelector1.Location = new System.Drawing.Point(0, 0);
            this.attributesSelector1.Name = "attributesSelector1";
            this.attributesSelector1.Service = null;
            this.attributesSelector1.Size = new System.Drawing.Size(450, 198);
            this.attributesSelector1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblMessage);
            this.panel5.Controls.Add(this.chkMessages);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 218);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(450, 168);
            this.panel5.TabIndex = 23;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(11, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "Message";
            // 
            // chkMessages
            // 
            this.chkMessages.FormattingEnabled = true;
            this.chkMessages.Location = new System.Drawing.Point(15, 35);
            this.chkMessages.MultiColumn = true;
            this.chkMessages.Name = "chkMessages";
            this.chkMessages.Size = new System.Drawing.Size(380, 119);
            this.chkMessages.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblScope);
            this.panel4.Controls.Add(this.chkScope);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 386);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 159);
            this.panel4.TabIndex = 22;
            // 
            // lblScope
            // 
            this.lblScope.AutoSize = true;
            this.lblScope.Location = new System.Drawing.Point(11, 23);
            this.lblScope.Name = "lblScope";
            this.lblScope.Size = new System.Drawing.Size(55, 20);
            this.lblScope.TabIndex = 17;
            this.lblScope.Text = "Scope";
            // 
            // chkScope
            // 
            this.chkScope.FormattingEnabled = true;
            this.chkScope.Location = new System.Drawing.Point(15, 54);
            this.chkScope.Name = "chkScope";
            this.chkScope.Size = new System.Drawing.Size(380, 96);
            this.chkScope.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkRunAs);
            this.panel3.Controls.Add(this.lblRunAs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 172);
            this.panel3.TabIndex = 21;
            // 
            // chkRunAs
            // 
            this.chkRunAs.FormattingEnabled = true;
            this.chkRunAs.Location = new System.Drawing.Point(15, 56);
            this.chkRunAs.Name = "chkRunAs";
            this.chkRunAs.Size = new System.Drawing.Size(378, 96);
            this.chkRunAs.TabIndex = 24;
            // 
            // lblRunAs
            // 
            this.lblRunAs.AutoSize = true;
            this.lblRunAs.Location = new System.Drawing.Point(11, 22);
            this.lblRunAs.Name = "lblRunAs";
            this.lblRunAs.Size = new System.Drawing.Size(62, 20);
            this.lblRunAs.TabIndex = 23;
            this.lblRunAs.Text = "Run As";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFilterExpression);
            this.panel2.Controls.Add(this.txtFilterExpression);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 717);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 94);
            this.panel2.TabIndex = 18;
            // 
            // lblFilterExpression
            // 
            this.lblFilterExpression.AutoSize = true;
            this.lblFilterExpression.Location = new System.Drawing.Point(8, 18);
            this.lblFilterExpression.Name = "lblFilterExpression";
            this.lblFilterExpression.Size = new System.Drawing.Size(126, 20);
            this.lblFilterExpression.TabIndex = 12;
            this.lblFilterExpression.Text = "Filter Expression";
            // 
            // txtFilterExpression
            // 
            this.txtFilterExpression.Location = new System.Drawing.Point(15, 41);
            this.txtFilterExpression.Name = "txtFilterExpression";
            this.txtFilterExpression.Size = new System.Drawing.Size(380, 26);
            this.txtFilterExpression.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFilterAttributes);
            this.panel1.Controls.Add(this.txtFilterAttributes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 811);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 80);
            this.panel1.TabIndex = 17;
            // 
            // lblFilterAttributes
            // 
            this.lblFilterAttributes.AutoSize = true;
            this.lblFilterAttributes.Location = new System.Drawing.Point(11, 20);
            this.lblFilterAttributes.Name = "lblFilterAttributes";
            this.lblFilterAttributes.Size = new System.Drawing.Size(117, 20);
            this.lblFilterAttributes.TabIndex = 14;
            this.lblFilterAttributes.Text = "Filter Attributes";
            this.lblFilterAttributes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtFilterAttributes
            // 
            this.txtFilterAttributes.Location = new System.Drawing.Point(10, 43);
            this.txtFilterAttributes.Name = "txtFilterAttributes";
            this.txtFilterAttributes.Size = new System.Drawing.Size(380, 26);
            this.txtFilterAttributes.TabIndex = 15;
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
            this.lnkClearFilters.TabIndex = 25;
            this.lnkClearFilters.TabStop = true;
            this.lnkClearFilters.Text = "Remove Filters";
            this.lnkClearFilters.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearFilters_LinkClicked);
            // 
            // FiltersDataVerse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFilters);
            this.Name = "FiltersDataVerse";
            this.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Panel panel6;
        private Forms.AttributesSelector attributesSelector1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckedListBox chkMessages;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.CheckedListBox chkScope;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox chkRunAs;
        private System.Windows.Forms.Label lblRunAs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFilterExpression;
        private System.Windows.Forms.TextBox txtFilterExpression;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFilterAttributes;
        private System.Windows.Forms.TextBox txtFilterAttributes;
        private System.Windows.Forms.LinkLabel lnkClearFilters;
    }
}
