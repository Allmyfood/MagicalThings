using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Buffs.CompanionBuffs
{
	public class WindPixieBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Wind Pixie");
			Description.SetDefault("The Wind Pixie will help you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("WindPixieProj")] > 0)
			{
				modPlayer.WindPixieMinion = true;
			}
			if (!modPlayer.WindPixieMinion)
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