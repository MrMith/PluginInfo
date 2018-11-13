using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using System.Linq;

namespace PluginInfo
{
	public class EventLogic : IEventHandlerRoundStart
	{

		private readonly Plugin plugin;
		public EventLogic(Plugin plugin)
		{
			this.plugin = plugin;
		}

		public void OnRoundStart(RoundStartEvent ev)
		{
			string[] hiddenPlugins = plugin.GetConfigList("info_ignoredplugin");
			foreach (Smod2.API.Player playa in Smod2.PluginManager.Manager.Server.GetPlayers())
			{
				foreach (Plugin enabledPlugin in Smod2.PluginManager.Manager.EnabledPlugins)
				{
					if (!hiddenPlugins.Contains(enabledPlugin.Details.name))
					{
						switch (enabledPlugin.Details.name)
						{
							case "SCP-343":
								playa.SendConsoleMessage(enabledPlugin.Details.name + " | Version: " + enabledPlugin.Details.version, "white");
								playa.SendConsoleMessage(enabledPlugin.Details.description, "green");
								playa.SendConsoleMessage("SCP-343 Spawn Chance:" + (int)enabledPlugin.GetConfigFloat("scp343_spawnchance") + "%", "green");
								playa.SendConsoleMessage("Does SCP-343 convert weapons to flashlights:" + enabledPlugin.GetConfigBool("scp343_itemconverttoggle"), "green");
								playa.SendConsoleMessage("Time from round start when SCP-343 can open any door: " + enabledPlugin.GetConfigInt("scp343_opendoortime") + " seconds", "green");
								playa.SendConsoleMessage("-");
								break;
							case "Item Stacks":
								playa.SendConsoleMessage(enabledPlugin.Details.name + " | Version: " + enabledPlugin.Details.version, "white");
								playa.SendConsoleMessage(enabledPlugin.Details.description, "green");
								playa.SendConsoleMessage("Medkit Stack Size:" + enabledPlugin.GetConfigInt("stack_medkitlimit"), "green");
								playa.SendConsoleMessage("Frag Grenade Stack Size:" + enabledPlugin.GetConfigInt("stack_fraglimit"), "green");
								playa.SendConsoleMessage("FlashBang Stack Size:" + enabledPlugin.GetConfigInt("stack_flashlimit"), "green");
								playa.SendConsoleMessage("Coin Stack Size:" + enabledPlugin.GetConfigInt("stack_coinlimit"), "green");
								playa.SendConsoleMessage("-");
								break;
							default:
								playa.SendConsoleMessage(enabledPlugin.Details.name + " | Version: " + enabledPlugin.Details.version, "white");
								playa.SendConsoleMessage(enabledPlugin.Details.description, "green");
								playa.SendConsoleMessage("-");
								break;
						}
					}
				}
			}
		}
	}
}