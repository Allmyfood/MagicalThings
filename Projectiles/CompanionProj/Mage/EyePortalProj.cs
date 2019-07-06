using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage      //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly

{
    public class EyePortalProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye Portal");
        }

        public override void SetDefaults()
        {
            projectile.width = 52; //Set the hitbox width
            projectile.height = 51;   //Set the hitbox heinght
            projectile.hostile = false;    //tells the game if is hostile or not.
            projectile.friendly = true;   //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.ignoreWater = true;    //Tells the game whether or not projectile will be affected by water
            Main.projFrames[projectile.type] = 1;  //this is where you add how many frames u'r projectile has to make the animation
            projectile.timeLeft = 7200;  // this is the projectile life time( 60 = 1 second so 900 is 15 seconds )  3600 is 1 min.   
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed  -1 is infinity
            projectile.tileCollide = true; //Tells the game whether or not it can collide with tiles/ terrain
            projectile.sentry = true; //tells the game that this is a sentry
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(2, projectile.Center, 62);    //this make so when this projectile disappear will make this sound. you can find all the sound ID here: https://github.com/bluemagic123/tModLoader/wiki/Vanilla-Sound-IDs

            for (int i = 0; i < 20; i++) //this is for a loop that makes dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.LunarOre, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 3.50f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = false; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 2.5f;
            }
        }

        public override void AI()
        {
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.SparksMech, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 1.50f);   //this make so when this projectile is active has dust around , change PinkFlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust is effected by gravity
                Main.dust[dust].velocity *= 0.9f;
            }
            projectile.rotation += 0.05f;   //this make the projctile to rotate

            //---------------------------------------------------This make this projectile1 shot another projectile2 to a target if is in between the distance and this projectile1 ------------------------------------------------------------------------


            //Getting the npc to fire at
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                //Getting the shooting trajectory
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                //If the distance between the projectile and the live target is active
          //          if (target.active && target.immune[player.whoAmI] <= 0 && !target.dontTakeDamage && target.Distance(minecartMechPoint) < 300f && target.CanBeChasedBy(player, false) && Collision.CanHitLine(target.position, target.width, target.height, minecartMechPoint, 0, 0) && Math.Abs(MathHelper.WrapAngle(MathHelper.WrapAngle(target.AngleFrom(minecartMechPoint)) - MathHelper.WrapAngle((player.fullRotation + (float)num5 == -1f) ? 3.14159274f : 0f))) < 0.7853982f)
                    if (distance < 520f && !target.friendly && target.active && target.CanBeChasedBy (target, false))  //distance < 520 this is the projectile1 distance from the target if the target is in that range the this projectile1 will shot the projectile2
                {
                    if (projectile.ai[0] > 40f)//this make so the projectile1 shoot a projectile every 2 seconds(60 = 1 second so 120 = 2 seconds) 
                    {
                        //Dividing the factor of 2f which is the desired velocity by distance
                        distance = 1.6f / distance;

                        //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 24;  //this is the projectile2 damage                   
                                          //Shoot projectile and set ai back to 0
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("InfestedProj"), damage, 0, Main.myPlayer, 0f, 0f); //Spawning a projectile mod.ProjectileType("FlamethrowerProj") is an example of how to spawn a modded projectile. if you want to shot a terraria prjectile add instead ProjectileID.Nameofterrariaprojectile
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 24); //24 is the sound, so when this projectile is shot will make that sound
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
        }
    }
}