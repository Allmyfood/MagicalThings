﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.CompanionProj.Warrior
{
    public class BoneNaginataProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Naginata");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1.1f;
            projectile.alpha = 0;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                target.AddBuff(mod.BuffType("ArmorBreak"), 60); //60 is the buff time
            }
        }

        // In here the AI uses this example, to make the code more organized and readable
        // Also showcased in ExampleJavelinProjectile.cs
        public float movementFactor // Change this value to alter how fast the spear moves
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        // It appears that for this AI, only the ai0 field is used!
        public override void AI()
        {
            // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            // Sadly, Projectile/ModProjectile does not have its own
            Player projOwner = Main.player[projectile.owner];
            // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            // As long as the player isn't frozen, the spear can move
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
                {
                    movementFactor = 2.0f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
                {
                    movementFactor -= 1.7f;
                }
                else // Otherwise, increase the movement factor
                {
                    movementFactor += 1.6f;
                }
            }
            // Change the spear position based off of the velocity and the movementFactor
            projectile.position += projectile.velocity * movementFactor;
            // When we reach the end of the animation, we can kill the spear projectile
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
            // MathHelper.ToRadians(xx degrees here)
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
            // Offset by 90 degrees here
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
            //if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3) //code to shoot projectiles when spear is extended with a clear shot, not at lower angles.
            //{
            //    projectile.ai[0] -= 1.1f;
            //    if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
            //    {
            //        projectile.localAI[0] = 1f;
            //        if (Collision.CanHit(Main.player[projectile.owner].position, Main.player[projectile.owner].width, Main.player[projectile.owner].height, new Vector2(projectile.Center.X + projectile.velocity.X * projectile.ai[0], projectile.Center.Y + projectile.velocity.Y * projectile.ai[0]), projectile.width, projectile.height))
            //        {
            //            int z = Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X, projectile.Center.Y + projectile.velocity.Y, projectile.velocity.X * 1.5f, projectile.velocity.Y * 1.5f, ModContent.ProjectileType("SpitProj"), projectile.damage, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
            //            Main.projectile[z].tileCollide = true;
            //            Main.projectile[z].timeLeft = 240;
            //        }

            //        // These dusts are added later, for the 'ExampleMod' effect
            //        //if (Main.rand.Next(3) == 0)
            //        //{
            //        //	Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType<Dusts.Sparkle>(),
            //        //		projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
            //        //	dust.velocity += projectile.velocity * 0.3f;
            //        //	dust.velocity *= 0.2f;
            //        //}
            //        //if (Main.rand.Next(4) == 0)
            //        //{
            //        //	Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType<Dusts.Sparkle>(),
            //        //		0, 0, 254, Scale: 0.3f);
            //        //	dust.velocity += projectile.velocity * 0.5f;
            //        //		dust.velocity *= 0.5f;
            //        //}
            //    }
            //}
        }
    }
}
