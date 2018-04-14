using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class ServantBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Servant");
			Description.SetDefault("A Cthulhu Servant will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("ServantProj")] > 0)
			{
				modPlayer.ServantMinion = true;
			}
			if (!modPlayer.ServantMinion)
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