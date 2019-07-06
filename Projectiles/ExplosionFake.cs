using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace MagicalThings.Projectiles
{
	public class ExplosionFake : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poof");
			projectile.timeLeft = 10;
			//ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			//ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.SmokeBomb);
			projectile.magic = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.penetrate = 0;
			projectile.timeLeft = 10;
			projectile.tileCollide = false;
            projectile.damage = 0;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
		}
	
	}
}
