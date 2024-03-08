namespace DataVerseTrigger.Controls.Forms
{
    partial class FormSelectAttributes
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchAttribute = new System.Windows.Forms.TextBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lstAttributes = new System.Windows.Forms.ListView();
            this.clmHdrDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmHdrLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmHdrType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.linkClear = new System.Windows.Forms.LinkLabel();
            this.pnlSearch.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.linkClear);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.txtSearchAttribute);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(736, 88);
            this.pnlSearch.TabIndex = 57;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(591, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 37);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Logical Name / Display Name";
            // 
            // txtSearchAttribute
            // 
            this.txtSearchAttribute.Location = new System.Drawing.Point(236, 14);
            this.txtSearchAttribute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchAttribute.Name = "txtSearchAttribute";
            this.txtSearchAttribute.Size = new System.Drawing.Size(330, 26);
            this.txtSearchAttribute.TabIndex = 4;
            this.txtSearchAttribute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchAttribute_KeyPress);
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnConfirm);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 680);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(736, 71);
            this.pnlActions.TabIndex = 60;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(591, 19);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(117, 40);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.lstAttributes);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 88);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(736, 592);
            this.pnlGrid.TabIndex = 62;
            // 
            // lstAttributes
            // 
            this.lstAttributes.CheckBoxes = true;
            this.lstAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmHdrDisplayName,
            this.clmHdrLogicalName,
            this.clmHdrType});
            this.lstAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAttributes.HideSelection = false;
            this.lstAttributes.Location = new System.Drawing.Point(0, 0);
            this.lstAttributes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstAttributes.Name = "lstAttributes";
            this.lstAttributes.Size = new System.Drawing.Size(736, 592);
            this.lstAttributes.TabIndex = 59;
            this.lstAttributes.UseCompatibleStateImageBehavior = false;
            this.lstAttributes.View = System.Windows.Forms.View.Details;
            // 
            // clmHdrDisplayName
            // 
            this.clmHdrDisplayName.Text = "Display Name";
            this.clmHdrDisplayName.Width = 163;
            // 
            // clmHdrLogicalName
            // 
            this.clmHdrLogicalName.Text = "Logical Name";
            this.clmHdrLogicalName.Width = 176;
            // 
            // clmHdrType
            // 
            this.clmHdrType.Text = "Data Type";
            this.clmHdrType.Width = 139;
            // 
            // linkClear
            // 
            this.linkClear.AutoSize = true;
            this.linkClear.Location = new System.Drawing.Point(13, 63);
            this.linkClear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkClear.Name = "linkClear";
            this.linkClear.Size = new System.Drawing.Size(113, 20);
            this.linkClear.TabIndex = 8;
            this.linkClear.TabStop = true;
            this.linkClear.Text = "Clear Selected";
            this.linkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClear_LinkClicked);
            // 
            // FormSelectAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 751);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlSearch);
            this.Name = "FormSelectAttributes";
            this.Text = "FormSelectAttributes";
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchAttribute;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ListView lstAttributes;
        private System.Windows.Forms.ColumnHeader clmHdrDisplayName;
        private System.Windows.Forms.ColumnHeader clmHdrLogicalName;
        private System.Windows.Forms.ColumnHeader clmHdrType;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.LinkLabel linkClear;
    }
}