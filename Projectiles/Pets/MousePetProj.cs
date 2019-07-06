using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.Pets
{
	public class MousePetProj : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mouse Follower");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }
        public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);
			aiType = ProjectileID.Bunny;
            projectile.width = 20;
            projectile.height = 14;
			
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
            drawOriginOffsetY = 1;
            Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.dead)
			{
				modPlayer.MousePet = false;
			}
			if (modPlayer.MousePet)
			{
				projectile.timeLeft = 2;
			}

            if (Main.rand.Next(1000) == 0)
            {
                Main.PlaySound(29, (int)projectile.position.X, (int)projectile.position.Y, 15, .125f); //Chance for mousey to squeak
            }
        }
	}
}