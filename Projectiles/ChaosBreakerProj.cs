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
    public class ChaosBreakerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Breaker Slash");
        }
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            projectile.damage = 150;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
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
            Lighting.AddLight((int)(projectile.position.X + (double)(projectile.width / 2)) / 16, (int)(projectile.position.Y + (double)(projectile.height / 2)) / 16, 0.58f, 1.0f, 0.19f); //Greenish color
            #region Basic Dust
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.position.Y * 4f), 8, 8, 107, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default, 1.25f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= -0.25f;
                Main.dust[dust].position -= projectile.velocity * 0.5f;
            }
            #endregion

            #region Dusts 3
            if (Main.rand.Next(5) == 0)
            {
                int num3;
                for (int num798 = 4; num798 < 8; num798 = num3 + 1) //<31
                {
                    float num799 = projectile.oldVelocity.X * (30f / num798);
                    float num800 = projectile.oldVelocity.Y * (30f / num798);
                    int num801 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num799, projectile.oldPosition.Y - num800), 8, 8, 107, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default, 1.8f); //dust 107 for Terra blade
                    Main.dust[num801].noGravity = true;
                    Dust dust = Main.dust[num801];
                    dust.velocity *= 0.5f;
                    num801 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num799, projectile.oldPosition.Y - num800), 8, 8, 107, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default, 1.4f);
                    dust = Main.dust[num801];
                    dust.velocity *= 0.05f;
                    num3 = num798;
                }
            }
            #endregion

            #region Frame Counter
            if (projectile.frameCounter < 10)
                projectile.frame = 0;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 30)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 30 && projectile.frameCounter < 50)
                projectile.frame = 2;
            else if (projectile.frameCounter >= 50 && projectile.frameCounter < 70)
                projectile.frame = 3;
            else
                projectile.frameCounter = 0;
            projectile.frameCounter++;
            #endregion
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 5;
            target.AddBuff(BuffID.CursedInferno, 300);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(148, 255, 49, 150);
        }
    }
}
