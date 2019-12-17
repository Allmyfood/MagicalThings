using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items
{
    public class InfiniteTundraBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Snowify with Explosions!"
                + "\nWill change Dirt to Snow and Stone to Ice" + "\nExplodes in a 60 tile radius"
                + "\nCaution! Changes Stone walls to Snow! Don't use by your base!");
        }
        public override void SetDefaults()
        {
            item.damage = 0;
            item.width = 22;
            item.height = 30;
            item.maxStack = 1;
            item.consumable = false;
            item.useStyle = 1;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(silver: 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ProjectileType<Projectiles.TundraBombProj>();
            item.shootSpeed = 5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TundraBomb", 30);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}