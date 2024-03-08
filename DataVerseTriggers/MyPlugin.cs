using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace DataVerseTrigger
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Dataverse Triggers"),
        ExportMetadata("Description", "Visualize Table / Manual / Scheduled flows triggers  Workflows & Plugins in your DataVerse"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new DataVerseTrigger();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}