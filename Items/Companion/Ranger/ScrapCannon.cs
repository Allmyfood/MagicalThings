using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger
{
    public class ScrapCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scrap Cannon");
            Tooltip.SetDefault("A simple hand cannon, uses lead shot");
        }

        public override void SetDefaults()
        {

            item.damage = 18;
            item.ranged = true;
            item.width = 56;
            item.height = 20;
            item.useTime = 45;
            //item.shoot = 10;
            item.shoot = ProjectileType<Projectiles.CompanionProj.LeadShotProj>();
            item.shootSpeed = 16f;
            item.useAnimation = 45;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 9;
            item.value = 30;
            //item.useAmmo = AmmoID.Arrow;
            item.useAmmo = ItemType<LeadShot>();
            item.rare = ItemRarityID.Orange;
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
            recipe.AddIngredient(null, "PebbleGun", 1);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}