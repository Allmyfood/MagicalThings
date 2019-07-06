using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Ninja
{
    public class BoneAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Axe");
            Tooltip.SetDefault("A poisoned and corrupted axe");
        }
        public override void SetDefaults()
        {
            item.damage = 45;
            item.thrown = true;
            item.melee = false;
            item.width = 23;
            item.height = 22;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 1;
            item.knockBack = 3.5f;
            item.value = 70;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = 182; //mod.ProjectileType("TaintedStarProj");
            item.shootSpeed = 11.75f;
            item.crit += 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TaintedStar", 1);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.Spike, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}