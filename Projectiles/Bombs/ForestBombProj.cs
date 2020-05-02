using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles.Bombs
{
    public class ForestBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forest Bomb Explosion");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 32;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }



        public override void Kill(int timeLeft)
        {
            #region Updated WorldGen Convert
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            int radius = 60;
            ushort[] dirts = { 196, 197, 198, 199 };
            ushort dirtz = Main.rand.Next(dirts);
            //float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            //float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 58; i++)
            {
                float speedX = Main.rand.NextFloat(-12, 12);
                float speedY = Main.rand.NextFloat(-10, 10);
                //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], ProjectileID.PureSpray, 0, 0, Main.myPlayer);
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 256, speedX, speedY, 100, new Color(), 1.5f);//74 nice green color
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        //WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                        //WorldGen.GrowTree(xPosition, yPosition - 1);
                                        //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                            //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        //WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                        //WorldGen.GrowTree(xPosition, yPosition - 1);
                                        //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                            //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        //WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                        //WorldGen.GrowTree(xPosition, yPosition - 1);
                                        //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                            //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        //WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                        //WorldGen.GrowTree(xPosition, yPosition - 1);
                                        //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                            //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        //WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                        //WorldGen.GrowTree(xPosition, yPosition - 1);
                                        //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                            //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        //WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                        //WorldGen.GrowTree(xPosition, yPosition - 1);
                                        //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                            //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        //WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                        //WorldGen.GrowTree(xPosition, yPosition - 1);
                                        //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                            //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        //WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                        //WorldGen.GrowTree(xPosition, yPosition - 1);
                                        //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                            //NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
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
                                #region Blocks Sand to Dirt grow grass then trees
                                if (type == 53) //Sand
                                {
                                    if (yPosition <= Main.worldSurface)
                                    {
                                        Main.tile[xPosition, yPosition].type = 0; //Dirt block
                                        WorldGen.SpreadGrass(xPosition, yPosition, TileID.Dirt, TileID.Grass); //Spread grass on open surfaces before update to keep trees
                                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                        if (Main.rand.Next(12) == 0)
                                        {
                                            WorldGen.PlaceObject(xPosition, yPosition - 1, TileID.Saplings);
                                            WorldGen.GrowTree(xPosition, yPosition - 1);
                                        }
                                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                                    }
                                }
                                #endregion
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