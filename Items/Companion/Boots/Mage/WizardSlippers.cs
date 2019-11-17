using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Boots.Mage
{
    [AutoloadEquip(EquipType.Shoes)]
    public class WizardSlippers : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Wizard Slippers");
            Tooltip.SetDefault("Increases Magic Damage 5% and Max Mana by 10");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = Item.sellPrice(silver: 1);
            item.rare = 1;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 4);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.05f; //5% magic damage
            player.statManaMax2 += 10; //Max Mana 10
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
