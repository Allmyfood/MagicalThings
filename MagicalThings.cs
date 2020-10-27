using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using MagicalThings.Buffs;

namespace MagicalThings
{
    public class MagicalThings : Mod
    {
        public static bool AllowShoesInAccessorySlots = true;
        public static bool ShoeSlotlocation = true;
        //public const string SHOE_SLOT_BACK_TEX = "ShoeSlotBackground";
        public const string ShoeSlotBackTex = "ShoeSlotBackground";
        //public static readonly MagicalThingsConfig Config = new ModConfig("MagicalThings");

        private static List<Func<bool>> RightClickOverrides;

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
            //Config.Add(AllowShoesInAccessorySlots, true);
            //Config.Add(ShoeSlotlocation, 2);
            //Config.Load();
            //TerraUI.Utilities.UIUtils.Mod = this;
            //TerraUI.Utilities.UIUtils.Subdirectory = "TerraUI";
        }

        #region Load-Unload Sprite Draws
        public override void Load()
        {
            instance = this;
            if (!Main.dedServ)
            {
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Enkryption"), ItemType("EnkryptionMusicBox"), TileType("EnkryptionMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/BlueMoon"), ItemType("BlueMoonMusicBox"), TileType("BlueMoonMusicBox"));
                AddEquipTexture(null, EquipType.Legs, "GreatWizardRobes_Legs", "MagicalThings/Items/Armor/GreatWizard/GreatWizardRobes_Legs");
            }
            RightClickOverrides = new List<Func<bool>>();
        }

        public override void Unload()
        {
            instance = null;
            if (RightClickOverrides != null)
            {
                RightClickOverrides.Clear();
                RightClickOverrides = null;
            }
        }

        public override object Call(params object[] args)
        {
            try
            {
                string keyword = args[0] as string;

                if (string.IsNullOrEmpty(keyword))
                {
                    return null;
                }

                switch (keyword)
                {
                    case "add":
                    case "remove":
                        // shoeSlot.Call(/* "add" or "remove" */, /* func<bool> returns true to cancel/false to continue */);
                        // These two should be called in PostSetupContent
                        Func<bool> func = args[1] as Func<bool>;

                        if (func == null) return null;

                        if (keyword == "add")
                        {
                            RightClickOverrides.Add(func);
                        }
                        else if (keyword == "remove")
                        {
                            RightClickOverrides.Remove(func);
                        }
                        break;
                    case "getEquip":
                    case "getVanity":
                    case "getVisible":
                        /* Can't use these three in PostSetupContent because EquipShoeSlot is a field in MagicalPlayer, but
                         * that's not initialized yet, hence why I couldn't make some sort of delegate as an argument
                         * that assigned it */

                        // Item shoeItem = (Item)shoeSlot.Call(/* "getEquip"/"getVanity"/"getVisible" */, player.whoAmI);
                        // These three should be called on demand
                        int whoAmI = Convert.ToInt32(args[1]);
                        MagicalPlayer mmp = Main.player[whoAmI].GetModPlayer<MagicalPlayer>();

                        if (keyword == "getEquip")
                        {
                            return mmp.EquipShoeSlot.Item;
                        }
                        else if (keyword == "getVanity")
                        {
                            return mmp.VanityShoeSlot.Item;
                        }
                        // Returns the item that is responsible for the shoes to display on the player (at all times or during flight)
                        else if (keyword == "getVisible")
                        {
                            if (mmp.VanityShoeSlot.Item.shoeSlot > 0)
                            {
                                return mmp.VanityShoeSlot.Item;
                            }
                            else
                            {
                                return mmp.EquipShoeSlot.Item;
                            }
                        }
                        break;
                }
            }
            catch
            {
                return null;
            }
            return null;
            #region Old
            //string keyword = args[0] as string;
            //Func<bool> func = args[1] as Func<bool>;
            //if (string.IsNullOrEmpty(keyword) || func == null)
            //{
            //    return null;
            //}

            //keyword = keyword.ToLower();
            //if (keyword == "add")
            //{
            //    RightClickOverrides.Add(func);
            //}
            //else if (keyword == "remove")
            //{
            //    RightClickOverrides.Remove(func);
            //}

            //return null;
            #endregion
        }

        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            //MagicalPlayer mpp = Main.player[Main.myPlayer].GetModPlayer<MagicalPlayer>();
            MagicalPlayer mpp = Main.LocalPlayer.GetModPlayer<MagicalPlayer>();
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
                    if (Main.netMode == NetmodeID.Server)
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
                    if (Main.netMode == NetmodeID.Server)
                    {
                        modPlayer.SendSingleItemPacket(PacketMessageType.EquipShoeSlot, modPlayer.EquipShoeSlot.Item, -1, whoAmI);
                    }
                    break;
                case PacketMessageType.VanityShoeSlot:
                    modPlayer.VanityShoeSlot.Item = ItemIO.Receive(reader);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        modPlayer.SendSingleItemPacket(PacketMessageType.VanityShoeSlot, modPlayer.VanityShoeSlot.Item, -1, whoAmI);
                    }
                    break;
                case PacketMessageType.ShoeDyeSlot:
                    modPlayer.ShoeDyeSlot.Item = ItemIO.Receive(reader);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        modPlayer.SendSingleItemPacket(PacketMessageType.ShoeDyeSlot, modPlayer.ShoeDyeSlot.Item, -1, whoAmI);
                    }
                    break;
                default:
                    Logger.InfoFormat("Magical Things: Unknown message type: ", DisplayName);
                    //ErrorLogger.Log("Magical Things: Unknown message type: " + message);
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

        #endregion

        #region Recipe Groups
        public override void AddRecipeGroups()
        {
            #region Tier 7 Classes
            // Creates a new recipe group
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 7 Mage Class" + Lang.GetItemNameValue(ItemType("Tier 7 Mage Class")), new int[]
            {
                ItemType("HellMarkTome"),
                ItemType("HellBurstStaff"),
                ItemType("BookOfSpellsV6"),
                ItemType("UnholyStorm")
            });
            // Registers the new recipe group with the specified name
            RecipeGroup.RegisterGroup("MagicalThings:Tier 7 Mage Class", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 7 Ninja Class" + Lang.GetItemNameValue(ItemType("Tier 7 Ninja Class")), new int[]
            {
                ItemType("HellfireKunai"),
                ItemType("BurningBloodDagger")
            });
            RecipeGroup.RegisterGroup("MagicalThings:Tier 7 Ninja Class", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 7 Ranger Class" + Lang.GetItemNameValue(ItemType("Tier 7 Ranger Class")), new int[]
            {
                ItemType("NightmareBow"),
                ItemType("DarkBlaster")
            });
            RecipeGroup.RegisterGroup("MagicalThings:Tier 7 Ranger Class", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 7 Summoner Class" + Lang.GetItemNameValue(ItemType("Tier 7 Summoner Class")), new int[]
            {
                ItemType("FlameSkullLamp"),
                ItemType("BrokenLance")
            });
            RecipeGroup.RegisterGroup("MagicalThings:Tier 7 Summoner Class", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 7 Melee Class" + Lang.GetItemNameValue(ItemType("Tier 7 Melee Class")), new int[]
            {
                ItemType("HellfireSword"),
                ItemType("DarkFlail"),
                ItemType("HellfireBident"),
                ItemType("DarkThrow")
            });
            RecipeGroup.RegisterGroup("MagicalThings:Tier 7 Melee Class", group);
            #endregion

            #region Bar Groups
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Demonite Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup("MagicalThings:Demonite Bar", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Cobalt Bar", new int[]
            {
                ItemID.CobaltBar,
                ItemID.PalladiumBar
            });
            RecipeGroup.RegisterGroup("MagicalThings:Cobalt Bar", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Mythril Bar", new int[]
            {
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            });
            RecipeGroup.RegisterGroup("MagicalThings:Mythril Bar", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Adamantite Bar", new int[]
            {
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar
            });
            RecipeGroup.RegisterGroup("MagicalThings:Adamantite Bar", group);
            #endregion

            #region Boot Groups
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Hermes Boots", new int[]
            {
                ItemID.HermesBoots,
                ItemID.FlurryBoots,
                ItemID.SailfishBoots,
                ItemType("MercuryBoots")
            });
            RecipeGroup.RegisterGroup("MagicalThings:Hermes Boots", group);

            #endregion
        }
        #endregion

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "MercuryBoots", 1);
            recipe.AddIngredient(ItemID.RocketBoots, 1);
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

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
            {
                return;
            }
            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<SantaNK2Buff>()))
            {
                music = MusicID.FrostMoon;
                priority = MusicPriority.Environment;
            }
        }
    }
}
