using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Dev.Mugen
{
    [AutoloadEquip(EquipType.Body)]
    public class MugenChest : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mugen Body Armor");
            Tooltip.SetDefault("+15 critical chance strike"
                + "\n+1 Max Minions"
                + "\nDev Mugen Body Armor");
        }
        public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = ItemRarityID.Cyan;
			item.defense = 100;
		}

		public override void UpdateEquip(Player player)
		{
            if (player.name == "Lab Food")
            {
                player.moveSpeed += 10f;
                player.accRunSpeed += 5f;
                player.maxRunSpeed += 100f;
                player.statDefense += 999;
                player.buffImmune[BuffID.Bleeding] = true; //Immune to Blackout, Cursed, Slow, BrokenArmor on head
                player.buffImmune[BuffID.Frozen] = true;
                player.onHitDodge = true;
                if (player.onHitDodge && player.shadowDodgeTimer == 0 && Main.rand.Next(1) == 0) //Infinite shadow dodge mawhaha!
                {
                    if (!player.shadowDodge)
                        player.shadowDodgeTimer = 25;
                    player.AddBuff(59, 600, true);
                }
            }
            else
            {
                player.buffImmune[BuffID.OnFire] = true;
                player.meleeCrit += 15;
                player.magicCrit += 15;
                player.rangedCrit += 15;
                player.thrownCrit += 15;
                player.maxMinions++;
            }
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