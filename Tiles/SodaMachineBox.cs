using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using System;
using Terraria.Enums;

namespace MagicalThings.Tiles
{
    public class SodaMachineBox : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileSolidTop[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Soda Machine");
            AddMapEntry(new Color(0, 0, 204), name);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.WorkBenches };
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX < 20)
            {
                r = 0.83f;
                g = 0.89f;
                b = 0.91f;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("SodaMachine"));
        }

        //public override void MouseOverFar(int i, int j)
        //{
        //    Player player = Main.LocalPlayer;
        //    Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
        //    int left = Player.tileTargetX;
        //    int top = Player.tileTargetY;
        //    left -= (int)(tile.frameX % 54 / 18);
        //    if (tile.frameY % 74 != 0)//74
        //    {
        //        top--;
        //    }
        //    int chestIndex = Chest.FindChest(left, top);
        //    player.showItemIcon2 = -1;
        //    if (chestIndex < 0)
        //    {
        //        player.showItemIconText = Language.GetTextValue("Soda Machine");
        //    }
        //    else
        //    {
        //        if (Main.chest[chestIndex].name != "")
        //        {
        //            player.showItemIconText = Main.chest[chestIndex].name;
        //        }
        //        else
        //        {
        //            player.showItemIconText = chest;
        //        }
        //        if (player.showItemIconText == chest)
        //        {
        //            player.showItemIcon2 = mod.ItemType("Soda Machine");
        //            player.showItemIconText = "";
        //        }
        //    }
        //    player.noThrow = 2;
        //    player.showItemIcon = true;
        //    if (player.showItemIconText == "")
        //    {
        //        player.showItemIcon = false;
        //        player.showItemIcon2 = 0;
        //    }
        //}

        //public override void MouseOver(int i, int j)
        //{
        //    Player player = Main.LocalPlayer;
        //    Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
        //    int left = Player.tileTargetX;
        //    int top = Player.tileTargetY;
        //    left -= (int)(tile.frameX % 54 / 18);
        //    if (tile.frameY % 70 != 0)//36
        //    {
        //        top--;
        //    }
        //    int num138 = Chest.FindChest(left, top);
        //    player.showItemIcon2 = -1;
        //    if (num138 < 0)
        //    {
        //        player.showItemIconText = Language.GetTextValue("Soda Machine");
        //    }
        //    else
        //    {
        //        if (Main.chest[num138].name != "")
        //        {
        //            player.showItemIconText = Main.chest[num138].name;
        //        }
        //        else
        //        {
        //            player.showItemIconText = chest;
        //        }
        //        if (player.showItemIconText == chest)
        //        {
        //            player.showItemIcon2 = mod.ItemType("Soda Machine");
        //            player.showItemIconText = "";
        //        }
        //    }
        //    player.noThrow = 2;
        //    player.showItemIcon = true;
        //    if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameY > 0)
        //    {
        //        player.showItemIcon2 = ItemID.PiggyBank;
        //    }
        //}
    }
}
