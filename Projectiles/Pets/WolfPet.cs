using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.Pets
{
	public class WolfPet : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wolf Follower");
            Main.projFrames[projectile.type] = 9;
            Main.projPet[projectile.type] = true;
        }
        public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);
			aiType = ProjectileID.Bunny;
            projectile.width = 50;
            projectile.height = 39;
			
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
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
			if (player.dead)
			{
				modPlayer.WolfPet = false;
			}
			if (modPlayer.WolfPet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}