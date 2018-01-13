using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MagicalThings.Projectiles.Minions
{
	//ported from Example mod because I'm lazy
	public class VoidDragon : HoverShooter
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 5;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 73;
			projectile.height = 70;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			inertia = 20f;
			shoot = 661; //Onyx Blaster Shot
			shootSpeed = 24f;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.dead)
			{
				modPlayer.VoidDragonMinion = false;
			}
			if (modPlayer.VoidDragonMinion)
			{
				projectile.timeLeft = 2;
			}
		}

		public override void CreateDust()
		{
			if (projectile.ai[0] == 0f)
			{
				if (Main.rand.Next(5) == 0)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 65);
					Main.dust[dust].velocity.Y -= 1.2f;
				}
			}
			else
			{
				if (Main.rand.Next(3) == 0)
				{
					Vector2 dustVel = projectile.velocity;
					if (dustVel != Vector2.Zero)
					{
						dustVel.Normalize();
					}
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 151);
					Main.dust[dust].velocity -= 1.2f * dustVel;
				}
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
		}

		public override void SelectFrame()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 3;
			}
		}
	}
}