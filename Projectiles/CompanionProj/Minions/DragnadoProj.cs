using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{
    public class DragnadoProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 120;
            projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
            projectile.width = 44;
            projectile.height = 44;
            projectile.friendly = true;
            projectile.magic = true;
			Main.projFrames[projectile.type] = 6;
            aiType = ProjectileID.LaserMachinegunLaser;
            projectile.aiStyle = 1; //9 magic missle style, trailing, and sounds.
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.timeLeft = 300;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.scale = 0.75f;
            projectile.extraUpdates = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragnado");
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }
        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height /2, 107, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 200, default(Color), 0.5f);
            Main.dust[dust].noGravity = true;
            if (projectile.frameCounter < 5)
                projectile.frame = 0;
            else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
                projectile.frame = 2;
            else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
                projectile.frame = 3;
            else if (projectile.frameCounter >= 20 && projectile.frameCounter < 25)
                projectile.frame = 4;
            else if (projectile.frameCounter >= 25 && projectile.frameCounter < 30)
                projectile.frame = 5;
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
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.024f, 0.97f, 0.54f);
        }
    }
}
