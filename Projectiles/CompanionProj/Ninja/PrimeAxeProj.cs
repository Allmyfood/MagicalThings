using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Ninja
{
    public class PrimeAxeProj : ModProjectile
    {
        int type = 389; //projectile shot id
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Axe");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
        }

        public override void SetDefaults()
        {
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
            target.AddBuff(mod.BuffType("ArmorBreak"), 210);
        }

        public override void AI() //Will make the projectile and make it real. 480 is projectile ID. .52f is additional damage
        {
            if (Main.rand.Next(25) == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, type, (int)(0.52f * projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
            }
        }
    }
}
