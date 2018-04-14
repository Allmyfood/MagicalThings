using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraUI.Objects;
using Terraria.ID;
using Terraria.UI;

namespace MagicalThings
{
    //Wingslot Info was a big help!
    internal class MagicalPlayer : ModPlayer
    {
        private const string HIDDEN_TAG = "hidden";
        private const string SHOES_TAG = "shoes";
        private const string VANITY_SHOES_TAG = "vanityshoes";
        private const string SHOE_DYE_TAG = "shoedye";
        private const string SHOE_DYE_LAYER = "ShoeDye";
        private PlayerLayer shoesDye;

        public UIItemSlot EquipShoeSlot;
        public UIItemSlot VanityShoeSlot;
        public UIItemSlot ShoeDyeSlot;
        public bool WolfPet = false;
        public bool GwenMinion = false;
        public bool VoidDragonMinion = false;
        public bool WindPixieMinion = false;
        public bool CardinalSpriteMinion = false;
        public bool JaySpriteMinion = false;
        public bool CrimsonDaggerMinion = false;
        public bool AzureSpinnerMinion = false;
        public bool CrimsonPuffMinion = false;
        public bool SlimeBirdMinion = false;
        public bool SwarmMinion = false;
        public bool ServantMinion = false;
        public bool SidheMinion = false;

        /// <summary>
        /// Whether to autoload the ModPlayer.
        /// </summary>
        public override bool Autoload(ref string name)
        {
            return true;
        }
        #region Shoe Slot
        /// <summary>
        /// Initialize the ModPlayer.
        /// </summary>
        public override void Initialize()
        {
            EquipShoeSlot = new UIItemSlot(Vector2.Zero, context: ItemSlot.Context.EquipAccessory, hoverText: "Shoes",
                conditions: Slot_Conditions, drawBackground: Slot_DrawBackground, scaleToInventory: true);
            VanityShoeSlot = new UIItemSlot(Vector2.Zero, context: ItemSlot.Context.EquipAccessoryVanity, hoverText: //context: Contexts.EquipAccessoryVanity, hoverText:
                Language.GetTextValue("LegacyInterface.11") + " Shoes",
                conditions: Slot_Conditions, drawBackground: Slot_DrawBackground, scaleToInventory: true);
            ShoeDyeSlot = new UIItemSlot(Vector2.Zero, context: ItemSlot.Context.EquipDye, conditions: ShoeDyeSlot_Conditions,
                drawBackground: ShoeDyeSlot_DrawBackground, scaleToInventory: true);
            VanityShoeSlot.Partner = EquipShoeSlot;
            EquipShoeSlot.BackOpacity = VanityShoeSlot.BackOpacity = ShoeDyeSlot.BackOpacity = .8f;

            // Big thanks to thegamemaster1234 for the example code used to write this! And WingSlot for how this even works!
            shoesDye = new PlayerLayer(mod.Name, SHOE_DYE_LAYER, delegate (PlayerDrawInfo drawInfo)  //(UIUtils.Mod.Name, SHOE_DYE_LAYER, delegate
            {
                Player player = drawInfo.drawPlayer;
                MagicalPlayer mpp = player.GetModPlayer<MagicalPlayer>(mod); //(UIUtils.Mod);
                Item shoes = mpp.GetDyedShoes();
                Item dye = mpp.ShoeDyeSlot.Item;
                //int index = Main.playerDrawData.Count - 1; //changed

                if (dye.stack <= 0 || shoes.stack <= 0 || !shoes.active || shoes.noUseGraphic || player.mount.Active ||
                  (mpp.VanityShoeSlot.Item.stack <= 0 && !mpp.EquipShoeSlot.ItemVisible))
                    return;

                int shader = GameShaders.Armor.GetShaderIdFromItemId(dye.type); //new

                //if (shoes.flame)
                //    index -= 1;

                //if (index < 0 || index > Main.playerDrawData.Count)
                //return; //removed
                for (int i = 0; i < Main.playerDrawData.Count; i++) //new
                {
                    DrawData data = Main.playerDrawData[i]; // Main.playerDrawData[index];
                    data.shader = shader; //GameShaders.Armor.GetShaderIdFromItemId(dye.type);
                    Main.playerDrawData[i] = data; //Main.playerDrawData[index] = data;
                }
            });

            InitializeShoes();
        }

        /// <summary>
        /// Modify draw layers to draw the shoe dye.
        /// </summary>
        /// <param name="layers"></param>
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            if (!Main.gameMenu)
            {
                layers.Insert(layers.IndexOf(PlayerLayer.ShoeAcc) + 1, shoesDye);
            }
        }

        /// <summary>
        /// Update player with the equipped shoes.
        /// </summary>
        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            Item shoes = EquipShoeSlot.Item;
            Item vanityShoes = VanityShoeSlot.Item;

            if (shoes.stack > 0)
            {
                player.VanillaUpdateEquip(shoes);
                player.VanillaUpdateAccessory(player.whoAmI, shoes, !EquipShoeSlot.ItemVisible, ref wallSpeedBuff, ref tileSpeedBuff,
                    ref tileRangeBuff);
            }

            if (vanityShoes.stack > 0)
            {
                player.VanillaUpdateVanityAccessory(vanityShoes);
            }
        }

        /// <summary>
        /// Save the mod settings.
        /// </summary>
        public override TagCompound Save()
        {
            return new TagCompound {
                { HIDDEN_TAG, EquipShoeSlot.ItemVisible },
                { SHOES_TAG, ItemIO.Save(EquipShoeSlot.Item) },
                { VANITY_SHOES_TAG, ItemIO.Save(VanityShoeSlot.Item) },
                { SHOE_DYE_TAG, ItemIO.Save(ShoeDyeSlot.Item) }
            };
        }

        /// <summary>
        /// Load the mod settings.
        /// </summary>
        public override void Load(TagCompound tag)
        {
            SetShoes(false, ItemIO.Load(tag.GetCompound(SHOES_TAG)));
            SetShoes(true, ItemIO.Load(tag.GetCompound(VANITY_SHOES_TAG)));
            SetDye(ItemIO.Load(tag.GetCompound(SHOE_DYE_TAG)));
            EquipShoeSlot.ItemVisible = tag.GetBool(HIDDEN_TAG);
        }

        /// <summary>
        /// Load legacy mod settings.
        /// </summary>
        public override void LoadLegacy(BinaryReader reader)
        {
            int hide = 0;

            InitializeShoes();

            ushort installedFlag = reader.ReadUInt16();

            if (installedFlag == 0)
            {
                try { hide = reader.ReadInt32(); }
                catch (EndOfStreamException) { hide = 0; }

                EquipShoeSlot.ItemVisible = (hide == 1 ? false : true);

                Item shoes1 = EquipShoeSlot.Item;
                Item shoes2 = VanityShoeSlot.Item;

                int context = ReadShoesLegacy(ref shoes1, reader);
                ReadShoesLegacy(ref shoes2, reader);

                if (context == ItemSlot.Context.EquipAccessory) //(int)Contexts.EquipAccessory)
                {
                    SetShoes(false, shoes1);
                    SetShoes(true, shoes2);
                }
                else if (context == ItemSlot.Context.EquipAccessoryVanity)
                {
                    SetShoes(true, shoes1);
                    SetShoes(false, shoes2);
                }
            }
        }

        /// <summary>
        /// Read the shoes in legacy mod settings.
        /// </summary>
        internal static int ReadShoesLegacy(ref Item shoes, BinaryReader reader)
        {
            try
            {
                ItemIO.LoadLegacy(shoes, reader, false, false);
                return reader.ReadInt32();
            }
            catch (EndOfStreamException)
            {
                return -1;
            }
        }

        /// <summary>
        /// Draw the shoe slot backgrounds.
        /// </summary>
        private void Slot_DrawBackground(UIObject sender, SpriteBatch spriteBatch)
        {
            UIItemSlot slot = (UIItemSlot)sender;

            if (ShouldDrawSlots())
            {
                slot.OnDrawBackground(spriteBatch);

                if (slot.Item.stack == 0)
                {
                    Texture2D tex = mod.GetTexture(MagicalThings.SHOE_SLOT_BACK_TEX);
                    Vector2 origin = tex.Size() / 2f * Main.inventoryScale;
                    Vector2 position = slot.Rectangle.TopLeft();

                    spriteBatch.Draw(
                        tex,
                        position + (slot.Rectangle.Size() / 2f) - (origin / 2f),
                        null,
                        Color.White * 0.35f,
                        0f,
                        origin,
                        Main.inventoryScale,
                        SpriteEffects.None,
                        0f); // layer depth 0 = front
                }
            }
        }

        /// <summary>
        /// Control what can be placed in the shoe slots.
        /// </summary>
        private bool Slot_Conditions(Item item)
        {
            if (item.shoeSlot > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draw the shoe dye slot background.
        /// </summary>
        private void ShoeDyeSlot_DrawBackground(UIObject sender, SpriteBatch spriteBatch)
        {
            UIItemSlot slot = (UIItemSlot)sender;

            if (ShouldDrawSlots())
            {
                slot.OnDrawBackground(spriteBatch);

                if (slot.Item.stack == 0)
                {
                    Texture2D tex = Main.extraTexture[54];
                    Rectangle rectangle = tex.Frame(3, 6, 1 % 3, 1 / 3);
                    rectangle.Width -= 2;
                    rectangle.Height -= 2;
                    Vector2 origin = rectangle.Size() / 2f * Main.inventoryScale;
                    Vector2 position = slot.Rectangle.TopLeft();

                    spriteBatch.Draw(
                        tex,
                        position + (slot.Rectangle.Size() / 2f) - (origin / 2f),
                        new Rectangle?(rectangle),
                        Color.White * 0.35f,
                        0f,
                        origin,
                        Main.inventoryScale,
                        SpriteEffects.None,
                        0f); // layer depth 0 = front
                }
            }
        }

        /// <summary>
        /// Control what can be placed in the shoe dye slot.
        /// </summary>
        private bool ShoeDyeSlot_Conditions(Item item)
        {
            if (item.dye > 0 && item.hairDye < 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draw the shoe slots.
        /// </summary>
        /// <param name="spriteBatch">drawing SpriteBatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (ShouldDrawSlots())
            {
                int mapH = 0;
                int rX = 0;
                int rY = 0;
                float origScale = Main.inventoryScale;

                Main.inventoryScale = 0.85f;

                if (Main.mapEnabled)
                {
                    if (!Main.mapFullscreen && Main.mapStyle == 1)
                    {
                        mapH = 256;
                    }

                    if ((mapH + 569) > Main.screenHeight) //match for map settings
                    {
                        mapH = Main.screenHeight - 569;
                    }
                }

                rX = Main.screenWidth - 92 - (47 * 2);
                rY = mapH + 223; //lower than WingSlot Slots

                if (Main.netMode == 1)
                {
                    rX -= 47;
                }

                EquipShoeSlot.Position = new Vector2(rX, rY);
                VanityShoeSlot.Position = new Vector2(rX -= 47, rY);
                ShoeDyeSlot.Position = new Vector2(rX -= 47, rY);

                VanityShoeSlot.Draw(spriteBatch);
                EquipShoeSlot.Draw(spriteBatch);
                ShoeDyeSlot.Draw(spriteBatch);

                Main.inventoryScale = origScale;

                EquipShoeSlot.Update();
                VanityShoeSlot.Update();
                ShoeDyeSlot.Update();

                //UIUtils.UpdateInput(); //removed?
            }
        }

        /// <summary>
        /// Whether to draw the UIItemSlots.
        /// </summary>
        /// <returns>whether to draw the slots</returns>
        public bool ShouldDrawSlots()
        {
            if (Main.playerInventory && Main.EquipPage == 2) //new style main page ppfftt = 0 I set mine to 2
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Initialize the items in the UIItemSlots.
        /// </summary>
        private void InitializeShoes()
        {
            EquipShoeSlot.Item = new Item();
            VanityShoeSlot.Item = new Item();
            ShoeDyeSlot.Item = new Item();
            EquipShoeSlot.Item.SetDefaults();
            VanityShoeSlot.Item.SetDefaults();
            ShoeDyeSlot.Item.SetDefaults();
        }

        /// <summary>
        /// Set the item in the specified slot.
        /// </summary>
        /// <param name="isVanity">whether to equip in the vanity slot</param>
        /// <param name="item">shoes</param>
        public void SetShoes(bool isVanity, Item item)
        {
            if (!isVanity)
            {
                EquipShoeSlot.Item = item.Clone();
            }
            else
            {
                VanityShoeSlot.Item = item.Clone();
            }
        }

        /// <summary>
        /// Clear the shoes from the specified slot.
        /// </summary>
        /// <param name="isVanity">whether to unequip from the vanity slot</param>
        public void ClearShoes(bool isVanity)
        {
            if (!isVanity)
            {
                EquipShoeSlot.Item = new Item();
                EquipShoeSlot.Item.SetDefaults();
            }
            else
            {
                VanityShoeSlot.Item = new Item();
                VanityShoeSlot.Item.SetDefaults();
            }
        }

        /// <summary>
        /// Set the shoe dye.
        /// </summary>
        /// <param name="item">dye</param>
        public void SetDye(Item item)
        {
            ShoeDyeSlot.Item = item.Clone();
        }

        /// <summary>
        /// Clear the shoe dye.
        /// </summary>
        public void ClearDye()
        {
            ShoeDyeSlot.Item = new Item();
            ShoeDyeSlot.Item.SetDefaults();
        }

        /// <summary>
        /// Equip a set of shoes.
        /// </summary>
        /// <param name="isVanity">whether the shoes should go in the vanity slot</param>
        /// <param name="item">shoes</param>
        public void EquipShoes(bool isVanity, Item item)
        {
            UIItemSlot slot = (isVanity ? VanityShoeSlot : EquipShoeSlot);
            int fromSlot = Array.FindIndex(player.inventory, i => i == item);

            // from inv to slot
            if (fromSlot > -1)
            {
                item.favorited = false;
                player.inventory[fromSlot] = slot.Item.Clone();
                Main.PlaySound(SoundID.Grab);
                //UIUtils.PlaySound(Sounds.Grab);
                Recipe.FindRecipes();
                SetShoes(isVanity, item);
            }
        }

        /// <summary>
        /// Equip a dye.
        /// </summary>
        /// <param name="item">dye to equip</param>
        public void EquipDye(Item item)
        {
            int fromSlot = Array.FindIndex(player.inventory, i => i == item);

            // from inv to slot
            if (fromSlot > -1)
            {
                item.favorited = false;
                player.inventory[fromSlot] = ShoeDyeSlot.Item.Clone();
                Main.PlaySound(SoundID.Grab);
                //UIUtils.PlaySound(Sounds.Grab); old
                Recipe.FindRecipes();
                SetDye(item);
            }
        }

        /// <summary>
        /// Get the set of shoes that a dye should be applied to.
        /// </summary>
        /// <returns>dyed shoes</returns>
        public Item GetDyedShoes()
        {
            if (VanityShoeSlot.Item.stack > 0)
            {
                return VanityShoeSlot.Item;
            }
            else if (EquipShoeSlot.Item.stack > 0)
            {
                return EquipShoeSlot.Item;
            }

            return new Item();
        }
        #endregion

        #region Reset Effects

        // --------Reset Effects---------
        public override void ResetEffects() 
        {
            WolfPet = false;
            GwenMinion = false;
            VoidDragonMinion = false;
            WindPixieMinion = false;
            CardinalSpriteMinion = false;
            JaySpriteMinion = false;
            CrimsonDaggerMinion = false;
            AzureSpinnerMinion = false;
            CrimsonPuffMinion = false;
            SlimeBirdMinion = false;
            SwarmMinion = false;
            ServantMinion = false;
            SidheMinion = false;
    }

        #endregion

        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("Animus"));
            item.stack = 1;
            items.Add(item);
        }
    }
}