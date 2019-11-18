using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Mounts
{
    public class Centaur : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = 228;
            mountData.spawnDust = 10;
            mountData.buff = mod.BuffType("BarnBuff");
            mountData.heightBoost = 34;
            mountData.fallDamage = 0.0f;
            mountData.runSpeed = 12f;
            mountData.dashSpeed = 20f;
            mountData.flightTimeMax = 0;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 18;
            mountData.acceleration = 0.30f;
            mountData.jumpSpeed = 9f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 16;
            mountData.constantJump = false;
            mountData.usesHover = false;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 28;
            }
            array[3] += 2;
            array[4] += 2;
            array[7] += 2;
            array[8] += 2;
            array[12] += 2;
            array[13] += 2;
            array[15] += 4;
            mountData.playerYOffsets = array;
            mountData.xOffset = -6;
            mountData.bodyFrame = 3;
            mountData.yOffset = 1;
            mountData.playerHeadOffset = 31;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 7;
            mountData.runningFrameDelay = 15;
            mountData.runningFrameStart = 1;
            mountData.dashingFrameCount = 6;
            mountData.dashingFrameDelay = 40;
            mountData.dashingFrameStart = 9;
            mountData.flyingFrameCount = 6;
            mountData.flyingFrameDelay = 6;
            mountData.flyingFrameStart = 1;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 15;
            mountData.idleFrameCount = 0;
            mountData.idleFrameDelay = 0;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = false;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.backTexture.Width + 20;
                mountData.textureHeight = mountData.backTexture.Height;
            }
        }

        public override void UpdateEffects(Player player)
        {
            player.blockRange += 1;
            player.doubleJumpUnicorn = true;
            player.noFallDmg = true;
            if (Main.rand.Next(30) == 0)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 228);
            }
        }
    }
}