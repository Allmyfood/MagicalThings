using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Boots.Mage
{
    [AutoloadEquip(EquipType.Shoes)]
    public class WizardsLightningSlippers : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Wizards Lightning Slippers");
            Tooltip.SetDefault("Increases Magic Damage by 10% and Max Mana by 30" + "\nAllows flight" + "\nThe wearer can run incredibly fast");
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
            recipe.AddIngredient(null, "WizardsSpectreSlippers", 1);
            recipe.AddIngredient(ItemID.AnkletoftheWind, 1);
            recipe.AddIngredient(ItemID.Aglet, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.1f; //10% magic damage
            player.statManaMax2 += 30; //Max Mana 30
            player.accRunSpeed = 6.75f; //Hermes Speed, Spectre. Lightning/Frostspark = 6.75f
            player.rocketBoots = 2; //default Spectre boots rocket and lightning. Frostspark = 3;
            player.moveSpeed += 0.08f; //default lightning/frostspark
            //player.iceSkate = true; //default frostspark/iceskate.
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
