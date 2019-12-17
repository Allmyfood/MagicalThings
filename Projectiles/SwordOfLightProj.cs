using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace MagicalThings.Projectiles
{
    public class SwordOfLightProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword of Light Slash");
        }
        public override void SetDefaults()
        {
            projectile.damage = 100;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 420;
            projectile.extraUpdates = 1;
            projectile.tileCollide = false;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.usesLocalNPCImmunity = true;
            drawOriginOffsetY = -16;
            //projectile.alpha = 255;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Lighting.AddLight((int)(projectile.position.X + (double)(projectile.width / 2)) / 16, (int)(projectile.position.Y + (double)(projectile.height / 2)) / 16, 1.0f, 1.0f, 1.0f); //Greenish color
            #region Basic Dust
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.position.Y * 4f), 8, 8, 169, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default, 1.25f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= -0.25f;
                Main.dust[dust].position -= projectile.velocity * 0.5f;
            }
            #endregion

            #region Dusts 3
            if (Main.rand.Next(6) == 0)
            {
                int num3;
                for (int num798 = 4; num798 < 5; num798 = num3 + 1) //<31
                {
                    float num799 = projectile.oldVelocity.X * (30f / num798);
                    float num800 = projectile.oldVelocity.Y * (30f / num798);
                    int num801 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num799, projectile.oldPosition.Y - num800), 8, 8, 133, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default, 1.8f); //dust 107 for Terra blade
                    Main.dust[num801].noGravity = true;
                    Dust dust = Main.dust[num801];
                    dust.velocity *= 0.5f;
                    num801 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num799, projectile.oldPosition.Y - num800), 8, 8, 133, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default, 1.4f);
                    dust = Main.dust[num801];
                    dust.velocity *= 0.05f;
                    num3 = num798;
                }
            }
            #endregion
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 7;
            target.AddBuff(BuffID.Ichor, 300);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(250, 250, 250, 150);
        }
    }
}
