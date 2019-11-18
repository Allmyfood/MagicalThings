using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Warrior
{
    public class TheStormProj : ModProjectile
    {
        int type = 616; //projectile shot id

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
            DisplayName.SetDefault("The Storm");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 450f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 17.5f;
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
        }

        public override void AI() //Will make the projectile and make it real. 480 is projectile ID. .52f is additional damage
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.78f, 1.0f, 0.95f);
            float v1x = projectile.velocity.X; //keeps a slow moving projectile from going to 0
            float v1y = projectile.velocity.Y;
            if (v1x >= 0 && v1x < 1) v1x = 12f;
            if (v1y >= 0 && v1y < 1) v1y = 12f;
            if (v1x <= 0 && v1x > -1) v1x = -12f;
            if (v1y <= 0 && v1y > -1) v1y = -12f;
            if (Main.rand.Next(16) == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v1x, v1y, type, (int)(0.52f * projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
            }
        }

        public override void PostAI()
        {
            if (Main.rand.Next(12) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 229);
                dust.noGravity = true;
                dust.scale = 0.8f;                
            }
        }
    }
}
