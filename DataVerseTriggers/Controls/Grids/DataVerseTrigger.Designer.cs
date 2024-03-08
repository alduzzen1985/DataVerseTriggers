using DataVerseTrigger.Controls.Filters;
using DataVerseTrigger.Models;
using DataVerseTrigger.Extensions;

namespace DataVerseTrigger.Controls.Grids
{
    partial class DataVerseTrigger
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
            this.dtGridDataVerse = new System.Windows.Forms.DataGridView();
            this.workflowuniqueidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workflowidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entitynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scopeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filteringattributesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterexpressionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postponeuntilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVerseCloudFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.tabCloudFlows = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabFilter = new System.Windows.Forms.TabPage();
            this.dataVerseFilters1 = new FiltersDataVerse();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDataVerse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVerseCloudFlowBindingSource)).BeginInit();
            this.pnlData.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.tabCloudFlows.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabFilter.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGridDataVerse
            // 
            this.dtGridDataVerse.AllowUserToAddRows = false;
            this.dtGridDataVerse.AllowUserToDeleteRows = false;
            this.dtGridDataVerse.AutoGenerateColumns = false;
            this.dtGridDataVerse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridDataVerse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workflowuniqueidDataGridViewTextBoxColumn,
            this.workflowidDataGridViewTextBoxColumn,
            this.Name,
            this.Status,
            this.entitynameDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.scopeDataGridViewTextBoxColumn,
            this.filteringattributesDataGridViewTextBoxColumn,
            this.filterexpressionDataGridViewTextBoxColumn,
            this.postponeuntilDataGridViewTextBoxColumn,
            this.runasDataGridViewTextBoxColumn});
            this.dtGridDataVerse.DataSource = this.dataVerseCloudFlowBindingSource;
            this.dtGridDataVerse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridDataVerse.Location = new System.Drawing.Point(0, 0);
            this.dtGridDataVerse.MultiSelect = false;
            this.dtGridDataVerse.Name = "dtGridDataVerse";
            this.dtGridDataVerse.ReadOnly = true;
            this.dtGridDataVerse.RowHeadersWidth = 62;
            this.dtGridDataVerse.RowTemplate.Height = 28;
            this.dtGridDataVerse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridDataVerse.Size = new System.Drawing.Size(1400, 1120);
            this.dtGridDataVerse.TabIndex = 0;
            this.dtGridDataVerse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridDataVerse_CellClick);
            this.dtGridDataVerse.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGridDataVerse_CellFormatting);
            this.dtGridDataVerse.SelectionChanged += new System.EventHandler(this.dtGridDataVerse_SelectionChanged);
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
            this.Status.DataPropertyName = "StatusName";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // entitynameDataGridViewTextBoxColumn
            // 
            this.entitynameDataGridViewTextBoxColumn.DataPropertyName = "Entityname";
            this.entitynameDataGridViewTextBoxColumn.HeaderText = "Table";
            this.entitynameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.entitynameDataGridViewTextBoxColumn.Name = "entitynameDataGridViewTextBoxColumn";
            this.entitynameDataGridViewTextBoxColumn.ReadOnly = true;
            this.entitynameDataGridViewTextBoxColumn.Width = 150;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            this.messageDataGridViewTextBoxColumn.Width = 110;
            // 
            // scopeDataGridViewTextBoxColumn
            // 
            this.scopeDataGridViewTextBoxColumn.DataPropertyName = "Scope";
            this.scopeDataGridViewTextBoxColumn.HeaderText = "Scope";
            this.scopeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.scopeDataGridViewTextBoxColumn.Name = "scopeDataGridViewTextBoxColumn";
            this.scopeDataGridViewTextBoxColumn.ReadOnly = true;
            this.scopeDataGridViewTextBoxColumn.Width = 150;
            // 
            // filteringattributesDataGridViewTextBoxColumn
            // 
            this.filteringattributesDataGridViewTextBoxColumn.DataPropertyName = "Filteringattributes";
            this.filteringattributesDataGridViewTextBoxColumn.HeaderText = "Filtering Attributes";
            this.filteringattributesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.filteringattributesDataGridViewTextBoxColumn.Name = "filteringattributesDataGridViewTextBoxColumn";
            this.filteringattributesDataGridViewTextBoxColumn.ReadOnly = true;
            this.filteringattributesDataGridViewTextBoxColumn.Width = 150;
            // 
            // filterexpressionDataGridViewTextBoxColumn
            // 
            this.filterexpressionDataGridViewTextBoxColumn.DataPropertyName = "Filterexpression";
            this.filterexpressionDataGridViewTextBoxColumn.HeaderText = "Filter Expression";
            this.filterexpressionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.filterexpressionDataGridViewTextBoxColumn.Name = "filterexpressionDataGridViewTextBoxColumn";
            this.filterexpressionDataGridViewTextBoxColumn.ReadOnly = true;
            this.filterexpressionDataGridViewTextBoxColumn.Width = 150;
            // 
            // postponeuntilDataGridViewTextBoxColumn
            // 
            this.postponeuntilDataGridViewTextBoxColumn.DataPropertyName = "Postponeuntil";
            this.postponeuntilDataGridViewTextBoxColumn.HeaderText = "Postpone Until";
            this.postponeuntilDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.postponeuntilDataGridViewTextBoxColumn.Name = "postponeuntilDataGridViewTextBoxColumn";
            this.postponeuntilDataGridViewTextBoxColumn.ReadOnly = true;
            this.postponeuntilDataGridViewTextBoxColumn.Width = 150;
            // 
            // runasDataGridViewTextBoxColumn
            // 
            this.runasDataGridViewTextBoxColumn.DataPropertyName = "Runas";
            this.runasDataGridViewTextBoxColumn.HeaderText = "Run As";
            this.runasDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.runasDataGridViewTextBoxColumn.Name = "runasDataGridViewTextBoxColumn";
            this.runasDataGridViewTextBoxColumn.ReadOnly = true;
            this.runasDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataVerseCloudFlowBindingSource
            // 
            this.dataVerseCloudFlowBindingSource.DataSource = typeof(DataVerseCloudFlow);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dtGridDataVerse);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1400, 1120);
            this.pnlData.TabIndex = 1;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.tabCloudFlows);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(1400, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(450, 1120);
            this.pnlDetails.TabIndex = 2;
            // 
            // tabCloudFlows
            // 
            this.tabCloudFlows.Controls.Add(this.tabDetails);
            this.tabCloudFlows.Controls.Add(this.tabFilter);
            this.tabCloudFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCloudFlows.Location = new System.Drawing.Point(0, 0);
            this.tabCloudFlows.Name = "tabCloudFlows";
            this.tabCloudFlows.SelectedIndex = 0;
            this.tabCloudFlows.Size = new System.Drawing.Size(450, 1120);
            this.tabCloudFlows.TabIndex = 1;
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
            // tabFilter
            // 
            this.tabFilter.Controls.Add(this.dataVerseFilters1);
            this.tabFilter.Location = new System.Drawing.Point(4, 29);
            this.tabFilter.Name = "tabFilter";
            this.tabFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilter.Size = new System.Drawing.Size(442, 1087);
            this.tabFilter.TabIndex = 1;
            this.tabFilter.Text = "Filters";
            this.tabFilter.UseVisualStyleBackColor = true;
            // 
            // dataVerseFilters1
            // 
            this.dataVerseFilters1.ConnectionDetail = null;
            this.dataVerseFilters1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataVerseFilters1.Location = new System.Drawing.Point(3, 3);
            this.dataVerseFilters1.LstDataVerseTriggers = null;
            this.dataVerseFilters1.Name = "dataVerseFilters1";
            this.dataVerseFilters1.PluginIcon = null;
            this.dataVerseFilters1.Service = null;
            this.dataVerseFilters1.Size = new System.Drawing.Size(436, 1081);
            this.dataVerseFilters1.TabIcon = null;
            this.dataVerseFilters1.TabIndex = 0;
            this.dataVerseFilters1.ToolName = null;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.pnlData);
            this.pnlTab.Controls.Add(this.pnlDetails);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(1850, 1120);
            this.pnlTab.TabIndex = 3;
            // 
            // DataVerseTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTab);
            this.Size = new System.Drawing.Size(1850, 1120);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDataVerse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVerseCloudFlowBindingSource)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.tabCloudFlows.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabFilter.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridDataVerse;
        private System.Windows.Forms.BindingSource dataVerseCloudFlowBindingSource;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlTab;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabCloudFlows;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabFilter;
        private Filters.FiltersDataVerse dataVerseFilters1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn workflowuniqueidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workflowidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn entitynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scopeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filteringattributesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filterexpressionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postponeuntilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn runasDataGridViewTextBoxColumn;
    }
}
