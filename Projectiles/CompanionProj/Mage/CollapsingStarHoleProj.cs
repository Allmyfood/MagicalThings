using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class CollapsingStarHoleProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            //projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser); //440
            aiType = ProjectileID.LaserMachinegunLaser;
            projectile.aiStyle = 18;//118
            projectile.width = 68;
            projectile.height = 68;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1; //must be at least 1
            projectile.tileCollide = false;
            projectile.timeLeft = 240;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Collapsing Star");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = false;

        }

        public override void Kill(int timeLeft) //act like a flask explosion
        {
            Player player = Main.player[projectile.owner];
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 62);
            //Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("CollapsingStarFlashProj"), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(5, 15);//20,31
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                    value17.Normalize();
                    value17 *= Main.rand.Next(20, 302) * 0.01f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, 645, projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
                    
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 60);
            target.AddBuff(mod.BuffType("Slowed"), 270);
            target.AddBuff(mod.BuffType("ArmorBreak"), 270);
            target.AddBuff(BuffID.Confused, 160);
            target.immune[projectile.owner] = 6;
        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.99f, 1.0f, 0.99f);
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 272, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            //Main.dust[dust].noGravity = true;
            #region Dusts
            if (Main.rand.Next(45) == 0)
            {
                for (int num1001 = 0; num1001 < 5; num1001++)
                {
                    int num1002 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 272, 0f, 0f, 6, default(Color), 0.6f);
                    Main.dust[num1002].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * (float)projectile.width / 2f;
                    Main.dust[num1002].velocity *= 2f;
                    Main.dust[num1002].noGravity = true;
                    Main.dust[num1002].fadeIn = 2.5f;
                }
                for (int num1003 = 0; num1003 < 5; num1003++)
                {
                    int num1004 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226, 0f, 0f, 6, default(Color), 0.7f);
                    Main.dust[num1004].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2)) * (float)projectile.width / 2f;
                    Main.dust[num1004].noGravity = true;
                    Main.dust[num1004].velocity *= 3f;
                }
            }
            #endregion
            if (projectile.owner == Main.myPlayer)
            {
                //bool hitEffect = false; // if true, perform a hit effect
                //int droprate = Main.rand.Next(20, 65);
                //projectile.localAI[0] += 1f;
                projectile.ai[1] = 0;
                projectile.ai[0]++;
                if(projectile.ai[0] >60)
                {
                    int randshotx = Main.rand.Next(-5, 5);
                    if (randshotx >= 0 && randshotx < 1) randshotx = 1;
                    if (randshotx < -1 && randshotx >= 0) randshotx = -1;
                    int randshoty = Main.rand.Next(-2, 2);
                    if (randshoty >= 0 && randshoty < 1) randshotx = 1;
                    if (randshoty < -1 && randshoty >= 0) randshotx = -1;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, randshotx, randshoty, mod.ProjectileType("CollapsingStarShotProj"), projectile.damage, 0, Main.myPlayer, 0f, 0f);
                    projectile.ai[0] = 0;
                }
                // Every 30 ticks, the cloud drops a bomb. Currently 75
                //hitEffect = projectile.localAI[0] % droprate == 0;//75f == 0;
                //hitEffect = projectile.localAI[0] % 175f == 0;
                //if (hitEffect)
                //{
                //    for (int i = 0; i < droprate; i++)
                //    {
                //        Vector2 playerPosition = projectile.Center;
                //        int projectileIndex = Projectile.NewProjectile(playerPosition.X, playerPosition.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("CollapsingStarShotProj"), projectile.damage, projectile.knockBack);

                //        CollapsingStarShotProj projectileName = Main.projectile[projectileIndex].modProjectile as CollapsingStarShotProj;
                //        float angle = (360f / droprate) * i;
                //    }
                //    //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X / 4, 3, mod.ProjectileType("CollapsingStarShotProj"), projectile.damage, projectile.knockBack, projectile.owner, 0f);
                //}

                #region Frame Select
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
        }
    }
}
