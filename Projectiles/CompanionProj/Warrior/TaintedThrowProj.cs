using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Warrior
{
    public class TaintedThrowProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Code2); //otherwise aiStyle is 99 for yo-yos.
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
            DisplayName.SetDefault("Tainted Throw");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 6.75f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 295f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14f;
            // YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player. 
            // Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
            // YoyosMaximumRange is the maximum distance the yoyo sleep away from the player. 
            // Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
            // YoyosTopSpeed is top speed of the yoyo projectile. 
            // Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
        }
        //Adds dust to the yo-yo

        //Adds a Buff to the yo-yo
        //		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //		{
        //			if (Main.rand.NextBool())
        //			{
        //				target.AddBuff(72, 280, false);
        //			}
        //		}
        // handy way for more dust
        //public override void PostAI() //Will make effects but not actuall projectiles
        //{
        //    if (Main.rand.Next(5) == 0)
        //    {
        //        Vector2 position = projectile.Center;
        //        int target = 0;
        //        Projectile.NewProjectile(position.X, position.Y, 0, 0, 480, 0, 0f, projectile.owner, target, 0f);
        //    }
        //}
        public override void AI() //Will make the projectile and make it real. 480 is projectile ID. .52f is additional damage
        {
            if (Main.rand.Next(35)== 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, 480, (int)(0.52f * projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
            }
        }

    }
}
