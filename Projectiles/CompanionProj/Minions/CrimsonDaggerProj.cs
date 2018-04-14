using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{

	public class CrimsonDaggerProj : Minion4
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Crimson Dagger");
            Main.projFrames[projectile.type] = 1;
			//Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
            projectile.CloneDefaults(388);
            aiType = 388;
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = .5f;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			//inertia = 20f;
			//shoot = 123; //Sapphire Bolt
			//shootSpeed = 18f;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.tileCollide = false;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.tileCollide = false;
            }
            return false;
        }

        public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.dead)
			{
				modPlayer.CrimsonDaggerMinion = false;
			}
			if (modPlayer.CrimsonDaggerMinion)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}