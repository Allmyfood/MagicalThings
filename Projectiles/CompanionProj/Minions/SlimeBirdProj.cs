using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{
	//ported from Example mod because I'm lazy
	public class SlimeBirdProj : HoverShooter2
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Slime Bird");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 66;
			projectile.height = 42;
			projectile.friendly = true;
			projectile.minion = true;
            projectile.minionSlots = 1.0f;
            projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			inertia = 10f;
            shoot = ProjectileType<SlimeStingerProj>();
            //shoot = 123; //Sapphire Bolt
			shootSpeed = 12f;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.dead)
			{
				modPlayer.SlimeBirdMinion = false;
			}
			if (modPlayer.SlimeBirdMinion)
			{
				projectile.timeLeft = 2;
			}
		}
        //Handy for minions that use more or less than 1 minionSlot
        //public override bool OnTileCollide(Vector2 oldVelocity)
        //{
        //    return false;
        //}

        public override void CreateDust()
		{
			if (projectile.ai[0] == 0f)
			{
				if (Main.rand.Next(25) == 0)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 21);
					Main.dust[dust].velocity.Y -= 2.2f;
				}
			}
			else
			{
				if (Main.rand.Next(15) == 0)
				{
					Vector2 dustVel = projectile.velocity;
					if (dustVel != Vector2.Zero)
					{
						dustVel.Normalize();
					}
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 21);
					Main.dust[dust].velocity -= 1.2f * dustVel;
				}
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.31f, 0.13f, 0.75f);
		}

		public override void SelectFrame()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 3;
			}
		}
	}
}