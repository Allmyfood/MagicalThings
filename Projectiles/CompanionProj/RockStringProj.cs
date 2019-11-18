using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj
{
	public class RockStringProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodYoyo); //otherwise aiStyle is 99 for yo-yos.
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
			DisplayName.SetDefault("Stone Yo-Yo");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 4.25f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 190f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 10f;
            // YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player. 
            // Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
            // YoyosMaximumRange is the maximum distance the yoyo sleep away from the player. 
            // Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
            // YoyosTopSpeed is top speed of the yoyo projectile. 
            // Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
        }
        //Adds dust to the yo-yo
        //		public override bool PreAI()
        //		{
        //			if (Main.rand.NextBool(3))
        //			{
        //				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 13, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
        //			}
        //
        //			return true;
        //		}
        //Adds a Buff to the yo-yo
        //		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //		{
        //			if (Main.rand.NextBool())
        //			{
        //				target.AddBuff(72, 280, false);
        //			}
        //		}
        // handy way for more dust
        /*     public override void PostAI()
             {
                 if (Main.rand.Next(2) == 0)
                 {
                     Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 16);
                     dust.noGravity = true;
                     dust.scale = 1.6f;
                 }
             */ //}

    }
}
