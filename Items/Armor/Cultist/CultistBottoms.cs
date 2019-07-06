using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Armor.Cultist
{
    [AutoloadEquip(EquipType.Legs)]
    public class CultistBottoms : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Bottoms");
            Tooltip.SetDefault("Leggings of a Lunatic Cultist"
                + "\nIncreases your movement speed by 20%");
        }

        public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 9;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
            player.moveSpeed += 0.20f; //20% increase
		}

	//	public override void AddRecipes()
	//	{
	//		ModRecipe recipe = new ModRecipe(mod);
	//		recipe.AddIngredient(ItemID.DirtBlock, 5);
	//		recipe.AddTile(TileID.WorkBenches);
	//		recipe.SetResult(this);
	//		recipe.AddRecipe();
	//	}
	}
}