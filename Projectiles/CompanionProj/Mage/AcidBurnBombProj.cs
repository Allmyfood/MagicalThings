using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class AcidBurnBombProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser); //440
            aiType = ProjectileID.LaserMachinegunLaser;
            projectile.aiStyle = 1;
            projectile.width = 40;
            projectile.height = 42;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1; //must be at least 1
            projectile.tileCollide = true;
            projectile.timeLeft = 800;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Burn");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = false;

        }

        public override void Kill(int timeLeft) //act like a flask explosion
        {
            Player player = Main.player[projectile.owner];
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 112);
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(20, 31);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                    value17.Normalize();
                    value17 *= Main.rand.Next(20, 302) * 0.01f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, ProjectileType<AcidBurnCloudProj>(), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Venom, 210);
            target.AddBuff(BuffID.CursedInferno, 210);
            target.immune[projectile.owner] = 7;
        }

        public override void AI()
        {
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
        }
    }
}
