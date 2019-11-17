using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class IceMistProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser); //439
            projectile.width = 98;
            projectile.height = 98;
            projectile.friendly = true;
            projectile.magic = true;
			//Main.projFrames[projectile.type] = 4; //moved to static
            aiType = ProjectileID.LaserMachinegunLaser;
            //projectile.aiStyle = 139; //9 magic missle style, trailing, and sounds.
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 130;
            projectile.light = 0.6f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Mist Blast");
            Main.projFrames[projectile.type] = 7;
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void AI()
        {
            projectile.velocity = projectile.velocity * 0f; //It's an explosion so we don't want the projectile to move
            if (projectile.frameCounter < 10)
                projectile.frame = 0;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 30)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 30 && projectile.frameCounter < 50)
                projectile.frame = 2;
            else if (projectile.frameCounter >= 50 && projectile.frameCounter < 70)
                projectile.frame = 3;
            else if (projectile.frameCounter >= 70 && projectile.frameCounter < 90)
                projectile.frame = 4;
            else if (projectile.frameCounter >= 90 && projectile.frameCounter < 110)
                projectile.frame = 5;
            else if (projectile.frameCounter >= 110 && projectile.frameCounter < 130)
                projectile.frame = 6;
            else
                projectile.frameCounter = 0;
            projectile.frameCounter++;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 210);
            target.immune[projectile.owner] = 8;
        }
    }
}
