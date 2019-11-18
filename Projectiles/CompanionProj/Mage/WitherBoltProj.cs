using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class WitherBoltProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(121);
            projectile.width = 34;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.magic = true;
            aiType = 682;
            projectile.aiStyle = 1; //9 magic missle style, trailing, and sounds.
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 270;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.extraUpdates = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Withering Bolt");
            Main.projFrames[projectile.type] = 4;
            ProjectileID.Sets.Homing[projectile.type] = true;

        }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 210);
            target.immune[projectile.owner] = 7;
            target.AddBuff(mod.BuffType("ArmorBreak"), 210);
        }
    }
}
