using Terraria;
using Terraria.ModLoader;

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
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("FlameSkeletonProj")] > 0)
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