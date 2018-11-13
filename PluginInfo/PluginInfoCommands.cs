using Smod2;
using Smod2.Commands;

namespace PluginInfo
{
	class PluginInfo_Version : ICommandHandler
	{ 
		private Plugin plugin;
		public PluginInfo_Version(Plugin plugin)
		{
			this.plugin = plugin;
		}

		public string GetCommandDescription()
		{
			return "Version for this plugin.";
		}

		public string GetUsage()
		{
			return "plugininfo_version";
		}

		public string[] OnCall(ICommandSender sender, string[] args)
		{
			return new string[] { "This is version " + plugin.Details.version };
		}
	}//Return version for debugging purposes.
}
