using DataVerseTrigger.Controls.Forms;

namespace DataVerseTrigger.Controls.Filters
{
    partial class FilterWorkflows
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
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.chkEvents = new System.Windows.Forms.CheckedListBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkScope = new System.Windows.Forms.CheckedListBox();
            this.lblScope = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkLstMode = new System.Windows.Forms.CheckedListBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOnDemand = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.attributesSelector1 = new Controls.Forms.AttributesSelector();
            this.lnkClearFilters = new System.Windows.Forms.LinkLabel();
            this.pnlFilters.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
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
            // chkEvents
            // 
            this.chkEvents.FormattingEnabled = true;
            this.chkEvents.Location = new System.Drawing.Point(22, 52);
            this.chkEvents.MultiColumn = true;
            this.chkEvents.Name = "chkEvents";
            this.chkEvents.Size = new System.Drawing.Size(380, 96);
            this.chkEvents.TabIndex = 9;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(18, 19);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 20);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Event";
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.panel5);
            this.pnlFilters.Controls.Add(this.panel4);
            this.pnlFilters.Controls.Add(this.panel3);
            this.pnlFilters.Controls.Add(this.panel1);
            this.pnlFilters.Controls.Add(this.panel2);
            this.pnlFilters.Controls.Add(this.btnApplyFilter);
            this.pnlFilters.Controls.Add(this.lnkClearFilters);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkScope);
            this.panel5.Controls.Add(this.lblScope);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 353);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(450, 151);
            this.panel5.TabIndex = 23;
            // 
            // chkScope
            // 
            this.chkScope.FormattingEnabled = true;
            this.chkScope.Location = new System.Drawing.Point(23, 41);
            this.chkScope.Name = "chkScope";
            this.chkScope.Size = new System.Drawing.Size(380, 96);
            this.chkScope.TabIndex = 16;
            // 
            // lblScope
            // 
            this.lblScope.AutoSize = true;
            this.lblScope.Location = new System.Drawing.Point(19, 13);
            this.lblScope.Name = "lblScope";
            this.lblScope.Size = new System.Drawing.Size(55, 20);
            this.lblScope.TabIndex = 15;
            this.lblScope.Text = "Scope";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkLstMode);
            this.panel4.Controls.Add(this.lblMode);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 504);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 132);
            this.panel4.TabIndex = 22;
            // 
            // chkLstMode
            // 
            this.chkLstMode.FormattingEnabled = true;
            this.chkLstMode.Location = new System.Drawing.Point(22, 42);
            this.chkLstMode.Name = "chkLstMode";
            this.chkLstMode.Size = new System.Drawing.Size(380, 73);
            this.chkLstMode.TabIndex = 18;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(19, 3);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(49, 20);
            this.lblMode.TabIndex = 17;
            this.lblMode.Text = "Mode";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblMessage);
            this.panel3.Controls.Add(this.chkEvents);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 636);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 155);
            this.panel3.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkOnDemand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 791);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 100);
            this.panel1.TabIndex = 24;
            // 
            // chkOnDemand
            // 
            this.chkOnDemand.AutoSize = true;
            this.chkOnDemand.Location = new System.Drawing.Point(22, 30);
            this.chkOnDemand.Name = "chkOnDemand";
            this.chkOnDemand.Size = new System.Drawing.Size(121, 24);
            this.chkOnDemand.TabIndex = 15;
            this.chkOnDemand.Text = "On Demand";
            this.chkOnDemand.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.attributesSelector1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 871);
            this.panel2.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblName);
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(450, 82);
            this.panel6.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(380, 26);
            this.textBox1.TabIndex = 4;
            // 
            // attributesSelector1
            // 
            this.attributesSelector1.AutoSize = true;
            this.attributesSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributesSelector1.Location = new System.Drawing.Point(0, 0);
            this.attributesSelector1.Name = "attributesSelector1";
            this.attributesSelector1.Service = null;
            this.attributesSelector1.Size = new System.Drawing.Size(450, 871);
            this.attributesSelector1.TabIndex = 0;
            this.attributesSelector1.Load += new System.EventHandler(this.attributesSelector1_Load);
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
            // FilterWorkflows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFilters);
            this.Name = "FilterWorkflows";
            this.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.CheckedListBox chkEvents;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.CheckBox chkOnDemand;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckedListBox chkScope;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckedListBox chkLstMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Forms.AttributesSelector attributesSelector1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkClearFilters;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBox1;
    }
}
