using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Bombs
{
    public class SandBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Sandify with Explosions!"
                + "\nWill change Dirt to Sand at the surface layer" + "\nExplodes in a 60 tile radius" + "\nCaution Will collapse suspended dirt!");
        }
        public override void SetDefaults()
        {
            item.damage = 0;
            item.width = 22;
            item.height = 30;
            item.maxStack = 999;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(silver: 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ProjectileType<Projectiles.Bombs.SandBombProj>();
            item.shootSpeed = 5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenSolution, 20);
            recipe.AddIngredient(ItemID.Bomb, 1);
            recipe.AddIngredient(ItemID.SandBlock, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 15);
            recipe.AddRecipe();
        }
    }
}