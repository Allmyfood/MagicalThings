using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class HellMarkProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(585);
            projectile.width = 82;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.magic = true;
			//Main.projFrames[projectile.type] = 4; //moved to static
            aiType = 682;
            projectile.aiStyle = 1; //9 magic missle style, trailing, and sounds.
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 170;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Mark");
            Main.projFrames[projectile.type] = 4;
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }
        public override void AI()
        {
            //int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 34, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            //Main.dust[dust].noGravity = true;

            // Loop through the 4 animation frames, spending 5 ticks on each.
            if (++projectile.frameCounter >= 50)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }

            //if (projectile.frameCounter < 10)
            //    projectile.frame = 0;
            //else if (projectile.frameCounter >= 10 && projectile.frameCounter < 30)
            //    projectile.frame = 1;
            //else if (projectile.frameCounter >= 30 && projectile.frameCounter < 50)
            //    projectile.frame = 2;
            //else if (projectile.frameCounter >= 50 && projectile.frameCounter < 70)
            //    projectile.frame = 3;
            //else
            //    projectile.frameCounter = 0;
            //projectile.frameCounter++;
            //if (projectile.alpha > 30)
            //{
            //    projectile.alpha -= 15;
            //    if (projectile.alpha < 30)
            //    {
            //        projectile.alpha = 250;
            //    }
            //}
        }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 385);
        }
    }
}
