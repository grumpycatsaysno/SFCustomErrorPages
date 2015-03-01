using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
    /// <summary>
    /// Method that is called by ASP.NET before application start to register custom section and user control to Sitefinity toolbox.
    /// </summary>
    public class Installer
    {
        public static void PreApplicationStart()
        {
            SystemManager.ApplicationStart += SystemManager_ApplicationStart;
        }

         private static void SystemManager_ApplicationStart(object sender, EventArgs e)
         {
             RegisterSectionInBackend("PageControls", "CustomTools");
             RegisterControlInToolbox("PageControls", "CustomTools", "~/NotFoundStatusCodeSetter.ascx", "NotFoundStatusCodeSetter");
         }

         private static void RegisterSectionInBackend(string toolboxName, string sectionName)
         {
             var configManager = ConfigManager.GetManager();
             var config = configManager.GetSection<ToolboxesConfig>();

             var controls = config.Toolboxes[toolboxName];

             var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

             if (section == null)
             {
                 configManager.Provider.SuppressSecurityChecks = true;
                 section = new ToolboxSection(controls.Sections)
                 {
                     Name = sectionName,
                     Title = sectionName,
                     Description = sectionName,
                     ResourceClassId = ""// typeof(PageResources).Name
                 };
                 controls.Sections.Add(section);
                 configManager.SaveSection(config);

                 configManager.Provider.SuppressSecurityChecks = false;
             }
         }

         private static void RegisterControlInToolbox(string toolboxName, string sectionName, string controlType, string controlName)
         {
             var configManager = ConfigManager.GetManager();
             configManager.Provider.SuppressSecurityChecks = true;
             var config = configManager.GetSection<ToolboxesConfig>();

             var controls = config.Toolboxes[toolboxName];
             var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

             if (section != null && !section.Tools.Any<ToolboxItem>(e => e.Name == controlName))
             {
                 var tool = new ToolboxItem(section.Tools)
                 {
                     Name = controlName,
                     Title = controlName,
                     Description = controlName,
                     ControlType = controlType,
                 };
                 section.Tools.Add(tool);

                 configManager.SaveSection(config);
             }

             configManager.Provider.SuppressSecurityChecks = false;
         }
    }
}