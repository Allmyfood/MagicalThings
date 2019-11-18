using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{
    public class ShadowHammerProj : Minion4
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Hammer");
            Main.projFrames[projectile.type] = 21;
            //Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.CloneDefaults(533);
            aiType = 533;
            projectile.width = 82;
            projectile.height = 82;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = .5f;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.tileCollide = false;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.tileCollide = false;
            }
            return false;
        }

        public override void CheckActive()
        {
            //projectile.spriteDirection = projectile.direction = (projectile.velocity.X > 0).ToDirectionInt();
            //projectile.rotation = projectile.velocity.ToRotation() + (projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
            Player player = Main.player[projectile.owner];
            MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
            if (player.dead)
            {
                modPlayer.ShadowHammerMinion = false;
            }
            if (modPlayer.ShadowHammerMinion)
            {
                projectile.timeLeft = 2;
            }
            //Dusts
            if (projectile.ai[0] == 0f)
            {
                if (Main.rand.Next(55) == 0)
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 173);
                    Main.dust[dust].velocity.Y -= 2.2f;
                }

                else
                {
                    if (Main.rand.Next(35) == 0)
                    {
                        Vector2 dustVel = projectile.velocity;
                        if (dustVel != Vector2.Zero)
                        {
                            dustVel.Normalize();
                        }
                        int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 173);
                        Main.dust[dust].velocity -= 1.2f * dustVel;
                    }

                    Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.85f, 0.69f, 1.0f);
                }
            }

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 210);
        }

        public override void SelectFrame()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 20;
            }
        }
    }
}