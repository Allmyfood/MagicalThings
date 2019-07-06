using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class FreeSpiritBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("A Freed Spirit");
			Description.SetDefault("A Free Spirit will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("FreeSpiritProj")] > 0)
			{
				modPlayer.FreeSpiritMinion = true;
			}
			if (!modPlayer.FreeSpiritMinion)
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