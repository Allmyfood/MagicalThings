using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace MagicalThings.Projectiles.CompanionProj.Warrior	//We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class InfestedProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infested Blade"); //Name of the projectile, only shows this if you get killed by it
        }
        public override void SetDefaults()
        {
            projectile.width = 37;  //Set the hitbox width
            projectile.height = 42; //Set the hitbox height
            projectile.aiStyle = 1; //Is classic beam sword / enchanted sword shot
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.ignoreWater = true;  //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;  //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed, -1 infinity
            projectile.timeLeft = 1250;  //The amount of time the projectile is alive for  
            projectile.extraUpdates = 1;
            projectile.tileCollide = true;
            aiType = ProjectileID.Bullet;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;
            projectile.alpha = 255;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f; //Allows the vertical projectile to be rotated 45°
            Lighting.AddLight((int)(projectile.position.X + (double)(projectile.width / 2)) / 16, (int)(projectile.position.Y + (double)(projectile.height / 2)) / 16, 0.83f, 0.082f, .14f); //default 0.8f, 0.95f, 1f
            if (projectile.timeLeft > 1250)
            {
                projectile.timeLeft = 1249;
            }
            if (projectile.ai[0] > 1f)  //this defines where the flames starts
            {
                if (Main.rand.Next(6) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Shadowflame, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 0.75f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.PurpleCrystalShard, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 0.5f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }

        //public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //{
        //    target.AddBuff(BuffID.Frostburn, 1800);   //this make so when the projectile/flame hit a npc, gives it the buff  onfire , 80 = 3 seconds
        //}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}