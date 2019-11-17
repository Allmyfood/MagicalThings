using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Ranger
{
    public class VortexMissileProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Missile");     //Name of the projectile
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 3;
            projectile.CloneDefaults(ProjectileID.VortexBeaterRocket); //440
            aiType = ProjectileID.VortexBeaterRocket;
            projectile.damage = 80;
            projectile.aiStyle = 1;
            projectile.width = 14;
            projectile.height = 28;           
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
            //projectile.light = 0.5f;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            //projectile.extraUpdates = 1;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 120);
        }

        #region Explode on Collide
        public override bool PreKill(int timeLeft) //Default vortex beater rocket explosion
        {
            Main.PlaySound(SoundID.Item14, projectile.position);
            projectile.position = projectile.Center;
            projectile.width = (projectile.height = 80);
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            int num3;
            for (int num313 = 0; num313 < 4; num313 = num3 + 1)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                num3 = num313;
            }
            for (int num314 = 0; num314 < 40; num314 = num3 + 1)
            {
                int num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, 0f, 200, default(Color), 2.5f);
                Main.dust[num315].noGravity = true;
                Dust dust = Main.dust[num315];
                dust.velocity *= 2f;
                num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, 0f, 200, default(Color), 1.5f);
                dust = Main.dust[num315];
                dust.velocity *= 1.2f;
                Main.dust[num315].noGravity = true;
                num3 = num314;
            }
            for (int num316 = 0; num316 < 1; num316 = num3 + 1)
            {
                int num317 = Gore.NewGore(projectile.position + new Vector2((float)(projectile.width * Main.rand.Next(100)) / 100f, (float)(projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, default(Vector2), Main.rand.Next(61, 64), 1f);
                Gore gore = Main.gore[num317];
                gore.velocity *= 0.3f;
                Gore gore41 = Main.gore[num317];
                gore41.velocity.X = gore41.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
                Gore gore42 = Main.gore[num317];
                gore42.velocity.Y = gore42.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
                num3 = num316;
            }
            projectile.Damage();
            return false;
        }
        #endregion
    }
}
