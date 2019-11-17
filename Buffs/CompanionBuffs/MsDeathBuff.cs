using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class MsDeathBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mistress Death");
			Description.SetDefault("Death will fight for you" + "\n'Your whole life has come to this.'");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("DeathProj")] > 0)
            {
				modPlayer.MsDeathMinion = true;
			}
            if (!modPlayer.MsDeathMinion)
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