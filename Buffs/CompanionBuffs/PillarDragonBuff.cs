using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class PillarDragonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pillar Dragon");
			Description.SetDefault("A Pillar Dragon will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.PillarDragonProj>()] > 0)

            {
				modPlayer.PillarDragonMinion = true;
			}
            if (!modPlayer.PillarDragonMinion)
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