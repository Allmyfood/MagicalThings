using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MagicalThings.Projectiles.CompanionProj
{
    public abstract class AdvancedMelee : ModProjectile
    {
        public override void AI()
        {
            CheckActive();
            Behavior();
        }

        public abstract void CheckActive();
        public abstract void Behavior();

        public virtual void SelectFrame()
        {
        }

    }
}