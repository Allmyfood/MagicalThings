using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles
{
	public class MugenProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(595); //Arkhalis clone
			aiType = 595;
            projectile.aiStyle = 75;
            Main.projFrames[mod.ProjectileType("MugenProj")] = 28;            
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.width = 100;
            projectile.height = 100;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mugen Blade");

		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 3; //the time allowed to be immune to damage default 10 Arkhalis is 5
            target.AddBuff(mod.BuffType("ArmorBreak"), 2400); //2400 / 60 = secs, the buff time; 40 seconds.
            target.AddBuff(BuffID.CursedInferno, 2400);
        }

        public override void AI()
        {
            if (Main.myPlayer == projectile.owner)
            {
                //Do net update. Syncs this projectile.
                if (Main.rand.Next(3) == 0)
                {
                    int num30 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 107, projectile.velocity.X, projectile.velocity.Y, 150, default(Color), 2f);
                    Main.dust[num30].noGravity = true;
                    Main.dust[num30].position -= projectile.velocity;
                }
                projectile.netUpdate = true;
                Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                if (Main.player[projectile.owner].Center.Y < mouse.Y)
                {
                    float Xdis = Main.player[Main.myPlayer].Center.X - mouse.X;  // change myplayer to nearest player in full version
                    float Ydis = Main.player[Main.myPlayer].Center.Y - mouse.Y; // change myplayer to nearest player in full version
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    float DistXT = (float)(Math.Sin(Angle) * 29);
                    float DistYT = (float)(Math.Cos(Angle) * 29);
                    projectile.position.X = (Main.player[projectile.owner].Center.X + DistXT) - 40; // 30;
                    projectile.position.Y = (Main.player[projectile.owner].Center.Y + DistYT) - 30; // 30;
                }
                if (Main.player[projectile.owner].Center.Y >= mouse.Y)
                {
                    float Xdis = Main.player[Main.myPlayer].Center.X - mouse.X;  // change myplayer to nearest player in full version
                    float Ydis = Main.player[Main.myPlayer].Center.Y - mouse.Y; // change myplayer to nearest player in full version
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    float DistXT = (float)(Math.Sin(Angle) * 29);
                    float DistYT = (float)(Math.Cos(Angle) * 29);
                    projectile.position.X = (Main.player[projectile.owner].Center.X + (0 - DistXT)) - 30;  //30;
                    projectile.position.Y = (Main.player[projectile.owner].Center.Y + (0 - DistYT)) - 30;  //30;
                }
                #region Great Slash with Armor
                Player player = Main.player[projectile.owner];
                var mpm = player.GetModPlayer<MagicalPlayer>();
                if (mpm.MugenArmorEquiped == true)
                {
                    if (Main.rand.Next(6) == 0)
                    {
                        Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                        //position = SPos;
                        //Getting the shooting trajectory
                        float shootToX = target.X + projectile.width * 0.5f - projectile.Center.X;
                        float shootToY = target.Y + projectile.height * 0.5f - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt(shootToX * shootToX + shootToY * shootToY);
                        //Dividing the factor of 2f which is the desired velocity by distance
                        distance = 1.6f / distance;
                        //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 880;
                        {
                            Main.PlaySound(SoundID.Item125.WithVolume(0.5f), projectile.position);
                            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("MugenGreatSlashProj"), damage, 0, Main.myPlayer, 0f, 0f);
                            //Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity, mod.ProjectileType("InfestedProj"), projectile.damage, projectile.knockBack, projectile.owner);
                            //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("InfestedProj"), projectile.damage, 0, Main.myPlayer);
                        }
                    }
                }
                #endregion

                #region Great Slash without Armor
                if (mpm.MugenArmorEquiped == false)
                {
                    if (Main.rand.Next(25) == 0)
                    {
                        Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                        //position = SPos;
                        //Getting the shooting trajectory
                        float shootToX = target.X + projectile.width * 0.5f - projectile.Center.X;
                        float shootToY = target.Y + projectile.height * 0.5f - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt(shootToX * shootToX + shootToY * shootToY);
                        //Dividing the factor of 2f which is the desired velocity by distance
                        distance = 1.6f / distance;
                        //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 880;
                        {
                            Main.PlaySound(SoundID.Item125.WithVolume(0.5f), projectile.position);
                            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("MugenGreatSlashProj"), damage, 0, Main.myPlayer, 0f, 0f);
                            //Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity, mod.ProjectileType("InfestedProj"), projectile.damage, projectile.knockBack, projectile.owner);
                            //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("InfestedProj"), projectile.damage, 0, Main.myPlayer);
                        }
                    }
                }
                #endregion
            }
        }
    }
}
