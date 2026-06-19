using System;
using System.Configuration;
using System.Linq;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace Automation_Analyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbManager = new DatabaseManager("flowindex.db");
            dbManager.InitializeDatabase();

            string arg = "--rebuild";  //args[0];


            // if (args.Length > 0 && (arg == "--rebuild" || arg == "--sync"))
            if ((arg == "--rebuild" || arg == "--sync"))
            {
                var connectionString = ConfigurationManager.AppSettings["DataverseConnectionString"];
                var environmentId    = ConfigurationManager.AppSettings["EnvironmentId"] ?? string.Empty;

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    Console.WriteLine("Error: DataverseConnectionString not configured in App.config.");
                    return;
                }

                Console.WriteLine("Connecting to Dataverse...");
                var serviceClient = new ServiceClient(connectionString);
                if (!serviceClient.IsReady)
                {
                    Console.WriteLine("Error: " + serviceClient.LastError);
                    return;
                }

                var flowRepo     = new FlowRepository(serviceClient);
                var workflowRepo = new WorkflowDataverseRepository(serviceClient);
                var metaRepo     = new MetadataRepository(serviceClient);
                var indexer      = new FlowIndexer(dbManager, flowRepo, workflowRepo, metaRepo);

                if (arg == "--rebuild")
                {
                    Console.WriteLine("Rebuilding full index...");
                    indexer.RebuildIndexAsync(environmentId).Wait();
                }
                else
                {
                    Console.WriteLine("Syncing changed flows...");
                    indexer.SyncChangedFlowsAsync(environmentId).Wait();
                }

                Console.WriteLine("Done.");
                return;
            }

            var queryService = new FlowQueryService(dbManager);

            Console.Write("Enter target automation name (blank = list all dependencies): ");
            var flowName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(flowName))
            {
                var all = queryService.GetAllDependencies();
                if (!all.Any())
                {
                    Console.WriteLine("Index is empty. Run with --rebuild first.");
                    return;
                }
                Console.WriteLine(string.Format("\nAll dependency edges ({0}):\n", all.Count));
                foreach (var d in all)
                    Console.WriteLine(string.Format("  [{0}] {1}{2}  ->  {3}{4}  ({5})",
                        d.Confidence,
                        d.SourceFlowName, d.SourceIsActive ? "" : " [INACTIVE]",
                        d.TargetFlowName, d.TargetIsActive ? "" : " [INACTIVE]",
                        d.MatchReason));
                return;
            }

            var triggers = queryService.GetFlowsThatCanTrigger(flowName);
            if (!triggers.Any())
            {
                Console.WriteLine(string.Format(
                    "No flows found that can trigger '{0}'. (Index may be empty — run with --rebuild.)", flowName));
                return;
            }

            Console.WriteLine(string.Format("\nAutomations that can trigger '{0}'{1}:\n",
                flowName, triggers.Any() && !triggers[0].TargetIsActive ? " [INACTIVE]" : ""));
            foreach (var t in triggers)
                Console.WriteLine(string.Format("  [{0}] {1}{2}  ->  {3}",
                    t.Confidence,
                    t.SourceFlowName, t.SourceIsActive ? "" : " [INACTIVE]",
                    t.MatchReason));

            Console.WriteLine("\nFull trigger chain:");
            var chain = queryService.GetFullTriggerChain(flowName);
            if (chain.Any())
                foreach (var step in chain)
                    Console.WriteLine(string.Format("  -> {0}", step));
            else
                Console.WriteLine("  (no further triggers)");
        }
    }
}
