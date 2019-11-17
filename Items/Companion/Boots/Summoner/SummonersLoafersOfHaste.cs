using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Boots.Summoner
{
    [AutoloadEquip(EquipType.Shoes)]
    public class SummonersLoafersOfHaste : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Summoners Loafers of Haste");
            Tooltip.SetDefault("Increases Minion Damage by 5% and Max Minions by 1" + "\nThe wearer can run super fast");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 2;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("MagicalThings:Hermes Boots", 1);
            recipe.AddIngredient(null, "SummonersLoafers", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.05f; //5% minion damage
            player.maxMinions += 1; //Max minions
            player.accRunSpeed = 6.0f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            //player.rocketBoots = 2; //default Spectre boots rocket and lightning. Frostspark = 3;
            //player.iceSkate = true; //default frostspark/iceskate.
            //player.moveSpeed += 0.08f; //default lightning/frostspark
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
