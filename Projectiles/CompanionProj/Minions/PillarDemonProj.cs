using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{
    public class PillarDemonProj : AdvancedMelee
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pillar Demon");
            Main.projFrames[projectile.type] = 11;
            //Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.CloneDefaults(317);
            aiType = 317;
            projectile.width = 53;
            projectile.height = 46;
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
            MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>(mod);
            if (player.dead)
            {
                modPlayer.PillarDemonMinion = false;
            }
            if (modPlayer.PillarDemonMinion)
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
                        int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 151);
                        Main.dust[dust].velocity -= 1.2f * dustVel;
                    }

                    Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.58f, 0.65f, 0.77f);
                }
            }

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("CutDebuff"), 240); //bleeding debuff for mobs
        }

        public override void SelectFrame()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8) //this means 8 frames of time on each frame
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 10;
            }
        }
        public override void Behavior()
        {
            Player player = Main.player[projectile.owner];
        }
    }
}