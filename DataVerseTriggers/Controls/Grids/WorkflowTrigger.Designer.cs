using DataVerseTrigger.Controls.Filters;
using DataVerseTrigger.Models;

namespace DataVerseTrigger.Controls.Grids
{
    partial class WorkflowTrigger
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
            this.components = new System.ComponentModel.Container();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dtWorkflows = new System.Windows.Forms.DataGridView();
            this.classicWorkflowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabFilters = new System.Windows.Forms.TabPage();
            this.filterWorkflows1 = new FilterWorkflows();
            this.scheduledCloudFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.classicWorkflowBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.workflowidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workflowuniqueidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryentitynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scopeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AsChildProcess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TriggerOnCreate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TriggerOnAssign = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TriggerOnDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TriggerOnStatusChange = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TriggerOnUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.triggerOnUpdateAttributeListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtWorkflows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicWorkflowBindingSource)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduledCloudFlowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicWorkflowBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dtWorkflows);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1400, 1120);
            this.pnlData.TabIndex = 4;
            // 
            // dtWorkflows
            // 
            this.dtWorkflows.AutoGenerateColumns = false;
            this.dtWorkflows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtWorkflows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workflowidDataGridViewTextBoxColumn,
            this.workflowuniqueidDataGridViewTextBoxColumn,
            this.Name,
            this.Status,
            this.primaryentitynameDataGridViewTextBoxColumn,
            this.modeDataGridViewTextBoxColumn,
            this.scopeNameDataGridViewTextBoxColumn,
            this.AsChildProcess,
            this.TriggerOnCreate,
            this.TriggerOnAssign,
            this.TriggerOnDelete,
            this.TriggerOnStatusChange,
            this.TriggerOnUpdate,
            this.triggerOnUpdateAttributeListDataGridViewTextBoxColumn});
            this.dtWorkflows.DataSource = this.classicWorkflowBindingSource;
            this.dtWorkflows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtWorkflows.Location = new System.Drawing.Point(0, 0);
            this.dtWorkflows.MultiSelect = false;
            this.dtWorkflows.Name = "dtWorkflows";
            this.dtWorkflows.ReadOnly = true;
            this.dtWorkflows.RowHeadersWidth = 62;
            this.dtWorkflows.RowTemplate.Height = 28;
            this.dtWorkflows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtWorkflows.Size = new System.Drawing.Size(1400, 1120);
            this.dtWorkflows.TabIndex = 0;
            this.dtWorkflows.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtWorkflows_CellClick);
            this.dtWorkflows.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtWorkflows_CellFormatting);
            this.dtWorkflows.SelectionChanged += new System.EventHandler(this.dtWorkflows_SelectionChanged);
            // 
            // classicWorkflowBindingSource
            // 
            this.classicWorkflowBindingSource.DataSource = typeof(ClassicWorkflow);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.tabControl1);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(1400, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(450, 1120);
            this.pnlDetails.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDetails);
            this.tabControl1.Controls.Add(this.tabFilters);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 1120);
            this.tabControl1.TabIndex = 3;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.propertyGrid1);
            this.tabDetails.Location = new System.Drawing.Point(4, 29);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(442, 1087);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(436, 1081);
            this.propertyGrid1.TabIndex = 0;
            // 
            // tabFilters
            // 
            this.tabFilters.Controls.Add(this.filterWorkflows1);
            this.tabFilters.Location = new System.Drawing.Point(4, 29);
            this.tabFilters.Name = "tabFilters";
            this.tabFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilters.Size = new System.Drawing.Size(442, 1087);
            this.tabFilters.TabIndex = 1;
            this.tabFilters.Text = "Filters";
            this.tabFilters.UseVisualStyleBackColor = true;
            // 
            // filterWorkflows1
            // 
            this.filterWorkflows1.ConnectionDetail = null;
            this.filterWorkflows1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterWorkflows1.Location = new System.Drawing.Point(3, 3);
            this.filterWorkflows1.LstClassicWorkflows = null;
            this.filterWorkflows1.Name = "filterWorkflows1";
            this.filterWorkflows1.PluginIcon = null;
            this.filterWorkflows1.Service = null;
            this.filterWorkflows1.Size = new System.Drawing.Size(436, 1081);
            this.filterWorkflows1.TabIcon = null;
            this.filterWorkflows1.TabIndex = 0;
            this.filterWorkflows1.ToolName = null;
            this.filterWorkflows1.OnFilterApplied += new FilterWorkflows.FilterApplied(this.filterWorkflows1_OnFilterApplied);
            // 
            // scheduledCloudFlowBindingSource
            // 
            this.scheduledCloudFlowBindingSource.DataSource = typeof(ScheduledCloudFlow);
            // 
            // classicWorkflowBindingSource1
            // 
            this.classicWorkflowBindingSource1.DataSource = typeof(ClassicWorkflow);
            // 
            // workflowidDataGridViewTextBoxColumn
            // 
            this.workflowidDataGridViewTextBoxColumn.DataPropertyName = "Workflowid";
            this.workflowidDataGridViewTextBoxColumn.HeaderText = "Workflowid";
            this.workflowidDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.workflowidDataGridViewTextBoxColumn.Name = "workflowidDataGridViewTextBoxColumn";
            this.workflowidDataGridViewTextBoxColumn.ReadOnly = true;
            this.workflowidDataGridViewTextBoxColumn.Visible = false;
            this.workflowidDataGridViewTextBoxColumn.Width = 150;
            // 
            // workflowuniqueidDataGridViewTextBoxColumn
            // 
            this.workflowuniqueidDataGridViewTextBoxColumn.DataPropertyName = "Workflowuniqueid";
            this.workflowuniqueidDataGridViewTextBoxColumn.HeaderText = "Workflowuniqueid";
            this.workflowuniqueidDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.workflowuniqueidDataGridViewTextBoxColumn.Name = "workflowuniqueidDataGridViewTextBoxColumn";
            this.workflowuniqueidDataGridViewTextBoxColumn.ReadOnly = true;
            this.workflowuniqueidDataGridViewTextBoxColumn.Visible = false;
            this.workflowuniqueidDataGridViewTextBoxColumn.Width = 150;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 8;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 150;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status.DataPropertyName = "StatusName";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 92;
            // 
            // primaryentitynameDataGridViewTextBoxColumn
            // 
            this.primaryentitynameDataGridViewTextBoxColumn.DataPropertyName = "Primaryentityname";
            this.primaryentitynameDataGridViewTextBoxColumn.HeaderText = "Table";
            this.primaryentitynameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.primaryentitynameDataGridViewTextBoxColumn.Name = "primaryentitynameDataGridViewTextBoxColumn";
            this.primaryentitynameDataGridViewTextBoxColumn.ReadOnly = true;
            this.primaryentitynameDataGridViewTextBoxColumn.Width = 150;
            // 
            // modeDataGridViewTextBoxColumn
            // 
            this.modeDataGridViewTextBoxColumn.DataPropertyName = "Mode";
            this.modeDataGridViewTextBoxColumn.HeaderText = "Mode";
            this.modeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.modeDataGridViewTextBoxColumn.Name = "modeDataGridViewTextBoxColumn";
            this.modeDataGridViewTextBoxColumn.ReadOnly = true;
            this.modeDataGridViewTextBoxColumn.Width = 150;
            // 
            // scopeNameDataGridViewTextBoxColumn
            // 
            this.scopeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.scopeNameDataGridViewTextBoxColumn.DataPropertyName = "ScopeName";
            this.scopeNameDataGridViewTextBoxColumn.HeaderText = "Scope";
            this.scopeNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.scopeNameDataGridViewTextBoxColumn.Name = "scopeNameDataGridViewTextBoxColumn";
            this.scopeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.scopeNameDataGridViewTextBoxColumn.Width = 91;
            // 
            // AsChildProcess
            // 
            this.AsChildProcess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AsChildProcess.DataPropertyName = "AsChildProcess";
            this.AsChildProcess.HeaderText = "Child Process";
            this.AsChildProcess.MinimumWidth = 8;
            this.AsChildProcess.Name = "AsChildProcess";
            this.AsChildProcess.ReadOnly = true;
            this.AsChildProcess.Width = 111;
            // 
            // TriggerOnCreate
            // 
            this.TriggerOnCreate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TriggerOnCreate.DataPropertyName = "TriggerOnCreate";
            this.TriggerOnCreate.HeaderText = "On Create";
            this.TriggerOnCreate.MinimumWidth = 8;
            this.TriggerOnCreate.Name = "TriggerOnCreate";
            this.TriggerOnCreate.ReadOnly = true;
            this.TriggerOnCreate.Width = 88;
            // 
            // TriggerOnAssign
            // 
            this.TriggerOnAssign.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TriggerOnAssign.DataPropertyName = "TriggerOnAssign";
            this.TriggerOnAssign.HeaderText = "On Assign";
            this.TriggerOnAssign.MinimumWidth = 8;
            this.TriggerOnAssign.Name = "TriggerOnAssign";
            this.TriggerOnAssign.ReadOnly = true;
            this.TriggerOnAssign.Width = 88;
            // 
            // TriggerOnDelete
            // 
            this.TriggerOnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TriggerOnDelete.DataPropertyName = "TriggerOnDelete";
            this.TriggerOnDelete.HeaderText = "On Delete";
            this.TriggerOnDelete.MinimumWidth = 8;
            this.TriggerOnDelete.Name = "TriggerOnDelete";
            this.TriggerOnDelete.ReadOnly = true;
            this.TriggerOnDelete.Width = 87;
            // 
            // TriggerOnStatusChange
            // 
            this.TriggerOnStatusChange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TriggerOnStatusChange.DataPropertyName = "TriggerOnStatusChange";
            this.TriggerOnStatusChange.HeaderText = "On Change Status";
            this.TriggerOnStatusChange.MinimumWidth = 8;
            this.TriggerOnStatusChange.Name = "TriggerOnStatusChange";
            this.TriggerOnStatusChange.ReadOnly = true;
            this.TriggerOnStatusChange.Width = 132;
            // 
            // TriggerOnUpdate
            // 
            this.TriggerOnUpdate.DataPropertyName = "TriggerOnUpdate";
            this.TriggerOnUpdate.HeaderText = "On Update";
            this.TriggerOnUpdate.MinimumWidth = 8;
            this.TriggerOnUpdate.Name = "TriggerOnUpdate";
            this.TriggerOnUpdate.ReadOnly = true;
            this.TriggerOnUpdate.Width = 150;
            // 
            // triggerOnUpdateAttributeListDataGridViewTextBoxColumn
            // 
            this.triggerOnUpdateAttributeListDataGridViewTextBoxColumn.DataPropertyName = "TriggerOnUpdateAttributeList";
            this.triggerOnUpdateAttributeListDataGridViewTextBoxColumn.HeaderText = "On Update attribute list";
            this.triggerOnUpdateAttributeListDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.triggerOnUpdateAttributeListDataGridViewTextBoxColumn.Name = "triggerOnUpdateAttributeListDataGridViewTextBoxColumn";
            this.triggerOnUpdateAttributeListDataGridViewTextBoxColumn.ReadOnly = true;
            this.triggerOnUpdateAttributeListDataGridViewTextBoxColumn.Width = 77;
            // 
            // WorkflowTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlDetails);
            this.Size = new System.Drawing.Size(1850, 1120);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtWorkflows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicWorkflowBindingSource)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scheduledCloudFlowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicWorkflowBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource scheduledCloudFlowBindingSource;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabFilters;
        private System.Windows.Forms.BindingSource classicWorkflowBindingSource1;
        private System.Windows.Forms.BindingSource classicWorkflowBindingSource;
        private System.Windows.Forms.DataGridView dtWorkflows;
        private Filters.FilterWorkflows filterWorkflows1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn triggerOnCreateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn triggerOnDeleteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn onDemandDataGridViewCheckBoxColumn;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn workflowidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workflowuniqueidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryentitynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scopeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AsChildProcess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TriggerOnCreate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TriggerOnAssign;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TriggerOnDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TriggerOnStatusChange;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TriggerOnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn triggerOnUpdateAttributeListDataGridViewTextBoxColumn;
    }
}
