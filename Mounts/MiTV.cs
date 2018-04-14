using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Events;

namespace MagicalThings.Mounts
{
    public class MiTV : ModMountData
    {
        const int ShootRate = 12;
        int TimeToShoot = ShootRate;
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
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width / 2, rect.Height / 2, 92); //transparent cyan
            }
            if (Main.rand.Next(35) == 0)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X - (23 * player.direction), rect.Y + 23), rect.Width / 2, rect.Height / 2, 92); //92 is dust type, could use mod.DustType("Sparkel"),3f; for a mod version
            }
            if(mountData.buff == mod.BuffType("MartianMount"))
            //if (Math.Abs(player.velocity.X) != 0f)
            {
                if (--TimeToShoot <= 0)
                {
                    TimeToShoot = ShootRate;
                    Vector2 minecartMechPoint = Mount.GetMinecartMechPoint(player, 15, -19); //player, 20, -19
                int damage = 16;
                int num9 = 0;
                int num5 = player.direction;
                float num10 = 0f;
                for (int j = 0; j < 100; j++)
                {
                    NPC target = Main.npc[j];
                        if (target.active && target.immune[player.whoAmI] <= 0 && !target.dontTakeDamage && target.Distance(minecartMechPoint) < 550f && target.CanBeChasedBy(player, false) && Collision.CanHitLine(target.position, target.width, target.height, minecartMechPoint, 0, 0) && Math.Abs(MathHelper.WrapAngle(MathHelper.WrapAngle(target.AngleFrom(minecartMechPoint)) - MathHelper.WrapAngle((player.fullRotation + (float)num5 == -1f) ? 3.14159274f : 0f))) < 0.7853982f)
                        {
                            Vector2 vector6 = target.position + target.Size * Utils.RandomVector2(Main.rand, 0f, 1f) - minecartMechPoint;
                            num10 += vector6.ToRotation();
                            num9++;
                            int num11 = Projectile.NewProjectile(minecartMechPoint.X, minecartMechPoint.Y, vector6.X, vector6.Y, 440, 0, 0f, player.whoAmI, player.whoAmI, 0f); //default minecraft shot is 591
                            Projectile.NewProjectile(minecartMechPoint.X, minecartMechPoint.Y, vector6.X, vector6.Y, 440, damage, 1.5f, Main.myPlayer, 0, 0f);
                            Main.projectile[num11].Center = target.Center;
                            Main.projectile[num11].damage = damage;
                            Main.projectile[num11].Damage();
                            Main.projectile[num11].damage = 0;
                            Main.projectile[num11].Center = minecartMechPoint;
                            Main.projectile[num11].alpha = 0;
                            Main.projectile[num11].timeLeft = 600;
                        }
                    }
                }
            }
        }
    }
}