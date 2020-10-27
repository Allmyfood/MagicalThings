using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Warrior
{
    public class SpectreProj : ModProjectile
    {
        //int type = 538; //projectile shot id

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
            projectile.scale = 1f; //default for most yo-yos
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Spectre");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 400f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 17.0f;
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
            target.immune[projectile.owner] = 8;
            if (Main.rand.Next(10) == 0)
            {
                if (projectile.owner == Main.myPlayer) //do life steal if hp is less than max.
                {
                    Player owner = Main.player[projectile.owner];
                    if (owner.statLife < owner.statLifeMax)
                    {
                        if (owner.lifeSteal <= 0f) return;
                        float heal = damage / 10;
                        if (projectile.penetrate >= 0) heal = damage / 10;
                        owner.lifeSteal -= heal;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, ProjectileID.SpiritHeal, 0, 0f, projectile.owner, (float)projectile.owner, heal);
                    }
                }
            }
        }

        public override void AI() //Will make the projectile and make it real. 480 is projectile ID. .52f is additional damage
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.58f, 1.0f, 1.0f);
            if (Main.rand.Next(325) == 0)
            {
                Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 7); //Twinkle sound
                //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, type, (int)(0.52f * projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
            }

        }

        public override void PostAI()
        {
            if (Main.rand.Next(12) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
                dust.noGravity = true;
                dust.scale = 0.8f;                
            }
        }
    }
}
