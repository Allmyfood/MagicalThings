using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Warrior.Tier9
{
    public class SoulReaver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Reaver");
            Tooltip.SetDefault("A spectral blade"
                + "\nLife steal on hit");
        }
        public override void SetDefaults()
        {
            item.damage = 100;
            item.melee = true;
            item.width = 56;
            item.height = 56;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 2.75f;
            item.value = 150;
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 14;
            item.scale = 1.5f;
            //item.shoot = 389; // mod.ProjectileType("InfestedProj");
            //item.shootSpeed = 17.5f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight((int)(item.Center.X / 16f), (int)(item.Center.Y / 16f), 0.58f, 1.0f, 1.0f);
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (item.owner == Main.myPlayer) //do life steal if hp is less than max.
            {
                Player owner = Main.player[item.owner];
                if (owner.statLife < owner.statLifeMax)
                {
                    if (owner.lifeSteal <= 0f) return;
                    float heal = damage / 10;
                    owner.lifeSteal -= heal;
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, 298, 0, 0f, item.owner, item.owner, heal);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedCutter", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}