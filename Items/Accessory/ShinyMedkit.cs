using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Accessory
{
	public class ShinyMedkit : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shiny Medkit");
            Tooltip.SetDefault("Summons A Nurse");
        }
        public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.DogWhistle);
			item.shoot = ProjectileType<Projectiles.Pets.MedicProj>();
			item.buffType = mod.BuffType("MedicBuff");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdhesiveBandage, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}