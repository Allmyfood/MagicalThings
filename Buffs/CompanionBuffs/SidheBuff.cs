using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class SidheBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sidhe 'Shee'");
			Description.SetDefault("A mischievous Sidhe will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.CompanionProj.Minions.SidheProj>()] > 0)
			{
				modPlayer.SidheMinion = true;
			}
			if (!modPlayer.SidheMinion)
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