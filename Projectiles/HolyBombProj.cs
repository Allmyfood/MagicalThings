using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles
{
    public class HolyBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Bomb Explosion");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;   //This defines the hitbox width
            projectile.height = 32;    //This defines the hitbox height
            projectile.aiStyle = 16;  //How the projectile works, 16 is the aistyle Used for: Grenades, Dynamite, Bombs, Sticky Bomb.
            projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
            projectile.timeLeft = 170; //The amount of time the projectile is alive before explode 300 = 5 second fuse
        }
        
        public override void Kill(int timeLeft)
        {
            #region Original
            //Vector2 position = projectile.Center;
            //Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            //int radius = 120;     //this is the explosion radius, the highter is the value the bigger is the explosion

            //for (int x = -radius; x <= radius; x++)
            //{
            //    for (int y = -radius; y <= radius; y++)
            //    {
            //        int xPosition = (int)(x + position.X / 16.0f);
            //        int yPosition = (int)(y + position.Y / 16.0f);

            //        if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //this make so the explosion radius is a circle
            //        {
            //            int type = (int)Main.tile[xPosition, yPosition].type;
            //            int wall = (int)Main.tile[xPosition, yPosition].wall;

            //            #region Walls
            //            if (wall == 3 || wall == 1 || wall == 61 || wall == 83) //EbonStone, stone wall, Cave, Crimson
            //            {
            //                Main.tile[xPosition, yPosition].wall = 28; //pearlstone wall
            //                WorldGen.SquareWallFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            if (wall == 69 || (wall > 62 && wall < 66) || wall == 81 || (wall > 187 && wall < 196))// || (wall > 200 && wall < 203)) //Corrupt grass, Hallowed, Crimson grass, Corrupt 1-4 - Crimson 1-4, Hallow 1-4
            //            {
            //                Main.tile[xPosition, yPosition].wall = 70; //Hallowed Grass Wall natural
            //                WorldGen.SquareWallFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            if (wall == 220 || wall == 221 || wall ==187) //Ebonsandstone wall, Crimsandstone, sandstone wall
            //            {
            //                Main.tile[xPosition, yPosition].wall = 222; //Pearlsandstone wall
            //                WorldGen.SquareWallFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            if (wall == 217 || wall == 218 || wall == 216) //Hardened Ebonsand wall, Hardened Crimsand, Hardened sand wall
            //            {
            //                Main.tile[xPosition, yPosition].wall = 219; //Hardened Pearlsand wall
            //                WorldGen.SquareWallFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            #endregion

            //            #region Blocks
            //            if (type == 25 || type == 1 || type == 203) //Ebonstone, stone, and Crimstone
            //            {
            //                Main.tile[xPosition, yPosition].type = 117; //PearlStone block
            //                WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            if (type == 23 || type == 2 || type == 199) //Corrupt grass, Grass, and Crimson grass
            //            {
            //                Main.tile[xPosition, yPosition].type = 109; //Hallowed Grass block
            //                WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            if (type == 112 || type == 53 || type == 234) //Ebonsand, sand, and Crimsand
            //            {
            //                Main.tile[xPosition, yPosition].type = 116; //PearlSand
            //                WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            if (type == 400 || type == 401 || type == 396) //Ebonsandstone, Crimsandstone, and sandstone
            //            {
            //                Main.tile[xPosition, yPosition].type = 403; //PearlSandstone Block
            //                WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            if (type == 398 || type == 399 || type == 397) //Hardened Ebonsand, Crimsand, and Hardenedsand
            //            {
            //                Main.tile[xPosition, yPosition].type = 402; //Hardened PearlSand Block
            //                WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            if (type == 163 || type == 161 || type == 200) //Purple, Ice Block, and Red ice blocks
            //            {
            //                Main.tile[xPosition, yPosition].type = 164; //Pink Ice block
            //                WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            #endregion

            //            #region Bushes
            //            if (type == 32 || type == 352) //Corrupt Thorny Bush, Crimson Thorny Bush
            //            {
            //                WorldGen.KillTile(xPosition, yPosition, false, false, false);
            //                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //            }
            //            #endregion
            //        }
            //    }
            //}
            //Vector2 dustposition = projectile.Center;
            //int dustradius = 2;
            //for (int dx = -dustradius; dx <= dustradius; dx++)
            //{
            //    for (int dy = -radius; dy <= radius; dy++)
            //    {
            //        int dxPosition = (int)(dx + position.X / 16.0f);
            //        int dyPosition = (int)(dy + position.Y / 16.0f);
            //        if (Math.Sqrt(dx * dx + dy * dy) <= radius + 0.5)
            //            Dust.NewDust(projectile.position, projectile.width, projectile.height, 56, 0f, 0f, 100, new Color(), 0.5f);
            //    }
            //}
            #endregion

            #region Updated WorldGen Convert
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            int radius = 120;
            //float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            //float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 58; i++)
            {
                float speedX = Main.rand.NextFloat(-12, 12);
                float speedY = Main.rand.NextFloat(-10, 10);
                //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], ProjectileID.PureSpray, 0, 0, Main.myPlayer);
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 56, speedX, speedY, 100, new Color(), 1.5f);
            }

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //circle
                    {
                        WorldGen.Convert(xPosition, yPosition, 2, 1); // convert to hallowed
                    }
                }
            }
            #endregion
        }
    }
}