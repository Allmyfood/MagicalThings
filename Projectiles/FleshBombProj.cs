using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Projectiles
{
    public class FleshBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flesh Bomb Explosion");
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

            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 120;     //this is the explosion radius, the highter is the value the bigger is the explosion

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //this make so the explosion radius is a circle
                    {
                        int type = (int)Main.tile[xPosition, yPosition].type;
                        int wall = (int)Main.tile[xPosition, yPosition].wall;
                        //Walls
                        if (wall == 1 || wall == 28 || wall == 61)// || wall == 3) //Stone, Pearl, Cave, Ebonstone Walls
                        {
                            Main.tile[xPosition, yPosition].wall = 83; //Crimstone wall
                            WorldGen.SquareWallFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            if (wall == 70 || (wall > 62 && wall < 66) || (wall > 199 && wall < 204)) //Hallowed, Grass - Flower grass, Hallow 1-4
                        {
                                Main.tile[xPosition, yPosition].wall = 81; //Crimson Grass natural
                                WorldGen.SquareWallFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                            if (wall == 187 || wall == 222)// || wall ==220) //Sandstone, Pearlsandstone, Ebonsandstone
                        {
                            Main.tile[xPosition, yPosition].wall = 221; //Crimsandstone wall
                            WorldGen.SquareWallFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                            if (wall == 216 || wall == 219)// || wall == 217) //Hardened Sand, Hardened Pearlsand, Hardened Ebonsand
                        {
                            Main.tile[xPosition, yPosition].wall = 218; //Hardened Crimsand wall
                            WorldGen.SquareWallFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                        
                            //Blocks //Coruption and Crimson are both allowed now so only convert normal and holy blocks.
                    if (type == 1 || type == 117)// || type == 25) //Stone block, Pearlstone, and Ebonstone
                    {
                        Main.tile[xPosition, yPosition].type = 203; //CrimStone block
                        WorldGen.SquareTileFrame(xPosition, yPosition, true);
                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                    }
                        if (type == 2 || type == 109)// || type == 23) //Grass, Hallowed grass, and Corrupt Grass
                        {
                            Main.tile[xPosition, yPosition].type = 199; //Crimson Grass block
                            WorldGen.SquareTileFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            if (type == 53 || type == 116)// || type == 112) //Sand, Pearlsand, and Ebonsand
                            {
                                Main.tile[xPosition, yPosition].type = 234; //CrimSand
                                WorldGen.SquareTileFrame(xPosition, yPosition, true);
                                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                            }
                            if (type == 396 || type == 403)// || type == 400) //Sandstone, Pearlsandstone, and Ebonsandstone
                        {
                            Main.tile[xPosition, yPosition].type = 401; //CrimSandstone Block
                            WorldGen.SquareTileFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            if (type == 397 || type == 402)// || type == 398) //Hardened Sand, Hardened Pearlsand, and Hardened Ebonsand
                        {
                            Main.tile[xPosition, yPosition].type = 399; //Hardened CrimSand Block
                            WorldGen.SquareTileFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                            if (type == 161 || type == 164)// || type == 163) //Ice block, Pink Ice, and Purple Ice
                        {
                            Main.tile[xPosition, yPosition].type = 200; //Red Ice block
                            WorldGen.SquareTileFrame(xPosition, yPosition, true);
                            NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                        }
                    }
                }
            }
            Vector2 dustposition = projectile.Center;
            int dustradius = 2;
            for (int dx = -dustradius; dx <= dustradius; dx++)
            {
                for (int dy = -radius; dy <= radius; dy++)
                {
                    int dxPosition = (int)(dx + position.X / 16.0f);
                    int dyPosition = (int)(dy + position.Y / 16.0f);
                    if (Math.Sqrt(dx * dx + dy * dy) <= radius + 0.5)
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, 183, 0f, 0f, 100, new Color(), 0.5f);
                }
            }
        }
    }
}