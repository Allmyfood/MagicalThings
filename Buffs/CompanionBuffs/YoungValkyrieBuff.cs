using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class YoungValkyrieBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Young Valkyrie");
			Description.SetDefault("A young Valkyrie will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.YoungValkyrieProj>()] > 0)
			{
				modPlayer.YongValkyrieMinion = true;
			}
			if (!modPlayer.YongValkyrieMinion)
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