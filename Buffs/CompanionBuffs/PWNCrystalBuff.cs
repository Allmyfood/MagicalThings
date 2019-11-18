using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class PWNCrystalBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("PWN Crystal");
			Description.SetDefault("A magic Crystal will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.PWNCrystalProj>()] > 0)
			{
				modPlayer.PWNCrystalMinion = true;
			}
			if (!modPlayer.PWNCrystalMinion)
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