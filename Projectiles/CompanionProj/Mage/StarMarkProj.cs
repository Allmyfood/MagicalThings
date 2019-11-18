using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class StarMarkProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.magic = true;
            //aiType = 9;
            projectile.aiStyle = 9; //magic missle style, trailing, and sounds.
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Mark");
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }
        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 34, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.9f);
            Main.dust[dust].noGravity = true;
        }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 85);
        }
    }
}
