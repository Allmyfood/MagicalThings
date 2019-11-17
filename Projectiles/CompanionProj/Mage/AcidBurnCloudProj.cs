using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class AcidBurnCloudProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 5;
            projectile.CloneDefaults(ProjectileID.ToxicCloud); //440
            projectile.damage = 75;
            aiType = 511;
            projectile.aiStyle = 92;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1; //must be at least 1 or -1 for infnite
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
            projectile.scale = 1.5f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Burn");
            //Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = false;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Venom, 210);
            target.AddBuff(BuffID.CursedInferno, 210);
            target.immune[projectile.owner] = 8; 
        }
    }
}
