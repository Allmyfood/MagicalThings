using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MagicalThings.Projectiles.Minions
{
	//ported from Example mod because I'm lazy
	public class GwenProj : Minion2
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Guenhwyvar");
            Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
            aiType = 266;
            projectile.width = 80;
			projectile.height = 48;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
            projectile.aiStyle = 26;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
            projectile.timeLeft *= 5;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            fallThrough = false;
            return true;
        }
       
        public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.dead)
			{
				modPlayer.GwenMinion = false;
			}
			if (modPlayer.GwenMinion)
			{
				projectile.timeLeft = 2;
			}
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
        /*public override void CreateDust()
		{
			if (projectile.ai[0] == 0f)
			{
				if (Main.rand.Next(5) == 0)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, mod.DustType("Sparkle"));
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
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Sparkle"));
					Main.dust[dust].velocity -= 1.2f * dustVel;
				}
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
		}*/

    }
}