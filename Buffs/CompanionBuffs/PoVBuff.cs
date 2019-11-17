using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class PoVBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Path of Virtue");
			Description.SetDefault("A holy weapon will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("SwordOfVirtueProj")] > 0)

            {
				modPlayer.VirtueMinion = true;
			}
            if (!modPlayer.VirtueMinion)
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