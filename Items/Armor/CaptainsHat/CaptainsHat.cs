using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.CaptainsHat
{
    [AutoloadEquip(EquipType.Head)]
    public class CaptainsHat : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Captain's Hat");
            Tooltip.SetDefault("So stylish!" + "\nAaarrr!");
        }

        public override void SetDefaults()
        {
            item.width = 24; //The size in width of the sprite in pixels.
            item.height = 20;   //The size in height of the sprite in pixels.
            item.rare = 8;    //The color the title of your item when hovering over it ingame
            item.vanity = true; //this defines if this item is vanity or not.
            item.value = Item.sellPrice(gold: 40);
        }

        public override void UpdateEquip(Player player)
        {
            player.accCompass = 1;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
            drawAltHair = true;
        }
    }
}