using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.Cultist
{
    [AutoloadEquip(EquipType.Body)]
    public class CultistRobes : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Robes");
            Tooltip.SetDefault("Robes of a Lunatic Cultist"
                + "\nIncreases Magic Damage and Crit by 15%");
        }
        public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
            player.magicDamage += 15f; //15%
            player.magicCrit += 15;
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = true;
        }


        //    public override void AddRecipes()
        //	{
        //		ModRecipe recipe = new ModRecipe(mod);
        //		recipe.AddIngredient(ItemID.DirtBlock, 5);
        //		recipe.AddTile(TileID.WorkBenches);
        //		recipe.SetResult(this);
        //		recipe.AddRecipe();
        //	}
    }
}