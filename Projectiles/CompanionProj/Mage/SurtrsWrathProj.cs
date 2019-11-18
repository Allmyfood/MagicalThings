using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class SurtrsWrathProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 250;
            Main.projFrames[projectile.type] = 4;
            //projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser); //440
            aiType = ProjectileID.LaserMachinegunLaser;
            projectile.aiStyle = 45;
            projectile.width = 48;
            projectile.height = 48;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1; //must be at least 1
            projectile.tileCollide = false;
            projectile.timeLeft = 480;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Surtr's Wrath");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = false;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 600);
            target.immune[projectile.owner] = 5; 
        }

        public override void Kill(int timeLeft) //act like a flask explosion
        {
            Player player = Main.player[projectile.owner];
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(1, 2);//20, 31
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                    value17.Normalize();
                    value17 *= Main.rand.Next(20, 302) * 0.01f;
                    //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, 612, projectile.damage * 2, 1f, projectile.owner);//, 0f, Main.rand.Next(-30, 2));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, 612, projectile.damage, 10f, projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
                }
            }
        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 0.82f, 0.0f);
            if (projectile.owner == Main.myPlayer)
            {
                bool hitEffect = false; // if true, perform a hit effect
                int droprate = Main.rand.Next(30, 45);
                projectile.localAI[0] += 1f;
                // Every 30 ticks, the cloud drops a bomb. Currently 75
                hitEffect = projectile.localAI[0] % droprate == 0;//75f == 0;
                if (hitEffect)
                {
                    #region Target of Fireball and Projectile
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
                            if (hitEffect)//this make so the projectile1 shoot a projectile every 2 seconds(60 = 1 second so 120 = 2 seconds) 
                            {
                                //Dividing the factor of 2f which is the desired velocity by distance
                                distance = 1.6f / distance;

                                //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                                shootToX *= distance * 6;
                                shootToY *= distance * 6;
                                {
                                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, ProjectileType<SurtrsWrathShotProj>(), 200, 0, projectile.owner);
                                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 102); //24 is the sound, so when this projectile is shot will make that sound
                                }
                                //projectile.ai[0] = 0f;
                            }
                        }
                    }
                    //projectile.ai[0] += 1f;
                    #endregion
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, 400, projectile.damage, 10f, projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
                }

                #region Frame Select
                if (projectile.frameCounter < 10)
                    projectile.frame = 0;
                else if (projectile.frameCounter >= 10 && projectile.frameCounter < 20)
                    projectile.frame = 1;
                else if (projectile.frameCounter >= 20 && projectile.frameCounter < 30)
                    projectile.frame = 2;
                else if (projectile.frameCounter >= 30 && projectile.frameCounter < 40)
                    projectile.frame = 3;
                else
                    projectile.frameCounter = 0;
                projectile.frameCounter++;
                #endregion

                #region Basic Dust
                for (int i = 0; i < 1; i++)
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 35, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.6f, 100, default(Color), 0.8f);   //this make so when this projectile is active has dust around , change PinkFlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust is effected by gravity
                    Main.dust[dust].velocity *= 0.9f;
                }
                #endregion
            }
        }

    }
}
