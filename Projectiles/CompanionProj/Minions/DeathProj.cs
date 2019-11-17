using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MagicalThings.Projectiles.CompanionProj.Minions
{
    public class DeathProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mistress Death");
            Main.projFrames[projectile.type] = 13;
            //Main.projPet[projectile.type] = true;
            //ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            //ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            //projectile.CloneDefaults(533);
            //aiType = 533;
            projectile.width = 124;
            projectile.height = 124;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0.0f;
            projectile.penetrate = -1;
            projectile.timeLeft = projectile.timeLeft * 5;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 6;
        }

        public override bool? CanCutTiles()
        { return false; }

        public enum Animation { Idle, Alert, Attacking };
        public Animation spriteAnimation;
        public const float aggroDist = 600;
        public const float chaseDist = 1000;
        public const int attackRange = 50;

        public int AILogicMode { get { return (int)projectile.ai[0]; } set { projectile.ai[0] = value; } }//default 0
        public int AIAttackingState { get { return (int)projectile.ai[1]; } set { projectile.ai[1] = value; } }//1

        #region Behavior
        public override void AI()
        {
            // Get active player, or disappear
            Player player = Main.player[projectile.owner];
            var mpm = player.GetModPlayer<MagicalPlayer>();
            if (!player.active)
            { projectile.active = false; return; }
            if (player.dead)
            { mpm.MsDeathMinion = false; }

            // Stay around
            if (mpm.MsDeathMinion)
            { projectile.timeLeft = 2; }

            // Default resting point at player
            float clampSpeed = -1f;
            float lerpSpeed = 0.2f;
            spriteAnimation = Animation.Idle;
            Vector2 targetCentre = player.Center;
            targetCentre = player.Center + new Vector2(-32f * player.direction, -50 * player.gravDir);
            projectile.direction = projectile.spriteDirection = player.direction;
            projectile.friendly = false;
            projectile.damage = 0;
            projectile.knockBack = 0f;

            #region Attack logic start plus agro distance
            //Auto Ai to attack within agro range plus extra
            //int counter = 0; //use DeathCoolDown instead in my player.
            bool readyup = false;
            bool cooloff = false;
            float closestBad = aggroDist + 200;
            foreach (NPC npc in Main.npc)
            {
                Vector2 diffe = npc.Center - (player.Center - new Vector2(player.direction * 64, 0));
                float distx = Math.Max(Math.Abs(diffe.X), Math.Abs(diffe.Y));
                if (distx <= closestBad && npc.CanBeChasedBy(this, false))
                {
                    readyup = true;
                    closestBad = distx;
                    cooloff = true;
                    mpm.DeathCoolDown = 600;//my player cooldown

                }

            }
            #endregion

            #region Auto Ai logic
            if (readyup == true && AILogicMode == 0 && cooloff == true)
            {
                AILogicMode = 1;
            }
            else if (readyup == true && AILogicMode == 1 && cooloff == true)
            {
                AILogicMode = 1;
                mpm.DeathCoolDown = 600;//keep cooldown up if npcs are around
            }
            else if (readyup == false && AILogicMode == 1 && cooloff == true)
            {
                //wait for Cooldown
            }
            else if (readyup == false && AILogicMode == 1 && cooloff == true && mpm.DeathCoolDown <= 0)
            {
                cooloff = false;
            }
            else if (readyup == false && AILogicMode == 1 && cooloff == false && mpm.DeathCoolDown <= 0)
            {
                AILogicMode = 0;
                mpm.DeathCoolDown = 0;
                //cooldown complete set to 0
            }
            #endregion

            NPC target = null;

            #region Logic Mode Set
            switch (AILogicMode)
            {
                case 0:
                    // Mode 1: Attack player's last target
                    // Only attack what the player last hit, and follow it up to 250 away

                    if (mpm.lastNPCHitMsDeathMinion > -1)
                    {
                        target = Main.npc[mpm.lastNPCHitMsDeathMinion];
                        if (target.CanBeChasedBy(this, false) &&
                            Vector2.Distance(player.Center, target.Center) <= chaseDist)
                        {
                            targetCentre = MoveToAttack(player, target);

                            projectile.friendly = true;
                            projectile.damage = 250;
                            projectile.knockBack = 5f;
                        }
                        else
                        { target = null; mpm.lastNPCHitMsDeathMinion = -1; }
                    }

                    break;
                case 1:
                    // Mode 2: Watch player's back
                    // Only attacking targets closer than 250 that aren't what the player is hitting. 500 acording to agro.

                    // Resting position
                    spriteAnimation = Animation.Alert;
                    targetCentre = player.Center + new Vector2(-70f * player.direction, -70 * player.gravDir);
                    projectile.direction = projectile.spriteDirection = -player.direction;

                    //Get closest that player isn't hitting
                    float closestDist = aggroDist;
                    foreach (NPC npc in Main.npc)
                    {
                        if (npc.whoAmI == mpm.lastNPCHitMsDeathMinion) continue;

                        Vector2 diff = npc.Center - (player.Center - new Vector2(player.direction * 64, 0));
                        float dist = Math.Max(Math.Abs(diff.X), Math.Abs(diff.Y));
                        if (dist <= closestDist && npc.CanBeChasedBy(this, false))
                        {
                            target = npc;
                            closestDist = dist;
                        }
                    }

                    // No target, but player has hit something
                    if (target == null && mpm.lastNPCHitMsDeathMinion >= 0)
                    {
                        NPC npc = Main.npc[mpm.lastNPCHitMsDeathMinion];
                        Vector2 diff = npc.Center - (player.Center - new Vector2(player.direction * 64, 0));
                        float dist = Math.Max(Math.Abs(diff.X), Math.Abs(diff.Y));
                        if (dist <= closestDist && npc.CanBeChasedBy(this, false))
                        {
                            target = npc;
                            closestDist = dist;
                            mpm.lastNPCHitMsDeathMinion = -1;
                        }
                    }

                    // Attack it

                    if (target != null)
                    {
                        targetCentre = MoveToAttack(player, target);
                        mpm.DeathCoolDown = 600;
                        projectile.friendly = true;
                        projectile.damage = 250;
                        projectile.knockBack = 5f;

                        // Only go so fast, or speed up to catch up with it
                        clampSpeed = Math.Max(54f, (target.oldPosition - target.position).Length() * 2); //24 * 2
                    }
                    else
                    { lerpSpeed /= 4; }

                    break;
            }
            #endregion

            #region Move Projectile
            // Move to position
            projectile.velocity = Vector2.Lerp(projectile.Center, targetCentre, lerpSpeed) - projectile.Center;
            if (clampSpeed > 0f)
            {
                if (projectile.velocity.Length() > clampSpeed)
                {
                    projectile.velocity.Normalize();
                    projectile.velocity *= clampSpeed;
                }
            }

            Lighting.AddLight(projectile.Center, 0.9f, 0.9f, 0.7f);

            if (projectile.damage > 0)
            { spriteAnimation = Animation.Attacking; }
            FindFrame();
        }
        #endregion
        #endregion

        #region Move to Attack
        private Vector2 MoveToAttack(Player player, NPC target)
        {
            if (target.Center.X >= player.Center.X)
            { projectile.direction = projectile.spriteDirection = 1; }
            else
            { projectile.direction = projectile.spriteDirection = -1; }

            return target.Center - new Vector2((attackRange + target.width / 2) * projectile.direction, 0);
        }
        #endregion

        #region Frame select
        public void FindFrame()
        {
            projectile.frameCounter++;

            int frameTime = 9;
            int frameMin = 0;
            int frameMax = 4;

            switch (spriteAnimation)
            {
                case Animation.Alert:
                    frameTime = 9;
                    frameMin = 5;
                    frameMax = 8;
                    break;
                case Animation.Attacking:
                    frameTime = 8;
                    frameMin = 9;
                    frameMax = 12;
                    break;
            }

            if (projectile.frameCounter >= frameTime)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame < frameMin) projectile.frame = frameMax;
                else if (projectile.frame > frameMax) projectile.frame = frameMin;
            }
        }
        #endregion

        #region Update Net On Hit
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.netUpdate2 = true;
        }
        #endregion

        #region Draw Minion
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
                        new Color(1f * colMod, 1f * colMod, 1f, 0.5f) * 0.95f,
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