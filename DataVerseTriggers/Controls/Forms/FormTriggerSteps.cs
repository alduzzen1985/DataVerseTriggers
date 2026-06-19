using System.Collections.Generic;
using System.Windows.Forms;
using DataVerseTrigger.Helper.TriggerDB;

namespace DataVerseTrigger.Controls.Forms
{
    public partial class FormTriggerSteps : Form
    {
        public FormTriggerSteps(string sourceName, List<TriggerStepRow> steps)
        {
            InitializeComponent();
            Text = $"Steps in \"{sourceName}\" that may trigger this automation";
            dgvSteps.DataSource = steps;
        }
    }
}
