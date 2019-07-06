using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class FireRingBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fire Ring");
			Description.SetDefault("A Fire ring will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("FireRingProj")] > 0)
			{
				modPlayer.FireRingMinion = true;
			}
			if (!modPlayer.FireRingMinion)
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