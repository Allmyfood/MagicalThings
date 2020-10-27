using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Ranger.Tier9
{
    public class PhotonicCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Photonic Cannon");
            Tooltip.SetDefault("Shoots Pulse Ammo bullets"
                + "\n25% to not consume ammo" + "\nFires a powerful laser beam");
        }

        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.ChargedBlasterCannon);
            item.damage = 90;
            item.ranged = true;
            item.width = 66;
            item.height = 21;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = 150;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item68;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder; //10 is default for guns.
            //item.shoot = ProjectileType<PebbleProj>();
            item.shootSpeed = 14.0f;
            //item.useAmmo = AmmoID.Bullet; //Normal ammos.
            item.useAmmo = ItemType<Tier8.PulseAmmo>();
            item.magic = false;
            item.noUseGraphic = false;
            //item.channel = true;
            //item.scale = 0.75f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, -1);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EyeCannon", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int target = 0;
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.ElectrosphereMissile, 80, knockBack, player.whoAmI, target, 0f);
            return false;
        }
    }
}

