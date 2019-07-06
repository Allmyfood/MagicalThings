using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("WaspProj")] > 0)
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