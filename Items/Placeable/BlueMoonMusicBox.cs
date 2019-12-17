using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Placeable
{
    public class BlueMoonMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Blue Moon - Spirit Mod)");
            Tooltip.SetDefault("Music from Spirit Mod"
                + "\nI did not do this music!"
                + "\nCredits go to the Spirit Mod dev team!");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = mod.TileType("BlueMoonMusicBox");
            item.width = 24;
            item.height = 24;
            item.rare = 4;
            item.value = 100000;
            item.accessory = true;
        }
        //public override void AddRecipes()   //This defines the crafting recepe for this item
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemID.MusicBox, 1);
        //    recipe.AddIngredient(ItemID.Torch, 1);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(this, 1);
        //    recipe.AddRecipe();
        //}
    }
}
