using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Achievements;

namespace MagicalThings.Projectiles.CompanionProj.Ninja
{
	class BlindPowderProj : ModProjectile
	{
		public override void SetDefaults()
		{
            // while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
            projectile.CloneDefaults(196);
            aiType = ProjectileID.SmokeBomb;
            projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.penetrate = -1;
            projectile.damage = 1;
            projectile.aiStyle = 2;
            projectile.timeLeft = 80;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Confused, 210);
        }

        public override bool PreKill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);

            for (int num459 = 0; num459 < 7; num459++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 263, 0f, 0f, 100, default(Color), 1.5f);
            }
            for (int num460 = 0; num460 < 3; num460++)
            {
                int num461 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 263, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num461].noGravity = true;
                Main.dust[num461].velocity *= 3f;
                num461 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 263, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num461].velocity *= 2f;
                num461 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 263, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num461].velocity *= 4f;
                num461 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 263, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num461].velocity *= 1f;
                projectile.Damage();
            }
            
            int num462 = Gore.NewGore(new Vector2(projectile.position.X - 10f, projectile.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
            int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[goreIndex].scale = 1.5f;
            Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
            Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;

            Main.gore[num462].velocity *= 0.3f;
            Main.gore[num462].velocity.X += Main.rand.Next(-10, 11) * 0.05f;
            Main.gore[num462].velocity.Y += Main.rand.Next(-10, 11) * 0.05f;
            Main.gore[num462].velocity *= 0.4f;
            Main.gore[num462].velocity.X += Main.rand.Next(-12, 18) * 0.05f;
            Main.gore[num462].velocity.Y += Main.rand.Next(-12, 18) * 0.05f;
            Main.gore[num462].velocity *= 0.5f;
            Main.gore[num462].velocity.X += Main.rand.Next(-15, 15) * 0.05f;
            Main.gore[num462].velocity.Y += Main.rand.Next(-15, 15) * 0.05f;
            projectile.Damage();

            if (projectile.localAI[1] == 0f)
            {
                projectile.maxPenetrate = 1;
                projectile.position.X = projectile.position.X + projectile.width / 2;
                projectile.position.Y = projectile.position.Y + projectile.height / 2;
                projectile.width = 80;
                projectile.height = 80;
                projectile.position.X = projectile.position.X - projectile.width / 2;
                projectile.position.Y = projectile.position.Y - projectile.height / 2;
                projectile.width = 120;
                projectile.height = 120;
                projectile.position.X = projectile.position.X - projectile.width / 2;
                projectile.position.Y = projectile.position.Y - projectile.height / 2;
                projectile.Damage();

                projectile.localAI[1] = -1f;
            }
            return false;
        }
    }
}
