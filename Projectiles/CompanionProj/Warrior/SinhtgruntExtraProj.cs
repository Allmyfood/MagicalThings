using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Warrior
{
    public class SinhtgruntExtraProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 260;
            projectile.CloneDefaults(ProjectileID.TerrarianBeam);
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.melee = true;
            //aiType = 9;
            projectile.aiStyle = 115;
            projectile.penetrate = -1;
            //projectile.timeLeft = 1200;
            projectile.scale = 1.2f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.usesLocalNPCImmunity = true; // Invincibility acts per individual projectile
            projectile.localNPCHitCooldown = projectile.timeLeft;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sinhtgrunt Flare");
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 1.0f, 1.0f);
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 34, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 162, default(Color), 0.9f);
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }

        #region Vanilla Terrarian Blur
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            int num341 = (int)projectile.ai[1] + 1;
            if (num341 > 7)
            {
                num341 = 7;
            }
            int num43;
            for (int num342 = 1; num342 < num341; num342 = num43 + 1)
            {
                SpriteEffects spriteEffects = SpriteEffects.None;
                if (projectile.spriteDirection == -1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                int num148 = 0;
                int num149 = 0;
                float num150 = (float)(Main.projectileTexture[projectile.type].Width - projectile.width) * 0.5f + (float)projectile.width * 0.5f;
                float num343 = projectile.velocity.X * (float)num342 * 1.5f;
                float num344 = projectile.velocity.Y * (float)num342 * 1.5f;
                Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
                Color alpha13 = projectile.GetAlpha(color25);
                float num345 = 0.4f - (float)num342 * 0.06f;
                num345 *= 1f - (float)projectile.alpha / 255f;
                alpha13.R = (byte)((float)alpha13.R * num345);
                alpha13.G = (byte)((float)alpha13.G * num345);
                alpha13.B = (byte)((float)alpha13.B * num345);
                alpha13.A = (byte)((float)alpha13.A * num345 / 2f);
                float num346 = projectile.scale;
                num346 -= (float)num342 * 0.1f;
                Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], new Vector2(projectile.position.X - Main.screenPosition.X + num150 + (float)num149 - num343, projectile.position.Y - Main.screenPosition.Y + (float)(projectile.height / 2) + projectile.gfxOffY - num344), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, 0, Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height)), alpha13, projectile.rotation, new Vector2(num150, (float)(projectile.height / 2 + num148)), num346, spriteEffects, 0f);
                num43 = num342;
            }
            return false;
        }
        #endregion

        #region On Kill Proj
        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(2) == 0)
            {
                #region Explosion
                Main.PlaySound(SoundID.Item14, projectile.position);
                projectile.damage = projectile.damage * 5;
                projectile.position = projectile.Center;
                projectile.width = (projectile.height = 160);//80
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                int num3;
                for (int num313 = 0; num313 < 4; num313 = num3 + 1)
                {
                    Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 228, 0f, 0f, 100, default(Color), 1.5f);
                    num3 = num313;
                }
                for (int num314 = 0; num314 < 40; num314 = num3 + 1)
                {
                    int num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 200, default(Color), 2.5f);
                    Main.dust[num315].noGravity = true;
                    Dust dust = Main.dust[num315];
                    dust.velocity *= 2f;
                    num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 200, default(Color), 1.5f);
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
                #endregion
            }
        }
        #endregion
    }
}
