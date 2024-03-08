using DataVerseTrigger.Controls.Filters;
using DataVerseTrigger.Models;

namespace DataVerseTrigger.Controls.Grids
{
    partial class PluginTriggers
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
            this.gtGridPlugins = new System.Windows.Forms.DataGridView();
            this.pluginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.tabCloudFlows = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabFilter = new System.Windows.Forms.TabPage();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pluginBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.filterPlugins1 = new FilterPlugins();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gtGridPlugins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pluginBindingSource)).BeginInit();
            this.pnlData.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.tabCloudFlows.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabFilter.SuspendLayout();
            this.pnlTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pluginBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gtGridPlugins
            // 
            this.gtGridPlugins.AllowUserToAddRows = false;
            this.gtGridPlugins.AllowUserToDeleteRows = false;
            this.gtGridPlugins.AutoGenerateColumns = false;
            this.gtGridPlugins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gtGridPlugins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.Status,
            this.dataGridViewTextBoxColumn1,
            this.Message,
            this.ModeName,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn6});
            this.gtGridPlugins.DataSource = this.pluginBindingSource1;
            this.gtGridPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtGridPlugins.Location = new System.Drawing.Point(0, 0);
            this.gtGridPlugins.MultiSelect = false;
            this.gtGridPlugins.Name = "gtGridPlugins";
            this.gtGridPlugins.ReadOnly = true;
            this.gtGridPlugins.RowHeadersWidth = 62;
            this.gtGridPlugins.RowTemplate.Height = 28;
            this.gtGridPlugins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gtGridPlugins.Size = new System.Drawing.Size(1400, 1120);
            this.gtGridPlugins.TabIndex = 0;
            this.gtGridPlugins.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gtGridPlugins_CellFormatting);
            this.gtGridPlugins.SelectionChanged += new System.EventHandler(this.dtGridDataVerse_SelectionChanged);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.gtGridPlugins);
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
            this.tabFilter.Controls.Add(this.filterPlugins1);
            this.tabFilter.Location = new System.Drawing.Point(4, 29);
            this.tabFilter.Name = "tabFilter";
            this.tabFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilter.Size = new System.Drawing.Size(442, 1087);
            this.tabFilter.TabIndex = 1;
            this.tabFilter.Text = "Filters";
            this.tabFilter.UseVisualStyleBackColor = true;
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
            // pluginBindingSource1
            // 
            this.pluginBindingSource1.DataSource = typeof(Plugin);
            // 
            // filterPlugins1
            // 
            this.filterPlugins1.ConnectionDetail = null;
            this.filterPlugins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPlugins1.Location = new System.Drawing.Point(3, 3);
            this.filterPlugins1.LstClassicWorkflows = null;
            this.filterPlugins1.Name = "filterPlugins1";
            this.filterPlugins1.PluginIcon = null;
            this.filterPlugins1.Service = null;
            this.filterPlugins1.Size = new System.Drawing.Size(436, 1081);
            this.filterPlugins1.TabIcon = null;
            this.filterPlugins1.TabIndex = 0;
            this.filterPlugins1.ToolName = null;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Plugin step name";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "ComponentStateName";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrimaryObjectTypeCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Table";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "SdkMessageIdName";
            this.Message.HeaderText = "Message";
            this.Message.MinimumWidth = 8;
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 150;
            // 
            // ModeName
            // 
            this.ModeName.DataPropertyName = "ModeName";
            this.ModeName.HeaderText = "Execution Mode";
            this.ModeName.MinimumWidth = 8;
            this.ModeName.Name = "ModeName";
            this.ModeName.ReadOnly = true;
            this.ModeName.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Stage";
            this.dataGridViewTextBoxColumn10.HeaderText = "Stage Number";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "StageName";
            this.dataGridViewTextBoxColumn11.HeaderText = "Stage Name";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FilteringAttributes";
            this.dataGridViewTextBoxColumn6.HeaderText = "Filtering Attributes";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 286;
            // 
            // PluginTriggers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTab);
            this.Name = "PluginTriggers";
            this.Size = new System.Drawing.Size(1850, 1120);
            ((System.ComponentModel.ISupportInitialize)(this.gtGridPlugins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pluginBindingSource)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.tabCloudFlows.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabFilter.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pluginBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gtGridPlugins;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlTab;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabCloudFlows;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.BindingSource pluginBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryObjectTypeCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdkMessageProcessingStepIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdkMessageIdNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentStateNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filteringAttributesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdkMessageIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdkMessageFilterIdNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabFilter;
        private Filters.FilterPlugins filterPlugins1;
        private System.Windows.Forms.BindingSource pluginBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
