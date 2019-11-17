using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Ninja
{
    public class IzanamiFaintProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Izanami");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
        }

        public override void SetDefaults()
        {
            projectile.damage = 450;
            projectile.width = 78;               //The width of projectile hitbox
            projectile.height = 70;              //The height of projectile hitbox
            projectile.aiStyle = 18;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.thrown = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = -1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 255;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 0.50f;            //How much light emit around the projectile
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = false;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;
            aiType = ProjectileID.DeathSickle;           //Act exactly like default Bullet
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 0;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("CutDebuff"), 270);
            target.immune[projectile.owner] = 4;
        }

        public override void AI() //Will make the projectile and make it real. 480 is projectile ID. .52f is additional damage
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.63f, 0.28f, 0.64f);
            projectile.alpha += 1;
            if (projectile.alpha > 255)
            {
                projectile.alpha = 255; // Increase alpha, decreasing visibility.
            }
        }

    }
}
