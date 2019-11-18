using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Dev.Mugen
{
    [AutoloadEquip(EquipType.Head)]
    public class MugenHelm : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mugen Helmet");
            Tooltip.SetDefault("12% Increased movement speed"
                + "\n12% Increased melee speed"
                + "\nDev Mugen Helmet");
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
            player.buffImmune[BuffID.Blackout] = true; //Immune to Blackout, Cursed, Slow, BrokenArmor
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<MugenChest>() && legs.type == ItemType<MugenBoots>();
		}
        
        

        public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Mugen Dev Armor Equiped";
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
            MagicalPlayer mpm = player.GetModPlayer<MagicalPlayer>();
            mpm.MugenArmorEquiped = true;
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