using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Ninja
{
    public class TwistingNebulaProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twisting Nebula");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
        }

        public override void SetDefaults()
        {
            projectile.damage = 140;
            projectile.width = 56;               //The width of projectile hitbox
            projectile.height = 64;              //The height of projectile hitbox
            projectile.aiStyle = 3;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.thrown = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = -1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 0.50f;            //How much light emit around the projectile
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = false;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;
            aiType = ProjectileID.PossessedHatchet;           //Act exactly like default Bullet
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("CutDebuff"), 150);
            target.immune[projectile.owner] = 5;
            #region Drop Nebula booster chance
            if (projectile.owner == Main.myPlayer && !target.friendly && target.active && target.CanBeChasedBy(target, false))
            {
                if (Main.rand.NextFloat() < .5000f)
                {
                    int choice = Main.rand.Next(2);
                    if (choice == 0)
                    {
                        Item.NewItem((int)target.position.X + (Main.rand.Next(target.width) * 2), (int)target.position.Y + (Main.rand.Next(target.height) * -6), 2, 2, ItemID.NebulaPickup1, Main.rand.Next(1, 4));
                    }
                    else if (choice == 1)
                    {
                        Item.NewItem((int)target.position.X + (Main.rand.Next(target.width) * 2), (int)target.position.Y + (Main.rand.Next(target.height) * -6), 2, 2, ItemID.NebulaPickup2, Main.rand.Next(1, 4));
                    }
                }
                return;
            }
            #endregion
        }

        public override void AI() //Will make the projectile and make it real. 480 is projectile ID. .52f is additional damage
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.99f, 0.42f, 0.89f);
        }

    }
}
