namespace DataVerseTrigger.Controls.Forms
{
    partial class TriggerDetails
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabTriggered = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCloudFlows = new System.Windows.Forms.DataGridView();
            this.colCfName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colCfStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCfMatchReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCfConfidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCfViewSteps = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvWorkflows = new System.Windows.Forms.DataGridView();
            this.colWfName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colWfStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWfMatchReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWfConfidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWfViewSteps = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tabTriggered.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCloudFlows)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkflows)).BeginInit();
            this.SuspendLayout();
            //
            // tabTriggered
            //
            this.tabTriggered.Controls.Add(this.tabPage1);
            this.tabTriggered.Controls.Add(this.tabPage2);
            this.tabTriggered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTriggered.Location = new System.Drawing.Point(0, 0);
            this.tabTriggered.Name = "tabTriggered";
            this.tabTriggered.SelectedIndex = 0;
            this.tabTriggered.Size = new System.Drawing.Size(1797, 483);
            this.tabTriggered.TabIndex = 2;
            //
            // tabPage1
            //
            this.tabPage1.Controls.Add(this.dgvCloudFlows);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1789, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Triggered by (Cloud Flows)";
            this.tabPage1.UseVisualStyleBackColor = true;
            //
            // dgvCloudFlows
            //
            this.dgvCloudFlows.AllowUserToAddRows = false;
            this.dgvCloudFlows.AllowUserToDeleteRows = false;
            this.dgvCloudFlows.AutoGenerateColumns = false;
            this.dgvCloudFlows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCloudFlows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCfName,
            this.colCfStatus,
            this.colCfMatchReason,
            this.colCfConfidence,
            this.colCfViewSteps});
            this.dgvCloudFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCloudFlows.Location = new System.Drawing.Point(3, 3);
            this.dgvCloudFlows.MultiSelect = false;
            this.dgvCloudFlows.Name = "dgvCloudFlows";
            this.dgvCloudFlows.ReadOnly = true;
            this.dgvCloudFlows.RowHeadersWidth = 62;
            this.dgvCloudFlows.RowTemplate.Height = 28;
            this.dgvCloudFlows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCloudFlows.Size = new System.Drawing.Size(1783, 448);
            this.dgvCloudFlows.TabIndex = 0;
            //
            // colCfName
            //
            this.colCfName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCfName.DataPropertyName = "Name";
            this.colCfName.HeaderText = "Flow Name";
            this.colCfName.MinimumWidth = 8;
            this.colCfName.Name = "colCfName";
            this.colCfName.ReadOnly = true;
            this.colCfName.TrackVisitedState = false;
            //
            // colCfStatus
            //
            this.colCfStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCfStatus.DataPropertyName = "StatusName";
            this.colCfStatus.HeaderText = "Status";
            this.colCfStatus.MinimumWidth = 8;
            this.colCfStatus.Name = "colCfStatus";
            this.colCfStatus.ReadOnly = true;
            this.colCfStatus.Width = 80;
            //
            // colCfMatchReason
            //
            this.colCfMatchReason.DataPropertyName = "MatchReason";
            this.colCfMatchReason.HeaderText = "Match Reason";
            this.colCfMatchReason.MinimumWidth = 8;
            this.colCfMatchReason.Name = "colCfMatchReason";
            this.colCfMatchReason.ReadOnly = true;
            this.colCfMatchReason.Width = 220;
            //
            // colCfConfidence
            //
            this.colCfConfidence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCfConfidence.DataPropertyName = "Confidence";
            this.colCfConfidence.HeaderText = "Confidence";
            this.colCfConfidence.MinimumWidth = 8;
            this.colCfConfidence.Name = "colCfConfidence";
            this.colCfConfidence.ReadOnly = true;
            this.colCfConfidence.Width = 90;
            //
            // colCfViewSteps
            //
            this.colCfViewSteps.HeaderText = "Steps";
            this.colCfViewSteps.MinimumWidth = 8;
            this.colCfViewSteps.Name = "colCfViewSteps";
            this.colCfViewSteps.ReadOnly = true;
            this.colCfViewSteps.Text = "View Steps";
            this.colCfViewSteps.TrackVisitedState = false;
            this.colCfViewSteps.UseColumnTextForLinkValue = true;
            this.colCfViewSteps.Width = 90;
            //
            // tabPage2
            //
            this.tabPage2.Controls.Add(this.dgvWorkflows);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1789, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Triggered by (Classic Workflows)";
            this.tabPage2.UseVisualStyleBackColor = true;
            //
            // dgvWorkflows
            //
            this.dgvWorkflows.AllowUserToAddRows = false;
            this.dgvWorkflows.AllowUserToDeleteRows = false;
            this.dgvWorkflows.AutoGenerateColumns = false;
            this.dgvWorkflows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkflows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWfName,
            this.colWfStatus,
            this.colWfMatchReason,
            this.colWfConfidence,
            this.colWfViewSteps});
            this.dgvWorkflows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkflows.Location = new System.Drawing.Point(3, 3);
            this.dgvWorkflows.MultiSelect = false;
            this.dgvWorkflows.Name = "dgvWorkflows";
            this.dgvWorkflows.ReadOnly = true;
            this.dgvWorkflows.RowHeadersWidth = 62;
            this.dgvWorkflows.RowTemplate.Height = 28;
            this.dgvWorkflows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkflows.Size = new System.Drawing.Size(1783, 448);
            this.dgvWorkflows.TabIndex = 0;
            //
            // colWfName
            //
            this.colWfName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWfName.DataPropertyName = "Name";
            this.colWfName.HeaderText = "Workflow Name";
            this.colWfName.MinimumWidth = 8;
            this.colWfName.Name = "colWfName";
            this.colWfName.ReadOnly = true;
            this.colWfName.TrackVisitedState = false;
            //
            // colWfStatus
            //
            this.colWfStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colWfStatus.DataPropertyName = "StatusName";
            this.colWfStatus.HeaderText = "Status";
            this.colWfStatus.MinimumWidth = 8;
            this.colWfStatus.Name = "colWfStatus";
            this.colWfStatus.ReadOnly = true;
            this.colWfStatus.Width = 80;
            //
            // colWfMatchReason
            //
            this.colWfMatchReason.DataPropertyName = "MatchReason";
            this.colWfMatchReason.HeaderText = "Match Reason";
            this.colWfMatchReason.MinimumWidth = 8;
            this.colWfMatchReason.Name = "colWfMatchReason";
            this.colWfMatchReason.ReadOnly = true;
            this.colWfMatchReason.Width = 220;
            //
            // colWfConfidence
            //
            this.colWfConfidence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colWfConfidence.DataPropertyName = "Confidence";
            this.colWfConfidence.HeaderText = "Confidence";
            this.colWfConfidence.MinimumWidth = 8;
            this.colWfConfidence.Name = "colWfConfidence";
            this.colWfConfidence.ReadOnly = true;
            this.colWfConfidence.Width = 90;
            //
            // colWfViewSteps
            //
            this.colWfViewSteps.HeaderText = "Steps";
            this.colWfViewSteps.MinimumWidth = 8;
            this.colWfViewSteps.Name = "colWfViewSteps";
            this.colWfViewSteps.ReadOnly = true;
            this.colWfViewSteps.Text = "View Steps";
            this.colWfViewSteps.TrackVisitedState = false;
            this.colWfViewSteps.UseColumnTextForLinkValue = true;
            this.colWfViewSteps.Width = 90;
            //
            // TriggerDetails
            //
            this.Controls.Add(this.tabTriggered);
            this.Name = "TriggerDetails";
            this.Size = new System.Drawing.Size(1797, 483);
            this.tabTriggered.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCloudFlows)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkflows)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabTriggered;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvCloudFlows;
        private System.Windows.Forms.DataGridView dgvWorkflows;
        private System.Windows.Forms.DataGridViewLinkColumn colCfName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCfStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCfMatchReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCfConfidence;
        private System.Windows.Forms.DataGridViewLinkColumn colCfViewSteps;
        private System.Windows.Forms.DataGridViewLinkColumn colWfName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWfStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWfMatchReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWfConfidence;
        private System.Windows.Forms.DataGridViewLinkColumn colWfViewSteps;
    }
}
