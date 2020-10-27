using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items
{
    public class CleanseBombOriginal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Purify with Explosions!"
                + "\nWill not change Mushroom Biomes to Jungle"
                + "\nNot as effective as new version");
			DisplayName.SetDefault("Cleanse Bomb (Original)");
        }
        public override void SetDefaults()
        {
            item.damage = 0;
            item.width = 22;
            item.height = 30;
            item.maxStack = 999;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(silver: 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ProjectileType<Projectiles.CleanseBombOriginalProj>();
            item.shootSpeed = 5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenSolution, 20);
            recipe.AddIngredient(ItemID.Bomb, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 15);
            recipe.AddRecipe();
        }
    }
}