using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier3
{
    public class SapphireBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sleek sapphire blade");
        }
        public override void SetDefaults()
        {
            item.damage = 12;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 19;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.value = 30;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 6;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Branch", 1);
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddIngredient(ItemID.Sapphire, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}