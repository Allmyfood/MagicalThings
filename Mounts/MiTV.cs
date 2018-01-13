using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MagicalThings.Mounts
{
	public class MiTV : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = 56;
            mountData.spawnDust = 63;
            mountData.spawnDust = 92;
            mountData.buff = mod.BuffType("MartianMount");
			mountData.heightBoost = 16;
			mountData.fallDamage = 0.0f;
			mountData.runSpeed = 17.2f;
			mountData.dashSpeed = 8f;
			mountData.flightTimeMax = 999999998;
			mountData.fatigueMax = 999999998;
			mountData.jumpHeight = 10;
			mountData.acceleration = 0.99f;
			mountData.jumpSpeed = 9f;
			mountData.blockExtraJumps = true;
			mountData.totalFrames = 2;
		//	mountData.constantJump = true;
            mountData.usesHover = true;
            int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 16;
			}
       //     array[3] += 2;
       //     array[4] += 2;
       //     array[7] += 2;
       //     array[8] += 2;
       //     array[12] += 2;
       //     array[13] += 2;
       //     array[15] += 4;
            mountData.playerYOffsets = array;
			mountData.xOffset = 7;
            mountData.bodyFrame = 3;
            mountData.yOffset = 2;			
			mountData.playerHeadOffset = 18;
			mountData.standingFrameCount = 2;
			mountData.standingFrameDelay = 4;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 2;
			mountData.runningFrameDelay = 4;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 2;
			mountData.flyingFrameDelay = 4;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 2;
			mountData.inAirFrameDelay = 4;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 2;
			mountData.idleFrameDelay = 12;
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
			if (Math.Abs(player.velocity.X) > 10f)
			{
				Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width/2, rect.Height/2, 92); //transparent cyan
            }
            if (Main.rand.Next(54) == 0)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X-10, rect.Y+27), rect.Width/2, rect.Height/2, 92);
            }
        }
	}
}