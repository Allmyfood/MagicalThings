using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.Pets
{
	public class IlluminationProj : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Illumination Follower");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }
        public override void SetDefaults()
		{
			projectile.CloneDefaults(492); //Magic Lantern defaults and ai to stay near the palyer
			aiType = 492;
            projectile.width = 50;
            projectile.height = 54;
            projectile.scale = 0.5f;
			
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
				modPlayer.IlluminationTriangle = false;
			}
			if (modPlayer.IlluminationTriangle)
			{
				projectile.timeLeft = 2;
			}
            Lighting.AddLight(projectile.position, 3.0f, 3.0f, 3.0f);
        }
	}
}