using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.SwarmProj>()] > 0)
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