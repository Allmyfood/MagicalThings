using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Warrior.Tier9
{
    public class SpiritCrusher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Crusher");
            Tooltip.SetDefault("A spectral greataxe"
                + "\nLife steal on hit");
        }
        public override void SetDefaults()
        {
            item.damage = 150;
            item.melee = true;
            item.width = 70;
            item.height = 70;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 7.75f;
            item.value = 150;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 16;
            //item.shoot = 389; // ModContent.ProjectileType("InfestedProj");
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
			target.AddBuff(mod.BuffType("CutDebuff"), 270);
            if (item.owner == Main.myPlayer) //do life steal if hp is less than max.
            {
                Player owner = Main.player[item.owner];
                if (owner.statLife < owner.statLifeMax)
                {
                    if (owner.lifeSteal <= 0f) return;
                    float heal = damage / 10;
                    owner.lifeSteal -= heal;
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, ProjectileID.SpiritHeal, 0, 0f, item.owner, item.owner, heal);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PrimeGreatsword", 1);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}