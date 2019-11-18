using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Boots.Summoner
{
    [AutoloadEquip(EquipType.Shoes)]
    public class SummonersLightningLoafers : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Summoners Lightning Loafers");
            Tooltip.SetDefault("Increases Minion Damage by 10% and Max Minions by 2" + "\nAllows flight" + "\nThe wearer can run incredibly fast");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 28;
            item.value = Item.sellPrice(gold: 6);
            item.rare = 4;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SummonersSpectreLoafers", 1);
            recipe.AddIngredient(ItemID.AnkletoftheWind, 1);
            recipe.AddIngredient(ItemID.Aglet, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage += 0.1f; //10% minion damage
            player.maxMinions += 2; //Max minions
            player.accRunSpeed = 6.75f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            player.rocketBoots = 2; //default Spectre boots rocket and lightning. Frostspark = 3;
            player.moveSpeed += 0.08f; //default lightning/frostspark
            //player.iceSkate = true; //default frostspark/iceskate.
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
