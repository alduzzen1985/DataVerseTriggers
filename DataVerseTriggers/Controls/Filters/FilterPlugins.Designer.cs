using DataVerseTrigger.Controls.Forms;

namespace DataVerseTrigger.Controls.Filters
{
    partial class FilterPlugins
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
            this.chkMessage = new System.Windows.Forms.CheckedListBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkStage = new System.Windows.Forms.CheckedListBox();
            this.lblStage = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkLstMode = new System.Windows.Forms.CheckedListBox();
            this.lblExecutionMode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.attributesSelector1 = new Controls.Forms.AttributesSelector();
            this.lnkClearFilters = new System.Windows.Forms.LinkLabel();
            this.pnlFilters.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // chkMessage
            // 
            this.chkMessage.FormattingEnabled = true;
            this.chkMessage.Location = new System.Drawing.Point(22, 52);
            this.chkMessage.MultiColumn = true;
            this.chkMessage.Name = "chkMessage";
            this.chkMessage.Size = new System.Drawing.Size(380, 96);
            this.chkMessage.TabIndex = 9;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(18, 19);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Message";
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.panel5);
            this.pnlFilters.Controls.Add(this.panel4);
            this.pnlFilters.Controls.Add(this.panel3);
            this.pnlFilters.Controls.Add(this.panel2);
            this.pnlFilters.Controls.Add(this.btnApplyFilter);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkStage);
            this.panel5.Controls.Add(this.lblStage);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 437);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(450, 151);
            this.panel5.TabIndex = 23;
            // 
            // chkStage
            // 
            this.chkStage.FormattingEnabled = true;
            this.chkStage.Location = new System.Drawing.Point(23, 41);
            this.chkStage.Name = "chkStage";
            this.chkStage.Size = new System.Drawing.Size(380, 96);
            this.chkStage.TabIndex = 16;
            // 
            // lblStage
            // 
            this.lblStage.AutoSize = true;
            this.lblStage.Location = new System.Drawing.Point(19, 13);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(52, 20);
            this.lblStage.TabIndex = 15;
            this.lblStage.Text = "Stage";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkLstMode);
            this.panel4.Controls.Add(this.lblExecutionMode);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 588);
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
            // lblExecutionMode
            // 
            this.lblExecutionMode.AutoSize = true;
            this.lblExecutionMode.Location = new System.Drawing.Point(19, 8);
            this.lblExecutionMode.Name = "lblExecutionMode";
            this.lblExecutionMode.Size = new System.Drawing.Size(123, 20);
            this.lblExecutionMode.TabIndex = 17;
            this.lblExecutionMode.Text = "Execution Mode";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblMessage);
            this.panel3.Controls.Add(this.chkMessage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 720);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 171);
            this.panel3.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.attributesSelector1);
            this.panel2.Controls.Add(this.lnkClearFilters);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 891);
            this.panel2.TabIndex = 20;
            // 
            // attributesSelector1
            // 
            this.attributesSelector1.AutoSize = true;
            this.attributesSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributesSelector1.Location = new System.Drawing.Point(0, 20);
            this.attributesSelector1.Name = "attributesSelector1";
            this.attributesSelector1.Service = null;
            this.attributesSelector1.Size = new System.Drawing.Size(450, 871);
            this.attributesSelector1.TabIndex = 0;
            // 
            // lnkClearFilters
            // 
            this.lnkClearFilters.AutoSize = true;
            this.lnkClearFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkClearFilters.Location = new System.Drawing.Point(0, 0);
            this.lnkClearFilters.Name = "lnkClearFilters";
            this.lnkClearFilters.Size = new System.Drawing.Size(115, 20);
            this.lnkClearFilters.TabIndex = 1;
            this.lnkClearFilters.TabStop = true;
            this.lnkClearFilters.Text = "Remove Filters";
            this.lnkClearFilters.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearFilters_LinkClicked);
            // 
            // FilterPlugins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFilters);
            this.Name = "FilterPlugins";
            this.Size = new System.Drawing.Size(450, 930);
            this.pnlFilters.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.CheckedListBox chkMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckedListBox chkStage;
        private System.Windows.Forms.Label lblStage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckedListBox chkLstMode;
        private System.Windows.Forms.Label lblExecutionMode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Forms.AttributesSelector attributesSelector1;
        private System.Windows.Forms.LinkLabel lnkClearFilters;
    }
}
