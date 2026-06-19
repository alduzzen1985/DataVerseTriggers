namespace DataVerseTrigger.Controls.Forms
{
    partial class FormTriggerSteps
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
            this.dgvSteps = new System.Windows.Forms.DataGridView();
            this.colActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
            this.SuspendLayout();
            //
            // dgvSteps
            //
            this.dgvSteps.AllowUserToAddRows = false;
            this.dgvSteps.AllowUserToDeleteRows = false;
            this.dgvSteps.AutoGenerateColumns = false;
            this.dgvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSteps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colActionName,
            this.colActionType,
            this.colEntityName,
            this.colDescription});
            this.dgvSteps.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.dgvSteps.Location = new System.Drawing.Point(12, 12);
            this.dgvSteps.MultiSelect = false;
            this.dgvSteps.Name = "dgvSteps";
            this.dgvSteps.ReadOnly = true;
            this.dgvSteps.RowHeadersWidth = 51;
            this.dgvSteps.RowTemplate.Height = 28;
            this.dgvSteps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSteps.Size = new System.Drawing.Size(860, 360);
            this.dgvSteps.TabIndex = 0;
            //
            // colActionName
            //
            this.colActionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colActionName.DataPropertyName = "ActionName";
            this.colActionName.HeaderText = "Step Name";
            this.colActionName.MinimumWidth = 8;
            this.colActionName.Name = "colActionName";
            this.colActionName.ReadOnly = true;
            //
            // colActionType
            //
            this.colActionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colActionType.DataPropertyName = "ActionType";
            this.colActionType.HeaderText = "Action Type";
            this.colActionType.MinimumWidth = 8;
            this.colActionType.Name = "colActionType";
            this.colActionType.ReadOnly = true;
            this.colActionType.Width = 120;
            //
            // colEntityName
            //
            this.colEntityName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEntityName.DataPropertyName = "EntityName";
            this.colEntityName.HeaderText = "Table";
            this.colEntityName.MinimumWidth = 8;
            this.colEntityName.Name = "colEntityName";
            this.colEntityName.ReadOnly = true;
            this.colEntityName.Width = 160;
            //
            // colDescription
            //
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.MinimumWidth = 8;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Right));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(797, 384);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            //
            // FormTriggerSteps
            //
            this.AcceptButton = this.btnClose;
            this.CancelButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 424);
            this.Controls.Add(this.dgvSteps);
            this.Controls.Add(this.btnClose);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FormTriggerSteps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trigger Steps";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvSteps;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.Button btnClose;
    }
}
