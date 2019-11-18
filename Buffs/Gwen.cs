using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs
{
	public class Gwen : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Guenhwyvar");
			Description.SetDefault("Guenhwyvar will assist you in your fight");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.GwenProj>()] > 0)
			{
				modPlayer.GwenMinion = true;
			}
			if (!modPlayer.GwenMinion)
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