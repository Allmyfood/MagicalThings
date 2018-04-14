using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ninja
{
    public class TaintedStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A Corrupted Shuriken");
            Tooltip.SetDefault("A poisoned and corrupted shuriken");
        }
        public override void SetDefaults()
        {
            item.damage = 24;
            item.thrown = true;
            item.melee = false;
            item.width = 23;
            item.height = 22;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 1;
            item.knockBack = 3.5f;
            item.value = 50;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TaintedStarProj");
            item.shootSpeed = 11.75f;
            item.crit += 6;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EndlessSlime", 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EndlessSlime", 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}