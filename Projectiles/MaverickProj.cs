using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace MagicalThings.Projectiles       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class MaverickProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mavrick Staff"); //Name of the projectile, only shows this if you get killed by it
        }
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 6; //projectile uses 6 frames
            projectile.width = 48;  //Set the hitbox width
            projectile.height = 29; //Set the hitbox height
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.ignoreWater = true;  //Tells the game whether or not projectile will be affected by water
            projectile.magic = true;  //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed, -1 infinity
            projectile.timeLeft = 1500;  //The amount of time the projectile is alive for  
            projectile.extraUpdates = 3;
            projectile.tileCollide = false;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ghostHeal(damage *6, projectile.position); //Heals alot because its multiplied x6
            target.AddBuff(BuffID.Frostburn, 180);
        }

        public override void AI()
        {
            if (projectile.frameCounter < 6) //frame counter has 6 frames
                projectile.frame = 0;
            else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
                projectile.frame = 1;
            else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
                projectile.frame = 2;
            else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
                projectile.frame = 3;
            else if (projectile.frameCounter >= 20 && projectile.frameCounter < 25)
                projectile.frame = 4;
            else if (projectile.frameCounter >= 25 && projectile.frameCounter < 30)
                projectile.frame = 5;
            else
                projectile.frameCounter = 0;
            projectile.frameCounter++;

            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f; //Allows the vertical projectile to be rotated 45°
            Lighting.AddLight((int)(projectile.position.X + (double)(projectile.width / 2)) / 16, (int)(projectile.position.Y + (double)(projectile.height / 2)) / 16, 0.48f, 0.34f, .71f); //default 0.8f, 0.95f, 1f
            if (projectile.timeLeft > 1500)
            {
                projectile.timeLeft = 1499; //set above starter too loop forever and ever
            }

            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero; //Homing
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
            if (target) //Adjust homing speed
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (4 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }
            if (projectile.alpha <= 100)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
                Main.dust[dust].velocity /= 1f;
            }

            if (projectile.ai[0] > 1f)  //this defines where the flames starts
            {
                if (Main.rand.Next(6) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 52, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 0.75f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 70, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 0.5f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 12f)
            {
                vector *= 12f / magnitude;
            }
        }
    }
}