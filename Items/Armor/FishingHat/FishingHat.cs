using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Armor.FishingHat   //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    [AutoloadEquip(EquipType.Head)]
    public class FishingHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("So stylish!" + "\nImproves fishing!" + "\nWhen equiped in main slot");
        }

        public override void SetDefaults()
        {
            item.width = 34; //The size in width of the sprite in pixels.
            item.height = 22;   //The size in height of the sprite in pixels.
            item.rare = 3;    //The color the title of your item when hovering over it ingame
            item.vanity = true; //this defines if this item is vanity or not.
            item.value = Item.sellPrice(silver: 40);
        }

        public override void UpdateEquip(Player player)
        {
            player.sonarPotion = true;
            player.fishingSkill += 15;
        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SummerHat, 1);
            recipe.AddIngredient(ItemID.Sunglasses, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
            drawAltHair = true;
        }
    }
}