using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MagicalThings.NPCs
{
    public class MagicalGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public bool ArmorBreak = false;

        #region OnHitBuffs
        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            if (npc.HasBuff(mod.BuffType("ArmorBreak")))
            {
                npc.buffImmune[mod.BuffType("ArmorBreak")] = false;
                npc.AddBuff(mod.BuffType("ArmourBreak"), 600);
                npc.defense = npc.defense / 2;
                if (npc.defense <= 0f)
                {
                    npc.defense = 0;
                }
            }
            if (npc.HasBuff(mod.BuffType("Slowed")))
            {
                npc.buffImmune[mod.BuffType("Slowed")] = false;
                npc.AddBuff(mod.BuffType("Slowed"), 300);
                npc.velocity *= 0.80f;
            }
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (npc.HasBuff(mod.BuffType("ArmorBreak")))
            {
                npc.buffImmune[mod.BuffType("ArmorBreak")] = false;
                npc.AddBuff(mod.BuffType("ArmourBreak"), 600);
                npc.defense = npc.defense / 2;
                if (npc.defense <= 0f)
                {
                    npc.defense = 0;
                }
            }
            if (npc.HasBuff(mod.BuffType("Slowed")))
            {
                npc.buffImmune[mod.BuffType("Slowed")] = false;
                npc.AddBuff(mod.BuffType("Slowed"), 180);
                npc.velocity *= 0.80f;
            }
        }

        #endregion

        #region Reset Effects
        public override void ResetEffects(NPC npc)
        {
            ArmorBreak = false;
        }
        #endregion

        #region Shops
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Wizard: //NPC type

                    if (Main.hardMode) //if it's hardmode NPC will sell this.
                    {
                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.Drow.DrowHelmet>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.Drow.DrowBreastplate>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.Drow.DrowLeggings>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Accessory.DrowPiwafwi>());
                        nextSlot++;
                    }
                    if (type == NPCID.Wizard)//Items NPC will always sell
                    {
                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.Drow.DrowMask>());
                        nextSlot++;

                        //shop.item[nextSlot].SetDefaults(ItemID.LunarBar);    //this is an example of how to add a terraria item
                        //nextSlot++;
                    }
                    break;
            }
        }
        #endregion

        #region NPC Loot
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Wolf)
            {
                if (Main.rand.Next(24) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WolfPet"));
                }
            }
            if (npc.type == NPCID.MartianDrone)
            {
                if (Main.rand.Next(35) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NaniteAssembler"));
                }
            }
            if (npc.type == NPCID.Shark)
            {
                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Deployer"));
                }
            }
            if (npc.type == NPCID.Mouse)
            {
                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CheeseWheel"));
                }
            }
            if (npc.type == NPCID.GoldMouse)
            {
                if (Main.rand.Next(1) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CheeseWheel"));
                }
            }

            #region Cultist Robes
            if (npc.type == NPCID.CultistArcherBlue)
            {
                if (Main.rand.Next(2) == 0 && Main.expertMode)
                {
                    var dropChooser = new WeightedRandom<int>();
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistHood>());
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistRobes>());
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistBottoms>());
                    int choice = dropChooser;
                    Item.NewItem(npc.getRect(), choice);
                }
                else if (Main.rand.Next(4) == 0)
                {
                    var dropChooser = new WeightedRandom<int>();
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistHood>());
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistRobes>());
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistBottoms>());
                    int choice = dropChooser;
                    Item.NewItem(npc.getRect(), choice);
                }
            }
            if (npc.type == NPCID.CultistDevote)
            {
                if (Main.rand.Next(2) == 0 && Main.expertMode)
                {
                    var dropChooser = new WeightedRandom<int>();
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistHood>());
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistRobes>());
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistBottoms>());
                    int choice = dropChooser;
                    Item.NewItem(npc.getRect(), choice);
                }
                else if (Main.rand.Next(4) == 0)
                {
                    var dropChooser = new WeightedRandom<int>();
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistHood>());
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistRobes>());
                    dropChooser.Add(mod.ItemType<Items.Armor.Cultist.CultistBottoms>());
                    int choice = dropChooser;
                    Item.NewItem(npc.getRect(), choice);
                }
            }
            #endregion

            #region Shinobi Emblem
            if (npc.type == NPCID.WallofFlesh)
            {
                if (Main.rand.NextFloat() < .25f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("ShinobiEmblem"));
                }
                else
                    if (Main.rand.NextFloat() < .125f)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("ShinobiEmblem"));
                }
            }
            #endregion

            if (npc.type == NPCID.DrManFly)
            {
                if (Main.rand.NextFloat() < .10f) //10% chance
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FlyMask"));
                }
            }
        }
    }
    #endregion
}

