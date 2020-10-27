using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.Drow
{
    [AutoloadEquip(EquipType.Body)]
    public class DrowBreastplate : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Immunity to 'On Fire!'"
                + "\n+5 critical chance strike"
                + "\n+1 Max Minions");
        }
        public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 60;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.OnFire] = true;
            player.meleeCrit += 5;
            player.magicCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
            player.maxMinions++;
		}
        public override void DrawHands(ref bool drawHands, ref bool drawaltHands) //Will draw the normal hands and arms if drawhands is set to true.
        {
            drawHands = true; //drawhands = true will set default hands and arms on. drawAltHands = true; does something else.
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