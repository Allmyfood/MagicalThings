using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class BitingSnowBombProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            projectile.CloneDefaults(ProjectileID.NorthPoleSpear); //440
            aiType = ProjectileID.NorthPoleSpear;
            projectile.aiStyle = 57;
            projectile.width = 46;
            projectile.height = 46;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 3; //must be at least 1
            projectile.tileCollide = true;
            //projectile.timeLeft = 600;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Biting Snow");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = false;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 210);
            target.immune[projectile.owner] = 7;
            #region Steal Health
            if (projectile.owner == Main.myPlayer) //do life steal if hp is less than max.
            {
                Player owner = Main.player[projectile.owner];
                if (owner.statLife < owner.statLifeMax)
                {
                    if (owner.lifeSteal <= 0f) return;
                    float heal = damage / 10;
                    if (projectile.penetrate >= 0) heal = damage / 10;
                    owner.lifeSteal -= heal;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, 298, 0, 0f, projectile.owner, (float)projectile.owner, heal);
                }
            }
            #endregion
        }

        public override void AI()
        {
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

            #region Vanilla Northpole AI
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] >= 4f)
            {
                projectile.localAI[0] = 0f;
                int num564 = 0;
                int num3;
                for (int num565 = 0; num565 < 1000; num565 = num3 + 1)
                {
                    if (Main.projectile[num565].active && Main.projectile[num565].owner == projectile.owner)
                    {
                        num3 = num564;
                        num564 = num3 + 1;
                    }
                    num3 = num565;
                }
                float num566 = (float)projectile.damage * 0.8f;
                if (num564 > 100)
                {
                    float num567 = (float)(num564 - 100);
                    num567 = 1f - num567 / 100f;
                    num566 *= num567;
                }
                if (num564 > 100)
                {
                    projectile.localAI[0] -= 1f;
                }
                if (num564 > 120)
                {
                    projectile.localAI[0] -= 1f;
                }
                if (num564 > 140)
                {
                    projectile.localAI[0] -= 1f;
                }
                if (num564 > 150)
                {
                    projectile.localAI[0] -= 1f;
                }
                if (num564 > 160)
                {
                    projectile.localAI[0] -= 1f;
                }
                if (num564 > 165)
                {
                    projectile.localAI[0] -= 1f;
                }
                if (num564 > 170)
                {
                    projectile.localAI[0] -= 2f;
                }
                if (num564 > 175)
                {
                    projectile.localAI[0] -= 3f;
                }
                if (num564 > 180)
                {
                    projectile.localAI[0] -= 4f;
                }
                if (num564 > 185)
                {
                    projectile.localAI[0] -= 5f;
                }
                if (num564 > 190)
                {
                    projectile.localAI[0] -= 6f;
                }
                if (num564 > 195)
                {
                    projectile.localAI[0] -= 7f;
                }
                if (num566 > (float)projectile.damage * 0.1f)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("BitingSnowDropProj"), (int)num566, projectile.knockBack * 0.55f, projectile.owner, 0f, (float)Main.rand.Next(3));//344 is snowflake
                    return;
                }
            }
            #endregion
        }
    }
}
