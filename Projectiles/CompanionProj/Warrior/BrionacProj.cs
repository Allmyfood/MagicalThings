using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MagicalThings.Projectiles.CompanionProj.Warrior
{
    public class BrionacProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brionac");
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 113;
            projectile.penetrate = -1;
            //projectile.scale = 1.1f; //usually 1.1
            //projectile.alpha = 0;
            projectile.hide = true;
            //projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.netImportant = true;
            projectile.usesLocalNPCImmunity = true; // Invincibility acts per individual projectile
            projectile.localNPCHitCooldown = projectile.timeLeft;
        }

        #region On NPC Hit
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                target.immune[projectile.owner] = 3;
            }
        }
        #endregion

        #region Draw Behind
        // See ExampleBehindTilesProjectile. 
        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            // If attached to an NPC, draw behind tiles (and the npc) if that NPC is behind tiles, otherwise just behind the NPC.
            if (projectile.ai[0] == 1f) // or if(isStickingToTarget) since we made that helper method.
            {
                int npcIndex = (int)projectile.ai[1];
                if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
                {
                    if (Main.npc[npcIndex].behindTiles)
                        drawCacheProjsBehindNPCsAndTiles.Add(index);
                    else
                        drawCacheProjsBehindNPCs.Add(index);
                    return;
                }
            }
            // Since we aren't attached, add to this list
            drawCacheProjsBehindProjectiles.Add(index);
        }
        #endregion

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            // For going through platforms and such, javelins use a tad smaller size
            width = height = 10; // notice we set the width to the height, the height to 10. so both are 10
            return true;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // Inflate some target hitboxes if they are beyond 8,8 size
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            // Return if the hitboxes intersects, which means the javelin collides or not
            return projHitbox.Intersects(targetHitbox);
        }

        #region On Kill Proj
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
            Vector2 usePos = projectile.position; // Position to use for dusts
                                                  // Please note the usage of MathHelper, please use this! We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
            Vector2 rotVector =
                (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
            usePos += rotVector * 16f;

            // Spawn some dusts upon javelin death
            for (int i = 0; i < 10; i++)
            {
                // Create a new dust
                Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 271);
                dust.position = (dust.position + projectile.Center) / 2f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotVector * 8f;
            }
            #region Explosion
            Main.PlaySound(SoundID.Item14, projectile.position);
            projectile.damage = projectile.damage * 5;
            projectile.position = projectile.Center;
            projectile.width = (projectile.height = 160);//80
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            int num3;
            for (int num313 = 0; num313 < 4; num313 = num3 + 1)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 228, 0f, 0f, 100, default(Color), 1.5f);
                num3 = num313;
            }
            for (int num314 = 0; num314 < 40; num314 = num3 + 1)
            {
                int num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 200, default(Color), 2.5f);
                Main.dust[num315].noGravity = true;
                Dust dust = Main.dust[num315];
                dust.velocity *= 2f;
                num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 200, default(Color), 1.5f);
                dust = Main.dust[num315];
                dust.velocity *= 1.2f;
                Main.dust[num315].noGravity = true;
                num3 = num314;
            }
            for (int num316 = 0; num316 < 1; num316 = num3 + 1)
            {
                int num317 = Gore.NewGore(projectile.position + new Vector2((float)(projectile.width * Main.rand.Next(100)) / 100f, (float)(projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, default(Vector2), Main.rand.Next(61, 64), 1f);
                Gore gore = Main.gore[num317];
                gore.velocity *= 0.3f;
                Gore gore41 = Main.gore[num317];
                gore41.velocity.X = gore41.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
                Gore gore42 = Main.gore[num317];
                gore42.velocity.Y = gore42.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
                num3 = num316;
            }
            projectile.Damage();
            #endregion

        }
        #endregion

        // Here's an example on how you could make your AI even more readable, by giving AI fields more descriptive names
        // These are not used in AI, but it is good practice to apply some form like this to keep things organized

        // Are we sticking to a target?
        public bool isStickingToTarget
        {
            get { return projectile.ai[0] == 1f; }
            set { projectile.ai[0] = value ? 1f : 0f; }
        }

        // WhoAmI of the current target
        public float targetWhoAmI
        {
            get { return projectile.ai[1]; }
            set { projectile.ai[1] = value; }
        }

        #region Modify NPC Hit
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit,
            ref int hitDirection)
        {
            // If you'd use the example above, you'd do: isStickingToTarget = 1f;
            // and: targetWhoAmI = (float)target.whoAmI;
            isStickingToTarget = true; // we are sticking to a target
            targetWhoAmI = (float)target.whoAmI; // Set the target whoAmI
            projectile.velocity =
                (target.Center - projectile.Center) *
                0.75f; // Change velocity based on delta center of targets (difference between entity centers)
            projectile.netUpdate = true; // netUpdate this javelin
            target.AddBuff(ModContent.BuffType<Buffs.CompanionBuffs.BrionacBuff>(), 1000); // Adds the ExampleJavelin debuff for a very small DoT

            projectile.damage = projectile.damage; // Makes sure the sticking javelins do not deal damage anymore

            // The following code handles the javelin sticking to the enemy hit.
            int maxStickingJavelins = 16; // This is the max. amount of javelins being able to attach
            Point[] stickingJavelins = new Point[maxStickingJavelins]; // The point array holding for sticking javelins
            int javelinIndex = 0; // The javelin index
            for (int i = 0; i < Main.maxProjectiles; i++) // Loop all projectiles
            {
                Projectile currentProjectile = Main.projectile[i];
                if (i != projectile.whoAmI // Make sure the looped projectile is not the current javelin
                    && currentProjectile.active // Make sure the projectile is active
                    && currentProjectile.owner == Main.myPlayer // Make sure the projectile's owner is the client's player
                    && currentProjectile.type == projectile.type // Make sure the projectile is of the same type as this javelin
                    && currentProjectile.ai[0] == 1f // Make sure ai0 state is set to 1f (set earlier in ModifyHitNPC)
                    && currentProjectile.ai[1] == (float)target.whoAmI
                ) // Make sure ai1 is set to the target whoAmI (set earlier in ModifyHitNPC)
                {
                    stickingJavelins[javelinIndex++] =
                        new Point(i, currentProjectile.timeLeft); // Add the current projectile's index and timeleft to the point array
                    if (javelinIndex >= stickingJavelins.Length
                    ) // If the javelin's index is bigger than or equal to the point array's length, break
                    {
                        break;
                    }
                }
            }
            // Here we loop the other javelins if new javelin needs to take an older javelin's place.
            if (javelinIndex >= stickingJavelins.Length)
            {
                int oldJavelinIndex = 0;
                // Loop our point array
                for (int i = 1; i < stickingJavelins.Length; i++)
                {
                    // Remove the already existing javelin if it's timeLeft value (which is the Y value in our point array) is smaller than the new javelin's timeLeft
                    if (stickingJavelins[i].Y < stickingJavelins[oldJavelinIndex].Y)
                    {
                        oldJavelinIndex = i; // Remember the index of the removed javelin
                    }
                }
                // Remember that the X value in our point array was equal to the index of that javelin, so it's used here to kill it.
                Main.projectile[stickingJavelins[oldJavelinIndex].X].Kill();
                #region Explosion
                Main.PlaySound(SoundID.Item14, projectile.position);
                projectile.damage = projectile.damage * 5;
                projectile.position = projectile.Center;
                projectile.width = (projectile.height = 160);//80
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                int num3;
                for (int num313 = 0; num313 < 4; num313 = num3 + 1)
                {
                    Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 228, 0f, 0f, 100, default(Color), 1.5f);
                    num3 = num313;
                }
                for (int num314 = 0; num314 < 40; num314 = num3 + 1)
                {
                    int num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 200, default(Color), 2.5f);
                    Main.dust[num315].noGravity = true;
                    Dust dust = Main.dust[num315];
                    dust.velocity *= 2f;
                    num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 200, default(Color), 1.5f);
                    dust = Main.dust[num315];
                    dust.velocity *= 1.2f;
                    Main.dust[num315].noGravity = true;
                    num3 = num314;
                }
                for (int num316 = 0; num316 < 1; num316 = num3 + 1)
                {
                    int num317 = Gore.NewGore(projectile.position + new Vector2((float)(projectile.width * Main.rand.Next(100)) / 100f, (float)(projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, default(Vector2), Main.rand.Next(61, 64), 1f);
                    Gore gore = Main.gore[num317];
                    gore.velocity *= 0.3f;
                    Gore gore41 = Main.gore[num317];
                    gore41.velocity.X = gore41.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
                    Gore gore42 = Main.gore[num317];
                    gore42.velocity.Y = gore42.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
                    num3 = num316;
                }
                projectile.Damage();
                #endregion
            }
        }
        #endregion

        // Added these 2 constant to showcase how you could make AI code cleaner by doing this
        // Change this number if you want to alter how long the javelin can travel at a constant speed
        private const float maxTicks = 1250f;

        // Change this number if you want to alter how the alpha changes
        private const int alphaReduction = 15;

        #region AI overrides
        public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.92f, 0.13f, 0.23f);
            // Slowly remove alpha as it is present
            if (projectile.alpha > 0)
            {
                projectile.alpha -= alphaReduction;
            }
            // If alpha gets lower than 0, set it to 0
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }

            #region Homing and Dusts
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 200f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && Main.npc[k].CanBeChasedBy(projectile, false) && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f; //11f
                AdjustMagnitude(ref projectile.velocity);
            }
            if (projectile.alpha <= 100)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 271, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 155, default(Color), 0.4f);
                Main.dust[dust].velocity /= 1f;
            }
            #endregion

            #region Not Sticking to Target
            // If ai0 is 0f, run this code. This is the 'movement' code for the javelin as long as it isn't sticking to a target
            //if (!isStickingToTarget)
            //{
            //    targetWhoAmI += 1f;
            //    // For a little while, the javelin will travel with the same speed, but after this, the javelin drops velocity very quickly.
            //    if (targetWhoAmI >= maxTicks)
            //    {
            //        // Change these multiplication factors to alter the javelin's movement change after reaching maxTicks
            //        float velXmult = 0.999f; // x velocity factor, every AI update the x velocity will be 98% of the original speed
            //        float
            //            velYmult = 0.05f; // y velocity factor, every AI update the y velocity will be be 0.35f bigger of the original speed, causing the javelin to drop to the ground
            //        targetWhoAmI = maxTicks; // set ai1 to maxTicks continuously
            //        projectile.velocity.X = projectile.velocity.X * velXmult;
            //        projectile.velocity.Y = projectile.velocity.Y + velYmult;
            //    }
            //    // Make sure to set the rotation accordingly to the velocity, and add some to work around the sprite's rotation
            //    projectile.rotation =
            //        projectile.velocity.ToRotation() +
            //        MathHelper.ToRadians(
            //            90f); // Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!

            //    // Spawn some random dusts as the javelin travels
            //    if (Main.rand.Next(20) == 0)
            //    {
            //        Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 271,
            //            projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 150, Scale: 1.2f);
            //        dust.velocity += projectile.velocity * 0.4f;
            //        dust.velocity *= 0.2f;
            //    }
            //    if (Main.rand.Next(30) == 0)
            //    {
            //        Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 271,
            //            0, 0, 254, Scale: 0.6f);
            //        dust.velocity += projectile.velocity * 0.5f;
            //        dust.velocity *= 0.5f;
            //    }
            //}
            #endregion
            // This code is ran when the javelin is sticking to a target
            if (isStickingToTarget)
            {
                // These 2 could probably be moved to the ModifyNPCHit hook, but in vanilla they are present in the AI
                projectile.ignoreWater = true; // Make sure the projectile ignores water
                projectile.tileCollide = false; // Make sure the projectile doesn't collide with tiles anymore
                int aiFactor = 15; // Change this factor to change the 'lifetime' of this sticking javelin
                bool killProj = false; // if true, kill projectile at the end
                bool hitEffect = false; // if true, perform a hit effect
                projectile.localAI[0] += 1f;
                // Every 30 ticks, the javelin will perform a hit effect
                hitEffect = projectile.localAI[0] % 15f == 0f;
                int projTargetIndex = (int)targetWhoAmI;
                if (projectile.localAI[0] >= (float)(60 * aiFactor)// If it's time for this javelin to die, kill it
                    || (projTargetIndex < 0 || projTargetIndex >= 200)) // If the index is past its limits, kill it
                {
                    killProj = true;
                }
                else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) // If the target is active and can take damage
                {
                    // Set the projectile's position relative to the target's center
                    projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
                    projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
                    if (hitEffect) // Perform a hit effect here
                    {
                        Main.npc[projTargetIndex].HitEffect(0, 1.0);
                    }
                }
                else // Otherwise, kill the projectile
                {
                    killProj = true;
                }

                if (killProj) // Kill the projectile
                {
                    #region Explosion
                    Main.PlaySound(SoundID.Item14, projectile.position);
                    projectile.damage = projectile.damage * 5;
                    projectile.position = projectile.Center;
                    projectile.width = (projectile.height = 160);//80
                    projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                    projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                    int num3;
                    for (int num313 = 0; num313 < 4; num313 = num3 + 1)
                    {
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 228, 0f, 0f, 100, default(Color), 1.5f);
                        num3 = num313;
                    }
                    for (int num314 = 0; num314 < 40; num314 = num3 + 1)
                    {
                        int num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 200, default(Color), 2.5f);
                        Main.dust[num315].noGravity = true;
                        Dust dust = Main.dust[num315];
                        dust.velocity *= 2f;
                        num315 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, 0f, 0f, 200, default(Color), 1.5f);
                        dust = Main.dust[num315];
                        dust.velocity *= 1.2f;
                        Main.dust[num315].noGravity = true;
                        num3 = num314;
                    }
                    for (int num316 = 0; num316 < 1; num316 = num3 + 1)
                    {
                        int num317 = Gore.NewGore(projectile.position + new Vector2((float)(projectile.width * Main.rand.Next(100)) / 100f, (float)(projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, default(Vector2), Main.rand.Next(61, 64), 1f);
                        Gore gore = Main.gore[num317];
                        gore.velocity *= 0.3f;
                        Gore gore41 = Main.gore[num317];
                        gore41.velocity.X = gore41.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
                        Gore gore42 = Main.gore[num317];
                        gore42.velocity.Y = gore42.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
                        num3 = num316;
                    }
                    projectile.Damage();
                    #endregion
                    projectile.Kill();
                }
            }
        }
        #endregion

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 25f)
            {
                vector *= 35f / magnitude;
            }
        }
        #region Draw Afterimage
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D t = Main.projectileTexture[projectile.type];
            int frameHeight = t.Height / Main.projFrames[projectile.type];
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection < 0) effects = SpriteEffects.FlipHorizontally;
            if (projectile.localAI[0] < 0) effects = effects | SpriteEffects.FlipVertically;
            Vector2 origin = new Vector2(t.Width / 2, frameHeight / 2);

            int length = Math.Min(2, 2 + (int)projectile.oldVelocity.Length());//2 after images

            for (int i = length; i >= 0; i--)
            {
                Vector2 drawPos = projectile.Center - Main.screenPosition - projectile.oldVelocity * i * 0.5f;
                float trailOpacity = projectile.Opacity - 0.05f - (0.95f / length) * i;
                if (i != 0) trailOpacity /= 2f;
                if (trailOpacity > 0f)
                {
                    float colMod = 0.4f + (0.6f * trailOpacity);
                    spriteBatch.Draw(t,
                        drawPos.ToPoint().ToVector2(),
                        new Rectangle(0, frameHeight * projectile.frame, t.Width, frameHeight),
                        new Color(1f * colMod, 1f * colMod, 1f, 0.5f) * 1.0f,
                        projectile.rotation,
                        origin,
                        projectile.scale * (1f + 0.02f * i),
                        effects,
                        0);//trailOpacity constant of 0.95f 
                }
            }
            return false;
        }
        #endregion
    }
}
