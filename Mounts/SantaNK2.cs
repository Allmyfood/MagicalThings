using System;
using MagicalThings.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Mounts
{//                        All useful data from Spirit mod Candy Copter! Thank you for all the hard work!
    public class SantaNK2 : ModMountData
    {
        private const float damage = 60f;
        private const float knockback = 1.5f;
        private const float velocity = 15f;
        private const int cooldown = 5;
        private const float fov = (float)Math.PI * 0.33333f; //60 degrees
        private const float aimRange = 690; //40 blocks
        private const float rangeSquare = aimRange * aimRange;
        private FOVHelper helper = new FOVHelper();
        private static readonly Vector3 lightColor = new Vector3(0.5294f, 0.7137f, 0.8745f);

        public override void SetDefaults()
        {
            #region Mount Data
            mountData.spawnDust = 59;
            mountData.spawnDust = 135;
            mountData.buff = BuffType<SantaNK2Buff>();
            mountData.heightBoost = 34;//34;
            mountData.fallDamage = 0.0f;
            mountData.runSpeed = 8f;
            mountData.dashSpeed = 15f;
            mountData.flightTimeMax = 0;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 26;
            mountData.acceleration = 0.12f;
            mountData.jumpSpeed = 8f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 9;
            mountData.constantJump = false;
            mountData.usesHover = false;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 74;// Player height
            }
            array[0] += 2; //bonus height on that frame
            //array[1] += 0;
            array[2] -= 2;
            array[3] -= 4;
            //array[4] += 0;
            //array[5] += 0;
            //array[15] += 4;
            mountData.playerYOffsets = array;
            mountData.xOffset = -20;
            mountData.bodyFrame = 3;
            mountData.yOffset = -36;
            mountData.playerHeadOffset = 40;
            mountData.standingFrameCount = 3;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 6;
            mountData.runningFrameCount = 6;
            mountData.runningFrameDelay = 15;
            mountData.runningFrameStart = 0;
            mountData.dashingFrameCount = 0;
            mountData.dashingFrameDelay = 12;
            mountData.dashingFrameStart = 0;
            mountData.flyingFrameCount = 0;
            mountData.flyingFrameDelay = 12;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 5;
            mountData.idleFrameCount = 0;
            mountData.idleFrameDelay = 15;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = false;
            mountData.textureHeight = 250;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            //if (Main.netMode != 2)
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }
            mountData.textureWidth = mountData.backTexture.Width + 20;
            mountData.textureHeight = mountData.backTexture.Height;
            #endregion
        }

        public override void UpdateEffects(Player player)
        {
            MagicalPlayer modPlayer = player.GetModPlayer<MagicalPlayer>();
            float tilt = player.fullRotation;

            player.blockRange += 5;
            player.resistCold = true;
            player.accDivingHelm = true;
            player.statDefense += 150;
            player.doubleJumpBlizzard = true;
            player.noFallDmg = true;
            player.iceSkate = true;
            player.pickSpeed -= 0.25f;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Webbed] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            if (Main.rand.Next(30) == 0)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 135);
            }

            #region Santa Target and Fire
            //Scan for enemies and fire at them
            if (player.mount._abilityCooldown == 0)
            {
                //Don't change these values, unless you want to adjust the nozzle position.
                float x = 5f * player.direction;//20 and 12
                float y = 5f;
                float sin = (float)Math.Sin(tilt);
                float cos = (float)Math.Cos(tilt);
                Vector2 muzzle = new Vector2(x * cos - y * sin, x * sin + y * cos);
                muzzle = muzzle + player.fullRotationOrigin + player.position;

                //Readjust the scanning cone to the current position.
                float direction;
                if (player.direction == 1)
                {
                    direction = FOVHelper.POS_X_DIR + tilt;
                }
                else
                {
                    direction = FOVHelper.NEG_X_DIR - tilt;
                }
                helper.adjustCone(muzzle, fov, direction);

                //Look for the nearest, unobscured enemy inside the cone
                NPC nearest = null;
                float distNearest = rangeSquare;
                for (int i = 0; i < 200; i++)
                {
                    NPC npc = Main.npc[i];
                    Vector2 npcCenter = npc.Center;
                    if (npc.CanBeChasedBy() && helper.isInCone(npcCenter)) //first param of canBeChasedBy has no effect
                    {
                        float distCurrent = Vector2.DistanceSquared(muzzle, npcCenter);
                        if (distCurrent < distNearest && Collision.CanHitLine(muzzle, 0, 0, npc.position, npc.width, npc.height))
                        {
                            nearest = npc;
                            distNearest = distCurrent;
                        }
                    }
                }
                //Shoot 'em dead
                if (nearest != null)
                {
                    if (player.whoAmI == Main.myPlayer)
                    {
                        Vector2 aim = nearest.Center - muzzle;
                        aim.Normalize();
                        aim *= velocity;
                        float vX = aim.X;
                        float vY = aim.Y;
                        //This precisely mimics the Gatligators spread
                        //Random rand = Main.rand; commenting this out because I changed the rand lines here and waiting on more experienced help- Jenosis
                        vX += Main.rand.Next(-20, 21) * 0.03f;
                        vY += Main.rand.Next(-20, 21) * 0.03f;
                        vX += Main.rand.Next(-10, 11) * 0.05f;
                        vY += Main.rand.Next(-10, 11) * 0.05f;
                        if (Main.rand.Next(3) == 0)
                        {
                            vX += Main.rand.Next(-15, 16) * 0.02f;
                            vY += Main.rand.Next(-15, 16) * 0.02f;
                        }
                        Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 41);
                        Projectile.NewProjectile(muzzle.X, muzzle.Y, vX, vY, ProjectileID.BulletHighVelocity, (int)(damage * player.minionDamage), knockback * player.minionKB, player.whoAmI); //CandyCopterBullet
                    }
                    Point point = player.Center.ToTileCoordinates();
                    Lighting.AddLight(point.X, point.Y, lightColor.X, lightColor.Y, lightColor.Z);
                    modPlayer.SantaFiring = true;
                    modPlayer.SantaFireFrame = 0;
                    player.mount._abilityCooldown = cooldown - 1;
                }
                else
                {
                    modPlayer.SantaFiring = false;
                }
                return;
            }
            else if (player.mount._abilityCooldown > cooldown)
            {
                player.mount._abilityCooldown = cooldown;
            }
            #endregion
        }
    }
}