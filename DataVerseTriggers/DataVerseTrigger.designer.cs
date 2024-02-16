
using DataVerseTrigger.Controls.Grids;
using DataVerseTrigger.Extensions;

namespace DataVerseTrigger
{
    partial class DataVerseTrigger
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataVerseTrigger));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbBrowser = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbProfile = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSolution = new System.Windows.Forms.ToolStripLabel();
            this.cmbListSolutions = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDownloadExcel = new System.Windows.Forms.ToolStripButton();
            this.lblYouMustConnect = new System.Windows.Forms.ToolStripLabel();
            this.pnlFlows = new System.Windows.Forms.Panel();
            this.tabPlugins = new System.Windows.Forms.TabControl();
            this.tabDataVerseTriggers = new System.Windows.Forms.TabPage();
            this.cstControlDataverseTriggers = new Controls.Grids.DataVerseTrigger();
            this.tabScheduled = new System.Windows.Forms.TabPage();
            this.cstControlRecurrencyTriggers = new Controls.Grids.ScheduledTrigger();
            this.tabManual = new System.Windows.Forms.TabPage();
            this.cstManualTrigger = new Controls.Grids.ManualTriggerCloudFlows();
            this.tabWorkflows = new System.Windows.Forms.TabPage();
            this.cstControlWorkflowsTriggers = new Controls.Grids.WorkflowTrigger();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cstPluginTriggers1 = new Controls.Grids.PluginTriggers();
            this.toolStripMenu.SuspendLayout();
            this.pnlFlows.SuspendLayout();
            this.tabPlugins.SuspendLayout();
            this.tabDataVerseTriggers.SuspendLayout();
            this.tabScheduled.SuspendLayout();
            this.tabManual.SuspendLayout();
            this.tabWorkflows.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.btnRefresh,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.cbBrowser,
            this.toolStripLabel2,
            this.cbProfile,
            this.toolStripSeparator1,
            this.lblSolution,
            this.cmbListSolutions,
            this.toolStripSeparator3,
            this.btnDownloadExcel,
            this.lblYouMustConnect});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(2341, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(34, 29);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 29);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(75, 29);
            this.toolStripLabel1.Text = "Browser";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbBrowser
            // 
            this.cbBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrowser.Name = "cbBrowser";
            this.cbBrowser.Size = new System.Drawing.Size(121, 34);
            this.cbBrowser.SelectedIndexChanged += new System.EventHandler(this.cbBrowser_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(130, 29);
            this.toolStripLabel2.Text = "Browser Profile";
            // 
            // cbProfile
            // 
            this.cbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfile.DropDownWidth = 150;
            this.cbProfile.Name = "cbProfile";
            this.cbProfile.Size = new System.Drawing.Size(200, 34);
            this.cbProfile.SelectedIndexChanged += new System.EventHandler(this.cbProfile_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // lblSolution
            // 
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(78, 29);
            this.lblSolution.Text = "Solution";
            // 
            // cmbListSolutions
            // 
            this.cmbListSolutions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbListSolutions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbListSolutions.Name = "cmbListSolutions";
            this.cmbListSolutions.Size = new System.Drawing.Size(400, 34);
            this.cmbListSolutions.SelectedIndexChanged += new System.EventHandler(this.cmbListSolutions_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
            // 
            // btnDownloadExcel
            // 
            this.btnDownloadExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadExcel.Image")));
            this.btnDownloadExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDownloadExcel.Name = "btnDownloadExcel";
            this.btnDownloadExcel.Size = new System.Drawing.Size(165, 29);
            this.btnDownloadExcel.Text = "Download Excel";
            this.btnDownloadExcel.Click += new System.EventHandler(this.btnDownloadExcel_Click);
            // 
            // lblYouMustConnect
            // 
            this.lblYouMustConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYouMustConnect.ForeColor = System.Drawing.Color.Red;
            this.lblYouMustConnect.Name = "lblYouMustConnect";
            this.lblYouMustConnect.Size = new System.Drawing.Size(202, 29);
            this.lblYouMustConnect.Text = "You\'re not connected !";
            // 
            // pnlFlows
            // 
            this.pnlFlows.Controls.Add(this.tabPlugins);
            this.pnlFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFlows.Location = new System.Drawing.Point(0, 34);
            this.pnlFlows.Name = "pnlFlows";
            this.pnlFlows.Size = new System.Drawing.Size(2341, 838);
            this.pnlFlows.TabIndex = 6;
            // 
            // tabPlugins
            // 
            this.tabPlugins.Controls.Add(this.tabDataVerseTriggers);
            this.tabPlugins.Controls.Add(this.tabScheduled);
            this.tabPlugins.Controls.Add(this.tabManual);
            this.tabPlugins.Controls.Add(this.tabWorkflows);
            this.tabPlugins.Controls.Add(this.tabPage1);
            this.tabPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPlugins.Location = new System.Drawing.Point(0, 0);
            this.tabPlugins.Name = "tabPlugins";
            this.tabPlugins.SelectedIndex = 0;
            this.tabPlugins.Size = new System.Drawing.Size(2341, 838);
            this.tabPlugins.TabIndex = 0;
            // 
            // tabDataVerseTriggers
            // 
            this.tabDataVerseTriggers.Controls.Add(this.cstControlDataverseTriggers);
            this.tabDataVerseTriggers.Location = new System.Drawing.Point(4, 29);
            this.tabDataVerseTriggers.Name = "tabDataVerseTriggers";
            this.tabDataVerseTriggers.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataVerseTriggers.Size = new System.Drawing.Size(2333, 805);
            this.tabDataVerseTriggers.TabIndex = 0;
            this.tabDataVerseTriggers.Text = "DataVerse Tables Triggers";
            this.tabDataVerseTriggers.UseVisualStyleBackColor = true;
            // 
            // cstControlDataverseTriggers
            // 
            this.cstControlDataverseTriggers.ConnectionDetail = null;
            this.cstControlDataverseTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cstControlDataverseTriggers.Location = new System.Drawing.Point(3, 3);
            this.cstControlDataverseTriggers.LstDataVerseTriggers = null;
            this.cstControlDataverseTriggers.Name = "cstControlDataverseTriggers";
            this.cstControlDataverseTriggers.PluginIcon = null;
            this.cstControlDataverseTriggers.Size = new System.Drawing.Size(2327, 799);
            this.cstControlDataverseTriggers.TabIcon = null;
            this.cstControlDataverseTriggers.TabIndex = 0;
            this.cstControlDataverseTriggers.ToolName = null;
            this.cstControlDataverseTriggers.OnProcessSelected += new Extensions.BaseControl.ProcessSelected(this.CstControlDataverseTriggers_OnProcessSelected);
            // 
            // tabScheduled
            // 
            this.tabScheduled.Controls.Add(this.cstControlRecurrencyTriggers);
            this.tabScheduled.Location = new System.Drawing.Point(4, 29);
            this.tabScheduled.Name = "tabScheduled";
            this.tabScheduled.Padding = new System.Windows.Forms.Padding(3);
            this.tabScheduled.Size = new System.Drawing.Size(2333, 805);
            this.tabScheduled.TabIndex = 1;
            this.tabScheduled.Text = "Scheduled";
            this.tabScheduled.UseVisualStyleBackColor = true;
            // 
            // cstControlRecurrencyTriggers
            // 
            this.cstControlRecurrencyTriggers.ConnectionDetail = null;
            this.cstControlRecurrencyTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cstControlRecurrencyTriggers.Location = new System.Drawing.Point(3, 3);
            this.cstControlRecurrencyTriggers.LstScheduledCloudFlows = null;
            this.cstControlRecurrencyTriggers.Name = "cstControlRecurrencyTriggers";
            this.cstControlRecurrencyTriggers.PluginIcon = null;
            this.cstControlRecurrencyTriggers.Size = new System.Drawing.Size(2327, 799);
            this.cstControlRecurrencyTriggers.TabIcon = null;
            this.cstControlRecurrencyTriggers.TabIndex = 0;
            this.cstControlRecurrencyTriggers.ToolName = null;
            this.cstControlRecurrencyTriggers.OnProcessSelected += new Extensions.BaseControl.ProcessSelected(this.CstControlDataverseTriggers_OnProcessSelected);
            // 
            // tabManual
            // 
            this.tabManual.Controls.Add(this.cstManualTrigger);
            this.tabManual.Location = new System.Drawing.Point(4, 29);
            this.tabManual.Name = "tabManual";
            this.tabManual.Padding = new System.Windows.Forms.Padding(3);
            this.tabManual.Size = new System.Drawing.Size(2333, 805);
            this.tabManual.TabIndex = 4;
            this.tabManual.Text = "Manual";
            this.tabManual.UseVisualStyleBackColor = true;
            // 
            // cstManualTrigger
            // 
            this.cstManualTrigger.ConnectionDetail = null;
            this.cstManualTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cstManualTrigger.Location = new System.Drawing.Point(3, 3);
            this.cstManualTrigger.LstScheduledCloudFlows = null;
            this.cstManualTrigger.Name = "cstManualTrigger";
            this.cstManualTrigger.PluginIcon = null;
            this.cstManualTrigger.Size = new System.Drawing.Size(2327, 799);
            this.cstManualTrigger.TabIcon = null;
            this.cstManualTrigger.TabIndex = 0;
            this.cstManualTrigger.ToolName = null;
            this.cstManualTrigger.OnProcessSelected += new Extensions.BaseControl.ProcessSelected(this.CstControlDataverseTriggers_OnProcessSelected);
            // 
            // tabWorkflows
            // 
            this.tabWorkflows.Controls.Add(this.cstControlWorkflowsTriggers);
            this.tabWorkflows.Location = new System.Drawing.Point(4, 29);
            this.tabWorkflows.Name = "tabWorkflows";
            this.tabWorkflows.Size = new System.Drawing.Size(2333, 805);
            this.tabWorkflows.TabIndex = 2;
            this.tabWorkflows.Text = "Workflows";
            this.tabWorkflows.UseVisualStyleBackColor = true;
            // 
            // cstControlWorkflowsTriggers
            // 
            this.cstControlWorkflowsTriggers.ConnectionDetail = null;
            this.cstControlWorkflowsTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cstControlWorkflowsTriggers.Location = new System.Drawing.Point(0, 0);
            this.cstControlWorkflowsTriggers.LsClassicWorkflows = null;
            this.cstControlWorkflowsTriggers.Name = "cstControlWorkflowsTriggers";
            this.cstControlWorkflowsTriggers.PluginIcon = null;
            this.cstControlWorkflowsTriggers.Service = null;
            this.cstControlWorkflowsTriggers.Size = new System.Drawing.Size(2333, 805);
            this.cstControlWorkflowsTriggers.SolutionId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cstControlWorkflowsTriggers.TabIcon = null;
            this.cstControlWorkflowsTriggers.TabIndex = 0;
            this.cstControlWorkflowsTriggers.ToolName = null;
            this.cstControlWorkflowsTriggers.OnProcessSelected += new Extensions.BaseControl.ProcessSelected(this.CstControlDataverseTriggers_OnProcessSelected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cstPluginTriggers1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2333, 805);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Plugins";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cstPluginTriggers1
            // 
            this.cstPluginTriggers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cstPluginTriggers1.Location = new System.Drawing.Point(3, 3);
            this.cstPluginTriggers1.LstPlugins = null;
            this.cstPluginTriggers1.Name = "cstPluginTriggers1";
            this.cstPluginTriggers1.Service = null;
            this.cstPluginTriggers1.Size = new System.Drawing.Size(2327, 799);
            this.cstPluginTriggers1.SolutionId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cstPluginTriggers1.TabIndex = 0;
            // 
            // DataVerseTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFlows);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DataVerseTrigger";
            this.Size = new System.Drawing.Size(2341, 872);
            this.ConnectionUpdated += new XrmToolBox.Extensibility.PluginControlBase.ConnectionUpdatedHandler(this.MyPluginControl_ConnectionUpdated);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.pnlFlows.ResumeLayout(false);
            this.tabPlugins.ResumeLayout(false);
            this.tabDataVerseTriggers.ResumeLayout(false);
            this.tabScheduled.ResumeLayout(false);
            this.tabManual.ResumeLayout(false);
            this.tabWorkflows.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Panel pnlFlows;
        private System.Windows.Forms.TabControl tabPlugins;
        private System.Windows.Forms.TabPage tabScheduled;
        private System.Windows.Forms.TabPage tabDataVerseTriggers;
        private Controls.Grids.DataVerseTrigger cstControlDataverseTriggers;
        private ScheduledTrigger cstControlRecurrencyTriggers;
        private System.Windows.Forms.TabPage tabWorkflows;
        private WorkflowTrigger cstControlWorkflowsTriggers;
        private System.Windows.Forms.TabPage tabPage1;
        private PluginTriggers cstPluginTriggers1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbBrowser;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbProfile;
        private System.Windows.Forms.ToolStripLabel lblSolution;
        private System.Windows.Forms.ToolStripComboBox cmbListSolutions;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDownloadExcel;
        private System.Windows.Forms.ToolStripLabel lblYouMustConnect;
        private System.Windows.Forms.TabPage tabManual;
        private Controls.Grids.ManualTriggerCloudFlows cstManualTrigger;
    }
}
