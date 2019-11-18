using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items
{
	public class AntiAnimus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Anti-Animation Scroll");
			Tooltip.SetDefault("Used to revert companion weapons"
                +"\nWill reset any companion weapon"
                +"\nto its original form");
		}
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.rare = 10;
            item.value = Item.buyPrice(copper: 1);
            item.maxStack = 99;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 1);
            recipe.AddIngredient(ItemID.PinkGel, 1);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}