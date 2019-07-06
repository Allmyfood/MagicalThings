using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework.Graphics;
using ModConfiguration;

namespace MagicalThings
{
    public class MagicalThings : Mod
	{
        public static int shakeIntensity = 0; //used for Weaponout info
        public static int shakeTick = 0; //used for Weaponout info
        public const string AllowAccessorySlots = "allowShoesInAccessorySlots";
        public const string SlotLocation = "slotLocation";
        //public const string SHOE_SLOT_BACK_TEX = "ShoeSlotBackground";
        public const string ShoeSlotBackTex = "ShoeSlotBackground";
        public static readonly ModConfig Config = new ModConfig("MagicalThings");

        private static readonly List<Func<bool>> RightClickOverrides = new List<Func<bool>>();

        internal static MagicalThings instance;

        public MagicalThings()
		{
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true //changed
			};
            Config.Add(AllowAccessorySlots, true);
            Config.Add(SlotLocation, 2);
            Config.Load();
            TerraUI.Utilities.UIUtils.Mod = this;
            TerraUI.Utilities.UIUtils.Subdirectory = "TerraUI";
        }

        public override void Unload()
        {
            instance = null;
            RightClickOverrides.Clear();
        }

        public override object Call(params object[] args)
        {
            string keyword = args[0] as string;
            Func<bool> func = args[1] as Func<bool>;
            if(string.IsNullOrEmpty(keyword) || func == null)
            {
                return null;
            }

            keyword = keyword.ToLower();
            if (keyword == "add")
            {
                RightClickOverrides.Add(func);
            }
            else if (keyword == "remove")
            {
                RightClickOverrides.Remove(func);
            }

            return null;
        }

        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            MagicalPlayer mpp = Main.player[Main.myPlayer].GetModPlayer<MagicalPlayer>(this);
            mpp.Draw(spriteBatch);
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            PacketMessageType message = (PacketMessageType)reader.ReadByte();
            byte player = reader.ReadByte();
            MagicalPlayer modPlayer = Main.player[player].GetModPlayer<MagicalPlayer>();

            switch (message)
            {
                case PacketMessageType.All:
                    modPlayer.EquipShoeSlot.Item = ItemIO.Receive(reader);
                    modPlayer.VanityShoeSlot.Item = ItemIO.Receive(reader);
                    modPlayer.ShoeDyeSlot.Item = ItemIO.Receive(reader);
                    if (Main.netMode == 2)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)PacketMessageType.All);
                        packet.Write(player);
                        ItemIO.Send(modPlayer.EquipShoeSlot.Item, packet);
                        ItemIO.Send(modPlayer.VanityShoeSlot.Item, packet);
                        ItemIO.Send(modPlayer.ShoeDyeSlot.Item, packet);
                        packet.Send(-1, whoAmI);
                    }
                    break;
                case PacketMessageType.EquipShoeSlot:
                    modPlayer.EquipShoeSlot.Item = ItemIO.Receive(reader);
                    if (Main.netMode == 2)
                    {
                        modPlayer.SendSingleItemPacket(PacketMessageType.EquipShoeSlot, modPlayer.EquipShoeSlot.Item, -1, whoAmI);
                    }
                    break;
                case PacketMessageType.VanityShoeSlot:
                    modPlayer.VanityShoeSlot.Item = ItemIO.Receive(reader);
                    if (Main.netMode == 2)
                    {
                        modPlayer.SendSingleItemPacket(PacketMessageType.VanityShoeSlot, modPlayer.VanityShoeSlot.Item, -1, whoAmI);
                    }
                    break;
                case PacketMessageType.ShoeDyeSlot:
                    modPlayer.ShoeDyeSlot.Item = ItemIO.Receive(reader);
                    if (Main.netMode == 2)
                    {
                        modPlayer.SendSingleItemPacket(PacketMessageType.ShoeDyeSlot, modPlayer.ShoeDyeSlot.Item, -1, whoAmI);
                    }
                    break;
                default:
                    ErrorLogger.Log("Magical Things: Unknown message type: " + message);
                    break;
            }
        }

        public static bool OverrideRightClick()
        {
            foreach (var func in RightClickOverrides)
            {
                if (func())
                {
                    return true;
                }
            }

            return false;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RocketBoots, 1);
            recipe.AddIngredient(null, "MercuryBoots", 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.SpectreBoots, 1);
            recipe.AddRecipe();

        //Added to normal recipe section
//            recipe = new ModRecipe(this);
//            recipe.AddIngredient(ItemID.PalladiumBar, 10);
//            recipe.AddIngredient(ItemID.SoulofNight, 2);
//            recipe.AddTile(TileID.MythrilAnvil);
//            recipe.SetResult(null, "Twinkle", 1);
//            recipe.AddRecipe();
        }

        public override void Load()
        {
            instance = this;
            if (!Main.dedServ)
            {
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Enkryption"), ItemType("EnkryptionMusicBox"), TileType("EnkryptionMusicBox"));
            }
        }
    }
}
