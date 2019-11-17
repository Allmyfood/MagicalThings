using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class SpectralRingProj : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.Typhoon);
			projectile.damage = 90;
            projectile.width = 120;
            projectile.height = 120;
            projectile.friendly = true;
            projectile.magic = true;
            //aiType = ProjectileID.DemonScythe;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 3600;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Shield Protection");
            //Main.projFrames[projectile.type] = 4;
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 1.0f, 0.0f);
            projectile.rotation -= 0.07f;
            Player player = Main.player[projectile.owner];
            projectile.Center = player.Center;
            if (player.dead || !player.HasBuff(mod.BuffType("VortexShieldBuff")))
            {
                if (player.dead || !player.HasBuff(mod.BuffType("HallowedShieldBuff")))
                {
                    if (player.dead || !player.HasBuff(mod.BuffType("HallowedArmorBuff")))
                    {
                        projectile.Kill();
                    }
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
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
    }
}
