using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class BoneStormProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(21);
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.magic = true;
            aiType = 21;
            projectile.aiStyle = 2;
            //projectile.penetrate = -1;
            //projectile.timeLeft = 1200;
            projectile.tileCollide = true;
            //ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            //ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Strom");
        }

        //public override void AI()
        //{
        //    projectile.friendly = true;
        //}
        //public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //{
        //    target.AddBuff(BuffID.Poisoned, 30);
        //}
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
                Main.PlaySound(SoundID.NPCHit2.WithVolume(.25f), projectile.position);
        }
    }
}
