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
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using TerraUI.Objects;
using Terraria.ID;
using Terraria.UI;
using Terraria.GameInput;

namespace MagicalThings
{
    //Wingslot Info was a big help! Including snipets of code, code ideas, or sometimes large pieces.
    //If you see this be sure to check out WingSlot in the mod browser.
    internal class MagicalPlayer : ModPlayer
    {
        private const string HiddenTag = "hidden";
        private const string ShoesTag = "shoes";
        private const string VanityshoesTag = "vanityshoes";
        private const string ShoeDyeTag = "shoedye";
        //private const string SHOE_DYE_LAYER = "ShoeDye"; //antiquated
        //private PlayerLayer shoesDye;

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
        public bool SurgeBuff = false;
        public bool ArmorBreak = false;
        public bool Slowed = false;
        public bool IlluminationTriangle = false;
        public bool MousePet = false;
        public bool FireRingMinion = false;
        public bool FreeSpiritMinion = false;
        public bool FlameSkeletonMinion = false;
        public bool YongValkyrieMinion = false;
        public bool Medic = false;
        public bool FoxPet = false;
        public bool WaspMinion = false;
        public bool PWNCrystalMinion = false;
        public bool BloodAxeMinion = false;
        public bool ShadowHammerMinion = false;
        public bool VirtueMinion = false;
        public bool Cut = false;
        public bool DoomSpectreMinion = false;
        public bool SpiritDragonMinion = false;
        public bool PillarDemonMinion = false;
        public bool PillarDragonMinion = false;
        public bool MsDeathMinion = false;
        public int lastNPCHitMsDeathMinion = -1;
        public int DeathCoolDown = 0;
        public bool ValkyrieMinion = false;
        public int lastNPCHitValkyrieMinion = -1;
        public int ValkyrieCoolDown = 0;
        public int ValkyrieArrowCoolDown = 0;
        public int ValgrindShotCount = 0;
        public bool MugenArmorEquiped = false;
        public bool SantaFiring = false;
        public int SantaFireFrame = 1000;
        

        #region OnHitBuffs
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (target.friendly == false)
            {
                if (player.HasBuff(mod.BuffType("SurgeBuff")))
                {
                    //target.buffImmune[BuffID.Ichor] = false;
                    target.buffImmune[BuffID.OnFire] = false;
                    target.buffImmune[BuffID.CursedInferno] = false;
                    //target.buffImmune[BuffID.Poisoned] = false;
                    //target.AddBuff(BuffID.Ichor, 600);
                    target.AddBuff(BuffID.OnFire, 600);
                    target.AddBuff(BuffID.CursedInferno, 600);
                    //target.AddBuff(BuffID.Poisoned, 600);
                    knockback += 2.0f;
                }
                if (player.HasBuff(mod.BuffType("ArmorBreak")))
                {
                    target.buffImmune[mod.BuffType("ArmorBreak")] = false;
                    target.AddBuff(mod.BuffType("ArmourBreak"), 600);
                    target.defense = target.defense / 2;
                    if (target.defense <= 0f)
                    {
                        target.defense = 0;
                    }
                }
                if (player.HasBuff(mod.BuffType("Slowed")))
                {
                    target.buffImmune[mod.BuffType("Slowed")] = false;
                    target.AddBuff(mod.BuffType("Slowed"), 180);
                    target.velocity *= 0.80f;
                }
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (target.friendly == false)
            {
                if (player.HasBuff(mod.BuffType("SurgeBuff")))
                {
                    //target.buffImmune[BuffID.Ichor] = false;
                    target.buffImmune[BuffID.OnFire] = false;
                    target.buffImmune[BuffID.CursedInferno] = false;
                    //target.buffImmune[BuffID.Poisoned] = false;
                    //target.AddBuff(BuffID.Ichor, 600);
                    target.AddBuff(BuffID.OnFire, 600);
                    target.AddBuff(BuffID.CursedInferno, 600);
                    //target.AddBuff(BuffID.Poisoned, 600);
                    knockback += 2.0f;
                }
                if (player.HasBuff(mod.BuffType("ArmorBreak")))
                {
                    target.buffImmune[mod.BuffType("ArmorBreak")] = false;
                    target.AddBuff(mod.BuffType("ArmourBreak"), 600);
                    target.defense = target.defense / 2;
                    if (target.defense <= 0f)
                    {
                        target.defense = 0;
                    }
                }
                if (player.HasBuff(mod.BuffType("Slowed")))
                {
                    target.buffImmune[mod.BuffType("Slowed")] = false;
                    target.AddBuff(mod.BuffType("Slowed"), 180);
                    target.velocity *= 0.80f;
                }
            }
        }

        #endregion

        #region Updated Shoe Slot now with server config
        #region Setup Bootslot
        public override void clientClone(ModPlayer clientClone)
        {
            MagicalPlayer clone = clientClone as MagicalPlayer;

            if (clone == null)
            {
                return;
            }

            clone.EquipShoeSlot.Item = EquipShoeSlot.Item.Clone();
            clone.VanityShoeSlot.Item = VanityShoeSlot.Item.Clone();
            clone.ShoeDyeSlot.Item = ShoeDyeSlot.Item.Clone();
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            MagicalPlayer oldClone = clientPlayer as MagicalPlayer;

            if (oldClone == null)
            {
                return;
            }

            if (oldClone.EquipShoeSlot.Item.IsNotTheSameAs(EquipShoeSlot.Item))
            {
                SendSingleItemPacket(PacketMessageType.EquipShoeSlot, EquipShoeSlot.Item, -1, player.whoAmI);
            }

            if (oldClone.VanityShoeSlot.Item.IsNotTheSameAs(VanityShoeSlot.Item))
            {
                SendSingleItemPacket(PacketMessageType.VanityShoeSlot, VanityShoeSlot.Item, -1, player.whoAmI);
            }

            if (oldClone.ShoeDyeSlot.Item.IsNotTheSameAs(ShoeDyeSlot.Item))
            {
                SendSingleItemPacket(PacketMessageType.ShoeDyeSlot, ShoeDyeSlot.Item, -1, player.whoAmI);
            }
        }

        internal void SendSingleItemPacket(PacketMessageType message, Item item, int toWho, int fromWho)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)message);
            packet.Write((byte)player.whoAmI);
            ItemIO.Send(item, packet);
            packet.Send(toWho, fromWho);
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)PacketMessageType.All);
            packet.Write((byte)player.whoAmI);
            ItemIO.Send(EquipShoeSlot.Item, packet);
            ItemIO.Send(VanityShoeSlot.Item, packet);
            ItemIO.Send(ShoeDyeSlot.Item, packet);
            packet.Send(toWho, fromWho);
        }
        #endregion

        /// <summary>
        /// Initialize the ModPlayer.
        /// </summary>
        public override void Initialize()
        {
            EquipShoeSlot = new UIItemSlot(Vector2.Zero, context: ItemSlot.Context.EquipAccessory, hoverText: "Shoes",
                conditions: Slot_Conditions, drawBackground: Slot_DrawBackground, scaleToInventory: true);
            VanityShoeSlot = new UIItemSlot(Vector2.Zero, context: ItemSlot.Context.EquipAccessoryVanity, hoverText:
                Language.GetTextValue("LegacyInterface.11") + " Shoes",
                conditions: Slot_Conditions, drawBackground: Slot_DrawBackground, scaleToInventory: true);
            ShoeDyeSlot = new UIDyeItemSlot(Vector2.Zero, context: ItemSlot.Context.EquipDye, conditions: ShoeDyeSlot_Conditions,
                drawBackground: ShoeDyeSlot_DrawBackground, scaleToInventory: true);
            VanityShoeSlot.Partner = EquipShoeSlot;
            EquipShoeSlot.BackOpacity = VanityShoeSlot.BackOpacity = ShoeDyeSlot.BackOpacity = .8f;
            InitializeShoes();
        }

        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            if (ShoeDyeSlot.Item.stack > 0 && (EquipShoeSlot.Item.shoeSlot > 0 || VanityShoeSlot.Item.shoeSlot > 0))
            {
                drawInfo.shoeShader = ShoeDyeSlot.Item.dye;
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
                player.VanillaUpdateAccessory(player.whoAmI, shoes, !EquipShoeSlot.ItemVisible, ref wallSpeedBuff, ref tileSpeedBuff,
                    ref tileRangeBuff); //.whoami, shoes
                player.VanillaUpdateEquip(shoes);
            }

            if (vanityShoes.stack > 0)
            {
                player.VanillaUpdateVanityAccessory(vanityShoes);
            }
        }

        /// <summary>
        /// Since there is no tModLoader hook in UpdateDyes, we use PreUpdateBuffs which is right after that.
        /// </summary>
        public override void PreUpdateBuffs()
        {
            //A little redundant code, but mirrors vanilla code exactly.
            if (ShoeDyeSlot.Item != null && !EquipShoeSlot.Item.IsAir && EquipShoeSlot.ItemVisible && EquipShoeSlot.Item.shoeSlot > 0)
            {
                if (EquipShoeSlot.Item.shoeSlot > 0)
                    player.cShoe = ShoeDyeSlot.Item.dye;
            }
            if (ShoeDyeSlot.Item != null && !VanityShoeSlot.Item.IsAir)
            {
                if (VanityShoeSlot.Item.shoeSlot > 0)
                    player.cShoe = ShoeDyeSlot.Item.dye;
            }
        }

        /// <summary>
        /// Save the mod settings.
        /// </summary>
        public override TagCompound Save()
        {
            return new TagCompound {
                { HiddenTag, EquipShoeSlot.ItemVisible },
                { ShoesTag, ItemIO.Save(EquipShoeSlot.Item) },
                { VanityshoesTag, ItemIO.Save(VanityShoeSlot.Item) },
                { ShoeDyeTag, ItemIO.Save(ShoeDyeSlot.Item) }
                };
        }

        /// <summary>
        /// Load the mod settings.
        /// </summary>
        public override void Load(TagCompound tag)
        {
            SetShoes(false, ItemIO.Load(tag.GetCompound(ShoesTag)));
            SetShoes(true, ItemIO.Load(tag.GetCompound(VanityshoesTag)));
            SetDye(ItemIO.Load(tag.GetCompound(ShoeDyeTag)));
            EquipShoeSlot.ItemVisible = tag.GetBool(HiddenTag);
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
                    Texture2D tex = mod.GetTexture(MagicalThings.ShoeSlotBackTex);
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
        private static bool Slot_Conditions(Item item)
        {
            if (item.shoeSlot <= 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Draw the shoe dye slot background.
        /// </summary>
        private static void ShoeDyeSlot_DrawBackground(UIObject sender, SpriteBatch spriteBatch)
        {
            UIItemSlot slot = (UIItemSlot)sender;

            if (!ShouldDrawSlots())
            {
                return;
            }

            slot.OnDrawBackground(spriteBatch);

            if (slot.Item.stack != 0)
            {
                return;
            }

            Texture2D tex = Main.extraTexture[54]; //54
            Rectangle rectangle = tex.Frame(3, 6, 1 % 3);
            rectangle.Width -= 2;
            rectangle.Height -= 2;
            Vector2 origin = rectangle.Size() / 2f * Main.inventoryScale;
            Vector2 position = slot.Rectangle.TopLeft();

            spriteBatch.Draw(
                tex,
                position + (slot.Rectangle.Size() / 2f) - (origin / 2f),
                rectangle,
                Color.White * 0.35f,
                0f,
                origin,
                Main.inventoryScale,
                SpriteEffects.None,
                0f); // layer depth 0 = front
        }

        /// <summary>
        /// Control what can be placed in the shoe dye slot.
        /// </summary>
        private static bool ShoeDyeSlot_Conditions(Item item)
        {
            return item.dye > 0 && item.hairDye < 0;
        }

        /// <summary>
        /// Draw the shoe slots.
        /// </summary>
        /// <param name="spriteBatch">drawing SpriteBatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            //int slotLocation; //old

            if (!ShouldDrawSlots())//(out slotLocation)) outdated
            {
                return;
            }

            int mapH = 0;
            int rX;
            int rY;
            float origScale = Main.inventoryScale;

            Main.inventoryScale = 0.85f;

            if (Main.mapEnabled)
            {
                if (!Main.mapFullscreen && Main.mapStyle == 1)
                {
                    mapH = 256;
                }
            }

            if(MagicalThings.ShoeSlotlocation) //(slotLocation == 2) used new config function
            {
                if (Main.mapEnabled)
                {
                    if ((mapH + 569) > Main.screenHeight)
                    {
                        mapH = Main.screenHeight - 569;
                    }
                }

                rX = Main.screenWidth - 92 - (47 * 2);
                rY = mapH + 223;

                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    rX -= 47;
                }
            }
            else
            {
                if (Main.mapEnabled)
                {
                    int adjustY = 600;

                    if (Main.player[Main.myPlayer].ExtraAccessorySlotsShouldShow)
                    {
                        adjustY = 610 + PlayerInput.UsingGamepad.ToInt() * 30;
                    }

                    if ((mapH + adjustY) > Main.screenHeight)
                    {
                        mapH = Main.screenHeight - adjustY;
                    }
                }

                int slotCount = 7 + Main.player[Main.myPlayer].extraAccessorySlots;

                if ((Main.screenHeight < 900) && (slotCount >= 8))
                {
                    slotCount = 7;
                }

                rX = Main.screenWidth - 92 - 14 - (47 * 3) - (int)(Main.extraTexture[58].Width * Main.inventoryScale); //58
                rY = (int)(mapH + 127 + 4 + slotCount * 56 * Main.inventoryScale);
            }

            EquipShoeSlot.Position = new Vector2(rX, rY);
            VanityShoeSlot.Position = new Vector2(rX -= 47, rY);
            ShoeDyeSlot.Position = new Vector2(rX - 47, rY);

            VanityShoeSlot.Draw(spriteBatch);
            EquipShoeSlot.Draw(spriteBatch);
            ShoeDyeSlot.Draw(spriteBatch);

            Main.inventoryScale = origScale;

            EquipShoeSlot.Update();
            VanityShoeSlot.Update();
            ShoeDyeSlot.Update();
        }

        /// <summary>
        /// Whether to draw the UIItemSlots.
        /// </summary>
        /// <returns>whether to draw the slots</returns>
        //private static bool ShouldDrawSlots(out int slotLocation) out dated
        //{
        //    if (Main.playerInventory)
        //    {
        //        slotLocation = Convert.ToInt32(MagicalThings.Config.Get(MagicalThings.ShoeSlotlocation));

        //        if ((slotLocation == 1 && Main.EquipPage == 0) ||
        //           (slotLocation == 2 && Main.EquipPage == 2))
        //        {
        //            return true;
        //        }
        //    }

        //    slotLocation = 1;
        //    return false;
        //}
        #region Server Config to Draw Bootslot
            //If the server config Bootslot Enable is true Bootslot is visible. If it is false the Bootslot
            //is disabled and items will not be placed in it. Even if you place the boot in the right location it won't work.
        private static bool ShouldDrawSlots()
        {
            return Main.playerInventory && MagicalThingsServerConfig.Instance.EnableBootslot &&((MagicalThings.ShoeSlotlocation && Main.EquipPage == 2) ||
                    (!MagicalThings.ShoeSlotlocation && Main.EquipPage == 0));//First line true = 2 equipment pate, False = 0 Main page
        }
        #endregion

        /// <summary>
        /// Whether to draw the UIItemSlots.
        /// </summary>
        /// <returns>whether to draw the slots</returns>
        //private static bool ShouldDrawSlots()
        //{
        //    int slotLocation;
        //    return ShouldDrawSlots(out slotLocation);
        //}

        /// <summary>
        /// Initialize the items in the UIItemSlots.
        /// </summary>
        private void InitializeShoes()
        {
            EquipShoeSlot.Item = new Item();
            VanityShoeSlot.Item = new Item();
            ShoeDyeSlot.Item = new Item();
            EquipShoeSlot.Item.SetDefaults(0, true); // Can remove "0, true" once 0.10.1.5 comes out.
            VanityShoeSlot.Item.SetDefaults(0, true);
            ShoeDyeSlot.Item.SetDefaults(0, true);
        }

        /// <summary>
        /// Set the item in the specified slot.
        /// </summary>
        /// <param name="isVanity">whether to equip in the vanity slot</param>
        /// <param name="item">shoes</param>
        private void SetShoes(bool isVanity, Item item)
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
        private void SetDye(Item item)
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
            if (fromSlot < 0)
            {
                return;
            }

            item.favorited = false;
            player.inventory[fromSlot] = slot.Item.Clone();
            Main.PlaySound(SoundID.Grab);
            Recipe.FindRecipes();
            SetShoes(isVanity, item);
        }

        /// <summary>
        /// Equip a dye.
        /// </summary>
        /// <param name="item">dye to equip</param>
        public void EquipDye(Item item)
        {
            int fromSlot = Array.FindIndex(player.inventory, i => i == item);
            // from inv to slot
            if (fromSlot < 0)
            {
                return;
            }

            item.favorited = false;
            player.inventory[fromSlot] = ShoeDyeSlot.Item.Clone();
            Main.PlaySound(SoundID.Grab);
            Recipe.FindRecipes();
            SetDye(item);
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

            if (EquipShoeSlot.Item.stack > 0)
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
            SurgeBuff = false;
            ArmorBreak = false;
            Slowed = false;
            IlluminationTriangle = false;
            MousePet = false;
            FireRingMinion = false;
            FreeSpiritMinion = false;
            FlameSkeletonMinion = false;
            YongValkyrieMinion = false;
            Medic = false;
            FoxPet = false;
            WaspMinion = false;
            PWNCrystalMinion = false;
            BloodAxeMinion = false;
            ShadowHammerMinion = false;
            VirtueMinion = false;
            Cut = false;
            DoomSpectreMinion = false;
            SpiritDragonMinion = false;
            PillarDemonMinion = false;
            PillarDragonMinion = false;
            MsDeathMinion = false;
            ValkyrieMinion = false;
            MugenArmorEquiped = false;
    }
        #endregion

        #region Post Updates and Timers
        public override void PostUpdateEquips()
        {
            if (DeathCoolDown >= 0)
            {
                DeathCoolDown--;
            }
            if (ValkyrieCoolDown >= 0)
            {
                ValkyrieCoolDown--;
            }
            if (ValkyrieArrowCoolDown >= 0)
            {
                ValkyrieArrowCoolDown--;
            }
        }
        #endregion

        #region Dead Reset Effects
        public override void UpdateDead()
        {
            Cut = false;
        }
        #endregion

        #region DeBuffs BadLife Regen
        public override void UpdateBadLifeRegen()
        {
            if (Cut)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 16;
            }
        }
        #endregion
        
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath = false)
        {            
            Item item = new Item();       
            item.SetDefaults(ItemType<Items.Animus>());
            item.stack = 1;
            items.Add(item);
        }
    }
}