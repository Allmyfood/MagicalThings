using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class AzureSpinnerBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Azure Spinner");
			Description.SetDefault("An Enchanted Spinner will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("AzureSpinnerProj")] > 0)
			{
				modPlayer.AzureSpinnerMinion = true;
			}
			if (!modPlayer.AzureSpinnerMinion)
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