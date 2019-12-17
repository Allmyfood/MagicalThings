using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
        public bool Cut = false;
        public bool PrimeSpear = false;
        public bool EctoSpear = false;
        public bool SkypiercerSpear = false;
        public bool BrionacSpear = false;
        public bool ValkyrieArrow = false;

        #region Defaults for Items
        public override void SetDefaults(NPC npc)
        {
            // Make Spears buff act like a bone javelin
            npc.buffImmune[ModContent.BuffType<Buffs.CompanionBuffs.PrimeSpearBuff>()] = npc.buffImmune[BuffID.BoneJavelin];
            npc.buffImmune[ModContent.BuffType<Buffs.CompanionBuffs.EctoSpearBuff>()] = npc.buffImmune[BuffID.BoneJavelin];
            npc.buffImmune[ModContent.BuffType<Buffs.CompanionBuffs.SkypiercerBuff>()] = npc.buffImmune[BuffID.BoneJavelin];
            npc.buffImmune[ModContent.BuffType<Buffs.CompanionBuffs.BrionacBuff>()] = npc.buffImmune[BuffID.Daybreak];
            npc.buffImmune[ModContent.BuffType<Buffs.CompanionBuffs.ValkyrieArrowBuff>()] = npc.buffImmune[BuffID.Daybreak];
        }
        #endregion

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

        #region Life Regen Buff / Debuffs
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (Cut)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 16;
                if (damage < 2)
                {
                    damage = 4;
                }
            }
            if (PrimeSpear)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int PrimeSpearCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ModContent.ProjectileType<Projectiles.CompanionProj.Warrior.PrimeSpearProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        PrimeSpearCount++;
                    }
                }
                npc.lifeRegen -= PrimeSpearCount * 2 * 3;
                if (damage < PrimeSpearCount * 3)
                {
                    damage = PrimeSpearCount * 3;
                }
            }
            if (EctoSpear)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int EctoSpearCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ModContent.ProjectileType<Projectiles.CompanionProj.Warrior.EctoSpearProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        EctoSpearCount++;
                    }
                }
                npc.lifeRegen -= EctoSpearCount * 2 * 4;
                if (damage < EctoSpearCount * 4)
                {
                    damage = EctoSpearCount * 4;
                }
            }
            if (SkypiercerSpear)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int SkypiercerSpearCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ModContent.ProjectileType<Projectiles.CompanionProj.Warrior.SkypiercerProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        SkypiercerSpearCount++;
                    }
                }
                npc.lifeRegen -= SkypiercerSpearCount * 6 * 6;
                if (damage < SkypiercerSpearCount * 6)
                {
                    damage = SkypiercerSpearCount * 6;
                }
            }
            if (BrionacSpear)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int BrionacSpearCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ModContent.ProjectileType<Projectiles.CompanionProj.Warrior.BrionacProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        BrionacSpearCount++;
                    }
                }
                npc.lifeRegen -= BrionacSpearCount * 8 * 14;
                if (damage < BrionacSpearCount * 14)
                {
                    damage = BrionacSpearCount * 14;
                }
            }
            if (ValkyrieArrow)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int ValkyrieArrowCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ModContent.ProjectileType<Projectiles.CompanionProj.Ranger.ValkyrieArrowProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        ValkyrieArrowCount++;
                    }
                }
                npc.lifeRegen -= ValkyrieArrowCount * 6 * 12;
                if (damage < ValkyrieArrowCount * 12)
                {
                    damage = ValkyrieArrowCount * 12;
                }
            }
        }
        #endregion

        #region Reset Effects
        public override void ResetEffects(NPC npc)
        {
            ArmorBreak = false;
            Cut = false;
            PrimeSpear = false;
            EctoSpear = false;
            SkypiercerSpear = false;
            BrionacSpear = false;
            ValkyrieArrow = false;
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
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.Drow.DrowHelmet>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.Drow.DrowBreastplate>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.Drow.DrowLeggings>());
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Accessory.DrowPiwafwi>());
                        nextSlot++;
                    }
                    if (type == NPCID.Wizard)//Items NPC will always sell
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.Drow.DrowMask>());
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
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.WolfPet>());
                }
            }
            if (npc.type == NPCID.MartianDrone)
            {
                if (Main.rand.Next(35) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.NaniteAssembler>());
                }
            }
            if (npc.type == NPCID.Shark)
            {
                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Deployer>());
                }
            }
            if (npc.type == NPCID.Mouse)
            {
                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Accessory.CheeseWheel>());
                }
            }
            if (npc.type == NPCID.GoldMouse)
            {
                if (Main.rand.Next(1) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Accessory.CheeseWheel>());
                }
            }

            #region Cultist Robes
            if (npc.type == NPCID.CultistArcherBlue)
            {
                if (Main.rand.Next(2) == 0 && Main.expertMode)
                {
                    var dropChooser = new WeightedRandom<int>();
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistHood>());
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistRobes>());
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistBottoms>());
                    int choice = dropChooser;
                    Item.NewItem(npc.getRect(), choice);
                }
                else if (Main.rand.Next(4) == 0)
                {
                    var dropChooser = new WeightedRandom<int>();
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistHood>());
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistRobes>());
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistBottoms>());
                    int choice = dropChooser;
                    Item.NewItem(npc.getRect(), choice);
                }
            }
            if (npc.type == NPCID.CultistDevote)
            {
                if (Main.rand.Next(2) == 0 && Main.expertMode)
                {
                    var dropChooser = new WeightedRandom<int>();
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistHood>());
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistRobes>());
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistBottoms>());
                    int choice = dropChooser;
                    Item.NewItem(npc.getRect(), choice);
                }
                else if (Main.rand.Next(4) == 0)
                {
                    var dropChooser = new WeightedRandom<int>();
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistHood>());
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistRobes>());
                    dropChooser.Add(ModContent.ItemType<Items.Armor.Cultist.CultistBottoms>());
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
                    Item.NewItem(npc.getRect(), ItemType<Items.Accessory.ShinobiEmblem>());
                }
                else
                    if (Main.rand.NextFloat() < .125f)
                {
                    Item.NewItem(npc.getRect(), ItemType<Items.Accessory.ShinobiEmblem>());
                }
            }
            #endregion

            if (npc.type == NPCID.DrManFly)
            {
                if (Main.rand.NextFloat() < .10f) //10% chance
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Armor.FlyMask.FlyMask>());
                }
            }

            if (npc.type == NPCID.Nurse) 
            {
                if (Main.rand.Next(1) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Accessory.ShinyMedkit>());
                }
            }

            if (npc.type == NPCID.Pirate)
            {
                if (Main.rand.Next(1) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Armor.CaptainsHat.CaptainsHat>());
                }
            }

            if (npc.type == NPCID.DarkCaster)
            {
                if (Main.rand.NextFloat() < .05f) //5% chance
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Armor.GreatWizard.GreatWizardHat>());
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Armor.GreatWizard.GreatWizardRobes>());
                }
            }
            if (npc.type == NPCID.SantaNK1)
            {
                if (Main.rand.NextFloat() < .10f) //10% chance
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Accessory.FancyBluePresent>());
                }
            }

            #region Animus Drop
            if (npc.type == NPCID.MoonLordCore)
            {
                if (Main.rand.Next(1) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Items.Animus>());
                }
            }
            #endregion
        }
    }
    #endregion
}

