using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class PillarDemonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pillar Demon");
			Description.SetDefault("A Pillar Demon will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.PillarDemonProj>()] > 0)

            {
				modPlayer.PillarDemonMinion = true;
			}
            if (!modPlayer.PillarDemonMinion)
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