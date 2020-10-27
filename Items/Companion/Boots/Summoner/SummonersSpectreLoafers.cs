using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Boots.Summoner
{
    [AutoloadEquip(EquipType.Shoes)]
    public class SummonersSpectreLoafers : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Summoners Spectre Loafers");
            Tooltip.SetDefault("Increases Minion Damage by 8% and Max Minions by 1" + "\nAllows flight" + "\nThe wearer can run super fast");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 28;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SummonersLoafersOfHaste", 1);
            recipe.AddIngredient(ItemID.RocketBoots, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.08f; //8% minion damage
            player.maxMinions += 1; //Max minions
            player.accRunSpeed = 6.0f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            player.rocketBoots = 2; //default Spectre boots rocket and lightning. Frostspark = 3;
            //player.iceSkate = true; //default frostspark/iceskate.
            //player.moveSpeed += 0.08f; //default lightning/frostspark
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
