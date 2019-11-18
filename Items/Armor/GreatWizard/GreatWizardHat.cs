using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.GreatWizard
{
    [AutoloadEquip(EquipType.Head)]
    public class GreatWizardHat : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Great Wizard Hat");
            Tooltip.SetDefault("Look like a true wizard!"
                + "\nChanneling Filbert");
        }

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 40;
			item.value = Item.sellPrice(gold: 1);
            item.rare = 9;
            item.vanity = true;
		}

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
            drawAltHair = true;
        }
    }
}