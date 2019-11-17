using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Ninja
{
    public class SpectralLabrysProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Labrys");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
        }

        public override void SetDefaults()
        {
            projectile.damage = 90;
            projectile.width = 30;               //The width of projectile hitbox
            projectile.height = 30;              //The height of projectile hitbox
            projectile.aiStyle = 3;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.thrown = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = -1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 0.50f;            //How much light emit around the projectile
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;
            aiType = ProjectileID.PossessedHatchet;           //Act exactly like default Bullet
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //projectile.ghostHeal(damage, projectile.position); //only works by default for magic based weapons
            if (projectile.owner == Main.myPlayer) //do life steal if hp is less than max.
            {
                Player owner = Main.player[projectile.owner];
                if (owner.statLife < owner.statLifeMax)
                {
                    if (owner.lifeSteal <= 0f) return;
                    float heal = damage / 10;
                    if (projectile.penetrate >= 0) heal = damage / 10;
                    owner.lifeSteal -= heal;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, 298, 0, 0f, projectile.owner, (float)projectile.owner, heal);
                }
            }
        }

        public override void AI() //Will make the projectile and make it real. 480 is projectile ID. .52f is additional damage
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.58f, 1.0f, 1.0f);
        }

    }
}
