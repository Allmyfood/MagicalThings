using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.Cultist
{
    [AutoloadEquip(EquipType.Head)]
    public class CultistHood : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Hood");
            Tooltip.SetDefault("Hood of a Lunatic Cultist"
                + "\nIncreases maximum mana by 50 ");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 9;
			item.defense = 10;
		}

        public override void UpdateEquip(Player player)
        {
            player.statManaMax += 50;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<CultistRobes>() && legs.type == ItemType<CultistBottoms>();
		}
        
        

        public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "10% reduced mana cost";
            player.manaCost -= 0.10f; //10% reduced mana cost
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Confused] = true;
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