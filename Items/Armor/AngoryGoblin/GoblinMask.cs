using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.AngoryGoblin
{
    [AutoloadEquip(EquipType.Head)]
    public class GoblinMask : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goblin Mask");
            Tooltip.SetDefault("Disguise as a goblin"
                + "\nI usurped the goblin thrown");
        }

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 16;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
            drawAltHair = false;
        }
    }
}