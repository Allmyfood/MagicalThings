using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MagicalThings.Items.Companion.Ranger.Tier8;

namespace MagicalThings.Projectiles.CompanionProj.Ranger
{
    public class RazorArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Razor Arrow");     //Name of the projectile
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            aiType = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 1200;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("CutDebuff"), 300);
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 0, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
            if (projectile.owner == Main.myPlayer && Main.rand.NextFloat() < .125f)
            {
                Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, ItemType<RazorArrow>(), 1, false, 0);
            }
        }
    }
}
