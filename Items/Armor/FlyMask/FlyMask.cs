using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Armor.FlyMask
{
    [AutoloadEquip(EquipType.Head)]
    public class FlyMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("BzzZzz");
        }

        public override void SetDefaults()
        {
            item.width = 18; //The size in width of the sprite in pixels.
            item.height = 18;   //The size in height of the sprite in pixels.
            item.rare = 11;    //The color the title of your item when hovering over it ingame
            item.vanity = true; //this defines if this item is vanity or not.
            item.value = 100000;
        }

        public override void UpdateEquip(Player player)
        {
            player.gravControl = true;
        }

     //   public override void AddRecipes()  //How to craft this item
     //   {
     //      ModRecipe recipe = new ModRecipe(mod);
     //       recipe.AddIngredient(ItemID.DirtBlock, 10);   //you need 10 Dirt
     //       recipe.AddTile(TileID.WorkBenches);   //at work bench
     //       recipe.SetResult(this);
     //       recipe.AddRecipe();
     //   }

        public override bool DrawHead()
        {
            return true;     //this make so the player head does not disappear when the vanity mask is equipped.  return false if you want to not show the player head.
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = drawAltHair = false;  //this make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }
    }
}