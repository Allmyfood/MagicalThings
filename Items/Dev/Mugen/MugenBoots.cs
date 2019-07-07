using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Dev.Mugen
{
    [AutoloadEquip(EquipType.Legs)]
    public class MugenBoots : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mugen Boots");
            Tooltip.SetDefault("15% Increased movement speed and Run Speed"
                + "\nDev Mugen Boots");
        }

        public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 9;
			item.defense = 100;
		}

		public override void UpdateEquip(Player player)
		{
            player.maxRunSpeed += 0.50f;
            player.moveSpeed += 0.15f; //15% increase
            player.noFallDmg = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.MoonLeech] = true;
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