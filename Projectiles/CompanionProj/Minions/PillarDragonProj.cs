using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{
	public class PillarDragonProj : HoverShooter2
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Pillar Dragon");
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
    }

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 46;
			projectile.height = 50;
			projectile.friendly = true;
			projectile.minion = true;
            projectile.minionSlots = 1.0f;
            projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			inertia = 8f;
            projectile.damage = 140;
            //shoot = mod.ProjectileType("DragnadoProj");
            shoot = 640;
            shootSpeed = 16f;
            shootCool = 30f; //called from Hovershooter2
            spacingMult = 1.0f;
		}

		public override void CheckActive()
		{
            //projectile.spriteDirection = projectile.direction;
            Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.dead)
			{
				modPlayer.PillarDragonMinion = false;
			}
			if (modPlayer.PillarDragonMinion)
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
				if (Main.rand.Next(30) == 0)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 202);
					Main.dust[dust].velocity.Y -= 2.2f;
				}
			}
			else
			{
				if (Main.rand.Next(20) == 0)
				{
					Vector2 dustVel = projectile.velocity;
					if (dustVel != Vector2.Zero)
					{
						dustVel.Normalize();
					}
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 202);
					Main.dust[dust].velocity -= 1.2f * dustVel;
				}
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.46f, 0.87f, 0.87f);
		}
        public override void SelectFrame()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8) //this means 8 frames of time on each frame
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 7;
            }
        }
    }
}