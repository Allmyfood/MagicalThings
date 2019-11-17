using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class PillarDragonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pillar Dragon");
			Description.SetDefault("A Pillar Dragon will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("PillarDragonProj")] > 0)

            {
				modPlayer.PillarDragonMinion = true;
			}
            if (!modPlayer.PillarDragonMinion)
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