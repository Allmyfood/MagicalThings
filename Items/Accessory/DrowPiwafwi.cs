using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Accessory   //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    [AutoloadEquip(EquipType.Front, EquipType.Back)]
    public class DrowPiwafwi : ModItem
    {
        public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("A dark-hued cloak");
    }
    public override void SetDefaults()
        {
            item.width = 26; //The size in width of the sprite in pixels.
            item.height = 30;   //The size in height of the sprite in pixels.
            item.rare = ItemRarityID.Pink;    //The color the title of your item when hovering over it ingame
            item.vanity = true; //this defines if this item is vanity or not.
            item.accessory = true;
            item.value = 10000;
        }
    //    public override void AddRecipes()  //How to craft this item
    //    {
    //        ModRecipe recipe = new ModRecipe(mod);
    //        recipe.AddIngredient(ItemID.DirtBlock, 10);   //you need 10 Dirt
    //        recipe.AddTile(TileID.WorkBenches);   //at work bench
    //        recipe.SetResult(this);
    //        recipe.AddRecipe();
    //    }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.ChaosState] = true;
        }
    }
    }