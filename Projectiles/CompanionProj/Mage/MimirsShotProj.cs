using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class MimirsShotProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.damage = 250;
            Main.projFrames[projectile.type] = 5;
            projectile.CloneDefaults(ProjectileID.Blizzard); //440
            //aiType = ProjectileID.LaserMachinegunLaser;
            //projectile.aiStyle = 1;
            //projectile.width = 18;
            //projectile.height = 42;
            //projectile.friendly = true;
            //projectile.magic = true;
            //projectile.penetrate = 1; //must be at least 1
            //projectile.tileCollide = false;
            //projectile.timeLeft = 3600;
            //ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            //ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            //projectile.usesLocalNPCImmunity = true;
            projectile.scale = 0.80f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mimir's Wisdom");
            //Main.projFrames[projectile.type] = 4;
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void Kill(int timeLeft)
        {
            #region Vanilla Sounds and Dusts
            Main.PlaySound(SoundID.Item27, projectile.position);
            int num3;
            for (int num511 = 0; num511 < 10; num511 = num3 + 1)
            {
                int num512 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 197, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num512].noGravity = true;
                num3 = num511;
            }
            #endregion
        }


        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.51f, 0.87f, 0.98f);

            #region Vanilla Altitude Blizzard
            if (projectile.position.Y > Main.player[projectile.owner].position.Y - 300f)
            {
                projectile.tileCollide = true;
                if (projectile.position.Y < Main.player[projectile.owner].position.Y + 450f)
                {
                    bool hitEffect = false; // if true, perform a hit effect
                    int droprate = Main.rand.Next(5, 20);
                    projectile.localAI[0] += 1f;
                    // Every 30 ticks, the cloud drops a bomb. Currently 75
                    hitEffect = projectile.localAI[0] % droprate == 0;//75f == 0;
                    if (hitEffect)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ProjectileType<StarFieldProj>(), 140, 0f, projectile.owner);
                    }
                }
            }
            if (projectile.position.Y < Main.worldSurface * 16.0)
            {
                projectile.tileCollide = true;
            }
            projectile.frame = (int)projectile.ai[1];
            if (Main.rand.Next(2) == 0)
            {
                int num185 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 197, 0f, 0f, 0, default(Color), 1f);
                Dust dust3 = Main.dust[num185];
                dust3.velocity *= 0.5f;
                Main.dust[num185].noGravity = true;
            }
            #endregion   
        }
    

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(250, 250, 250, 150);
        }
    }
}
