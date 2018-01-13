using Terraria.ModLoader;

namespace MagicalThings.Projectiles.Minions
{
	public abstract class Minion2 : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
		}

		public abstract void CheckActive();

	}
}