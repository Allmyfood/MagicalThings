using Terraria.ID;
using Terraria.ModLoader;


namespace MagicalThings.Items.Placeable
{
    public class SodaMachine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soda Machine");
            Tooltip.SetDefault("Soda Machine");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = mod.TileType("SodaMachineBox");
            item.width = 24;
            item.height = 32;
            item.maxStack = 99;
            item.rare = 4;
            item.value = 100000;
        }
        public override void AddRecipes()   //This defines the crafting recepe for this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
