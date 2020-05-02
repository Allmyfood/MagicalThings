using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.AngoryGoblin
{
    [AutoloadEquip(EquipType.Body)]
    public class GoblinTunic : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goblin Tunic");
            Tooltip.SetDefault("Disguise as a goblin"
                + "\nWe have a very complex culture"
				+ "\nIt involves carrying wood around");
        }
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 9;
            item.vanity = true;
		}
    }
}