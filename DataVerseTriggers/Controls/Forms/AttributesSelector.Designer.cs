namespace DataVerseTrigger.Controls.Forms
{
    partial class AttributesSelector
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
            this.pnlAttributes = new System.Windows.Forms.Panel();
            this.lstAttributes = new System.Windows.Forms.ListView();
            this.clmHdrDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmHdrLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTables = new System.Windows.Forms.Panel();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.lblEntityName = new System.Windows.Forms.Label();
            this.pnlSelectAttributes = new System.Windows.Forms.Panel();
            this.lnkSelectAttributes = new System.Windows.Forms.LinkLabel();
            this.pnlAttributes.SuspendLayout();
            this.pnlTables.SuspendLayout();
            this.pnlSelectAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAttributes
            // 
            this.pnlAttributes.Controls.Add(this.lstAttributes);
            this.pnlAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttributes.Location = new System.Drawing.Point(0, 159);
            this.pnlAttributes.Name = "pnlAttributes";
            this.pnlAttributes.Size = new System.Drawing.Size(549, 268);
            this.pnlAttributes.TabIndex = 22;
            // 
            // lstAttributes
            // 
            this.lstAttributes.CheckBoxes = true;
            this.lstAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmHdrDisplayName,
            this.clmHdrLogicalName});
            this.lstAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAttributes.HideSelection = false;
            this.lstAttributes.Location = new System.Drawing.Point(0, 0);
            this.lstAttributes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstAttributes.Name = "lstAttributes";
            this.lstAttributes.Size = new System.Drawing.Size(549, 268);
            this.lstAttributes.TabIndex = 60;
            this.lstAttributes.UseCompatibleStateImageBehavior = false;
            this.lstAttributes.View = System.Windows.Forms.View.Details;
            // 
            // clmHdrDisplayName
            // 
            this.clmHdrDisplayName.Text = "Display Name";
            this.clmHdrDisplayName.Width = 177;
            // 
            // clmHdrLogicalName
            // 
            this.clmHdrLogicalName.Text = "Logical Name";
            this.clmHdrLogicalName.Width = 176;
            // 
            // pnlTables
            // 
            this.pnlTables.Controls.Add(this.cmbTable);
            this.pnlTables.Controls.Add(this.lblEntityName);
            this.pnlTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTables.Location = new System.Drawing.Point(0, 0);
            this.pnlTables.Name = "pnlTables";
            this.pnlTables.Size = new System.Drawing.Size(549, 100);
            this.pnlTables.TabIndex = 21;
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(22, 46);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(382, 28);
            this.cmbTable.TabIndex = 8;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedValueChanged);
            // 
            // lblEntityName
            // 
            this.lblEntityName.AutoSize = true;
            this.lblEntityName.Location = new System.Drawing.Point(18, 16);
            this.lblEntityName.Name = "lblEntityName";
            this.lblEntityName.Size = new System.Drawing.Size(48, 20);
            this.lblEntityName.TabIndex = 7;
            this.lblEntityName.Text = "Table";
            // 
            // pnlSelectAttributes
            // 
            this.pnlSelectAttributes.Controls.Add(this.lnkSelectAttributes);
            this.pnlSelectAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectAttributes.Location = new System.Drawing.Point(0, 100);
            this.pnlSelectAttributes.Name = "pnlSelectAttributes";
            this.pnlSelectAttributes.Size = new System.Drawing.Size(549, 59);
            this.pnlSelectAttributes.TabIndex = 61;
            // 
            // lnkSelectAttributes
            // 
            this.lnkSelectAttributes.AutoSize = true;
            this.lnkSelectAttributes.Location = new System.Drawing.Point(18, 16);
            this.lnkSelectAttributes.Name = "lnkSelectAttributes";
            this.lnkSelectAttributes.Size = new System.Drawing.Size(127, 20);
            this.lnkSelectAttributes.TabIndex = 0;
            this.lnkSelectAttributes.TabStop = true;
            this.lnkSelectAttributes.Text = "Select Attributes";
            this.lnkSelectAttributes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelectAttributes_LinkClicked);
            // 
            // AttributesSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAttributes);
            this.Controls.Add(this.pnlSelectAttributes);
            this.Controls.Add(this.pnlTables);
            this.Name = "AttributesSelector";
            this.Size = new System.Drawing.Size(549, 427);
            this.Load += new System.EventHandler(this.AttributesSelector_Load);
            this.pnlAttributes.ResumeLayout(false);
            this.pnlTables.ResumeLayout(false);
            this.pnlTables.PerformLayout();
            this.pnlSelectAttributes.ResumeLayout(false);
            this.pnlSelectAttributes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAttributes;
        private System.Windows.Forms.ListView lstAttributes;
        private System.Windows.Forms.ColumnHeader clmHdrDisplayName;
        private System.Windows.Forms.ColumnHeader clmHdrLogicalName;
        private System.Windows.Forms.Panel pnlTables;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Label lblEntityName;
        private System.Windows.Forms.Panel pnlSelectAttributes;
        private System.Windows.Forms.LinkLabel lnkSelectAttributes;
    }
}
