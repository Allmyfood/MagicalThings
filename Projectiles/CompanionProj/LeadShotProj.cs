using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj
{
    public class LeadShotProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Shot");     //Name of the projectile
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
        }

        public override void SetDefaults()
        {
            projectile.width = 18;               //The width of projectile hitbox
            projectile.height = 18;              //The height of projectile hitbox
            projectile.aiStyle = 2;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 2;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 1200;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 0.5f;            //How much light emit around the projectile
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
                                                    //aiType = ProjectileID.WoodenArrowFriendly;           //Act exactly like default Bullet, Arrow
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Dazed, 35);
        }

        public override bool PreKill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);

            for (int num459 = 0; num459 < 7; num459++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
            }
            for (int num460 = 0; num460 < 3; num460++)
            {
                int num461 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num461].noGravity = true;
                Main.dust[num461].velocity *= 3f;
                num461 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num461].velocity *= 2f;
            }
            int num462 = Gore.NewGore(new Vector2(projectile.position.X - 10f, projectile.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num462].velocity *= 0.3f;
            Main.gore[num462].velocity.X += Main.rand.Next(-10, 11) * 0.05f;
            Main.gore[num462].velocity.Y += Main.rand.Next(-10, 11) * 0.05f;

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
    }
}
