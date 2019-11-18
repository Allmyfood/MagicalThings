using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj
{
    public class SpiritFireProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            projectile.width = 20;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.aiStyle = 0;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Fire");

        }
        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 110, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            Main.dust[dust].noGravity = true;

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
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 175);
        }
    }
}
