using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior
{
    public class WoodMess : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A bunch of wood stuck together");
        }
        public override void SetDefaults()
        {
            item.damage = 9;
            item.melee = true;
            item.width = 70;
            item.height = 80;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 10;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = -4;
           // item.shoot = mod.ProjectileType("LightBladeShot");
           // item.shootSpeed = 4.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Animus", 1);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.Gel, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}