using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs
{
	public class PegasusMount : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Pegasus");
            Description.SetDefault("Wooo!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(MountType<Mounts.Pegasus>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
