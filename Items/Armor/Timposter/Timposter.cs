using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Armor.Timposter
{
    [AutoloadEquip(EquipType.Head)]
    public class Timposter : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Timposter");
            Tooltip.SetDefault("The guise of the Wizard Tim!"
                + "\nIncreases maximum mana by 80 "
                + "\n15% Magic Damage");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 500000;
			item.rare = 12;
			item.defense = 18;
		}

        public override void UpdateEquip(Player player)
        {
            player.statManaMax += 80;
            player.magicDamage += 0.15f; //15%
            player.magicCrit += 10; //10%
            player.buffImmune[BuffID.Silenced] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WizardHat, 1);
            recipe.AddIngredient(ItemID.Skull, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}