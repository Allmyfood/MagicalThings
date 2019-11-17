using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class ValgrindGateProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 0;
            //Main.projFrames[projectile.type] = 5;
            //projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser); //440
            //aiType = ProjectileID.LaserMachinegunLaser;
            //projectile.aiStyle = 1;
            projectile.width = 42;
            projectile.height = 82;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1; //must be at least 1
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.usesLocalNPCImmunity = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            //projectile.sentry = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valgrind");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 0.58f, 0.84f);
            projectile.velocity = projectile.velocity * .001f;

            #region Basic Dust
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 141, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.6f, 160, default(Color), 0.8f);   //this make so when this projectile is active has dust around , change PinkFlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust is effected by gravity
                Main.dust[dust].velocity *= 0.9f;
            }
            #endregion

            #region Target of Gate and Projectile
            //Getting the npc to fire at
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                //Getting the shooting trajectory
                float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                //If the distance between the projectile and the live target is active
                if (distance < 620f && !target.friendly && target.active && target.CanBeChasedBy(target, false))  //distance < 520 this is the projectile1 distance from the target if the target is in that range the this projectile1 will shot the projectile2
                {
                    if (projectile.ai[0] > 25f)//this make so the projectile1 shoot a projectile every 2 seconds(60 = 1 second so 120 = 2 seconds) 
                    {
                        //Dividing the factor of 2f which is the desired velocity by distance
                        distance = 1.6f / distance;

                        //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                        shootToX *= distance * 6;
                        shootToY *= distance * 6;
                        {
                            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("WitherBoltProj"), 200, 0, projectile.owner);
                            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 72); //24 is the sound, so when this projectile is shot will make that sound
                        }
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
            #endregion
        }
    }
}
