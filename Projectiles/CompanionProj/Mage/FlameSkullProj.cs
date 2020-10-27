using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class FlameSkullProj : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(706);
            Main.projFrames[projectile.type] = 4;
            projectile.width = 90;
            projectile.height = 52;
            projectile.friendly = true;
            projectile.magic = true;
            aiType = 123;
            projectile.aiStyle = 29;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.alpha = 255;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame Skull Staff");
            ProjectileID.Sets.Homing[projectile.type] = true;

        }
        public override void AI()
        {
            projectile.spriteDirection = projectile.direction = (projectile.velocity.X > 0).ToDirectionInt();
            projectile.rotation = projectile.velocity.ToRotation() + (projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
            //int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            //Main.dust[dust].noGravity = true;
            if (projectile.spriteDirection == 1) // facing right
            {
                drawOffsetX = 30; // These values match the values in SetDefaults
                drawOriginOffsetY = -15;
            }
            else
            {
                // Facing left.
                // You can figure these values out if you flip the sprite in your drawing program.
                drawOffsetX = 0; // 0 since now the top left corner of the hitbox is on the far left pixel.
                drawOriginOffsetY = -15; // doesn't change
            }

            if (projectile.frameCounter < 5)
                projectile.frame = 0;
            else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
                projectile.frame = 2;
            else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
                projectile.frame = 3;
            else
                projectile.frameCounter = 0;
            projectile.frameCounter++;
            if (projectile.alpha > 30)
            {
                projectile.alpha -= 15;
                if (projectile.alpha < 30)
                {
                    projectile.alpha = 250;
                }
            }
        }

        public override bool PreKill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 74);

            for (int num459 = 0; num459 < 7; num459++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 101, default(Color), 0.5f);
            }
            for (int num460 = 0; num460 < 3; num460++)
            {
                int num461 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 101, default(Color), 1.5f);
                Main.dust[num461].noGravity = true;
                Main.dust[num461].velocity *= 3f;
                num461 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 101, default(Color), 0.5f);
                Main.dust[num461].velocity *= 2f;
            }
            int num462 = Gore.NewGore(new Vector2(projectile.position.X - 10f, projectile.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num462].velocity *= 0.3f;
            Main.gore[num462].velocity.X += Main.rand.Next(-2, 6) * 0.05f;
            Main.gore[num462].velocity.Y += Main.rand.Next(-2, 6) * 0.05f;

            if (projectile.localAI[1] == 0f)
            {
                projectile.maxPenetrate = 1;
                projectile.position.X = projectile.position.X + projectile.width / 2;
                projectile.position.Y = projectile.position.Y + projectile.height / 2;
                projectile.width = 80;
                projectile.height = 80;
                projectile.position.X = projectile.position.X - projectile.width / 2;
                projectile.position.Y = projectile.position.Y - projectile.height / 2;
                projectile.Damage();

                projectile.localAI[1] = -1f;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300);
        }
    }
}
