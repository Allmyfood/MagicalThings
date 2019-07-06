using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Dev.Maverick
{
    [AutoloadEquip(EquipType.Head)]
    public class MaverickHelm : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Maverick Helmet");
            Tooltip.SetDefault("12% Increased movement speed"
                + "\n12% Increased melee speed"
                + "\nDev Maverick Helmet");
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
            player.moveSpeed += 0.12f; //12%
            player.meleeSpeed += 0.12f; //12%
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MaverickChest") && legs.type == mod.ItemType("MaverickBoots");
		}
        
        

        public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Maverick Dev Armor Equiped";
			player.meleeDamage *= 10.0f;
			player.thrownDamage *= 10.0f;
			player.rangedDamage *= 10.0f;
			player.magicDamage *= 10.0f;
			player.minionDamage *= 10.0f;
            player.nightVision = true;
            player.magicCrit *= 55;
            player.rangedCrit *= 55;
            player.thrownCrit *= 55;
            player.meleeCrit *= 55;
            player.meleeSpeed += 0.35f; //35%
            player.lifeRegen += 15;
            player.manaRegen += 4;
            player.statLifeMax2 += 200;
            player.statManaMax2 += 200;
            player.ammoCost75 = true;
            player.manaCost -= .75f;
            player.shroomiteStealth = true;
            player.moveSpeed += 0.15f;
            player.maxMinions++;
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