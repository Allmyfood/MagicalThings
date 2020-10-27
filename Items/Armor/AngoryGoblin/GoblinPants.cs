using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.AngoryGoblin
{
    [AutoloadEquip(EquipType.Legs)]
    public class GoblinPants : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goblin Pants");
            Tooltip.SetDefault("Disguise as a goblin"
                + "\nMachine-gunning spiders is amazing!");
        }

        public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;
        }
	}
}