using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class LivingFireballProj : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(207);
            Main.projFrames[projectile.type] = 4;
            projectile.width = 54;
            projectile.height = 52;
            projectile.friendly = true;
            projectile.magic = true;
            //aiType = 207;
            projectile.aiStyle = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 1800;
            projectile.alpha = 255;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grand Ember Staff");
            ProjectileID.Sets.Homing[projectile.type] = true;

        }
        public override void AI()
        {
            //int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            //Main.dust[dust].noGravity = true;

            if (projectile.frameCounter < 5)
                projectile.frame = 0;
            else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
                projectile.frame = 2;
            else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
                projectile.frame = 3;
            else
                projectile.frameCounter = 0;
            projectile.frameCounter++;
            if (projectile.alpha > 30)
            {
                projectile.alpha -= 15;
                if (projectile.alpha < 30)
                {
                    projectile.alpha = 250;
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 100);
        }
    }
}
