using System.Configuration;
using Microsoft.Practices.Prism.Modularity;

namespace DevDumps.Pats.Apps.PatsViewer.ModulesConfig
{
    public class ModuleConfigurationStore : IConfigurationStore
    {
        public ModulesConfigurationSection RetrieveModuleConfigurationSection()
        {
            var modulesConfig =
                ConfigurationManager.OpenMappedExeConfiguration(
                    new ExeConfigurationFileMap() {ExeConfigFilename = "modules.xml"},
                    ConfigurationUserLevel.None);
            var modules = (ModulesConfigurationSection) modulesConfig.GetSection("modules");

            return modules;
        }
    }
}
