using DataVerseTrigger.Controls.Filters;
using DataVerseTrigger.Models;

namespace DataVerseTrigger.Controls.Grids
{
    partial class ManualTriggerCloudFlows
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
            this.dtGridScheduled = new System.Windows.Forms.DataGridView();
            this.manualCloudFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scheduledCloudFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabFilters = new System.Windows.Forms.TabPage();
            this.Name = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workflowidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workflowuniqueidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridScheduled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manualCloudFlowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduledCloudFlowBindingSource)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dtGridScheduled);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1400, 1120);
            this.pnlData.TabIndex = 4;
            // 
            // dtGridScheduled
            // 
            this.dtGridScheduled.AllowUserToAddRows = false;
            this.dtGridScheduled.AllowUserToDeleteRows = false;
            this.dtGridScheduled.AutoGenerateColumns = false;
            this.dtGridScheduled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridScheduled.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Status,
            this.Kind,
            this.workflowidDataGridViewTextBoxColumn,
            this.workflowuniqueidDataGridViewTextBoxColumn});
            this.dtGridScheduled.DataSource = this.manualCloudFlowBindingSource;
            this.dtGridScheduled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridScheduled.Location = new System.Drawing.Point(0, 0);
            this.dtGridScheduled.Name = "dtGridScheduled";
            this.dtGridScheduled.ReadOnly = true;
            this.dtGridScheduled.RowHeadersWidth = 62;
            this.dtGridScheduled.RowTemplate.Height = 28;
            this.dtGridScheduled.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridScheduled.Size = new System.Drawing.Size(1400, 1120);
            this.dtGridScheduled.TabIndex = 1;
            this.dtGridScheduled.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridScheduled_CellClick);
            this.dtGridScheduled.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGridScheduled_CellFormatting);
            this.dtGridScheduled.SelectionChanged += new System.EventHandler(this.dtGridScheduled_SelectionChanged);
            // 
            // manualCloudFlowBindingSource
            // 
            this.manualCloudFlowBindingSource.DataSource = typeof(Models.CloudFlows.ManualCloudFlow);
            // 
            // scheduledCloudFlowBindingSource
            // 
            this.scheduledCloudFlowBindingSource.DataSource = typeof(Models.ScheduledCloudFlow);
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
            this.propertyGrid1.TabIndex = 1;
            // 
            // tabFilters
            // 
            this.tabFilters.Location = new System.Drawing.Point(4, 29);
            this.tabFilters.Name = "tabFilters";
            this.tabFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilters.Size = new System.Drawing.Size(442, 1087);
            this.tabFilters.TabIndex = 1;
            this.tabFilters.Text = "Filters";
            this.tabFilters.UseVisualStyleBackColor = true;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 8;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Name.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "StatusName";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 130;
            // 
            // Kind
            // 
            this.Kind.DataPropertyName = "Kind";
            this.Kind.HeaderText = "Kind";
            this.Kind.MinimumWidth = 8;
            this.Kind.Name = "Kind";
            this.Kind.ReadOnly = true;
            this.Kind.Width = 150;
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
            // ManualTriggerCloudFlows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlDetails);
            this.Size = new System.Drawing.Size(1850, 1120);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridScheduled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manualCloudFlowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduledCloudFlowBindingSource)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtGridScheduled;
        private System.Windows.Forms.BindingSource scheduledCloudFlowBindingSource;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFilters;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.BindingSource manualCloudFlowBindingSource;
        private System.Windows.Forms.DataGridViewLinkColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn workflowidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workflowuniqueidDataGridViewTextBoxColumn;
    }
}
