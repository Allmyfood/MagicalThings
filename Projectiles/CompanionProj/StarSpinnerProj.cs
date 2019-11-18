using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj
{
    public class StarSpinnerProj : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 28;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.aiStyle = 18;
            projectile.penetrate = 3;
            projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Spinner");

        }

        public override void AI()
        {
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 1, projectile.height + 1, 15, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f); //Create Dust 15 = White and blue magic fx
        }
    }
}
