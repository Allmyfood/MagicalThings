using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Mounts
{
	public class Pegasus : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = 204;
            mountData.spawnDust = 63;
			mountData.buff = mod.BuffType("PegasusMount");
			mountData.heightBoost = 34;
			mountData.fallDamage = 0f;
			mountData.runSpeed = 10f;
			mountData.dashSpeed = 18f;
			mountData.flightTimeMax = 3000;
			mountData.fatigueMax = 3000;
			mountData.jumpHeight = 45;
			mountData.acceleration = 0.39f;
			mountData.jumpSpeed = 8f;
			mountData.blockExtraJumps = false;
			mountData.totalFrames = 16;
			mountData.constantJump = true;
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
			mountData.xOffset = 5;
            mountData.bodyFrame = 3;
            mountData.yOffset = 1;			
			mountData.playerHeadOffset = 31;
			mountData.standingFrameCount = 1;
			mountData.standingFrameDelay = 12;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 8;
			mountData.runningFrameDelay = 15;
			mountData.runningFrameStart = 1;
			mountData.flyingFrameCount = 6;
			mountData.flyingFrameDelay = 12;
			mountData.flyingFrameStart = 9;
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
			if (Math.Abs(player.velocity.X) > 3f)
			{
				Rectangle rect = player.getRect();
				Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 204);
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 63);
            }
		}
	}
}