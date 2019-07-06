using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Bags.Ninja
{
	public class BurningBloodDaggerBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Blood Dagger Bag");
			Tooltip.SetDefault("Ingredients from the Burning Blood Dagger");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.rare = 2;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(mod.ItemType("Animus"),1);
			player.QuickSpawnItem(ItemID.Spike, 4);
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AntiAnimus", 1);
            recipe.AddIngredient(null, "BurningBloodDagger", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}