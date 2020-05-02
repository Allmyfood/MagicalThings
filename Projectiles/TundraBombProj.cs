using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles
{
    public class TundraBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tundra Bomb Explosion");
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
            #region Updated WorldGen Convert
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            int radius = 60;
            //float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            //float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 58; i++)
            {
                float speedX = Main.rand.NextFloat(-12, 12);
                float speedY = Main.rand.NextFloat(-10, 10);
                //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], ProjectileID.PureSpray, 0, 0, Main.myPlayer);
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 16, speedX, speedY, 100, new Color(), 1.5f);
            }

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + (position.X / 16.0f));
                    int yPosition = (int)(y + (position.Y / 16.0f));

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //circle
                    {
                        #region Bomb Conversion
                        #region Border Saftey Checks
                        if (xPosition < 0 && yPosition < 0)//top left
                        {
                            xPosition = 0;
                            yPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2 || wall == 59) //Stone, Dirt
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion
                            }
                        }
                        if ((xPosition >= Main.maxTilesX - 43) && yPosition < 0)//top right
                        {
                            xPosition = Main.maxTilesX - 43;
                            yPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2 || wall == 59) //Stone, Dirt
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion
                            }
                        }
                        if (xPosition < 0 && yPosition >= Main.maxTilesY - 44)//bottom left
                        {
                            xPosition = 0;
                            yPosition = Main.maxTilesY - 44;
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2 || wall == 59) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2) //Stone, Dirt
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion
                            }
                        }
                        if ((xPosition >= Main.maxTilesX - 43) && yPosition >= Main.maxTilesY - 44)//bottom right
                        {
                            xPosition = Main.maxTilesX - 43;
                            yPosition = Main.maxTilesY - 44;
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2 || wall == 59) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2) //Stone, Dirt
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion
                            }
                        }
                        if (xPosition < 0)//left wall
                        {
                            xPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2 || wall == 59) //Stone, Dirt
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion
                            }
                        }
                        if (xPosition >= Main.maxTilesX - 43)//right wall MaxX
                        {
                            xPosition = Main.maxTilesX - 43;
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2 || wall == 59) //Stone, Dirt
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion
                            }
                        }
                        if (yPosition < 0)//top
                        {
                            yPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2 || wall == 59) //Stone, Dirt, Dirt with Stones
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion
                            }
                        }
                        if (yPosition >= Main.maxTilesY - 44)//bottom
                        {
                            yPosition = Main.maxTilesY - 44;
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2 || wall == 59) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2) //Stone, Dirt
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion
                            }
                        }
                        #endregion

                        else
                        {
                            Tile tile = Main.tile[xPosition, yPosition];
                            int type = Main.tile[xPosition, yPosition].type;
                            int wall = Main.tile[xPosition, yPosition].wall;
                            if (tile != null)
                            {
                                #region Blocks Snow and Ice
                                if (type == 0 || type == 2) //Dirt, Grass
                                {
                                    Main.tile[xPosition, yPosition].type = 147; //Snow block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (type == 1) //Stone
                                {
                                    Main.tile[xPosition, yPosition].type = 161; //Ice block
                                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                #region Walls Snow and Ice Walls
                                if (wall == 1 || wall == 2) //Stone, Dirt
                                {
                                    Main.tile[xPosition, yPosition].wall = 40; //Snow Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                if (wall > 195 && wall < 200) //Dirt Cavern
                                {
                                    Main.tile[xPosition, yPosition].wall = 71; //Ice Unsafe
                                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                }
                                #endregion

                                //Main.tile[xPosition, yPosition].lava(false);
                                //Main.tile[xPosition, yPosition].liquid = 0;
                                //WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        #endregion
                    }
                }
            }
            #endregion
        }
    }
}