using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs
{
	public class MartianMount : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("MiTV");
            Description.SetDefault("Martian Interstellar Tactical Vehicle");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(MountType<Mounts.MiTV>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
