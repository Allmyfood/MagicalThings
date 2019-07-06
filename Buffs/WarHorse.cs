using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs
{
	public class WarHorse : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Horse of War");
            Description.SetDefault("War on Hooves");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType<Mounts.HorseofWar>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
