using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage      //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly

{
    public class VolcanoProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Volcano");
        }

        public override void SetDefaults()
        {
            projectile.width = 57; //Set the hitbox width
            projectile.height = 50;   //Set the hitbox heinght
            projectile.hostile = false;    //tells the game if is hostile or not.
            projectile.friendly = true;   //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.ignoreWater = true;    //Tells the game whether or not projectile will be affected by water
            Main.projFrames[projectile.type] = 4;  //this is where you add how many frames u'r projectile has to make the animation
            projectile.timeLeft = 7200;  // this is the projectile life time( 60 = 1 second so 900 is 15 seconds )  3600 is 1 min.   
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed  -1 is infinity
            projectile.tileCollide = true; //Tells the game whether or not it can collide with tiles/ terrain
            projectile.sentry = true; //tells the game that this is a sentry
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Item, projectile.Center, 62);    //this make so when this projectile disappear will make this sound.

            for (int i = 0; i < 20; i++) //this is for a loop that makes dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 158, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 3.50f);
                Main.dust[dust].noGravity = false; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 2.5f;
            }
        }

        public override void AI()
        {
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 158, projectile.velocity.X * 0.6f, projectile.velocity.Y * 0.6f, 160, default(Color), 0.8f);
                Main.dust[dust].noGravity = true; //this make so the dust is effected by gravity
                Main.dust[dust].velocity *= 0.9f;
            }
            //projectile.rotation += 0.05f;   //this make the projctile to rotate

            //---------------------------------------------------This make this projectile1 shot another projectile2 to a target if is in between the distance and this projectile1 ------------------------------------------------------------------------


            //Getting the npc to fire at
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                //Getting the shooting trajectory
                float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                //If the distance between the projectile and the live target is active
                    if (distance < 620f && !target.friendly && target.active && target.CanBeChasedBy (target, false))  //distance < 520 this is the projectile1 distance from the target if the target is in that range the this projectile1 will shot the projectile2
                {
                    if (projectile.ai[0] > 120f)//this make so the projectile1 shoot a projectile every 2 seconds(60 = 1 second so 120 = 2 seconds) 
                    {
                        //Dividing the factor of 2f which is the desired velocity by distance
                        distance = 1.6f / distance;

                        //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                        shootToX *= distance * 13;
                        shootToY *= distance * 13;
                        int damage = 50;  //this is the projectile2 damage
                        //Shoot projectile and set ai back to 0
                        {
                            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, ProjectileType<HellBurstFireballProj>(), damage, 0, Main.myPlayer, 0f, 0f);
                            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 24); //24 is the sound, so when this projectile is shot will make that sound
                        }
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
            projectile.frameCounter++;
            if (projectile.frameCounter > 20) //time spet on each frame
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4) //max number of frames
            { projectile.frame = 0; }
        }
    }
}