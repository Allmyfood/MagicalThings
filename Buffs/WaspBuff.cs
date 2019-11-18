using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Buffs
{
	public class WaspBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("A Swarm of Wasps!");
			Description.SetDefault("The Wasps will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.buffImmune[BuffID.Poisoned] = true;
            MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.WaspProj>()] > 0)
			{
				modPlayer.WaspMinion = true;
			}
			if (!modPlayer.WaspMinion)
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