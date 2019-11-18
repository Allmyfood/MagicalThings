using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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