using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class SlimeBirdBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Slime Bird");
			Description.SetDefault("A Slime Bird will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("SlimeBirdProj")] > 0)
			{
				modPlayer.SlimeBirdMinion = true;
			}
			if (!modPlayer.SlimeBirdMinion)
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