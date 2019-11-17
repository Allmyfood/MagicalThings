using Terraria;
using Terraria.ModLoader;

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
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("PWNCrystalProj")] > 0)
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