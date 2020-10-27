using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicalThings.Items.Companion.Boots.Mage
{
    [AutoloadEquip(EquipType.Shoes)]
    public class WizardsElementsparkSlippers : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Wizards Elementspark Slippers");
            Tooltip.SetDefault("Increases Magic Damage by 15% and Max Mana by 60" + "\nAllows flight, super fast running, immune to fall damage" + "\ncan walk on lava and water and extra mobility on ice" + "\n10% increased movement speed and max run speed" + "\nRun speed is added not set");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(gold: 20);
            item.rare = ItemRarityID.Yellow;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WizardsFrostsparkSlippers", 1);
            recipe.AddIngredient(ItemID.LavaWaders, 1);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.15f; //15% magic damage
            player.statManaMax2 += 60; //Max Mana 60
            player.accRunSpeed += 8.75f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            player.rocketBoots = 3; //default Spectre boots rocket and lightning. Frostspark = 3;
            player.iceSkate = true; //default frostspark/iceskate.
            player.moveSpeed += 0.10f; //default lightning/frostspark
            player.maxRunSpeed += 0.10f;
            player.noFallDmg = true;
            player.waterWalk = true;
            player.waterWalk2 = true;
            player.fireWalk = true;
            player.lavaMax = 600;
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}