using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class HellBurstBoltProj : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(207);
            //Main.projFrames[projectile.type] = 4;
            projectile.damage = 50;
            projectile.width = 14;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.magic = true;
            //aiType = 207;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
            projectile.tileCollide = false;
            //projectile.alpha = 255;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Burst Bolt");
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }
        public override void AI()
        {
            //int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            //Main.dust[dust].noGravity = true;
            #region Homing and Dusts
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 400f;
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
            if (projectile.alpha <= 100)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
                Main.dust[dust].velocity /= 1f;
            }
            #endregion
        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 25f)
            {
                vector *= 25f / magnitude;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 185);
        }
    }
}