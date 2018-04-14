using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Wizard: //NPC type

                    if (Main.hardMode) //if it's hardmode NPC will sell this.
                    {
                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.DrowHelmet>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.DrowBreastplate>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.DrowLeggings>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Accessory.DrowPiwafwi>());
                        nextSlot++;
                    }
                    if (type == NPCID.Wizard)//Items NPC will always sell
                    {
                        shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Armor.DrowMask>());
                        nextSlot++;

                        //shop.item[nextSlot].SetDefaults(ItemID.LunarBar);    //this is an example of how to add a terraria item
                        //nextSlot++;
                    }
                    break;
            }
        }
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
        }
    }
}
