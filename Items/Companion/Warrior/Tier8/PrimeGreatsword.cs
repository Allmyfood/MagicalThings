using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier8
{
    public class PrimeGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Greatsword");
            Tooltip.SetDefault("A heavy greatsword"
                + "\nMay cause Bleeding on hit");
        }
        public override void SetDefaults()
        {
            item.damage = 120;
            item.melee = true;
            item.width = 70;
            item.height = 70;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.knockBack = 6.75f;
            item.value = 120;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 15;
            item.shoot = 440; // mod.ProjectileType("InfestedProj");
            item.shootSpeed = 17.5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int target = 0;

            if (Main.rand.Next(6) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, target, 0f);
            }
            return false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(mod.BuffType("CutDebuff"), 240);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PWNSword", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}