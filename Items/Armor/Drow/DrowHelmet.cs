using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Armor.Drow
{
    [AutoloadEquip(EquipType.Head)]
    public class DrowHelmet : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("7% Increased movement speed"
                + "\n12% Increased melee speed");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 5;
			item.defense = 30;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.07f; //7%
            player.meleeSpeed += 0.12f; //12%
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<DrowBreastplate>() && legs.type == ItemType<DrowLeggings>();
		}
        public override bool DrawHead()
        {
            return true;     //this make so the player head does not disappear when the vanity mask is equipped.  return false if you want to not show the player head.
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) //Will draw the normal hair if drawhair is set to true.
        {
            drawHair = true; //drawhair = true will set default hair on. drawAltHair = true; does something else.
        }

        public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Improvments To All Stats";
			player.meleeDamage += 1.8f;
			player.thrownDamage += 1.8f;
			player.rangedDamage += 1.8f;
			player.magicDamage += 1.8f;
			player.minionDamage += 1.8f;
            player.AddBuff(BuffID.NightOwl, 2);
            player.magicCrit += 1;
            player.rangedCrit += 1;
            player.thrownCrit += 1;
            player.meleeCrit += 1;
            player.meleeSpeed += 0.05f; //5%
            player.lifeRegen += 1;
            player.manaRegen += 1;
            player.statManaMax2 += 60;
            player.ammoCost75 = true;
            player.manaCost -= .25f;
            player.shroomiteStealth = true;
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