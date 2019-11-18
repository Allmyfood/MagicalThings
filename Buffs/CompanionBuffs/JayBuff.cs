using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class JayBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Blue Jay");
			Description.SetDefault("A Blue Jay will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.JaySpriteProj>()] > 0)
			{
				modPlayer.JaySpriteMinion = true;
			}
			if (!modPlayer.JaySpriteMinion)
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