using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{
	//ported from Example mod because I'm lazy
	public class SidheProj : HoverShooter2
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Sidhe");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 54;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.minion = true;
            projectile.minionSlots = 1.0f;
            projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			inertia = 8f;
            //shoot = mod.ProjectileType("SlimeStingerProj");
            shoot = 124; //Emerald Staff
            shootSpeed = 14f;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.dead)
			{
				modPlayer.SidheMinion = false;
			}
			if (modPlayer.SidheMinion)
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
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 74);
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
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74);
					Main.dust[dust].velocity -= 1.2f * dustVel;
				}
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.08f, 0.86f, 0.01f);
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