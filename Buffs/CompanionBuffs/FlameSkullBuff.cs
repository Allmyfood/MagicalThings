using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class FlameSkullBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Flame Skeleton");
			Description.SetDefault("A Fire Spirit will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.FlameSkeletonProj>()] > 0)
			{
				modPlayer.FlameSkeletonMinion = true;
			}
			if (!modPlayer.FlameSkeletonMinion)
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