using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
    public class SlimeCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Cannon");
            Tooltip.SetDefault("A slimy hand cannon");
        }

        public override void SetDefaults()
        {

            item.damage = 28;
            item.ranged = true;
            item.width = 56;
            item.height = 20;
            item.useTime = 42;
            //item.shoot = 10;
            item.shoot = ProjectileType<Projectiles.CompanionProj.Ranger.SlimeShotProj>();
            item.shootSpeed = 18f;
            item.useAnimation = 42;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 11;
            item.value = 40;
            //item.useAmmo = AmmoID.Arrow;
            item.useAmmo = ItemType<SlimeShot>();
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item14;//14 is explosion sound
            item.autoReuse = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ScrapCannon", 1);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}