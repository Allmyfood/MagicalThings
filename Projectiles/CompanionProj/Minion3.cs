using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj
{
	public abstract class Minion3 : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
            Behavior();
        }

		public abstract void CheckActive();
        public abstract void Behavior();

    }
}