using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MagicalThings.Items.Accessory
{
    [AutoloadEquip(EquipType.Shoes)]
    public class ElementsparkBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The wearer can run super fast, immune to fall damage, can walk\n" +
                "on lava and water, and extra mobility on ice");
    }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FrostsparkBoots);
            item.width = 34;
            item.height = 28;
            item.value = 60000;
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
            player.accRunSpeed += 8.75f;
            player.rocketBoots = 3;
            player.moveSpeed += 0.2f;
            player.maxRunSpeed += 0.2f;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.waterWalk = true;
            player.waterWalk2 = true;
        }
    }
}
