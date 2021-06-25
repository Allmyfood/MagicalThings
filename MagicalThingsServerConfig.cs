using Newtonsoft.Json;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace MagicalThings
{
	[Label("Server Config")]
	public class MagicalThingsServerConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		public static MagicalThingsServerConfig Instance => ModContent.GetInstance<MagicalThingsServerConfig>();

		/// <summary>
		/// If false, disables the hooks required for the Bootslot to work, normal slots only from Magical Things.
		/// </summary>
		[Label("Enable Bootslot")]
		[Tooltip("On : Bootslot is enabled\nOff : Bootslot is disabled\nDefault: On")]
		[ReloadRequired]
		[DefaultValue(true)]
		public bool EnableBootslot;

		[Header("Hint: To go to the client config to adjust Bootslot location, press the '<' arrow in the bottom left")]
		[Label("Hint")]
		[JsonIgnore]
		public bool Hint => true;

		public static bool IsPlayerLocalServerOwner(int whoAmI) {
			if (Main.netMode == NetmodeID.MultiplayerClient) {
				return Netplay.Connection.Socket.GetRemoteAddress().IsLocalHost();
			}

			for (int i = 0; i < Main.maxPlayers; i++) {
				RemoteClient client = Netplay.Clients[i];
				if (client.State == 10 && i == whoAmI && client.Socket.GetRemoteAddress().IsLocalHost()) {
					return true;
				}
			}
			return false;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			if (Main.netMode == NetmodeID.SinglePlayer) return true;
			else if (!IsPlayerLocalServerOwner(whoAmI)) {
				message = "You are not the server owner so you can not change this config";
				return false;
			}
			return base.AcceptClientChanges(pendingConfig, whoAmI, ref message);
		}
	}
}
