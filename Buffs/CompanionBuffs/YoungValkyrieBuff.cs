using Terraria;
using Terraria.ModLoader;

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
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("YoungValkyrieProj")] > 0)
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