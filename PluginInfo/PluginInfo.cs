using Smod2;
using Smod2.Attributes;

namespace PluginInfo
{
	[PluginDetails(
	author = "Mith",
	name = "PluginInfo",
	description = "Displays information about current plugins active to people in the server through their console.",
	id = "mith.plugininfo",
	version = "1.0.0",
	SmodMajor = 3,
	SmodMinor = 1,
	SmodRevision = 21
	)]
	class PluginInfo : Plugin
	{

		public override void OnDisable()
		{
			this.Info("PluginInfo has been Disabled.");
		}
		
		public override void OnEnable()
		{
			this.Info("PluginInfo has been Enabled.");
		}

		public override void Register()
		{
			this.AddEventHandlers(new EventLogic(this));

			this.AddCommand("plugininfo_version", new PluginInfo_Version(this));

			this.AddConfig(new Smod2.Config.ConfigSetting("info_ignoredplugin", new string[]{ "PluginInfo" }, Smod2.Config.SettingType.LIST, true, "Plugins to hide from being displayed"));
		}
	}
}