using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.GreatWizard
{
    [AutoloadEquip(EquipType.Body)]
    class GreatWizardRobes : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Great Wizard Robes");
            Tooltip.SetDefault("Look like a true wizard!"
                + "\n'I'm a wizard with over 70 confirmed kills!'");
        }
        public override void SetDefaults()
		{
			item.width = 30;
			item.height = 28;
			item.value = Item.sellPrice(gold: 1);
            item.rare = 9;
            item.vanity = true;
		}

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = true;
        }
		
		public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
		{
			robes = true;
			// The equipSlot is added in ExampleMod.cs --> Load hook
			equipSlot = mod.GetEquipSlot("GreatWizardRobes_Legs", EquipType.Legs);
		}
    }
}