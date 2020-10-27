using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class PhoenixFlightProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 150;
            Main.projFrames[projectile.type] = 8;
            projectile.CloneDefaults(ProjectileID.DD2PhoenixBowShot); //440
            aiType = ProjectileID.DD2PhoenixBowShot;
            projectile.aiStyle = 1;
            projectile.width = 66;//66
            projectile.height = 66;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1; //must be at least 1
            projectile.tileCollide = true;
            projectile.timeLeft = 300;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 7;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phoenix Flight");
            //Main.projFrames[projectile.type] = 4;
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void Kill(int timeLeft) //act like a flask explosion
        {
            Player player = Main.player[projectile.owner];
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 100);
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(1, 2);//20, 31
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                    value17.Normalize();
                    value17 *= Main.rand.Next(20, 302) * 0.01f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, ProjectileID.DD2ExplosiveTrapT3Explosion, projectile.damage *2, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 480);
            //target.immune[projectile.owner] = 6;
        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 0.99f, 0.71f); 
        }

        #region Basic Motion Blur based on Trail Cache Length
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D t = Main.projectileTexture[projectile.type];
            int frameHeight = t.Height / Main.projFrames[projectile.type];
            Vector2 drawOrigin = new Vector2(t.Width * 0.5f, frameHeight * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * projectile.frame, t.Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        #endregion
    }
}
