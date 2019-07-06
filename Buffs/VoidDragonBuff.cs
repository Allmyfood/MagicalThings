using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Buffs
{
	public class VoidDragonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Void Dragon");
			Description.SetDefault("The Void Dragon will fight for you.");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("VoidDragon")] > 0)
			{
				modPlayer.VoidDragonMinion = true;
			}
			if (!modPlayer.VoidDragonMinion)
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