using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs
{
	public class HeavenlyMount : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Divine Horse");
            Description.SetDefault("An Angelic Horse");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType<Mounts.HeavenHorse>(), player);
			player.buffTime[buffIndex] = 10;
            player.nightVision = true;
		}
	}
}
