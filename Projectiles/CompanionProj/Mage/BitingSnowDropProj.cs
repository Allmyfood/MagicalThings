using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class BitingSnowDropProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 5;
            projectile.CloneDefaults(ProjectileID.NorthPoleSnowflake); //440
            projectile.damage = 90;
            aiType = ProjectileID.NorthPoleSnowflake;
            projectile.aiStyle = 1;
            projectile.width = 12;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1; //must be at least 1 or -1 for infnite
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.scale = 1.5f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Biting Snow Ice");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = false;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 240);
            target.immune[projectile.owner] = 8;
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
            projectile.rotation = 0;
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.58f, 1.0f, 1.0f);

            #region Frame Select
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
            else
                projectile.frameCounter = 0;
            projectile.frameCounter++;
            #endregion

            #region Dusts
            if (Main.rand.Next(25) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 206,
                    projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 150, Scale: 1.2f);
                dust.velocity += projectile.velocity * 0.4f;
                dust.velocity *= 0.2f;
            }
            if (Main.rand.Next(30) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 206,
                    0, 0, 254, Scale: 0.6f);
                dust.velocity += projectile.velocity * 0.5f;
                dust.velocity *= 0.5f;
            }
            #endregion
        }

    }
}
