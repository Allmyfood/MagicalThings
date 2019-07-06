using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class CardinalBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cardinal");
			Description.SetDefault("A Cardinal will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("CardinalSpriteProj")] > 0)
			{
				modPlayer.CardinalSpriteMinion = true;
			}
			if (!modPlayer.CardinalSpriteMinion)
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