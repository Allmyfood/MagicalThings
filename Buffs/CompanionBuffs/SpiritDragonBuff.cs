using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class SpiritDragonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Spirit Dragon");
			Description.SetDefault("A baby Spirit Dragon will protect you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.SpiritDragonProj>()] > 0)

            {
				modPlayer.SpiritDragonMinion = true;
			}
            if (!modPlayer.SpiritDragonMinion)
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