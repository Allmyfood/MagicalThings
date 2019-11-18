using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace MagicalThings.Items.Accessory
{
    [AutoloadEquip(EquipType.Shoes)]
    public class ElementsparkBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The wearer can run super fast, immune to fall damage, can walk\n" +
                "on lava and water, and extra mobility on ice" + "\n10% increased movement speed and max run speed" + "\nRun speed is added not set");
    }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FrostsparkBoots);
            item.width = 34;
            item.height = 32;
            item.value = Item.sellPrice(gold: 20);
            item.rare = 8;
            item.accessory = true;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots, 1);   //you need 1 Dirt
            recipe.AddIngredient(ItemID.LavaWaders, 1);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noFallDmg = true;
            player.accRunSpeed += 8.75f; //Run Speed different call = 8.75%
            player.rocketBoots = 3;
            player.moveSpeed += 0.1f; //10% += means stacks
            player.maxRunSpeed += 0.10f; //15%
            player.fireWalk = true;
            player.lavaMax = 600; //is time /60fps so 420/60 = 7 seconds. 600 for 10 secs lava charm
            player.waterWalk = true;
            player.waterWalk2 = true;
            player.iceSkate = true;
        }
    }
}
