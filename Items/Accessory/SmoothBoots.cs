using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MagicalThings.Items.Accessory
{
    [AutoloadEquip(EquipType.Shoes)]
    public class SmoothBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Run Fast Across Water and Lava"
                + "\nIncreases way too many abilities"
                + "\nCheat Item");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FrostsparkBoots);
            item.width = 32;
            item.height = 32;
            item.value = 10000;
            item.rare = 10;
            item.accessory = true;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoonLordTrophy, 10);   //you need 10 Dirt
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.extraAccessorySlots == 0)
                {
                player.extraAccessorySlots += 2;
                player.accRunSpeed = 26.75f;
                player.noFallDmg = true;
                player.rocketBoots = 3;
                player.rocketTime += 12;
                player.aggro += 300;
                player.meleeCrit += 17;
                player.meleeDamage += 0.22f;
                player.meleeSpeed += 0.15f;
                player.moveSpeed += 2.15f;
                player.rangedCrit += 7;
                player.rangedDamage += 0.16f;
                player.maxMinions += 8;
                player.minionDamage += 0.22f;
                player.statManaMax2 += 60;
                player.manaCost -= 0.15f;
                player.magicCrit += 7;
                player.magicDamage += 1.07f;
                player.tileSpeed += 2.5f; //block placement speed
                player.blockRange += 10; //block placement range
                player.wallSpeed += 2.5f; //wall placement speed
                player.waterWalk2 = true;
                player.iceSkate = true;
                player.fireWalk = true;
                player.waterWalk = true;
                player.lavaImmune = true;
                player.maxRunSpeed += 2.15f;
                player.statDefense += 100;
                player.statLifeMax2 += 60;
                player.ignoreWater = true;
                player.accMerman = true;
                player.arcticDivingGear = true;
                player.armorPenetration = 100;
                player.findTreasure = true;
                player.accFishingLine = true;
                player.accTackleBox = true;
                player.beetleDefense = true;
                player.beetleOffense = true;
            }
            if (player.extraAccessorySlots == 1)
            {
                player.extraAccessorySlots += 1;
                player.accRunSpeed = 3.75f;
                player.noFallDmg = true;
                player.rocketBoots = 3;
                player.rocketTime += 12;
                player.aggro += 300;
                player.meleeCrit += 17;
                player.meleeDamage += 0.22f;
                player.meleeSpeed += 0.15f;
                player.moveSpeed += 2.15f;
                player.rangedCrit += 7;
                player.rangedDamage += 0.16f;
                player.maxMinions += 8;
                player.minionDamage += 0.22f;
                player.statManaMax2 += 60;
                player.manaCost -= 0.15f;
                player.magicCrit += 7;
                player.magicDamage += 1.07f;
                player.tileSpeed += 2.5f; //block placement speed
                player.blockRange += 10; //block placement range
                player.wallSpeed += 2.5f; //wall placement speed
                player.waterWalk2 = true;
                player.iceSkate = true;
                player.fireWalk = true;
                player.waterWalk = true;
                player.lavaImmune = true;
                player.maxRunSpeed += 20f;
                player.statDefense += 100;
                player.statLifeMax2 += 60;
                player.ignoreWater = true;
                player.accMerman = true;
                player.arcticDivingGear = true;
                player.armorPenetration = 100;
                player.findTreasure = true;
                player.accFishingLine = true;
                player.accTackleBox = true;
                player.beetleDefense = true;
                player.beetleOffense = true;
            }
            else
            {
                player.accRunSpeed = 3.75f;
                player.noFallDmg = true;
                player.rocketBoots = 3;
                player.rocketTime += 12;
                player.aggro += 300;
                player.meleeCrit += 17;
                player.meleeDamage += 0.22f;
                player.meleeSpeed += 0.15f;
                player.moveSpeed += 2.15f;
                player.rangedCrit += 7;
                player.rangedDamage += 0.16f;
                player.maxMinions += 8;
                player.minionDamage += 0.22f;
                player.statManaMax2 += 60;
                player.manaCost -= 0.15f;
                player.magicCrit += 7;
                player.magicDamage += 1.07f;
                player.tileSpeed += 2.5f; //block placement speed
                player.blockRange += 10; //block placement range
                player.wallSpeed += 2.5f; //wall placement speed
                player.waterWalk2 = true;
                player.iceSkate = true;
                player.fireWalk = true;
                player.waterWalk = true;
                player.lavaImmune = true;
                player.maxRunSpeed += 20f;
                player.statDefense += 100;
                player.statLifeMax2 += 60;
                player.ignoreWater = true;
                player.accMerman = true;
                player.arcticDivingGear = true;
                player.armorPenetration = 100;
                player.findTreasure = true;
                player.accFishingLine = true;
                player.accTackleBox = true;
                player.beetleDefense = true;
                player.beetleOffense = true;
            }

            if (player.controlLeft)
            {
                if (player.velocity.X > -2) player.velocity.X -= 0.25f;
                if (player.velocity.X < -2 && player.velocity.X > -8)
                {
                    player.velocity.X -= 0.23f;
                }
            }
            if (player.controlRight)
            {
                if (player.velocity.X < 2) player.velocity.X += 0.25f;
                if (player.velocity.X > 2 && player.velocity.X < 8)
                {
                    player.velocity.X += 0.23f;
                }
            }
        }
    }
}