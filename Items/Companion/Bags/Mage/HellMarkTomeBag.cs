using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Bags.Mage
{
	public class HellMarkTomeBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hell Mark Tome Bag");
			Tooltip.SetDefault("Ingredients from the Hell Mark Tome");
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
			player.QuickSpawnItem(ItemID.MagicMissile, 1);
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AntiAnimus", 1);
            recipe.AddIngredient(null, "HellMarkTome", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}