using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Warrior
{
    public class SinhtgruntProj : ModProjectile
    {
        //int type = 616; //projectile shot id

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ValkyrieYoyo); //otherwise aiStyle is 99 for yo-yos.
            projectile.width = 16;
            projectile.height = 16;
            //projectile.timeLeft = 220;
            projectile.friendly = true;
            // could use "projectile.aiStyle = 99;"
            projectile.melee = true;
            projectile.penetrate = -1; //default for yo-yos
            projectile.scale = 1.15f; //default for most yo-yos
            projectile.extraUpdates = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sinhtgrunt");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 550f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 20.5f;
            // YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player. 
            // Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
            // YoyosMaximumRange is the maximum distance the yoyo sleep away from the player. 
            // Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
            // YoyosTopSpeed is top speed of the yoyo projectile. 
            // Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
        }
        //Adds dust to the yo-yo

        //Adds a Buff to the yo-yo
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 5;
        }

        public override void AI() //Will make the projectile and make it real. 480 is projectile ID. .52f is additional damage
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.93f, 0.82f, 0.29f);
            //if (Main.rand.Next(16) == 0)
            //{
            //    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType("SinhtgruntExtraProj"), (int)(projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
            //}
            projectile.localAI[1] += 1f;
            if (projectile.localAI[1] >= 6f)
            {
                float num3 = 400f;
                Vector2 vector = projectile.velocity;
                Vector2 vector2 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                vector2.Normalize();
                vector2 *= (float)Main.rand.Next(10, 41) * 0.1f;
                if (Main.rand.Next(3) == 0)
                {
                    vector2 *= 2f;
                }
                vector *= 0.25f;
                vector += vector2;
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].CanBeChasedBy(projectile, false))
                    {
                        float num4 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                        float num5 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                        float num6 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num4) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num5);
                        if (num6 < num3 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[j].position, Main.npc[j].width, Main.npc[j].height))
                        {
                            num3 = num6;
                            vector.X = num4;
                            vector.Y = num5;
                            vector -= projectile.Center;
                            vector.Normalize();
                            vector *= 8f;
                        }
                    }
                }
                vector *= 0.8f;
                Projectile.NewProjectile(projectile.Center.X - vector.X, projectile.Center.Y - vector.Y, vector.X, vector.Y, ProjectileType<SinhtgruntExtraProj>(), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                projectile.localAI[1] = 0f;
            }
        }

        public override void PostAI()
        {
            if (Main.rand.Next(12) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 222);
                dust.noGravity = true;
                dust.scale = 0.8f;                
            }
        }
    }
}
