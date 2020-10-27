using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class PortalRingProj : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser); //439
            projectile.width = 298;
            projectile.height = 298;
            projectile.friendly = true;
            projectile.magic = true;
			//Main.projFrames[projectile.type] = 4; //moved to static
            aiType = ProjectileID.LaserMachinegunLaser;
            //projectile.aiStyle = 139; //9 magic missle style, trailing, and sounds.
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 1740;
            projectile.light = 1.6f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            projectile.usesIDStaticNPCImmunity = true;
            projectile.idStaticNPCHitCooldown = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Hole");
            //Main.projFrames[projectile.type] = 8;
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 1.0f, 0.89f, 0.45f);
            projectile.velocity = projectile.velocity * .001f;
            projectile.rotation -= 0.005f;
            if (projectile.timeLeft == 1260 && projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.Zombie, (int)projectile.position.X, (int)projectile.position.Y, 99);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, ProjectileType<BlackHoleProj>(), 450, 1f, projectile.owner);
            }

            #region Velocity and frame selection
            //if (projectile.frameCounter < 5)
            //    projectile.frame = 0;
            //else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
            //    projectile.frame = 1;
            //else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
            //    projectile.frame = 2;
            //else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
            //    projectile.frame = 3;
            //else if (projectile.frameCounter >= 20 && projectile.frameCounter < 25)
            //    projectile.frame = 4;
            //else if (projectile.frameCounter >= 25 && projectile.frameCounter < 30)
            //    projectile.frame = 5;
            //else if (projectile.frameCounter >= 30 && projectile.frameCounter < 35)
            //    projectile.frame = 6;
            //else if (projectile.frameCounter >= 35 && projectile.frameCounter < 50)
            //    projectile.frame = 7;
            //else

            //    projectile.frameCounter = 0;
            //projectile.frameCounter++;
            #endregion

            #region Dusts
            if (Main.rand.Next(25) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 206,
                projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 150, Scale: 1.2f);
                dust.velocity += projectile.velocity * 0.4f;
                dust.velocity *= 0.2f;
            }
            if (Main.rand.Next(30) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 206,
                    0, 0, 254, Scale: 0.6f);
                dust.velocity += projectile.velocity * 0.5f;
                dust.velocity *= 0.5f;
            }
            #endregion

            #region Blackhole
            for (int i = 0; i < 201; i++)
            {
                Item item = Main.item[i];
                NPC target = Main.npc[i];
                if (!Main.npc[i].boss && !Main.npc[i].townNPC && !target.friendly && target.active && target.CanBeChasedBy(target, false))
                {
                    double dist = Math.Sqrt(Math.Pow(projectile.Center.X - Main.npc[i].position.X, 2) + Math.Pow(projectile.Center.Y - Main.npc[i].position.Y, 2));
                   
                    #region Ring Gravity Pull
                    if (dist <= 650.0f) //will pull any npc within 400f
                    {
                        if (target.position.X < projectile.Center.X && Main.npc[i].velocity.X < 3.0f) //smooth pulling methods
                        {
                            target.velocity.X += (float)dist / 650.0f;
                        }
                        else if (Main.npc[i].position.X > projectile.Center.X && Main.npc[i].velocity.X > -3.0f)
                        {
                            Main.npc[i].velocity.X -= (float)dist / 650.0f;
                        }
                        if (Main.npc[i].position.Y < projectile.Center.Y && Main.npc[i].velocity.Y < 3.0f)
                        {
                            Main.npc[i].velocity.Y += (float)dist / 650.0f;
                        }
                        else if (Main.npc[i].position.Y > projectile.Center.Y && Main.npc[i].velocity.Y > -3.0f)
                        {
                            Main.npc[i].velocity.Y -= (float)dist / 650.0f;
                        }
                    }
                    #endregion
                }
                if (!Main.item[i].isBeingGrabbed )
                {
                    double dist = Math.Sqrt(Math.Pow(projectile.Center.X - Main.item[i].position.X, 2) + Math.Pow(projectile.Center.Y - Main.item[i].position.Y, 2));
                    if (item.Hitbox.Intersects(projectile.Hitbox)) //npc hitbox touches projectile hit box
                    {
                        item.position = projectile.Center; //will attach a npc to the projectile. If projectile returns to the player so does the npc.
                    }
                    #region Ring Gravity Pull Items
                    if (dist <= 450.0f) //will pull any npc within 400f
                    {
                        if (item.position.X < projectile.Center.X && Main.item[i].velocity.X < 3.0f) //smooth pulling methods
                        {
                            item.velocity.X += (float)dist / 650.0f;
                        }
                        else if (Main.item[i].position.X > projectile.Center.X && Main.item[i].velocity.X > -3.0f)
                        {
                            Main.item[i].velocity.X -= (float)dist / 650.0f;
                        }
                        if (Main.item[i].position.Y < projectile.Center.Y && Main.item[i].velocity.Y < 3.0f)
                        {
                            Main.item[i].velocity.Y += (float)dist / 650.0f;
                        }
                        else if (Main.item[i].position.Y > projectile.Center.Y && Main.item[i].velocity.Y > -3.0f)
                        {
                            Main.item[i].velocity.Y -= (float)dist / 650.0f;
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region Fade In/Out

            if (projectile.alpha > 51)
            {
                projectile.alpha -= 5;
            }        
            
            #endregion
        }

        #region On Hit NPC Effecs
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //target.AddBuff(BuffID.Frostburn, 240);
            //target.immune[projectile.owner] = 5;
            #region Steal Health
            if (projectile.owner == Main.myPlayer) //do life steal if hp is less than max.
            {
                Player owner = Main.player[projectile.owner];
                if (owner.statLife < owner.statLifeMax)
                {
                    if (owner.lifeSteal <= 0f) return;
                    float heal = damage / 10;
                    if (projectile.penetrate >= 0) heal = damage / 10;
                    owner.lifeSteal -= heal;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, ProjectileID.SpiritHeal, 0, 0f, projectile.owner, (float)projectile.owner, heal);
                }
            }
            #endregion
        }
        #endregion

        #region Explode Lunar Flare
        public override void Kill(int timeLeft) //act like a flask explosion
        {
            Player player = Main.player[projectile.owner];
            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 62);
            //Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType("CollapsingStarFlashProj"), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(5, 15);//20,31
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-50, 50), Main.rand.Next(-50, 50));
                    value17.Normalize();
                    value17 *= Main.rand.Next(20, 302) * 0.01f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value17.X, value17.Y, ProjectileID.LunarFlare, projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-30, 2));
                }
            }
        }
        #endregion
    }
}
