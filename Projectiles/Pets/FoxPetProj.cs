using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.Pets
{
	public class FoxPetProj : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fox Follower");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }
        public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);
			aiType = ProjectileID.Bunny;
            projectile.width = 48;
            projectile.height = 37;
			
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
            Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
			if (player.dead)
			{
				modPlayer.FoxPet = false;
			}
			if (modPlayer.FoxPet)
			{
				projectile.timeLeft = 2;
			}
        }
	}
}