using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class CrimsonDaggerBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Crimson Dagger");
			Description.SetDefault("An Enchanted Dagger will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("CrimsonDaggerProj")] > 0)
			{
				modPlayer.CrimsonDaggerMinion = true;
			}
			if (!modPlayer.CrimsonDaggerMinion)
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