using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Accessory
{
    [AutoloadEquip(EquipType.Shoes)]
    public class MercuryBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The wearer can run fast and is immune to fall damage");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.value = Item.sellPrice(gold: 3);
            item.rare = 2;
            item.accessory = true;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HermesBoots, 1);   //you need 10 Dirt
            recipe.AddIngredient(ItemID.LuckyHorseshoe, 1);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noFallDmg = true;
            player.accRunSpeed += 7.75f;
            player.moveSpeed += 0.15f;
            player.maxRunSpeed += 0.15f;
        }
    }
}
