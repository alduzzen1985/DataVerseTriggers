using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using DataVerseTrigger.Constants;
using DataVerseTrigger.Enums;
using DataVerseTrigger.Helper;
using DataVerseTrigger.Models;
using DataVerseTrigger.Models.CloudFlows;
using McTools.Xrm.Connection;
using Microsoft.Office.Interop.Excel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow.Activities;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using XrmToolBox.Extensibility;



namespace DataVerseTrigger
{
    public partial class DataVerseTrigger : PluginControlBase
    {
        private Settings mySettings;

        private List<DataVerseCloudFlow> lsDataVerseFlows = new List<DataVerseCloudFlow>();
        private List<ScheduledCloudFlow> lsScheduledCloudFlows = new List<ScheduledCloudFlow>();
        private List<ManualCloudFlow> lsManualCloudFlows = new List<ManualCloudFlow>();


        private string _baseFlowUrl;
        private string _baseWorkflowUrl;


        public DataVerseTrigger()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            lblYouMustConnect.Visible = (Service == null);
            if (Service == null) return;
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings, $"{ConnectionDetail.ConnectionId}-{ConnectionDetail.ConnectionName}"))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");

                if (ConnectionDetail == null) return;

                if (ConnectionDetail.BrowserName != BrowserEnum.None)
                {
                    for (var i = 0; i < cbBrowser.Items.Count; i++)
                    {
                        var browser = (Browser)cbBrowser.Items[i];

                        if (browser.Type != ConnectionDetail.BrowserName) { continue; }

                        cbBrowser.SelectedIndex = i;

                        break;
                    }
                }
                else
                {
                    cbBrowser.SelectedIndex = 0;
                }

                if (ConnectionDetail.BrowserProfile != null)
                {
                    for (var i = 0; i < cbProfile.Items.Count; i++)
                    {
                        var browserProfile = (BrowserProfile)cbProfile.Items[i];

                        if (browserProfile.Name != ConnectionDetail.BrowserProfile) { continue; }

                        cbProfile.SelectedIndex = i;

                        break;
                    }
                }
                else
                {
                    cbProfile.SelectedIndex = 0;
                }

                SaveSettings();
            }
            else
            {
                LogInfo("Settings found and loaded");

                if (mySettings.Browser != null && mySettings.BrowserProfile != null)
                {
                    for (var i = 0; i < cbBrowser.Items.Count; i++)
                    {
                        var browser = (Browser)cbBrowser.Items[i];

                        if (browser.Type != mySettings.Browser.Type) { continue; }

                        cbBrowser.SelectedIndex = i;

                        break;
                    }
                }
                else
                {
                    cbBrowser.SelectedIndex = 0;
                }
            }
        }



        private void CstControlDataverseTriggers_OnProcessSelected(Guid processSelected, ProcessType processType)
        {
            string url = "";

            if (processType == ProcessType.CloudFlow)
            {
                //$"https://make.powerautomate.com/environments/{ConnectionDetail.EnvironmentId}/solutions/{solutionId}/flows/{cmn.Workflowuniqueid}/details";
                url = $"https://make.powerautomate.com/environments/{ConnectionDetail.GetCrmServiceClient().EnvironmentId}/solutions/{cstPluginTriggers1.SolutionId}/flows/{processSelected}/details";
            }
            else if (processType == ProcessType.Workflow)
            {
                url = $"{ConnectionDetail.OriginalUrl}/sfa/workflow/edit.aspx?id=%7b{processSelected}%7d";
            }


            var process = new Process();

            process.StartInfo = new ProcessStartInfo(mySettings.Browser.Executable)
            {
                Arguments = url
            };

            switch (mySettings.Browser.Type)
            {
                case BrowserEnum.Chrome:
                case BrowserEnum.Edge:
                    process.StartInfo.Arguments += $" --profile-directory=\"{mySettings.BrowserProfile.Path}\"";
                    break;
                case BrowserEnum.Firefox:
                    process.StartInfo.Arguments += $" -P \"{mySettings.BrowserProfile.Path}\"";
                    break;
            }




            process.Start();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }




        private void GetSolutions()
        {

            if (Service is null)
            {
                MessageBox.Show("You need to connect to an environment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var query = new QueryExpression("solution")
            {
                ColumnSet = new ColumnSet("friendlyname",
               "uniquename",
               "solutionid"
               ),
            };
            query.AddOrder("friendlyname", OrderType.Ascending);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Solutions",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(query);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {

                        var solutions = result.Entities.Select(x =>
                           new SolutionItem
                           {
                               SolutionId = (Guid)x["solutionid"],
                               Name = $"{x["friendlyname"]} ({x["uniquename"]})"
                           }).ToArray();


                        cmbListSolutions.Items.AddRange(solutions);




                        //cmbListSolutions.DataSource = solutions;
                        //cmbListSolutions.DisplayMember = "displayName";
                        //cmbListSolutions.ValueMember = "solutionId";
                    }
                }
            });
        }


        private void GetTables()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Tables",
                Work = (worker, args) =>
                {
                    args.Result = MetaDataHelper.GetListEntities(Service);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityMetadata[];
                    if (result != null)
                    {

                        List<PowerAppsTable> tables = result.Where(x => x.DisplayName != null && x.DisplayName.UserLocalizedLabel != null).OrderBy(x => x.DisplayName.UserLocalizedLabel.Label).Select(x => new PowerAppsTable()
                        {
                            LogicalName = x.LogicalName,
                            ObjectTypeCode = x.ObjectTypeCode,
                            DisplayName = $"{x.DisplayName.UserLocalizedLabel.Label} ({x.LogicalName})",
                            Name = x.DisplayName.UserLocalizedLabel.Label
                        }).ToList();

                        tables.Insert(0, new PowerAppsTable() { DisplayName = "-", LogicalName = "-", Name = "-" });


                        PowerAppsTable[] tb = tables.ToArray();

                        cstControlDataverseTriggers.PowerAppsTables = tb;
                        cstControlWorkflowsTriggers.PowerAppsTables = tb;
                        cstPluginTriggers1.PowerAppsTables = tb;
                    }
                }
            });

        }


        private void GetPluginMessages()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Plugin Messages",
                Work = (worker, args) =>
                {
                    args.Result = PluginHelper.GetCRUDPluginMessages(this.Service);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    EntityCollection result = args.Result as EntityCollection;
                    if (result != null)
                    {

                        BindingItem[] messages = result.Entities.Select(x => new BindingItem
                        {
                            Description = x.GetAttributeValue<string>("name"),
                            Value = x.GetAttributeValue<Guid>("sdkmessageid").ToString(),
                        }).ToArray();

                        cstPluginTriggers1.PluginMessages = messages;
                    }
                }
            });

        }



        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SaveSettings();
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings == null || detail == null)
            {
                return;
            }


            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }



        private void ConfigureBaseValues(CommonAutomation cmn, Entity cloudFlow)
        {
            

            cmn.Name = (string)cloudFlow.GetAttributeValue<AliasedValue>("workflow.name").Value;
            cmn.Workflowid = (Guid)cloudFlow.GetAttributeValue<AliasedValue>("workflow.workflowid")
                .Value;
            cmn.Workflowuniqueid = (Guid)cloudFlow
                .GetAttributeValue<AliasedValue>("workflow.workflowidunique").Value;
            cmn.Status = ((OptionSetValue)cloudFlow
                .GetAttributeValue<AliasedValue>("workflow.statuscode").Value).Value;
            cmn.StatusName = cloudFlow.FormattedValues["workflow.statuscode"];

         
            
        }

        private void cmbListSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListSolutions.SelectedIndex < 0) return;

            Guid solutionId = ((SolutionItem)cmbListSolutions.SelectedItem).SolutionId;

            var infoPanel = InformationPanel.GetInformationPanel(this, "Getting Cloud Flows", 340, 150);

            lsDataVerseFlows.Clear();
            lsManualCloudFlows.Clear();
            lsScheduledCloudFlows.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Cloud Flows",
                Work = (worker, args) =>
                {
                    TriggerWorker triggerWorker = new TriggerWorker();



                    args.Result = CloudFlowHelper.GetCloudFlows(Service, solutionId);

                    var coll = args.Result as EntityCollection;

                    int nrFlows = coll.Entities.Count;

                    foreach (var cloudFlow in coll.Entities)
                    {
                        JObject jsonCF = JObject.Parse((string)cloudFlow.GetAttributeValue<AliasedValue>("workflow.clientdata").Value);

                        var typeFlow = jsonCF.SelectToken("properties.definition.triggers.*.type");
                        var apiId = jsonCF.SelectToken("properties.definition.triggers.*.inputs.host.apiId");

                        if (typeFlow != null)
                        {




                            switch (typeFlow.Value<string>())
                            {

                                case CloudFlowTypes.OPEN_API_CONNECTION_WEBHOOK:

                                    DataVerseCloudFlow dvCloudFlow = new DataVerseCloudFlow();
                                    ConfigureBaseValues(dvCloudFlow, cloudFlow);


                                    JToken dataverseProperties = jsonCF.SelectToken("properties.definition.triggers.*.inputs.parameters");

                                    dvCloudFlow.Entityname =
                                        dataverseProperties.SelectToken("subscriptionRequest/entityname", false) != null
                                            ? dataverseProperties.SelectToken("subscriptionRequest/entityname", false)
                                                .Value<string>()
                                            : "";
                                    dvCloudFlow.Filterexpression =
                                        dataverseProperties.SelectToken("subscriptionRequest/filterexpression",
                                            false) != null
                                            ? dataverseProperties.SelectToken("subscriptionRequest/filterexpression")
                                                .Value<string>()
                                            : "";
                                    dvCloudFlow.Filteringattributes =
                                        dataverseProperties.SelectToken("subscriptionRequest/filteringattributes",
                                            false) != null
                                            ? dataverseProperties
                                                .SelectToken("subscriptionRequest/filteringattributes", false)
                                                .Value<string>()
                                            : "";
                                    dvCloudFlow.Message =
                                        dataverseProperties.SelectToken("subscriptionRequest/message", false) != null
                                            ? (MessageType)dataverseProperties
                                                .SelectToken("subscriptionRequest/message").Value<int>()
                                            : MessageType.NULL;
                                    dvCloudFlow.Runas =
                                        dataverseProperties.SelectToken("subscriptionRequest/runas", false) != null
                                            ? (RunAs)dataverseProperties.SelectToken("subscriptionRequest/runas")
                                                .Value<int>()
                                            : RunAs.NULL;
                                    dvCloudFlow.Scope =
                                        dataverseProperties.SelectToken("subscriptionRequest/scope", false) != null
                                            ? (Scope)dataverseProperties.SelectToken("subscriptionRequest/scope")
                                                .Value<int>()
                                            : Scope.NULL;

                                    lsDataVerseFlows.Add(dvCloudFlow);

                                    break;


                                case CloudFlowTypes.RECURRENCE:

                                    JToken recurrecyProperties = jsonCF.SelectToken("properties.definition.triggers.Recurrence.recurrence");

                                    ScheduledCloudFlow scheduledCloudFlow = new ScheduledCloudFlow();
                                    ConfigureBaseValues(scheduledCloudFlow, cloudFlow);


                                    if (recurrecyProperties != null)
                                    {
                                        scheduledCloudFlow.Frequency = recurrecyProperties.SelectToken("frequency", false).Value<string>();
                                        scheduledCloudFlow.Interval = recurrecyProperties.SelectToken("interval", false).Value<int>();

                                        if (recurrecyProperties.SelectToken("timeZone", false) != null)
                                        {
                                            scheduledCloudFlow.TimeZone = recurrecyProperties.SelectToken("timeZone", false).Value<string>();
                                        }


                                        if (recurrecyProperties.SelectTokens("schedule.weekDays[*]", false) != null)
                                        {
                                            scheduledCloudFlow.WeekDays = recurrecyProperties.SelectTokens("schedule.weekDays[*]", false).Values<string>().ToArray();
                                        }


                                        if (recurrecyProperties.SelectTokens("schedule.hours[*]", false) != null)
                                        {
                                            scheduledCloudFlow.Hours = recurrecyProperties.SelectTokens("schedule.hours[*]", false).Values<int>().ToArray();
                                        }

                                        if (recurrecyProperties.SelectTokens("schedule.minutes[*]", false) != null)
                                        {
                                            scheduledCloudFlow.Minutes = recurrecyProperties.SelectTokens("schedule.minutes[*]", false).Values<int>().ToArray();
                                        }


                                        if (recurrecyProperties.SelectToken("startTime", false) != null)
                                        {

                                            scheduledCloudFlow.StartTime = recurrecyProperties.SelectToken("startTime", false).Value<DateTime>();
                                        }
                                    }



                                    lsScheduledCloudFlows.Add(scheduledCloudFlow);


                                    break;
                                case CloudFlowTypes.REQUEST:
                                    string kind = (string)jsonCF.SelectToken("properties.definition.triggers.manual.kind");

                                    if (kind == CloudFlowKind.POWERAPPSV2 || kind == CloudFlowKind.BUTTON)
                                    {
                                        ManualCloudFlow manualFlow = new ManualCloudFlow();

                                        ConfigureBaseValues(manualFlow, cloudFlow);

                                        JToken[] inputProperties = jsonCF.SelectTokens("properties.definition.triggers.*.inputs.schema.properties.*").ToArray();
                                        string[] mandatoryFields = jsonCF.SelectTokens("properties.definition.triggers.*.inputs.schema.required").Values<string>().ToArray();
                                        CloudFlowInputs[] inputs = new CloudFlowInputs[inputProperties.Length];

                                        for (int i = 0; i < inputProperties.Length; i++)
                                        {
                                            inputs[i] = new CloudFlowInputs();
                                            inputs[i].Title = inputProperties[i].SelectToken("title", false).Value<string>();
                                            inputs[i].Description = inputProperties[i].SelectToken("title", false).Value<string>();
                                            inputs[i].Content = inputProperties[i].SelectToken("x-ms-content-hint", false).Value<string>();
                                            string prop = inputProperties[i].Path.Split('.').Last();
                                            inputs[i].Mandatory = mandatoryFields.Contains(prop);
                                        }

                                        manualFlow.Inputs = inputs;
                                        manualFlow.Kind = kind;
                                        lsManualCloudFlows.Add(manualFlow);
                                    }

                                    break;
                            }

                        }



                    }



                    InformationPanel.ChangeInformationPanelMessage(infoPanel, "Getting Workflows");



                },
                PostWorkCallBack = (args) =>
                {
                    if (this.Controls.Contains(infoPanel))
                    {
                        Controls.Remove(infoPanel);
                        infoPanel.Dispose();
                    }



                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cstControlDataverseTriggers.Service = this.Service;
                        cstControlDataverseTriggers.LstDataVerseTriggers = lsDataVerseFlows;
                        cstControlDataverseTriggers.RefreshGrid();

                        cstManualTrigger.Service = this.Service;
                        cstManualTrigger.LstScheduledCloudFlows = lsManualCloudFlows;
                        cstManualTrigger.RefreshGrid();


                        cstControlRecurrencyTriggers.Service = this.Service;
                        cstControlRecurrencyTriggers.LstScheduledCloudFlows = lsScheduledCloudFlows;
                        cstControlRecurrencyTriggers.RefreshGrid();

                        cstControlWorkflowsTriggers.SolutionId = solutionId;
                        cstControlWorkflowsTriggers.Service = this.Service;
                        cstControlWorkflowsTriggers.RefreshGrid();

                        cstPluginTriggers1.SolutionId = solutionId;
                        cstPluginTriggers1.Service = this.Service;
                        cstPluginTriggers1.RefreshGrid();

                    }

                }
            });





        }

        private void MyPluginControl_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            lblYouMustConnect.Visible = (Service == null);
            if (Service == null) return;


            var browsers = BrowserLoader.GetBrowsers();
            cbBrowser.Items.AddRange(browsers.ToArray());


            string env = ConnectionDetail.EnvironmentId;


            LoadPlugin();


        }


        private void LoadPlugin()
        {
            ExecuteMethod(GetSolutions);
            ExecuteMethod(GetTables);
            ExecuteMethod(GetPluginMessages);

            cstPluginTriggers1.Service = this.Service;
            cstControlWorkflowsTriggers.Service = this.Service;
            cstControlDataverseTriggers.Service = this.Service;
        }



        private void cbBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBrowser = (Browser)cbBrowser.SelectedItem;

            if (selectedBrowser == null)
            {
                return;
            }

            mySettings.Browser = selectedBrowser;

            cbProfile.Items.Clear();
            cbProfile.Items.AddRange(selectedBrowser.Profiles.ToArray());

            var profileIndex = selectedBrowser.Profiles.FindIndex(bp => bp.Path.Equals(mySettings.BrowserProfile?.Path));

            cbProfile.SelectedIndex = profileIndex == -1 ? 0 : profileIndex;




            SaveSettings();
        }


        private void cbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBrowserProfile = (BrowserProfile)cbProfile.SelectedItem;

            if (selectedBrowserProfile == null)
            {
                return;
            }

            mySettings.BrowserProfile = selectedBrowserProfile;

            SaveSettings();
        }

        public void SaveSettings()
        {
            SettingsManager.Instance.Save(GetType(), mySettings, $"{ConnectionDetail.ConnectionId}-{ConnectionDetail.ConnectionName}");
        }

        private void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            if (Service != null)
            {
                ExportToExcel();
            }
            else
            {
                MessageBox.Show("You're not connected!", "Not connected");
            }
        }

        public void ExportToExcel()
        {
            var saveFileDialog = new SaveFileDialog();
            var filter = "Excel file (*.xlsx)|*.xlsx| All Files (*.*)|*.*";
            saveFileDialog.Filter = filter;
            saveFileDialog.Title = @"Export as Excel file";

            var filenName = $"Triggers-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            saveFileDialog.FileName = filenName;

            if (saveFileDialog.ShowDialog() != DialogResult.OK) { return; }

            WorkAsync(new WorkAsyncInfo("Creating Excel file...",
               (eventargs) =>
               {
                   var excel = new Microsoft.Office.Interop.Excel.Application();
                   var wb = excel.Workbooks.Add();

                   //GetWorkSheetWorkflowsAndAttributes((Worksheet)wb.Sheets.Add());
                   //GetWorkSheetDataVerseFlowsAttributes((Worksheet)wb.Sheets.Add());

                   GetWorkSheetPlugins((Worksheet)wb.Sheets.Add());
                   GetWorkSheetWorkflows((Worksheet)wb.Sheets.Add());
                   GetWorkSheetRecurringFlows((Worksheet)wb.Sheets.Add());
                   GetWorkSheetDataVerseFlows((Worksheet)wb.Sheets.Add());

                   excel.DisplayAlerts = false;
                   wb.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                   wb.Close(true);
                   excel.Quit();
               })
            {
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        var result = MessageBox.Show(
                            "Do you you want to open exported Excel file?",
                            "Export Completed",
                            MessageBoxButtons.YesNo);

                        if (result == DialogResult.No) { return; }

                        Process.Start(saveFileDialog.FileName);
                    }
                }
            });
        }



        private Worksheet GetWorkSheetDataVerseFlows(Worksheet sh)
        {
            sh.Name = "DataVerse Flows";
            sh.Cells[1, 1] = "Id";
            sh.Cells[1, 2] = "Flow Name";
            sh.Cells[1, 3] = "Status";
            sh.Cells[1, 4] = "Table";
            sh.Cells[1, 5] = "Message/Operation";
            sh.Cells[1, 6] = "Filtering attributes";
            sh.Cells[1, 7] = "Filter Expression";
            sh.Cells[1, 8] = "Scope";
            sh.Cells[1, 9] = "Postpone until";


            for (var index = 0; index < lsDataVerseFlows.Count; index++)
            {
                var row = (DataVerseCloudFlow)lsDataVerseFlows[index];

                sh.Cells[index + 2, "A"] = row.Workflowid.ToString();
                sh.Cells[index + 2, "B"] = row.Name;
                sh.Cells[index + 2, "C"] = row.StatusName;
                sh.Cells[index + 2, "D"] = row.Entityname;
                sh.Cells[index + 2, "E"] = row.Message.ToString();
                sh.Cells[index + 2, "F"] = row.Filteringattributes;
                sh.Cells[index + 2, "G"] = row.Filterexpression;
                sh.Cells[index + 2, "H"] = row.Scope.ToString();
                sh.Cells[index + 2, "I"] = row.Postponeuntil;


                // Add hyperlink to the cell containing the URL
                //var cell = (Range)sh.Cells[index + 2, "F"];
                //sh.Hyperlinks.Add(cell, row.Url);
            }

            var statusColumn = sh.Range["C2:C" + (lsDataVerseFlows.Count + 1)];
            var successCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Activated\""
            );

            successCondition.Interior.Color = ColorTranslator.ToOle(Color.Green);
            successCondition.Font.Bold = true;

            var failureCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Draft\""
            );

            failureCondition.Interior.Color = ColorTranslator.ToOle(Color.Orange);
            failureCondition.Font.Bold = true;

            var range = sh.Range["A1", $"I{lsDataVerseFlows.Count + 1}"];
            FormatAsTable(range, "Table1", "TableStyleMedium15");

            range.Columns.AutoFit();

            return sh;
        }


        private Worksheet GetWorkSheetWorkflows(Worksheet sh)
        {
            sh.Name = "Workflows";
            sh.Cells[1, 1] = "Id";
            sh.Cells[1, 2] = "Name";
            sh.Cells[1, 3] = "Status";
            sh.Cells[1, 4] = "Table";
            sh.Cells[1, 5] = "Mode";
            sh.Cells[1, 6] = "Scope";
            sh.Cells[1, 7] = "Child Process";
            sh.Cells[1, 8] = "On Create";
            sh.Cells[1, 9] = "On Assign";
            sh.Cells[1, 10] = "On Delete";
            sh.Cells[1, 11] = "On Change Status";
            sh.Cells[1, 12] = "On Update";
            sh.Cells[1, 13] = "On Update Attribute List";


            for (var index = 0; index < cstControlWorkflowsTriggers.LsClassicWorkflows.Count; index++)
            {
                var row = (ClassicWorkflow)cstControlWorkflowsTriggers.LsClassicWorkflows[index];

                sh.Cells[index + 2, "A"] = row.Workflowid.ToString();
                sh.Cells[index + 2, "B"] = row.Name;
                sh.Cells[index + 2, "C"] = row.StatusName;
                sh.Cells[index + 2, "D"] = row.Primaryentityname;
                sh.Cells[index + 2, "E"] = row.Mode.ToString();
                sh.Cells[index + 2, "F"] = row.ScopeName;
                sh.Cells[index + 2, "G"] = row.AsChildProcess.ToString();
                sh.Cells[index + 2, "H"] = row.TriggerOnCreate.ToString();
                sh.Cells[index + 2, "I"] = row.TriggerOnAssign.ToString();
                sh.Cells[index + 2, "J"] = row.TriggerOnDelete.ToString();
                sh.Cells[index + 2, "K"] = row.TriggerOnStatusChange.ToString();
                sh.Cells[index + 2, "L"] = row.TriggerOnUpdate.ToString();
                sh.Cells[index + 2, "M"] = row.TriggerOnUpdateAttributeList;


                // Add hyperlink to the cell containing the URL
                //var cell = (Range)sh.Cells[index + 2, "F"];
                //sh.Hyperlinks.Add(cell, row.Url);
            }

            var statusColumn = sh.Range["C2:C" + (cstControlWorkflowsTriggers.LsClassicWorkflows.Count + 1)];
            var successCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Activated\""
            );

            successCondition.Interior.Color = ColorTranslator.ToOle(Color.Green);
            successCondition.Font.Bold = true;

            var failureCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Draft\""
            );

            failureCondition.Interior.Color = ColorTranslator.ToOle(Color.Orange);
            failureCondition.Font.Bold = true;

            var range = sh.Range["A1", $"M{cstControlWorkflowsTriggers.LsClassicWorkflows.Count + 1}"];
            FormatAsTable(range, "TableWorkflows", "TableStyleMedium15");

            range.Columns.AutoFit();

            return sh;
        }


        private Worksheet GetWorkSheetPlugins(Worksheet sh)
        {
            sh.Name = "Plugins";
            sh.Cells[1, 1] = "Plugin Step Name";
            sh.Cells[1, 2] = "Status";
            sh.Cells[1, 3] = "Table";
            sh.Cells[1, 4] = "Message";
            sh.Cells[1, 5] = "Execution Mode";
            sh.Cells[1, 6] = "Stage Number";
            sh.Cells[1, 7] = "Stage Name";
            sh.Cells[1, 8] = "Filtering attributes";



            for (var index = 0; index < cstPluginTriggers1.LstPlugins.Length; index++)
            {
                var row = (Plugin)cstPluginTriggers1.LstPlugins[index];

                sh.Cells[index + 2, "A"] = row.Name;
                sh.Cells[index + 2, "B"] = row.ComponentStateName;
                sh.Cells[index + 2, "C"] = row.PrimaryObjectTypeCode;
                sh.Cells[index + 2, "D"] = row.SdkMessageIdName;
                sh.Cells[index + 2, "E"] = row.ModeName;
                sh.Cells[index + 2, "F"] = row.Stage;
                sh.Cells[index + 2, "G"] = row.StageName;
                sh.Cells[index + 2, "H"] = row.FilteringAttributes;


                // Add hyperlink to the cell containing the URL
                //var cell = (Range)sh.Cells[index + 2, "F"];
                //sh.Hyperlinks.Add(cell, row.Url);
            }

            var statusColumn = sh.Range["C2:C" + (cstPluginTriggers1.LstPlugins.Length + 1)];
            var successCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Activated\""
            );

            successCondition.Interior.Color = ColorTranslator.ToOle(Color.Green);
            successCondition.Font.Bold = true;

            var failureCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlNotEqual,
                $"=$C2=\"Published\""
            );

            failureCondition.Interior.Color = ColorTranslator.ToOle(Color.Orange);
            failureCondition.Font.Bold = true;

            var range = sh.Range["A1", $"H{cstPluginTriggers1.LstPlugins.Length + 1}"];
            FormatAsTable(range, "TableWorkflows", "TableStyleMedium15");

            range.Columns.AutoFit();

            return sh;
        }



        private Worksheet GetWorkSheetWorkflowsAndAttributes(Worksheet sh)
        {
            sh.Name = "Workflow On Upd.";
            sh.Cells[1, 1] = "Id";
            sh.Cells[1, 2] = "Name";
            sh.Cells[1, 3] = "Status";
            sh.Cells[1, 4] = "Table";
            sh.Cells[1, 5] = "On Update Field";


            ClassicWorkflow[] workflowFields = cstControlWorkflowsTriggers.LsClassicWorkflows.Where(x => !string.IsNullOrEmpty(x.TriggerOnUpdateAttributeList)).ToArray();

            int index = 0;

            foreach (ClassicWorkflow row in workflowFields)
            {

                if (string.IsNullOrEmpty(row.TriggerOnUpdateAttributeList)) continue;

                string[] attributes = row.TriggerOnUpdateAttributeList.Split(',');


                foreach (string attr in attributes)
                {
                    sh.Cells[index + 2, "A"] = row.Workflowid.ToString();
                    sh.Cells[index + 2, "B"] = row.Name;
                    sh.Cells[index + 2, "C"] = row.StatusName;
                    sh.Cells[index + 2, "D"] = row.Primaryentityname;
                    sh.Cells[index + 2, "E"] = attr;
                    index++;

                }


                // Add hyperlink to the cell containing the URL
                //var cell = (Range)sh.Cells[index + 2, "F"];
                //sh.Hyperlinks.Add(cell, row.Url);
            }

            var statusColumn = sh.Range["C2:C" + (index + 1)];
            var successCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Activated\""
            );

            successCondition.Interior.Color = ColorTranslator.ToOle(Color.Green);
            successCondition.Font.Bold = true;

            var failureCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Draft\""
            );

            failureCondition.Interior.Color = ColorTranslator.ToOle(Color.Orange);
            failureCondition.Font.Bold = true;

            var range = sh.Range["A1", $"E{index + 1}"];
            FormatAsTable(range, "TableWorkflows", "TableStyleMedium15");

            range.Columns.AutoFit();

            return sh;
        }



        private Worksheet GetWorkSheetDataVerseFlowsAttributes(Worksheet sh)
        {
            sh.Name = "Flow Attributes";
            sh.Cells[1, 1] = "Id";
            sh.Cells[1, 2] = "Flow Name";
            sh.Cells[1, 3] = "Status";
            sh.Cells[1, 4] = "Table";
            sh.Cells[1, 5] = "Message/Operation";
            sh.Cells[1, 6] = "Attribute";
            sh.Cells[1, 7] = "Filter Expression";



            DataVerseCloudFlow[] cloudFlows = lsDataVerseFlows.Where(x => !string.IsNullOrEmpty(x.Filteringattributes)).ToArray();

            int index = 0;

            foreach (DataVerseCloudFlow row in cloudFlows)
            {



                if (string.IsNullOrEmpty(row.Filteringattributes)) continue;


                string[] attributes = row.Filteringattributes.Split(',');

                foreach (string attr in attributes)
                {
                    sh.Cells[index + 2, "A"] = row.Workflowid.ToString();
                    sh.Cells[index + 2, "B"] = row.Name;
                    sh.Cells[index + 2, "C"] = row.StatusName;
                    sh.Cells[index + 2, "D"] = row.Entityname;
                    sh.Cells[index + 2, "E"] = row.Message.ToString();
                    sh.Cells[index + 2, "F"] = attr;
                    sh.Cells[index + 2, "G"] = row.Filterexpression;

                    index++;
                }






                // Add hyperlink to the cell containing the URL
                //var cell = (Range)sh.Cells[index + 2, "F"];
                //sh.Hyperlinks.Add(cell, row.Url);
            }

            var statusColumn = sh.Range["C2:C" + (index + 1)];
            var successCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Activated\""
            );

            successCondition.Interior.Color = ColorTranslator.ToOle(Color.Green);
            successCondition.Font.Bold = true;

            var failureCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Draft\""
            );

            failureCondition.Interior.Color = ColorTranslator.ToOle(Color.Orange);
            failureCondition.Font.Bold = true;

            var range = sh.Range["A1", $"G{index + 1}"];
            FormatAsTable(range, "Table1", "TableStyleMedium15");

            range.Columns.AutoFit();

            return sh;
        }


        private Worksheet GetWorkSheetRecurringFlows(Worksheet sh)
        {
            sh.Name = "Scheduled";
            sh.Cells[1, 1] = "Id";
            sh.Cells[1, 2] = "Flow Name";
            sh.Cells[1, 3] = "Status";
            sh.Cells[1, 4] = "Frequency";
            sh.Cells[1, 5] = "Week Days";
            sh.Cells[1, 6] = "Hours";
            sh.Cells[1, 7] = "Minutes";
            sh.Cells[1, 8] = "Interval";
            sh.Cells[1, 9] = "Start Time";
            sh.Cells[1, 10] = "Time Zone";


            for (var index = 0; index < cstControlRecurrencyTriggers.LstScheduledCloudFlows.Count; index++)
            {
                var row = (ScheduledCloudFlow)cstControlRecurrencyTriggers.LstScheduledCloudFlows[index];

                sh.Cells[index + 2, "A"] = row.Workflowuniqueid.ToString();
                sh.Cells[index + 2, "B"] = row.Name;
                sh.Cells[index + 2, "C"] = row.StatusName;
                sh.Cells[index + 2, "D"] = row.Frequency;
                sh.Cells[index + 2, "E"] = row.WeekDaysDescription;
                sh.Cells[index + 2, "F"] = row.HoursDescription;
                sh.Cells[index + 2, "G"] = row.Interval;
                sh.Cells[index + 2, "H"] = row.StartTime;
                sh.Cells[index + 2, "I"] = row.TimeZone;



                // Add hyperlink to the cell containing the URL
                //var cell = (Range)sh.Cells[index + 2, "F"];
                //sh.Hyperlinks.Add(cell, row.Url);
            }

            var statusColumn = sh.Range["C2:C" + (cstControlRecurrencyTriggers.LstScheduledCloudFlows.Count + 1)];
            var successCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Activated\""
            );

            successCondition.Interior.Color = ColorTranslator.ToOle(Color.Green);
            successCondition.Font.Bold = true;

            var failureCondition = (FormatCondition)statusColumn.FormatConditions.Add(
                XlFormatConditionType.xlExpression,
                XlFormatConditionOperator.xlEqual,
                $"=$C2=\"Draft\""
            );

            failureCondition.Interior.Color = ColorTranslator.ToOle(Color.Orange);
            failureCondition.Font.Bold = true;

            var range = sh.Range["A1", $"I{cstControlRecurrencyTriggers.LstScheduledCloudFlows.Count + 1}"];
            FormatAsTable(range, "TableScheduled", "TableStyleMedium15");

            range.Columns.AutoFit();

            return sh;
        }



        public void FormatAsTable(Range sourceRange, string tableName, string tableStyleName)
        {
            sourceRange.Worksheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange,
                    sourceRange, Type.Missing, XlYesNoGuess.xlYes, Type.Missing).Name =
                tableName;
            sourceRange.Select();
            sourceRange.Worksheet.ListObjects[tableName].TableStyle = tableStyleName;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPlugin();
        }


    }




}
