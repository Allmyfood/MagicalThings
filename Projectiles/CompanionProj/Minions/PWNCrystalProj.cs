using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{
	public class PWNCrystalProj : HoverShooter2
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("PWN Crystal");
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
    }

		public override void SetDefaults()
		{
            //projectile.CloneDefaults(643);
            //aiType = 643;
			projectile.netImportant = true;
			projectile.width = 26;
			projectile.height = 50;
			projectile.friendly = true;
			projectile.minion = true;
            projectile.minionSlots = 1.0f;
            projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			inertia = 8f;
            projectile.damage = 65;
            //shoot = ModContent.ProjectileType("SpiritFireProj");
            shoot = 440;
            shootSpeed = 17f;
            shootCool = 35f; //called from Hovershooter2
		}

		public override void CheckActive()
		{
            //projectile.spriteDirection = projectile.direction;
            Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.dead)
			{
				modPlayer.PWNCrystalMinion = false;
			}
			if (modPlayer.PWNCrystalMinion)
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
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 169);
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
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 169);
					Main.dust[dust].velocity -= 1.2f * dustVel;
				}
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 0.92f, 0.77f);
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

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 210);
        }
    }
}