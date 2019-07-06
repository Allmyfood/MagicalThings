using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MagicalThings.Tiles
{
	public class SodaMachineBox : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = false;
			//Main.tileObsidianKill[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.LavaDeath = false;
			//TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Soda Machine");
			disableSmartCursor = true;
			AddMapEntry(new Color(0, 0, 204), name);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            adjTiles = new int[] { TileID.WorkBenches };
		}

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("SodaMachine"));
		}

        //public override void MouseOver(int i, int j)
        //{
        //	Player player = Main.LocalPlayer;
        //	player.noThrow = 2;
        //	player.showItemIcon = true;
        //	player.showItemIcon2 = mod.ItemType("SodaMachineBox");
        //}
    }
}
