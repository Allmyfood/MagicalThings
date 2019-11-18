using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs
{
	public class BarnBuff : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Centaur Transformation");
            Description.SetDefault("You have extra legs and move quickly!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<Mounts.Centaur>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
