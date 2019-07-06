using Terraria;
using Terraria.ModLoader;

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
			player.mount.SetMount(mod.MountType<Mounts.Centaur>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
