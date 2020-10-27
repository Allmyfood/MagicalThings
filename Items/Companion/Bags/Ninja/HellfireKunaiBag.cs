using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Bags.Ninja
{
	public class HellfireKunaiBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellfire Kunai Bag");
			Tooltip.SetDefault("Ingredients from the Hellfire Kunai");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Green;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ItemType<Animus>(), 1);
			player.QuickSpawnItem(ItemID.Spike, 4);
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AntiAnimus", 1);
            recipe.AddIngredient(null, "HellfireKunai", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}