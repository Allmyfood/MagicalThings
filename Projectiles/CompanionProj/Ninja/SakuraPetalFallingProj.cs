using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Ninja
{
    public class SakuraPetalFallingProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 250;
            Main.projFrames[projectile.type] = 3;
            //projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser); //440
            aiType = ProjectileID.ConfettiGun;
            projectile.aiStyle = 1;
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.magic = false;
            projectile.thrown = true;
            projectile.penetrate = 1; //must be at least 1
            projectile.tileCollide = false;
            projectile.timeLeft = 360;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.usesLocalNPCImmunity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sakura Petal");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void Kill(int timeLeft) //act like a flask explosion
        {
            Player player = Main.player[projectile.owner];
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 71);
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(1, 3);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                    value17.Normalize();
                    value17 *= Main.rand.Next(20, 302) * 0.01f;
                    //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, 90, projectile.damage *2, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, ProjectileType<SakuraPetalProj>(), projectile.damage, 1f, projectile.owner);//, 0f, Main.rand.Next(-30, 2));
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("CutDebuff"), 420);
            target.immune[projectile.owner] = 6;
        }

        #region AI control
        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.63f, 0.28f, 0.64f);

            #region Frame Select and Counter
            if (projectile.frameCounter < 10)
                projectile.frame = 0;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 20)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 20 && projectile.frameCounter < 30)
                projectile.frame = 2;
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
            float distance = 375f;
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
                projectile.Kill();
                //AdjustMagnitude(ref move);
                //projectile.velocity = (10 * projectile.velocity + move) / 11f; //11f
                //AdjustMagnitude(ref projectile.velocity);
            }
            //if (projectile.alpha <= 100)
            //{
            //    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            //    Main.dust[dust].velocity /= 1f;
            //}
            #endregion

            #region Gravity
            projectile.velocity.Y = projectile.velocity.Y + 0.05f; // 0.1f for arrow gravity, 0.4f for knife gravity
            if (projectile.velocity.Y > 0.5f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
            {
                projectile.velocity.Y = 0.5f;
            }
            #endregion
        }
        #endregion

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
