using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MagicalThings.Mounts
{
    public class SSMonkfish : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = 204;
            mountData.spawnDust = 63;
            mountData.buff = mod.BuffType("MonkfishMount");
            mountData.heightBoost = 30;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 2f;
            mountData.dashSpeed = 1f;
            mountData.swimSpeed = 25f;
            mountData.flightTimeMax = 30;
            mountData.fatigueMax = 30;
            mountData.jumpHeight = 5;
            mountData.acceleration = 0.39f;
            mountData.jumpSpeed = 4f;
            mountData.blockExtraJumps = true;
            mountData.totalFrames = 3;
            mountData.constantJump = true;
            mountData.usesHover = false;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 16;
            }
            //array[3] += 2;
            //array[4] += 2;
            //array[7] += 2;
            //array[8] += 2;
            //array[12] += 2;
            //array[13] += 2;
            //array[15] += 4;
            mountData.playerYOffsets = array;
            mountData.xOffset = 4;
            mountData.bodyFrame = 3;
            mountData.yOffset = 2;
            mountData.playerHeadOffset = 18;
            mountData.standingFrameCount = 3;
            mountData.standingFrameDelay = 4;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 3;
            mountData.runningFrameDelay = 4;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 3;
            mountData.flyingFrameDelay = 4;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 3;
            mountData.inAirFrameDelay = 4;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 3;
            mountData.idleFrameDelay = 4;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
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
            if (Math.Abs(player.velocity.X) > 3f)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 15);
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 34);
            }
            if (player.wet == true)
            {
                mountData.usesHover = true;
                mountData.flightTimeMax = 99999;
                mountData.fatigueMax = 99999;
                mountData.dashSpeed = 16f;
                mountData.acceleration = .85f;
                mountData.runSpeed = 15f;
            }
            if (player.wet == false)
            {
                mountData.usesHover = false;
                mountData.flightTimeMax = 30;
                mountData.fatigueMax = 30;
                mountData.dashSpeed = 1f;
                mountData.acceleration = .39f;
                mountData.runSpeed = 2f;
            }
        }
    }
}