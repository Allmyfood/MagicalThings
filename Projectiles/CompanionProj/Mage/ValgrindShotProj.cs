using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class ValgrindShotProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 250;
            Main.projFrames[projectile.type] = 5;
            //projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser); //440
            aiType = ProjectileID.LaserMachinegunLaser;
            projectile.aiStyle = 1;
            projectile.width = 18;
            projectile.height = 42;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1; //must be at least 1
            projectile.tileCollide = false;
            projectile.timeLeft = 3600;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.usesLocalNPCImmunity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valgrind");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void Kill(int timeLeft) //Explode small crystal shards on NPC hit (cause no tile collide)
        {
            Player player = Main.player[projectile.owner];
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);//30
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(1, 3);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                    value17.Normalize();
                    value17 *= Main.rand.Next(20, 302) * 0.01f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, 90, projectile.damage * 2, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
                    //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, ModContent.ProjectileType("IceMistProj"), projectile.damage * 2, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            var mpm = player.GetModPlayer<MagicalPlayer>();
            target.AddBuff(mod.BuffType("CutDebuff"), 420);
            target.immune[projectile.owner] = 5;
            mpm.ValgrindShotCount++;
            if (mpm.ValgrindShotCount >= 5)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ProjectileType<ValgrindGateProj>(), 0, 0f, projectile.owner);//, 0f, Main.rand.Next(-30, 2));
                mpm.ValgrindShotCount = 0;
            }
        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 0.58f, 0.84f);
            
            #region Frame Select and Counter
            if (projectile.frameCounter < 10)
                projectile.frame = 0;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 20)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 20 && projectile.frameCounter < 30)
                projectile.frame = 2;
            else if (projectile.frameCounter >= 30 && projectile.frameCounter < 40)
                projectile.frame = 3;
            else if (projectile.frameCounter >= 40 && projectile.frameCounter < 50)
                projectile.frame = 4;
            else
                projectile.frameCounter = 0;
            projectile.frameCounter++;
            #endregion

            #region Homing and Dusts
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 600f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && Main.npc[k].CanBeChasedBy(projectile, false) && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f; //11f
                AdjustMagnitude(ref projectile.velocity);
            }
            //if (projectile.alpha <= 100)
            //{
            //    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 255, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            //    Main.dust[dust].velocity /= 1f;
            //}
            #endregion
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 35f)
            {
                vector *= 25f / magnitude;
            }
        }
    }
}
