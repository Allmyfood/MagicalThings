using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Placeable
{
    public class PottedSunflower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potted Sunflower");
            Tooltip.SetDefault("Gives the Happy! buff");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = TileType<Tiles.SunflowerTile>();
            item.width = 16;
            item.height = 28;
            item.maxStack = 99;
            item.rare = 1;
            item.value = Item.sellPrice(silver: 2, copper: 40);
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sunflower, 1);
            recipe.AddIngredient(ItemID.ClayPot, 1);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
