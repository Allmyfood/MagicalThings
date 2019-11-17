using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicalThings.Items.Companion.Boots.Warrior
{
    [AutoloadEquip(EquipType.Shoes)]
    public class WarriorGladiators : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Warrior Gladiators");
            Tooltip.SetDefault("Increases Melee Damage and Speed by 5%");
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
            recipe.AddIngredient(ItemID.WoodenSword, 1);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.05f; //5% melee damage
            player.meleeSpeed += 0.05f; //5% melee speed
            //player.meleeCrit += 15; //+15% crit chance
            //player.moveSpeed += 0.1f; //10% increased movement speed
        }
    }
}
