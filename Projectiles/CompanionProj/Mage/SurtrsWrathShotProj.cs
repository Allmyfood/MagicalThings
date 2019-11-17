using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class SurtrsWrathShotProj : ModProjectile
    {
        public override void SetDefaults()
        {
            //Main.projFrames[projectile.type] = 5;
            projectile.CloneDefaults(ProjectileID.DD2BetsyArrow); //440
            //projectile.damage = 75;
            aiType = 710;
            projectile.aiStyle = 1;
            //projectile.width = 32;
            //projectile.height = 32;
            //projectile.friendly = true;
            projectile.magic = true;
            projectile.ranged = false;
            //projectile.penetrate = -1; //must be at least 1 or -1 for infnite
            //projectile.tileCollide = false;
            //projectile.timeLeft = 600;
            //projectile.scale = 1.5f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Surtr's Wrath Bolt");
            //Main.projFrames[projectile.type] = 4;
            //ProjectileID.Sets.Homing[projectile.type] = false;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 600);
            //target.AddBuff(BuffID.CursedInferno, 210);
            //target.immune[projectile.owner] = 5; 
        }
    }
}
