using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Mage
{
    public class VortexShieldProj : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.Typhoon);
            projectile.width = 82;
            projectile.height = 82;
            projectile.friendly = true;
            projectile.magic = true;
            //aiType = ProjectileID.DemonScythe;
            //projectile.aiStyle = 71; //9 magic missle style, trailing, and sounds.
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 3600;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Shield Attack");
            //Main.projFrames[projectile.type] = 4;
            //ProjectileID.Sets.Homing[projectile.type] = true;

        }

        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.36f, 1.0f, 0.58f);
            projectile.rotation += 0.05f;
            Player player = Main.player[projectile.owner];
            projectile.Center = player.Center;
            #region Target NPC
            //Getting the npc to fire at
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                //Getting the shooting trajectory
                float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                //If the distance between the projectile and the live target is active
                if (distance < 600f && !target.friendly && target.active && target.CanBeChasedBy(target, false))  //distance < 520 max distance to shoot to
                {
                    if (projectile.ai[0] > 8f)// time / 60fps = 0.667 times per 1 second. If time = 60 would be 1 second.
                    {
                        //Dividing the factor of 2f which is the desired velocity by distance
                        distance = 1.6f / distance;

                        //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                        shootToX *= distance * 13;
                        shootToY *= distance * 13;
                        int damage = 140;  //this is the projectile2 damage                   
                                          //Shoot projectile and set ai back to 0
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("VortexOrbProj"), damage, 0, Main.myPlayer, 0f, 0f);
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 12); //24 is the sound, so when this projectile is shot will make that sound
                        projectile.ai[0] = 0f;
                    }
                }
            }
            #endregion
            projectile.ai[0] += 1f;
            if (player.dead || !player.HasBuff(mod.BuffType("VortexShieldBuff")))
            {
                if (player.dead || !player.HasBuff(mod.BuffType("HallowedShieldBuff")))
                {
                    projectile.Kill();
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 210);
        }
    }
}
