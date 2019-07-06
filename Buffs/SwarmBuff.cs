using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs
{
	public class SwarmBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("A Swarm of Bees!");
			Description.SetDefault("The Bees will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("SwarmProj")] > 0)
			{
				modPlayer.SwarmMinion = true;
			}
			if (!modPlayer.SwarmMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}