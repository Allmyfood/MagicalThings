using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MagicalThings.Projectiles.Minions
{

	public class SwarmProj : Minion2
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Enchanted Beehive");
            Main.projFrames[projectile.type] = 8;
			//Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
            projectile.CloneDefaults(388);
            aiType = 388;
            projectile.aiStyle = 66;
			projectile.width = 10;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = .25f;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
            //inertia = 20f;
            //shoot = 389; //Sapphire Bolt
            //shootSpeed = 15f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.tileCollide = false;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.tileCollide = false;
            }
            return false;
        }

        public override void CheckActive()
		{
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.95f, 0.84f, 0.26f);
            Player player = Main.player[projectile.owner];
			MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
            projectile.spriteDirection = projectile.direction = (projectile.velocity.X > 0).ToDirectionInt();
            projectile.rotation = projectile.velocity.ToRotation() + (projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
            if (player.dead)
			{
				modPlayer.SwarmMinion = false;
			}
			if (modPlayer.SwarmMinion)
			{
				projectile.timeLeft = 2;
			}
		} 
	}
}