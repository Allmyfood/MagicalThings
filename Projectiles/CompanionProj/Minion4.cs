using System;
using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj
{
	public abstract class Minion4 : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
        }

        public virtual void SelectFrame()
        {
        }

        public virtual void CreateDust()
        {
        }

        public abstract void CheckActive();
    }
    
}