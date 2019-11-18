using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class PoEBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Path of Evil");
			Description.SetDefault("Malevolent weapons will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.ShadowHammerProj>()] > 0)

            {
				modPlayer.ShadowHammerMinion = true;
			}
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.BloodAxeProj>()] > 0)

            {
                modPlayer.BloodAxeMinion = true;
            }
            if (!modPlayer.ShadowHammerMinion && !modPlayer.BloodAxeMinion)
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