using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class DoomSpectreBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Doom Spectre");
			Description.SetDefault("A Doom spectre will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.DoomSpectreProj>()] > 0)

            {
				modPlayer.DoomSpectreMinion = true;
			}
            if (!modPlayer.DoomSpectreMinion)
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