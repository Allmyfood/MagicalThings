using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles
{
    public class AirLavaBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Remover Bomb Explosion");
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
            //            #region If Tile active
            //            Tile tile = Main.tile[xPosition, yPosition];
            //            if (tile.active() == true)
            //            {
            //                int type = (int)Main.tile[xPosition, yPosition].type;
            //                int wall = (int)Main.tile[xPosition, yPosition].wall;
            //                #region Walls
            //                //---Walls--//
            //                if (wall == 3 || wall == 28 || wall == 61 || wall == 83) //EbonStone, Pearl, Cave, Crimson
            //                {
            //                    Main.tile[xPosition, yPosition].wall = 1; //Stone
            //                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }//                                                                              >199 && <204 means between so 200-203 will be affected
            //                if (wall == 69 || wall == 70 || wall == 81 || (wall > 187 && wall < 196) || (wall > 199 && wall < 204)) //Corrupt grass, Hallowed, Crimson grass, Corrupt 1-4 - Crimson 1-4, Hallow 1-4
            //                {
            //                    Main.tile[xPosition, yPosition].wall = 65; //Grass Flower Wall natural
            //                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                if (wall == 220 || wall == 221 || wall == 222) //Ebonsandstone, Crimsandstone, Pearlsandstone 
            //                {
            //                    Main.tile[xPosition, yPosition].wall = 187; //sandstone wall
            //                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                if (wall == 217 || wall == 218 || wall == 219) //Hardened Ebonsand, Hardened Crimsand, Hardened Pearlsand
            //                {
            //                    Main.tile[xPosition, yPosition].wall = 216; //Hardened sand wall
            //                    WorldGen.SquareWallFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }

            //                #endregion

            //                #region Blocks
            //                //---Blocks---//
            //                if (type == 25 || type == 117 || type == 203) //Ebonstone, Pearlsone, and Crimstone
            //                {
            //                    Main.tile[xPosition, yPosition].type = 1; //Stone block
            //                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                if (type == 23 || type == 109 || type == 199) //Corrupt grass, Hallowed grass, and Crimson grass
            //                {
            //                    Main.tile[xPosition, yPosition].type = 2; //Grass block
            //                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                if (type == 112 || type == 116 || type == 234) //Ebonsand, Pearlsand, and Crimsand
            //                {
            //                    Main.tile[xPosition, yPosition].type = 53; //Sand
            //                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                if (type == 400 || type == 401 || type == 403) //Ebonsandstone, Crimsandstone, and Pearlsandstone
            //                {
            //                    Main.tile[xPosition, yPosition].type = 396; //Sandstone Block
            //                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                if (type == 398 || type == 399 || type == 402) //Hardened Ebonsand, Crimsand, and Pearlsand
            //                {
            //                    Main.tile[xPosition, yPosition].type = 397; //Hardened Sand Block
            //                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                if (type == 163 || type == 164 || type == 200) //Purple, Pink, and Red ice blocks
            //                {
            //                    Main.tile[xPosition, yPosition].type = 161; //Ice block
            //                    WorldGen.SquareTileFrame(xPosition, yPosition, true);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                //WorldGen.KillTile(xPosition, yPosition, false, false, false);  //this make the explosion destroy tiles  
            //                //Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 100, new Color(), 0.5f);  //this is the dust that will spawn after the explosion
            //                #endregion

            //                #region Bushes
            //                if (type == 32 || type == 352) //Corrupt Thorny Bush, Crimson Thorny Bush
            //                {
            //                    WorldGen.KillTile(xPosition, yPosition, false, false, false);
            //                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            //                }
            //                #endregion
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
            //            Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 100, new Color(), 0.5f);
            //    }
            //}
            #endregion

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
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 269, speedX, speedY, 100, new Color(), 1.5f);
            }

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //circle
                    {
                        #region Border Saftey Checks
                        if (xPosition < 0 && yPosition <0)
                        {
                            xPosition = 0;
                            yPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        if (xPosition < 0)
                        {
                            xPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                            //WorldGen.Convert(xPosition, yPosition, 0, 1); // convert to purity
                        }
                        if (yPosition < 0)
                        {
                            yPosition = 0;
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                        #endregion

                        else
                        {
                            Tile tile = Main.tile[xPosition, yPosition];
                            if (tile != null && Main.tile[xPosition, yPosition].liquid > 0 && Main.tile[xPosition, yPosition].liquidType() == 1)
                            {
                                Main.tile[xPosition, yPosition].lava(false);
                                Main.tile[xPosition, yPosition].liquid = 0;
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                        }
                    }
                }
            }
            #endregion

            #region Dusts
            //Vector2 dustposition = projectile.Center;
            //int dustradius = 2;
            //for (int dx = -dustradius; dx <= dustradius; dx++)
            //{
            //    for (int dy = -radius; dy <= radius; dy++)
            //    {
            //        int dxPosition = (int)(dx + position.X / 16.0f);
            //        int dyPosition = (int)(dy + position.Y / 16.0f);
            //        if (Math.Sqrt(dx * dx + dy * dy) <= radius + 0.5)
            //            Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 100, new Color(), 0.5f);
            //    }
            //}
            #endregion
        }
    }
}