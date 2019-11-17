using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class PillarDemonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pillar Demon");
			Description.SetDefault("A Pillar Demon will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("PillarDemonProj")] > 0)

            {
				modPlayer.PillarDemonMinion = true;
			}
            if (!modPlayer.PillarDemonMinion)
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